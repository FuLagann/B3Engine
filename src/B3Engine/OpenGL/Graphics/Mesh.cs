
using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class that creates an indexed vertex array mesh</summary>
	/// <typeparam name="T">The data type of the vertex used by the mesh, needs to be a struct</typeparam>
	public class Mesh<T> : IMesh<T> where T : struct {
		#region Field Variables
		// Variables
		private int handle;
		private int attrsLength;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the handle of the mesh</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets and sets the vertex buffer of the mesh</summary>
		public IVertexBuffer<T> VertexBuffer { get; set; }
		
		/// <summary>Gets and sets the index buffer of the mesh</summary>
		public IIndexBuffer IndexBuffer { get; set; }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the mesh</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="vertexBuffer">The vertex buffer used to get all the vertex data</param>
		/// <param name="indexBuffer">The index buffer used to</param>
		public Mesh(IGame game, IVertexBuffer<T> vertexBuffer, IIndexBuffer indexBuffer) {
			this.VertexBuffer = vertexBuffer;
			this.IndexBuffer = indexBuffer;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenVertexArray();
			}
			else {
				game.OnLoad += () => {
					this.handle = GL.GenVertexArray();
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() { GL.BindVertexArray(this.handle); }
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {
			// Variables
			VertexAttributeData[] data = this.VertexBuffer.GetVertexAttributes();
			int stride = 0;
			int offset = 0;
			
			this.VertexBuffer.Bind();
			this.VertexBuffer.Buffer();
			this.IndexBuffer.Bind();
			this.IndexBuffer.Buffer();
			this.attrsLength = data.Length;
			
			foreach(VertexAttributeData attr in data) { stride += attr.stride; }
			for(int i = 0; i < data.Length; i++) {
				GL.VertexAttribPointer(i, data[i].size, (VertexAttribPointerType)data[i].dataType, data[i].isNormalized, stride, new System.IntPtr(offset));
				GL.EnableVertexAttribArray(i);
				offset += data[i].stride;
			}
			GL.BindVertexArray(0);
		}
		
		/// <summary>Renders the object</summary>
		public void Render() {
			this.Bind();
			GL.DrawElements(PrimitiveType.Triangles, this.IndexBuffer.Count, DrawElementsType.UnsignedInt, 0);
		}
		
		/// <summary>Disposes of the mesh</summary>
		public void Dispose() {
			GL.DeleteVertexArray(this.handle);
			this.VertexBuffer.Dispose();
			this.IndexBuffer.Dispose();
		}
		
		#endregion // Public Methods
	}
}

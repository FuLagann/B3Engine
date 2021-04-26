
using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class for a vertex array that renders an array of vertices</summary>
	/// <typeparam name="T">The data type of the vertex, needs to be a struct</typeparam>
	public class VertexArray<T> : IVertexArray<T> where T : struct {
		#region Field Variables
		// Variables
		private int handle;
		private int attrsLength;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the vertex buffer used by the vertex array</summary>
		public IVertexBuffer<T> VertexBuffer { get; set; }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets and sets the rendering type of the vertex array</summary>
		public RenderType RenderType { get; set; }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for a vertex array</summary>
		/// <param name="game">The game used for setting up the vertex array properly</param>
		/// <param name="vertexBuffer">The vertex buffer used by the vertex array</param>
		/// <param name="renderType">The type of rendering done by the vertex array, defaults to <see cref="B3.Graphics.RenderType.Triangles"/></param>
		public VertexArray(IGame game, IVertexBuffer<T> vertexBuffer, RenderType renderType = RenderType.Triangles) {
			this.VertexBuffer = vertexBuffer;
			this.RenderType = renderType;
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
			GL.DrawArrays((PrimitiveType)this.RenderType, 0, this.VertexBuffer.Count);
		}
		
		/// <summary>Disposes of the vertex array</summary>
		public void Dispose() {
			this.VertexBuffer.Dispose();
			GL.DeleteVertexArray(this.handle);
		}
		
		#endregion // Public Methods
	}
}

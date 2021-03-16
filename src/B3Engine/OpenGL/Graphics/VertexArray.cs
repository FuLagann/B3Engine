
using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class for a vertex array that renders an array of vertices</summary>
	/// <typeparam name="T">The data type of the vertex, needs to be a struct</typeparam>
	public class VertexArray<T> : IVertexArray<T> where T : struct {
		#region Field Variables
		// Variables
		private int handle;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the vertex buffer used by the vertex array</summary>
		public IVertexBuffer<T> VertexBuffer { get; set; }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for a vertex array</summary>
		/// <param name="game"></param>
		/// <param name="vertexBuffer"></param>
		public VertexArray(IGame game, IVertexBuffer<T> vertexBuffer) {
			this.VertexBuffer = vertexBuffer;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenVertexArray();
			}
			else {
				game.OnLoad += delegate(EventArgs args) {
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
			
			this.VertexBuffer.Bind();
			this.VertexBuffer.Buffer();
			foreach(VertexAttributeData attr in data) { stride += attr.size; }
			for(int i = 0; i < data.Length; i++) {
				GL.VertexAttribPointer(i, data[i].size, (VertexAttribPointerType)data[i].dataType, data[i].isNormalized, stride, System.IntPtr.Zero);
			}
		}
		
		/// <summary>Renders the object with no special shading</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		public void Render(IGame game) { this.Render(game.DefaultProgram); }
		
		/// <summary>Renders the object with a specific shading program</summary>
		/// <param name="program">The shader program used to render the object</param>
		public void Render(IShaderProgram program) {
			if(program != null) {
				program.Use();
			}
			this.Bind();
			GL.DrawArrays(PrimitiveType.Triangles, 0, this.VertexBuffer.Count);
		}
		
		/// <summary>Disposes of the vertex array</summary>
		public void Dispose() {
			this.VertexBuffer.Dispose();
			GL.DeleteVertexArray(this.handle);
		}
		
		#endregion // Public Methods
	}
}

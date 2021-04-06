
using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class that holds a buffer for all the indices in a mesh/model</summary>
	public class IndexBuffer : IIndexBuffer {
		#region Field Variables
		// Variables
		private int handle;
		private int[] indices;
		private BufferUsage type;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get; }
		
		/// <summary>Gets and sets the list of indices that make up the index buffer</summary>
		public int[] Indices { get; set; }
		
		/// <summary>Gets the size of the index buffer</summary>
		public int Count { get; }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating an index buffer</summary>
		/// <param name="game">The game to check if it's initialized or not and generate the buffer appropriately</param>
		/// <param name="indices">The list of indices to place into the buffer</param>
		/// <param name="type">The type of usage the index buffer would have with the data</param>
		public IndexBuffer(IGame game, int[] indices, BufferUsage type) {
			this.indices = indices ?? new int[0];
			this.type = type;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenBuffer();
			}
			else {
				game.OnLoad += delegate(EventArgs args) {
					this.handle = GL.GenBuffer();
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() { GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.handle); }
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {
			this.Bind();
			GL.BufferData(BufferTarget.ElementArrayBuffer, this.Count * sizeof(int), System.IntPtr.Zero, this.type.ToOpenGL());
		}
		
		/// <summary>Disposes of the index buffer</summary>
		public void Dispose() { GL.DeleteBuffer(this.handle); }
		
		#endregion // Public Methods
	}
}


using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class that holds a buffer for all the indices in a mesh/model</summary>
	public sealed class IndexBuffer : IIndexBuffer {
		#region Field Variables
		// Variables
		private int handle;
		private uint[] indices;
		private BufferUsage type;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets and sets the list of indices that make up the index buffer</summary>
		/// <remarks>Remember to <see cref="B3.Graphics.IndexBuffer.Bind"/> and <see cref="B3.Graphics.IndexBuffer.Buffer"/> afterwards</remarks>
		public uint[] Indices { get { return this.indices; } set {
			if(this.IsStatic || value == null) {
				Logger.Warning(this.IsStatic ?
					"Vertex buffer is static but trying to be modified" :
					"Vertex buffer is trying to be modified with a null array"
				);
				return;
			}
			this.indices = value;
		} }
		
		/// <summary>Gets the size of the index buffer</summary>
		public int Count { get { return this.indices.Length; } }
		
		/// <summary>Gets if the vertex buffer is static</summary>
		public bool IsStatic { get {
			return (
				type != BufferUsage.DynamicCopy
				&& type != BufferUsage.DynamicDraw
				&& type != BufferUsage.DynamicRead
			);
		} }
		
		/// <summary>Gets and sets the type of usage</summary>
		public BufferUsage BufferUsageType { get { return this.type; } set { this.type = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating an index buffer</summary>
		/// <param name="game">The game to check if it's initialized or not and generate the buffer appropriately</param>
		/// <param name="indices">The list of indices to place into the buffer</param>
		/// <param name="type">The type of usage the index buffer would have with the data</param>
		public IndexBuffer(IGame game, uint[] indices, BufferUsage type) {
			this.indices = indices ?? new uint[0];
			this.type = type;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenBuffer();
			}
			else {
				game.OnLoad += () => {
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
			GL.BufferData(
				BufferTarget.ElementArrayBuffer,
				this.Count * sizeof(uint),
				this.indices,
				this.type.ToOpenGL()
			);
		}
		
		/// <summary>Disposes of the index buffer</summary>
		public void Dispose() { GL.DeleteBuffer(this.handle); }
		
		#endregion // Public Methods
	}
}

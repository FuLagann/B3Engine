
namespace B3.Graphics.Testing {
	public sealed class DummyIndexBuffer : IIndexBuffer {
		#region Public Properties
		
		/// <summary>Gets and sets the list of indices that make up the index buffer</summary>
		public uint[] Indices { get; set; }
		
		/// <summary>Gets the size of the index buffer</summary>
		public int Count { get { return this.Indices.Length; } }
		
		/// <summary>Gets if the vertex buffer is static</summary>
		public bool IsStatic { get { return false; } }
		
		/// <summary>Gets and sets the type of usage</summary>
		public BufferUsage BufferUsageType { get; set; }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return 0; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		public DummyIndexBuffer(uint[] indices, BufferUsage type) {
			this.Indices = indices ?? new uint[0];
			this.BufferUsageType = type;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() {}
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {}
		
		/// <summary>Dispoes of the index buffer</summary>
		public void Dispose() {}
		
		#endregion // Public Methods
	}
}


namespace B3.Graphics.Testing {
	public sealed class DummyVertexBuffer<T> : IVertexBuffer<T> where T : struct {
		#region Public Properties
		
		/// <summary>Gets if the vertex buffer is static</summary>
		public bool IsStatic { get { return false; } }
		
		/// <summary>Gets and sets the type of usage</summary>
		public BufferUsage BufferUsageType { get; set; }
		
		/// <summary>Gets and sets the vertices within the buffer</summary>
		public T[] Vertices { get; set; }
		
		/// <summary>Gets the size of the buffer</summary>
		public int Count { get { return this.Vertices.Length; } }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return 0; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		public DummyVertexBuffer(T[] vertices, BufferUsage type) {
			this.BufferUsageType = type;
			this.Vertices = vertices ?? new T[0];
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() {}
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {}
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			if(this.Vertices != null && this.Vertices.Length > 0 && this.Vertices[0] is IVertexAttributable) {
				// Variables
				IVertexAttributable attr = this.Vertices[0] as IVertexAttributable;
				
				return attr.GetVertexAttributes();
			}
			
			return new VertexAttributeData[0];
		}
		
		/// <summary>Disposes of the vertex buffer</summary>
		public void Dispose() {}
		
		#endregion // Public Methods
	}
}

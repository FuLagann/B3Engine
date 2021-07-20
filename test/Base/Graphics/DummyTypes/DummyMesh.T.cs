
namespace B3.Graphics.Testing {
	public sealed class DummyMesh<T> : IMesh<T> where T : struct {
		#region Public Properties
		
		/// <summary>Gets and sets the index buffer of the mesh</summary>
		public IIndexBuffer IndexBuffer { get; set; }
		
		/// <summary>Gets and sets the vertex buffer used by the vertex array</summary>
		public IVertexBuffer<T> VertexBuffer { get; set; }
		
		/// <summary>Gets and sets the rendering type of the vertex array</summary>
		public RenderType RenderType { get; set; }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return 0; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		public DummyMesh(IVertexBuffer<T> vertexBuffer, IIndexBuffer indexBuffer, RenderType type) {
			this.VertexBuffer = vertexBuffer;
			this.IndexBuffer = indexBuffer;
			this.RenderType = type;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Renders the object</summary>
		public void Render() {}
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() {}
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {}
		
		/// <summary>Disposes of the mesh</summary>
		public void Dispose() {}
		
		#endregion // Public Methods
	}
}

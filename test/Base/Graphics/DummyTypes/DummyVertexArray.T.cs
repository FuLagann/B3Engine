
namespace B3.Graphics.Testing {
	public sealed class DummyVertexArray<T> : IVertexArray<T> where T : struct {
		#region Public Properties
		
		/// <summary>Gets and sets the vertex buffer used by the vertex array</summary>
		public IVertexBuffer<T> VertexBuffer { get; set; }
		
		/// <summary>Gets and sets the rendering type of the vertex array</summary>
		public RenderType RenderType { get; set; }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return 0; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		public DummyVertexArray(IVertexBuffer<T> buffer, RenderType type) {
			this.VertexBuffer = buffer;
			this.RenderType = type;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() {}
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {}
		
		/// <summary>Renders the object</summary>
		public void Render() {}
		
		/// <summary>Disposes of the vertex array</summary>
		public void Dispose() {}
		
		#endregion // Public Methods
	}
}

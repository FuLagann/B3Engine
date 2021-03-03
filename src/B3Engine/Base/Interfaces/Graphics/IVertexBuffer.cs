
namespace B3.Graphics {
	/// <summary>An interface for vertex buffers</summary>
	public interface IVertexBuffer<T> : IGraphicsBuffer where T : struct {
		#region Properties
		
		/// <summary>Gets if the vertex buffer is static</summary>
		bool IsStatic { get; }
		
		/// <summary>Gets and sets the type of usage</summary>
		BufferUsage BufferUsageType { get; set; }
		
		/// <summary>Gets and sets the vertices within the buffer</summary>
		T[] Vertices { get; set; }
		
		#endregion // Properties
	}
}


namespace B3.Graphics {
	/// <summary>An interface for a general vertex array that can be rendered</summary>
	/// <typeparam name="T">The data type of the vertex, needs to be a struct</typeparam>
	public interface IVertexArray<T> : IRenderable, IGraphicsBuffer where T : struct {
		#region Properties
		
		/// <summary>Gets and sets the vertex buffer used by the vertex array</summary>
		IVertexBuffer<T> VertexBuffer { get; set; }
		
		#endregion // Properties
	}
}

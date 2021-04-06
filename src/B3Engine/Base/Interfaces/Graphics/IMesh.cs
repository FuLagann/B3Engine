
namespace B3.Graphics {
	/// <summary>An interface for a general indexed vertex array mesh that can be rendered</summary>
	/// <typeparam name="T">The data type of the vertex, needs to be a struct</typeparam>
	public interface IMesh<T> : IVertexArray<T> where T : struct {
		#region Properties
		
		/// <summary>Gets and sets the index buffer of the mesh</summary>
		IIndexBuffer IndexBuffer { get; set; }
		
		#endregion // Properties
	}
}

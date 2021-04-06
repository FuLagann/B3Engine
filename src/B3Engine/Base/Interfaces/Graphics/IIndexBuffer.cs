
namespace B3.Graphics {
	/// <summary>An interface for the index buffer</summary>
	public interface IIndexBuffer : IGraphicsBuffer {
		#region Properties
		
		/// <summary>Gets and sets the list of indices that make up the index buffer</summary>
		int[] Indices { get; set; }
		
		/// <summary>Gets the size of the index buffer</summary>
		int Count { get; }
		
		#endregion // Properties
	}
}

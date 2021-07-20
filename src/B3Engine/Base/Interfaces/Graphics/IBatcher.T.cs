
namespace B3.Graphics {
	/// <summary>An interface for a general purpose batcher</summary>
	/// <typeparam name="T">The type of vertex used to batch with</typeparam>
	/// <remarks>
	/// The batcher in question might be more specific, so
	/// <see cref="B3.Graphics.IBatcher{T}.Batch(ref T)"/>,
	/// <see cref="B3.Graphics.IBatcher{T}.Batch(ref T, ref T)"/>, and
	/// <see cref="B3.Graphics.IBatcher{T}.Batch(ref T, ref T, ref T)"/> are mutually exclusive
	/// and should throw an exception if the wrong method is used on the wrong type of batcher
	/// </remarks>
	public interface IBatcher<T> : IRenderable where T : struct {
		#region Properties
		
		/// <summary>Gets and sets the size of the batch of vertices being used to render with</summary>
		int BatchSize { get; set; }
		
		/// <summary>Gets the current size of the batcher</summary>
		int Count { get; }
		
		/// <summary>Gets the batcher's current vertex data</summary>
		T[] VertexData { get; }
		
		/// <summary>Gets the batcher's current index data</summary>
		/// <remarks>
		/// Not all batchers will use this and will return null.
		/// Check <see cref="B3.Graphics.IBatcher{T}.HasIndexData"/>
		/// to make sure that the data exists
		/// </remarks>
		uint[] IndexData { get; }
		
		/// <summary>Gets if the batcher has any index data</summary>
		bool HasIndexData { get; }
		
		#endregion // Properties
		
		#region Methods
		
		/// <summary>Sends the batcher a single point to render</summary>
		/// <param name="point">The point to render</param>
		void Batch(ref T point);
		
		/// <summary>Sends the batcher two points to render a line segment</summary>
		/// <param name="segA">The first point that makes a line segment</param>
		/// <param name="segB">The second point that makes a line segment</param>
		void Batch(ref T segA, ref T segB);
		
		/// <summary>Sends the batcher three points to render a triangle</summary>
		/// <param name="triA">The first point that makes a triangle</param>
		/// <param name="triB">The second point that makes a triangle</param>
		/// <param name="triC">The third point that makes a triangle</param>
		void Batch(ref T triA, ref T triB, ref T triC);
		
		/// <summary>Sends the batcher an array of vertices along with an array of indices</summary>
		/// <param name="newVertices">The list of vertices to add</param>
		/// <param name="newIndices">The list of indices to add</param>
		void Batch(T[] newVertices, uint[] newIndices);
		
		/// <summary>Immediately renders what's on the batcher to render a new batch</summary>
		void Flush();
		
		#endregion // Methods
	}
}


using System.Collections.Generic;

namespace B3.Graphics {
	/// <summary>A batcher class that only renders lines</summary>
	/// <typeparam name="T">The vertex type that gets rendered by the batcher</typeparam>
	public sealed class LineBatcher<T> : IBatcher<T> where T : struct {
		#region Field Variables
		// Variables
		private IVertexArray<T> array;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the size of the batch of vertices being used to render with</summary>
		public int BatchSize { get; set; }
		
		/// <summary>Gets the current size of the batcher</summary>
		public int Count { get; }
		
		/// <summary>Gets the batcher's current vertex data</summary>
		public T[] VertexData { get { return this.array.VertexBuffer.Vertices; } }
		
		/// <summary>Gets the batcher's current index data</summary>
		/// <remarks>
		/// Not all batchers will use this and will return null.
		/// Check <see cref="B3.Graphics.IBatcher{T}.HasIndexData"/>
		/// to make sure that the data exists
		/// </remarks>
		public uint[] IndexData { get { return null; } }
		
		/// <summary>Gets if the batcher has any index data</summary>
		public bool HasIndexData { get { return false; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating the line batcher</summary>
		/// <param name="array">An empty vertex array to be used by the batcher</param>
		/// <param name="batchSize">The size of the batch before flushing and making another batch</param>
		public LineBatcher(IVertexArray<T> array, int batchSize = 4000) {
			this.BatchSize = batchSize;
			this.array = array;
			if(!this.IsRenderingLines()) { this.array.RenderType = RenderType.Lines; }
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Sends the batcher a single point to render</summary>
		/// <param name="point">The point to render</param>
		public void Batch(ref T point) { throw new System.NotImplementedException(); }
		
		/// <summary>Sends the batcher two points to render a line segment</summary>
		/// <param name="segA">The first point that makes a line segment</param>
		/// <param name="segB">The second point that makes a line segment</param>
		public void Batch(ref T segA, ref T segB) {
			if(this.BatchSize > 0 && this.Count >= this.BatchSize) {
				this.Flush();
			}
			
			// Variables
			IVertexBuffer<T> buffer = this.array.VertexBuffer;
			List<T> lines = new List<T>(buffer.Vertices);
			
			lines.Add(segA);
			lines.Add(segB);
			
			buffer.Vertices = lines.ToArray();
			this.array.VertexBuffer = buffer;
		}
		
		/// <summary>Sends the batcher three points to render a triangle</summary>
		/// <param name="triA">The first point that makes a triangle</param>
		/// <param name="triB">The second point that makes a triangle</param>
		/// <param name="triC">The third point that makes a triangle</param>
		public void Batch(ref T triA, ref T triB, ref T triC) { throw new System.NotImplementedException(); }
		
		/// <summary>Sends the batcher an array of vertices along with an array of indices</summary>
		/// <param name="newVertices">The list of vertices to add</param>
		/// <param name="newIndices">The list of indices to add</param>
		public void Batch(T[] newVertices, uint[] newIndices) { throw new System.NotImplementedException(); }
		
		/// <summary>Renders the object</summary>
		public void Render() { this.array.Render(); }
		
		/// <summary>Immediately renders what's on the batcher to render a new batch</summary>
		public void Flush() {
			this.array.Bind();
			this.array.Buffer();
			this.Render();
			
			// Variables
			IVertexBuffer<T> buffer = this.array.VertexBuffer;
			
			buffer.Vertices = new T[0];
			this.array.VertexBuffer = buffer;
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Finds if the vertex array is using any line type rendering type</summary>
		/// <returns>Returns true if the vertex array is rendering liens</returns>
		private bool IsRenderingLines() {
			return (
				this.array.RenderType == RenderType.Lines ||
				this.array.RenderType == RenderType.LineLoop ||
				// this.array.RenderType == RenderType.LinesAdjacency ||
				this.array.RenderType == RenderType.LineStrip //||
				// this.array.RenderType == RenderType.LineStripAdjacency
			);
		}
		
		#endregion // Private Methods
	}
}

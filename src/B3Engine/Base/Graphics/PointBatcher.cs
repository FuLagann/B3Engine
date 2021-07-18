
using System.Collections.Generic;

namespace B3.Graphics {
	/// <summary>A batcher that only batches and renders points</summary>
	/// <typeparam name="T">The vertex type that gets rendered by the batcher</typeparam>
	public sealed class PointBatcher<T> : IBatcher<T> where T : struct {
		#region Field Variables
		// Variables
		private IVertexArray<T> array;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the size of the batch of vertices being used to render with</summary>
		public int BatchSize { get; set; }
		
		/// <summary>Gets the current size of the batcher</summary>
		public int Count { get { return this.array.VertexBuffer.Count; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the point batcher</summary>
		/// <param name="array">An empty vertex array to be used by the batcher</param>
		/// <param name="batchSize">The size of the batch before flushing and making another batch</param>
		public PointBatcher(IVertexArray<T> array, int batchSize = 2000) {
			this.BatchSize = batchSize;
			this.array = array;
			this.array.RenderType = RenderType.Points;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Sends the batcher a single point to render</summary>
		/// <param name="point">The point to render</param>
		public void Batch(ref T point) {
			if(this.BatchSize > 0 && this.Count >= this.BatchSize) {
				this.Flush();
			}
			
			// Variables
			IVertexBuffer<T> buffer = this.array.VertexBuffer;
			List<T> points = new List<T>(buffer.Vertices);
			
			points.Add(point);
			buffer.Vertices = points.ToArray();
			this.array.VertexBuffer = buffer;
		}
		
		/// <summary>Sends the batcher two points to render a line segment</summary>
		/// <param name="segA">The first point that makes a line segment</param>
		/// <param name="segB">The second point that makes a line segment</param>
		public void Batch(ref T segA, ref T segB) { throw new System.NotImplementedException(); }
		
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
	}
}

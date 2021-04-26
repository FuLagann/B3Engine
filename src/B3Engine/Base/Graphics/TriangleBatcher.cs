
using System.Collections.Generic;

namespace B3.Graphics {
	/// <summary>A batcher that only batches and renders triangles</summary>
	/// <typeparam name="T">The vertex type that gets rendered by the batcher</typeparam>
	public sealed class TriangleBatcher<T> : IBatcher<T> where T : struct {
		#region Field Variables
		// Variables
		private IMesh<T> mesh;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the size of the batch of vertices being used to render with</summary>
		public int BatchSize { get; set; }
		
		/// <summary>Gets the current size of the batcher</summary>
		public int Count { get { return this.mesh.VertexBuffer.Count; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor that sets up the triangle/mesh batcher</summary>
		/// <param name="mesh">An empty mesh to be used by the batcher</param>
		/// <param name="batchSize">The size of the batch before flushing and making another batch</param>
		public TriangleBatcher(IMesh<T> mesh, int batchSize = 6000) {
			this.BatchSize = batchSize;
			this.mesh = mesh;
			if(!this.IsRenderingTriangles()) { this.mesh.RenderType = RenderType.Triangles; }
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Sends the batcher a single point to render</summary>
		/// <param name="point">The point to render</param>
		public void Batch(ref T point) { throw new System.NotImplementedException(); }
		
		/// <summary>Sends the batcher two points to render a line segment</summary>
		/// <param name="segA">The first point that makes a line segment</param>
		/// <param name="segB">The second point that makes a line segment</param>
		public void Batch(ref T segA, ref T segB) { throw new System.NotImplementedException(); }
		
		/// <summary>Sends the batcher three points to render a triangle</summary>
		/// <param name="triA">The first point that makes a triangle</param>
		/// <param name="triB">The second point that makes a triangle</param>
		/// <param name="triC">The third point that makes a triangle</param>
		public void Batch(ref T triA, ref T triB, ref T triC) {
			if(this.BatchSize > 0 && this.Count >= this.BatchSize) {
				this.Flush();
			}
			
			// Variables
			IVertexBuffer<T> vbuffer = this.mesh.VertexBuffer;
			IIndexBuffer ibuffer = this.mesh.IndexBuffer;
			List<T> vertices = new List<T>(vbuffer.Vertices);
			List<uint> indices = new List<uint>(ibuffer.Indices);
			T temp = triA;
			int index = vertices.FindIndex((T vert) => vert.Equals(temp));
			
			if(index == -1) {
				indices.Add((uint)vertices.Count);
				vertices.Add(triA);
			}
			else { indices.Add((uint)index); }
			
			temp = triB;
			index = vertices.FindIndex((T vert) => vert.Equals(temp));
			if(index == -1) {
				indices.Add((uint)vertices.Count);
				vertices.Add(triB);
			}
			else { indices.Add((uint)index); }
			
			temp = triC;
			index = vertices.FindIndex((T vert) => vert.Equals(temp));
			if(index == -1) {
				indices.Add((uint)vertices.Count);
				vertices.Add(triC);
			}
			else { indices.Add((uint)index); }
			
			vbuffer.Vertices = vertices.ToArray();
			ibuffer.Indices = indices.ToArray();
			this.mesh.VertexBuffer = vbuffer;
			this.mesh.IndexBuffer = ibuffer;
		}
		
		/// <summary>Renders the object</summary>
		public void Render() {
			this.mesh.Render();
		}
		
		/// <summary>Immediately renders what's on the batcher to render a new batch</summary>
		public void Flush() {
			this.mesh.Bind();
			this.mesh.Buffer();
			this.Render();
			
			// Variables
			IVertexBuffer<T> vbuffer = this.mesh.VertexBuffer;
			IIndexBuffer ibuffer = this.mesh.IndexBuffer;
			
			vbuffer.Vertices = new T[0];
			ibuffer.Indices = new uint[0];
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Finds if the renderer is rendering with triangles</summary>
		/// <returns>Returns true if the renderer is rendering with triangles</returns>
		private bool IsRenderingTriangles() {
			return (
				this.mesh.RenderType == RenderType.Triangles ||
				this.mesh.RenderType == RenderType.TriangleFan ||
				// this.mesh.RenderType == RenderType.TrianglesAdjacency ||
				this.mesh.RenderType == RenderType.TriangleStrip //||
				// this.mesh.RenderType == RenderType.TriangleStripAdjacency
			);
		}
		
		#endregion // Private Methods
	}
}

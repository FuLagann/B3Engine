
using Xunit;

using B3.Graphics.VertexStructures;

namespace B3.Graphics.Testing {
	/// <summary>Tests the <see cref="B3.Graphics.Renderer"/> class to make sure it's correct. Contains 3 test</summary>
	public class RendererTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Graphics.Renderer.Batch(IConvertable{Vertex3PC})"/> functionality.
		/// Batches 6 points with 2 points being positionally identical and checks if it's correct
		/// </summary>
		[Fact]
		public void Batch_SixPoints_ReturnsBatchedPointVertices() {
			// Variables
			Renderer renderer = new DummyRenderer();
			Vertex3PC[] expected = new Vertex3PC[] {
				new Vertex3PC(Vector3.Zero, new Color("red")),
				new Vertex3PC(Vector3.One, new Color("green")),
				new Vertex3PC(new Vector3(1, 2, 3), new Color("blue")),
				new Vertex3PC(new Vector3(-1, -2, -3), new Color("yellow")),
				new Vertex3PC(Vector3.Zero, new Color("magenta"))
			};
			Vertex3PC[] actual;
			
			renderer.Batch(new Vertex3PC(Vector3.Zero, new Color("red")));
			renderer.Batch(new Vertex3PC(Vector3.One, new Color("green")));
			renderer.Batch(new Vertex3PC(new Vector3(1, 2, 3), new Color("blue")));
			renderer.Batch(new Vertex3PC(new Vector3(-1, -2, -3), new Color("yellow")));
			renderer.Batch(new Vertex3PC(Vector3.Zero, new Color("magenta")));
			actual = renderer.BatchedPointVertices;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Graphics.Renderer.FlushPointBatcher"/> funciontality.
		/// Batches some points of the renderer, flushes them, and checks to see if it's correct
		/// </summary>
		[Fact]
		public void FlushPointBatcher_SixPoints_ReturnsEmptyArray() {
			// Variables
			Renderer renderer = new DummyRenderer();
			Vertex3PC[] expected = new Vertex3PC[0];
			Vertex3PC[] actual;
			
			renderer.Batch(new Vertex3PC(Vector3.Zero, new Color("red")));
			renderer.Batch(new Vertex3PC(Vector3.One, new Color("green")));
			renderer.Batch(new Vertex3PC(new Vector3(1, 2, 3), new Color("blue")));
			renderer.Batch(new Vertex3PC(new Vector3(-1, -2, -3), new Color("yellow")));
			renderer.Batch(new Vertex3PC(Vector3.Zero, new Color("magenta")));
			renderer.FlushPointBatcher();
			actual = renderer.BatchedPointVertices;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Graphics.Renderer.Batch(IConvertable{Vertex3PC}, IConvertable{Vertex3PC})"/> functionality.
		/// Batches three lines and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Batch_ThreeLines_ReturnsBatchedLineVertices() {
			// Variables
			Renderer renderer = new DummyRenderer();
			Vertex3PC[] expected = new Vertex3PC[] {
				new Vertex3PC(new Vector3(0, 0, 0), new Color("red")),
				new Vertex3PC(new Vector3(1, 1, 1), new Color("green")),
				new Vertex3PC(new Vector3(1, 1, 1), new Color("blue")),
				new Vertex3PC(new Vector3(1, 0, 0), new Color("yellow")),
				new Vertex3PC(new Vector3(1, 0, 0), new Color("magenta")),
				new Vertex3PC(new Vector3(0, 0, 0), new Color("cyan"))
			};
			Vertex3PC[] actual;
			
			renderer.Batch(
				new Vertex3PC(new Vector3(0, 0, 0), new Color("red")),
				new Vertex3PC(new Vector3(1, 1, 1), new Color("green"))
			);
			renderer.Batch(
				new Vertex3PC(new Vector3(1, 1, 1), new Color("blue")),
				new Vertex3PC(new Vector3(1, 0, 0), new Color("yellow"))
			);
			renderer.Batch(
				new Vertex3PC(new Vector3(1, 0, 0), new Color("magenta")),
				new Vertex3PC(new Vector3(0, 0, 0), new Color("cyan"))
			);
			actual = renderer.BatchedLineVertices;
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

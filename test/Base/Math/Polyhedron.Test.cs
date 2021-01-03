
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class PolyhedronTest {
		// Variables
		private ITestOutputHelper output;
		
		public PolyhedronTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			// Variables
			Polyhedron p = new Polyhedron(new Vector3[] {
				new Vector3(0, 0, 0),
				new Vector3(1, 2, 3),
				new Vector3(4, 5, 6)
			});
			
			Assert.Equal(new Polyhedron(new Vector3[0]), Polyhedron.Empty);
			Assert.Equal(Vector3.Zero, p[0]);
			Assert.Equal(new Vector3(1, 2, 3), p[1]);
			Assert.Equal(new Vector3(4, 5, 6), p[2]);
			Assert.Equal(new Vector3(5, 7, 9), p[1] + p[2]);
		}
		
		[Theory]
		[InlineData(4.25, 1.75, 2.75, new float[] { 1, 1, 1, 2, 3, 4, 4, 1, 2, 10, 2, 4 })]
		[InlineData(0, 0, 0, new float[] {})]
		[InlineData(3, 2, 1, new float[] {3, 2, 1})]
		[InlineData(-0.8, 0.8, 0.8, new float[] { 0, 0, 0, 3, 2, 1, -4, 5, 6, -1, -1, -1, -2, -2, -2 })]
		public void Center(float ex, float ey, float ez, float[] xyz) {
			// Variables
			Vector3[] a = new Vector3[xyz.Length/3];
			Polyhedron b;
			Vector3 e = new Vector3(ex, ey, ez);
			
			
			for(int i = 0; i < a.Length; i++) {
				a[i] = new Vector3(xyz[3 * i], xyz[3 * i + 1], xyz[3 * i + 2]);
			}
			
			b = new Polyhedron(a);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(b.Center.ToString());
			
			Assert.True(Vector3.Approx(e, b.Center));
		}
	}
}

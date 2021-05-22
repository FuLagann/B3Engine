
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class PlaneTest {
		// Variables
		private ITestOutputHelper output;
		
		public PlaneTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		// [Fact]
		// public void Constructors() {
		// 	// Variables
		// 	Plane a = new Plane(Vector3.One, 1.0f);
			
		// 	Assert.Equal(0.57735026f * Vector3.One, a.Normal);
		// 	Assert.Equal(1.0f, a.Distance);
			
		// 	a = Plane.XYPlane;
		// 	Assert.Equal(Vector3.UnitZ, a.Normal);
		// 	Assert.Equal(0.0f, a.Distance);
			
		// 	a = Plane.XZPlane;
		// 	Assert.Equal(Vector3.UnitY, a.Normal);
		// 	Assert.Equal(0.0f, a.Distance);
			
		// 	a = Plane.YZPlane;
		// 	Assert.Equal(Vector3.UnitX, a.Normal);
		// 	Assert.Equal(0.0f, a.Distance);
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0)]
		// [InlineData(1, 0, 1, -1, 0, 0, 2, 0, 2, 0, 1, 0, 0)]
		// [InlineData(0, 10, 1, 0, 20, 20, 0, -50, -100, 1, 0, 0, 0)]
		// [InlineData(1, 0, 0, 0, 1, 0, 0, 0, 1, 0.57735026, 0.57735026, 0.57735026, -0.57735026)]
		// public void CreateFromThreePoints(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float ex, float ey, float ez, float ed) {
		// 	// Variables
		// 	Vector3 a = new Vector3(x0, y0, z0);
		// 	Vector3 b = new Vector3(x1, y1, z1);
		// 	Vector3 c = new Vector3(x2, y2, z2);
		// 	Plane e = new Plane(new Vector3(ex, ey, ez), ed);
		// 	Plane actual = Plane.CreateFromThreePoints(ref a, ref b, ref c);
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + actual);
			
		// 	Assert.True(
		// 		Vector3.Approx(e.Normal, actual.Normal) && 
		// 		Mathx.Approx(e.Distance, actual.Distance)
		// 	);
		// }
	}
}


using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class PlaneTest {
		// Variables
		private ITestOutputHelper output;
		
		public PlaneTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			// Variables
			Plane a = new Plane(Vector3.One, 1.0f);
			
			Assert.Equal(0.57735026f * Vector3.One, a.Normal);
			Assert.Equal(1.0f, a.Distance);
			
			a = Plane.XYPlane;
			Assert.Equal(Vector3.UnitZ, a.Normal);
			Assert.Equal(0.0f, a.Distance);
			
			a = Plane.XZPlane;
			Assert.Equal(Vector3.UnitY, a.Normal);
			Assert.Equal(0.0f, a.Distance);
			
			a = Plane.YZPlane;
			Assert.Equal(Vector3.UnitX, a.Normal);
			Assert.Equal(0.0f, a.Distance);
		}
		
		[Theory]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0)]
		[InlineData(1, 0, 1, -1, 0, 0, 2, 0, 2, 0, 1, 0, 0)]
		[InlineData(0, 10, 1, 0, 20, 20, 0, -50, -100, 1, 0, 0, 0)]
		[InlineData(1, 0, 0, 0, 1, 0, 0, 0, 1, 0.57735026, 0.57735026, 0.57735026, -0.57735026)]
		public void CreateFromThreePoints(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float ex, float ey, float ez, float ed) {
			// Variables
			Vector3 a = new Vector3(x0, y0, z0);
			Vector3 b = new Vector3(x1, y1, z1);
			Vector3 c = new Vector3(x2, y2, z2);
			Plane e = new Plane(new Vector3(ex, ey, ez), ed);
			Plane actual = Plane.CreateFromThreePoints(ref a, ref b, ref c);
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + actual);
			
			Assert.True(
				Vector3.Approx(e.Normal, actual.Normal) && 
				Mathx.Approx(e.Distance, actual.Distance)
			);
		}
		
		// [Theory]
		// [InlineData(1, 0, 0, 0, 0, 10, 10, true)]
		// [InlineData(1, 0, 0, 0, 1, 10, 10, false)]
		// [InlineData(0, 1, 0, 0, 10, 0, 10, true)]
		// [InlineData(0, 0, 1, 0, 10, 10, 0, true)]
		// [InlineData(1, 1, 0, 8, 9.656854, 1.656854, -10, true)]
		// [InlineData(1, 1, 0, 8, 9.656854, 1.6568, -10, false)]
		// [InlineData(1, 2, 3, 4, 0.5286549, 0.8260232, 1.189474, false)]
		// [InlineData(1, 2, 3, 4, 1.78, 3.59332, 2, false)]
		// public void Contains(float nx, float ny, float nz, float d, float x, float y, float z, bool e) {
		// 	// Variables
		// 	Vector3 a = new Vector3(x, y, z);
		// 	Plane b = new Plane(nx, ny, nz, d);
			
		// 	Assert.Equal(e, b.Contains(a));
		// }
		
		// [Theory]
		// [InlineData(1,2, 3, 3, 0, 6, 7, -2, -1, -8, true, -1.5553594, 5.2223206, 0.77856255, 6.4598923)]
		// [InlineData(1, 0, 1, 0, 1, 1, 1, 1, 1, 1, false, 1, 1, 1, 0)]
		// [InlineData(1, 0, 1, 4, 1, 1, 1, 1, 1, 1, true, 2.8284273, 2.8284273, 2.8284273, 3.1669288)]
		// [InlineData(0, 1, 0, 0, 0, 10, 0, 1, -1, 2, true, 10, 0, 20, 24.494898)]
		// [InlineData(1, 0, 0, 0, 1, 0, 0, 1, 0, 0, false, 1, 0, 0, 0)]
		// public void Intersects_Ray(float nx, float ny, float nz, float d, float ox, float oy, float oz, float dx, float dy, float dz, bool e, float ex, float ey, float ez, float ed) {
		// 	// Variables
		// 	Plane plane = new Plane(nx, ny, nz, d);
		// 	Ray ray = new Ray(new Vector3(ox, oy, oz), new Vector3(dx, dy, dz));
		// 	IntersectionInfo info = plane.Intersects(ray);
		// 	Vector3 ep = new Vector3(ex, ey, ez);
			
		// 	Assert.Equal(e, info.hasIntersected);
		// 	Assert.Equal(ep, info.impactPoint);
		// 	Assert.Equal(ed, info.distance);
		// }
	}
}

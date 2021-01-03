
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class SphereTest {
		// Variables
		private ITestOutputHelper output;
		
		public SphereTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			Assert.Equal(new Sphere(0, 0, 0, 0), Sphere.Empty);
			Assert.Equal(new Sphere(0, 0, 0, 1), Sphere.Unit);
		}
		
		[Theory]
		[InlineData(4, 0, 1, 5, 5, 0, -1, 5, 4.5, 0, 0, 6.118034)]
		[InlineData(4, 0, 1, -10, 0, 0, 0, 5, 4, 0, 1, -10)]
		[InlineData(4, 0, 1, -4, 0, 6, 7, 5, 1.786799, 3.319801, 4.319801, 9.190415)]
		[InlineData(4, 0, 0, 10, 4, 6, 7, 5, 4, 1.373022, 1.601859, 12.10977)]
		public void Encompass(float ax, float ay, float az, float ar, float bx, float by, float bz, float br, float ex, float ey, float ez, float er) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			Sphere e = new Sphere(ex, ey, ez, er);
			
			a = Sphere.Encompass(ref a, ref b);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(
				Mathx.Approx(ref e.center, ref a.center, 0.00001f) &&
				Mathx.Approx(e.radius, a.radius, 0.00001f)
			);
		}
		
		[Theory]
		[InlineData(4, 0, 0, 10, 4, 6, 7, 5, 1, 0, 0, 10, 3.362874, 1.081426, 1.261663, 12.88868)]
		[InlineData(1, 2, 3, 4, 0, 0, 0, 1, 1, 1, 1, 1, 0.9008919, 1.801784, 2.702676, 4.370829)]
		[InlineData(1, 2, 3, 5, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 3, 5)]
		[InlineData(1, -3, 3, -3, -2, 0, 0, 3, 1, 1, 1, 5, 0.09836006, -0.5027337, 1.300547, 6.778058)]
		public void EncompassRange(float ax, float ay, float az, float ar, float bx, float by, float bz, float br, float cx, float cy, float cz, float cr, float ex, float ey, float ez, float er) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			Sphere c = new Sphere(cx, cy, cz, cr);
			Sphere e = new Sphere(ex, ey, ez, er);
			
			a = Sphere.Encompass(a, b, c);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(
				Mathx.Approx(ref e.center, ref a.center, 0.00001f) &&
				Mathx.Approx(e.radius, a.radius, 0.00001f)
			);
		}
		
		[Theory]
		[InlineData(true, 0, 0, 0, 3, 0, -3, 0, 1)]
		[InlineData(true, 0, 0, 0, 3, 0, -4, 0, -3)]
		[InlineData(false, 0, 0, 0, 3, 0, -5, 0, -1)]
		[InlineData(true, 0, 0, 0, 3, 0, 0, 0, 2)]
		[InlineData(true, 0, 0, 0, 2, 0, 0, 0, 3)]
		[InlineData(false, 1, 2, 3, 4, -1, -1, -1, -1)]
		[InlineData(true, 1, 2, 3, 4, -1, -2, -3, -4)]
		[InlineData(true, 1, 2, 3, 4, 3, 2, 1, 0.4)]
		[InlineData(true, 1, 2, 3, 4, 3, 2, 1, 4)]
		public void IsOverlapping(bool isTrue, float ax, float ay, float az, float ar, float bx, float by, float bz, float br) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			
			if(isTrue)	Assert.True(Sphere.IsOverlapping(ref a, ref b));
			else	Assert.False(Sphere.IsOverlapping(ref a, ref b));
		}
		
		[Theory]
		[InlineData(false, 0, 0, 0, 3, 0, -3, 0, 1)]
		[InlineData(false, 0, 0, 0, 3, 0, -4, 0, -3)]
		[InlineData(true, 0, 0, 0, 3, 0, -5, 0, -1)]
		[InlineData(false, 0, 0, 0, 3, 0, 0, 0, 2)]
		[InlineData(false, 0, 0, 0, 2, 0, 0, 0, 3)]
		[InlineData(true, 1, 2, 3, 4, -1, -1, -1, -1)]
		[InlineData(false, 1, 2, 3, 4, -1, -2, -3, -4)]
		[InlineData(false, 1, 2, 3, 4, 3, 2, 1, 0.4)]
		[InlineData(false, 1, 2, 3, 4, 3, 2, 1, 4)]
		public void IsDisjoint(bool isTrue, float ax, float ay, float az, float ar, float bx, float by, float bz, float br) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			
			if(isTrue)	Assert.True(Sphere.IsDisjoint(ref a, ref b));
			else	Assert.False(Sphere.IsDisjoint(ref a, ref b));
		}
		
		[Theory]
		[InlineData(false, 0, 0, 0, 3, 0, -3, 0, 1)]
		[InlineData(false, 0, 0, 0, 3, 0, -4, 0, -3)]
		[InlineData(false, 0, 0, 0, 3, 0, -5, 0, -1)]
		[InlineData(true, 0, 0, 0, 3, 0, 0, 0, 2)]
		[InlineData(false, 0, 0, 0, 2, 0, 0, 0, 3)]
		[InlineData(false, 1, 2, 3, 4, -1, -1, -1, -1)]
		[InlineData(false, 1, 2, 3, 4, -1, -2, -3, -4)]
		[InlineData(true, 1, 2, 3, 4, 3, 2, 1, 0.4)]
		[InlineData(false, 1, 2, 3, 4, 3, 2, 1, 4)]
		public void IsContained(bool isTrue, float ax, float ay, float az, float ar, float bx, float by, float bz, float br) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			
			if(isTrue)	Assert.True(Sphere.IsContained(ref a, ref b));
			else	Assert.False(Sphere.IsContained(ref a, ref b));
		}
		
		// [Theory]
		// [InlineData(0, 0, 0, 10, 0, 0, 0, true)]
		// [InlineData(0, 0, 0, 10, 10, 0, 0, true)]
		// [InlineData(0, 0, 0, 10, 10, 10, 0, false)]
		// [InlineData(0, 0, 0, 10, 5.7735026919, 5.7735026919, 5.7735026919, true)]
		// [InlineData(10, 20, 30, 40, -10, -20, -10, false)]
		// [InlineData(10, 20, 30, 40, -10, 10, 0, true)]
		// public void Contains(float cx, float cy, float cz, float cr, float x, float y, float z, bool e) {
		// 	// Variables
		// 	Vector3 a = new Vector3(x, y, z);
		// 	Sphere b = new Sphere(cx, cy, cz, cr);
			
		// 	Assert.Equal(e, b.Contains(a));
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 10, 12, 0, 3, -3, 2, -3, true, 9.860277, 1.4264817, 0.86027777, 3.345396)]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, false, 5, 6, 7, 0)]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, -1, -2, -3, true, 4.0938363, 4.1876726, 4.2815084, 3.3905544)]
		// [InlineData(2, 8, 1, 10, 1, 1, 1, 0, 1, -1, true, 1, 10.603277, -8.603277, 13.581085)]
		// [InlineData(2, 8, 1, 2, 1, 1, 1, 0, 1, -1, false, 1, 1, 1, 0)]
		// [InlineData(2, 8, 1, 2, 5, 5, 4, -1, 1, -1, true, 3.1547003, 6.8452997, 2.1547003, 3.1961527)]
		// [InlineData(2, 8, 1, 3, 5, 5, 4, -1, 1, -1, true, 3.732051, 6.267949, 2.732051, 2.1961524)]
		// public void Intersects_Ray(float cx, float cy, float cz, float r, float ox, float oy, float oz, float dx, float dy, float dz, bool e, float ex, float ey, float ez, float ed) {
		// 	// Variables
		// 	Sphere sphere = new Sphere(cx, cy, cz, r);
		// 	Ray ray = new Ray(new Vector3(ox, oy, oz), new Vector3(dx, dy, dz));
		// 	IntersectionInfo info = sphere.Intersects(ray);
		// 	Vector3 ep = new Vector3(ex, ey, ez);
			
		// 	Assert.Equal(e, info.hasIntersected);
			
		// 	this.output.WriteLine("Expected: " + ep);
		// 	this.output.WriteLine("Actual: " + info.impactPoint);
			
		// 	Assert.True(Mathx.Approx(ref ep, ref info.impactPoint, 0.000001f));
		// 	Assert.Equal(ed, info.distance);
		// }
	}
}


using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class BoxTest {
		// Variables
		private ITestOutputHelper output;
		
		public BoxTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Theory]
		[InlineData(10, 0, 1, 100, -100, 0, 10, 110, -100, 0, 1, 1)]
		public void Constructors(float x, float y, float z, float w, float h, float d, float left, float right, float top, float bottom, float near, float far) {
			// Variables
			Box a = new Box(x, y, z, w, h, d);
			
			Assert.Equal(a.Left, left);
			Assert.Equal(a.Right, right);
			Assert.Equal(a.Top, top);
			Assert.Equal(a.Bottom, bottom);
			Assert.Equal(a.Near, near);
			Assert.Equal(a.Far, far);
			
			Assert.Equal(a.FarTopLeft, new Vector3(left, top, far));
			Assert.Equal(a.NearTopLeft, new Vector3(left, top, near));
			Assert.Equal(a.FarBottomLeft, new Vector3(left, bottom, far));
			Assert.Equal(a.NearBottomLeft, new Vector3(left, bottom, near));
			Assert.Equal(a.FarTopRight, new Vector3(right, top, far));
			Assert.Equal(a.NearTopRight, new Vector3(right, top, near));
			Assert.Equal(a.FarBottomRight, new Vector3(right, bottom, far));
			Assert.Equal(a.NearBottomRight, new Vector3(right, bottom, near));
		}
		
		[Theory]
		[InlineData(0, 0, 0, 1, 1, 1, 5, 5, 5, 2, 2, 2, 0, 0, 0, 7, 7, 7)]
		[InlineData(-3.7, -1.7, -1.7, 11.1, 1.6, 1.7, 2.1, 2.7, -5.1, 0.6, 1, 17, -3.7, -1.7, -5.1, 11.1, 5.4, 17)]
		[InlineData(-0.5, -0.5, -0.5, 2, 2, 2, 1.5, 1.5, 1.5, -2, -2, -2, -0.5, -0.5, -0.5, 2, 2, 2)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, -1, -1, 2, 2, 2, -1, -1, -1, 2, 2, 2)]
		public void Encompass(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, float ex, float ey, float ez, float ew, float eh, float ed) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box e = new Box(ex, ey, ez, ew, eh, ed);
			
			Assert.Equal(e, Box.Encompass(ref a, ref b));
		}
		
		[Theory]
		[InlineData(0, 0, 0, 1, 1, 1, 1.5, 0.6, -0.2, 2, 2, 2, 1.6, -3.4, 0.2, 2.4, 6.8, 2, 0, -3.4, -0.2, 4.0, 6.8, 2.4)]
		[InlineData(-2, 7, 4, 14, 2, 2, 7, -2, 7, 2, 14, 2, 4, 4, -2, 2, 2, 14, -2, -2, -2, 14, 14, 14)]
		[InlineData(-2, 6.7, 4, 14, 2.6, 2, 14, -2, 7, -12, 14, 2, 14.2, 7.6, -2, -20, 2, 14, -5.8, -2, -2, 20, 14, 14)]
		[InlineData(0, 0, 0, 2, 2, 2, -2, 0.1, -3.7, 1.2, 0.8, 3.6, -4, -4, -4, 8, 8, 8, -4, -4, -4, 8, 8, 8)]
		public void EncompassRange(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, float cx, float cy, float cz, float cw, float ch, float cd, float ex, float ey, float ez, float ew, float eh, float ed) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box c = new Box(cx, cy, cz, cw, ch, cd);
			Box e = new Box(ex, ey, ez, ew, eh, ed);
			
			Assert.Equal(e, Box.EncompassRange(a, b, c));
		}
		
		[Theory]
		[InlineData(-5.7, 8.8, 3.8, 9.4, 3.2, 3.7, 1.8, -3, 6, 8.1, 12.8, 2, true)]
		[InlineData(-5.7, 5.6, 3.8, 9.4, 7.3, 3.7, 6.5, 5.7, 10.9, -7.7, 3.1, -12.3, true)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1, -1, 4, 4, 4, true)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1.1, -1, 4, 4, 4, false)]
		[InlineData(-4, -4, -4, 8, 8, 8, 0, 0, 0, 2, 2, 2, true)]
		public void IsOverlapping(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, bool isTrue) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			
			if(isTrue)	Assert.True(Box.IsOverlapping(ref a, ref b));
			else	Assert.False(Box.IsOverlapping(ref a, ref b));
		}
		
		[Theory]
		[InlineData(-5.7, 8.8, 3.8, 9.4, 3.2, 3.7, 1.8, -3, 6, 8.1, 12.8, 2, false)]
		[InlineData(-5.7, 5.6, 3.8, 9.4, 7.3, 3.7, 6.5, 5.7, 10.9, -7.7, 3.1, -12.3, false)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1, -1, 4, 4, 4, false)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1.1, -1, 4, 4, 4, false)]
		[InlineData(-4, -4, -4, 8, 8, 8, 0, 0, 0, 2, 2, 2, true)]
		[InlineData(6, 6, 6, -8, -8, -8, 0, 0, 0, 2, 2, 2, true)]
		public void IsContained(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, bool isTrue) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			
			if(isTrue)	Assert.True(Box.IsContained(ref a, ref b));
			else	Assert.False(Box.IsContained(ref a, ref b));
		}
		
		[Theory]
		[InlineData(-5.7, 8.8, 3.8, 9.4, 3.2, 3.7, 1.8, -3, 6, 8.1, 12.8, 2, false)]
		[InlineData(-5.7, 5.6, 3.8, 9.4, 7.3, 3.7, 6.5, 5.7, 10.9, -7.7, 3.1, -12.3, false)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1, -1, 4, 4, 4, false)]
		[InlineData(-1, -1, -1, 2, 2, 2, -1, 1.1, -1, 4, 4, 4, true)]
		[InlineData(-4, -4, -4, 8, 8, 8, 0, 0, 0, 2, 2, 2, false)]
		public void IsDisjoint(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, bool isTrue) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			
			if(isTrue)	Assert.True(Box.IsDisjoint(ref a, ref b));
			else	Assert.False(Box.IsDisjoint(ref a, ref b));
		}
		
		[Theory]
		[InlineData(-4, -4, -4, 8, 8, 8, 0, 0, 0, 2, 2, 2, 0, 0, 0, 2, 2, 2)]
		[InlineData(-4, -4, -4, 8, 8, 8, 3, 2.6, 2.5, 2, 2, 2, 3, 2.6, 2.5, 1, 1.4, 1.5)]
		[InlineData(-4, -4, -4, 8, 8, 8, -5, 3, -1.5, 2, 2, 2, -4, 3, -1.5, 1, 1, 2)]
		[InlineData(-4, -4, -4, 8, 8, 8, -7.1, -0.9, -5.6, 2, 2, 2, -4, -0.9, -4, 0, 2, 0.4)]
		public void Clip(float ax, float ay, float az, float aw, float ah, float ad, float bx, float by, float bz, float bw, float bh, float bd, float ex, float ey, float ez, float ew, float eh, float ed) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box e = new Box(ex, ey, ez, ew, eh, ed);
			Box c = Box.Clip(ref a, ref b);
			
			this.output.WriteLine("Expected: ");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual: ");
			this.output.WriteLine(c.ToString());
			
			Assert.True(
				Mathx.Approx(e.x, c.x) &&
				Mathx.Approx(e.y, c.y) &&
				Mathx.Approx(e.z, c.z) &&
				Mathx.Approx(e.width, c.width) &&
				Mathx.Approx(e.height, c.height) &&
				Mathx.Approx(e.depth, c.depth)
			);
		}
		
		[Theory]
		[InlineData(2, 0.5, -2, 4, 5, 6, 7, 8, 9, 4, 5, 6, 14, 4, -18)]
		[InlineData(0, 1, -2, 1, 2, 3, 1, 2, 3, 1, 2, 3, 0, 2, -6)]
		public void Scale(float widthScalar, float heightScalar, float depthScalar, float ax, float ay, float az, float aw, float ah, float ad, float ex, float ey, float ez, float ew, float eh, float ed) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box e = new Box(ex, ey, ez, ew, eh, ed);
			
			Assert.Equal(e, Box.Scale(widthScalar, heightScalar, depthScalar, ref a));
		}
		
		// [Theory]
		// [InlineData(0, 0, 0, 20, 20, 20, 0, 0, 0, true)]
		// [InlineData(0, 0, 0, 20, 20, 20, 0, 10, 10, true)]
		// [InlineData(0, 0, 0, 20, 20, 20, -1, 10, 10, false)]
		// [InlineData(-10, -10, -10, 20, 20, 20, -10, 10, -10, true)]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, false)]
		// [InlineData(1, 2, 3, 4, 5, 6, 1, 2, 3, true)]
		// public void Contains(float bx, float by, float bz, float bw, float bh, float bd, float x, float y, float z, bool e) {
		// 	// Variables
		// 	Vector3 a = new Vector3(x, y, z);
		// 	Box b = new Box(bx, by, bz, bw, bh, bd);
			
		// 	Assert.Equal(e, b.Contains(a));
		// }
		
		// [Theory]
		// [InlineData(-8, -8, -8, 16, 16, 16, 2, 5, 2, 1, 2, 1, true, 3.5, 8, 3.5, 3.6742349)]
		// [InlineData(-8, -8, -8, 16, 16, 16, 2, 5, 2, -1, -2, -1, true, -4.5, -8, -4.5, 15.921684)]
		// [InlineData(-4, -4, -4, 8, 8, 8, 2, 5, 2, 1, 2, 1, false, 2, 5, 2, 0)]
		// [InlineData(-4, -4, -4, 8, 8, 8, -6, -6, 0, 1, 2, 1, true, -4, -2, 2, 4.8989797)]
		// [InlineData(-4, -4, -4, 8, 8, 8, 4, 5, 0.5, -4, -2, 0, true, 2, 4, 0.5, 2.236068)]
		// [InlineData(-4, -4, -4, 8, 8, 8, 4, 5, 1.5, -4, -2, 6, false, 4, 5, 1.5, 0)]
		// public void Intersects_Ray(float x, float y, float z, float w, float h, float d, float ox, float oy, float oz, float dx, float dy, float dz, bool e, float ex, float ey, float ez, float ed) {
		// 	// Variables
		// 	Box box = new Box(x, y, z, w, h, d);
		// 	Ray ray = new Ray(new Vector3(ox, oy, oz), new Vector3(dx, dy, dz));
		// 	IntersectionInfo info = box.Intersects(ray);
		// 	Vector3 ep = new Vector3(ex, ey, ez);
			
		// 	Assert.Equal(e, info.hasIntersected);
		// 	Assert.Equal(ep, info.impactPoint);
		// 	Assert.Equal(ed, info.distance);
		// }
	}
}

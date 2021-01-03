
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class RectangleTest {
		// Variables
		private ITestOutputHelper output;
		
		public RectangleTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Theory]
		[InlineData(10, 10, 20, 20, 10, 15, 15, 15, 15, 10, 15, 15)]
		[InlineData(0, 10, 30, 20, 10, 10, -10, 10, 10, 10, 20, 20)]
		public void Encompass(float ex, float ey, float ew, float eh, float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh) {
			// Variables
			Rectangle e = new Rectangle(ex, ey, ew, eh);
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			
			Assert.Equal(e, Rectangle.Encompass(ref a, ref b));
		}
		
		[Theory]
		[InlineData(0, 0, 30, 30, 10, 15, 15, 15, 15, 10, 15, 15, 10, 20, -10, -20)]
		[InlineData(0, 10, 30, 20, 10, 10, -10, 10, 10, 10, 20, 20, 15, 15, 5, 5)]
		public void EncompassRange(float ex, float ey, float ew, float eh, float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh, float cx, float cy, float cw, float ch) {
			// Variables
			Rectangle e = new Rectangle(ex, ey, ew, eh);
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			Rectangle c = new Rectangle(cx, cy, cw, ch);
			
			Assert.Equal(e, Rectangle.EncompassRange(a, b, c));
		}
		
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, true)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, true)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, true)]
		public void IsOverlapping(float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh, bool result) {
			// Variables
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			
			this.output.WriteLine(a.ToString());
			this.output.WriteLine(b.ToString());
			
			Assert.Equal(result, Rectangle.IsOverlapping(ref a, ref b));
		}
		
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, false)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, false)]
		[InlineData(25, 25, 100, 100, 50, 50, 50, 50, true)]
		[InlineData(50, 50, 50, 50, 50, 50, 50, 50, true)]
		[InlineData(50, 50, 50, 50, 50, 50, 25, 25, true)]
		public void IsContained(float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh, bool result) {
			// Variables
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			
			this.output.WriteLine(a.ToString());
			this.output.WriteLine(b.ToString());
			
			Assert.Equal(result, Rectangle.IsContained(ref a, ref b));
		}
		
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, 50, 50, 0, 0)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, 50, 50, 0, 20)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, 80, 80, 20, 20)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, 100, 100, 0, 0)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, 50, 50, 50, 50)]
		[InlineData(25, 25, 100, 100, 50, 50, 50, 50, 50, 50, 50, 50)]
		[InlineData(50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50)]
		[InlineData(50, 50, 50, 50, 50, 50, 25, 25, 50, 50, 25, 25)]
		[InlineData(50, 50, 0, 0, 25, 25, 100, 100, 50, 50, 0, 0)]
		[InlineData(0, 0, 0, 0, 25, 25, 25, 25, 0, 0, 0, 0)]
		public void Clip(float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh, float ex, float ey, float ew, float eh) {
			// Variables
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			Rectangle e = new Rectangle(ex, ey, ew, eh);
			
			this.output.WriteLine(a.ToString());
			this.output.WriteLine(b.ToString());
			
			Assert.Equal(e, Rectangle.Clip(ref a, ref b));
		}
		
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, false)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, true)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, true)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, false)]
		public void IsDisjoint(float ax, float ay, float aw, float ah, float bx, float by, float bw, float bh, bool result) {
			// Variables
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle b = new Rectangle(bx, by, bw, bh);
			
			this.output.WriteLine(a.ToString());
			this.output.WriteLine(b.ToString());
			
			Assert.Equal(result, Rectangle.IsDisjoint(ref a, ref b));
		}
		
		[Theory]
		[InlineData(0.5f, 0.5f, 50, 50, 50, 50, 50, 50, 25, 25, true)]
		[InlineData(2, 2, 50, 50, 50, 50, 50, 50, 100, 100, false)]
		[InlineData(0.5, 2, 0, 0, 100, 100, 0, 0, 50, 200, false)]
		public void Scale(float ws, float hs, float ax, float ay, float aw, float ah, float ex, float ey, float ew, float eh, bool isSingle) {
			// Variables
			Rectangle a = new Rectangle(ax, ay, aw, ah);
			Rectangle e = new Rectangle(ex, ey, ew, eh);
			
			this.output.WriteLine(a.ToString());
			this.output.WriteLine(e.ToString());
			
			if(isSingle) Assert.Equal(e, Rectangle.Scale(ws, ref a));
			else Assert.Equal(e, Rectangle.Scale(ws, hs, ref a));
		}
		
		[Theory]
		[InlineData(10, 10, 50, 50, 10, 10, 25, 25, 0, 0, 100, 100, 0, 0, 50, 50)]
		public void ParallelScale(float ox, float oy, float ow, float oh, float ix, float iy, float iw, float ih, float px, float py, float pw, float ph, float ex, float ey, float ew, float eh) {
			// Variables
			Rectangle o = new Rectangle(ox, oy, ow, oh);
			Rectangle i = new Rectangle(ix, iy, iw, ih);
			Rectangle p = new Rectangle(px, py, pw, ph);
			Rectangle e = new Rectangle(ex, ey, ew, eh);
			
			Assert.Equal(e, Rectangle.ParallelScale(ref o, ref i, ref p));
		}
		
		// [Theory]
		// [InlineData(10, 10, 100, 100, 0, 0, false)]
		// [InlineData(10, 10, 100, 100, 10, 10, true)]
		// [InlineData(10, 10, 100, 100, 24, 100, true)]
		// [InlineData(10, 10, 100, 100, 24, 110, true)]
		// [InlineData(10, 10, 100, 100, 24, 111, false)]
		// [InlineData(10, 10, 100, 100, 110, 110, true)]
		// [InlineData(10, 10, 100, 100, 111, 110, false)]
		// public void Contains(float x, float y, float w, float h, float px, float py, bool e) {
		// 	// Variables
		// 	Rectangle a = new Rectangle(x, y, w, h);
		// 	Vector2 p = new Vector2(px, py);
			
		// 	Assert.Equal(e, a.Contains(p));
		// }
		
		// [Theory]
		// [InlineData(6, 6, 8, 8, 0, 0, -1, 0, 0, 1, false, 0, 0, -1, 0)]
		// [InlineData(6, 6, 8, 8, 0, 0, -10, 1, 1, 1, true, 10, 10, 0, 17.320509)]
		// [InlineData(-4, -4, 8, 8, 2, -2, -1, 2, 2, 2, true, 3, -1, 0, 1.7320509)]
		// [InlineData(-4, -4, 8, 8, 0, 0, 0, 1, 2, 3, true, 0, 0, 0, 0)]
		// [InlineData(-4, -4, 8, 8, 0, 0, 0, 1, 2, 0, true, 2, 4, 0, 4.472136)]
		// public void Intersects_Ray(float x, float y, float w, float h, float ox, float oy, float oz, float dx, float dy, float dz, bool e, float ex, float ey, float ez, float ed) {
		// 	// Variables
		// 	Rectangle a = new Rectangle(x, y, w, h);
		// 	Ray b = new Ray(new Vector3(ox, oy, oz), new Vector3(dx, dy, dz));
		// 	IntersectionInfo info = a.Intersects(b);
		// 	Vector3 ep = new Vector3(ex, ey, ez);
			
		// 	Assert.Equal(e, info.hasIntersected);
		// 	Assert.Equal(ep, info.impactPoint);
		// 	Assert.Equal(ed, info.distance);
		// }
	}
}

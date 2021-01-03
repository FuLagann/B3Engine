
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class PolygonTest {
		// Variables
		private ITestOutputHelper output;
		
		public PolygonTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			// Variables
			Polygon p = new Polygon(new Vector2[] {
				new Vector2(0, 0),
				new Vector2(1, 2),
				new Vector2(3, 4),
			});
			Assert.Equal(new Polygon(new Vector2[0]), Polygon.Empty);
			Assert.Equal(new Vector2(0, 0), p[0]);
			Assert.Equal(new Vector2(1, 2), p[1]);
			Assert.Equal(new Vector2(3, 4), p[2]);
			Assert.Equal(new Vector2(4, 6), p[1] + p[2]);
		}
		
		[Theory]
		[InlineData(1, 2.1666667, new float[] { 0, 0, 6, 0, 0, 1, 0, 2, 0, 4, 0, 6 })]
		[InlineData(0, 0, new float[] { 4, -3, 4, 3, -4, 3, 0, -5, -4, -3, 0, 5 })]
		[InlineData(1.41666667, 1.70833333, new float[] { 3.5f, -0.95f, 6.04f, 6.27f, 1.1f, 6.57f, -2.3f, -1.28f, -0.14f, -2.24f, 0.3f, 1.88f })]
		[InlineData(0, 0, new float[] {})]
		[InlineData(2, 1, new float[] {2, 1})]
		public void Center(float ex, float ey, float[] xy) {
			// Variables
			Vector2[] a = new Vector2[xy.Length/2];
			Polygon b;
			Vector2 e = new Vector2(ex, ey);
			
			
			for(int i = 0; i < a.Length; i++) {
				a[i] = new Vector2(xy[2 * i], xy[2 * i + 1]);
			}
			
			b = new Polygon(a);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(b.Center.ToString());
			
			Assert.True(Vector2.Approx(e, b.Center));
		}
		
		[Theory]
		[InlineData(1, 3, new float[] { 0, 1, 2, 3, 0, 0, 1, 1 }, new float[] { 0, 1, 2, 3, 0, 0, 1, 1, 1, 3 })]
		[InlineData(2, 2, new float[] { 1, 1, 3, 3 }, new float[] { 1, 1, 3, 3, 2, 2})]
		public void Add(float x, float y, float[] xy, float[] exy) {
			// Variables
			Vector2[] a = new Vector2[xy.Length/2];
			Vector2[] ev = new Vector2[exy.Length/2];
			Polygon b, e;
			
			
			for(int i = 0; i < a.Length; i++) {
				a[i] = new Vector2(xy[2 * i], xy[2 * i + 1]);
			}
			for(int i = 0; i < ev.Length; i++) {
				ev[i] = new Vector2(exy[2 * i], exy[2 * i + 1]);
			}
			b = new Polygon(a);
			e = new Polygon(ev);
			
			Polygon.Add(ref b, new Vector2(x, y));
			
			Assert.Equal(e, b);
		}
		
		[Theory]
		[InlineData(1, 3, new float[] { 0, 1, 1, 3, 0, 0, 1, 1 }, new float[] { 0, 1, 0, 0, 1, 1 })]
		[InlineData(2, 2, new float[] { 1, 1, 3, 3 }, new float[] { 1, 1, 3, 3})]
		[InlineData(0, 0, new float[] { 0, 0, 0, 0 }, new float[] { 0, 0})]
		[InlineData(0, 0, new float[] { 0, 0 }, new float[] {})]
		public void Remove(float x, float y, float[] xy, float[] exy) {
			// Variables
			Vector2[] a = new Vector2[xy.Length/2];
			Vector2[] ev = new Vector2[exy.Length/2];
			Polygon b, e;
			
			
			for(int i = 0; i < a.Length; i++) {
				a[i] = new Vector2(xy[2 * i], xy[2 * i + 1]);
			}
			for(int i = 0; i < ev.Length; i++) {
				ev[i] = new Vector2(exy[2 * i], exy[2 * i + 1]);
			}
			b = new Polygon(a);
			e = new Polygon(ev);
			
			Polygon.Remove(ref b, new Vector2(x, y));
			
			Assert.Equal(e, b);
		}
	}
}

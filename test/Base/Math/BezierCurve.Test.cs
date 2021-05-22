
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class BezierCurveTest {
		// Variables
		private ITestOutputHelper output;
		
		public BezierCurveTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		// [Theory]
		// [InlineData(10, new float[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1 })]
		// [InlineData(3, new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// public void Constructors(float duration, float[] vertices) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(duration, points);
			
		// 	this.output.WriteLine("Duration: E: " + duration + ", A: " + curve.Duration);
		// 	Assert.Equal(duration, curve.Duration);
		// 	Assert.Equal(points, curve.Points);
		// }
		
		// [Theory]
		// [InlineData(4, 0, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.08333334, 0.05324074f, 0.6365741f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.1666667, 0.2037037f, 1.203704f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.25, 0.4375f, 1.6875f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.3333333, 0.7407408f, 2.074074f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.4166667, 1.099537f, 2.349537f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.5, 1.5f, 2.5f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.5833334, 1.928241f, 2.511574f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.6666667, 2.37037f, 2.37037f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.75, 2.8125f, 2.0625f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.8333334, 3.240741f, 1.574074f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 0.9166667, 3.641204f, 0.8912035f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// [InlineData(4, 1, 4f, 0f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		// public void Value(float duration, float t, float ex, float ey, float ez, float[] vertices) {
		// 	// Variables
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(duration, points);
			
		// 	curve.Time = t;
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + curve.Value);
			
		// 	Assert.True(Vector3.Approx(e, curve.Value, 0.000001f));
		// }
		// [Theory]
		// [InlineData(4, 0, 0f, 0f, 12f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.08333334, 0.3310184f, 1.12037f, 9.243056f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.1666667, 0.6481482f, 1.851852f, 6.944444f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.25, 0.9375f, 2.25f, 5.0625f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.3333333, 1.185185f, 2.37037f, 3.555555f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.4166667, 1.377315f, 2.268518f, 2.381944f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.5, 1.5f, 2f, 1.5f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.5833334, 1.539352f, 1.62037f, 0.8680553f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.6666667, 1.481481f, 1.185185f, 0.4444444f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.75, 1.3125f, 0.75f, 0.1875f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.8333334, 1.018518f, 0.3703702f, 0.05555551f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 0.9166667, 0.585648f, 0.1018518f, 0.006944439f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// [InlineData(4, 1, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		// public void Value_Backwards(float duration, float t, float ex, float ey, float ez, float[] vertices) {
		// 	// Variables
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(duration, points);
			
		// 	curve.Time = t;
		// 	curve.LoopType = InterpolationLoopType.NoLoopBackwards;
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + curve.Value);
			
		// 	Assert.True(Vector3.Approx(e, curve.Value, 0.00001f));
		// }
		
		// [Theory]
		// [InlineData(0, 0, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		// [InlineData(0, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 1 })]
		// [InlineData(0, 0, 1, new float[] {}, new float[] { 0, 0, 1 })]
		// public void Add(float x, float y, float z, float[] v, float[] e1) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	Vector3[] e = new Vector3[e1.Length / 3];
		// 	for(int i = 0; i < e.Length; i++) {
		// 		e[i] = new Vector3(e1[3 * i], e1[3 * i + 1], e1[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	curve.Add(a);
			
		// 	Assert.Equal(e, curve.Points);
		// }
		
		// [Theory]
		// [InlineData(1, 0, 1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		// [InlineData(1, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		// [InlineData(1, 0, 1, new float[] {}, new float[] {})]
		// public void Remove(float x, float y, float z, float[] v, float[] e1) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	Vector3[] e = new Vector3[e1.Length / 3];
		// 	for(int i = 0; i < e.Length; i++) {
		// 		e[i] = new Vector3(e1[3 * i], e1[3 * i + 1], e1[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	curve.Remove(a);
			
		// 	Assert.Equal(e, curve.Points);
		// }
		
		// [Theory]
		// [InlineData(1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		// [InlineData(-1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		// [InlineData(1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		// [InlineData(0, new float[] {}, new float[] {})]
		// public void RemoveAt(int index, float[] v, float[] e1) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	Vector3[] e = new Vector3[e1.Length / 3];
		// 	for(int i = 0; i < e.Length; i++) {
		// 		e[i] = new Vector3(e1[3 * i], e1[3 * i + 1], e1[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
			
		// 	curve.RemoveAt(index);
			
		// 	Assert.Equal(e, curve.Points);
		// }
		
		// [Theory]
		// [InlineData(1, 0, 1, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1, 1, 0, 0 })]
		// [InlineData(0, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		// [InlineData(10, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1 })]
		// [InlineData(-1, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		// [InlineData(1, 0, 1, 1, new float[] {}, new float[] { 0, 1, 1 })]
		// public void Insert(int index, float x, float y, float z, float[] v, float[] e1) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	Vector3[] e = new Vector3[e1.Length / 3];
		// 	for(int i = 0; i < e.Length; i++) {
		// 		e[i] = new Vector3(e1[3 * i], e1[3 * i + 1], e1[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	curve.Insert(index, a);
			
		// 	Assert.Equal(e, curve.Points);
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// [InlineData(2, 0, 1, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// [InlineData(-1, 0, 2, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// public void IndexOf(int e, float x, float y, float z, float[] v) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
		// 	int id = curve.IndexOf(a);
			
		// 	Assert.Equal(e, id);
		// }
		
		// [Theory]
		// [InlineData(new float[] { 0, 0, 0, 1, 2, 3 })]
		// [InlineData(new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		// [InlineData(new float[] { 0, 0, 0, 0, 0, 1 })]
		// [InlineData(new float[] { 0, 0, 1 })]
		// [InlineData(new float[] {})]
		// public void Clear(float[] e1) {
		// 	// Variables
		// 	Vector3[] e = new Vector3[e1.Length / 3];
		// 	for(int i = 0; i < e.Length; i++) {
		// 		e[i] = new Vector3(e1[3 * i], e1[3 * i + 1], e1[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, e);
			
		// 	curve.Clear();
			
		// 	Assert.Equal(new Vector3[0], curve.Points);
		// }
		
		// [Theory]
		// [InlineData(true, 0, 0, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// [InlineData(true, 0, 1, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// [InlineData(false, 0, 2, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		// public void Contains(bool e, float x, float y, float z, float[] v) {
		// 	// Variables
		// 	Vector3[] points = new Vector3[v.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(v[3 * i], v[3 * i + 1], v[3 * i + 2]);
		// 	}
		// 	BezierCurve curve = new BezierCurve(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
		// 	bool id = curve.Contains(a);
			
		// 	Assert.Equal(e, id);
		// }
	}
}

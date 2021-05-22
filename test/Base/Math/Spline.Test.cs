
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class SplineTest {
		// Variables
		private ITestOutputHelper output;
		
		public SplineTest(ITestOutputHelper output) {
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
		// 	Spline spline = new Spline(duration, points);
			
		// 	this.output.WriteLine("Duration: E: " + duration + ", A: " + spline.Duration);
		// 	Assert.Equal(duration, spline.Duration);
		// 	Assert.Equal(points, spline.Points);
		// }
		
		// [Theory]
		// [InlineData(4, 0, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.08333334, 0.5833334f, 0f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.1666667, 1f, 0.1666667f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.25, 1f, 0.75f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.3333333, 1f, 1.166667f, 0.3333335f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.4166667, 1f, 1.458333f, 0.9166667f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.5, 1f, 1.25f, 1.5f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.5833334, 1f, 0.9166665f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.6666667, 1f, 0.333333f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.75, 0.75f, 0f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.8333334, 0.1666665f, 0f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 0.9166667, 0f, 0.416667f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// [InlineData(4, 1, 0f, 1f, 2f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, 0f, 1f, 2f })]
		// public void Value_Linear(float duration, float t, float ex, float ey, float ez, float[] vertices) {
		// 	// Variables
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	Spline spline = new Spline(duration, points);
			
		// 	spline.Time = t;
		// 	spline.SplineType = SplineType.Linear;
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + spline.Value);
			
		// 	Assert.True(Vector3.Approx(e, spline.Value, 0.000001f));
		// }
		
		// [Theory]
		// [InlineData(4, 0, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.08333334, 0.603588f, -0.07089121f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.1666667, 1.05787f, 0.1145834f, -0.01157408f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.25, 1.023438f, 0.7617188f, -0.0703125f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.3333333, 0.9999999f, 1.240741f, 0.2592593f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.4166667, 1f, 1.494936f, 0.913484f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.5, 1f, 1.34375f, 1.5625f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.5833334, 1.003183f, 0.9309893f, 2.035012f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.6666667, 1.074074f, 0.2777776f, 2.037037f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.75, 0.8085938f, -0.0703125f, 2.023438f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.8333334, 0.1493053f, -0.01157406f, 2.05787f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 0.9166667, -0.2690973f, 0f, 1.603588f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// [InlineData(4, 1, -0.5f, 0f, 1f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f, -0.5f, 0f, 1f })]
		// public void Value_CatmullRom_NoLoop(float duration, float t, float ex, float ey, float ez, float[] vertices) {
		// 	// Variables
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	Spline spline = new Spline(duration, points);
			
		// 	spline.Time = t;
		// 	spline.SplineType = SplineType.CatmullRom;
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + spline.Value);
			
		// 	Assert.True(Vector3.Approx(e, spline.Value, 0.000001f));
		// }
		
		// [Theory]
		// [InlineData(4, 0, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.08333334, 0.603588f, -0.07089121f, -0.1012731f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.1666667, 1.05787f, 0.1145834f, -0.01157408f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.25, 1.023438f, 0.7617188f, -0.0703125f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.3333333, 0.9999999f, 1.240741f, 0.2592593f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.4166667, 1f, 1.494936f, 0.913484f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.5, 1f, 1.34375f, 1.5625f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.5833334, 1.003183f, 0.9309893f, 2.035012f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.6666667, 1.074074f, 0.2777776f, 2.037037f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.75, 0.796875f, -0.0703125f, 2.046875f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.8333334, 0.1203701f, -0.01157406f, 2.115741f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 0.9166667, -0.0708912f, 0f, 1.207176f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// [InlineData(4, 1, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 1f, 0f, 0f, 1f, 1f, 0f, 1f, 1.5f, 1f, 1f, 1f, 2f, 1f, 0f, 2f, 0f, 0f, 2f })]
		// public void Value_CatmullRom_FullLoop(float duration, float t, float ex, float ey, float ez, float[] vertices) {
		// 	// Variables
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Vector3[] points = new Vector3[vertices.Length / 3];
		// 	for(int i = 0; i < points.Length; i++) {
		// 		points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
		// 	}
		// 	Spline spline = new Spline(duration, points);
			
		// 	spline.Time = t;
		// 	spline.SplineType = SplineType.CatmullRom;
		// 	spline.LoopType = InterpolationLoopType.FullLoop;
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + spline.Value);
			
		// 	Assert.True(Vector3.Approx(e, spline.Value, 0.000001f));
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
		// 	Spline spline = new Spline(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	spline.Add(a);
			
		// 	Assert.Equal(e, spline.Points);
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
		// 	Spline spline = new Spline(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	spline.Remove(a);
			
		// 	Assert.Equal(e, spline.Points);
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
		// 	Spline spline = new Spline(10.0f, points);
			
		// 	spline.RemoveAt(index);
			
		// 	Assert.Equal(e, spline.Points);
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
		// 	Spline spline = new Spline(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
			
		// 	spline.Insert(index, a);
			
		// 	Assert.Equal(e, spline.Points);
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
		// 	Spline spline = new Spline(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
		// 	int id = spline.IndexOf(a);
			
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
		// 	Spline spline = new Spline(10.0f, e);
			
		// 	spline.Clear();
			
		// 	Assert.Equal(new Vector3[0], spline.Points);
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
		// 	Spline spline = new Spline(10.0f, points);
		// 	Vector3 a = new Vector3(x, y, z);
		// 	bool id = spline.Contains(a);
			
		// 	Assert.Equal(e, id);
		// }
	}
}


using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class QuaternionTest {
		// Variables
		private ITestOutputHelper output;
		
		public QuaternionTest(ITestOutputHelper helper) {
			this.output = helper;
		}
		
		// [Theory]
		// [InlineData(0.65328145f, 0.65328145f, 0.27059805f, -0.27059805f, 1.570796326f, 0.785398163f, 0.0f)]
		// [InlineData(0.70710678f, 0.70710678f, 0.0f, 0.0f, 1.570796326f, 0.0f, 0.0f)]
		// [InlineData(0.70710678f, 0.0f, 0.70710678f, 0.0f, 0.0f, 1.570796326f, 0.0f)]
		// [InlineData(0.70710678f, 0.0f, 0.0f, 0.70710678f, 0.0f, 0.0f, 1.570796326f)]
		// [InlineData(0.8223632, 0.5319757, 0.2005621, 0.02226007, 60*Mathx.DegToRad, 45*Mathx.DegToRad, 30*Mathx.DegToRad)]
		// [InlineData(-0.3378031, 0.07764797, -0.1592292, 0.9243949, 14*Mathx.DegToRad, 15*Mathx.DegToRad, 222*Mathx.DegToRad)]
		// [InlineData(0.3044173, 0.3044173, -0.6382242, 0.6382242, 90*Mathx.DegToRad, 88*Mathx.DegToRad, 217*Mathx.DegToRad)]
		// public void ConstructorsAndEulerAngles(float a, float b, float c, float d, float yaw, float pitch, float roll) {
		// 	// Variables
		// 	Quaternion e = new Quaternion(a, b, c, d);
		// 	Quaternion r = new Quaternion(yaw, pitch, roll);
		// 	Quaternion r2 = Quaternion.FromEulerAngles(new Vector3(yaw, pitch, roll));
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + r);
			
		// 	Assert.True(Mathx.Approx(ref e, ref r));
		// 	Assert.True(Mathx.Approx(ref e, ref r2));
		// }
		
		// [Theory]
		// [InlineData(1, 0, 0, 1.570796326f, 0.70710678f, 0.70710678f, 0.0f, 0.0f)]
		// [InlineData(0, 1, 0, 1.570796326f, 0.70710678f, 0.0f, 0.70710678f, 0.0f)]
		// [InlineData(0, 0, 1, 1.570796326f, 0.70710678f, 0.0f, 0.0f, 0.70710678f)]
		// [InlineData(1, 2, 3, 1.570796326f, 0.70710678f, 0.18898223f, 0.37796447f, 0.5669467f)]
		// public void FromAxisAngle(float x, float y, float z, float theta, float a, float b, float c, float d) {
		// 	// Variables
		// 	Vector3 v = new Vector3(x, y, z);
		// 	Quaternion e = new Quaternion(a, b, c, d);
			
		// 	Assert.Equal(e, Quaternion.FromAxisAngle(ref v, theta));
		// }
		
		// [Theory]
		// [InlineData(1, 2, 3, 4, 1, -2, -3, -4)]
		// [InlineData(1, -2, 3, -4, 1, 2, -3, 4)]
		// [InlineData(1, -2, -3, -4, 1, 2, 3, 4)]
		// public void Conjugate(float a, float b, float c, float d, float w, float x, float y, float z) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion e = new Quaternion(w, x, y, z);
			
		// 	Assert.Equal(e, Quaternion.Conjugate(ref f));
		// }
		
		// [Theory]
		// [InlineData(1, 2, 3, 4, 1, -2, -3, -4, 2, 0, 0, 0)]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 6, 8, 10, 12)]
		// public void Add(float a, float b, float c, float d, float w, float x, float y, float z, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion g = new Quaternion(w, x, y, z);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Add(ref f, ref g));
		// }
		
		// [Theory]
		// [InlineData(1, 2, 3, 4, 1, -2, -3, -4, 0, 4, 6, 8)]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, -4, -4, -4, -4)]
		// [InlineData(1, 2, 3, 4, 1, 2, 3, 4, 0, 0, 0, 0)]
		// public void Subtract(float a, float b, float c, float d, float w, float x, float y, float z, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion g = new Quaternion(w, x, y, z);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Subtract(ref f, ref g));
		// }
		
		// [Theory]
		// [InlineData(1, -2, -3, -4, -1, 2, 3, 4)]
		// [InlineData(5, 6, 7, 8, -5, -6, -7, -8)]
		// [InlineData(1, 2, 3, 4, -1, -2, -3, -4)]
		// public void Negate(float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Negate(ref f));
		// }
		
		// [Theory]
		// [InlineData(3, 1, -2, -3, -4, 3, -6, -9, -12)]
		// [InlineData(2, 5, 6, 7, 8, 10, 12, 14, 16)]
		// [InlineData(4, 1, 2, 3, 4, 4, 8, 12, 16)]
		// public void Multiply_Scalar(float s, float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Multiply(s, ref f));
		// }
		
		// [Theory]
		// [InlineData(3, 1, -2, -3, -4, 1/3f, -2/3f, -1, -4/3f)]
		// [InlineData(2, 5, 6, 7, 8, 5/2f, 3, 7/2f, 4)]
		// [InlineData(4, 1, 2, 3, 4, 1/4f, 1/2f, 3/4f, 1f)]
		// public void Divide_Scalar(float s, float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion f = new Quaternion(a, b, c, d);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Divide(s, ref f));
		// }
		
		// [Theory]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, -60, 12, 30, 24)]
		// [InlineData(5, 6, 7, 8, 1, 2, 3, 4, -60, 20, 14, 32)]
		// [InlineData(1, 2, 3, 4, 1, -2, -3, -4, 30, 0, 0, 0)]
		// public void Multiply(float aa, float ab, float ac, float ad, float ba, float bb, float bc, float bd, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion a = new Quaternion(aa, ab, ac, ad);
		// 	Quaternion b = new Quaternion(ba, bb, bc, bd);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Multiply(ref a, ref b));
		// }
		
		// [Theory]
		// [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 70/174f, 8/174f, 0f, 16/174f)]
		// [InlineData(5, 6, 7, 8, 1, 2, 3, 4, 7/3f, -4/15f, 0f, -8/15f)]
		// [InlineData(1, 2, 3, 4, 1, -2, -3, -4, -14/15f, 2/15f, 1/5f, 4/15f)]
		// public void Divide(float aa, float ab, float ac, float ad, float ba, float bb, float bc, float bd, float ea, float eb, float ec, float ed) {
		// 	// Variables
		// 	Quaternion a = new Quaternion(aa, ab, ac, ad);
		// 	Quaternion b = new Quaternion(ba, bb, bc, bd);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Assert.Equal(e, Mathx.Divide(ref a, ref b));
		// }
		
		// [Fact]
		// public void Invert() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Quaternion a = new Quaternion(
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f)
		// 		);
				
		// 		Assert.InRange(
		// 			Quaternion.Multiply(a, Mathx.Invert(ref a)),
		// 			Quaternion.Identity - 0.000001f * (new Quaternion(1f, 1f, 1f, 1f)),
		// 			Quaternion.Identity + 0.000001f * (new Quaternion(1f, 1f, 1f, 1f))
		// 		);
		// 	}
		// }
		
		// [Fact]
		// public void Normalize() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Quaternion a = new Quaternion(
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f)
		// 		);
				
		// 		Assert.InRange(
		// 			Mathx.Normalize(ref a).Magnitude,
		// 			1f - 0.000001f,
		// 			1f + 0.000001f
		// 		);
		// 	}
		// }
		
		// [Fact]
		// public void Dot() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Quaternion a = new Quaternion(
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f)
		// 		);
		// 		Quaternion b = new Quaternion(
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f),
		// 			Random.Range(-10f, 10f)
		// 		);
		// 		Vector4 c = new Vector4(a.a, a.b, a.c, a.d);
		// 		Vector4 d = new Vector4(b.a, b.b, b.c, b.d);
				
		// 		Assert.Equal(Mathx.Dot(ref c, ref d), Mathx.Dot(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void ToEulerAngles() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		Vector3 e = Random.Range(-0.5f * Mathx.Pi * Vector3.One, 0.5f * Mathx.Pi * Vector3.One);
		// 		Quaternion a = Quaternion.FromEulerAngles(ref e);
		// 		Vector3 b;
				
		// 		Quaternion.ToEulerAngles(ref a, out b);
				
		// 		this.output.WriteLine("Expected: " + e);
		// 		this.output.WriteLine("Actual: " + b);
				
		// 		Assert.True(Mathx.Approx(ref e, ref b, 0.001f));
		// 	}
		// }
		
		// [Theory]
		// [InlineData(60*Mathx.DegToRad, 0, 0, 1, 0, 0, 0, 0, 0.5, -0.8660254, 0, 0, 0.8660254, 0.5, 0, 0, 0, 0, 1)]
		// [InlineData(0, 45*Mathx.DegToRad, 0, 0.7071068, 0, 0.7071068, 0, 0, 1, 0, 0, -0.7071068, 0, 0.7071068, 0, 0, 0, 0, 1)]
		// [InlineData(0, 0, 30*Mathx.DegToRad, 0.8660253, -0.5, 0, 0, 0.5, 0.8660253, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		// [InlineData(60*Mathx.DegToRad, 45*Mathx.DegToRad, 30*Mathx.DegToRad, 0.9185587, 0.1767766, 0.3535534, 0, 0.2500001, 0.4330125, -0.8660255, 0, -0.3061861, 0.8838837, 0.3535533, 0, 0, 0, 0, 1)]
		// public void ToMatrix_EulerAngles(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
		// 	// Variables
		// 	Quaternion rot = new Quaternion(x, y, z);
		// 	Matrix b = Quaternion.ToMatrix(ref rot);
		// 	Matrix e = new Matrix(
		// 		e11, e12, e13, e14,
		// 		e21, e22, e23, e24,
		// 		e31, e32, e33, e34,
		// 		e41, e42, e43, e44
		// 	);
			
		// 	this.output.WriteLine("Quaternion: " + rot);
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(b.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref b, 0.000001f));
		// }
		
		// [Theory]
		// [InlineData(1, 0, 0, 30 * Mathx.DegToRad)]
		// [InlineData(0, 1, 0, 60 * Mathx.DegToRad)]
		// [InlineData(0, 0, 1, 129 * Mathx.DegToRad)]
		// [InlineData(1, 2, 3, 77 * Mathx.DegToRad)]
		// public void ToMatrix_AxisAngle(float x, float y, float z, float theta) {
		// 	// Variables
		// 	Quaternion a = Quaternion.FromAxisAngle(new Vector3(x, y, z), theta);
		// 	Matrix b = Quaternion.ToMatrix(ref a);
		// 	Matrix e = Matrix.CreateRotationFromAxisAngle(new Vector3(x, y, z), theta);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(b.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref b));
		// }
		
		// [Theory]
		// [InlineData(1, 0, 0, 30 * Mathx.DegToRad)]
		// [InlineData(0, 1, 0, 60 * Mathx.DegToRad)]
		// [InlineData(0, 0, 1, 129 * Mathx.DegToRad)]
		// [InlineData(1, 2, 3, 77 * Mathx.DegToRad)]
		// public void FromMatrix_AxisAngle(float x, float y, float z, float theta) {
		// 	// Variables
		// 	Quaternion e = Quaternion.FromAxisAngle(new Vector3(x, y, z), theta);
		// 	Matrix a = Matrix.CreateRotationFromAxisAngle(new Vector3(x, y, z), theta);
		// 	Quaternion b = Quaternion.FromMatrix(ref a);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(b.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref b));
		// }
		
		// [Theory]
		// [InlineData(1, 0, 0, 0, 0.9659258, 0.258819, 0, 0, 0, 1, 0, 0, 0)]
		// [InlineData(1, 0, 0, 0, 0.9659258, 0.258819, 0, 0, 0.5, 0.9914448, 0.1305262, 0, 0)]
		// [InlineData(1, 0, 0, 0, 0.9659258, 0.258819, 0, 0, 1, 0.9659259, 0.2588188, 0, 0)]
		// [InlineData(0.8660254, 0, 0.5, 0, 0.4158418, 0.1114245, -0.2336062, 0.8718304, 0.5, 0.8128968, 0.0706599, 0.1689338, 0.5528718)]
		// [InlineData(-0.3181352, 0.1210909, 0.7457347, -0.5727189, 0.4751292, 0.5046578, -0.6902984, 0.207511, 0.1552, -0.3577666, 0.01902954, 0.7662717, -0.5333562)]
		// public void Slerp(
		// 	float a, float b, float c, float d,
		// 	float w, float x, float y, float z,
		// 	float t,
		// 	float ea, float eb, float ec, float ed
		// ) {
		// 	// Variables
		// 	Quaternion p = new Quaternion(a, b, c, d);
		// 	Quaternion q = new Quaternion(w, x, y, z);
		// 	Quaternion e = new Quaternion(ea, eb, ec, ed);
			
		// 	Mathx.Slerp(ref p, ref q, t, out p);
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(p.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref p));
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
		// [InlineData(1, 0, 1, -1, 12*Mathx.DegToRad, 24*Mathx.DegToRad, 48*Mathx.DegToRad, 1.071974, 0.5189937, 0.7625729, -1)]
		// [InlineData(-1, -1, -1, -1, 44*Mathx.DegToRad, 90*Mathx.DegToRad, 90*Mathx.DegToRad, -1.4139981, -0.024681374, -1, -1)]
		// [InlineData(100, 200, 300, 400, -90*Mathx.DegToRad, 89*Mathx.DegToRad, 77*Mathx.DegToRad, -145.41391, 300, 169.86697, 399.99997)]
		// [InlineData(20, -4, 0, 1, 8*Mathx.DegToRad, 48*Mathx.DegToRad, 128*Mathx.DegToRad, -4.2453156, 18.045515, 8.505091, 1)]
		// public void Multiply_Vector4(float x, float y, float z, float w, float yaw, float pitch, float roll, float ex, float ey, float ez, float ew) {
		// 	// Variables
		// 	Vector4 a = new Vector4(x, y, z, w);
		// 	Vector4 e = new Vector4(ex, ey, ez, ew);
		// 	Quaternion r = new Quaternion(yaw, pitch, roll);
			
		// 	Mathx.Multiply(ref r, ref a, out a);
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + a);
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0)]
		// [InlineData(1, 0, 1, 12*Mathx.DegToRad, 24*Mathx.DegToRad, 48*Mathx.DegToRad, 1.071974, 0.5189937, 0.7625729)]
		// [InlineData(-1, -1, -1, 44*Mathx.DegToRad, 90*Mathx.DegToRad, 90*Mathx.DegToRad, -1.4139981, -0.024681374, -1)]
		// [InlineData(100, 200, 300, -90*Mathx.DegToRad, 89*Mathx.DegToRad, 77*Mathx.DegToRad, -145.41394, 300, 169.86697)]
		// [InlineData(20, -4, 0, 8*Mathx.DegToRad, 48*Mathx.DegToRad, 128*Mathx.DegToRad, -4.2453146, 18.045515, 8.505091)]
		// public void Multiply_Vector3(float x, float y, float z, float yaw, float pitch, float roll, float ex, float ey, float ez) {
		// 	// Variables
		// 	Vector3 a = new Vector3(x, y, z);
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Quaternion r = new Quaternion(yaw, pitch, roll);
			
		// 	Mathx.Multiply(ref r, ref a, out a);
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + a);
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
		
		// [Theory]
		// [InlineData(0, 0, 0, 0, 0, 0, 0)]
		// [InlineData(1, 1, 12*Mathx.DegToRad, 24*Mathx.DegToRad, 48*Mathx.DegToRad, 0.05181412, 1.381414)]
		// [InlineData(-1, -1, 44*Mathx.DegToRad, 90*Mathx.DegToRad, 90*Mathx.DegToRad, -0.6946583, -0.7193398)]
		// [InlineData(100, 200, -90*Mathx.DegToRad, 89*Mathx.DegToRad, 77*Mathx.DegToRad, -145.41394, 0)]
		// [InlineData(20, -4, 8*Mathx.DegToRad, 48*Mathx.DegToRad, 128*Mathx.DegToRad, -4.2453146, 18.045515)]
		// public void Multiply_Vector2(float x, float y, float yaw, float pitch, float roll, float ex, float ey) {
		// 	// Variables
		// 	Vector2 a = new Vector2(x, y);
		// 	Vector2 e = new Vector2(ex, ey);
		// 	Quaternion r = new Quaternion(yaw, pitch, roll);
			
		// 	Mathx.Multiply(ref r, ref a, out a);
			
		// 	this.output.WriteLine("Expected: " + e);
		// 	this.output.WriteLine("Actual: " + a);
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
	}
}

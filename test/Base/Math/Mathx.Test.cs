
using Xunit;
using Xunit.Abstractions;

using Math = System.Math;

namespace B3.Testing {
	public class MathxTest {
		// Variables
		private readonly ITestOutputHelper output;
		
		public MathxTest(ITestOutputHelper output) {
			this.output = output;
		}
		// [Fact]
		// public void Constants() {
		// 	Assert.Equal(Mathx.Pi, (float)Math.PI);
		// 	Assert.Equal(Mathx.PiOverTwo, (float)Math.PI / 2.0f);
		// 	Assert.Equal(Mathx.TwoPi, 2.0f * (float)Math.PI);
		// 	Assert.Equal(Mathx.E, (float)Math.E);
		// 	Assert.Equal(Mathx.Epsilon, float.Epsilon);
		// 	Assert.Equal(Mathx.Infinity, float.PositiveInfinity);
		// 	Assert.Equal(Mathx.NegativeInfinity, float.NegativeInfinity);
		// 	Assert.Equal(Mathx.DegToRad, (float)Math.PI / 180.0f);
		// 	Assert.Equal(Mathx.RadToDeg, 180.0f / (float)Math.PI);
		// }
		
		// [Fact]
		// public void SinCosTanCscSecCot() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		float angle = Random.Angle;
				
		// 		Assert.Equal((float)Math.Sin(angle), Mathx.Sin(angle));
		// 		Assert.Equal((float)Math.Cos(angle), Mathx.Cos(angle));
		// 		Assert.Equal((float)Math.Tan(angle), Mathx.Tan(angle));
				
		// 		Assert.Equal(1.0f / (float)Math.Sin(angle), Mathx.Csc(angle));
		// 		Assert.Equal(1.0f / (float)Math.Cos(angle), Mathx.Sec(angle));
		// 		Assert.Equal(1.0f / (float)Math.Tan(angle), Mathx.Cot(angle));
		// 	}
		// }
		
		// [Fact]
		// public void SinDegCosDegTanDegCscDegSecDegCotDeg() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		float angle = Random.Range0To(360.0f);
				
		// 		Assert.Equal((float)Math.Sin(Mathx.DegToRad * angle), Mathx.SinDeg(angle));
		// 		Assert.Equal((float)Math.Cos(Mathx.DegToRad * angle), Mathx.CosDeg(angle));
		// 		Assert.Equal((float)Math.Tan(Mathx.DegToRad * angle), Mathx.TanDeg(angle));
				
		// 		Assert.Equal(1.0f / (float)Math.Sin(Mathx.DegToRad * angle), Mathx.CscDeg(angle));
		// 		Assert.Equal(1.0f / (float)Math.Cos(Mathx.DegToRad * angle), Mathx.SecDeg(angle));
		// 		Assert.Equal(1.0f / (float)Math.Tan(Mathx.DegToRad * angle), Mathx.CotDeg(angle));
		// 	}
		// }
		
		// [Fact]
		// public void ArcsinArccosArctanArctan2() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Vector2 unit = Random.UnitVector2;
				
		// 		Assert.Equal((float)Math.Asin(unit.y), Mathx.Arcsin(unit.y));
		// 		Assert.Equal((float)Math.Acos(unit.x), Mathx.Arccos(unit.x));
		// 		Assert.Equal((float)Math.Atan(unit.y / unit.x), Mathx.Arctan(unit.y / unit.x));
		// 		Assert.Equal((float)Math.Atan2(unit.y, unit.x), Mathx.Arctan(unit.y, unit.x));
		// 	}
		// }
		
		// [Fact]
		// public void ArcsinDegArccosDegArctanDegArctan2Deg() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Vector2 unit = new Vector2(Random.Range0To(360.0f), Random.Range0To(360.0f));
				
		// 		Assert.Equal(Mathx.RadToDeg * (float)Math.Asin(unit.y), Mathx.ArcsinDeg(unit.y));
		// 		Assert.Equal(Mathx.RadToDeg * (float)Math.Acos(unit.x), Mathx.ArccosDeg(unit.x));
		// 		Assert.Equal(Mathx.RadToDeg * (float)Math.Atan(unit.y / unit.x), Mathx.ArctanDeg(unit.y / unit.x));
		// 		Assert.Equal(Mathx.RadToDeg * (float)Math.Atan2(unit.y, unit.x), Mathx.ArctanDeg(unit.y, unit.x));
		// 	}
		// }
		
		// [Fact]
		// public void SinhCoshTanhCschSechCoth() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		float num = Random.Range(float.MinValue / 2.0f, float.MaxValue / 2.0f);
				
		// 		Assert.Equal((float)Math.Sinh(num), Mathx.Sinh(num));
		// 		Assert.Equal((float)Math.Cosh(num), Mathx.Cosh(num));
		// 		Assert.Equal((float)Math.Tanh(num), Mathx.Tanh(num));
				
		// 		Assert.Equal(1.0f / (float)Math.Sinh(num), Mathx.Csch(num));
		// 		Assert.Equal(1.0f / (float)Math.Cosh(num), Mathx.Sech(num));
		// 		Assert.Equal(1.0f / (float)Math.Tanh(num), Mathx.Coth(num));
		// 	}
		// }
		
		// [Fact]
		// public void SinhDegCoshDegTanhDegCschDegSechDegCothDeg() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		float num = Random.Range(float.MinValue / 2.0f, float.MaxValue / 2.0f);
				
		// 		Assert.Equal((float)Math.Sinh(Mathx.DegToRad * num), Mathx.SinhDeg(num));
		// 		Assert.Equal((float)Math.Cosh(Mathx.DegToRad * num), Mathx.CoshDeg(num));
		// 		Assert.Equal((float)Math.Tanh(Mathx.DegToRad * num), Mathx.TanhDeg(num));
				
		// 		Assert.Equal(1.0f / (float)Math.Sinh(Mathx.DegToRad * num), Mathx.CschDeg(num));
		// 		Assert.Equal(1.0f / (float)Math.Cosh(Mathx.DegToRad * num), Mathx.SechDeg(num));
		// 		Assert.Equal(1.0f / (float)Math.Tanh(Mathx.DegToRad * num), Mathx.CothDeg(num));
		// 	}
		// }
		
		// [Fact]
		// public void Min() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-10.0f, 10.0f);
		// 		float b = Random.Range(-10.0f, 10.0f);
		// 		int c = Random.Range(-10, 10);
		// 		int d = Random.Range(-10, 10);
		// 		Vector2 e = Random.Range(-10.0f * Vector2.One, 10.0f * Vector2.One);
		// 		Vector2 f = Random.Range(-10.0f * Vector2.One, 10.0f * Vector2.One);
		// 		Vector3 g = Random.Range(-10.0f * Vector3.One, 10.0f * Vector3.One);
		// 		Vector3 h = Random.Range(-10.0f * Vector3.One, 10.0f * Vector3.One);
		// 		Vector4 i = Random.Range(-10.0f * Vector4.One, 10.0f * Vector4.One);
		// 		Vector4 j = Random.Range(-10.0f * Vector4.One, 10.0f * Vector4.One);
				
		// 		Assert.Equal(Math.Min(a, b), Mathx.Min(a, b));
		// 		Assert.Equal(Math.Min(c, d), Mathx.Min(c, d));
		// 		Assert.Equal(new Vector2(
		// 			Math.Min(e.x, f.x),
		// 			Math.Min(e.y, f.y)
		// 		), Mathx.Min(ref e, ref f));
		// 		Assert.Equal(new Vector3(
		// 			Math.Min(g.x, h.x),
		// 			Math.Min(g.y, h.y),
		// 			Math.Min(g.z, h.z)
		// 		), Mathx.Min(ref g, ref h));
		// 		Assert.Equal(new Vector4(
		// 			Math.Min(i.x, j.x),
		// 			Math.Min(i.y, j.y),
		// 			Math.Min(i.z, j.z),
		// 			Math.Min(i.w, j.w)
		// 		), Mathx.Min(ref i, ref j));
		// 	}
		// }
		
		// [Fact]
		// public void Max() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-10.0f, 10.0f);
		// 		float b = Random.Range(-10.0f, 10.0f);
		// 		int c = Random.Range(-10, 10);
		// 		int d = Random.Range(-10, 10);
		// 		Vector2 e = Random.Range(-10.0f * Vector2.One, 10.0f * Vector2.One);
		// 		Vector2 f = Random.Range(-10.0f * Vector2.One, 10.0f * Vector2.One);
		// 		Vector3 g = Random.Range(-10.0f * Vector3.One, 10.0f * Vector3.One);
		// 		Vector3 h = Random.Range(-10.0f * Vector3.One, 10.0f * Vector3.One);
		// 		Vector4 i = Random.Range(-10.0f * Vector4.One, 10.0f * Vector4.One);
		// 		Vector4 j = Random.Range(-10.0f * Vector4.One, 10.0f * Vector4.One);
				
		// 		Assert.Equal(Math.Max(a, b), Mathx.Max(a, b));
		// 		Assert.Equal(Math.Max(c, d), Mathx.Max(c, d));
		// 		Assert.Equal(new Vector2(
		// 			Math.Max(e.x, f.x),
		// 			Math.Max(e.y, f.y)
		// 		), Mathx.Max(ref e, ref f));
		// 		Assert.Equal(new Vector3(
		// 			Math.Max(g.x, h.x),
		// 			Math.Max(g.y, h.y),
		// 			Math.Max(g.z, h.z)
		// 		), Mathx.Max(ref g, ref h));
		// 		Assert.Equal(new Vector4(
		// 			Math.Max(i.x, j.x),
		// 			Math.Max(i.y, j.y),
		// 			Math.Max(i.z, j.z),
		// 			Math.Max(i.w, j.w)
		// 		), Mathx.Max(ref i, ref j));
		// 	}
		// }
		
		// [Fact]
		// public void Clamp() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float aa = Random.Range(5.0f, 50.0f);
		// 		float ab = Random.Range0To(10.0f);
		// 		float ac = Random.Range(10.0f, 20.0f);
		// 		int ba = Random.Range(5, 50);
		// 		int bb = Random.Range0To(10);
		// 		int bc = Random.Range(10, 20);
		// 		Vector2 ca = Random.Range(5.0f * Vector2.One, 50.0f * Vector2.One);
		// 		Vector2 cb = Random.Range0To(10.0f * Vector2.One);
		// 		Vector2 cc = Random.Range(10.0f * Vector2.One, 20.0f * Vector2.One);
		// 		Vector3 da = Random.Range(5.0f * Vector3.One, 50.0f * Vector3.One);
		// 		Vector3 db = Random.Range0To(10.0f * Vector3.One);
		// 		Vector3 dc = Random.Range(10.0f * Vector3.One, 20.0f * Vector3.One);
		// 		Vector4 ea = Random.Range(5.0f * Vector4.One, 50.0f * Vector4.One);
		// 		Vector4 eb = Random.Range0To(10.0f * Vector4.One);
		// 		Vector4 ec = Random.Range(10.0f * Vector4.One, 20.0f * Vector4.One);
				
		// 		Assert.Equal(Math.Clamp(aa, ab, ac), Mathx.Clamp(aa, ab, ac));
		// 		Assert.Equal(Math.Clamp(ba, bb, bc), Mathx.Clamp(ba, bb, bc));
		// 		Assert.Equal(new Vector2(
		// 			Math.Clamp(ca.x, cb.x, cc.x),
		// 			Math.Clamp(ca.y, cb.y, cc.y)
		// 		), Mathx.Clamp(ref ca, ref cb, ref cc));
		// 		Assert.Equal(new Vector3(
		// 			Math.Clamp(da.x, db.x, dc.x),
		// 			Math.Clamp(da.y, db.y, dc.y),
		// 			Math.Clamp(da.z, db.z, dc.z)
		// 		), Mathx.Clamp(ref da, ref db, ref dc));
		// 		Assert.Equal(new Vector4(
		// 			Math.Clamp(ea.x, eb.x, ec.x),
		// 			Math.Clamp(ea.y, eb.y, ec.y),
		// 			Math.Clamp(ea.z, eb.z, ec.z),
		// 			Math.Clamp(ea.w, eb.w, ec.w)
		// 		), Mathx.Clamp(ref ea, ref eb, ref ec));
		// 	}
		// }
		
		// [Fact]
		// public void FloorCeilFract() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-10.0f, 10.0f);
		// 		Vector2 b = Random.Range(-10.0f * Vector2.One, 10.0f * Vector2.One);
		// 		Vector3 c = Random.Range(-10.0f * Vector3.One, 10.0f * Vector3.One);
		// 		Vector4 d = Random.Range(-10.0f * Vector4.One, 10.0f * Vector4.One);
				
		// 		Assert.Equal(Math.Floor(a), (float)Mathx.Floor(a));
		// 		Assert.Equal(new Vector2(
		// 			(int)Math.Floor(b.x),
		// 			(int)Math.Floor(b.y)
		// 		), Mathx.Floor(ref b));
		// 		Assert.Equal(new Vector3(
		// 			(int)Math.Floor(c.x),
		// 			(int)Math.Floor(c.y),
		// 			(int)Math.Floor(c.z)
		// 		), Mathx.Floor(ref c));
		// 		Assert.Equal(new Vector4(
		// 			(int)Math.Floor(d.x),
		// 			(int)Math.Floor(d.y),
		// 			(int)Math.Floor(d.z),
		// 			(int)Math.Floor(d.w)
		// 		), Mathx.Floor(ref d));
				
		// 		Assert.Equal(Math.Ceiling(a), (float)Mathx.Ceiling(a));
		// 		Assert.Equal(new Vector2(
		// 			(int)Math.Ceiling(b.x),
		// 			(int)Math.Ceiling(b.y)
		// 		), Mathx.Ceiling(ref b));
		// 		Assert.Equal(new Vector3(
		// 			(int)Math.Ceiling(c.x),
		// 			(int)Math.Ceiling(c.y),
		// 			(int)Math.Ceiling(c.z)
		// 		), Mathx.Ceiling(ref c));
		// 		Assert.Equal(new Vector4(
		// 			(int)Math.Ceiling(d.x),
		// 			(int)Math.Ceiling(d.y),
		// 			(int)Math.Ceiling(d.z),
		// 			(int)Math.Ceiling(d.w)
		// 		), Mathx.Ceiling(ref d));
				
		// 		Assert.Equal(InvertFraction(a - (int)Math.Floor(a), Math.Sign(a)), Mathx.Fraction(a));
		// 		Assert.Equal(new Vector2(
		// 			InvertFraction(b.x - (int)Math.Floor(b.x), Math.Sign(b.x)),
		// 			InvertFraction(b.y - (int)Math.Floor(b.y), Math.Sign(b.y))
		// 		), Mathx.Fraction(ref b));
		// 		Assert.Equal(new Vector3(
		// 			InvertFraction(c.x - (int)Math.Floor(c.x), Math.Sign(c.x)),
		// 			InvertFraction(c.y - (int)Math.Floor(c.y), Math.Sign(c.y)),
		// 			InvertFraction(c.z - (int)Math.Floor(c.z), Math.Sign(c.z))
		// 		), Mathx.Fraction(ref c));
		// 		Assert.Equal(new Vector4(
		// 			InvertFraction(d.x - (int)Math.Floor(d.x), Math.Sign(d.x)),
		// 			InvertFraction(d.y - (int)Math.Floor(d.y), Math.Sign(d.y)),
		// 			InvertFraction(d.z - (int)Math.Floor(d.z), Math.Sign(d.z)),
		// 			InvertFraction(d.w - (int)Math.Floor(d.w), Math.Sign(d.w))
		// 		), Mathx.Fraction(ref d));
		// 	}
		// }
		
		// private float InvertFraction(float fraction, int sign) { return (sign < 0 ? 1.0f - fraction : fraction); }
		
		// [Fact]
		// public void Abs() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-100.0f, 50.0f);
		// 		int b = Random.Range(-100, 50);
		// 		Vector2 c = Random.Range(-100.0f * Vector2.One, 50.0f * Vector2.One);
		// 		Vector3 d = Random.Range(-100.0f * Vector3.One, 50.0f * Vector3.One);
		// 		Vector4 e = Random.Range(-100.0f * Vector4.One, 50.0f * Vector4.One);
				
		// 		Assert.Equal(Math.Abs(a), Mathx.Abs(a));
		// 		Assert.Equal(Math.Abs(b), Mathx.Abs(b));
		// 		Assert.Equal(new Vector2(
		// 			Math.Abs(c.x),
		// 			Math.Abs(c.y)
		// 		), Mathx.Abs(ref c));
		// 		Assert.Equal(new Vector3(
		// 			Math.Abs(d.x),
		// 			Math.Abs(d.y),
		// 			Math.Abs(d.z)
		// 		), Mathx.Abs(ref d));
		// 		Assert.Equal(new Vector4(
		// 			Math.Abs(e.x),
		// 			Math.Abs(e.y),
		// 			Math.Abs(e.z),
		// 			Math.Abs(e.w)
		// 		), Mathx.Abs(ref e));
		// 	}
		// }
		
		// [Fact]
		// public void Sign() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-100.0f, 50.0f);
		// 		int b = Random.Range(-100, 50);
				
		// 		Assert.Equal(Math.Sign(a), Mathx.Sign(a));
		// 		Assert.Equal(Math.Sign(b), Mathx.Sign(b));
		// 	}
		// }
		
		// [Fact]
		// public void Pow() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float aa = Random.Range(-10.0f, 10.0f);
		// 		float ab = Random.Range(-10.0f, 10.0f);
		// 		int ba = Random.Range(-10, 10);
		// 		int bb = Random.Range(-10, 10);
				
		// 		Assert.Equal((float)Math.Pow(aa, ab), Mathx.Pow(aa, ab));
		// 		Assert.Equal((float)Math.Pow(ba, bb), Mathx.Pow(ba, bb));
		// 	}
		// }
		
		// [Fact]
		// public void EPow() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-10.0f, 10.0f);
		// 		int b = Random.Range(-10, 10);
				
		// 		Assert.Equal((float)Math.Pow((float)Math.E, a), Mathx.Pow(Mathx.E, a));
		// 		Assert.Equal((float)Math.Pow((float)Math.E, a), Mathx.Pow(a));
		// 		Assert.Equal((float)Math.Pow((float)Math.E, b), Mathx.Pow(Mathx.E, b));
		// 		Assert.Equal((float)Math.Pow((float)Math.E, b), Mathx.Pow(b));
		// 	}
		// }
		
		// [Theory]
		// [InlineData(0.0f, 0.7f, 15.0f, -1.2f, 1.0f, 3.0f, 20.0f, -0.8f, 0.8f)]
		// public void MapRange(float i1, float i2, float i3, float i4, float i5, float i6, float i7, float i8, float i9) {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		Vector2 e1 = new Vector2(i1, i2);
		// 		Vector3 e2 = new Vector3(i3, i4, i5);
		// 		Vector4 e3 = new Vector4(i6, i7, i8, i9);
		// 		Vector2 v1 = new Vector2(0.5f, 7);
		// 		Vector3 v2 = new Vector3(2, -0.1f, 1);
		// 		Vector4 v3 = new Vector4(0, 1, 0.1f, 0.9f);
		// 		// In and Outs Vec2
		// 		Vector2 im1 = new Vector2(0, -10);
		// 		Vector2 iM1 = new Vector2(1, 10);
		// 		Vector2 om1 = new Vector2(-1, -1);
		// 		Vector2 oM1 = new Vector2(1, 1);
		// 		// In and Outs Vec3
		// 		Vector3 im2 = new Vector3(-1, 0, 0);
		// 		Vector3 iM2 = new Vector3(1, 1, 1);
		// 		Vector3 om2 = new Vector3(0, -1, -1);
		// 		Vector3 oM2 = new Vector3(10, 1, 1);
		// 		// In and Outs Vec4
		// 		Vector4 im3 = new Vector4(0, 0, 0, 0);
		// 		Vector4 iM3 = new Vector4(1, 1, 1, 1);
		// 		Vector4 om3 = new Vector4(3, 8, -1, -1);
		// 		Vector4 oM3 = new Vector4(5, 20, 1, 1);
				
		// 		Assert.Equal(e1.x, Mathx.MapRange(v1.x, im1.x, iM1.x, om1.x, oM1.x));
		// 		Assert.Equal((int)e2.x, Mathx.MapRange(v2.x, im2.x, iM2.x, om2.x, oM2.x));
		// 		Assert.InRange(
		// 			Mathx.MapRange(ref v1, ref im1, ref iM1, ref om1, ref oM1),
		// 			e1 - Vector2.One * 0.000001f,
		// 			e1 + Vector2.One * 0.000001f
		// 		);
		// 		Assert.InRange(
		// 			Mathx.MapRange(ref v2, ref im2, ref iM2, ref om2, ref oM2),
		// 			e2 - Vector3.One * 0.000001f,
		// 			e2 + Vector3.One * 0.000001f
		// 		);
		// 		Assert.InRange(
		// 			Mathx.MapRange(ref v3, ref im3, ref iM3, ref om3, ref oM3),
		// 			e3 - Vector4.One * 0.000001f,
		// 			e3 + Vector4.One * 0.000001f
		// 		);
		// 	}
		// }
		
		// [Fact]
		// public void Log() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range0To(100.0f);
		// 		float b = Random.Range(2.0f, 20.0f);
				
		// 		Assert.Equal((float)Math.Log(a), Mathx.Log(a));
		// 		Assert.Equal((float)Math.Log(a, b), Mathx.Log(a, b));
		// 		Assert.Equal((float)Math.Log10(a), Mathx.Log10(a));
		// 		Assert.Equal((float)Math.Log(a, (float)Math.E), Mathx.Ln(a));
		// 	}
		// }
		
		// [Fact]
		// public void Trunc() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-100.0f, 100.0f);
		// 		Vector2 b = Random.Range(-100.0f * Vector2.One, 100.0f * Vector2.One);
		// 		Vector3 c = Random.Range(-100.0f * Vector3.One, 100.0f * Vector3.One);
		// 		Vector4 d = Random.Range(-100.0f * Vector4.One, 100.0f * Vector4.One);
				
		// 		Assert.Equal((float)Math.Truncate(a), (float)Mathx.Trunc(a));
		// 		Assert.Equal(new Vector2(
		// 			(int)Math.Truncate(b.x),
		// 			(int)Math.Truncate(b.y)
		// 		), Mathx.Trunc(ref b));
		// 		Assert.Equal(new Vector3(
		// 			(int)Math.Truncate(c.x),
		// 			(int)Math.Truncate(c.y),
		// 			(int)Math.Truncate(c.z)
		// 		), Mathx.Trunc(ref c));
		// 		Assert.Equal(new Vector4(
		// 			(int)Math.Truncate(d.x),
		// 			(int)Math.Truncate(d.y),
		// 			(int)Math.Truncate(d.z),
		// 			(int)Math.Truncate(d.w)
		// 		), Mathx.Trunc(ref d));
		// 	}
		// }
		
		// [Fact]
		// public void Sqrt() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range0To(100.0f);
		// 		Vector2 b = Random.Range0To(100.0f * Vector2.One);
		// 		Vector3 c = Random.Range0To(100.0f * Vector3.One);
		// 		Vector4 d = Random.Range0To(100.0f * Vector4.One);
				
		// 		Assert.Equal((float)Math.Sqrt(a), Mathx.Sqrt(a));
		// 		Assert.Equal(new Vector2(
		// 			(float)Math.Sqrt(b.x),
		// 			(float)Math.Sqrt(b.y)
		// 		), Mathx.Sqrt(ref b));
		// 		Assert.Equal(new Vector3(
		// 			(float)Math.Sqrt(c.x),
		// 			(float)Math.Sqrt(c.y),
		// 			(float)Math.Sqrt(c.z)
		// 		), Mathx.Sqrt(ref c));
		// 		Assert.Equal(new Vector4(
		// 			(float)Math.Sqrt(d.x),
		// 			(float)Math.Sqrt(d.y),
		// 			(float)Math.Sqrt(d.z),
		// 			(float)Math.Sqrt(d.w)
		// 		), Mathx.Sqrt(ref d));
		// 	}
		// }
		
		// [Fact]
		// public void Round() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-210.023f, 6.204f);
		// 		Vector2 b = Random.Range(-1000 * Vector2.One, 1000 * Vector2.One);
		// 		Vector3 c = Random.Range(-1000 * Vector3.One, 1000 * Vector3.One);
		// 		Vector4 d = Random.Range(-1000 * Vector4.One, 1000 * Vector4.One);
				
		// 		Assert.Equal((float)Math.Round(a), Mathx.Round(a));
		// 		Assert.Equal(new Vector2(
		// 			(float)Math.Round(b.x),
		// 			(float)Math.Round(b.y)
		// 		), Mathx.Round(ref b));
		// 		Assert.Equal(new Vector3(
		// 			(float)Math.Round(c.x),
		// 			(float)Math.Round(c.y),
		// 			(float)Math.Round(c.z)
		// 		), Mathx.Round(ref c));
		// 		Assert.Equal(new Vector4(
		// 			(float)Math.Round(d.x),
		// 			(float)Math.Round(d.y),
		// 			(float)Math.Round(d.z),
		// 			(float)Math.Round(d.w)
		// 		), Mathx.Round(ref d));
		// 	}
		// }
		
		// [Fact]
		// public void Smoothstep() {
		// 	for(int k = 0; k < 25; k++) {
		// 		// Variables
		// 		float a = Random.Range(-100f, 100f);
				
		// 		Assert.InRange(Mathx.Smoothstep(a, -100f, 100f), 0.0f, 1.0f);
		// 	}
		// }
		
		// [Theory]
		// [InlineData(7, 0, 3, 1), InlineData(23, 4, 9, 8), InlineData(10, 5, 15, 10), InlineData(3, 3, 6, 3)]
		// [InlineData(6, 3, 6, 6), InlineData(0.1, 0, 1, 0.1), InlineData(-0.1, 0, 1, 0.9), InlineData(-1, 0, 3, 2)]
		// public void Repeat(float val, float min, float max, float expected) {
		// 	Assert.InRange(Mathx.Repeat(val, min, max), expected - 0.000001f, expected + 0.000001f);
		// }
		
		// [Fact]
		// public void Approx() {
		// 	for(int k = 0; k < 25; k++) {
		// 		float val = Random.Value;
		// 		float nval = 0.0000001f * val * 10000000f;
				
		// 		Assert.True(Mathx.Approx(val, nval));
		// 	}
		// }
		
		// [Fact]
		// public void Lerp() {
		// 	for(int k = 0; k < 25; k++) {
		// 		float t = Random.Value;
		// 		float t2 = Random.Range(-10f, 10f);
		// 		float a = Random.Range(-10f, 0f);
		// 		float b = Random.Range(0f, 10f);
				
		// 		Assert.Equal((1.0f - t ) * a + b * t, Mathx.LerpClamped(a, b, t));
		// 		Assert.Equal(a + t2 * (b - a), Mathx.Lerp(a, b, t2));
		// 	}
		// }
		
		// [Theory]
		// [InlineData(10, 20, 2103, 302, 10, 20)]
		// [InlineData(1, 2, 29, 3, 2, 1)]
		// public void MinRange(float e, float v1, float v2, float v3, float v4, float v5) {
		// 	Assert.Equal(e, Mathx.MinRange(new float[]{v1, v2, v3, v4, v5}));
		// }
		
		// [Theory]
		// [InlineData(2103, 20, 2103, 302, 10, 20)]
		// [InlineData(29, 2, 29, 3, 2, 1)]
		// public void MaxRange(float e, float v1, float v2, float v3, float v4, float v5) {
		// 	Assert.Equal(e, Mathx.MaxRange(new float[]{v1, v2, v3, v4, v5}));
		// }
		
		// [Theory]
		// [InlineData(10, 20, 20, 10)]
		// [InlineData(10, 20, 10, 20)]
		// [InlineData(1, 2, 1, 2)]
		// [InlineData(1, 2, 2, 1)]
		// public void MinMax(float emin, float emax, float a, float b) {
		// 	// Variables
		// 	float min, max;
			
		// 	Mathx.MinMax(a, b, out min, out max);
			
		// 	Assert.Equal(emin, min);
		// 	Assert.Equal(emax, max);
		// }
	}
}

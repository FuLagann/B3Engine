
using Xunit;

using Math = System.Math;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Mathx"/> static class to make sure it works correctly. Contains 279 tests.</summary>
	public class MathxTest {
		#region Field Variables
		// Variables
		public const float Epsilon = 0.000001f;
		
		#endregion // Field Variables
		
		#region Public Test Methods
		
		#region Constants Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Pi"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void Pi_ReturnsMathPI() {
			Assert.Equal((float)Math.PI, Mathx.Pi);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.PiOverTwo"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void PiOverTwo_ReturnsMathPIOverTwo() {
			Assert.Equal((float)Math.PI / 2.0f, Mathx.PiOverTwo);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.TwoPi"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void TwoPi_ReturnsTwoMathPI() {
			Assert.Equal(2.0f * (float)Math.PI, Mathx.TwoPi);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.E"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void E_ReturnsMathE() {
			Assert.Equal((float)Math.E, Mathx.E);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Epsilon"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void Epsilon_ReturnsFloatEpsilon() {
			Assert.Equal(float.Epsilon, Mathx.Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Infinity"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void Infinity_ReturnsFloatInfinity() {
			Assert.Equal(float.PositiveInfinity, Mathx.Infinity);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.NegativeInfinity"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void NegativeInfinity_ReturnsFloatNegativeInfinity() {
			Assert.Equal(float.NegativeInfinity, Mathx.NegativeInfinity);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.DegToRad"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void DegToRad_ReturnsMathPIOver180() {
			Assert.Equal((float)Math.PI / 180.0f, Mathx.DegToRad);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.RadToDeg"/> functionality.
		/// Checks to see if the constant is correct
		/// </summary>
		[Fact]
		public void RadToDeg_Returns180OverMathPI() {
			Assert.Equal(180.0f / (float)Math.PI, Mathx.RadToDeg);
		}
		
		#endregion // Constants Test Methods
		
		#region Sin/Cos/Tan Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sin(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(1.570796327f, 1.0f)]
		[InlineData(3.141592653f, 0.0f)]
		[InlineData(4.71238898f, -1.0f)]
		[InlineData(6.283185306f, 0.0f)]
		[InlineData(0.785398163f, 0.707106781f)]
		[InlineData(1.0f, 0.841470985f)]
		[InlineData(-100.0f, 0.506365641f)]
		public void Sin_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Sin(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.SinDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(90.0f, 1.0f)]
		[InlineData(180.0f, 0.0f)]
		[InlineData(270.0f, -1.0f)]
		[InlineData(360.0f, 0.0f)]
		[InlineData(45.0f, 0.707106781f)]
		[InlineData(57.29577951f, 0.841470985f)]
		[InlineData(-5729.577951f, 0.506365641f)]
		public void SinDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.SinDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Cos(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(1.570796327f, 0.0f)]
		[InlineData(3.141592653f, -1.0f)]
		[InlineData(4.71238898f, 0.0f)]
		[InlineData(6.283185306f, 1.0f)]
		[InlineData(0.785398163f, 0.707106781f)]
		[InlineData(1.0f, 0.540302306f)]
		[InlineData(-100.0f, 0.862318872f)]
		public void Cos_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Cos(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.CosDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(90.0f, 0.0f)]
		[InlineData(180.0f, -1.0f)]
		[InlineData(270.0f, 0.0f)]
		[InlineData(360.0f, 1.0f)]
		[InlineData(45.0f, 0.707106781f)]
		[InlineData(57.29577951f, 0.540302306f)]
		[InlineData(-5729.577951f, 0.862318872f)]
		public void CosDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.CosDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Tan(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(3.141592653f, 0.0f)]
		[InlineData(6.283185306f, 0.0f)]
		[InlineData(0.785398163f, 1.0f)]
		[InlineData(1.0f, 1.557407725f)]
		[InlineData(-100.0f, 0.587213915f)]
		public void Tan_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Tan(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.TanDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(180.0f, 0.0f)]
		[InlineData(360.0f, 0.0f)]
		[InlineData(45.0f, 1.0f)]
		[InlineData(57.29577951f, 1.557407725f)]
		[InlineData(-5729.577951f, 0.587213915f)]
		public void TanDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.TanDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		#endregion // SinCosTan Test Methods
		
		#region Csc/Sec/Cot Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Csc(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(1.570796327f, 1.0f)]
		[InlineData(4.71238898f, -1.0f)]
		[InlineData(0.785398163f, 1.414213562f)]
		[InlineData(1.0f, 1.188395106f)]
		[InlineData(-100.0f, 1.974857531f)]
		public void Csc_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Csc(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.CscDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(90.0f, 1.0f)]
		[InlineData(270.0f, -1.0f)]
		[InlineData(45.0f, 1.414213562f)]
		[InlineData(57.29577951f, 1.188395106f)]
		[InlineData(-5729.577951f, 1.974857531f)]
		public void CscDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.CscDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sec(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(3.141592653f, -1.0f)]
		[InlineData(6.283185306f, 1.0f)]
		[InlineData(0.785398163f, 1.414213562f)]
		[InlineData(1.0f, 1.850815718f)]
		[InlineData(-100.0f, 1.159663823f)]
		public void Sec_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Sec(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.SecDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(180.0f, -1.0f)]
		[InlineData(360.0f, 1.0f)]
		[InlineData(45.0f, 1.414213562f)]
		[InlineData(57.29577951f, 1.850815718f)]
		[InlineData(-5729.577951f, 1.159663823f)]
		public void SecDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.SecDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Cot(float)"/> functionality.
		/// Puts an angle (in radians) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(1.570796327f, 0.0f)]
		[InlineData(4.71238898f, 0.0f)]
		[InlineData(0.785398163f, 1.0f)]
		[InlineData(1.0f, 0.642092616f)]
		[InlineData(-100.0f, 1.702956919f)]
		public void Cot_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Cot(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.CotDeg(float)"/> functionality.
		/// Puts an angle (in degrees) through the trig function and checks to see if the returned value is correct
		/// </summary>
		[Theory]
		[InlineData(90.0f, 0.0f)]
		[InlineData(270.0f, 0.0f)]
		[InlineData(45.0f, 1.0f)]
		[InlineData(57.29577951f, 0.642092616f)]
		[InlineData(-5729.577951f, 1.702956919f)]
		public void CotDeg_DegreeAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.CotDeg(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		#endregion // CscSecCot Test Methods
		
		#region Arcsin/Arccos/Arctan Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Arcsin(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in radians) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(1.0f, 1.570796327f)]
		[InlineData(-1.0f, -1.570796327f)]
		[InlineData(0.707106781f, 0.785398163f)]
		[InlineData(0.841470985f, 1.0f)]
		public void Arcsin_RadianVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Arcsin(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.ArcsinDeg(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in degrees) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(1.0f, 90.0f)]
		[InlineData(-1.0f, -90.0f)]
		[InlineData(0.707106782f, 44.999996f)] // Floating point error
		[InlineData(0.841470985f, 57.295773f)]
		public void ArcsinDeg_DegreeVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.ArcsinDeg(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Arccos(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in radians) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.57079632679f)]
		[InlineData(1.0f, 0.0f)]
		[InlineData(-1.0f, 3.14159265359f)]
		[InlineData(0.707106781f, 0.785398163661f)]
		[InlineData(0.540302306f, 1.0f)]
		public void Arccos_RadianVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Arccos(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.ArccosDeg(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in degrees) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 90.0f)]
		[InlineData(1.0f, 0.0f)]
		[InlineData(-1.0f, 180.0f)]
		[InlineData(0.707106781f, 45.0f)]
		[InlineData(0.540302306f, 57.295776f)]
		public void ArccosDeg_DegreeVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.ArccosDeg(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Arctan(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in radians) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(1.0f, 0.785398163397f)]
		[InlineData(-1.0f, -0.785398163397f)]
		[InlineData(0.707106781f, 0.615479708546f)]
		[InlineData(1.557407725f, 1.0f)]
		public void Arctan_RadianVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Arctan(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.ArctanDeg(float)"/> functionality.
		/// Puts a value through the function and checks to see if the returned angle (in degrees) is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(1.0f, 45.0f)]
		[InlineData(-1.0f, -45.0f)]
		[InlineData(0.707106781f, 35.2643896756)]
		[InlineData(1.557407725f, 57.295776f)]
		public void ArctanDeg_DegreeVal_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.ArctanDeg(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Arctan(float, float)"/> functionality.
		/// Puts two values through the function and checks to see if the returned angle (in radians) is correct
		/// </summary>
		[Fact]
		public void Arctan2_DivisionByZero_ReturnsFloat() {
			// Variables
			float actual = Mathx.Arctan(1.0f, 0.0f);
			float expected = 1.57079632679f;
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		#endregion // Arcsin/Arccos/Arctan Test Methods
		
		#region Sinh/Cosh/Tanh Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sinh(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(Mathx.Pi, 11.5487393573f)]
		[InlineData(Mathx.E, 7.54413710282f)]
		[InlineData(1.0f, 1.17520119364)]
		public void Sinh_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Sinh(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Cosh(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(Mathx.Pi, 11.5919532755f)]
		[InlineData(Mathx.E, 7.61012513866)]
		[InlineData(1.0f, 1.54308063482f)]
		public void Cosh_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Cosh(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Tanh(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f)]
		[InlineData(Mathx.Pi, 0.996272076221f)]
		[InlineData(Mathx.E, 0.991328915801f)]
		[InlineData(1.0f, 0.761594155956f)]
		[InlineData(10.0f, 0.999999995878f)]
		[InlineData(15.0f, 1.0f)]
		[InlineData(100.0f, 1.0f)]
		[InlineData(1000.0f, 1.0f)]
		public void Tanh_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Tanh(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		#endregion // Sinh/Cosh/Tanh Test Methods
		
		#region Csch/Sech/Coth Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Csch(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(Mathx.Pi, 0.08658953753f)]
		[InlineData(Mathx.E, 0.132553264392f)]
		[InlineData(1.0f, 0.850918128239f)]
		[InlineData(1000.0f, 0.0f)]
		[InlineData(0.1f, 9.9833527573f)]
		public void Csch_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Csch(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sech(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f)]
		[InlineData(Mathx.Pi, 0.0862667383341f)]
		[InlineData(Mathx.E, 0.131403883876f)]
		[InlineData(1.0f, 0.648054273664f)]
		[InlineData(0.1f, 0.995020748953f)]
		[InlineData(1000.0f, 0.0f)]
		public void Sech_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Sech(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Coth(float)"/> functionality.
		/// Puts an angle (in radians) through the function and checks to see if the return value is correct
		/// </summary>
		[Theory]
		[InlineData(Mathx.Pi, 1.0037418732f)]
		[InlineData(Mathx.E, 1.00874692956f)]
		[InlineData(1.0f, 1.3130352855f)]
		[InlineData(10.0f, 1.00000000412f)]
		[InlineData(0.1f, 10.0333111323f)]
		[InlineData(1000.0f, 1.0f)]
		public void Coth_RadianAngle_ReturnsFloat(float angle, float expected) {
			// Variables
			float actual = Mathx.Coth(angle);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		#endregion // Csch/Sech/Coth Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Min(float, float)"/> functionality.
		/// Puts two values in and checks to see if the smallest number comes out
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 1, 0)]
		[InlineData(1, 0, 0)]
		[InlineData(-100, 100, -100)]
		public void Min_Float_ReturnsFloat(float first, float second, float expected) {
			// Variables
			float actual = Mathx.Min(first, second);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Max(float, float)"/> functionality.
		/// Puts two values in and checks to see if the largest number comes out
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0, 1, 1)]
		[InlineData(1, 0, 1)]
		[InlineData(-100, 100, 100)]
		public void Max_Float_ReturnsFloat(float first, float second, float expected) {
			// Variables
			float actual = Mathx.Max(first, second);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Clamp(float, float, float)"/> functionality.
		/// Puts in a value and a range checks to see if the number doesn't go outside that range
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(10, 0, 0, 0)]
		[InlineData(0.5, 0, 1, 0.5)]
		[InlineData(5, 0, 1, 1)]
		[InlineData(-0.000001, 0, 1, 0)]
		public void Clamp_Float_ReturnsFloat(float val, float min, float max, float expected) {
			// Variables
			float actual = Mathx.Clamp(val, min, max);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Floor(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its the rounded down number.
		/// </summary>
		[Theory]
		[InlineData(-3.0f, -3)]
		[InlineData(1.4f, 1)]
		[InlineData(2.9f, 2)]
		[InlineData(-4.9f, -5)]
		[InlineData(-5.5f, -6)]
		public void Floor_Float_ReturnsInt32(float val, int expected) {
			// Variables
			float actual = Mathx.Floor(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Ceiling(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its the rounded up number.
		/// </summary>
		[Theory]
		[InlineData(3.0f, 3)]
		[InlineData(1.4f, 2)]
		[InlineData(2.9f, 3)]
		[InlineData(-4.9f, -4)]
		[InlineData(-5.5f, -5)]
		public void Ceiling_Float_ReturnsInt32(float val, int expected) {
			// Variables
			float actual = Mathx.Ceiling(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Fraction(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its the fractional part of the number
		/// </summary>
		[Theory]
		[InlineData(3.0f, 0.0f)]
		[InlineData(-3.0f, 0.0f)]
		[InlineData(4.9f, 0.9f)]
		[InlineData(-4.9, 0.1f)]
		[InlineData(12.34f, 0.34f)]
		public void Fraction_Float_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Fraction(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Abs(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its the absolute (positive) value version of it
		/// </summary>
		[Theory]
		[InlineData(3.0f, 3.0f)]
		[InlineData(-3.0f, 3.0f)]
		[InlineData(0.0f, 0.0f)]
		public void Abs_Float_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Abs(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sign(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if it returns a positive or negative number
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0)]
		[InlineData(2.0f, 1)]
		[InlineData(-3.0f, -1)]
		public void Sign_Float_ReturnsInt32(float val, int expected) {
			// Variables
			int actual = Mathx.Sign(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Pow(float, float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0.0f, 1.0f)]
		[InlineData(10.0f, 0.0f, 1.0f)]
		[InlineData(0.0f, 2.0f, 0.0f)]
		[InlineData(10.0f, 2.0f, 100.0f)]
		[InlineData(2.0f, 0.4f, 1.3195079107728942f)]
		[InlineData(2.0f, -3.0f, 0.125f)]
		[InlineData(16, 0.25, 2)]
		[InlineData(16, -0.25, 0.5)]
		[InlineData(-1.0f, 0.1f, float.NaN)]
		public void Pow_Float_ReturnsFloat(float baseVal, float expVal, float expected) {
			// Variables
			float actual = Mathx.Pow(baseVal, expVal);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Pow(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(-1.0f, 0.367879441171f)]
		[InlineData(0.0f, 1.0f)]
		[InlineData(1.0f, Mathx.E)]
		[InlineData(2.0f, 7.38905609893f)]
		public void Pow_SingleFloat_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Pow(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.MapRange(float, float, float, float, float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 2.0f, 1.0f, 2.0f, 1.5f, 1.5f)]
		[InlineData(0.0f, 10.0f, 0.0f, 1.0f, 1.0f, 0.1f)]
		[InlineData(0.0f, 10.0f, 0.0f, 1.0f, 11.0f, 1.1f)]
		[InlineData(-10.0f, 10.0f, 0.0f, 1.0f, 1.0f, 0.55f)]
		[InlineData(-100.0f, -10.0f, 10.0f, 100.0f, -10.0f, 100.0f)]
		public void MapRange_Floats_ReturnsFloat(
			float minBase, float maxBase,
			float minMapped, float maxMapped,
			float val, float expected
		) {
			// Variables
			float actual = Mathx.MapRange(val, minBase, maxBase, minMapped, maxMapped);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Log(float, float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(2.0f, 2.0f, 1.0f)]
		[InlineData(1.0f, 2.0f, 0.0f)]
		[InlineData(10.0f, 2.0f, 3.32192809489)]
		[InlineData(16.0f, 4.0f, 2.0f)]
		[InlineData(2.0f, 1.0f, float.NaN)]
		public void Log_FloatNewBase_ReturnsFloat(float val, float newBase, float expected) {
			// Variables
			float actual = Mathx.Log(val, newBase);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Log(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 0.0f)]
		[InlineData(2.0f, 0.301029995664f)]
		[InlineData(10.0f, 1.0f)]
		[InlineData(50.0f, 1.69897000434f)]
		[InlineData(100.0f, 2.0f)]
		public void Log_FloatBase10_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Log(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Ln(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 0.0f)]
		[InlineData(Mathx.E, 1.0f)]
		[InlineData(2.0f, 0.69314718056f)]
		[InlineData(10.0f, 2.30258509299f)]
		public void Ln_Float_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Ln(val);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Trunc(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its truncated
		/// </summary>
		[Theory]
		[InlineData(0.0f, 0)]
		[InlineData(0.1f, 0)]
		[InlineData(1.5f, 1)]
		[InlineData(15.9f, 15)]
		public void Trunc_Float_ReturnsInt32(float val, int expected) {
			// Variables
			float actual = Mathx.Trunc(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Sqrt(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f)]
		[InlineData(2.0f, 1.41421356237)]
		[InlineData(4.0f, 2.0f)]
		[InlineData(16.0f, 4.0f)]
		[InlineData(63.45f, 7.96555082841f)]
		[InlineData(-1.0f, float.NaN)]
		public void Sqrt_Float_ReturnsFloat(float val, float expected) {
			// Variables
			float actual = Mathx.Sqrt(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Round(float)"/> functionality.
		/// Puts in a floating point number through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1)]
		[InlineData(1.1f, 1)]
		[InlineData(1.4f, 1)]
		[InlineData(1.5f, 2)]
		[InlineData(2.5f, 3)]
		[InlineData(1.9f, 2)]
		[InlineData(-1.4f, -1)]
		[InlineData(-1.6f, -2)]
		[InlineData(-1.5f, -2)]
		[InlineData(-2.5f, -3)]
		public void Round_Float_ReturnsInt32(float val, int expected) {
			// Variables
			int actual = Mathx.Round(val);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Round(float, int)"/> functionality.
		/// Puts in a floating point number and the amount of digits to round through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 0, 1.0f)]
		[InlineData(-1.0f, 0, -1.0f)]
		[InlineData(1.525f, 0, 2.0f)]
		[InlineData(1.525f, 1, 1.5f)]
		[InlineData(1.525f, 2, 1.53f)]
		[InlineData(-1.535f, 0, -2.0f)]
		[InlineData(-1.535f, 2, -1.54f)]
		[InlineData(-2.535f, 0, -3.0f)]
		[InlineData(-2.535f, 1, -2.5f)]
		[InlineData(-2.535f, 2, -2.54f)]
		[InlineData(-2.4f, 0, -2)]
		[InlineData(-2.6f, 0, -3)]
		public void Round_FloatWithDigits_ReturnsFloat(float val, int digits, float expected) {
			// Variables
			float actual = Mathx.Round(val, digits);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Smoothstep(float, float, float)"/> functionality.
		/// Puts in a floating point number and a range through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(-1.0f, 0.0f, 1.5f, 0.0f)]
		[InlineData(1.0f, 0.0f, 1.5f, 0.740740740741f)]
		[InlineData(2.0f, 0.0f, 1.5f, 1.0f)]
		[InlineData(0.5f, 0.0f, 1.5f, 0.259259259259f)]
		[InlineData(-1.0f, -1.0f, 3.0f, 0.0f)]
		[InlineData(1.0f, -1.0f, 3.0f, 0.5f)]
		[InlineData(2.0f, -1.0f, 3.0f, 0.84375f)]
		[InlineData(0.5f, -1.0f, 3.0f, 0.31640625f)]
		public void SmoothStep_Float_ReturnFloat(float val, float min, float max, float expected) {
			// Variables
			float actual = Mathx.Smoothstep(val, min, max);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Repeat(float, float, float)"/> functionality.
		/// Puts in a floating point number and a range through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 0.0f, 2.0f, 1.0f)]
		[InlineData(1.0f, 0.0f, 1.0f, 1.0f)]
		[InlineData(5.3f, 0.0f, 3.0f, 2.3f)]
		[InlineData(-4.0f, 0.0f, 1.23f, 0.31f)]
		[InlineData(-4.0f, 10.0f, 12.23f, 10.620003f)]
		public void Repeat_Float_ReturnsFloat(float val, float min, float max, float expected) {
			// Variables
			float actual = Mathx.Repeat(val, min, max);
			
			Assert.InRange(actual, expected - Epsilon, expected + Epsilon);
		}
		
		/// <summary>
		/// To check the validity, checking to see if a floating point error occurs so it can be used to check for approximate closeness
		/// </summary>
		[Fact]
		public void Approx_CausingFloatingPointErrorBeforeApprox_ReturnsNotEqual() {
			// Variables
			float notExpected = 1.0f;
			float actual = 1.0000001f;
			
			Assert.NotEqual(notExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Approx(float, float)"/> functionality.
		/// Checks to see if the two numbers are approximately close to each other
		/// </summary>
		[Fact]
		public void Approx_WithFloatingPointError_ReturnsTrue() {
			// Variables
			float original = 1.0f;
			float approx = 1.0000001f;
			bool actual = Mathx.Approx(original, approx);
			
			Assert.True(actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.Lerp(float, float, float)"/> functionality.
		/// Puts in a range and a value through the function and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(0.0f, 1.0f, 0.5f, 0.5f)]
		[InlineData(0.0f, 0.1f, 0.9f, 0.089999996f)]
		[InlineData(-10.0f, 10.0f, 0.6f, 2f)]
		[InlineData(-10.0f, -4.0f, 0.7f, -5.8f)]
		[InlineData(1.0f, 4.0f, 1.5f, 5.5f)]
		public void Lerp_Float_ReturnsFloat(float min, float max, float time, float expected) {
			// Variables
			float actual = Mathx.Lerp(min, max, time);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.MinRange(float[])"/> functionality.
		/// Puts in a list of numbers through the function and checks to see if it returns the correct smallest number
		/// </summary>
		[Theory]
		[InlineData(10, 20, 2103, 302, 10, 20)]
		[InlineData(1, 2, 29, 3, 2, 1)]
		public void MinRange_Floats_ReturnsFloat(float expected, float val1, float val2, float val3, float val4, float val5) {
			// Variables
			float actual = Mathx.MinRange(val1, val2, val3, val4, val5);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.MaxRange(float[])"/> functionality.
		/// Puts in a list of numbers through the function and checks to see if it returns the correct largest number
		/// </summary>
		[Theory]
		[InlineData(2103, 20, 2103, 302, 10, 20)]
		[InlineData(29, 2, 29, 3, 2, 1)]
		public void MaxRange_Floats_ReturnsFloat(float expected, float val1, float val2, float val3, float val4, float val5) {
			// Variables
			float actual = Mathx.MaxRange(val1, val2, val3, val4, val5);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.MinMax(float, float, out float, out float)"/> functionality.
		/// Puts in a two numbers and returns two numbers sorting out which one is smallest and which one is largest and checks to see if the smallest one is correct
		/// </summary>
		[Theory]
		[InlineData(10, 20, 10)]
		[InlineData(10, 10, 20)]
		[InlineData(1, 1, 2)]
		[InlineData(1, 2, 1)]
		public void MinMax_Floats_ReturnsMin(float expected, float actual, float other) {
			Mathx.MinMax(actual, other, out actual, out other);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Mathx.MinMax(float, float, out float, out float)"/> functionality.
		/// Puts in a two numbers and returns two numbers sorting out which one is smallest and which one is largest and checks to see if the largest one is correct
		/// </summary>
		[Theory]
		[InlineData(20, 20, 10)]
		[InlineData(20, 10, 20)]
		[InlineData(2, 1, 2)]
		[InlineData(2, 2, 1)]
		public void MinMax_Floats_ReturnsMax(float expected, float other, float actual) {
			Mathx.MinMax(other, actual, out other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

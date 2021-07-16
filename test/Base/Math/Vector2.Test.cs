
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Vector2"/> structure to make sure it works correctly. Contains 106 tests</summary>
	public class Vector2Test {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Zero"/> functionality.
		/// Checks to see if the zero vector is correct
		/// </summary>
		[Fact]
		public void Constants_Zero_ReturnsVector2() {
			// Variables
			Vector2 vector = Vector2.Zero;
			(float, float) expected = (0, 0);
			(float, float) actual = (
				vector.x,
				vector.y
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.One"/> functionality.
		/// Checsk to see if the one vector is correct
		/// </summary>
		[Fact]
		public void Constants_One_ReturnsVector2() {
			// Variables
			Vector2 vector = Vector2.One;
			(float, float) expected = (1, 1);
			(float, float) actual = (
				vector.x,
				vector.y
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.UnitX"/> functionality.
		/// Checks to see if the unit x vector is correct
		/// </summary>
		[Fact]
		public void Constants_UnitX_ReturnsVector2() {
			// Variables
			Vector2 vector = Vector2.UnitX;
			(float, float) expected = (1, 0);
			(float, float) actual = (
				vector.x,
				vector.y
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.UnitY"/> functionality.
		/// Checks to see if the unit y vector is correct
		/// </summary>
		[Fact]
		public void Constants_UnitY_ReturnsVector2() {
			// Variables
			Vector2 vector = Vector2.UnitY;
			(float, float) expected = (0, 1);
			(float, float) actual = (
				vector.x,
				vector.y
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.UnitOne"/> functionality.
		/// Checks to see if the unit one vector is correct
		/// </summary>
		[Fact]
		public void Constants_UnitOne_ReturnsVector2() {
			// Variables
			Vector2 vector = Vector2.UnitOne;
			(float, float) expected = (0.707106781187f, 0.707106781187f);
			(float, float) actual = (
				vector.x,
				vector.y
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.ToVector3"/> functionality.
		/// Checks to see if the vector gets converted
		/// </summary>
		[Fact]
		public void ToVector3_12Vector2_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 2, 0);
			Vector2 vector = new Vector2(1, 2);
			Vector3 actual = vector.ToVector3();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.ToVector4"/> functionality.
		/// Checks to see if the vector gets converted
		/// </summary>
		[Fact]
		public void ToVector4_12Vector2_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 0, 1);
			Vector2 vector = new Vector2(1, 2);
			Vector4 actual = vector.ToVector4();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Heading"/> functionality.
		/// Creates a vector and checks to see if the heading is correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(1, 0, 0)]
		[InlineData(1, 1, Mathx.Pi / 4.0)]
		[InlineData(0, 1, Mathx.Pi / 2.0)]
		[InlineData(-0.601815023152, 0.798635510047, 2.21656815003)]
		public void Heading_ReturnsFloat(float x, float y, float expected) {
			// Variables
			Vector2 vector = new Vector2(x, y);
			float actual = vector.Heading;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Magnitude"/> functionality.
		/// Gets the magnitude from the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.41421356237)]
		[InlineData(3.0f, 4.0f, 5.0f)]
		[InlineData(7.0f, 2.0f, 7.28010988928f)]
		public void Magnitude_ReturnsFloat(float x, float y, float expected) {
			// Variables
			Vector2 vector = new Vector2(x, y);
			float actual = vector.Magnitude;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.MagnitudeSquared"/> functionality.
		/// Gets the squared magnitude from the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 2.0f)]
		[InlineData(3.0f, 4.0f, 25.0f)]
		[InlineData(7.0f, 2.0f, 53.0f)]
		public void MagnitudeSquared_ReturnsFloat(float x, float y, float expected) {
			// Variables
			Vector2 vector = new Vector2(x, y);
			float actual = vector.MagnitudeSquared;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.FromAngle(float)"/> functionality.
		/// Creates a vector from a single angle and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 1)]
		[InlineData(Mathx.Pi / 4.0f, 0.707106781187, 0.707106781187)]
		[InlineData(1.0471975512, 0.5, 0.866025403784)]
		[InlineData(Mathx.PiOverTwo, 1, 0)]
		[InlineData(2.21656815, -0.601815023152, 0.798635510047)]
		public void FromAngle_RadianAngle_ReturnsVector2(float angle, float ex, float ey) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = Vector2.FromAngle(angle);
			Vector2 margin = 0.0000001f * Vector2.One;
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.FromAngleDeg(float)"/> functionality.
		/// Creates a vector from a single angle in degrees and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 1)]
		[InlineData(45, 0.707106781187, 0.707106781187)]
		[InlineData(60, 0.5, 0.866025403784)]
		[InlineData(90, 1, 0)]
		[InlineData(127, -0.601815023152, 0.798635510047)]
		public void FromAngleDeg_DegreeAngle_ReturnsVector2(float angle, float ex, float ey) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = Vector2.FromAngleDeg(angle);
			Vector2 margin = 0.0000001f * Vector2.One;
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Add(Vector2)"/> functionality.
		/// Adds two vectors together and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 1, 1, 0, 1, 1)]
		[InlineData(1, 2, 3, 4, 4, 6)]
		public void Add_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 other = new Vector2(bx, by);
			
			Vector2.Add(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Subtract(Vector2)"/> functionality.
		/// Subtracts one vector from the other and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0)]
		[InlineData(0, 1, 1, 0, -1, 1)]
		[InlineData(1, 2, 3, 4, -2, -2)]
		public void Subtract_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 other = new Vector2(bx, by);
			
			Vector2.Subtract(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Multiply(float)"/> functionality.
		/// Multiplies a vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 1, 1, 1)]
		[InlineData(-1, 1, 1, -1, -1)]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0.5, 1, 1, 0.5, 0.5)]
		[InlineData(3, 3, -4, 9, -12)]
		public void Multiply_Scalar_ReturnsVector2(
			float scalar, float ax, float ay,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 vector = new Vector2(ax, ay);
			Vector2 actual;
			
			Vector2.Multiply(scalar, ref vector, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Divide(float)"/> functionality.
		/// Divides a vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 1, 1, 1)]
		[InlineData(-1, 1, 1, -1, -1)]
		[InlineData(0.5, 1, 1, 2, 2)]
		[InlineData(3, 3, -4, 1, -1.3333334)]
		public void Divide_Scalar_ReturnsVector2(
			float scalar, float ax, float ay,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 vector = new Vector2(ax, ay);
			Vector2 actual;
			
			Vector2.Divide(scalar, ref vector, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Dot(Vector2)"/> functionality.
		/// Dot products two vectors together and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(1, 0, 0, 1, 0)]
		[InlineData(1, 1, 1, 1, 2)]
		[InlineData(0, 1, 0, 1, 1)]
		[InlineData(1, 2, 3, 4, 11)]
		public void Dot_TwoVectors_ReturnsFloat(
			float ax, float ay,
			float bx, float by,
			float expected
		) {
			// Variables
			Vector2 first = new Vector2(ax, ay);
			Vector2 second = new Vector2(bx, by);
			float actual = first * second;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Normalize"/> functionality.
		/// Normalizes the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0)]
		[InlineData(0, 1, 0, 1)]
		[InlineData(1, 1, 0.707106781187f, 0.707106781187f)]
		[InlineData(1, 2, 0.4472135955, 0.894427191)]
		public void Normalize_SingleVector_ReturnsVector2(float x, float y, float ex, float ey) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Normalize(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Negate"/> functionality.
		/// Negates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Negate_SingleVector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(-1, 2);
			Vector2 actual = new Vector2(1, -2);
			
			Vector2.Negate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.CreatePerpendicular"/> functionality.
		/// Creates a perpendicular vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void CreatePerpendicular_SingleVector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(-2, -1);
			Vector2 actual = new Vector2(1, -2);
			
			Vector2.CreatePerpendicular(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Project(Vector2, Vector2)"/> functionality.
		/// Projects a vector onto another and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, -8, -13.0 / 5.0, -26.0 / 5.0)]
		[InlineData(2, 4, -1, 5, 9.0 / 5.0, 18.0 / 5.0)]
		[InlineData(1, 2, 3, 4, 11.0 / 5.0, 22.0 / 5.0)]
		public void Project_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 other = new Vector2(bx, by);
			
			Vector2.Project(ref other, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Reject(Vector2, Vector2)"/> functionality.
		/// Rejects a vector onto another and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, -8, 5.6, -2.8000002)]
		[InlineData(2, 4, -1, 5, -2.8, 1.4000001)]
		[InlineData(1, 2, 3, 4, 0.79999995, -0.4000001)]
		public void Reject_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 other = new Vector2(ax, ay);
			Vector2 actual = new Vector2(bx, by);
			
			Vector2.Reject(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Min(Vector2, Vector2)"/> functionality.
		/// Gets the minimum vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, 4, 1, 2)]
		[InlineData(-1, 0, 1, -4, -1, -4)]
		[InlineData(0, 0, 1, 0, 0, 0)]
		public void Min_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 other = new Vector2(bx, by);
			
			Vector2.Min(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Max(Vector2, Vector2)"/> functionality.
		/// Gets the maximum vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, 4, 3, 4)]
		[InlineData(-1, 0, 1, -4, 1, 0)]
		[InlineData(0, 0, 1, 0, 1, 0)]
		public void Max_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 other = new Vector2(bx, by);
			
			Vector2.Max(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Abs(Vector2)"/> functionality.
		/// Gets the absolute vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 1, 2)]
		[InlineData(-1, 1, 1, 1)]
		[InlineData(0, 0, 0, 0)]
		[InlineData(-4, -5, 4, 5)]
		public void Abs_TwoVectors_ReturnsVector2(
			float ax, float ay,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			
			Vector2.Abs(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Approx(Vector2, Vector2)"/> functionality.
		/// Checks if two vectors that are approximately close to each other are not equal
		/// </summary>
		[Fact]
		public void Approx_TwoVectors_ReturnsNotEqual() {
			// Variables
			Vector2 notExpected = new Vector2(1.0f, 2.0f);
			Vector2 actual = new Vector2(1.0000001f, 2.0000001f);
			
			Assert.NotEqual(notExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Approx(Vector2, Vector2)"/> functionality.
		/// Checks if two vectors that are approximately close to each other are approximately close
		/// </summary>
		[Fact]
		public void Approx_TwoVectors_ReturnsTrue() {
			// Variables
			Vector2 expected = new Vector2(1.0f, 2.0f);
			Vector2 actual = new Vector2(1.0000001f, 2.0000001f);
			
			Assert.True(Vector2.Approx(expected, actual));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Clamp(Vector2, Vector2, Vector2)"/> functionality.
		/// Clamps a vector between a minimum and maximum vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1.5, 0, 1, 1, 2, 1, 1.5)]
		[InlineData(1, 3, 0, 1, 1, 2, 1, 2)]
		[InlineData(-4, 3, -1, -1, 1, 1, -1, 1)]
		public void Clamp_ThreeVectors_ReturnsVector2(
			float ax, float ay,
			float bx, float by,
			float cx, float cy,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(ax, ay);
			Vector2 min = new Vector2(bx, by);
			Vector2 max = new Vector2(cx, cy);
			
			Vector2.Clamp(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Ceiling(Vector2)"/> functionality.
		/// Gets a rounded up vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.1, 1, 3)]
		[InlineData(1.000001, 2.0, 2, 2)]
		[InlineData(1.5, 2.9, 2, 3)]
		[InlineData(-1.4, -4.0, -1, -4)]
		public void Ceiling_Vector_ReturnsVector2(
			float x, float y,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Ceiling(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Floor(Vector2)"/> functionality.
		/// Gets a rounded down vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.1, 1, 2)]
		[InlineData(1.000001, 2.0, 1, 2)]
		[InlineData(1.5, 2.9, 1, 2)]
		[InlineData(-1.4, -4.0, -2, -4)]
		public void Floor_Vector_ReturnsVector2(
			float x, float y,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Floor(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Fraction(Vector2)"/> functionality.
		/// Gets the fractional part of the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.1, 0, 0.099999905)]
		[InlineData(1.000001, 2.0, 0.0000009536743, 0)]
		[InlineData(1.5, 2.9, 0.5, 0.9000001)]
		[InlineData(-1.4, -4.0, 0.6, 0)]
		public void Fraction_Vector_ReturnsVector2(
			float x, float y,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Fraction(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Round(Vector2)"/> functionality.
		/// Rounds the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.1, 1, 2)]
		[InlineData(1.000001, 2.0, 1, 2)]
		[InlineData(1.5, 2.9, 2, 3)]
		[InlineData(1.4, 2.9, 1, 3)]
		[InlineData(-1.4, -4.0, -1, -4)]
		[InlineData(-1.5, -4.9, -2, -5)]
		public void Round_Vector_ReturnsVector2(
			float x, float y,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Round(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Trunc(Vector2)"/> functionality.
		/// Truncates the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.1, 1, 2)]
		[InlineData(1.000001, 2.0, 1, 2)]
		[InlineData(1.5, 2.9, 1, 2)]
		[InlineData(1.4, 2.9, 1, 2)]
		[InlineData(-1.4, -4.0, -1, -4)]
		[InlineData(-1.5, -4.9, -1, -4)]
		public void Trunc_Vector_ReturnsVector2(
			float x, float y,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Vector2 actual = new Vector2(x, y);
			
			Vector2.Trunc(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Sqrt(Vector2)"/> functionality.
		/// Square roots the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Sqrt_Vector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(2, 4.2426405f);
			Vector2 actual = new Vector2(4, 18);
			
			Vector2.Sqrt(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Repeat(Vector2, Vector2, Vector2)"/> functionality.
		/// Repeats the vector over a minimum and maximum vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Repeat_Vector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(0, 2);
			Vector2 actual = new Vector2(10, 8);
			Vector2 min = new Vector2(0, -3);
			Vector2 max = new Vector2(5, 3);
			
			Vector2.Repeat(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Smoothstep(Vector2, Vector2, Vector2)"/> functionality.
		/// Smoothsteps a vector over a minimum and maximum vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Smoothstep_Vector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(0.25925928f, 0.84375f);
			Vector2 actual = new Vector2(0.5f, 2.0f);
			Vector2 min = new Vector2(0.0f, -1.0f);
			Vector2 max = new Vector2(1.5f, 3.0f);
			
			Vector2.Smoothstep(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.Lerp(Vector2, Vector2, float)"/> functionality.
		/// Linearly interpolates a vector between two vectors and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Lerp_ThreeVectors_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(0.07f, -5.8f);
			Vector2 actual = new Vector2(0.0f, -10.0f);
			Vector2 max = new Vector2(0.1f, -4.0f);
			float time = 0.7f;
			
			Vector2.Lerp(ref actual, ref max, time, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.MapRange(Vector2, Vector2, Vector2, Vector2, Vector2)"/> functionality.
		/// Maps a vector over a range of vectors and checks to see if it's correct
		/// </summary>
		[Fact]
		public void MapRange_FourVectors_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(0.1f, 0.55f);
			Vector2 actual = Vector2.One; // Actual and maxMapped are the same
			Vector2 minBase = new Vector2(0.0f, -10.0f);
			Vector2 maxBase = new Vector2(10.0f, 10.0f);
			Vector2 minMapped = new Vector2(0.0f, 0.0f);
			
			Vector2.MapRange(ref actual, ref minBase, ref maxBase, ref minMapped, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.MinMax(Vector2, Vector2, out Vector2, out Vector2)"/> functionality.
		/// Rearranges the minimum and maximum vectors and checks to see if the minimum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_MinVector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(-3, 2);
			Vector2 actual = new Vector2(4, 2);
			Vector2 other = new Vector2(-3, 8);
			
			Vector2.MinMax(ref actual, ref other, out actual, out other);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector2.MinMax(Vector2, Vector2, out Vector2, out Vector2)"/> functionality.
		/// Rearranges the minimum and maximum vectors and checks to see if the maximum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_MaxVector_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(4, 8);
			Vector2 actual = new Vector2(4, 2);
			Vector2 other = new Vector2(-3, 8);
			
			Vector2.MinMax(ref actual, ref other, out other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

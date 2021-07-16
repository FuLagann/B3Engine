
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Vector4"/> structure to make sure it works correctly. Contains 52 tests</summary>
	public class Vector4Test {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Zero"/> functionality.
		/// 
		/// </summary>
		[Fact]
		public void Constructor_Returns1234() {
			// Variables
			Vector4 vector = new Vector4(1, 2, 3, 4);
			(float, float, float, float) expected = (1, 2, 3, 4);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Zero"/> functionality.
		/// Checks to see if the zero vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_Zero_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.Zero;
			(float, float, float, float) expected = (0, 0, 0, 0);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.One"/> functionality.
		/// Checks to see if the one vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_One_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.One;
			(float, float, float, float) expected = (1, 1, 1, 1);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.UnitX"/> functionality.
		/// Checks to see if the unit x vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_UnitX_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.UnitX;
			(float, float, float, float) expected = (1, 0, 0, 0);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.UnitY"/> functionality.
		/// Checks to see if the unit y vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_UnitY_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.UnitY;
			(float, float, float, float) expected = (0, 1, 0, 0);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.UnitZ"/> functionality.
		/// Checks to see if the unit z vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_UnitZ_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.UnitZ;
			(float, float, float, float) expected = (0, 0, 1, 0);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.UnitW"/> functionality.
		/// Checks to see if the unit w vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_UnitW_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.UnitW;
			(float, float, float, float) expected = (0, 0, 0, 1);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.UnitOne"/> functionality.
		/// Checks to see if the unit one vector is formed correctly
		/// </summary>
		[Fact]
		public void Constants_UnitOne_ReturnsVector4() {
			// Variables
			Vector4 vector = Vector4.UnitOne;
			(float, float, float, float) expected = (0.5f, 0.5f, 0.5f, 0.5f);
			(float, float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z,
				vector.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.ToVector2"/> functionality.
		/// Converts the vector into a 2D vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void ToVector2_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(1, 2);
			Vector4 vector = new Vector4(1, 2, 3, 4);
			Vector2 actual = vector.ToVector2();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.ToVector3"/> functionality.
		/// Converts the vector into a 3D vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void ToVector3_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 2, 3);
			Vector4 vector = new Vector4(1, 2, 3, 4);
			Vector3 actual = vector.ToVector3();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Magnitude"/> functionality.
		/// Gets the magnitude from a vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f, 1.0f, 2.0f)]
		[InlineData(3.0f, 4.0f, 5.0f, 6.0f, 9.2736184955)]
		[InlineData(7.0f, 2.0f, 9.0f, 5.0f, 12.6095202129)]
		public void Magnitude_SingleVector_ReturnsFloat(float x, float y, float z, float w, float expected) {
			// Variables
			Vector4 vector = new Vector4(x, y, z, w);
			float actual = vector.Magnitude;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.MagnitudeSquared"/> functionality.
		/// Gets the squared magnitude from a vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f, 1.0f, 4.0f)]
		[InlineData(3.0f, 4.0f, 5.0f, 6.0f, 86.0f)]
		[InlineData(7.0f, 2.0f, 9.0f, 5.0f, 159.0f)]
		public void MagnitudeSquared_SingleVector_ReturnsFloat(float x, float y, float z, float w, float expected) {
			// Variables
			Vector4 vector = new Vector4(x, y, z, w);
			float actual = vector.MagnitudeSquared;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Add(Vector4)"/> functionality.
		/// Adds two vectors together and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Add_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-3, 0, 4, 4.1f);
			Vector4 actual = new Vector4(-1, 0, 1, 5.5f);
			Vector4 other = new Vector4(-2, 0, 3, -1.4f);
			
			Vector4.Add(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Subtract(Vector4)"/> functionality.
		/// Subtracts a vector from another and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Subtract_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 0, -2, 6.9f);
			Vector4 actual = new Vector4(-1, 0, 1, 5.5f);
			Vector4 other = new Vector4(-2, 0, 3, -1.4f);
			
			Vector4.Subtract(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Multiply(float)"/> functionality.
		/// Multiplies a vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 2, 3, 4, 1, 2, 3, 4)]
		[InlineData(0.25, 1, 2, 3, 4, 0.25, 0.5, 0.75, 1)]
		[InlineData(-2, 1, -2, 3, -4, -2, 4, -6, 8)]
		public void Multiply_ScalarAndVector_ReturnsVector4(
			float scalar, float x, float y, float z, float w,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Vector4 actual = new Vector4(x, y, z, w);
			
			Vector4.Multiply(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Divide(float)"/> functionality.
		/// Divides a vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 2, 3, 4, 1, 2, 3, 4)]
		[InlineData(0.25, 1, 2, 3, 4, 4, 8, 12, 16)]
		[InlineData(-2, 1, -2, 3, -4, -0.5, 1, -1.5, 2)]
		public void Divide_ScalarAndVector_ReturnsVector4(
			float scalar, float x, float y, float z, float w,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Vector4 actual = new Vector4(x, y, z, w);
			
			Vector4.Divide(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Dot(Vector4)"/> functionality.
		/// Dot products two vectors and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, 4, 5, 6, 7, 8, 70)]
		[InlineData(1, 2, 3, 4, 1, 2, 3, 4, 30)]
		[InlineData(-1, 0, 1, -10, 5, 10, -2, -3, 23)]
		public void Dot_TwoVectors_ReturnsFloat(
			float ax, float ay, float az, float aw,
			float bx, float by, float bz, float bw,
			float expected
		) {
			// Variables
			Vector4 first = new Vector4(ax, ay, az, aw);
			Vector4 second = new Vector4(bx, by, bz, bw);
			float actual = first * second;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Normalize"/> functionality.
		/// Normalizes the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Normalize_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-0.024891337f, 0.049782675f, -0.07467401f, 0.9956535f);
			Vector4 actual = new Vector4(-1, 2, -3, 40);
			
			Vector4.Normalize(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Negate"/> functionality.
		/// Negates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Negate_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 0, -1, -3.2f);
			Vector4 actual = new Vector4(-1, 0, 1, 3.2f);
			
			Vector4.Negate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Project(Vector4, Vector4)"/> functionality.
		/// Projects a vector onto another and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Project_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(0.6f, 1.2f, 1.8000001f, 2.4f);
			Vector4 actual = new Vector4(1, 2, 3, 4);
			Vector4 other = new Vector4(-5, 6, -7, 8);
			
			Vector4.Project(ref other, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Reject(Vector4, Vector4)"/> functionality.
		/// Rejects a vector from another and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Reject_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-5.6f, 4.8f, -8.8f, 5.6f);
			Vector4 actual = new Vector4(1, 2, 3, 4);
			Vector4 other = new Vector4(-5, 6, -7, 8);
			
			Vector4.Reject(ref other, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Abs(Vector4)"/> functionality.
		/// Gets the absolute vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Abs_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 0, 1, 3.2f);
			Vector4 actual = new Vector4(-1, 0, 1, -3.2f);
			
			Vector4.Abs(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Approx(Vector4, Vector4)"/> functionality.
		/// Checks to see if two approximately close vectors are not equal
		/// </summary>
		[Fact]
		public void Approx_TwoVectors_ReturnsNotEqual() {
			// Variables
			Vector4 notExpected = new Vector4(1, 2, 3, 4);
			Vector4 actual = new Vector4(1.0000001f, 2, 3.0000001f, 4);
			
			Assert.NotEqual(notExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Approx(Vector4, Vector4)"/> functionality.
		/// Checks to see if two approximately close vectors are approximately close
		/// </summary>
		[Fact]
		public void Approx_TwoVectors_ReturnsTrue() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 3, 4);
			Vector4 actual = new Vector4(1.0000001f, 2, 3.0000001f, 4);
			
			Assert.True(Vector4.Approx(expected, actual));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Ceiling(Vector4)"/> functionality.
		/// Gets the ceiling vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0, 2.1, 3.9, -4.0, 1, 3, 4, -4)]
		[InlineData(-2.3, 0.0, 0.1, -0.1, -2, 0, 1, 0)]
		public void Ceiling_SingleVector_ReturnsVector4(
			float x, float y, float z, float w,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Vector4 actual = new Vector4(x, y, z, w);
			
			Vector4.Ceiling(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Floor(Vector4)"/> functionality.
		/// Gets the floor vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0, 2.1, 3.9, -4.0, 1, 2, 3, -4)]
		[InlineData(-2.3, 0.0, 0.1, -0.1, -3, 0, 0, -1)]
		public void Floor_SingleVector_ReturnsVector4(
			float x, float y, float z, float w,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Vector4 actual = new Vector4(x, y, z, w);
			
			Vector4.Floor(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Fraction(Vector4)"/> functionality.
		/// Gets the fraction vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0, 2.1, 3.9, -4.0, 0, 0.1, 0.9, 0)]
		[InlineData(-2.3, 0.0, 0.1, -0.1, 0.7, 0, 0.1, 0.9)]
		public void Fraction_SingleVector_ReturnsVector4(
			float x, float y, float z, float w,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Vector4 actual = new Vector4(x, y, z, w);
			Vector4 margin = 0.0000001f * Vector4.One;
			
			Vector4.Fraction(ref actual, out actual);
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Clamp(Vector4, Vector4, Vector4)"/> functionality.
		/// Clamps the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Clamp_ThreeVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-1, -2, 1, 2.5f);
			Vector4 actual = new Vector4(-1, -2, 0, 3);
			Vector4 min = new Vector4(-1, -3, 1, 2);
			Vector4 max = new Vector4(1, 3, 2, 2.5f);
			
			Vector4.Clamp(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Lerp(Vector4, Vector4, float)"/> functionality.
		/// Linearly interpolates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Lerp_ThreeVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-0.3f, -0.25f, 0.7f, 2.825f);
			Vector4 actual = new Vector4(-1, -2, 0, 3);
			Vector4 other = new Vector4(1, 3, 2, 2.5f);
			float time = 0.35f;
			
			Vector4.Lerp(ref actual, ref other, time, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.MapRange(Vector4, Vector4, Vector4, Vector4, Vector4)"/> functionality.
		/// Maps the vector into a different range and checks to see if it's correct
		/// </summary>
		[Fact]
		public void MapRange_FiveVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(10.55f, 2.1666665f, 13, 5);
			Vector4 actual = new Vector4(0.1f, -2, 0, 3);
			Vector4 minBase = new Vector4(-1, -3, 1, 2);
			Vector4 maxBase = new Vector4(1, 3, 2, 2.5f);
			Vector4 minMapped = new Vector4(10, 1, 5, 0);
			Vector4 maxMapped = new Vector4(11, 8, -3, 2.5f);
			
			Vector4.MapRange(ref actual, ref minBase, ref maxBase, ref minMapped, ref maxMapped, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Min(Vector4, Vector4)"/> functionality.
		/// Gets the minimum vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Min_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(-1, 0, -1, -8);
			Vector4 actual = new Vector4(-1, 0, 1, 8);
			Vector4 other = new Vector4(1, 2, -1, -8);
			
			Vector4.Min(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Max(Vector4, Vector4)"/> functionality.
		/// Gets the maximum vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Max_TwoVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 1, 8);
			Vector4 actual = new Vector4(-1, 0, 1, 8);
			Vector4 other = new Vector4(1, 2, -1, -8);
			
			Vector4.Max(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.MinMax(Vector4, Vector4, out Vector4, out Vector4)"/> functionality.
		/// Rearranges the minimum and maximum vector and checks to see if the minimum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_TwoVectors_ReturnsMinVector4() {
			// Variables
			Vector4 expected = new Vector4(-1, 0, -1, -8);
			Vector4 actual = new Vector4(-1, 0, 1, 8);
			Vector4 other = new Vector4(1, 2, -1, -8);
			
			Vector4.MinMax(ref actual, ref other, out actual, out other);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.MinMax(Vector4, Vector4, out Vector4, out Vector4)"/> functionality.
		/// Rearranges the minimum and maximum vector and checks to see if the maximum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_TwoVectors_ReturnsMaxVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 1, 8);
			Vector4 actual = new Vector4(-1, 0, 1, 8);
			Vector4 other = new Vector4(1, 2, -1, -8);
			
			Vector4.MinMax(ref actual, ref other, out other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Repeat(Vector4, Vector4, Vector4)"/> functionality.
		/// Repeats the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Repeat_ThreeVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2.0000005f, 1, 10);
			Vector4 actual = new Vector4(1, 12, 13, 4);
			Vector4 min = new Vector4(-1, 0, 2, 7);
			Vector4 max = new Vector4(1, 10f, -2, 13);
			
			Vector4.Repeat(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Round(Vector4)"/> functionality.
		/// Rounds the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Round_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 1, 2, 3);
			Vector4 actual = new Vector4(1.0f, 1.1f, 1.9f, 2.5f);
			
			Vector4.Round(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Smoothstep(Vector4, Vector4, Vector4)"/> functionality.
		/// Smooth steps the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Smoothstep_ThreeVectors_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(0.5f, 0.104f, 1, 0.95703125f);
			Vector4 actual = new Vector4(0, 2, 3, 3);
			Vector4 min = new Vector4(-1, 0, 1, -4);
			Vector4 max = new Vector4(1, 10, 2, 4);
			
			Vector4.Smoothstep(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Sqrt(Vector4)"/> functionality.
		/// Square roots the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Sqrt_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 1.41421356237f, 1.73205080757f, 2);
			Vector4 actual = new Vector4(1, 2, 3, 4);
			
			Vector4.Sqrt(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector4.Trunc(Vector4)"/> functionality.
		/// Truncates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Trunc_SingleVector_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 3, 4);
			Vector4 actual = new Vector4(1.0f, 2.1f, 3.9f, 4.5f);
			
			Vector4.Trunc(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

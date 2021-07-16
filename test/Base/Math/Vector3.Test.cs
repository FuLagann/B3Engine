
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Vector3"/> structure to make sure it works correctly. Contains 67 tests</summary>
	public class Vector3Test {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Vector3(float, float, float)"/> functionality.
		/// Creates a 3D vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Constructor_Returns123() {
			// Variables
			(float, float, float) expected = (1, 2, 3);
			Vector3 vector = new Vector3(1, 2, 3);
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Zero"/> functionality.
		/// Checks to see if the zero vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_Zero_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (0, 0, 0);
			Vector3 vector = Vector3.Zero;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.One"/> functionality.
		/// Checks to see if the one vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_One_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (1, 1, 1);
			Vector3 vector = Vector3.One;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.UnitX"/> functionality.
		/// Checks to see if the unit x vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_UnitX_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (1, 0, 0);
			Vector3 vector = Vector3.UnitX;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.UnitY"/> functionality.
		/// Checks to see if the unit y vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_UnitY_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (0, 1, 0);
			Vector3 vector = Vector3.UnitY;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.UnitZ"/> functionality.
		/// Checks to see if the unit z vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_UnitZ_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (0, 0, 1);
			Vector3 vector = Vector3.UnitZ;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.UnitOne"/> functionality.
		/// Checks to see if the unit one vector is formed correctly
		/// </summary>
		[Fact]
		public void Contants_UnitOne_ReturnsVector3() {
			// Variables
			(float, float, float) expected = (0.57735026919f, 0.57735026919f, 0.57735026919f);
			Vector3 vector = Vector3.UnitOne;
			(float, float, float) actual = (
				vector.x,
				vector.y,
				vector.z
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.ToVector4"/> functionality.
		/// Converts the vector to a 4D vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void ToVector4_ReturnsVector4() {
			// Variables
			Vector4 expected = new Vector4(1, 2, 3, 1);
			Vector3 vector = new Vector3(1, 2, 3);
			Vector4 actual = vector.ToVector4();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.ToVector2"/> functionality.
		/// Converts the vector to a 4D vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void ToVector2_ReturnsVector2() {
			// Variables
			Vector2 expected = new Vector2(1, 2);
			Vector3 vector = new Vector3(1, 2, 3);
			Vector2 actual = vector.ToVector2();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Magnitude"/> functionality.
		/// Gets the magnitude of the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f, 1.73205080757)]
		[InlineData(3.0f, 4.0f, 5.0f, 7.07106781187)]
		[InlineData(7.0f, 2.0f, 9.0f, 11.5758369028)]
		public void Magnitude_Vector_ReturnsFloat(float x, float y, float z, float expected) {
			// Variables
			Vector3 vector = new Vector3(x, y, z);
			float actual = vector.Magnitude;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.MagnitudeSquared"/> functionality.
		/// Gets the squared magnitude of the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f, 3)]
		[InlineData(3.0f, 4.0f, 5.0f, 50)]
		[InlineData(7.0f, 2.0f, 9.0f, 134)]
		public void MagnitudeSquared_Vector_ReturnsFloat(float x, float y, float z, float expected) {
			// Variables
			Vector3 vector = new Vector3(x, y, z);
			float actual = vector.MagnitudeSquared;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.FromAngles(float, float)"/> functionality.
		/// Creates a vector from two angles and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(Mathx.Pi / 4.0f, Mathx.Pi / 4.0f, 0.5, 0.5, 0.707106781187)]
		[InlineData(0.523598775598, 1.0471975512, 0.999791230426, 0.00913686909743, 0.0182760276285)]
		[InlineData(-2.21656815003, 2.21656815003, 0.998504107996, -0.0386478241492, 0.038676763106)]
		public void FromAngle_TwoAnglesInRadians_ReturnsVector3(
			float theta, float phi,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = Vector3.FromAngles(theta, phi);
			Vector3 margin = 0.0000001f * Vector3.One;
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.FromAnglesDeg(float, float)"/> functionality.
		/// Creates a vector from two degree angles and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(45, 45, 0.5, 0.5, 0.707106781187)]
		[InlineData(30, 60, 0.999791230426, 0.00913686909743, 0.0182760276285)]
		[InlineData(-127, 127, 0.998504107996, -0.0386478241492, 0.038676763106)]
		public void FromAngleDeg_TwoAnglesInRadians_ReturnsVector3(
			float theta, float phi,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = Vector3.FromAnglesDeg(theta, phi);
			Vector3 margin = 0.0000001f * Vector3.One;
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Add(Vector3)"/> functionality.
		/// Adds two vectors together and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 5, 6, 5, 7, 9)]
		[InlineData(1, 2, 3, -4, -5, -6, -3, -3, -3)]
		public void Add_TwoVectors_ReturnsVector3(
			float ax, float ay, float az,
			float bx, float by, float bz,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(ax, ay, az);
			Vector3 other = new Vector3(bx, by, bz);
			
			Vector3.Add(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Subtract(Vector3)"/> functionality.
		/// Subtracts two vectors from each other and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 5, 6, -3, -3, -3)]
		[InlineData(1, 2, 3, -4, -5, -6, 5, 7, 9)]
		public void Subtract_TwoVectors_ReturnsVector3(
			float ax, float ay, float az,
			float bx, float by, float bz,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(ax, ay, az);
			Vector3 other = new Vector3(bx, by, bz);
			
			Vector3.Subtract(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Multiply(float)"/> functionality.
		/// Multiplies the vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 2, 3, 1, 2, 3)]
		[InlineData(0, 1, 2, 3, 0, 0, 0)]
		[InlineData(0.5, 1, 2, 3, 0.5, 1, 1.5)]
		[InlineData(2, 1, -2, 3, 2, -4, 6)]
		[InlineData(-2, 1, -2, 3, -2, 4, -6)]
		public void Multiply_SingleScalar_ReturnsVector3(
			float scalar, float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(x, y, z);
			
			Vector3.Multiply(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Divide(float)"/> functionality.
		/// Divides the vector with a scalar and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 1, 2, 3, 1, 2, 3)]
		[InlineData(0.5, 1, 2, 3, 2, 4, 6)]
		[InlineData(2, 1, -2, 3, 0.5, -1, 1.5)]
		[InlineData(-2, 1, -2, 3, -0.5, 1, -1.5)]
		public void Divide_SingleScalar_ReturnsVector3(
			float scalar, float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(x, y, z);
			
			Vector3.Divide(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Dot(Vector3)"/> functionality.
		/// Dot products the two vectors and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, 1, 2, 3, 14)]
		[InlineData(1, 2, 3, 4, 5, 6, 32)]
		[InlineData(1, 0, 0, 0, 1, 0, 0)]
		public void Dot_TwoVectors_ReturnsFloat(
			float ax, float ay, float az,
			float bx, float by, float bz,
			float expected
		) {
			// Variables
			Vector3 first = new Vector3(ax, ay, az);
			Vector3 second = new Vector3(bx, by, bz);
			float actual = first * second;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Normalize"/> functionality.
		/// Normalizes the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Normalize_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(0.033241127f, 0.06648225f, 0.9972338f);
			Vector3 actual = new Vector3(1, 2, 30);
			
			Vector3.Normalize(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Negate"/> functionality.
		/// Negates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Negate_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 0, -3);
			Vector3 actual = new Vector3(-1, 0, 3);
			
			Vector3.Negate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.CrossProduct(Vector3)"/> functionality.
		/// Cross products the two vectors and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2, 3, 1, 2, 3, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 5, 6, -3, 6, -3)]
		[InlineData(-1, 2, -3, 4, 5, 6, 27, -6, -13)]
		public void CrossProduct_SingleVector_ReturnVector3(
			float ax, float ay, float az,
			float bx, float by, float bz,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(ax, ay, az);
			Vector3 other = new Vector3(bx, by, bz);
			
			Vector3.CrossProduct(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Project(Vector3, Vector3)"/> functionality.
		/// Projects the vector onto the other vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Project_TwoVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(128 / 77.0f, 160 / 77.0f, 192 / 77.0f);
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 other = new Vector3(4, 5, 6);
			
			Vector3.Project(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Reject(Vector3, Vector3)"/> functionality.
		/// Rejects the vector from another vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Reject_TwoVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-0.66233766f, -0.077922106f, 0.50649357f);
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 other = new Vector3(4, 5, 6);
			
			Vector3.Reject(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Abs(Vector3)"/> functionality.
		/// Gets the absolute vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Abs_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 0, 3);
			Vector3 actual = new Vector3(-1, 0, 3);
			
			Vector3.Abs(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Approx(Vector3, Vector3)"/> functionality.
		/// Gets two vectors that are approximately close to each other and checks to see if they do not equal each other
		/// </summary>
		[Fact]
		public void Approx_TwoVectorsApproximatelyClose_ReturnsNotEqual() {
			// Variables
			Vector3 notExpected = new Vector3(1, 2, 3);
			Vector3 actual = new Vector3(1.0000001f, 2, 3.00000002f);
			
			Assert.NotEqual(notExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Approx(Vector3, Vector3)"/> functionality.
		/// Gets two vectors that are approximately close to each other and checks to see if it's approximately close to each other
		/// </summary>
		[Fact]
		public void Approx_TwoVectorsApproximatelyClose_ReturnsTrue() {
			// Variables
			Vector3 first = new Vector3(1, 2, 3);
			Vector3 second = new Vector3(1.0000001f, 2, 3.00000002f);
			bool actual = Vector3.Approx(first, second);
			
			Assert.True(actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Trunc(Vector3)"/> functionality.
		/// Truncates the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Trunc_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-1, 2, 3);
			Vector3 actual = new Vector3(-1.4f, 2.9f, 3);
			
			Vector3.Trunc(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Sqrt(Vector3)"/> functionality.
		/// Square roots the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Sqrt_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 1.41421356237f, 5.47722557505f);
			Vector3 actual = new Vector3(1, 2, 30);
			
			Vector3.Sqrt(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Round(Vector3)"/> functionality.
		/// Rounds the vector and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(1, 2.5, 49.9, 1, 3, 50)]
		[InlineData(1, 2.49, 50.0001, 1, 2, 50)]
		[InlineData(-2, -2.5, -2.6, -2, -3, -3)]
		[InlineData(0, -2.49, -2.1, 0, -2, -2)]
		public void Round_SingleVector_ReturnsVector3(
			float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = new Vector3(x, y, z);
			
			Vector3.Round(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Min(Vector3, Vector3)"/> functionality.
		/// Gets the minimum vector from the two vectors and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Min_TwoVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(0, -2, -80);
			Vector3 actual = new Vector3(1, 20, -80);
			Vector3 other = new Vector3(0, -2, 8);
			
			Vector3.Min(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Max(Vector3, Vector3)"/> functionality.
		/// Gets the maximum vector from the vectors and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Max_TwoVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 20, 8);
			Vector3 actual = new Vector3(1, 20, -80);
			Vector3 other = new Vector3(0, -2, 8);
			
			Vector3.Max(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.MinMax(Vector3, Vector3, out Vector3, out Vector3)"/> functionality.
		/// Rearranges the minimum and maximum vectors and checks to see if the minimum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_TwoVectors_ReturnsMinVector3() {
			// Variables
			Vector3 expected = new Vector3(0, -2, -80);
			Vector3 actual = new Vector3(1, 20, -80);
			Vector3 other = new Vector3(0, -2, 8);
			
			Vector3.MinMax(ref actual, ref other, out actual, out other);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.MinMax(Vector3, Vector3, out Vector3, out Vector3)"/> functionality.
		/// Rearranges the minimum and maximum vectors and checks to see if the maximum vector is correct
		/// </summary>
		[Fact]
		public void MinMax_TwoVectors_ReturnsMaxVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 20, 8);
			Vector3 actual = new Vector3(1, 20, -80);
			Vector3 other = new Vector3(0, -2, 8);
			
			Vector3.MinMax(ref actual, ref other, out other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Ceiling(Vector3)"/> functionality.
		/// Gets the ceiling vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Ceiling_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-1, 4, 5);
			Vector3 actual = new Vector3(-1.9f, 4.0f, 4.9f);
			
			Vector3.Ceiling(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Floor(Vector3)"/> functionality.
		/// Gets the floor vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Floor_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-2, 4, 4);
			Vector3 actual = new Vector3(-1.9f, 4.0f, 4.9f);
			
			Vector3.Floor(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Fraction(Vector3)"/> functionality.
		/// Gets the fraction vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Fraction_SingleVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(0.1f, 0, 0.9f);
			Vector3 actual = new Vector3(-1.9f, 4.0f, 4.9f);
			Vector3 margin = 0.0000001f * Vector3.One;
			
			Vector3.Fraction(ref actual, out actual);
			
			Assert.InRange(actual, expected - margin, expected + margin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Clamp(Vector3, Vector3, Vector3)"/> functionality.
		/// Clamps the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Clamp_ThreeVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-1, 1, 3);
			Vector3 actual = new Vector3(-2, 2, 3);
			Vector3 min = new Vector3(-1, 0, 1);
			Vector3 max = new Vector3(0, 1, 10);
			
			Vector3.Clamp(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Repeat(Vector3, Vector3, Vector3)"/> functionality.
		/// Repeats the vector's components and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Repeat_ThreeVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-1, 0.3f, 11);
			Vector3 actual = new Vector3(17, 5.1f, 5);
			Vector3 min = new Vector3(-1, 0.2f, 10);
			Vector3 max = new Vector3(1, 0.4f, 12);
			
			Vector3.Repeat(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Lerp(Vector3, Vector3, float)"/> functionality.
		/// Lerps the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Lerp_ThreeVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(-0.3f, 0.27f, 10.7f);
			Vector3 actual = new Vector3(-1, 0.2f, 10);
			Vector3 other = new Vector3(1, 0.4f, 12);
			float time = 0.35f;
			
			Vector3.Lerp(ref actual, ref other, time, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.MapRange(Vector3, Vector3, Vector3, Vector3, Vector3)"/> functionality.
		/// Maps the vector to a range and checks if it's correct
		/// </summary>
		[Fact]
		public void MapRange_FiveVectors_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(0, -5, 6.470588f);
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 minBase = new Vector3(-1, 3, 1.5f);
			Vector3 maxBase = new Vector3(1, 5, 10);
			Vector3 minMapped = new Vector3(-10, 0, 10);
			Vector3 maxMapped = new Vector3(0, 10, -10);
			
			Vector3.MapRange(ref actual, ref minBase, ref maxBase, ref minMapped, ref maxMapped, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Vector3.Smoothstep(Vector3, Vector3, Vector3)"/> functionality.
		/// Smooths steps the vector and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Smoothstep_ThreeVector_ReturnsVector3() {
			// Variables
			Vector3 expected = new Vector3(1, 0.104f, 0.97199994f);
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 min = new Vector3(-1, 0, 1.2f);
			Vector3 max = new Vector3(1, 10, 3.2f);
			
			Vector3.Smoothstep(ref actual, ref min, ref max, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

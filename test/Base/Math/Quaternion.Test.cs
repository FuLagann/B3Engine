
using Xunit;

namespace B3.Testing {
	// TRACK: 707 tests
	/// <summary>Tests the <see cref="B3.Quaternion"/> structure to make sure it's correct. Contains 98 tests</summary>
	public class QuaternionTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Quaternion.Identity"/> functionality.
		/// Checks to see if the identity quaternion is correct
		/// </summary>
		[Fact]
		public void Identity_Returns1000() {
			// Variables
			Quaternion quaternion = Quaternion.Identity;
			(float, float, float, float) expected = (1, 0, 0, 0);
			(float, float, float, float) actual = (
				quaternion.a,
				quaternion.b,
				quaternion.c,
				quaternion.d
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Quaternion.Quaternion(float, float, float, float)"/> functionality.
		/// Checks to see if the quaternion get constructed correctly
		/// </summary>
		[Fact]
		public void Constructor_Returns1234() {
			// Variables
			Quaternion quaternion = new Quaternion(1, 2, 3, 4);
			(float, float, float, float) expected = (1, 2, 3, 4);
			(float, float, float, float) actual = (
				quaternion.a,
				quaternion.b,
				quaternion.c,
				quaternion.d
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 5.477225575051661)]
		public void Magnitude_ReturnsFloat(float a, float b, float c, float d, float expected) {
			// Variables
			Quaternion quaternion = new Quaternion(a, b, c, d);
			float actual = quaternion.Magnitude;
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 30)]
		public void MagnitudeSquared_ReturnsFloat(float a, float b, float c, float d, float expected) {
			// Variables
			Quaternion quaternion = new Quaternion(a, b, c, d);
			float actual = quaternion.MagnitudeSquared;
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region FromEulerAngles_RadianAngles_ReturnsQuaternion Test Data
		[InlineData(
			Mathx.PiOverTwo, Mathx.Pi / 4.0f, 0.0f,
			0.65328145f, 0.65328145f, 0.27059805f, -0.27059805f
		)]
		[InlineData(
			Mathx.PiOverTwo, 0.0f, 0.0f,
			0.70710678f, 0.70710678f, 0.0f, 0.0f
		)]
		[InlineData(
			0.0f, Mathx.PiOverTwo, 0.0f,
			0.70710678f, 0.0f, 0.70710678f, 0.0f
		)]
		[InlineData(
			0.0f, 0.0f, Mathx.PiOverTwo,
			0.70710678f, 0.0f, 0.0f, 0.70710678f
		)]
		[InlineData(
			1.0471975512f, Mathx.Pi / 4.0f, 0.5235987756f, // 60deg, 45deg, 30deg
			0.82236314, 0.5319757, 0.20056215, 0.02226001
		)]
		[InlineData(
			0.24434609528f, 0.2617993878, 3.8746309394f, // 14deg, 15deg, 222deg
			-0.33780313f, 0.07764797f, -0.15922922f, 0.9243949f
		)]
		[InlineData(
			Mathx.PiOverTwo, 1.5358897418f, 3.7873644768, // 90deg, 88deg, 217deg
			0.3044173f, 0.3044173f, -0.6382241f, 0.6382241f
		)]
		#endregion // FromEulerAngles_RadianAngles_ReturnsQuaternion Test Data
		public void FromEulerAngles_RadianAngles_ReturnsQuaternion(float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = Quaternion.FromEulerAngles(x, y, z);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region FromEulerAnglesDeg_DegreeAngles_ReturnsQuaternion Test Data
		[InlineData(
			90.0f, 45.0f, 0.0f,
			0.65328145f, 0.65328145f, 0.27059805f, -0.27059805f
		)]
		[InlineData(
			90.0f, 0.0f, 0.0f,
			0.70710678f, 0.70710678f, 0.0f, 0.0f
		)]
		[InlineData(
			0.0f, 90.0f, 0.0f,
			0.70710678f, 0.0f, 0.70710678f, 0.0f
		)]
		[InlineData(
			0.0f, 0.0f, 90.0f,
			0.70710678f, 0.0f, 0.0f, 0.70710678f
		)]
		[InlineData(
			60.0f, 45.0f, 30.0f,
			0.82236314, 0.5319757, 0.20056215, 0.02226001
		)]
		[InlineData(
			14.0f, 15.0f, 222.0f,
			-0.33780313f, 0.07764797f, -0.15922922f, 0.9243949f
		)]
		[InlineData(
			90.0f, 88.0f, 217.0f,
			0.3044173f, 0.3044173f, -0.6382241f, 0.6382241f
		)]
		#endregion // FromEulerAnglesDeg_DegreeAngles_ReturnsQuaternion Test Data
		public void FromEulerAnglesDeg_DegreeAngles_ReturnsQuaternion(float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = Quaternion.FromEulerAnglesDeg(x, y, z);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0.70710678f, 0.70710678f, 0.0f, 0.0f)]
		[InlineData(0, 1, 0, 0.70710678f, 0.0f, 0.70710678f, 0.0f)]
		[InlineData(0, 0, 1, 0.70710678f, 0.0f, 0.0f, 0.70710678f)]
		[InlineData(1, 2, 3, 0.70710678f, 0.18898223f, 0.37796447f, 0.5669467f)]
		public void FromAxisAngle_RadianAnglePiOverTwo_ReturnsQuaternion(float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Vector3 axis = new Vector3(x, y, z);
			float angle = Mathx.PiOverTwo;
			Quaternion actual = Quaternion.FromAxisAngle(axis, angle);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0.70710678f, 0.70710678f, 0.0f, 0.0f)]
		[InlineData(0, 1, 0, 0.70710678f, 0.0f, 0.70710678f, 0.0f)]
		[InlineData(0, 0, 1, 0.70710678f, 0.0f, 0.0f, 0.70710678f)]
		[InlineData(1, 2, 3, 0.70710678f, 0.18898223f, 0.37796447f, 0.5669467f)]
		public void FromAxisAngleDeg_DegreeAngle90Degrees_ReturnsQuaternion(float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Vector3 axis = new Vector3(x, y, z);
			float angle = 90.0f;
			Quaternion actual = Quaternion.FromAxisAngleDeg(axis, angle);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 1, -2, -3, -4)]
		[InlineData(1, -2, 3, -4, 1, 2, -3, 4)]
		[InlineData(1, -2, -3, -4, 1, 2, 3, 4)]
		public void Conjugate_SingleQuaternion_ReturnsQuaternion(float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Conjugate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 1, -2, -3, -4, 2, 0, 0, 0)]
		[InlineData(1, 2, 3, 4, 5, 6, 7, 8, 6, 8, 10, 12)]
		public void Add_TwoQuaternions_ReturnsQuaternion(float a, float b, float c, float d, float w, float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			Quaternion other = new Quaternion(w, x, y, z);
			
			Quaternion.Add(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 1, -2, -3, -4, 0, 4, 6, 8)]
		[InlineData(1, 2, 3, 4, 5, 6, 7, 8, -4, -4, -4, -4)]
		[InlineData(1, 2, 3, 4, 1, 2, 3, 4, 0, 0, 0, 0)]
		public void Subtract_TwoQuaternions_ReturnsQuaternion(float a, float b, float c, float d, float w, float x, float y, float z, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			Quaternion other = new Quaternion(w, x, y, z);
			
			Quaternion.Subtract(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, -2, -3, -4, -1, 2, 3, 4)]
		[InlineData(5, 6, 7, 8, -5, -6, -7, -8)]
		[InlineData(1, 2, 3, 4, -1, -2, -3, -4)]
		public void Negate_SingleQuaternion_ReturnsQuaternion(float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Negate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(3, 1, -2, -3, -4, 3, -6, -9, -12)]
		[InlineData(2, 5, 6, 7, 8, 10, 12, 14, 16)]
		[InlineData(4, 1, 2, 3, 4, 4, 8, 12, 16)]
		public void Multiply_Scalar_ReturnsQuaternion(float scalar, float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Multiply(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(3, 1, -2, -3, -4, 1/3f, -2/3f, -1, -4/3f)]
		[InlineData(2, 5, 6, 7, 8, 5/2f, 3, 7/2f, 4)]
		[InlineData(4, 1, 2, 3, 4, 1/4f, 1/2f, 3/4f, 1f)]
		public void Divide_Scalar_ReturnsQuaternion(float scalar, float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Divide(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 5, 6, 7, 8, -60, 12, 30, 24)]
		[InlineData(5, 6, 7, 8, 1, 2, 3, 4, -60, 20, 14, 32)]
		[InlineData(1, 2, 3, 4, 1, -2, -3, -4, 30, 0, 0, 0)]
		public void Multiply_TwoQuaternions_ReturnsQuaternion(float aa, float ab, float ac, float ad, float ba, float bb, float bc, float bd, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(aa, ab, ac, ad);
			Quaternion other = new Quaternion(ba, bb, bc, bd);
			
			Quaternion.Multiply(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 5, 6, 7, 8, 0.4022988505747126f, 0.0459770114942529f, 0f, 0.0919540229885057f)]
		[InlineData(5, 6, 7, 8, 1, 2, 3, 4, 2.333333333333333f, -0.2666666666666667f, 0f, -0.5333333333333333f)]
		[InlineData(1, 2, 3, 4, 1, -2, -3, -4, -0.9333333333333333f, 0.1333333333333333, 0.2f, 0.2666666666666667f)]
		public void Divide_TwoQuaternion_ReturnsQuaternion(float aa, float ab, float ac, float ad, float ba, float bb, float bc, float bd, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(aa, ab, ac, ad);
			Quaternion other = new Quaternion(ba, bb, bc, bd);
			
			Quaternion.Divide(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region ToMatrix_EulerAngleInDegrees_ReturnsMatrix Test Data
		[InlineData(
			60.0f, 0, 0,
			1, 0, 0, 0,
			0, 0.5, -0.8660254, 0,
			0, 0.8660254, 0.5, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 45.0f, 0,
			0.7071067, 0, 0.7071068, 0,
			0, 1, 0, 0,
			-0.7071068, 0, 0.7071067, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 30.0f,
			0.8660254, -0.5, 0, 0,
			0.5, 0.8660254, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			60.0f, 45.0f, 30.0f,
			0.91855866, 0.17677674, 0.3535534, 0,
			0.25, 0.4330127, -0.8660254, 0,
			-0.30618626, 0.8838834, 0.35355335, 0,
			0, 0, 0, 1
		)]
		#endregion // ToMatrix_EulerAngleInDegrees_ReturnsMatrix Test Data
		public void ToMatrix_EulerAngleInDegrees_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Quaternion quaternion = Quaternion.FromEulerAnglesDeg(x, y, z);
			Matrix actual = Quaternion.ToMatrix(quaternion);
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0, 1, 0, 0, 0)]
		[InlineData(0, 0, 1, 0, 0, 0, -1, 0)]
		[InlineData(1, 0, 0, 1, 0.5f, 0, 0, -0.5f)]
		[InlineData(1, -2, 3, -4, 0.033333335, 0.06666667, -0.1, 0.13333334)]
		public void Invert_SingleQuaternion_ReturnsQuaternion(float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Invert(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 0, 1, 0, 0, 0)]
		[InlineData(0, 0, 1, 0, 0, 0, 1, 0)]
		[InlineData(1, 0, 0, 1, 0.70710677, 0, 0, 0.70710677)]
		[InlineData(1, 2, 3, 4, 0.18257418, 0.36514837, 0.5477225, 0.73029673)]
		public void Normalize_SingleQuaternion_ReturnsQuaternion(float a, float b, float c, float d, float ea, float eb, float ec, float ed) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			
			Quaternion.Normalize(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Slerp_TwoQuaternions_ReturnsQuaternion Test Data
		[InlineData(
			1, 0, 0, 0,
			0.9659258, 0.258819, 0, 0,
			0, 1, 0, 0, 0
		)]
		[InlineData(
			1, 0, 0, 0,
			0.9659258, 0.258819, 0, 0,
			0.5, 0.9914449, 0.13052611, 0, 0
		)]
		[InlineData(
			1, 0, 0, 0,
			0.9659258, 0.258819, 0, 0,
			1, 0.9659259, 0.25881886, 0, 0
		)]
		[InlineData(
			0.8660254, 0, 0.5, 0,
			0.4158418, 0.1114245, -0.2336062, 0.8718304,
			0.5, 0.81289685, 0.07065991, 0.1689338, 0.55287176
		)]
		[InlineData(
			-0.3181352, 0.1210909, 0.7457347, -0.5727189,
			0.4751292, 0.5046578, -0.6902984, 0.207511,
			0.1552, -0.35776657, 0.019029543, 0.7662716, -0.5333562
		)]
		#endregion // Slerp_TwoQuaternions_ReturnsQuaternion Test Data
		public void Slerp_TwoQuaternions_ReturnsQuaternion(
			float a, float b, float c, float d,
			float w, float x, float y, float z,
			float t, float ea, float eb, float ec, float ed
		) {
			// Variables
			Quaternion expected = new Quaternion(ea, eb, ec, ed);
			Quaternion actual = new Quaternion(a, b, c, d);
			Quaternion other = new Quaternion(w, x, y, z);
			
			Mathx.Slerp(ref actual, ref other, t, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(1, 0, 0, 30.0f)]
		[InlineData(0, 1, 0, 60.0f)]
		[InlineData(0, 0, 1, 129.0f)]
		[InlineData(1, 2, 3, 77.0f)]
		public void ToMatrix_AxisAngleInDegrees_ReturnsMatrix(float x, float y, float z, float angle) {
			// Variables
			Vector3 axis = new Vector3(x, y, z);
			Quaternion quaternion = Quaternion.FromAxisAngleDeg(axis, angle);
			Matrix expected = Matrix.CreateRotationFromAxisAngleDeg(axis, angle);
			Matrix actual = Quaternion.ToMatrix(quaternion);
			
			Assert.True(Matrix.Approx(expected, actual));
		}
		
		[Theory]
		[InlineData(1, 0, 0, 30.0f)]
		[InlineData(0, 1, 0, 60.0f)]
		[InlineData(0, 0, 1, 129.0f)]
		[InlineData(1, 2, 3, 77.0f)]
		public void FromMatrix_AxisAngleInDegrees_ReturnsQuaternion(float x, float y, float z, float angle) {
			// Variables
			Vector3 axis = new Vector3(x, y, z);
			Quaternion expected = Quaternion.FromAxisAngleDeg(axis, angle);
			Matrix matrix = Matrix.CreateRotationFromAxisAngleDeg(axis, angle);
			Quaternion actual = Quaternion.FromMatrix(matrix);
			
			Assert.True(Quaternion.Approx(expected, actual));
		}
		
		[Fact]
		public void Approx_TwoQuaternions_ReturnsNotEqual() {
			// Variables
			Quaternion notExpected = new Quaternion(1, 2, 3, 4);
			Quaternion actual = new Quaternion(1.0000001f, 2, 3.0000001f, 4);
			
			Assert.NotEqual(notExpected, actual);
		}
		
		[Fact]
		public void Approx_TwoQuaternions_ReturnsTrue() {
			// Variables
			Quaternion a = new Quaternion(1, 2, 3, 4);
			Quaternion b = new Quaternion(1.0000001f, 2, 3.0000001f, 4);
			
			Assert.True(Quaternion.Approx(a, b));
		}
		
		[Theory]
		#region Multiply_Vector4AxisAngleDeg_ReturnsVector4 Test Data
		[InlineData(
			0, 0, 0, 0,
			0, 0, 0,
			0, 0, 0, 0
		)]
		[InlineData(
			1, 0, 1, -1,
			12, 24, 48,
			1.0719739, 0.5189936, 0.7625728, -1
		)]
		[InlineData(
			-1, -1, -1, -1,
			44, 90, 90,
			-1.4139981, -0.02468142, -1, -1
		)]
		[InlineData(
			100, 200, 300, 400,
			-90, 89, 77,
			-145.41391, 300, 169.86697, 399.99997
		)]
		[InlineData(
			20, -4, 0, 1,
			8, 48, 128,
			-4.2453156, 18.045515, 8.505091, 1
		)]
		#endregion // Multiply_Vector4AxisAngleDeg_ReturnsVector4 Test Data
		public void Multiply_Vector4AxisAngleDeg_ReturnsVector4(
			float x, float y, float z, float w,
			float yaw, float pitch, float roll,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Vector4 expected = new Vector4(ex, ey, ez, ew);
			Quaternion quaternion = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Vector4 actual = new Vector4(x, y, z, w);
			
			Quaternion.Multiply(ref quaternion, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Multiply_Vector3AxisAngleDeg_ReturnsVector3 Test Data
		[InlineData(
			0, 0, 0,
			0, 0, 0,
			0, 0, 0
		)]
		[InlineData(
			1, 0, 1,
			12, 24, 48,
			1.0719739, 0.5189936, 0.7625729
		)]
		[InlineData(
			-1, -1, -1,
			44, 90, 90,
			-1.4139981, -0.024681374, -1
		)]
		[InlineData(
			100, 200, 300,
			-90, 89, 77,
			-145.41394, 300, 169.86697
		)]
		[InlineData(
			20, -4, 0,
			8, 48, 128,
			-4.2453146, 18.045515, 8.505091
		)]
		#endregion // Multiply_Vector3AxisAngleDeg_ReturnsVector3 Test Data
		public void Multiply_Vector3AxisAngleDeg_ReturnsVector3(
			float x, float y, float z,
			float yaw, float pitch, float roll,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Quaternion quaternion = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Vector3 actual = new Vector3(x, y, z);
			
			Quaternion.Multiply(ref quaternion, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Multiply_Vector2AxisAngleDeg_ReturnsVector2 Test Data
		[InlineData(
			0, 0,
			0, 0, 0,
			0, 0
		)]
		[InlineData(
			1, 1,
			12, 24, 48,
			0.0518141, 1.3814139
		)]
		[InlineData(
			-1, -1,
			44, 90, 90,
			-0.6946584, -0.7193398
		)]
		[InlineData(
			100, 200,
			-90, 89, 77,
			-145.41394, 0
		)]
		[InlineData(
			20, -4,
			8, 48, 128,
			-4.2453146, 18.045515
		)]
		#endregion // Multiply_Vector2AxisAngleDeg_ReturnsVector2 Test Data
		public void Multiply_Vector2AxisAngleDeg_ReturnsVector2(
			float x, float y,
			float yaw, float pitch, float roll,
			float ex, float ey
		) {
			// Variables
			Vector2 expected = new Vector2(ex, ey);
			Quaternion quaternion = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Vector2 actual = new Vector2(x, y);
			
			Quaternion.Multiply(ref quaternion, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Dot_TwoQuaternions_ReturnsFloat Test Data
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8, 70
		)]
		[InlineData(
			1, 0, 0, 0,
			1, 0, 0, 0, 1
		)]
		[InlineData(
			1, 2, 3, 4,
			1, 2, 3, 4, 30
		)]
		#endregion // Dot_TwoQuaternions_ReturnsFloat Test Data
		public void Dot_TwoQuaternions_ReturnsFloat(
			float aa, float ab, float ac, float ad,
			float ba, float bb, float bc, float bd, float expected
		) {
			// Variables
			Quaternion first = new Quaternion(aa, ab, ac, ad);
			Quaternion second = new Quaternion(ba, bb, bc, bd);
			float actual = first.Dot(second);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

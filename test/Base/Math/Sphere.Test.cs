
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Sphere"/> structure to make sure it works correctly. Contains 28 tests.</summary>
	public class SphereTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.Empty"/> functionality.
		/// Checks to see if the empty sphere is formed correctly
		/// </summary>
		[Fact]
		public void Empty_ReturnsSphere() {
			// Variables
			Sphere sphere = Sphere.Empty;
			(float, float, float, float) expected = (0.0f, 0.0f, 0.0f, 0.0f);
			(float, float, float, float) actual = (
				sphere.X,
				sphere.Y,
				sphere.Z,
				sphere.radius
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.Unit"/> functionality.
		/// Checks to see if the unit sphere is formed correctly
		/// </summary>
		[Fact]
		public void Unit_ReturnsSphere() {
			// Variables
			Sphere sphere = Sphere.Unit;
			(float, float, float, float) expected = (0.0f, 0.0f, 0.0f, 1.0f);
			(float, float, float, float) actual = (
				sphere.X,
				sphere.Y,
				sphere.Z,
				sphere.radius
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.Encompass(Sphere)"/> functionality.
		/// Creates a sphere that encompasses two spheres and checks if its correct
		/// </summary>
		[Theory]
		#region Encompass_TwoSpheres_ReturnsSphere Test Data
		[InlineData(
			4, 0, 1, 5,
			5, 0, -1, 5,
			4.5, 0, 0, 6.118034
		)]
		[InlineData(
			4, 0, 1, -10,
			0, 0, 0, 5,
			4, 0, 1, -10
		)]
		[InlineData(
			4, 0, 1, -4,
			0, 6, 7, 5,
			1.7867992, 3.3198013, 4.3198013, 9.190416
		)]
		[InlineData(
			4, 0, 0, 10,
			4, 6, 7, 5,
			4, 1.3730216, 1.6018586, 12.109773
		)]
		#endregion // Encompass_TwoSpheres_ReturnsSphere Test Data
		public void Encompass_TwoSpheres_ReturnsSphere(
			float ax, float ay, float az, float ar,
			float bx, float by, float bz, float br,
			float ex, float ey, float ez, float er
		) {
			// Variables
			Sphere actual = new Sphere(ax, ay, az, ar);
			Sphere other = new Sphere(bx, by, bz, br);
			Sphere expected = new Sphere(ex, ey, ez, er);
			
			Sphere.Encompass(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.EncompassRange(Sphere[])"/> functionality.
		/// Creates a sphere that encompasses multiple spheres and checks if its correct
		/// </summary>
		[Theory]
		#region EncompassRange_MultipleSpheres_ReturnsSphere Test Data
		[InlineData(
			4, 0, 0, 10,
			4, 6, 7, 5,
			1, 0, 0, 10,
			3.362874, 1.0814257, 1.2616634, 12.888676
		)]
		[InlineData(
			1, 2, 3, 4,
			0, 0, 0, 1,
			1, 1, 1, 1,
			0.9008919, 1.8017838, 2.7026756, 4.3708286
		)]
		[InlineData(
			1, 2, 3, 5,
			0, 0, 0, 1,
			1, 1, 1, 1,
			1, 2, 3, 5
		)]
		[InlineData(
			1, -3, 3, -3,
			-2, 0, 0, 3,
			1, 1, 1, 5,
			0.09836006, -0.5027337, 1.3005466, 6.7780576
		)]
		#endregion // EncompassRange_MultipleSpheres_ReturnsSphere Test Data
		public void EncompassRange_MultipleSpheres_ReturnsSphere(
			float ax, float ay, float az, float ar,
			float bx, float by, float bz, float br,
			float cx, float cy, float cz, float cr,
			float ex, float ey, float ez, float er
		) {
			// Variables
			Sphere actual = new Sphere(ax, ay, az, ar);
			Sphere other = new Sphere(bx, by, bz, br);
			Sphere another = new Sphere(cx, cy, cz, cr);
			Sphere expected = new Sphere(ex, ey, ez, er);
			
			Sphere.EncompassRange(out actual, actual, other, another);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.IsOverlapping(Sphere)"/> functionality.
		/// Checks to see if the two spheres are overlapping
		/// </summary>
		[Theory]
		#region IsOverlapping_TwoSpheres_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 0, 3,
			0, -3, 0, 1, true
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -4, 0, -3, true
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -5, 0, -1, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, 0, 0, 2, true
		)]
		[InlineData(
			0, 0, 0, 2,
			0, 0, 0, 3, true
		)]
		[InlineData(
			1, 2, 3, 4,
			-1, -1, -1, -1, false
		)]
		#endregion // IsOverlapping_TwoSpheres_ReturnsBoolean Test Data
		public void IsOverlapping_TwoSpheres_ReturnsBoolean(
			float ax, float ay, float az, float ar,
			float bx, float by, float bz, float br,
			bool expected
		) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			bool actual = a.IsOverlapping(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.IsDisjoint(Sphere)"/> functionality.
		/// Checks to see if the two spheres are disjoint
		/// </summary>
		[Theory]
		#region IsDisjoint_TwoSpheres_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 0, 3,
			0, -3, 0, 1, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -4, 0, -3, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -5, 0, -1, true
		)]
		[InlineData(
			0, 0, 0, 3,
			0, 0, 0, 2, false
		)]
		[InlineData(
			0, 0, 0, 2,
			0, 0, 0, 3, false
		)]
		[InlineData(
			1, 2, 3, 4,
			-1, -1, -1, -1, true
		)]
		#endregion // IsDisjoint_TwoSpheres_ReturnsBoolean Test Data
		public void IsDisjoint_TwoSpheres_ReturnsBoolean(
			float ax, float ay, float az, float ar,
			float bx, float by, float bz, float br,
			bool expected
		) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			bool actual = a.IsDisjoint(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Sphere.IsContained(Sphere)"/> functionality.
		/// Checks to see if one sphere is contained within the other sphere
		/// </summary>
		[Theory]
		#region IsContained_TwoSpheres_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 0, 3,
			0, -3, 0, 1, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -4, 0, -3, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, -5, 0, -1, false
		)]
		[InlineData(
			0, 0, 0, 3,
			0, 0, 0, 2, true
		)]
		[InlineData(
			0, 0, 0, 2,
			0, 0, 0, 3, false
		)]
		[InlineData(
			1, 2, 3, 4,
			-1, -1, -1, -1, false
		)]
		#endregion // IsContained_TwoSpheres_ReturnsBoolean Test Data
		public void IsContained_TwoSpheres_ReturnsBoolean(
			float ax, float ay, float az, float ar,
			float bx, float by, float bz, float br,
			bool expected
		) {
			// Variables
			Sphere a = new Sphere(ax, ay, az, ar);
			Sphere b = new Sphere(bx, by, bz, br);
			bool actual = a.IsContained(b);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

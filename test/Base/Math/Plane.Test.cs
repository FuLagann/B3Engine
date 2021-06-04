
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Plane"/> structure to make sure it works correctly. Contains 12 tests</summary>
	public class PlaneTest {
		#region Public Test Method
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.Normal"/> functionality.
		/// Creates a plane and checks to see if the normal is being constructed correctly
		/// </summary>
		[Fact]
		public void Constructor_Normal_ReturnsUnitVector3() {
			// Variables
			Plane plane = new Plane(Vector3.One, 1.0f);
			Vector3 expected = Vector3.UnitOne;
			
			Assert.Equal(expected, plane.Normal);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.Distance"/> functionality.
		/// Creates a plane and checks to see if the distance is being constructed correctly
		/// </summary>
		[Fact]
		public void Constructor_Distance_ReturnsFloat() {
			// Variables
			Plane plane = new Plane(Vector3.One, 1.0f);
			
			Assert.Equal(1.0f, plane.Distance);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.XYPlane"/> functionality.
		/// Checks to see if the readonly object has the correct normal
		/// </summary>
		[Fact]
		public void XYPlane_Normal_ReturnsUnitVector3() {
			// Variables
			Plane plane = Plane.XYPlane;
			
			Assert.Equal(Vector3.UnitZ, plane.Normal);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.XYPlane"/> functionality.
		/// Checks to see if the readonly object has the correct distance
		/// </summary>
		[Fact]
		public void XYPlane_Distance_ReturnsFloat() {
			// Variables
			Plane plane = Plane.XYPlane;
			
			Assert.Equal(0.0f, plane.Distance);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.XZPlane"/> functionality.
		/// Checks to see if the readonly object has the correct normal
		/// </summary>
		[Fact]
		public void XZPlane_Normal_ReturnsUnitVector3() {
			// Variables
			Plane plane = Plane.XZPlane;
			
			Assert.Equal(Vector3.UnitY, plane.Normal);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.XZPlane"/> functionality.
		/// Checks to see if the readonly object has the correct distance
		/// </summary>
		[Fact]
		public void XZPlane_Distance_ReturnsFloat() {
			// Variables
			Plane plane = Plane.XZPlane;
			
			Assert.Equal(0.0f, plane.Distance);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.YZPlane"/> functionality.
		/// Checks to see if the readonly object has the correct normal
		/// </summary>
		[Fact]
		public void YZPlane_Normal_ReturnsUnitVector3() {
			// Variables
			Plane plane = Plane.YZPlane;
			
			Assert.Equal(Vector3.UnitX, plane.Normal);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.YZPlane"/> functionality.
		/// Checks to see if the readonly object has the correct distance
		/// </summary>
		[Fact]
		public void YZPlane_Distance_ReturnsFloat() {
			// Variables
			Plane plane = Plane.YZPlane;
			
			Assert.Equal(0.0f, plane.Distance);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Plane.CreateFromThreePoints(ref Vector3, ref Vector3, ref Vector3)"/> functionality.
		/// Checks to see if the method creates a plane accurately
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0)]
		[InlineData(1, 0, 1, -1, 0, 0, 2, 0, 2, 0, 1, 0, 0)]
		[InlineData(0, 10, 1, 0, 20, 20, 0, -50, -100, 1, 0, 0, 0)]
		[InlineData(1, 0, 0, 0, 1, 0, 0, 0, 1, 0.57735026, 0.57735026, 0.57735026, -0.57735026)]
		public void CreateFromThreePoints_ThreeVectors_ReturnsApproximatePlane(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float ex, float ey, float ez, float ed) {
			// Variables
			Vector3 a = new Vector3(x0, y0, z0);
			Vector3 b = new Vector3(x1, y1, z1);
			Vector3 c = new Vector3(x2, y2, z2);
			Plane expected = new Plane(new Vector3(ex, ey, ez), ed);
			Plane actual = Plane.CreateFromThreePoints(ref a, ref b, ref c);
			bool approxNormal = Vector3.Approx(expected.Normal, actual.Normal);
			bool approxDistance = Mathx.Approx(expected.Distance, actual.Distance);
			
			Assert.True(approxNormal && approxDistance);
		}
		
		#endregion // Public Test Method
	}
}

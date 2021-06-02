
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Ray"/> structure to make sure it works correctly. Contains 7 tests</summary>
	public class RayTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Ray.Direction"/> functionality.
		/// Creates a ray and checks to see if the direction is correct (normalized)
		/// </summary>
		[Fact]
		public void Constructor_Direction_ReturnsNormalizedVector3() {
			// Variables
			Ray ray = new Ray(Vector3.One, Vector3.One);
			Vector3 expected = Vector3.UnitOne;
			
			Assert.Equal(expected, ray.Direction);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Ray.Origin"/> functionality.
		/// Creates a ray and checks to see if the origin is correct (not normalized)
		/// </summary>
		[Fact]
		public void Constructor_Origin_ReturnsVector3() {
			// Variables
			Ray ray = new Ray(Vector3.One, Vector3.One);
			Vector3 expected = Vector3.One;
			
			Assert.Equal(expected, ray.Origin);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Ray.GetPoint(float, Ray)"/> functionality.
		/// Using a ray and a distance, gets a point along the ray and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(2, 0, 0, 0, 1, 0, 0, 2, 0, 0)]
		[InlineData(0.57735026919f, 0, 0, 0, 1, 1, 1, 0.3333333, 0.3333333, 0.3333333)]
		[InlineData(-5, 0, 0, 0, 0, 1, 0, 0, -5, 0)]
		public void GetPoint_Distance_ReturnsVector3(
			float distance, float x, float y, float z,
			float dx, float dy, float dz,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 origin = new Vector3(x, y, z);
			Vector3 direction = new Vector3(dx, dy, dz);
			Ray ray = new Ray(origin, direction);
			Vector3 expected = new Vector3(ex, ey, ez);
			Vector3 actual = Ray.GetPoint(distance, ref ray);
			// TODO: Add ray.GetPoint(distance) method
			// TODO: Add distance * ray operator
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Ray.Direction"/> functionality.
		/// Using a ray and a point, gets the closest point along the ray from the given point and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(1, 0, 0, 0, 0, 0, 1, 1, 0, 0.5, 0.5, 0)]
		[InlineData(0, 0, 0, 1, 1, 1, 1, -1, 1, 0.6666666, 1.3333334, 0.6666666)]
		public void GetPointFromPoint(
			float ax, float ay, float az,
			float x, float y, float z,
			float dx, float dy, float dz,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 origin = new Vector3(x, y, z);
			Vector3 direction = new Vector3(dx, dy, dz);
			Ray ray = new Ray(origin, direction);
			Vector3 actual = new Vector3(ax, ay, az);
			Vector3 expected = new Vector3(ex, ey, ez);
			// TODO: Add ray.GetPointFromPoint(point) method
			// TODO: Add point ~ ray method, if possible
			
			Ray.GetPointFromPoint(ref actual, ref ray, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}


using Xunit;

namespace B3.Testing {
	public class RayTest {
		// [Fact]
		// public void Constructors() {
		// 	Assert.Equal(new Ray(Vector3.Zero, Vector3.Zero), Ray.Empty);
		// 	Assert.Equal(new Ray(Vector3.Zero, Vector3.UnitX), Ray.UnitXDir);
		// 	Assert.Equal(new Ray(Vector3.Zero, Vector3.UnitY), Ray.UnitYDir);
		// 	Assert.Equal(new Ray(Vector3.Zero, Vector3.UnitZ), Ray.UnitZDir);
		// }
		
		// [Theory]
		// [InlineData(2, 0, 0, 0, 1, 0, 0, 2, 0, 0)]
		// [InlineData(0.57735026919f, 0, 0, 0, 1, 1, 1, 0.3333333, 0.3333333, 0.3333333)]
		// [InlineData(-5, 0, 0, 0, 0, 1, 0, 0, -5, 0)]
		// public void GetPoint(float dist, float x, float y, float z, float dx, float dy, float dz, float ex, float ey, float ez) {
		// 	// Variables
		// 	Ray ray = new Ray(new Vector3(x, y, z), new Vector3(dx, dy, dz));
		// 	Vector3 e = new Vector3(ex, ey, ez);
			
		// 	Assert.Equal(e, Ray.GetPoint(dist, ref ray));
		// }
		
		// [Theory]
		// [InlineData(1, 0, 0, 0, 0, 0, 1, 1, 0, 0.5, 0.5, 0)]
		// [InlineData(0, 0, 0, 1, 1, 1, 1, -1, 1, 0.6666666, 1.3333334, 0.6666666)]
		// public void GetPointFromPoint(
		// 	float ax, float ay, float az,
		// 	float x, float y, float z,
		// 	float dx, float dy, float dz,
		// 	float ex, float ey, float ez
		// ) {
		// 	// Variables
		// 	Vector3 a = new Vector3(ax, ay, az);
		// 	Vector3 e = new Vector3(ex, ey, ez);
		// 	Ray ray = new Ray(new Vector3(x, y, z), new Vector3(dx, dy, dz));
			
		// 	Assert.Equal(e, Ray.GetPointFromPoint(ref a, ref ray));
		// }
	}
}


using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class TransformTest {
		// Variables
		private ITestOutputHelper output;
		
		public TransformTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			// Variables
			Transform t = new Transform();
			
			Assert.Equal(Matrix.Identity, t.World);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 3, 0, 0, 0, 1)]
		[InlineData(1, -1, 1, 1, 0, 0, 1, 0, 1, 0, -1, 0, 0, 1, 1, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		public void Position(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 pos = new Vector3(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Position = pos;
			
			Assert.Equal(e, transform.World);
		}
		
		[Theory]
		[InlineData(60*Mathx.DegToRad, 0, 0, 1, 0, 0, 0, 0, 0.5, -0.8660254, 0, 0, 0.8660254, 0.5, 0, 0, 0, 0, 1)]
		[InlineData(0, 45*Mathx.DegToRad, 0, 0.7071068, 0, 0.7071068, 0, 0, 1, 0, 0, -0.7071068, 0, 0.7071068, 0, 0, 0, 0, 1)]
		[InlineData(0, 0, 30*Mathx.DegToRad, 0.8660253, -0.5, 0, 0, 0.5, 0.8660253, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(60*Mathx.DegToRad, 45*Mathx.DegToRad, 30*Mathx.DegToRad, 0.9185587, 0.1767766, 0.3535534, 0, 0.25, 0.4330125, -0.8660255, 0, -0.3061861, 0.8838837, 0.3535533, 0, 0, 0, 0, 1)]
		[InlineData(140*Mathx.DegToRad, -380*Mathx.DegToRad, 20*Mathx.DegToRad, 0.8078303, -0.5279818, 0.2620027, 0, -0.2620026, -0.7198464, -0.6427877, 0, 0.5279819, 0.450618, -0.7198464, 0, 0, 0, 0, 1)]
		public void Rotation(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Quaternion rot = new Quaternion(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 45*Mathx.DegToRad, 60*Mathx.DegToRad, 0, 0.5, 0.6123725, 0.6123725, 1, 0, 0.7071068, -0.7071068, 2, -0.8660254, 0.3535534, 0.3535534, 3, 0, 0, 0, 1)]
		[InlineData(-1, 0, 1, 90*Mathx.DegToRad, 88*Mathx.DegToRad, 217*Mathx.DegToRad, -0.6293204, -0.777146, 0, -1, 0, 0, -1, 0, 0.777146, -0.6293204, 0, 1, 0, 0, 0, 1)]
		public void Position_Rotation(float x, float y, float z, float yaw, float pitch, float roll, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 pos = new Vector3(x, y, z);
			Quaternion rot = new Quaternion(yaw, pitch, roll);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Position = pos;
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)]
		[InlineData(-1, 0, 1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		public void Scale(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 scale = new Vector3(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Scale = scale;
			
			Assert.Equal(e, transform.World);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 1, 2, 3, 1, 0, 0, 1, 0, 2, 0, 2, 0, 0, 3, 3, 0, 0, 0, 1)]
		[InlineData(1, -1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, -1, 0, 0, 0, 1, 0, 0, 0, 1)]
		[InlineData(0, 1, -1, -1, 0, 1, -1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, -1, 0, 0, 0, 1)]
		public void Position_Scale(float x, float y, float z, float sx, float sy, float sz, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 pos = new Vector3(x, y, z);
			Vector3 scale = new Vector3(sx, sy, sz);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Position = pos;
			transform.Scale = scale;
			
			Assert.Equal(e, transform.World);
		}
		
		[Theory]
		[InlineData(1, 2, 3, 45*Mathx.DegToRad, 60*Mathx.DegToRad, 0, 0.5, 1.224745, 1.837118, 0, 0, 1.414214, -2.12132, 0, -0.8660254, 0.7071068, 1.06066, 0, 0, 0, 0, 1)]
		[InlineData(-1, 0, 1, 90*Mathx.DegToRad, 88*Mathx.DegToRad, 217*Mathx.DegToRad, 0.6293204, 0, 0, 0, 0, 0, -1, 0, -0.777146, 0, 0, 0, 0, 0, 0, 1)]
		[InlineData(4, 6, 8, 100*Mathx.DegToRad, 200*Mathx.DegToRad, 300*Mathx.DegToRad, -0.7125931, -5.893259, 0.4751284, 0, 0.6015347, -0.5209444, -7.878463, 0, 3.889778, -0.9990621, 1.305406, 0, 0, 0, 0, 1)]
		public void Rotation_Scale(float x, float y, float z, float yaw, float pitch, float roll, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 scale = new Vector3(x, y, z);
			Quaternion rot = new Quaternion(yaw, pitch, roll);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Scale = scale;
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.00001f));
		}
		
		[Theory]
		[InlineData(1, 1, 1, 1, 2, 3, 45*Mathx.DegToRad, 60*Mathx.DegToRad, 0, 0.5, 1.224745, 1.837118, 1, 0, 1.414214, -2.12132, 1, -0.8660254, 0.7071068, 1.06066, 1, 0, 0, 0, 1)]
		[InlineData(4, 4, 0, -1, 0, 1, 90*Mathx.DegToRad, 88*Mathx.DegToRad, 217*Mathx.DegToRad, 0.6293204, 0, 0, 4, 0, 0, -1, 4, -0.777146, 0, 0, 0, 0, 0, 0, 1)]
		[InlineData(4, 8, 16, 4, 6, 8, 100*Mathx.DegToRad, 200*Mathx.DegToRad, 300*Mathx.DegToRad, -0.7125931, -5.893259, 0.4751284, 4, 0.6015347, -0.5209444, -7.878463, 8, 3.889778, -0.9990621, 1.305406, 16, 0, 0, 0, 1)]
		public void Position_Rotation_Scale(float x, float y, float z, float sx, float sy, float sz, float yaw, float pitch, float roll, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 pos = new Vector3(x, y, z);
			Vector3 scale = new Vector3(sx, sy, sz);
			Quaternion rot = new Quaternion(yaw, pitch, roll);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Position = pos;
			transform.Scale = scale;
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 1)]
		[InlineData(30*Mathx.DegToRad, 0, 0, 0, -0.5, 0.8660253)]
		[InlineData(20*Mathx.DegToRad, 40*Mathx.DegToRad, 60*Mathx.DegToRad, 0.6040228, -0.3420202, 0.7198463)]
		public void Forward_Get(float x, float y, float z, float ex, float ey, float ez) {
			// Variables
			Quaternion rot = Quaternion.FromEulerAngles(x, y, z);
			Vector3 e = new Vector3(ex, ey, ez);
			Transform transform = new Transform();
			
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.Forward);
			
			Assert.True(Vector3.Approx(e, transform.Forward, 0.000001f));
		}
		
		[Theory]
		[InlineData(0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(1, 0, 1, 0.7071067, 0, 0.7071068, 0, 0, 1, 0, 0, -0.7071068, 0, 0.7071067, 0, 0, 0, 0, 1)]
		[InlineData(-1, 4, 10, 0.9950372, 0.03679649, -0.09245003, 0, 0, 0.9291113, 0.3698002, 0, 0.09950372, -0.367965, 0.9245003, 0, 0, 0, 0, 1)]
		[InlineData(-1, -1, -1, -0.7071068, -0.4082483, -0.5773503, 0, 0, 0.8164966, -0.5773503, 0, 0.7071068, -0.4082483, -0.5773503, 0, 0, 0, 0, 1)]
		public void Forward_Set(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 forward = new Vector3(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Forward = forward;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 3, 0, 0, 0, 1)]
		[InlineData(-1, -1, -1, 1, 0, 1, 0.7071067, 0, 0.7071068, -1, 0, 1, 0, -1, -0.7071068, 0, 0.7071067, -1, 0, 0, 0, 1)]
		public void Position_Forward_Set(float x, float y, float z, float fx, float fy, float fz, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 pos = new Vector3(x, y, z);
			Vector3 forward = new Vector3(fx, fy, fz);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Position = pos;
			transform.Forward = forward;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Theory]
		[InlineData(0, 0, 0, 1, 0, 0)]
		[InlineData(0, -45*Mathx.DegToRad, 0, 0.7071067, 0, 0.7071068)]
		[InlineData(12.2*Mathx.DegToRad, -36.206*Mathx.DegToRad, 36.206*Mathx.DegToRad, 0.5773501, 0.5773503, 0.5773503)]
		[InlineData(-22.13*Mathx.DegToRad, 23.529*Mathx.DegToRad, 86.396*Mathx.DegToRad, -0.09245005, 0.9245003, -0.3698002)]
		public void Right_Get(float x, float y, float z, float ex, float ey, float ez) {
			// Variables
			Quaternion rot = Quaternion.FromEulerAngles(x, y, z);
			Vector3 e = new Vector3(ex, ey, ez);
			Transform transform = new Transform();
			
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.Right);
			
			Assert.True(Vector3.Approx(e, transform.Right, 0.00001f));
		}
		
		[Theory]
		[InlineData(1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(1, 0, 1, 0.7071067, 0, -0.7071068, 0, 0, 1, 0, 0, 0.7071068, 0, 0.7071067, 0, 0, 0, 0, 1)]
		[InlineData(-1, 4, 10, -0.09245014, 0.03679648, -0.9950373, 0, 0.3698002, 0.9291113, 0, 0, 0.9245005, -0.3679649, -0.09950387, 0, 0, 0, 0, 1)]
		[InlineData(-1, -1, -1, -0.5773504, -0.4082484, 0.7071069, 0, -0.5773503, 0.8164965, 0, 0, -0.5773503, -0.4082484, -0.7071068, 0, 0, 0, 0, 1)]
		[InlineData(-1, 1, -1, -0.5773503, 0.4082484, 0.7071069, 0, 0.5773504, 0.8164965, 0, 0, -0.5773503, 0.4082484, -0.7071068, 0, 0, 0, 0, 1)]
		public void Right_Set(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 right = new Vector3(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Right = right;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			this.output.WriteLine("Quaternion: " + transform.Rotation);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Theory]
		[InlineData(0, 0, 0, 0, 1, 0)]
		[InlineData(135*Mathx.DegToRad, 135*Mathx.DegToRad, 90*Mathx.DegToRad, 0.7071068, 0, 0.7071068)]
		[InlineData(53.301*Mathx.DegToRad, -13.513*Mathx.DegToRad, -26.565*Mathx.DegToRad, 0.2672612, 0.5345225, 0.8017837)]
		[InlineData(-35.264*Mathx.DegToRad, -75*Mathx.DegToRad, 135*Mathx.DegToRad, -0.5773503, -0.5773503, -0.5773503)]
		public void Up_Get(float x, float y, float z, float ex, float ey, float ez) {
			// Variables
			Quaternion rot = Quaternion.FromEulerAngles(x, y, z);
			Vector3 e = new Vector3(ex, ey, ez);
			Transform transform = new Transform();
			
			transform.Rotation = rot;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.Up);
			
			Assert.True(Vector3.Approx(e, transform.Up, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(1, 0, 1, 0.7071067, 0.7071068, 0, 0, 0, 0, -1, 0, -0.7071068, 0.7071067, 0, 0, 0, 0, 0, 1)]
		[InlineData(-1, 4, 10, 0.9950372, -0.09245004, -0.036796477, 0, 0, 0.3698001, -0.92911124, 0, 0.09950371, 0.9245002, 0.36796486, 0, 0, 0, 0, 1)]
		[InlineData(-1, -1, -1, -0.7071068, -0.5773503, 0.4082482, 0, 0, -0.5773503, -0.8164966, 0, 0.7071068, -0.5773504, 0.4082483, 0, 0, 0, 0, 1)]
		public void Up_Set(float x, float y, float z, float e11, float e12, float e13, float e14, float e21, float e22, float e23, float e24, float e31, float e32, float e33, float e34, float e41, float e42, float e43, float e44) {
			// Variables
			Vector3 up = new Vector3(x, y, z);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			
			transform.Up = up;
			
			this.output.WriteLine("Expected: " + e);
			this.output.WriteLine("Actual: " + transform.World);
			this.output.WriteLine("Up: " + transform.Up);
			
			Assert.True(Matrix.Approx(e, transform.World, 0.000001f));
		}
		
		[Fact]
		public void EulerAngles() {
			// Variables
			Transform transform = new Transform();
			
			for(int k = 0; k < 25; k++) {
				// Variables
				Vector3 e = Random.Range(-0.5f * Mathx.Pi * Vector3.One, 0.5f * Mathx.Pi * Vector3.One);
				Vector3 a;
				
				transform.EulerAngles = e;
				a = transform.EulerAngles;
				this.output.WriteLine("Expected: " + e);
				this.output.WriteLine("Actual: " + a);
				
				Assert.True(Mathx.Approx(ref e, ref a, 0.001f));
			}
		}
		
	}
}

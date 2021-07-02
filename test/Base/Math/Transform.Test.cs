
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Transform"/> class to make sure it works correctly. Contains 50 tests</summary>
	public class TransformTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.Transform"/> functionality.
		/// Creates a default transform and checks to see if it gets formed correctly
		/// </summary>
		[Fact]
		public void Constructor_World_ReturnsIdentityMatrix() {
			// Variables
			Transform transform = new Transform();
			Matrix expected = Matrix.Identity;
			Matrix actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Position"/> functionality.
		/// Changes the position of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetPosition_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			1, 0, 0, 1,
			0, 1, 0, 2,
			0, 0, 1, 3,
			0, 0, 0, 1
		)]
		[InlineData(
			1, -1, 1,
			1, 0, 0, 1,
			0, 1, 0, -1,
			0, 0, 1, 1,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetPosition_ReturnsMatrix Test Data
		public void World_SetPosition_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 position = new Vector3(x, y, z);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Position = position;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Rotation"/> functionality.
		/// Changes the rotation of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetRotation_ReturnsMatrix Test Data
		[InlineData(
			60, 0, 0,
			1, 0, 0, 0,
			0, 0.5, -0.8660254, 0,
			0, 0.8660254, 0.5, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 45, 0,
			0.7071067, 0, 0.7071068, 0,
			0, 1, 0, 0,
			-0.7071068, 0, 0.7071067, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 30,
			0.8660254, -0.5, 0, 0,
			0.5, 0.8660254, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			60, 45, 30,
			0.91855866, 0.17677674, 0.3535534, 0,
			0.25, 0.4330127, -0.8660254, 0,
			-0.30618626, 0.8838834, 0.35355335, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			140, -380, 20,
			0.80783033, -0.52798176, 0.26200268, 0,
			-0.2620026, -0.7198461, -0.6427876, 0,
			0.52798176, 0.4506179, -0.7198461, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetRotation_ReturnsMatrix Test Data
		public void World_SetRotation_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(x, y, z);
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Rotation = rotation;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Scale"/> functionality.
		/// Changes the scale of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetScale_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			1, 0, 0, 0,
			0, 2, 0, 0,
			0, 0, 3, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 0, 1,
			-1, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetScale_ReturnsMatrix Test Data
		public void World_SetScale_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 scale = new Vector3(x, y, z);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Scale = scale;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/>, <see cref="B3.Transform.Position"/>, and <see cref="B3.Transform.Rotation"/> functionality.
		/// Changes the position and rotation of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetPositionRotation_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			45, 60, 0,
			0.50000006, 0.61237246, 0.6123724, 1,
			0, 0.70710677, -0.7071068, 2,
			-0.8660253, 0.3535534, 0.35355338, 3,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 0, 1,
			90, 88, 217,
			-0.62932014, -0.77714586, 0, -1,
			0, 0.00000011920929, -0.9999999, 0,
			0.77714586, -0.62932026, 0.00000011920929, 1,
			0, 0, 0, 1
		)]
		#endregion // World_SetPositionRotation_ReturnsMatrix Test Data
		public void World_SetPositionRotation_ReturnsMatrix(
			float x, float y, float z,
			float yaw, float pitch, float roll,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 position = new Vector3(x, y, z);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Position = position;
			transform.Rotation = rotation;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/>, <see cref="B3.Transform.Position"/>, and <see cref="B3.Transform.Scale"/> functionality.
		/// Changes the position and scale of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetPositionScale_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			1, 2, 3,
			1, 0, 0, 1,
			0, 2, 0, 2,
			0, 0, 3, 3,
			0, 0, 0, 1
		)]
		[InlineData(
			1, -1, 1,
			0, 0, 0,
			0, 0, 0, 1,
			0, 0, 0, -1,
			0, 0, 0, 1,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 1, -1,
			-1, 0, 1,
			-1, 0, 0, 0,
			0, 0, 0, 1,
			0, 0, 1, -1,
			0, 0, 0, 1
		)]
		#endregion // World_SetPositionScale_ReturnsMatrix Test Data
		public void World_SetPositionScale_ReturnsMatrix(
			float x, float y, float z,
			float sx, float sy, float sz,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 position = new Vector3(x, y, z);
			Vector3 scale = new Vector3(sx, sy, sz);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Position = position;
			transform.Scale = scale;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/>, <see cref="B3.Transform.Rotation"/>, and <see cref="B3.Transform.Scale"/> functionality.
		/// Changes the rotation and scale of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetRotationScale_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			45, 60, 0,
			0.50000006, 1.2247449, 1.8371172, 0,
			0, 1.4142135, -2.1213205, 0,
			-0.8660253, 0.7071068, 1.0606601, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 0, 1,
			90, 88, 217,
			0.62932014, 0, 0, 0,
			0, 0, -0.9999999, 0,
			-0.77714586, 0, 0.00000011920929, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			4, 6, 8,
			100, 200, 300,
			-0.71259284, -5.8932595, 0.47512937, 0,
			0.60153496, -0.5209454, -7.8784637, 0,
			3.8897781, -0.99906063, 1.3054059, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetRotationScale_ReturnsMatrix Test Data
		public void World_SetRotationScale_ReturnsMatrix(
			float x, float y, float z,
			float yaw, float pitch, float roll,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 scale = new Vector3(x, y, z);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Scale = scale;
			transform.Rotation = rotation;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/>, <see cref="B3.Transform.Position"/>, <see cref="B3.Transform.Rotation"/>, and <see cref="B3.Transform.Scale"/> functionality.
		/// Changes the position, rotation, and scale of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetPositionRotationScale_ReturnsMatrix Test Data
		[InlineData(
			1, 1, 1,
			1, 2, 3,
			45, 60, 0,
			0.50000006, 1.2247449, 1.8371172, 1,
			0, 1.4142135, -2.1213205, 1,
			-0.8660253, 0.7071068, 1.0606601, 1,
			0, 0, 0, 1
		)]
		[InlineData(
			4, 4, 0,
			-1, 0, 1,
			90, 88, 217,
			0.62932014, 0, 0, 4,
			0, 0, -0.9999999, 4,
			-0.77714586, 0, 0.00000011920929, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			4, 8, 16,
			4, 6, 8,
			100, 200, 300,
			-0.71259284, -5.8932595, 0.47512937, 4,
			0.60153496, -0.5209454, -7.8784637, 8,
			3.8897781, -0.99906063, 1.3054059, 16,
			0, 0, 0, 1
		)]
		#endregion // World_SetPositionRotationScale_ReturnsMatrix Test Data
		public void World_SetPositionRotationScale_ReturnsMatrix(
			float x, float y, float z,
			float sx, float sy, float sz,
			float yaw, float pitch, float roll,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 position = new Vector3(x, y, z);
			Vector3 scale = new Vector3(sx, sy, sz);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(yaw, pitch, roll);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Position = position;
			transform.Scale = scale;
			transform.Rotation = rotation;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Forward"/> functionality.
		/// Changes the forward vector of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetForward_ReturnsMatrix Test Data
		[InlineData(
			0, 0, 1,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 1,
			0.7071067, 0, 0.7071068, 0,
			0, 1, 0, 0,
			-0.7071068, 0, 0.7071067, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 4, 10,
			0.9950372, 0.036796488, -0.09245003, 0,
			0, 0.92911136, 0.3698001, 0,
			0.09950372, -0.36796486, 0.92450035, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, -1, -1,
			-0.7071065, -0.40824828, -0.57735026, 0,
			0, 0.8164966, -0.5773502, 0,
			0.7071067, -0.40824825, -0.57735, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetForward_ReturnsMatrix Test Data
		public void World_SetForward_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 forward = new Vector3(x, y, z);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Forward = forward;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Right"/> functionality.
		/// Changes the right vector of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetRight_ReturnsMatrix Test Data
		[InlineData(
			1, 0, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 1,
			0.7071067, 0, -0.7071068, 0,
			0, 1, 0, 0,
			0.7071068, 0, 0.7071067, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 4, 10,
			-0.09245022, 0.03679642, -0.9950372, 0,
			0.3698002, 0.9291113, -0.00000010430813, 0,
			0.92450035, -0.36796498, -0.099503875, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, -1, -1,
			-0.57735, -0.4082483, 0.70710665, 0,
			-0.57735026, 0.81649655, 0.000000044703484, 0,
			-0.5773502, -0.40824825, -0.70710653, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 1, -1,
			-0.57735, 0.4082483, 0.70710665, 0,
			0.57735026, 0.81649655, -0.000000044703484, 0,
			-0.5773502, 0.40824825, -0.70710653, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetRight_ReturnsMatrix Test Data
		public void World_SetRight_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 right = new Vector3(x, y, z);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Right = right;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.World"/> and <see cref="B3.Transform.Up"/> functionality.
		/// Changes the up vector of the transform and checks if it's correct
		/// </summary>
		[Theory]
		#region World_SetUp_ReturnsMatrix Test Data
		[InlineData(
			0, 1, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 1,
			0.7071068, 0.7071068, 0, 0,
			0, -0.00000008940697, -1.0000001, 0,
			-0.7071068, 0.7071068, -0.00000008940697, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 4, 10,
			0.9950372, -0.09245004, -0.036796477, 0,
			-0.0000000037252903, 0.3698001, -0.92911124, 0,
			0.09950371, 0.9245002, 0.36796486, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, -1, -1,
			-0.70710623, -0.5773502, 0.40824807, 0,
			0.000000059604645, -0.5773496, -0.81649643, 0,
			0.7071066, -0.5773501, 0.4082484, 0,
			0, 0, 0, 1
		)]
		#endregion // World_SetUp_ReturnsMatrix Test Data
		public void World_SetUp_ReturnsMatrix(
			float x, float y, float z,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix expected = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			Vector3 up = new Vector3(x, y, z);
			Transform transform = new Transform();
			Matrix actual;
			
			transform.Up = up;
			actual = transform.World;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.Forward"/> functionality.
		/// Rotates the transform and checks to see if the forward vector is correct.
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 0, 1)]
		[InlineData(30, 0, 0, 0, -0.5, 0.8660254)]
		[InlineData(20, 40, 60, 0.6040226, -0.3420201, 0.7198462)]
		public void Forward_Rotation_RetunrsVector3(
			float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(x, y, z);
			Transform transform = new Transform();
			Vector3 actual;
			
			transform.Rotation = rotation;
			actual = transform.Forward;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.Right"/> functionality.
		/// Rotates the transform and checks to see if the right vector is correct.
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 1, 0, 0)]
		[InlineData(0, -45, 0, 0.7071067, 0, 0.7071068)]
		[InlineData(12.2, -36.206, 36.206, 0.5773508, 0.5773499, 0.5773501)]
		[InlineData(-22.13, 23.529, 86.396, -0.09245615, 0.9244996, -0.3698005)]
		public void Right_Rotation_ReturnsVector3(
			float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(x, y, z);
			Transform transform = new Transform();
			Vector3 actual;
			
			transform.Rotation = rotation;
			actual = transform.Right;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Transform.Up"/> functionality.
		/// Rotates the transform and checks to see if the up vector is correct.
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, 1, 0)]
		[InlineData(135, 135, 90, 0.70710665, -0.000000029802322, 0.70710665)]
		[InlineData(53.301, -13.513, -26.565, 0.26726145, 0.53452, 0.8017853)]
		[InlineData(-35.264, -75, 135, -0.57734644, -0.577353, -0.5773513)]
		public void Up_Rotation_ReturnsVector3(
			float x, float y, float z,
			float ex, float ey, float ez
		) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			Quaternion rotation = Quaternion.FromEulerAnglesDeg(x, y, z);
			Transform transform = new Transform();
			Vector3 actual;
			
			transform.Rotation = rotation;
			actual = transform.Up;
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

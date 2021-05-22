
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class Vector3Test {
		// Variables
		private const float Sqrt3 = 1.73205080757f;
		private const float Sqrt50 = 7.07106781187f;
		private const float Sqrt134 = 11.5758369028f;
		private readonly ITestOutputHelper output;
		private readonly System.Random random;
		
		public Vector3Test(ITestOutputHelper output) {
			this.output = output;
			this.random = new System.Random();
		}
		
		// [Fact]
		// public void ToVector4() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Vector3 a = 100.0f * Random.UnitVector3;
		// 		Vector4 e = new Vector4(a.x, a.y, a.z, 1.0f);
				
		// 		Assert.Equal(e, (Vector4)a);
		// 	}
		// }
		
		// [Fact]
		// public void ToVector2() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		Vector3 a = 100.0f * Random.UnitVector3;
		// 		Vector2 e = new Vector2(a.x, a.y);
				
		// 		Assert.Equal(e, (Vector2)a);
		// 	}
		// }
		
		// // Testing the constants of the 3D vector
		// [Fact]
		// public void Constants() {
		// 	// Variables
		// 	Vector3 vec = Vector3.Zero;
			
		// 	Assert.True(vec.x == 0.0f && vec.y == 0.0f && vec.z == 0.0f);
		// 	vec = Vector3.One;
		// 	Assert.True(vec.x == 1.0f && vec.y == 1.0f && vec.z == 1.0f);
		// 	vec = Vector3.UnitX;
		// 	Assert.True(vec.x == 1.0f && vec.y == 0.0f && vec.z == 0.0f);
		// 	vec = Vector3.UnitY;
		// 	Assert.True(vec.x == 0.0f && vec.y == 1.0f && vec.z == 0.0f);
		// 	vec = Vector3.UnitZ;
		// 	Assert.True(vec.x == 0.0f && vec.y == 0.0f && vec.z == 1.0f);
		// }
		
		// // Testing the magnitude of the 2D vector
		// [Theory]
		// [InlineData(1.0f, 1.0f, 1.0f, 3.0f, Sqrt3)]
		// [InlineData(3.0f, 4.0f, 5.0f, 50.0f, Sqrt50)]
		// [InlineData(7.0f, 2.0f, 9.0f, 134.0f, Sqrt134)]
		// public void Magnitude(float x, float y, float z, float expectedSqMagnitude, float expectedMagnitude) {
		// 	// Variables
		// 	Vector3 vec = new Vector3(x, y, z);
			
		// 	Assert.True(vec.MagnitudeSquared == expectedSqMagnitude);
		// 	Assert.True(vec.Magnitude == expectedMagnitude);
		// }
		
		// [Fact]
		// public void FromAngle() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float theta = Mathx.Pi * (float)this.random.NextDouble();
		// 		float phi = Mathx.Pi * (float)this.random.NextDouble();
		// 		float cosPhi = Mathx.Cos(phi);
		// 		float ex = cosPhi * Mathx.Cos(theta);
		// 		float ey = cosPhi * Mathx.Sin(theta);
		// 		float ez = Mathx.Sin(phi);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.FromAngle(theta, phi));
		// 	}
		// }
		
		// [Fact]
		// public void Add() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float ex = x1 + x2;
		// 		float ey = y1 + y2;
		// 		float ez = z1 + z2;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Add(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void Subtract() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float ex = x1 - x2;
		// 		float ey = y1 - y2;
		// 		float ez = z1 - z2;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Subtract(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void Multiply() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float scalar = 10.0f * (float)this.random.NextDouble();
		// 		float x = 10.0f * (float)this.random.NextDouble();
		// 		float y = 10.0f * (float)this.random.NextDouble();
		// 		float z = 10.0f * (float)this.random.NextDouble();
		// 		float ex = x * scalar;
		// 		float ey = y * scalar;
		// 		float ez = z * scalar;
		// 		Vector3 a = new Vector3(x, y, z);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Multiply(scalar, ref a));
		// 	}
		// }
		
		// [Fact]
		// public void Divide() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float scalar = 10.0f * (float)this.random.NextDouble();
		// 		float x = 10.0f * (float)this.random.NextDouble();
		// 		float y = 10.0f * (float)this.random.NextDouble();
		// 		float z = 10.0f * (float)this.random.NextDouble();
		// 		float dividedScalar = 1.0f / scalar;
		// 		float ex = x * dividedScalar;
		// 		float ey = y * dividedScalar;
		// 		float ez = z * dividedScalar;
		// 		Vector3 a = new Vector3(x, y, z);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Divide(scalar, ref a));
		// 	}
		// }
		
		// [Fact]
		// public void Dot() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float ex = x1 * x2;
		// 		float ey = y1 * y2;
		// 		float ez = z1 * z2;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		float e = ex + ey + ez;
				
		// 		Assert.Equal(e, Mathx.Dot(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void Normalize() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x = 10.0f * (float)this.random.NextDouble();
		// 		float y = 10.0f * (float)this.random.NextDouble();
		// 		float z = 10.0f * (float)this.random.NextDouble();
		// 		float length = (float)System.Math.Sqrt(x * x + y * y + z * z);
		// 		float dividedLength = 1.0f / length;
		// 		float ex = x * dividedLength;
		// 		float ey = y * dividedLength;
		// 		float ez = z * dividedLength;
		// 		Vector3 a = new Vector3(x, y, z);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Normalize(ref a));
		// 		Assert.InRange(Mathx.Normalize(ref a).Magnitude, 1.0f - 0.000005f, 1.0f + 0.000005f);
		// 	}
		// }
		
		// [Fact]
		// public void Negate() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float scalar = 10.0f * (float)this.random.NextDouble();
		// 		float x = 10.0f * (float)this.random.NextDouble();
		// 		float y = 10.0f * (float)this.random.NextDouble();
		// 		float z = 10.0f * (float)this.random.NextDouble();
		// 		float ex = -x;
		// 		float ey = -y;
		// 		float ez = -z;
		// 		Vector3 a = new Vector3(x, y, z);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Negate(ref a));
		// 	}
		// }
		
		// [Fact]
		// public void CrossProduct() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float ex = y1 * z2 - z1 * y2;
		// 		float ey = z1 * x2 - x1 * z2;
		// 		float ez = x1 * y2 - y1 * x2;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.CrossProduct(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void Project() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float tx = x1 * x2;
		// 		float ty = y1 * y2;
		// 		float tz = z1 * z2;
		// 		float tdot = tx + ty + tz;
		// 		float bx = x2 * x2;
		// 		float by = y2 * y2;
		// 		float bz = z2 * z2;
		// 		float bdot = bx + by + bz;
		// 		float scalar = tdot / bdot;
		// 		float ex = scalar * x2;
		// 		float ey = scalar * y2;
		// 		float ez = scalar * z2;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Project(ref a, ref b));
		// 	}
		// }
		
		// [Fact]
		// public void Reject() {
		// 	for(int i = 0; i <= 25; i++) {
		// 		// Variables
		// 		float x1 = 10.0f * (float)this.random.NextDouble();
		// 		float y1 = 10.0f * (float)this.random.NextDouble();
		// 		float z1 = 10.0f * (float)this.random.NextDouble();
		// 		float x2 = 10.0f * (float)this.random.NextDouble();
		// 		float y2 = 10.0f * (float)this.random.NextDouble();
		// 		float z2 = 10.0f * (float)this.random.NextDouble();
		// 		float tx = x1 * x2;
		// 		float ty = y1 * y2;
		// 		float tz = z1 * z2;
		// 		float tdot = tx + ty + tz;
		// 		float bx = x2 * x2;
		// 		float by = y2 * y2;
		// 		float bz = z2 * z2;
		// 		float bdot = bx + by + bz;
		// 		float scalar = tdot / bdot;
		// 		float px = scalar * x2;
		// 		float py = scalar * y2;
		// 		float pz = scalar * z2;
		// 		float ex = x1 - px;
		// 		float ey = y1 - py;
		// 		float ez = z1 - pz;
		// 		Vector3 a = new Vector3(x1, y1, z1);
		// 		Vector3 b = new Vector3(x2, y2, z2);
		// 		Vector3 e = new Vector3(ex, ey, ez);
				
		// 		Assert.Equal(e, Mathx.Reject(ref a, ref b));
		// 	}
		// }
	}
}

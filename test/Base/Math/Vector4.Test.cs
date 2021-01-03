
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class Vector4Test {
		// Variables
		private const float Sqrt86 = 9.2736184955f;
		private const float Sqrt159 = 12.6095202129f;
		private readonly ITestOutputHelper output;
		private readonly System.Random random;
		
		public Vector4Test(ITestOutputHelper output) {
			this.output = output;
			this.random = new System.Random();
		}
		
		[Fact]
		public void ToVector3() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Vector4 a = 100.0f * Random.UnitVector4;
				Vector3 e = new Vector3(a.x, a.y, a.z);
				
				Assert.Equal(e, (Vector3)a);
			}
		}
		
		[Fact]
		public void ToVector2() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Vector4 a = 100.0f * Random.UnitVector4;
				Vector2 e = new Vector2(a.x, a.y);
				
				Assert.Equal(e, (Vector2)a);
			}
		}
		
		// Testing the constants of the 3D vector
		[Fact]
		public void Constants() {
			// Variables
			Vector4 vec = Vector4.Zero;
			
			Assert.True(vec.x == 0.0f && vec.y == 0.0f && vec.z == 0.0f && vec.w == 0.0f);
			vec = Vector4.One;
			Assert.True(vec.x == 1.0f && vec.y == 1.0f && vec.z == 1.0f && vec.w == 1.0f);
			vec = Vector4.UnitX;
			Assert.True(vec.x == 1.0f && vec.y == 0.0f && vec.z == 0.0f && vec.w == 0.0f);
			vec = Vector4.UnitY;
			Assert.True(vec.x == 0.0f && vec.y == 1.0f && vec.z == 0.0f && vec.w == 0.0f);
			vec = Vector4.UnitZ;
			Assert.True(vec.x == 0.0f && vec.y == 0.0f && vec.z == 1.0f && vec.w == 0.0f);
			vec = Vector4.UnitW;
			Assert.True(vec.x == 0.0f && vec.y == 0.0f && vec.z == 0.0f && vec.w == 1.0f);
		}
		
		// Testing the magnitude of the 2D vector
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f, 1.0f, 4.0f, 2.0f)]
		[InlineData(3.0f, 4.0f, 5.0f, 6.0f, 86.0f, Sqrt86)]
		[InlineData(7.0f, 2.0f, 9.0f, 5.0f, 159.0f, Sqrt159)]
		public void Magnitude(float x, float y, float z, float w, float expectedSqMagnitude, float expectedMagnitude) {
			// Variables
			Vector4 vec = new Vector4(x, y, z, w);
			
			Assert.True(vec.MagnitudeSquared == expectedSqMagnitude);
			Assert.True(vec.Magnitude == expectedMagnitude);
		}
		
		[Fact]
		public void Add() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float z1 = 10.0f * (float)this.random.NextDouble();
				float w1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float z2 = 10.0f * (float)this.random.NextDouble();
				float w2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 + x2;
				float ey = y1 + y2;
				float ez = z1 + z2;
				float ew = w1 + w2;
				Vector4 a = new Vector4(x1, y1, z1, w1);
				Vector4 b = new Vector4(x2, y2, z2, w2);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Add(ref a, ref b));
			}
		}
		
		[Fact]
		public void Subtract() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float z1 = 10.0f * (float)this.random.NextDouble();
				float w1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float z2 = 10.0f * (float)this.random.NextDouble();
				float w2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 - x2;
				float ey = y1 - y2;
				float ez = z1 - z2;
				float ew = w1 - w2;
				Vector4 a = new Vector4(x1, y1, z1, w1);
				Vector4 b = new Vector4(x2, y2, z2, w2);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Subtract(ref a, ref b));
			}
		}
		
		[Fact]
		public void Multiply() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float scalar = 10.0f * (float)this.random.NextDouble();
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float z = 10.0f * (float)this.random.NextDouble();
				float w = 10.0f * (float)this.random.NextDouble();
				float ex = x * scalar;
				float ey = y * scalar;
				float ez = z * scalar;
				float ew = w * scalar;
				Vector4 a = new Vector4(x, y, z, w);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Multiply(scalar, ref a));
			}
		}
		
		[Fact]
		public void Divide() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float scalar = 10.0f * (float)this.random.NextDouble();
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float z = 10.0f * (float)this.random.NextDouble();
				float w = 10.0f * (float)this.random.NextDouble();
				float dividedScalar = 1.0f / scalar;
				float ex = x * dividedScalar;
				float ey = y * dividedScalar;
				float ez = z * dividedScalar;
				float ew = w * dividedScalar;
				Vector4 a = new Vector4(x, y, z, w);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Divide(scalar, ref a));
			}
		}
		
		[Fact]
		public void Dot() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float z1 = 10.0f * (float)this.random.NextDouble();
				float w1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float z2 = 10.0f * (float)this.random.NextDouble();
				float w2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 * x2;
				float ey = y1 * y2;
				float ez = z1 * z2;
				float ew = w1 * w2;
				Vector4 a = new Vector4(x1, y1, z1, w1);
				Vector4 b = new Vector4(x2, y2, z2, w2);
				float e = ex + ey + ez + ew;
				
				Assert.Equal(e, Mathx.Dot(ref a, ref b));
			}
		}
		
		[Fact]
		public void Normalize() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float z = 10.0f * (float)this.random.NextDouble();
				float w = 10.0f * (float)this.random.NextDouble();
				float length = (float)System.Math.Sqrt(x * x + y * y + z * z + w * w);
				float dividedLength = 1.0f / length;
				float ex = x * dividedLength;
				float ey = y * dividedLength;
				float ez = z * dividedLength;
				float ew = w * dividedLength;
				Vector4 a = new Vector4(x, y, z, w);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Normalize(ref a));
				Assert.InRange(Mathx.Normalize(ref a).Magnitude, 1.0f - 0.000005f, 1.0f + 0.000005f);
			}
		}
		
		[Fact]
		public void Negate() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float scalar = 10.0f * (float)this.random.NextDouble();
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float z = 10.0f * (float)this.random.NextDouble();
				float w = 10.0f * (float)this.random.NextDouble();
				float ex = -x;
				float ey = -y;
				float ez = -z;
				float ew = -w;
				Vector4 a = new Vector4(x, y, z, w);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Negate(ref a));
			}
		}
		
		[Fact]
		public void Project() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float z1 = 10.0f * (float)this.random.NextDouble();
				float w1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float z2 = 10.0f * (float)this.random.NextDouble();
				float w2 = 10.0f * (float)this.random.NextDouble();
				float tx = x1 * x2;
				float ty = y1 * y2;
				float tz = z1 * z2;
				float tw = w1 * w2;
				float tdot = tx + ty + tz + tw;
				float bx = x2 * x2;
				float by = y2 * y2;
				float bz = z2 * z2;
				float bw = w2 * w2;
				float bdot = bx + by + bz + bw;
				float scalar = tdot / bdot;
				float ex = scalar * x2;
				float ey = scalar * y2;
				float ez = scalar * z2;
				float ew = scalar * w2;
				Vector4 a = new Vector4(x1, y1, z1, w1);
				Vector4 b = new Vector4(x2, y2, z2, w2);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Project(ref a, ref b));
			}
		}
		
		[Fact]
		public void Reject() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float z1 = 10.0f * (float)this.random.NextDouble();
				float w1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float z2 = 10.0f * (float)this.random.NextDouble();
				float w2 = 10.0f * (float)this.random.NextDouble();
				float tx = x1 * x2;
				float ty = y1 * y2;
				float tz = z1 * z2;
				float tw = w1 * w2;
				float tdot = tx + ty + tz + tw;
				float bx = x2 * x2;
				float by = y2 * y2;
				float bz = z2 * z2;
				float bw = w2 * w2;
				float bdot = bx + by + bz + bw;
				float scalar = tdot / bdot;
				float px = scalar * x2;
				float py = scalar * y2;
				float pz = scalar * z2;
				float pw = scalar * w2;
				float ex = x1 - px;
				float ey = y1 - py;
				float ez = z1 - pz;
				float ew = w1 - pw;
				Vector4 a = new Vector4(x1, y1, z1, w1);
				Vector4 b = new Vector4(x2, y2, z2, w2);
				Vector4 e = new Vector4(ex, ey, ez, ew);
				
				Assert.Equal(e, Mathx.Reject(ref a, ref b));
			}
		}
	}
}

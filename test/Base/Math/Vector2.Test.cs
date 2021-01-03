
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class Vector2Test {
		// Variables
		private const float Sqrt2 = 1.41421356237f;
		private const float Sqrt53 = 7.28010988928f;
		private readonly ITestOutputHelper output;
		private readonly System.Random random;
		
		public Vector2Test(ITestOutputHelper output) {
			this.output = output;
			this.random = new System.Random();
		}
		
		[Fact]
		public void ToVector4() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Vector2 a = 100.0f * Random.UnitVector2;
				Vector4 e = new Vector4(a.x, a.y, 0.0f, 1.0f);
				
				Assert.Equal(e, (Vector4)a);
			}
		}
		
		[Fact]
		public void ToVector3() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Vector2 a = 100.0f * Random.UnitVector2;
				Vector3 e = new Vector3(a.x, a.y, 0.0f);
				
				Assert.Equal(e, (Vector3)a);
			}
		}
		
		// Testing the constants of the 2D vector
		[Fact]
		public void Constants() {
			// Variables
			Vector2 vec = Vector2.Zero;
			
			Assert.True(vec.x == 0.0f && vec.y == 0.0f);
			vec = Vector2.One;
			Assert.True(vec.x == 1.0f && vec.y == 1.0f);
			vec = Vector2.UnitX;
			Assert.True(vec.x == 1.0f && vec.y == 0.0f);
			vec = Vector2.UnitY;
			Assert.True(vec.x == 0.0f && vec.y == 1.0f);
		}
		
		// Testing the magnitude of the 2D vector
		[Theory]
		[InlineData(1.0f, 1.0f, 2.0f, Sqrt2)]
		[InlineData(3.0f, 4.0f, 25.0f, 5.0f)]
		[InlineData(7.0f, 2.0f, 53.0f, Sqrt53)]
		public void Magnitude(float x, float y, float expectedSqMagnitude, float expectedMagnitude) {
			// Variables
			Vector2 vec = new Vector2(x, y);
			
			Assert.True(vec.MagnitudeSquared == expectedSqMagnitude);
			Assert.True(vec.Magnitude == expectedMagnitude);
		}
		
		[Fact]
		public void FromAngle() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float theta = Mathx.Pi * (float)this.random.NextDouble();
				float ex = Mathx.Cos(theta);
				float ey = Mathx.Sin(theta);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.FromAngle(theta));
			}
		}
		
		[Fact]
		public void Add() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 + x2;
				float ey = y1 + y2;
				Vector2 a = new Vector2(x1, y1);
				Vector2 b = new Vector2(x2, y2);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.Add(ref a, ref b));
			}
		}
		
		[Fact]
		public void Subtract() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 - x2;
				float ey = y1 - y2;
				Vector2 a = new Vector2(x1, y1);
				Vector2 b = new Vector2(x2, y2);
				Vector2 e = new Vector2(ex, ey);
				
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
				float ex = scalar * x;
				float ey = scalar * y;
				Vector2 a = new Vector2(x, y);
				Vector2 e = new Vector2(ex, ey);
				
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
				float dividedScalar = 1.0f / scalar;
				float ex = x * dividedScalar;
				float ey = y * dividedScalar;
				Vector2 a = new Vector2(x, y);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.Divide(scalar, ref a));
			}
		}
		
		[Fact]
		public void Dot() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float ex = x1 * x2;
				float ey = y1 * y2;
				Vector2 a = new Vector2(x1, y1);
				Vector2 b = new Vector2(x2, y2);
				float e = ex + ey;
				
				Assert.Equal(e, Mathx.Dot(ref a, ref b));
			}
		}
		
		[Fact]
		public void Normalize() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float length = (float)System.Math.Sqrt(x * x + y * y);
				float dividedLength = 1.0f / length;
				float ex = x * dividedLength;
				float ey = y * dividedLength;
				Vector2 a = new Vector2(x, y);
				Vector2 e = new Vector2(ex, ey);
				
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
				float ex = -x;
				float ey = -y;
				Vector2 a = new Vector2(x, y);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.Negate(ref a));
			}
		}
		
		[Fact]
		public void CreatePerpendicular() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x = 10.0f * (float)this.random.NextDouble();
				float y = 10.0f * (float)this.random.NextDouble();
				float ex = y;
				float ey = -x;
				Vector2 a = new Vector2(x, y);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.CreatePerpendicular(ref a));
			}
		}
		
		[Fact]
		public void Project() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float tx = x1 * x2;
				float ty = y1 * y2;
				float tdot = tx + ty;
				float bx = x2 * x2;
				float by = y2 * y2;
				float bdot = bx + by;
				float scalar = tdot / bdot;
				float ex = scalar * x2;
				float ey = scalar * y2;
				Vector2 a = new Vector2(x1, y1);
				Vector2 b = new Vector2(x2, y2);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.Project(ref a, ref b));
			}
		}
		
		[Fact]
		public void Reject() {
			for(int i = 0; i <= 25; i++) {
				// Variables
				float x1 = 10.0f * (float)this.random.NextDouble();
				float y1 = 10.0f * (float)this.random.NextDouble();
				float x2 = 10.0f * (float)this.random.NextDouble();
				float y2 = 10.0f * (float)this.random.NextDouble();
				float tx = x1 * x2;
				float ty = y1 * y2;
				float tdot = tx + ty;
				float bx = x2 * x2;
				float by = y2 * y2;
				float bdot = bx + by;
				float scalar = tdot / bdot;
				float px = scalar * x2;
				float py = scalar * y2;
				float ex = x1 - px;
				float ey = y1 - py;
				Vector2 a = new Vector2(x1, y1);
				Vector2 b = new Vector2(x2, y2);
				Vector2 e = new Vector2(ex, ey);
				
				Assert.Equal(e, Mathx.Reject(ref a, ref b));
			}
		}
	}
}

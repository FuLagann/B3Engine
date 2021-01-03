
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class MatrixTest {
		// Variables
		private ITestOutputHelper output;
		
		public MatrixTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void Constructors() {
			Assert.Equal(
				Matrix.Identity,
				new Matrix(
					1, 0, 0, 0,
					0, 1, 0, 0,
					0, 0, 1, 0,
					0, 0, 0, 1
				)
			);
			Assert.Equal(
				Matrix.Zero,
				new Matrix(
					0, 0, 0, 0,
					0, 0, 0, 0,
					0, 0, 0, 0,
					0, 0, 0, 0
				)
			);
		}
		
		[Fact]
		public void Add() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Matrix a = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				Matrix b = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				Matrix e = new Matrix(
					a.row1 + b.row1,
					a.row2 + b.row2,
					a.row3 + b.row3,
					a.row4 + b.row4
				);
				
				Assert.Equal(e, Mathx.Add(ref a, ref b));
			}
		}
		
		[Fact]
		public void Subtract() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Matrix a = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				Matrix b = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				Matrix e = new Matrix(
					a.row1 - b.row1,
					a.row2 - b.row2,
					a.row3 - b.row3,
					a.row4 - b.row4
				);
				
				Assert.Equal(e, Mathx.Subtract(ref a, ref b));
			}
		}
		
		[Fact]
		public void MultiplyScalar() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Matrix a = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				float b = 10f * Random.Value;
				Matrix e = new Matrix(
					b * a.row1,
					b * a.row2,
					b * a.row3,
					b * a.row4
				);
				
				Assert.Equal(e, Mathx.Multiply(b, ref a));
			}
		}
		
		[Fact]
		public void DivideScalar() {
			for(int i = 0; i < 25; i++) {
				// Variables
				Matrix a = new Matrix(
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4,
					10f * Random.UnitVector4
				);
				float b = 10f * Random.Value;
				Matrix e = new Matrix(
					a.row1 / b,
					a.row2 / b,
					a.row3 / b,
					a.row4 / b
				);
				
				Assert.Equal(e, Mathx.Divide(b, ref a));
			}
		}
		
		[Theory]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			1, 5, 9, 13,
			2, 6, 10, 14,
			3, 7, 11, 15,
			4, 8, 12, 16
		)]
		public void Transpose(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix e = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			
			Assert.Equal(e, Mathx.Transpose(ref a));
		}
		
		[Theory]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			-1, 0, 0, 0,
			0, -1, 0, 0,
			0, 0, -1, 0,
			0, 0, 0, -1
		)]
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			-1, -2, -3, -4,
			-5, -6, -7, -8,
			-9, -10, -11, -12,
			-13, -14, -15, -16
		)]
		public void Negate(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix e = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			
			Assert.Equal(e, Mathx.Negate(ref a));
		}
		
		[Theory]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16
		)]
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16
		)]
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			1, 5, 9, 13,
			2, 6, 10, 14,
			3, 7, 11, 15,
			4, 8, 12, 16,
			
			30, 70, 110, 150,
			70, 174, 278, 382,
			110, 278, 446, 614,
			150, 382, 614, 846
		)]
		[InlineData(
			0, 1, 0, 0,
			1, 0, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 0, 0, 0,
			0, 0, -1, 0,
			0, 1, 0, 0,
			0, 0, 0, 1,
			
			0, 0, -1, 0,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 0, 1
		)]
		public void Multiply(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44,
			float e11, float e12, float e13, float e14,
			float e21, float e22, float e23, float e24,
			float e31, float e32, float e33, float e34,
			float e41, float e42, float e43, float e44
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix b = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			Matrix e = new Matrix(
				e11, e12, e13, e14,
				e21, e22, e23, e24,
				e31, e32, e33, e34,
				e41, e42, e43, e44
			);
			
			Assert.Equal(e, Mathx.Multiply(ref a, ref b));
		}
		
		[Theory]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			1
		)]
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			0
		)]
		[InlineData(
			1, 2, 3, 4,
			2, 0, 0, 3,
			3, 0, 0, 2,
			4, 3, 2, 1,
			25
		)]
		[InlineData(
			1, 2, 3, 4,
			2, 8, 8, 3,
			3, 8, 8, 2,
			4, 3, 2, 1,
			-55
		)]
		public void GetDeterminant(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float detA
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			float e = detA;
			
			Assert.Equal(e, Mathx.GetDeterminant(ref a));
		}
		
		[Theory]
		[InlineData(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 2, 3, 4,
			2, 0, 0, 3,
			3, 0, 0, 2,
			4, 3, 2, 1,
			
			0, -0.4f, 0.6f, 0,
			-0.4f, 1.4f, -1.6f, 0.6f,
			0.6f, -1.6f, 1.4f, -0.4f,
			0, 0.6f, -0.4f, 0
		)]
		[InlineData(
			1, 2, 3, 4,
			2, 8, 8, 3,
			3, 8, 8, 2,
			4, 3, 2, 1,
			
			0.14545454f, -0.54545454f, 0.4545454f, 0.14545454f,
			-0.54545454f, 1.54545454f, -1.4545454f, 0.4545454f,
			0.4545454f, -1.4545454f, 1.54545454f, -0.54545454f,
			0.14545454f, 0.4545454f, -0.54545454f, 0.14545454f
		)]
		public void Invert(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix e = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			
			Mathx.Invert(ref a, out a);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
			Assert.True(Matrix.Approx(Matrix.Identity, a * Mathx.Invert(ref a), 0.00001f));
			Assert.True(Matrix.Approx(Matrix.Identity, Mathx.Invert(ref a) * a, 0.00001f));
			Assert.True(Matrix.Approx(a, a * Mathx.Invert(ref a) * a, 0.00001f));
		}
		
		[Theory]
		[InlineData(
			30 * Mathx.DegToRad, 0, 0,
			1, 0, 0, 0,
			0, 0.8660254037f, -0.5f, 0,
			0, 0.5f, 0.8660254037f, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 60 * Mathx.DegToRad, 0,
			0.5f, 0, 0.8660254037f, 0,
			0, 1, 0, 0,
			-0.8660254037f, 0, 0.5f, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 129 * Mathx.DegToRad,
			-0.6293203910f, -0.7771459614f, 0, 0,
			0.7771459614f, -0.6293203910f, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			30 * Mathx.DegToRad, 60 * Mathx.DegToRad, 129 * Mathx.DegToRad,
			-0.3146601955f, -0.9455318679f, -0.08341731255f, 0,
			0.3885729807f, -0.2084933732f, 0.8975196666f, 0,
			-0.8660254037f, 1/4f, 0.4330127018f, 0,
			0, 0, 0, 1
		)]
		public void Rotations(
			float xrot, float yrot, float zrot,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44
		) {
			// Variables
			Matrix e = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			Matrix a = (
				Matrix.CreateRotationZ(zrot) *
				Matrix.CreateRotationY(yrot) *
				Matrix.CreateRotationX(xrot)
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a, 0.000001f));
		}
		
		[Fact]
		public void CreateRotationFromAxisAngle() {
			// Variables
			Matrix a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitX, 30 * Mathx.DegToRad);
			Matrix e = Matrix.CreateRotationX(30 * Mathx.DegToRad);
			
			this.output.WriteLine("Expected X:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual X:");
			this.output.WriteLine(a.ToString());
			this.output.WriteLine("---------------");
			
			Assert.True(Mathx.Approx(ref e, ref a));
			
			a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitY, 30 * Mathx.DegToRad);
			e = Matrix.CreateRotationY(30 * Mathx.DegToRad);
			
			this.output.WriteLine("Expected Y:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual Y:");
			this.output.WriteLine(a.ToString());
			this.output.WriteLine("---------------");
			
			Assert.True(Mathx.Approx(ref e, ref a));
			
			a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitZ, 30 * Mathx.DegToRad);
			e = Matrix.CreateRotationZ(30 * Mathx.DegToRad);
			
			this.output.WriteLine("Expected Z:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual Z:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
			
			a = Matrix.CreateRotationFromAxisAngle(new Vector3(1, 1, 1), 30 * Mathx.DegToRad);
			e = new Matrix(
				0.9106836025f, -0.244016935f, 1/3f, 0.0f,
				1/3f, 0.9106836025f, -0.244016935f, 0.0f,
				-0.244016935f, 1/3f, 0.9106836025f, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f
			);
			
			this.output.WriteLine("Expected One:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual One:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
			
			a = Matrix.CreateRotationFromAxisAngle(new Vector3(1, 2, 3), 30 * Mathx.DegToRad);
			e = new Matrix(
				0.8755950178f, -0.3817526348f, 0.2959700839f, 0,
				0.4200310909f, 0.9043038598f, -0.07621293686f, 0,
				-0.2385523998f, 0.1910483050f, 0.9521519299f, 0,
				0, 0, 0, 1
			);
			
			this.output.WriteLine("Expected 1,2,3:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual 1,2,3:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
		}
		
		[Theory]
		[InlineData(0.5, 2, 10, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0.5, 0, 0, 0, 0, 2, 0, 0, 0, 0, 10, 0, 0, 0, 0, 1)]
		[InlineData(0.5, 2, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0.5, 1, 1.5, 2, 10, 12, 14, 16, 90, 100, 110, 120, 13, 14, 15, 16)]
		[InlineData(0.1, 0.2, 4, 1, 2, 3, 4, 2, 8, 8, 3, 3, 8, 8, 2, 4, 3, 2, 1, 0.1, 0.2, 0.3, 0.4, 0.4, 1.6, 1.6, 0.6, 12, 32, 32, 8, 4, 3, 2, 1)]
		public void CreateScale(
			float xScalar, float yScalar, float zScalar,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float b11, float b12, float b13, float b14,
			float b21, float b22, float b23, float b24,
			float b31, float b32, float b33, float b34,
			float b41, float b42, float b43, float b44
		) {
			// Variables
			Vector3 scalars = new Vector3(xScalar, yScalar, zScalar);
			Matrix b = Matrix.CreateScale(ref scalars);
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix e = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine((b * a).ToString());
			
			Assert.True(Matrix.Approx(e, Mathx.Multiply(ref b, ref a)));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 4, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3, 4)]
		[InlineData(1, 2, 3, 1, 2, 0, 0, 10, 0, 2, 0, 8, 0, 0, 2, 5, 0, 0, 0, 1, 12, 12, 11, 1)]
		[InlineData(1, 2, 3, 4, 1, 2, 3, 4, 2, 3, 4, 1, 3, 4, 1, 2, 4, 1, 2, 3, 30, 24, 22, 24)]
		public void MultiplyVector4(
			float x, float y, float z, float w,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float ex, float ey, float ez, float ew
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Vector4 b = new Vector4(x, y, z, w);
			Vector4 e = new Vector4(ex, ey, ez, ew);
			
			Assert.Equal(e, Mathx.Multiply(ref a, ref b));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3)]
		[InlineData(1, 2, 3, 2, 0, 0, 10, 0, 2, 0, 8, 0, 0, 2, 5, 0, 0, 0, 1, 12, 12, 11)]
		[InlineData(1, 2, 3, 1, 2, 3, 4, 2, 3, 4, 1, 3, 4, 1, 2, 4, 1, 2, 3, 18, 21, 16)]
		public void MultiplyVector3(
			float x, float y, float z,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float ex, float ey, float ez
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Vector3 b = new Vector3(x, y, z);
			Vector3 e = new Vector3(ex, ey, ez);
			
			Assert.Equal(e, Mathx.Multiply(ref a, ref b));
		}
		
		[Theory]
		[InlineData(1, 2, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2)]
		[InlineData(1, 2, 2, 0, 0, 10, 0, 2, 0, 8, 0, 0, 2, 5, 0, 0, 0, 1, 12, 12)]
		[InlineData(1, 2, 1, 2, 3, 4, 2, 3, 4, 1, 3, 4, 1, 2, 4, 1, 2, 3, 9, 9)]
		public void MultiplyVector2(
			float x, float y,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44,
			float ex, float ey
		) {
			// Variables
			Matrix a = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Vector2 b = new Vector2(x, y);
			Vector2 e = new Vector2(ex, ey);
			
			Assert.Equal(e, Mathx.Multiply(ref a, ref b));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 3, 0, 0, 0, 1)]
		[InlineData(1, 2, 0, 1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(-10, 10, -0.5, 1, 0, 0, -10, 0, 1, 0, 10, 0, 0, 1, -0.5, 0, 0, 0, 1)]
		public void CreateTranslation(
			float x, float y, float z,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Vector3 a = new Vector3(x, y, z);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			Assert.Equal(e, Matrix.CreateTranslation(ref a));
		}
		
		[Theory]
		[InlineData(10, 10, 0.1, 100, 0.2, 0, 0, 0, 0, 0.2, 0, 0, 0, 0, -0.02002002, -1.002002, 0, 0, 0, 1)]
		[InlineData(20, 20, 0.3, 1000, 0.1, 0, 0, 0, 0, 0.1, 0, 0, 0, 0, -0.0020006, -1.0006, 0, 0, 0, 1)]
		public void CreateOrthographic(
			float width, float height, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix a = Matrix.CreateOrthographic(width, height, near, far);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
		}
		
		[Theory]
		[InlineData(4, 8, 1, 100, 0.3, 1000, 0.5, 0, 0, -3, 0, 0.02020202, 0, -1.020202, 0, 0, -0.0020006, -1.0006, 0, 0, 0, 1)]
		[InlineData(-8, 10, -1, 1, 0.1, 100, 0.1111111, 0, 0, -0.1111111, 0, 1, 0, 0, 0, 0, -0.02002002, -1.002002, 0, 0, 0, 1)]
		public void CreateOrthographicOffCenter(
			float left, float right, float top, float bottom, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix a = Matrix.CreateOrthographic(left, right, top, bottom, near, far);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
		}
		
		[Theory]
		[InlineData(90, 0.75, 1, 10, 1.333333, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1.222222, -2.222222, 0, 0, -1, 0)]
		[InlineData(60, 1.777778, 0.1, 100, 0.9742786, 0, 0, 0, 0, 1.732051, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		[InlineData(120, 1.461530, 0.1, 100, 0.3950291, 0, 0, 0, 0, 0.5773502, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		public void CreatePerspective(
			float fov, float aspect, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix a = Matrix.CreatePerspective(fov, aspect, near, far);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a, 0.00001f));
		}
		
		[Theory]
		[InlineData(-10, 10, -5, 5, 0.1, 100, 0.01, 0, 0, 0, 0, 0.02, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		[InlineData(-0.1, 0.1, -0.1, 0.1, 0.1, 100, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		[InlineData(-0.2, 0.1, -0.1, 0.2, 0.1, 100, 0.6666666, 0, -0.3333333, 0, 0, 0.6666666, 0.3333333, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		public void CreatePerspectiveOffCenter(
			float left, float right, float top, float bottom, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix a = Matrix.CreatePerspective(left, right, top, bottom, near, far);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a, 0.00001f));
		}
		
		[Theory]
		[InlineData(1, 2, 3, 0, 0, 0, 0, 1, 0, -0.9486833, -0.1690309, -0.2672612, 1, 0, 0.8451543, -0.5345225, 2, 0.3162278, -0.5070925, -0.8017837, 3, 0, 0, 0, 1)]
		[InlineData(-1, 1, -1, 1, 8, 2, 0, 1, 1, -0.8164966, -0.5184759, 0.2540002, -1, 0.4082483, -0.2073904, 0.8890009, 1, -0.4082483, 0.8295614, 0.3810004, -1, 0, 0, 0, 1)]
		[InlineData(0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)]
		[InlineData(1, 2, 3, 1, 2, 3, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 2, 0, 0, 1, 3, 0, 0, 0, 1)]
		public void CreateLookAt(
			float fx, float fy, float fz,
			float tx, float ty, float tz,
			float ux, float uy, float uz,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix a = Matrix.CreateLookAt(
				new Vector3(fx, fy, fz),
				new Vector3(tx, ty, tz),
				new Vector3(ux, uy, uz)
			);
			Matrix e = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			this.output.WriteLine("Expected:");
			this.output.WriteLine(e.ToString());
			this.output.WriteLine("Actual:");
			this.output.WriteLine(a.ToString());
			
			Assert.True(Mathx.Approx(ref e, ref a));
		}
		
		[Fact]
		public void Lerp() {
			for(int i = 0; i < 25; i++) {
				// Variables
				float t = Random.Value;
				Matrix a = new Matrix(
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One)
				);
				Matrix b = new Matrix(
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One),
					Random.Range(-10*Vector4.One, 10*Vector4.One)
				);
				Matrix e = new Matrix(
					Mathx.Lerp(ref a.row1, ref b.row1, t),
					Mathx.Lerp(ref a.row2, ref b.row2, t),
					Mathx.Lerp(ref a.row3, ref b.row3, t),
					Mathx.Lerp(ref a.row4, ref b.row4, t)
				);
				
				Mathx.Lerp(ref a, ref b, t, out a);
				
				this.output.WriteLine("Expected:");
				this.output.WriteLine(e.ToString());
				this.output.WriteLine("Actual:");
				this.output.WriteLine(a.ToString());
				
				Assert.True(Mathx.Approx(ref e, ref a));
			}
		}
	}
}

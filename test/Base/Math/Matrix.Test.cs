
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	// TRACK: 637 tests
	public class MatrixTest {
		#region Public Test Methods
		
		[Fact]
		public void Constructor_Identity_ReturnsMatrix() {
			// Variables
			Matrix matrix = Matrix.Identity;
			(
				float, float, float, float,
				float, float, float, float,
				float, float, float, float,
				float, float, float, float
			) expected = (
				1, 0, 0, 0,
				0, 1, 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1
			);
			(
				float, float, float, float,
				float, float, float, float,
				float, float, float, float,
				float, float, float, float
			) actual = (
				matrix.A11, matrix.A12, matrix.A13, matrix.A14,
				matrix.A21, matrix.A22, matrix.A23, matrix.A24,
				matrix.A31, matrix.A32, matrix.A33, matrix.A34,
				matrix.A41, matrix.A42, matrix.A43, matrix.A44
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Zero_ReturnsMatrix() {
			// Variables
			Matrix matrix = Matrix.Zero;
			(
				float, float, float, float,
				float, float, float, float,
				float, float, float, float,
				float, float, float, float
			) expected = (
				0, 0, 0, 0,
				0, 0, 0, 0,
				0, 0, 0, 0,
				0, 0, 0, 0
			);
			(
				float, float, float, float,
				float, float, float, float,
				float, float, float, float,
				float, float, float, float
			) actual = (
				matrix.A11, matrix.A12, matrix.A13, matrix.A14,
				matrix.A21, matrix.A22, matrix.A23, matrix.A24,
				matrix.A31, matrix.A32, matrix.A33, matrix.A34,
				matrix.A41, matrix.A42, matrix.A43, matrix.A44
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Row1_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.row1;
			(float, float, float, float) expected = (1, 2, 3, 4);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Row2_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.row2;
			(float, float, float, float) expected = (5, 6, 7, 8);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Row3_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.row3;
			(float, float, float, float) expected = (9, 10, 11, 12);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Row4_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.row4;
			(float, float, float, float) expected = (13, 14, 15, 16);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Column1_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.Column1;
			(float, float, float, float) expected = (1, 5, 9, 13);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Column2_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.Column2;
			(float, float, float, float) expected = (2, 6, 10, 14);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Column3_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.Column3;
			(float, float, float, float) expected = (3, 7, 11, 15);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Constructor_Column4_ReturnsVector() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 row = matrix.Column4;
			(float, float, float, float) expected = (4, 8, 12, 16);
			(float, float, float, float) actual = (
				row.x,
				row.y,
				row.z,
				row.w
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Add_TwoMatrices_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			Matrix other = this.CreateDefaultMatrixB();
			Matrix expected = new Matrix(
				2, 4, 6, 5,
				7, 9, 8, 10,
				12, 11, 13, 15,
				14, 16, 18, 17
			);
			
			Matrix.Add(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Subtract_TwoMatrices_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			Matrix other = this.CreateDefaultMatrixB();
			Matrix expected = new Matrix(
				0, 0, 0, 3,
				3, 3, 6, 6,
				6, 9, 9, 9,
				12, 12, 12, 15
			);
			
			Matrix.Subtract(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Multiply_TwoMatrices_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			Matrix other = this.CreateDefaultMatrixB();
			Matrix expected = new Matrix(
				18, 19, 23, 18,
				46, 51, 59, 46,
				74, 83, 95, 74,
				102, 115, 131, 102
			);
			
			Matrix.Multiply(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Multiply_MatrixAndVector4_ReturnsVector4() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 actual = new Vector4(1, 2, 3, 4);
			Vector4 expected = new Vector4(30, 70, 110, 150);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Multiply_MatrixAndVector3_ReturnsVector3() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 expected = new Vector3(18, 46, 74);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Multiply_MatrixAndVector2_ReturnsVector2() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector2 actual = new Vector2(1, 2);
			Vector2 expected = new Vector2(9, 25);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Multiply_MatrixAndScalar_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			float scalar = 4.0f;
			Matrix expected = new Matrix(
				4, 8, 12, 16,
				20, 24, 28, 32,
				36, 40, 44, 48,
				52, 56, 60, 64
			);
			
			Matrix.Multiply(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Transpose_Matrix_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			Matrix expected = new Matrix(
				1, 5, 9, 13,
				2, 6, 10, 14,
				3, 7, 11, 15,
				4, 8, 12, 16
			);
			
			Matrix.Transpose(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Transpose_IdentityMatrix_ReturnsMatrix() {
			// Variables
			Matrix actual = Matrix.Identity;
			Matrix expected = Matrix.Identity;
			
			Matrix.Transpose(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Negate_Matrix_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			Matrix expected = new Matrix(
				-1, -2, -3, -4,
				-5, -6, -7, -8,
				-9, -10, -11, -12,
				-13, -14, -15, -16
			);
			
			Matrix.Negate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Divide_MatrixAndScalar_ReturnsMatrix() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			float scalar = 4.0f;
			Matrix expected = new Matrix(
				0.25f, 0.5f, 0.75f, 1.0f,
				1.25f, 1.5f, 1.75f, 2.0f,
				2.25f, 2.5f, 2.75f, 3.0f,
				3.25f, 3.5f, 3.75f, 4.0f
			);
			
			Matrix.Divide(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void GetDeterminant_MatrixA_Returns0() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			float expected = 0.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void GetDeterminant_IdentityMatrix_Returns1() {
			// Variables
			Matrix matrix = Matrix.Identity;
			float expected = 1.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void GetDeterminant_MatrixC_ReturnsNonZeroFloat() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixC();
			float expected = 178.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Invert_Matrix_ReturnMatrix Test Data
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
			0, 2, 4, 0,
			2, 3, 3, 1,
			4, 2, 3, 0,
			0, 1, 0, 1,
			
			0, -0.5f, 0.5f, 0.5f,
			-1.5, 4, -2, -4,
			1, -2, 1, 2,
			1.5, -4, 2, 5
		)]
		#endregion // Invert_Matrix_ReturnMatrix Test Data
		public void Invert_Matrix_ReturnsMatrix(
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
			Matrix actual = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix expected = new Matrix(
				b11, b12, b13, b14,
				b21, b22, b23, b24,
				b31, b32, b33, b34,
				b41, b42, b43, b44
			);
			
			Matrix.Invert(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void Invert_MatrixAUninvertable_ThrowsException() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			
			Assert.Throws<System.Exception>(() => { Matrix.Invert(ref actual, out actual); });
		}
		
		[Fact]
		public void ToArray_Matrix_ReturnsArray() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			float[] expected = new float[] {
				1, 2, 3, 4,
				5, 6, 7, 8,
				9, 10, 11, 12,
				13, 14, 15, 16
			};
			float[] actual = matrix.ToArray();
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void CreateScale_Vector_ReturnsMatrix() {
			// Variables
			Vector3 scalars = new Vector3(0.5f, 2.0f, 10.0f);
			Matrix expected = new Matrix(
				0.5f, 0, 0, 0,
				0, 2, 0, 0,
				0, 0, 10, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateScale(scalars);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region CreateLookAt_Vectors_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3,
			0, 0, 0,
			0, 1, 0,
			
			-0.9486834, -0.16903086, -0.26726124, 1,
			0, 0.8451543, -0.5345225, 2,
			0.3162278, -0.5070926, -0.8017837, 3,
			0, 0, 0, 1
		)]
		[InlineData(
			-1, 1, -1,
			1, 8, 2,
			0, 1, 1,
			
			-0.8164966, -0.51847583, 0.25400025, -1,
			0.40824828, -0.20739037, 0.8890009, 1,
			-0.40824828, 0.82956135, 0.38100037, -1,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 0,
			0, 0, 0,
			1, 0, 0,
			
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 2, 3,
			1, 2, 3,
			1, 1, 1,
			
			1, 0, 0, 1,
			0, 1, 0, 2,
			0, 0, 1, 3,
			0, 0, 0, 1
		)]
		#endregion // CreateLookAt_Vectors_ReturnsMatrix Test Data
		public void CreateLookAt_Vectors_ReturnsMatrix(
			float fx, float fy, float fz,
			float tx, float ty, float tz,
			float ux, float uy, float uz,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix actual = Matrix.CreateLookAt(
				new Vector3(fx, fy, fz),
				new Vector3(tx, ty, tz),
				new Vector3(ux, uy, uz)
			);
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void CreateTranslation_Vector3_ReturnsMatrix() {
			// Variables
			Vector3 vector = new Vector3(0.5f, 2.0f, 10.0f);
			Matrix expected = new Matrix(
				1, 0, 0, 0.5f,
				0, 1, 0, 2,
				0, 0, 1, 10,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateTranslation(vector);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
		
		#region Private Methods
		
		private Matrix CreateDefaultMatrixA() {
			return new Matrix(
				1, 2, 3, 4,
				5, 6, 7, 8,
				9, 10, 11, 12,
				13, 14, 15, 16
			);
		}
		
		private Matrix CreateDefaultMatrixB() {
			return new Matrix(
				1, 2, 3, 1,
				2, 3, 1, 2,
				3, 1, 2, 3,
				1, 2, 3, 1
			);
		}
		
		private Matrix CreateDefaultMatrixC() {
			return new Matrix(
				1, 4, 10, 8,
				1, 3, 9, 0,
				0, 2, 4, 4,
				8, 3, 8, 1
			);
		}
		
		#endregion // Private Methods
		
		// [Theory]
		// [InlineData(
		// 	30 * Mathx.DegToRad, 0, 0,
		// 	1, 0, 0, 0,
		// 	0, 0.8660254037f, -0.5f, 0,
		// 	0, 0.5f, 0.8660254037f, 0,
		// 	0, 0, 0, 1
		// )]
		// [InlineData(
		// 	0, 60 * Mathx.DegToRad, 0,
		// 	0.5f, 0, 0.8660254037f, 0,
		// 	0, 1, 0, 0,
		// 	-0.8660254037f, 0, 0.5f, 0,
		// 	0, 0, 0, 1
		// )]
		// [InlineData(
		// 	0, 0, 129 * Mathx.DegToRad,
		// 	-0.6293203910f, -0.7771459614f, 0, 0,
		// 	0.7771459614f, -0.6293203910f, 0, 0,
		// 	0, 0, 1, 0,
		// 	0, 0, 0, 1
		// )]
		// [InlineData(
		// 	30 * Mathx.DegToRad, 60 * Mathx.DegToRad, 129 * Mathx.DegToRad,
		// 	-0.3146601955f, -0.9455318679f, -0.08341731255f, 0,
		// 	0.3885729807f, -0.2084933732f, 0.8975196666f, 0,
		// 	-0.8660254037f, 1/4f, 0.4330127018f, 0,
		// 	0, 0, 0, 1
		// )]
		// public void Rotations(
		// 	float xrot, float yrot, float zrot,
		// 	float b11, float b12, float b13, float b14,
		// 	float b21, float b22, float b23, float b24,
		// 	float b31, float b32, float b33, float b34,
		// 	float b41, float b42, float b43, float b44
		// ) {
		// 	// Variables
		// 	Matrix e = new Matrix(
		// 		b11, b12, b13, b14,
		// 		b21, b22, b23, b24,
		// 		b31, b32, b33, b34,
		// 		b41, b42, b43, b44
		// 	);
		// 	Matrix a = (
		// 		Matrix.CreateRotationZ(zrot) *
		// 		Matrix.CreateRotationY(yrot) *
		// 		Matrix.CreateRotationX(xrot)
		// 	);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a, 0.000001f));
		// }
		
		// [Fact]
		// public void CreateRotationFromAxisAngle() {
		// 	// Variables
		// 	Matrix a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitX, 30 * Mathx.DegToRad);
		// 	Matrix e = Matrix.CreateRotationX(30 * Mathx.DegToRad);
			
		// 	this.output.WriteLine("Expected X:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual X:");
		// 	this.output.WriteLine(a.ToString());
		// 	this.output.WriteLine("---------------");
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
			
		// 	a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitY, 30 * Mathx.DegToRad);
		// 	e = Matrix.CreateRotationY(30 * Mathx.DegToRad);
			
		// 	this.output.WriteLine("Expected Y:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual Y:");
		// 	this.output.WriteLine(a.ToString());
		// 	this.output.WriteLine("---------------");
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
			
		// 	a = Matrix.CreateRotationFromAxisAngle(Vector3.UnitZ, 30 * Mathx.DegToRad);
		// 	e = Matrix.CreateRotationZ(30 * Mathx.DegToRad);
			
		// 	this.output.WriteLine("Expected Z:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual Z:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
			
		// 	a = Matrix.CreateRotationFromAxisAngle(new Vector3(1, 1, 1), 30 * Mathx.DegToRad);
		// 	e = new Matrix(
		// 		0.9106836025f, -0.244016935f, 1/3f, 0.0f,
		// 		1/3f, 0.9106836025f, -0.244016935f, 0.0f,
		// 		-0.244016935f, 1/3f, 0.9106836025f, 0.0f,
		// 		0.0f, 0.0f, 0.0f, 1.0f
		// 	);
			
		// 	this.output.WriteLine("Expected One:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual One:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
			
		// 	a = Matrix.CreateRotationFromAxisAngle(new Vector3(1, 2, 3), 30 * Mathx.DegToRad);
		// 	e = new Matrix(
		// 		0.8755950178f, -0.3817526348f, 0.2959700839f, 0,
		// 		0.4200310909f, 0.9043038598f, -0.07621293686f, 0,
		// 		-0.2385523998f, 0.1910483050f, 0.9521519299f, 0,
		// 		0, 0, 0, 1
		// 	);
			
		// 	this.output.WriteLine("Expected 1,2,3:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual 1,2,3:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
		
		// [Theory]
		// [InlineData(10, 10, 0.1, 100, 0.2, 0, 0, 0, 0, 0.2, 0, 0, 0, 0, -0.02002002, -1.002002, 0, 0, 0, 1)]
		// [InlineData(20, 20, 0.3, 1000, 0.1, 0, 0, 0, 0, 0.1, 0, 0, 0, 0, -0.0020006, -1.0006, 0, 0, 0, 1)]
		// public void CreateOrthographic(
		// 	float width, float height, float near, float far,
		// 	float a11, float a12, float a13, float a14,
		// 	float a21, float a22, float a23, float a24,
		// 	float a31, float a32, float a33, float a34,
		// 	float a41, float a42, float a43, float a44
		// ) {
		// 	// Variables
		// 	Matrix a = Matrix.CreateOrthographic(width, height, near, far);
		// 	Matrix e = new Matrix(
		// 		a11, a12, a13, a14,
		// 		a21, a22, a23, a24,
		// 		a31, a32, a33, a34,
		// 		a41, a42, a43, a44
		// 	);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
		
		// [Theory]
		// [InlineData(4, 8, 1, 100, 0.3, 1000, 0.5, 0, 0, -3, 0, 0.02020202, 0, -1.020202, 0, 0, -0.0020006, -1.0006, 0, 0, 0, 1)]
		// [InlineData(-8, 10, -1, 1, 0.1, 100, 0.1111111, 0, 0, -0.1111111, 0, 1, 0, 0, 0, 0, -0.02002002, -1.002002, 0, 0, 0, 1)]
		// public void CreateOrthographicOffCenter(
		// 	float left, float right, float top, float bottom, float near, float far,
		// 	float a11, float a12, float a13, float a14,
		// 	float a21, float a22, float a23, float a24,
		// 	float a31, float a32, float a33, float a34,
		// 	float a41, float a42, float a43, float a44
		// ) {
		// 	// Variables
		// 	Matrix a = Matrix.CreateOrthographic(left, right, top, bottom, near, far);
		// 	Matrix e = new Matrix(
		// 		a11, a12, a13, a14,
		// 		a21, a22, a23, a24,
		// 		a31, a32, a33, a34,
		// 		a41, a42, a43, a44
		// 	);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a));
		// }
		
		// [Theory]
		// [InlineData(90, 0.75, 1, 10, 1.333333, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1.222222, -2.222222, 0, 0, -1, 0)]
		// [InlineData(60, 1.777778, 0.1, 100, 0.9742786, 0, 0, 0, 0, 1.732051, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		// [InlineData(120, 1.461530, 0.1, 100, 0.3950291, 0, 0, 0, 0, 0.5773502, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		// public void CreatePerspective(
		// 	float fov, float aspect, float near, float far,
		// 	float a11, float a12, float a13, float a14,
		// 	float a21, float a22, float a23, float a24,
		// 	float a31, float a32, float a33, float a34,
		// 	float a41, float a42, float a43, float a44
		// ) {
		// 	// Variables
		// 	Matrix a = Matrix.CreatePerspective(fov, aspect, near, far);
		// 	Matrix e = new Matrix(
		// 		a11, a12, a13, a14,
		// 		a21, a22, a23, a24,
		// 		a31, a32, a33, a34,
		// 		a41, a42, a43, a44
		// 	);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a, 0.00001f));
		// }
		
		// [Theory]
		// [InlineData(-10, 10, -5, 5, 0.1, 100, 0.01, 0, 0, 0, 0, 0.02, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		// [InlineData(-0.1, 0.1, -0.1, 0.1, 0.1, 100, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		// [InlineData(-0.2, 0.1, -0.1, 0.2, 0.1, 100, 0.6666666, 0, -0.3333333, 0, 0, 0.6666666, 0.3333333, 0, 0, 0, -1.002002, -0.2002002, 0, 0, -1, 0)]
		// public void CreatePerspectiveOffCenter(
		// 	float left, float right, float top, float bottom, float near, float far,
		// 	float a11, float a12, float a13, float a14,
		// 	float a21, float a22, float a23, float a24,
		// 	float a31, float a32, float a33, float a34,
		// 	float a41, float a42, float a43, float a44
		// ) {
		// 	// Variables
		// 	Matrix a = Matrix.CreatePerspective(left, right, top, bottom, near, far);
		// 	Matrix e = new Matrix(
		// 		a11, a12, a13, a14,
		// 		a21, a22, a23, a24,
		// 		a31, a32, a33, a34,
		// 		a41, a42, a43, a44
		// 	);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(Mathx.Approx(ref e, ref a, 0.00001f));
		// }
		
		// [Fact]
		// public void Lerp() {
		// 	for(int i = 0; i < 25; i++) {
		// 		// Variables
		// 		float t = Random.Value;
		// 		Matrix a = new Matrix(
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One)
		// 		);
		// 		Matrix b = new Matrix(
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One),
		// 			Random.Range(-10*Vector4.One, 10*Vector4.One)
		// 		);
		// 		Matrix e = new Matrix(
		// 			Mathx.Lerp(ref a.row1, ref b.row1, t),
		// 			Mathx.Lerp(ref a.row2, ref b.row2, t),
		// 			Mathx.Lerp(ref a.row3, ref b.row3, t),
		// 			Mathx.Lerp(ref a.row4, ref b.row4, t)
		// 		);
				
		// 		Mathx.Lerp(ref a, ref b, t, out a);
				
		// 		this.output.WriteLine("Expected:");
		// 		this.output.WriteLine(e.ToString());
		// 		this.output.WriteLine("Actual:");
		// 		this.output.WriteLine(a.ToString());
				
		// 		Assert.True(Mathx.Approx(ref e, ref a));
		// 	}
		// }
	}
}

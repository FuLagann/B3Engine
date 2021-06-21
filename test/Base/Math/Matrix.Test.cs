
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Matrix"/> structure to make sure it works correctly. Contains 70 tests</summary>
	public class MatrixTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Identity"/> functionality.
		/// Checks the identity matrix to see if its correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Zero"/> functionality.
		/// Checks the zero matrix to see if its correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.row1"/> functionality.
		/// Checks to see if the first row of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.row2"/> functionality.
		/// Checks to see if the second row of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.row3"/> functionality.
		/// Checks to see if the third row of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.row4"/> functionality.
		/// Checks to see if the fourth row of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Column1"/> functionality.
		/// Checks to see if the first column of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Column2"/> functionality.
		/// Checks to see if the second column of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Column3"/> functionality.
		/// Checks to see if the third column of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Column4"/> functionality.
		/// Checks to see if the fourth column of the matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Add(Matrix)"/> functionality.
		/// Adds two matrices together and checks to see if the resulting matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Subtract(Matrix)"/> functionality.
		/// Subtracts two matrices from each other and checks to see if the resulting matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Multiply(Matrix)"/> functionality.
		/// Multiplies two matrices together and checks to see if the resulting matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Multiply(Vector4)"/> functionality.
		/// Multiplies a matrix with a vector and checks to see if the resulting vector is correct
		/// </summary>
		[Fact]
		public void Multiply_MatrixAndVector4_ReturnsVector4() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector4 actual = new Vector4(1, 2, 3, 4);
			Vector4 expected = new Vector4(30, 70, 110, 150);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Multiply(Vector3)"/> functionality.
		/// Multiplies a matrix with a vector and checks to see if the resulting vector is correct
		/// </summary>
		[Fact]
		public void Multiply_MatrixAndVector3_ReturnsVector3() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector3 actual = new Vector3(1, 2, 3);
			Vector3 expected = new Vector3(18, 46, 74);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Multiply(Vector2)"/> functionality.
		/// Multiplies a matrix with a vector and checks to see if the resulting vector is correct
		/// </summary>
		[Fact]
		public void Multiply_MatrixAndVector2_ReturnsVector2() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			Vector2 actual = new Vector2(1, 2);
			Vector2 expected = new Vector2(9, 25);
			
			Matrix.Multiply(ref matrix, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Multiply(float))"/> functionality.
		/// Multiplies a matrix with a scalar and checks to see if the resulting matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Transpose"/> functionality.
		/// Transposes the matrix and checks to see if its correct.
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Transpose"/> functionality.
		/// Transposes the identity matrix and checks to see if its still the identity matrix
		/// </summary>
		[Fact]
		public void Transpose_IdentityMatrix_ReturnsMatrix() {
			// Variables
			Matrix actual = Matrix.Identity;
			Matrix expected = Matrix.Identity;
			
			Matrix.Transpose(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Negate"/> functionality.
		/// Negates the matrix and checks to see if its correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Divide(float)"/> functionality.
		/// Divides the matrix with a scalar and checks to see if the resulting matrix is correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.GetDeterminant"/> functionality.
		/// Gets the determinant from a non-inversible matrix and checks to see if its zero
		/// </summary>
		[Fact]
		public void GetDeterminant_MatrixA_Returns0() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixA();
			float expected = 0.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.GetDeterminant"/> functionality.
		/// Gets the determinant from the identity matrix and checks to see if its one
		/// </summary>
		[Fact]
		public void GetDeterminant_IdentityMatrix_Returns1() {
			// Variables
			Matrix matrix = Matrix.Identity;
			float expected = 1.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.GetDeterminant"/> functionality.
		/// Gets the determinant from an inversible matrix and checks to see if its not zero
		/// </summary>
		[Fact]
		public void GetDeterminant_MatrixC_ReturnsNonZeroFloat() {
			// Variables
			Matrix matrix = this.CreateDefaultMatrixC();
			float expected = 178.0f;
			float actual;
			
			Matrix.GetDeterminant(ref matrix, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Invert"/> functionality.
		/// Inverts the matrix and checks to see if its correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Invert"/> functionality.
		/// Inverts a non-invertible matrix and checks to see if it throws an exception
		/// </summary>
		[Fact]
		public void Invert_MatrixANoninvertible_ThrowsException() {
			// Variables
			Matrix actual = this.CreateDefaultMatrixA();
			
			Assert.Throws<System.Exception>(() => { Matrix.Invert(ref actual, out actual); });
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.ToArray"/> functionality.
		/// Converts the matrix into an array of size 16 and checks to see if it's correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateScale(Vector3)"/> functionality.
		/// Creates a scalable matrix using the vector and checks to see if it's correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateLookAt(Vector3, Vector3, Vector3)"/> functionality.
		/// Creates a look at matrix and checks to see if it's correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateTranslation(Vector3)"/> functionality.
		/// Creates a translation matrix and checks to see if it's correct
		/// </summary>
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
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Approx(Matrix, Matrix)"/> functionality.
		/// Checks to see if the two matrices that are approximately close to each other
		/// are not equal to each other to set up the test for <see cref="B3.Testing.MatrixTest.Approx_TwoMatrices_ReturnTrue"/>
		/// </summary>
		[Fact]
		public void Approx_TwoMatrices_ReturnsNotEqual() {
			// Variables
			Matrix notExpected = this.CreateDefaultMatrixA();
			Matrix actual = 1.0000001f * this.CreateDefaultMatrixA();
			
			Assert.NotEqual(notExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Approx(Matrix, Matrix)"/> functionality.
		/// Checks to see if the two matrices are approximately close to each other
		/// </summary>
		[Fact]
		public void Approx_TwoMatrices_ReturnTrue() {
			// Variables
			Matrix original = this.CreateDefaultMatrixA();
			Matrix approx = 1.0000001f * this.CreateDefaultMatrixA();
			bool actual = Matrix.Approx(original, approx, 0.00001f);
			
			Assert.True(actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateOrthographic(float, float, float, float)"/> functionality.
		/// Creates an orthographic projection matrix and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreateOrthographic_Parameters_ReturnsMatrix Test Data
		[InlineData(
			10, 10, 0.1, 100,
			0.2, 0, 0, 0,
			0, 0.2, 0, 0,
			0, 0, -0.02002002, -1.002002,
			0, 0, 0, 1
		)]
		[InlineData(
			20, 20, 0.3, 1000,
			0.1, 0, 0, 0,
			0, 0.1, 0, 0,
			0, 0, -0.0020006, -1.0006001,
			0, 0, 0, 1
		)]
		#endregion // CreateOrthographic_Parameters_ReturnsMatrix Test Data
		public void CreateOrthographic_Parameters_ReturnsMatrix(
			float width, float height, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix actual = Matrix.CreateOrthographic(width, height, near, far);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateOrthographicOffCenter(float, float, float, float, float, float)"/> functionality.
		/// Creates an off center orthographic projection matrix and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreateOrthographic_OffCenterParameters_ReturnsMatrix Test Data
		[InlineData(
			4, 8, 1, 100, 0.3, 1000,
			0.5, 0, 0, -3,
			0, 0.02020202, 0, -1.020202,
			0, 0, -0.0020006, -1.0006001,
			0, 0, 0, 1
		)]
		[InlineData(
			-8, 10, -1, 1, 0.1, 100,
			0.11111111, 0, 0, -0.11111111,
			0, 1, 0, 0,
			0, 0, -0.02002002, -1.002002,
			0, 0, 0, 1
		)]
		#endregion // CreateOrthographic_OffCenterParameters_ReturnsMatrix Test Data
		public void CreateOrthographicOffCenter_Parameters_ReturnsMatrix(
			float left, float right, float top, float bottom, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix actual = Matrix.CreateOrthographicOffCenter(left, right, top, bottom, near, far);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreatePerspective(float, float, float, float)"/> functionality.
		/// Creates a perspective projection matrix and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreatePerspective_Parameters_ReturnsMatrix Test Data
		[InlineData(
			90, 0.75, 1, 10,
			1.3333334, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, -1.2222222, -2.2222223,
			0, 0, -1, 0
		)]
		[InlineData(
			60, 1.777778, 0.1, 100,
			0.97427845, 0, 0, 0,
			0, 1.7320509, 0, 0,
			0, 0, -1.002002, -0.2002002,
			0, 0, -1, 0
		)]
		[InlineData(
			120, 1.461530, 0.1, 100,
			0.3950314, 0, 0, 0,
			0, 0.57735026, 0, 0,
			0, 0, -1.002002, -0.2002002,
			0, 0, -1, 0
		)]
		#endregion // CreatePerspective_Parameters_ReturnsMatrix Test Data
		public void CreatePerspective_Parameters_ReturnsMatrix(
			float fov, float aspect, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix actual = Matrix.CreatePerspective(fov, aspect, near, far);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreatePerspectiveOffCenter(float, float, float, float, float, float)"/> functionality.
		/// Creates an off center perspective projection matrix and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreatePerspective_OffCenterParameters_ReturnsMatrix Test Data
		[InlineData(
			-10, 10, -5, 5, 0.1, 100,
			0.01, 0, 0, 0,
			0, 0.02, 0, 0,
			0, 0, -1.002002, -0.2002002,
			0, 0, -1, 0
		)]
		[InlineData(
			-0.1, 0.1, -0.1, 0.1, 0.1, 100,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, -1.002002, -0.2002002,
			0, 0, -1, 0
		)]
		[InlineData(
			-0.2, 0.1, -0.1, 0.2, 0.1, 100,
			0.6666666, 0, -0.3333333, 0,
			0, 0.6666666, 0.3333333, 0,
			0, 0, -1.002002, -0.2002002,
			0, 0, -1, 0
		)]
		#endregion // CreatePerspective_OffCenterParameters_ReturnsMatrix Test Data
		public void CreatePerspective_OffCenterParameters_ReturnsMatrix(
			float left, float right, float top, float bottom, float near, float far,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Matrix actual = Matrix.CreatePerspectiveOffCenter(left, right, top, bottom, near, far);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.Adjugate"/> functionality.
		/// Adjugates the matrix and checks to see if it's correct
		/// </summary>
		[Theory]
		#region Adjugate_Matrix_ReturnsMatrix Test Data
		[InlineData(
			1, 2, 3, 4,
			5, 6, 7, 8,
			9, 10, 11, 12,
			13, 14, 15, 16,
			
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0
		)]
		[InlineData(
			1, 4, 10, 8,
			1, 3, 9, 0,
			0, 2, 4, 4,
			8, 3, 8, 1,
			
			6, -20, -18, 24,
			-260, 36, 513, 28,
			86, 10, -169, -12,
			44, -28, -43, -2
		)]
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
		#endregion // Adjugate_Matrix_ReturnsMatrix Test Data
		public void Adjugate_Matrix_ReturnsMatrix(
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
			
			Matrix.Adjugate(ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateFromQuaternion(Quaternion)"/> functionality.
		/// Creates a matrix from the quaternion provided and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreateFromQuaternion_Quaternion_ReturnsMatrix Test Data
		[InlineData(
			90, 0, 0,
			1, 0, 0, 0,
			0, 0, -1, 0,
			0, 1, 0, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 90, 0,
			0, 0, 1, 0,
			0, 1, 0, 0,
			-1, 0, 0, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 90,
			0, -1, 0, 0,
			1, 0, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			45.0, 24.0, 10.0,
			0.949609, 0.12460141, 0.28760624, 0,
			0.12278779, 0.69636416, -0.7071068, 0,
			-0.2883852, 0.7067895, 0.6459741, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			11.25, 0, 128,
			-0.6156615, -0.7880108, 0, 0,
			0.7728694, -0.6038318, -0.1950903, 0,
			0.1537333, -0.1201096, 0.9807853, 0,
			0, 0, 0, 1
		)]
		#endregion // CreateFromQuaternion_Quaternion_ReturnsMatrix Test Data
		public void CreateFromQuaternion_Quaternion_ReturnsMatrix(
			float x, float y, float z,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expectedMatrix = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Quaternion quaternion = Quaternion.FromEulerAnglesDeg(x, y, z);
			Matrix actualMatrix = Matrix.CreateFromQuaternion(quaternion);
			bool expected = Matrix.Approx(expectedMatrix, actualMatrix);
			
			Assert.True(expected);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationX(float)"/> functionality.
		/// Creates a rotation matrix around the x-axis by pi over 2
		/// </summary>
		[Fact]
		public void CreateRotationX_PiOver2Angle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				1, 0, 0, 0,
				0, 0.70710677f, -0.70710677f, 0,
				0, 0.70710677f, 0.70710677f, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationX(Mathx.Pi / 4.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationY(float)"/> functionality.
		/// Creates a rotation matrix around the y-axis by pi over 2
		/// </summary>
		[Fact]
		public void CreateRotationY_PiOver2Angle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				0.70710677f, 0, 0.70710677f, 0,
				0, 1, 0, 0,
				-0.70710677f, 0, 0.70710677f, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationY(Mathx.Pi / 4.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationZ(float)"/> functionality.
		/// Creates a rotation matrix around the z-axis by pi over 2
		/// </summary>
		[Fact]
		public void CreateRotationZ_PiOver2Angle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				0.70710677f, -0.70710677f, 0, 0,
				0.70710677f, 0.70710677f, 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationZ(Mathx.Pi / 4.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationXDeg(float)"/> functionality.
		/// Creates a rotation matrix around the x-axis by 45 degrees
		/// </summary>
		[Fact]
		public void CreateRotationXDeg_45DegreeAngle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				1, 0, 0, 0,
				0, 0.70710677f, -0.70710677f, 0,
				0, 0.70710677f, 0.70710677f, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationXDeg(45.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationYDeg(float)"/> functionality.
		/// Creates a rotation matrix around the y-axis by 45 degrees
		/// </summary>
		[Fact]
		public void CreateRotationYDeg_45DegreeAngle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				0.70710677f, 0, 0.70710677f, 0,
				0, 1, 0, 0,
				-0.70710677f, 0, 0.70710677f, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationYDeg(45.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationZDeg(float)"/> functionality.
		/// Creates a rotation matrix around the z-axis by 45 degrees
		/// </summary>
		[Fact]
		public void CreateRotationZDeg_45DegreeAngle_ReturnsMatrix() {
			// Variables
			Matrix expected = new Matrix(
				0.70710677f, -0.70710677f, 0, 0,
				0.70710677f, 0.70710677f, 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1
			);
			Matrix actual = Matrix.CreateRotationZDeg(45.0f);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationFromAxisAngle(Vector3, float)"/> functionality.
		/// Creates a rotation matrix around an arbitrary axis and a given angle (in radians) and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreateRotationFromAxisAngle_AxisAndAngle_ReturnsMatrix Test Data
		[InlineData(
			0, 0, 0, 0.21380283,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 0, 0.21380283,
			1, 0, 0, 0,
			0, 0.9772311, -0.21217766, 0,
			0, 0.21217766, 0.9772311, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 1, 0, 0.21380283,
			0.9772311, 0, 0.21217766, 0,
			0, 1, 0, 0,
			-0.21217766, 0, 0.9772311, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 1, 0.21380283,
			0.9772311, -0.21217766, 0, 0,
			0.21217766, 0.9772311, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 1, 1, 0.21380283,
			0.9848207, -0.11491119, 0.13009046, 0,
			0.13009046, 0.9848207, -0.11491119, 0,
			-0.11491119, 0.13009046, 0.9848207, 0,
			0, 0, 0, 1
		)]
		#endregion // CreateRotationFromAxisAngle_AxisAndAngle_ReturnsMatrix Test Data
		public void CreateRotationFromAxisAngle_AxisAndAngle_ReturnsMatrix(
			float x, float y, float z, float theta,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Vector3 axis = new Vector3(x, y, z);
			Matrix actual = Matrix.CreateRotationFromAxisAngle(axis, theta);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Matrix.CreateRotationFromAxisAngleDeg(Vector3, float)"/> functionality.
		/// Creates a rotation matrix around an arbitrary axis and a given angle (in degrees) and checks to see if it's correct
		/// </summary>
		[Theory]
		#region CreateRotationFromAxisAngle_AxisAndAngle_ReturnsMatrix Test Data
		[InlineData(
			0, 0, 0, 12.25,
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 0, 0, 12.25,
			1, 0, 0, 0,
			0, 0.9772311, -0.21217766, 0,
			0, 0.21217766, 0.9772311, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 1, 0, 12.25,
			0.9772311, 0, 0.21217766, 0,
			0, 1, 0, 0,
			-0.21217766, 0, 0.9772311, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			0, 0, 1, 12.25,
			0.9772311, -0.21217766, 0, 0,
			0.21217766, 0.9772311, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1
		)]
		[InlineData(
			1, 1, 1, 12.25,
			0.9848207, -0.11491119, 0.13009046, 0,
			0.13009046, 0.9848207, -0.11491119, 0,
			-0.11491119, 0.13009046, 0.9848207, 0,
			0, 0, 0, 1
		)]
		#endregion // CreateRotationFromAxisAngle_AxisAndAngle_ReturnsMatrix Test Data
		public void CreateRotationFromAxisAngleDeg_AxisAndAngle_ReturnsMatrix(
			float x, float y, float z, float theta,
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) {
			// Variables
			Matrix expected = new Matrix(
				a11, a12, a13, a14,
				a21, a22, a23, a24,
				a31, a32, a33, a34,
				a41, a42, a43, a44
			);
			Vector3 axis = new Vector3(x, y, z);
			Matrix actual = Matrix.CreateRotationFromAxisAngleDeg(axis, theta);
			
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
	}
}

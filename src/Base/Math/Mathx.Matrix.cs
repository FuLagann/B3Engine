
namespace B3 {
	public static partial class Mathx {
		#region Public Static Methods
		
		#region Add Methods
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is added together</param>
		public static void Add(ref Matrix a, ref Matrix b, out Matrix result) { Matrix.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is added together</returns>
		public static Matrix Add(ref Matrix a, ref Matrix b) { return Matrix.Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is subtracting the two given matrices</param>
		public static void Subtract(ref Matrix a, ref Matrix b, out Matrix result) { Matrix.Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is subtracting the two given matrices</returns>
		public static Matrix Subtract(ref Matrix a, ref Matrix b) { return Matrix.Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(float scalar, ref Matrix matrix, out Matrix result) { Matrix.Multiply(scalar, ref matrix, out result); }
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(float scalar, ref Matrix matrix) { return Matrix.Multiply(scalar, ref matrix); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(ref Matrix a, ref Matrix b, out Matrix result) { Matrix.Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(ref Matrix a, ref Matrix b) { return Matrix.Multiply(ref a, ref b); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <param name="result">The resulting divided matrix</param>
		public static void Divide(float scalar, ref Matrix matrix, out Matrix result) { Matrix.Divide(scalar, ref matrix, out result); }
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <returns>Returns the resulting divided matrix</returns>
		public static Matrix Divide(float scalar, ref Matrix matrix) { return Matrix.Divide(scalar, ref matrix); }
		
		#endregion // Divide Methods
		
		#region Transpose Methods
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <param name="result">The resulting transposed matrix</param>
		public static void Transpose(ref Matrix matrix, out Matrix result) { Matrix.Transpose(ref matrix, out result); }
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <returns>Returns the resulting transposed matrix</returns>
		public static Matrix Transpose(ref Matrix matrix) { return Matrix.Transpose(ref matrix); }
		
		#endregion // Transpose Methods
		
		#region Negate Methods
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <param name="result">The resulting negated matrix</param>
		public static void Negate(ref Matrix matrix, out Matrix result) { Matrix.Negate(ref matrix, out result); }
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <returns>Returns the resulting negated matrix</returns>
		public static Matrix Negate(ref Matrix matrix) { return Matrix.Negate(ref matrix); }
		
		#endregion // Negate Methods
		
		#region Adjugate Methods
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <param name="result">The resulting adjugated matrix</param>
		public static void Adjugate(ref Matrix matrix, out Matrix result) { Matrix.Adjugate(ref matrix, out result); }
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <returns>Returns the resulting adjugated matrix</returns>
		public static Matrix Adjugate(ref Matrix matrix) { return Matrix.Adjugate(ref matrix); }
		
		#endregion // Adjugate Methods
		
		#region GetDeterminant Methods
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <param name="result">The resulting determinant</param>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static void GetDeterminant(ref Matrix matrix, out float result) { Matrix.GetDeterminant(ref matrix, out result); }
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <returns>Returns the resulting determinant</returns>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static float GetDeterminant(ref Matrix matrix) { return Matrix.GetDeterminant(ref matrix); }
		
		#endregion // GetDeterminant Methods
		
		#region Invert Methods
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <param name="result">The resulting inverted matrix</param>
		public static void Invert(ref Matrix matrix, out Matrix result) { Matrix.Invert(ref matrix, out result); }
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <returns>Returns the resulting inverted matrix</returns>
		public static Matrix Invert(ref Matrix matrix) { return Matrix.Invert(ref matrix); }
		
		#endregion // Invert Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(ref Matrix a, ref Matrix b, float epsilon, out bool result) { Matrix.Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(ref Matrix a, ref Matrix b, float epsilon) { return Matrix.Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(ref Matrix a, ref Matrix b, out bool result) { Matrix.Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(ref Matrix a, ref Matrix b) { return Matrix.Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Multiply Vectors Methods
		
		#region Vector4 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector4 b, out Vector4 result) { Matrix.Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector4 Multiply(ref Matrix a, ref Vector4 b) { return Matrix.Multiply(ref a, ref b); }
		
		#endregion // Vector4 Methods
		
		#region Vector3 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector3 b, out Vector3 result) { Matrix.Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector3 Multiply(ref Matrix a, ref Vector3 b) { return Matrix.Multiply(ref a, ref b); }
		
		#endregion // Vector3 Methods
		
		#region Vector2 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector2 b, out Vector2 result) { Matrix.Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector2 Multiply(ref Matrix a, ref Vector2 b) { return Matrix.Multiply(ref a, ref b); }
		
		#endregion // Vector2 Methods
		
		#endregion // Multiply Vectors Methods
		
		#region Lerp Methods
		
		/// <summary>Linearly interpolates the from the first matrix and second matrix</summary>
		/// <param name="a">The first matrix to interpolate</param>
		/// <param name="b">The second matrix to interpolate</param>
		/// <param name="t">The time elapsed from the first value towards the second value to get the interpolation</param>
		/// <param name="result">The resulting interpolated matrix</param>
		public static void Lerp(ref Matrix a, ref Matrix b, float t, out Matrix result) { Matrix.Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates the from the first matrix and second matrix</summary>
		/// <param name="a">The first matrix to interpolate</param>
		/// <param name="b">The second matrix to interpolate</param>
		/// <param name="t">The time elapsed from the first value towards the second value to get the interpolation</param>
		/// <returns>Returns the resulting interpolated matrix</returns>
		public static Matrix Lerp(ref Matrix a, ref Matrix b, float t) { return Matrix.Lerp(ref a, ref b, t); }
		
		#endregion // Lerp Methods
		
		#region LerpClamped Methods
		
		/// <summary>Linearly interpolates the from the first matrix and second matrix given a value between 0 and 1</summary>
		/// <param name="a">The first matrix to interpolate</param>
		/// <param name="b">The second matrix to interpolate</param>
		/// <param name="t">The time elapsed from the first matrix towards the second matrix to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">The resulting interpolated matrix</param>
		public static void LerpClamped(ref Matrix a, ref Matrix b, float t, out Matrix result) { Matrix.LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates the from the first matrix and second matrix given a value between 0 and 1</summary>
		/// <param name="a">The first matrix to interpolate</param>
		/// <param name="b">The second matrix to interpolate</param>
		/// <param name="t">The time elapsed from the first matrix towards the second matrix to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the resulting interpolated matrix</returns>
		public static Matrix LerpClamped(ref Matrix a, ref Matrix b, float t) { return Matrix.LerpClamped(ref a, ref b, t); }
		
		#endregion // LerpClamped Methods
		
		#endregion // Public Static Methods
	}
}

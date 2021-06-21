
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 4x4 matrix used for manipulating vectors with rotation, translation, and scale</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Matrix : System.IEquatable<Matrix> {
		#region Field Variables
		// Variables
		/// <summary>The first row of the matrix</summary>
		public Vector4 row1;
		/// <summary>The second row of the matrix</summary>
		public Vector4 row2;
		/// <summary>The third row of the matrix</summary>
		public Vector4 row3;
		/// <summary>The fourth row of the matrix</summary>
		public Vector4 row4;
		/// <summary>The identity matrix that when multiplied with other matrices will not transform the other matrix</summary>
		public static readonly Matrix Identity = new Matrix(
			Vector4.UnitX,
			Vector4.UnitY,
			Vector4.UnitZ,
			Vector4.UnitW
		);
		/// <summary>The zero matrix that contains all zeros witihn the matrix</summary>
		public static readonly Matrix Zero = new Matrix(
			Vector4.Zero,
			Vector4.Zero,
			Vector4.Zero,
			Vector4.Zero
		);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the first columns of the matrix</summary>
		public Vector4 Column1 {
			get {
				return new Vector4(
					this.row1.x,
					this.row2.x,
					this.row3.x,
					this.row4.x
				);
			}
			set {
				this.row1.x = value.x;
				this.row2.x = value.y;
				this.row3.x = value.z;
				this.row4.x = value.w;
			}
		}
		
		/// <summary>Gets and sets the second columns of the matrix</summary>
		public Vector4 Column2 {
			get {
				return new Vector4(
					this.row1.y,
					this.row2.y,
					this.row3.y,
					this.row4.y
				);
			}
			set {
				this.row1.y = value.x;
				this.row2.y = value.y;
				this.row3.y = value.z;
				this.row4.y = value.w;
			}
		}
		
		/// <summary>Gets and sets the third columns of the matrix</summary>
		public Vector4 Column3 {
			get {
				return new Vector4(
					this.row1.z,
					this.row2.z,
					this.row3.z,
					this.row4.z
				);
			}
			set {
				this.row1.z = value.x;
				this.row2.z = value.y;
				this.row3.z = value.z;
				this.row4.z = value.w;
			}
		}
		
		/// <summary>Gets and sets the fourth columns of the matrix</summary>
		public Vector4 Column4 {
			get {
				return new Vector4(
					this.row1.w,
					this.row2.w,
					this.row3.w,
					this.row4.w
				);
			}
			set {
				this.row1.w = value.x;
				this.row2.w = value.y;
				this.row3.w = value.z;
				this.row4.w = value.w;
			}
		}
		
		/// <summary>Gets and sets the diagonals of the matrix</summary>
		public Vector4 Diagonal {
			get {
				return new Vector4(
					this.row1.x,
					this.row2.y,
					this.row3.z,
					this.row4.w
				);
			}
			set {
				this.row1.x = value.x;
				this.row2.y = value.y;
				this.row3.z = value.z;
				this.row4.w = value.w;
			}
		}
		
		/// <summary>Gets the trace of the matrix (summation of the diagonals of the matrix)</summary>
		public float Trace { get { return this.row1.x + this.row2.y + this.row3.z + this.row4.w; } }
		
		/// <summary>Gets and sets the first item of the first row of the matrix</summary>
		public float A11 { get { return this.row1.x; } set { this.row1.x = value; } }
		
		/// <summary>Gets and sets the second item of the first row of the matrix</summary>
		public float A12 { get { return this.row1.y; } set { this.row1.y = value; } }
		
		/// <summary>Gets and sets the third item of the first row of the matrix</summary>
		public float A13 { get { return this.row1.z; } set { this.row1.z = value; } }
		
		/// <summary>Gets and sets the fourth item of the first row of the matrix</summary>
		public float A14 { get { return this.row1.w; } set { this.row1.w = value; } }
		
		/// <summary>Gets and sets the first item of the second row of the matrix</summary>
		public float A21 { get { return this.row2.x; } set { this.row2.x = value; } }
		
		/// <summary>Gets and sets the second item of the second row of the matrix</summary>
		public float A22 { get { return this.row2.y; } set { this.row2.y = value; } }
		
		/// <summary>Gets and sets the third item of the second row of the matrix</summary>
		public float A23 { get { return this.row2.z; } set { this.row2.z = value; } }
		
		/// <summary>Gets and sets the fourth item of the second row of the matrix</summary>
		public float A24 { get { return this.row2.w; } set { this.row2.w = value; } }
		
		/// <summary>Gets and sets the first item of the third row of the matrix</summary>
		public float A31 { get { return this.row3.x; } set { this.row3.x = value; } }
		
		/// <summary>Gets and sets the second item of the third row of the matrix</summary>
		public float A32 { get { return this.row3.y; } set { this.row3.y = value; } }
		
		/// <summary>Gets and sets the third item of the third row of the matrix</summary>
		public float A33 { get { return this.row3.z; } set { this.row3.z = value; } }
		
		/// <summary>Gets and sets the fourth item of the third row of the matrix</summary>
		public float A34 { get { return this.row3.w; } set { this.row3.w = value; } }
		
		/// <summary>Gets and sets the first item of the fourth row of the matrix</summary>
		public float A41 { get { return this.row4.x; } set { this.row4.x = value; } }
		
		/// <summary>Gets and sets the second item of the fourth row of the matrix</summary>
		public float A42 { get { return this.row4.y; } set { this.row4.y = value; } }
		
		/// <summary>Gets and sets the third item of the fourth row of the matrix</summary>
		public float A43 { get { return this.row4.z; } set { this.row4.z = value; } }
		
		/// <summary>Gets and sets the fourth item of the fourth row of the matrix</summary>
		public float A44 { get { return this.row4.w; } set { this.row4.w = value; } }
		
		/// <summary>Gets the determinant of the matrix</summary>
		public float Determinant { get { return GetDeterminant(ref this); } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a matrix by using the rows</summary>
		/// <param name="row1">The first row of the matrix</param>
		/// <param name="row2">The second row of the matrix</param>
		/// <param name="row3">The third row of the matrix</param>
		/// <param name="row4">The fourth row of the matrix</param>
		public Matrix(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4) {
			this.row1 = row1;
			this.row2 = row2;
			this.row3 = row3;
			this.row4 = row4;
		}
		
		/// <summary>A constructor for creating a matrix by using a lot of values</summary>
		/// <param name="a11">The first item of the first row of the matrix</param>
		/// <param name="a12">The second item of the first row of the matrix</param>
		/// <param name="a13">The third item of the first row of the matrix</param>
		/// <param name="a14">The fourth item of the first row of the matrix</param>
		/// <param name="a21">The first item of the second row of the matrix</param>
		/// <param name="a22">The second item of the second row of the matrix</param>
		/// <param name="a23">The third item of the second row of the matrix</param>
		/// <param name="a24">The fourth item of the second row of the matrix</param>
		/// <param name="a31">The first item of the third row of the matrix</param>
		/// <param name="a32">The second item of the third row of the matrix</param>
		/// <param name="a33">The third item of the third row of the matrix</param>
		/// <param name="a34">The fourth item of the third row of the matrix</param>
		/// <param name="a41">The first item of the fourth row of the matrix</param>
		/// <param name="a42">The second item of the fourth row of the matrix</param>
		/// <param name="a43">The third item of the fourth row of the matrix</param>
		/// <param name="a44">The fourth item of the fourth row of the matrix</param>
		public Matrix(
			float a11, float a12, float a13, float a14,
			float a21, float a22, float a23, float a24,
			float a31, float a32, float a33, float a34,
			float a41, float a42, float a43, float a44
		) : this(
			new Vector4(a11, a12, a13, a14),
			new Vector4(a21, a22, a23, a24),
			new Vector4(a31, a32, a33, a34),
			new Vector4(a41, a42, a43, a44)
		) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region CreateRotationX Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the x axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationX(float theta, out Matrix result) {
			result = Matrix.Identity;
			result.row2.y = Mathx.Cos(theta);
			result.row3.y = Mathx.Sin(theta);
			result.row2.z = -result.row3.y;
			result.row3.z = result.row2.y;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the x axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationX(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationX(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationX Methods
		
		#region CreateRotationY Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the y axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationY(float theta, out Matrix result) {
			result = Matrix.Identity;
			result.row1.x = Mathx.Cos(theta);
			result.row1.z = Mathx.Sin(theta);
			result.row3.x = -result.row1.z;
			result.row3.z = result.row1.x;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the y axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationY(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationY(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationY Methods
		
		#region CreateRotationZ Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the z axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationZ(float theta, out Matrix result) {
			result = Matrix.Identity;
			result.row1.x = Mathx.Cos(theta);
			result.row2.x = Mathx.Sin(theta);
			result.row1.y = -result.row2.x;
			result.row2.y = result.row1.x;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the z axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationZ(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationZ(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationZ Methods
		
		#region CreateRotationFromAxisAngle Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationFromAxisAngle(ref Vector3 axis, float theta, out Matrix result) {
			if(axis == Vector3.Zero) {
				result = Matrix.Identity;
				return;
			}
			
			// Variables
			float cos = Mathx.Cos(theta);
			float sin = Mathx.Sin(theta);
			float invcos = (1.0f - cos);
			Vector3 u;
			
			Mathx.Normalize(ref axis, out u);
			result = Matrix.Identity;
			
			result.row1.x = cos + u.x * u.x * invcos;
			result.row1.y = u.x * u.y * invcos - u.z * sin;
			result.row1.z = u.x * u.z * invcos + u.y * sin;
			
			result.row2.x = u.y * u.x * invcos + u.z * sin;
			result.row2.y = cos + u.y * u.y * invcos;
			result.row2.z = u.y * u.z * invcos - u.x * sin;
			
			result.row3.x = u.z * u.x * invcos - u.y * sin;
			result.row3.y = u.z * u.y * invcos + u.x * sin;
			result.row3.z = cos + u.z * u.z * invcos;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationFromAxisAngle(Vector3 axis, float theta, out Matrix result) { CreateRotationFromAxisAngle(ref axis, theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationFromAxisAngle(ref Vector3 axis, float theta) {
			// Variables
			Matrix result;
			
			CreateRotationFromAxisAngle(ref axis, theta, out result);
			
			return result;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationFromAxisAngle(Vector3 axis, float theta) { return CreateRotationFromAxisAngle(ref axis, theta); }
		
		#endregion // CreateRotationFromAxisAngle Methods
		
		#region CreateRotationXDeg Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the x axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationXDeg(float theta, out Matrix result) { CreateRotationX(Mathx.DegToRad * theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the x axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationXDeg(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationXDeg(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationXDeg Methods
		
		#region CreateRotationYDeg Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the y axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationYDeg(float theta, out Matrix result) { CreateRotationY(Mathx.DegToRad * theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the y axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationYDeg(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationYDeg(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationYDeg Methods
		
		#region CreateRotationZDeg Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the z axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationZDeg(float theta, out Matrix result) { CreateRotationZ(Mathx.DegToRad * theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the z axis with the given angle (theta)</summary>
		/// <param name="theta">The angle of rotation</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationZDeg(float theta) {
			// Variables
			Matrix result;
			
			CreateRotationZDeg(theta, out result);
			
			return result;
		}
		
		#endregion // CreateRotationZDeg Methods
		
		#region CreateRotationFromAxisAngleDeg Methods
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationFromAxisAngleDeg(ref Vector3 axis, float theta, out Matrix result) { CreateRotationFromAxisAngle(ref axis, Mathx.DegToRad * theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateRotationFromAxisAngleDeg(Vector3 axis, float theta, out Matrix result) { CreateRotationFromAxisAngleDeg(ref axis, theta, out result); }
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationFromAxisAngleDeg(ref Vector3 axis, float theta) {
			// Variables
			Matrix result;
			
			CreateRotationFromAxisAngleDeg(ref axis, theta, out result);
			
			return result;
		}
		
		/// <summary>Creates a rotation matrix that rotates counterclockwise around the given axis using the given angle (theta)</summary>
		/// <param name="axis">The axis to rotate around</param>
		/// <param name="theta">The angle used to rotate with</param>
		/// /// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateRotationFromAxisAngleDeg(Vector3 axis, float theta) { return CreateRotationFromAxisAngleDeg(ref axis, theta); }
		
		#endregion // CreateRotationFromAxisAngleDeg Methods
		
		#region CreateScale Methods
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="xScalar">The scalar that scales the x axis</param>
		/// <param name="yScalar">The scalar that scales the y axis</param>
		/// <param name="zScalar">The scalar that scales the z axis</param>
		/// <param name="result">The resulting scale matrix</param>
		public static void CreateScale(float xScalar, float yScalar, float zScalar, out Matrix result) {
			result = Matrix.Identity;
			result.row1.x = xScalar;
			result.row2.y = yScalar;
			result.row3.z = zScalar;
		}
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="xScalar">The scalar that scales the x axis</param>
		/// <param name="yScalar">The scalar that scales the y axis</param>
		/// <param name="zScalar">The scalar that scales the z axis</param>
		/// <returns>Returns the resulting scale matrix</returns>
		public static Matrix CreateScale(float xScalar, float yScalar, float zScalar) {
			// Variables
			Matrix result;
			
			CreateScale(xScalar, yScalar, zScalar, out result);
			
			return result;
		}
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalar">The scalar that scales the x, y, and z axis uniformly</param>
		/// <param name="result">The resulting scale matrix</param>
		public static void CreateScale(float scalar, out Matrix result) { CreateScale(scalar, scalar, scalar, out result); }
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalar">The scalar that scales the x, y, and z axis uniformly</param>
		/// <returns>Returns the resulting scale matrix</returns>
		public static Matrix CreateScale(float scalar) { return CreateScale(scalar, scalar, scalar); }
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalars">The vector that holds the scalars to scale the x, y, and z axis</param>
		/// <param name="result">The resulting scale matrix</param>
		public static void CreateScale(ref Vector3 scalars, out Matrix result) { CreateScale(scalars.x, scalars.y, scalars.z, out result); }
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalars">The vector that holds the scalars to scale the x, y, and z axis</param>
		/// <param name="result">The resulting scale matrix</param>
		public static void CreateScale(Vector3 scalars, out Matrix result) { CreateScale(scalars.x, scalars.y, scalars.z, out result); }
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalars">The vector that holds the scalars to scale the x, y, and z axis</param>
		/// <returns>Returns the resulting scale matrix</returns>
		public static Matrix CreateScale(ref Vector3 scalars) { return CreateScale(scalars.x, scalars.y, scalars.z); }
		
		/// <summary>Creates a matrix that scales vectors</summary>
		/// <param name="scalars">The vector that holds the scalars to scale the x, y, and z axis</param>
		/// <returns>Returns the resulting scale matrix</returns>
		public static Matrix CreateScale(Vector3 scalars) { return CreateScale(scalars.x, scalars.y, scalars.z); }
		
		#endregion // CreateScale Methods
		
		#region CreateTranslation Methods
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <param name="result">The resulting translation matrix</param>
		public static void CreateTranslation(ref Vector3 position, out Matrix result) {
			result = Matrix.Identity;
			
			result.row1.w = position.x;
			result.row2.w = position.y;
			result.row3.w = position.z;
		}
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <param name="result">The resulting translation matrix</param>
		public static void CreateTranslation(Vector3 position, out Matrix result) { CreateTranslation(ref position, out result); }
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <returns>Returns the resulting translation matrix</returns>
		public static Matrix CreateTranslation(ref Vector3 position) {
			// Variables
			Matrix result;
			
			CreateTranslation(ref position, out result);
			
			return result;
		}
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <returns>Returns the resulting translation matrix</returns>
		public static Matrix CreateTranslation(Vector3 position) { return CreateTranslation(ref position); }
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <param name="result">The resulting translation matrix</param>
		public static void CreateTranslation(ref Vector2 position, out Matrix result) {
			result = Matrix.Identity;
			
			result.row1.w = position.x;
			result.row2.w = position.y;
		}
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <param name="result">The resulting translation matrix</param>
		public static void CreateTranslation(Vector2 position, out Matrix result) { CreateTranslation(ref position, out result); }
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <returns>Returns the resulting translation matrix</returns>
		public static Matrix CreateTranslation(ref Vector2 position) {
			// Variables
			Matrix result;
			
			CreateTranslation(ref position, out result);
			
			return result;
		}
		
		/// <summary>Creates a translation matrix from the given position</summary>
		/// <param name="position">The position that translates</param>
		/// <returns>Returns the resulting translation matrix</returns>
		public static Matrix CreateTranslation(Vector2 position) { return CreateTranslation(ref position); }
		
		#endregion // CreateTranslation Methods
		
		#region CreateFromQuaternion Methods
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result) { Quaternion.ToMatrix(ref quaternion, out result); }
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void CreateFromQuaternion(Quaternion quaternion, out Matrix result) { Quaternion.ToMatrix(ref quaternion, out result); }
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateFromQuaternion(ref Quaternion quaternion) { return Quaternion.ToMatrix(ref quaternion); }
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix CreateFromQuaternion(Quaternion quaternion) { return Quaternion.ToMatrix(ref quaternion); }
		
		#endregion // CreateFromQuaternion Methods
		
		#region CreateOrthographic Methods
		
		/// <summary>Creates an off center orthographic projection matrix (flat projection, lines are straight)</summary>
		/// <param name="left">The left most part of the orthographic projection</param>
		/// <param name="right">The right most part of the orthographic projection</param>
		/// <param name="top">The top most part of the orthographic projection</param>
		/// <param name="bottom">The bottom most part of the orthographic projection</param>
		/// <param name="near">The near most part of the orthographic projection</param>
		/// <param name="far">The far most part of the orthographic projection</param>
		/// <param name="result">The resulting projection matrix</param>
		public static void CreateOrthographicOffCenter(float left, float right, float top, float bottom, float near, float far, out Matrix result) {
			// Variables
			float rl = right - left;
			float tb = bottom - top;
			float fn = far - near;
			
			result.row1.y = result.row1.z = 0.0f;
			result.row2.x = result.row2.z = 0.0f;
			result.row3.x = result.row3.y = 0.0f;
			result.row4 = Vector4.UnitW;
			
			result.row1.x = 2.0f / rl;
			result.row1.w = -(right + left) / rl;
			result.row2.y = 2.0f / tb;
			result.row2.w = -(top + bottom) / tb;
			result.row3.z = -2.0f / fn;
			result.row3.w = -(far + near) / fn;
		}
		
		/// <summary>Creates an off center orthographic projection matrix</summary>
		/// <param name="left">The left most part of the orthographic projection</param>
		/// <param name="right">The right most part of the orthographic projection</param>
		/// <param name="top">The top most part of the orthographic projection</param>
		/// <param name="bottom">The bottom most part of the orthographic projection</param>
		/// <param name="near">The near most part of the orthographic projection</param>
		/// <param name="far">The far most part of the orthographic projection</param>
		/// <returns>Returns the resulting projection matrix</returns>
		public static Matrix CreateOrthographicOffCenter(float left, float right, float top, float bottom, float near, float far) {
			// Variables
			Matrix result;
			
			CreateOrthographicOffCenter(left, right, top, bottom, near, far, out result);
			
			return result;
		}
		
		/// <summary>Creates an orthographic projection (flat projection, lines are straight)</summary>
		/// <param name="width">The width of the box of projection</param>
		/// <param name="height">The height of the box of projection</param>
		/// <param name="near">The near z plane</param>
		/// <param name="far">The far z plane</param>
		/// <param name="result">The resulting orthographic projection matrix</param>
		public static void CreateOrthographic(float width, float height, float near, float far, out Matrix result) { CreateOrthographicOffCenter(-width / 2.0f, width / 2.0f, -height / 2.0f, height / 2.0f, near, far, out result); }
		
		/// <summary>Creates an orthographic projection (flat projection, lines are straight)</summary>
		/// <param name="width">The width of the box of projection</param>
		/// <param name="height">The height of the box of projection</param>
		/// <param name="near">The near z plane</param>
		/// <param name="far">The far z plane</param>
		/// <returns>Returns the resulting orthographic projection matrix</returns>
		public static Matrix CreateOrthographic(float width, float height, float near, float far) { return CreateOrthographicOffCenter(-width / 2.0f, width / 2.0f, -height / 2.0f, height / 2.0f, near, far); }
		
		#endregion // CreateOrthographic Methods
		
		#region CreatePerspective Methods
		
		/// <summary>Creates an off center perspective projection matrix (projection that closely mimics human perspective)</summary>
		/// <param name="left">The left most part of the perspective projection</param>
		/// <param name="right">The right most part of the perspective projection</param>
		/// <param name="top">The top most part of the perspective projection</param>
		/// <param name="bottom">The bottom most part of the perspective projection</param>
		/// <param name="near">The near most part of the perspective projection</param>
		/// <param name="far">The far most part of the perspective projection</param>
		/// <param name="result">The resulting perspective projection matrix</param>
		public static void CreatePerspectiveOffCenter(float left, float right, float top, float bottom, float near, float far, out Matrix result) {
			// Variables
			float rl = right - left;
			float tb = bottom - top;
			float fn = far - near;
			
			result.row1.y = result.row1.w = 0.0f;
			result.row2.x = result.row2.w = 0.0f;
			result.row3.x = result.row3.y = 0.0f;
			result.row4.x = result.row4.y = result.row4.w = 0.0f;
			
			result.row1.x = (2.0f * near) / rl;
			result.row1.z = (right + left) / rl;
			result.row2.y = (2.0f * near) / tb;
			result.row2.z = (top + bottom) / tb;
			result.row3.z = -(far + near) / fn;
			result.row3.w = -(2.0f * far * near) / fn;
			result.row4.z = -1.0f;
		}
		
		/// <summary>Creates an off center perspective projection matrix (projection that closely mimics human perspective)</summary>
		/// <param name="left">The left most part of the perspective projection</param>
		/// <param name="right">The right most part of the perspective projection</param>
		/// <param name="top">The top most part of the perspective projection</param>
		/// <param name="bottom">The bottom most part of the perspective projection</param>
		/// <param name="near">The near most part of the perspective projection</param>
		/// <param name="far">The far most part of the perspective projection</param>
		/// <returns>Returns the resulting perspective projection matrix</returns>
		public static Matrix  CreatePerspectiveOffCenter(float left, float right, float top, float bottom, float near, float far) {
			// Variables
			Matrix result;
			
			CreatePerspectiveOffCenter(left, right, top, bottom, near, far, out result);
			
			return result;
		}
		
		/// <summary>Creates a perspective projection (projection that closely mimics human perspective)</summary>
		/// <param name="fov">The field of view of the perspective in degrees. Normally 90 degrees is a good field of view to use</param>
		/// <param name="aspect">The aspect ratio of the perpective</param>
		/// <param name="near">The near plane</param>
		/// <param name="far">The far plane</param>
		/// <param name="result">The resulting perspective projection matrix</param>
		public static void CreatePerspective(float fov, float aspect, float near, float far, out Matrix result) {
			// Variables
			float top = Mathx.Tan(0.5f * fov * Mathx.DegToRad) * near;
			float right = top * aspect;
			
			CreatePerspectiveOffCenter(-right, right, -top, top, near, far, out result);
		}
		
		/// <summary>Creates a perspective projection (projection that closely mimics human perspective)</summary>
		/// <param name="fov">The field of view of the perspective in radians. Normally 90 degree is a good field of view to use</param>
		/// <param name="aspect">The aspect ratio of the perpective</param>
		/// <param name="near">The near plane</param>
		/// <param name="far">The far plane</param>
		/// <returns>Returns the resulting perspective projection matrix</returns>
		public static Matrix CreatePerspective(float fov, float aspect, float near, float far) {
			// Variables
			Matrix result;
			
			CreatePerspective(fov, aspect, near, far, out result);
			
			return result;
		}
		
		#endregion // CreatePerspective Methods
		
		#region CreateLookAt Methods
		
		/// <summary>Creates a matrix that transforms an object to look towards a point</summary>
		/// <param name="from">The position where the object would be at</param>
		/// <param name="to">The position where the object will be looking towards</param>
		/// <param name="up">The up vector to get a reference point from, normally being (0, 1, 0)</param>
		/// <param name="result">The resulting look at matrix</param>
		public static void CreateLookAt(ref Vector3 from, ref Vector3 to, ref Vector3 up, out Matrix result) {
			// Variables
			Vector3 forward, right, nup;
			
			Mathx.Subtract(ref to, ref from, out forward);
			if(forward == Vector3.Zero) {
				result = Matrix.Identity;
				result.row1.w = from.x;
				result.row2.w = from.y;
				result.row3.w = from.z;
				return;
			}
			Mathx.Normalize(ref forward, out forward);
			Mathx.Normalize(ref up, out nup);
			Mathx.CrossProduct(ref nup, ref forward, out right);
			Mathx.Normalize(ref right, out right);
			Mathx.CrossProduct(ref forward, ref right, out nup);
			
			// Column 1
			result.row1.x = right.x;
			result.row2.x = right.y;
			result.row3.x = right.z;
			
			// Column 2
			result.row1.y = nup.x;
			result.row2.y = nup.y;
			result.row3.y = nup.z;
			
			// Column 3
			result.row1.z = forward.x;
			result.row2.z = forward.y;
			result.row3.z = forward.z;
			
			// Column 4
			result.row1.w = from.x;
			result.row2.w = from.y;
			result.row3.w = from.z;
			
			// Row 4
			result.row4 = Vector4.UnitW;
		}
		
		/// <summary>Creates a matrix that transforms an object to look towards a point</summary>
		/// <param name="from">The position where the object would be at</param>
		/// <param name="to">The position where the object will be looking towards</param>
		/// <param name="up">The up vector to get a reference point from, normally being (0, 1, 0)</param>
		/// <param name="result">The resulting look at matrix</param>
		public static void CreateLookAt(Vector3 from, Vector3 to, Vector3 up, out Matrix result) { CreateLookAt(ref from, ref to, ref up, out result); }
		
		/// <summary>Creates a matrix that transforms an object to look towards a point</summary>
		/// <param name="from">The position where the object would be at</param>
		/// <param name="to">The position where the object will be looking towards</param>
		/// <param name="up">The up vector to get a reference point from, normally being (0, 1, 0)</param>
		/// <returns>Returns the resulting look at matrix</returns>
		public static Matrix CreateLookAt(ref Vector3 from, ref Vector3 to, ref Vector3 up) {
			// Variables
			Matrix result;
			
			CreateLookAt(ref from, ref to, ref up, out result);
			
			return result;
		}
		
		/// <summary>Creates a matrix that transforms an object to look towards a point</summary>
		/// <param name="from">The position where the object would be at</param>
		/// <param name="to">The position where the object will be looking towards</param>
		/// <param name="up">The up vector to get a reference point from, normally being (0, 1, 0)</param>
		/// <returns>Returns the resulting look at matrix</returns>
		public static Matrix CreateLookAt(Vector3 from, Vector3 to, Vector3 up) { return CreateLookAt(ref from, ref to, ref up); }
		
		#endregion // CreateLookAt Methods
		
		#region Add Methods
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is added together</param>
		public static void Add(ref Matrix a, ref Matrix b, out Matrix result) {
			Mathx.Add(ref a.row1, ref b.row1, out result.row1);
			Mathx.Add(ref a.row2, ref b.row2, out result.row2);
			Mathx.Add(ref a.row3, ref b.row3, out result.row3);
			Mathx.Add(ref a.row4, ref b.row4, out result.row4);
		}
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is added together</param>
		public static void Add(Matrix a, Matrix b, out Matrix result) { Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is added together</returns>
		public static Matrix Add(ref Matrix a, ref Matrix b) {
			// Variables
			Matrix result;
			
			Add(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is added together</returns>
		public static Matrix Add(Matrix a, Matrix b) { return Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is subtracting the two given matrices</param>
		public static void Subtract(ref Matrix a, ref Matrix b, out Matrix result) {
			Mathx.Subtract(ref a.row1, ref b.row1, out result.row1);
			Mathx.Subtract(ref a.row2, ref b.row2, out result.row2);
			Mathx.Subtract(ref a.row3, ref b.row3, out result.row3);
			Mathx.Subtract(ref a.row4, ref b.row4, out result.row4);
		}
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting matrix that is subtracting the two given matrices</param>
		public static void Subtract(Matrix a, Matrix b, out Matrix result) { Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is subtracting the two given matrices</returns>
		public static Matrix Subtract(ref Matrix a, ref Matrix b) {
			// Variables
			Matrix result;
			
			Subtract(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting matrix that is subtracting the two given matrices</returns>
		public static Matrix Subtract(Matrix a, Matrix b) { return Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(float scalar, ref Matrix matrix, out Matrix result) {
			Mathx.Multiply(scalar, ref matrix.row1, out result.row1);
			Mathx.Multiply(scalar, ref matrix.row2, out result.row2);
			Mathx.Multiply(scalar, ref matrix.row3, out result.row3);
			Mathx.Multiply(scalar, ref matrix.row4, out result.row4);
		}
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(float scalar, Matrix matrix, out Matrix result) { Multiply(scalar, ref matrix, out result); }
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(float scalar, ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Multiply(scalar, ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <param name="matrix">The matrix to multiply with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(float scalar, Matrix matrix) { return Multiply(scalar, ref matrix); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(ref Matrix a, ref Matrix b, out Matrix result) {
			// Variables
			Vector4 row1 = a.row1;
			Vector4 row2 = a.row2;
			Vector4 row3 = a.row3;
			Vector4 row4 = a.row4;
			Vector4 col1 = b.Column1;
			Vector4 col2 = b.Column2;
			Vector4 col3 = b.Column3;
			Vector4 col4 = b.Column4;
			
			// Row 1
			Mathx.Dot(ref row1, ref col1, out result.row1.x);
			Mathx.Dot(ref row1, ref col2, out result.row1.y);
			Mathx.Dot(ref row1, ref col3, out result.row1.z);
			Mathx.Dot(ref row1, ref col4, out result.row1.w);
			
			// Row 2
			Mathx.Dot(ref row2, ref col1, out result.row2.x);
			Mathx.Dot(ref row2, ref col2, out result.row2.y);
			Mathx.Dot(ref row2, ref col3, out result.row2.z);
			Mathx.Dot(ref row2, ref col4, out result.row2.w);
			
			// Row 3
			Mathx.Dot(ref row3, ref col1, out result.row3.x);
			Mathx.Dot(ref row3, ref col2, out result.row3.y);
			Mathx.Dot(ref row3, ref col3, out result.row3.z);
			Mathx.Dot(ref row3, ref col4, out result.row3.w);
			
			// Row 4
			Mathx.Dot(ref row4, ref col1, out result.row4.x);
			Mathx.Dot(ref row4, ref col2, out result.row4.y);
			Mathx.Dot(ref row4, ref col3, out result.row4.z);
			Mathx.Dot(ref row4, ref col4, out result.row4.w);
		}
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <param name="result">The resulting multiplied matrix</param>
		public static void Multiply(Matrix a, Matrix b, out Matrix result) { Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(ref Matrix a, ref Matrix b) {
			// Variables
			Matrix result;
			
			Multiply(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="a">The first matrix</param>
		/// <param name="b">The second matrix</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix Multiply(Matrix a, Matrix b) { return Multiply(ref a, ref b); }
		
		#endregion // Multiply Methods
		
		#region Multiply Vectors Methods
		
		#region Vector4 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector4 b, out Vector4 result) {
			// Variables
			Vector4 temp;
			
			Mathx.Dot(ref a.row1, ref b, out temp.x);
			Mathx.Dot(ref a.row2, ref b, out temp.y);
			Mathx.Dot(ref a.row3, ref b, out temp.z);
			Mathx.Dot(ref a.row4, ref b, out temp.w);
			
			result = temp;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(Matrix a, Vector4 b, out Vector4 result) { Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector4 Multiply(ref Matrix a, ref Vector4 b) {
			// Variables
			Vector4 result;
			
			Multiply(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector4 Multiply(Matrix a, Vector4 b) { return Multiply(ref a, ref b); }
		
		#endregion // Vector4 Methods
		
		#region Vector3 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector3 b, out Vector3 result) {
			// Variables
			Vector3 temp;
			
			temp.x = a.row1.x * b.x + a.row1.y * b.y + a.row1.z * b.z + a.row1.w;
			temp.y = a.row2.x * b.x + a.row2.y * b.y + a.row2.z * b.z + a.row2.w;
			temp.z = a.row3.x * b.x + a.row3.y * b.y + a.row3.z * b.z + a.row3.w;
			
			result = temp;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(Matrix a, Vector3 b, out Vector3 result) { Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector3 Multiply(ref Matrix a, ref Vector3 b) {
			// Variables
			Vector3 result;
			
			Multiply(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector3 Multiply(Matrix a, Vector3 b) { return Multiply(ref a, ref b); }
		
		#endregion // Vector3 Methods
		
		#region Vector2 Methods
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(ref Matrix a, ref Vector2 b, out Vector2 result) {
			// Variables
			Vector2 temp;
			
			temp.x = a.row1.x * b.x + a.row1.y * b.y + a.row1.w;
			temp.y = a.row2.x * b.x + a.row2.y * b.y + a.row2.w;
			
			result = temp;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <param name="result">The resulting multipied vector</param>
		public static void Multiply(Matrix a, Vector2 b, out Vector2 result) { Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector2 Multiply(ref Matrix a, ref Vector2 b) {
			// Variables
			Vector2 result;
			
			Multiply(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="a">The matrix to multiply with</param>
		/// <param name="b">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector2 Multiply(Matrix a, Vector2 b) { return Multiply(ref a, ref b); }
		
		#endregion // Vector2 Methods
		
		#endregion // Multiply Vectors Methods
		
		#region Divide Methods
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <param name="result">The resulting divided matrix</param>
		public static void Divide(float scalar, ref Matrix matrix, out Matrix result) {
			Mathx.Divide(scalar, ref matrix.row1, out result.row1);
			Mathx.Divide(scalar, ref matrix.row2, out result.row2);
			Mathx.Divide(scalar, ref matrix.row3, out result.row3);
			Mathx.Divide(scalar, ref matrix.row4, out result.row4);
		}
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <param name="result">The resulting divided matrix</param>
		public static void Divide(float scalar, Matrix matrix, out Matrix result) { Divide(scalar, ref matrix, out result); }
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <returns>Returns the resulting divided matrix</returns>
		public static Matrix Divide(float scalar, ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Divide(scalar, ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <param name="matrix">The matrix to divide with</param>
		/// <returns>Returns the resulting divided matrix</returns>
		public static Matrix Divide(float scalar, Matrix matrix) { return Divide(scalar, ref matrix); }
		
		#endregion // Divide Methods
		
		#region Transpose Methods
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <param name="result">The resulting transposed matrix</param>
		public static void Transpose(ref Matrix matrix, out Matrix result) {
			// Variables
			Vector4 col1 = matrix.Column1;
			Vector4 col2 = matrix.Column2;
			Vector4 col3 = matrix.Column3;
			Vector4 col4 = matrix.Column4;
			
			result.row1 = col1;
			result.row2 = col2;
			result.row3 = col3;
			result.row4 = col4;
		}
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <param name="result">The resulting transposed matrix</param>
		public static void Transpose(Matrix matrix, out Matrix result) { Transpose(ref matrix, out result); }
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <returns>Returns the resulting transposed matrix</returns>
		public static Matrix Transpose(ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Transpose(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <param name="matrix">The matrix to transpose</param>
		/// <returns>Returns the resulting transposed matrix</returns>
		public static Matrix Transpose(Matrix matrix) { return Transpose(ref matrix); }
		
		#endregion // Transpose Methods
		
		#region Negate Methods
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <param name="result">The resulting negated matrix</param>
		public static void Negate(ref Matrix matrix, out Matrix result) {
			Mathx.Negate(ref matrix.row1, out result.row1);
			Mathx.Negate(ref matrix.row2, out result.row2);
			Mathx.Negate(ref matrix.row3, out result.row3);
			Mathx.Negate(ref matrix.row4, out result.row4);
		}
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <param name="result">The resulting negated matrix</param>
		public static void Negate(Matrix matrix, out Matrix result) { Negate(ref matrix, out result); }
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <returns>Returns the resulting negated matrix</returns>
		public static Matrix Negate(ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Negate(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <returns>Returns the resulting negated matrix</returns>
		public static Matrix Negate(Matrix matrix) { return Negate(ref matrix); }
		
		#endregion // Negate Methods
		
		#region Adjugate Methods
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <param name="result">The resulting adjugated matrix</param>
		public static void Adjugate(ref Matrix matrix, out Matrix result) {
			// Variables
			float det11, det12, det13, det14;
			float det21, det22, det23, det24;
			float det31, det32, det33, det34;
			float det41, det42, det43, det44;
			
			// Gets the determinant for row 1
			GetDeterminant3x3(
				ref matrix.row2.y, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row3.y, ref matrix.row3.z, ref matrix.row3.w,
				ref matrix.row4.y, ref matrix.row4.z, ref matrix.row4.w,
				out det11
			);
			GetDeterminant3x3(
				ref matrix.row2.x, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row3.x, ref matrix.row3.z, ref matrix.row3.w,
				ref matrix.row4.x, ref matrix.row4.z, ref matrix.row4.w,
				out det12
			);
			GetDeterminant3x3(
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.w,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.w,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.w,
				out det13
			);
			GetDeterminant3x3(
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.z,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.z,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.z,
				out det14
			);
			
			// Gets the determinant for row 2
			GetDeterminant3x3(
				ref matrix.row1.y, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row3.y, ref matrix.row3.z, ref matrix.row3.w,
				ref matrix.row4.y, ref matrix.row4.z, ref matrix.row4.w,
				out det21
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row3.x, ref matrix.row3.z, ref matrix.row3.w,
				ref matrix.row4.x, ref matrix.row4.z, ref matrix.row4.w,
				out det22
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.w,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.w,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.w,
				out det23
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.z,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.z,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.z,
				out det24
			);
			
			// Gets the determinant for row 3
			GetDeterminant3x3(
				ref matrix.row1.y, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row2.y, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row4.y, ref matrix.row4.z, ref matrix.row4.w,
				out det31
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row2.x, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row4.x, ref matrix.row4.z, ref matrix.row4.w,
				out det32
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.w,
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.w,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.w,
				out det33
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.z,
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.z,
				ref matrix.row4.x, ref matrix.row4.y, ref matrix.row4.z,
				out det34
			);
			
			// Gets the determinant for row 4
			GetDeterminant3x3(
				ref matrix.row1.y, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row2.y, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row3.y, ref matrix.row3.z, ref matrix.row3.w,
				out det41
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.z, ref matrix.row1.w,
				ref matrix.row2.x, ref matrix.row2.z, ref matrix.row2.w,
				ref matrix.row3.x, ref matrix.row3.z, ref matrix.row3.w,
				out det42
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.w,
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.w,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.w,
				out det43
			);
			GetDeterminant3x3(
				ref matrix.row1.x, ref matrix.row1.y, ref matrix.row1.z,
				ref matrix.row2.x, ref matrix.row2.y, ref matrix.row2.z,
				ref matrix.row3.x, ref matrix.row3.y, ref matrix.row3.z,
				out det44
			);
			
			// Row 1
			result.row1.x = det11;
			result.row1.y = -det12;
			result.row1.z = det13;
			result.row1.w = -det14;
			
			// Row 2
			result.row2.x = -det21;
			result.row2.y = det22;
			result.row2.z = -det23;
			result.row2.w = det24;
			
			// Row 3
			result.row3.x = det31;
			result.row3.y = -det32;
			result.row3.z = det33;
			result.row3.w = -det34;
			
			// Row 4
			result.row4.x = -det41;
			result.row4.y = det42;
			result.row4.z = -det43;
			result.row4.w = det44;
			
			Transpose(ref result, out result);
		}
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <param name="result">The resulting adjugated matrix</param>
		public static void Adjugate(Matrix matrix, out Matrix result) { Adjugate(ref matrix, out result); }
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <returns>Returns the resulting adjugated matrix</returns>
		public static Matrix Adjugate(ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Adjugate(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <param name="matrix">The matrix to adjugate</param>
		/// <returns>Returns the resulting adjugated matrix</returns>
		public static Matrix Adjugate(Matrix matrix) { return Adjugate(ref matrix); }
		
		#endregion // Adjugate Methods
		
		#region GetDeterminant Methods
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <param name="result">The resulting determinant</param>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static void GetDeterminant(ref Matrix matrix, out float result) {
			// Variables
			// The following numbers A-F are used twice, this is to cut on computation
			float numA = matrix.A33 * matrix.A44 - matrix.A34 * matrix.A43;
			float numB = matrix.A32 * matrix.A44 - matrix.A34 * matrix.A42;
			float numC = matrix.A32 * matrix.A43 - matrix.A33 * matrix.A42;
			float numD = matrix.A31 * matrix.A44 - matrix.A34 * matrix.A41;
			float numE = matrix.A31 * matrix.A43 - matrix.A33 * matrix.A41;
			float numF = matrix.A31 * matrix.A42 - matrix.A32 * matrix.A41;
			// The following are subsection of the matrix (3x3) to get the full determinant
			float detA = matrix.A22 * numA - matrix.A23 * numB + matrix.A24 * numC;
			float detB = matrix.A21 * numA - matrix.A23 * numD + matrix.A24 * numE;
			float detC = matrix.A21 * numB - matrix.A22 * numD + matrix.A24 * numF;
			float detD = matrix.A21 * numC - matrix.A22 * numE + matrix.A23 * numF;
			
			result = matrix.A11 * detA - matrix.A12 * detB + matrix.A13 * detC - matrix.A14 * detD;
		}
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <param name="result">The resulting determinant</param>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static void GetDeterminant(Matrix matrix, out float result) { GetDeterminant(ref matrix, out result); }
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <returns>Returns the resulting determinant</returns>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static float GetDeterminant(ref Matrix matrix) {
			// Variables
			float result;
			
			GetDeterminant(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <param name="matrix">The matrix to get the determinant</param>
		/// <returns>Returns the resulting determinant</returns>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public static float GetDeterminant(Matrix matrix) { return GetDeterminant(ref matrix); }
		
		#endregion // GetDeterminant Methods
		
		#region Invert Methods
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <param name="result">The resulting inverted matrix</param>
		public static void Invert(ref Matrix matrix, out Matrix result) {
			// Variables
			float det;
			
			GetDeterminant(ref matrix, out det);
			if(Mathx.Approx(det, 0.0f)) {
				throw new System.Exception("Could not invert matrix");
			}
			
			Adjugate(ref matrix, out result);
			Divide(det, ref result, out result);
		}
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <param name="result">The resulting inverted matrix</param>
		public static void Invert(Matrix matrix, out Matrix result) { Invert(ref matrix, out result); }
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <returns>Returns the resulting inverted matrix</returns>
		public static Matrix Invert(ref Matrix matrix) {
			// Variables
			Matrix result;
			
			Invert(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Inverts the matrix</summary>
		/// <param name="matrix">The matrix to invert</param>
		/// <returns>Returns the resulting inverted matrix</returns>
		public static Matrix Invert(Matrix matrix) { return Invert(ref matrix); }
		
		#endregion // Invert Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(ref Matrix a, ref Matrix b, float epsilon, out bool result) {
			Mathx.Approx(ref a.row1, ref b.row1, epsilon, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row2, ref b.row2, epsilon, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row3, ref b.row3, epsilon, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row4, ref b.row4, epsilon, out result);
		}
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(Matrix a, Matrix b, float epsilon, out bool result) { Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(ref Matrix a, ref Matrix b, float epsilon) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, epsilon, out result);
			
			return result;
		}
		
		/// <summary>Finds if the two matrices are approximately close to each other</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(Matrix a, Matrix b, float epsilon) { return Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(ref Matrix a, ref Matrix b, out bool result) {
			Mathx.Approx(ref a.row1, ref b.row1, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row2, ref b.row2, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row3, ref b.row3, out result);
			if(!result) { return; }
			Mathx.Approx(ref a.row4, ref b.row4, out result);
		}
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <param name="result">Returns true if the two matrices are approximately close to each other</param>
		public static void Approx(Matrix a, Matrix b, out bool result) { Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(ref Matrix a, ref Matrix b) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Finds if the two matrices are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first matrix to approximate</param>
		/// <param name="b">The second matrix to approximate</param>
		/// <returns>Returns true if the two matrices are approximately close to each other</returns>
		public static bool Approx(Matrix a, Matrix b) { return Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Gets the determinant from a 3x3 block, used for easier readability</summary>
		/// <param name="a">The first number from the first row</param>
		/// <param name="b">The second number from the first row</param>
		/// <param name="c">The third number from the first row</param>
		/// <param name="d">The first number from the second row</param>
		/// <param name="e">The second number from the second row</param>
		/// <param name="f">The third number from the second row</param>
		/// <param name="g">The first number from the third row</param>
		/// <param name="h">The second number from the third row</param>
		/// <param name="i">The third number from the third row</param>
		/// <param name="result">The resulting determinant from the 3x3 block</param>
		private static void GetDeterminant3x3(
			ref float a, ref float b, ref float c,
			ref float d, ref float e, ref float f,
			ref float g, ref float h, ref float i,
			out float result
		) {
			// Variables
			float numA = e * i - f * h;
			float numB = d * i - f * g;
			float numC = d * h - e * g;
			
			result = a * numA - b * numB + c * numC;
		}
		
		#endregion // Private Static Methods
		
		#region Public Methods
		
		/// <summary>Converts the matrix into an array of floating point numbers</summary>
		/// <returns>Returns an array of floating point numbers that represent this matrix</returns>
		public float[] ToArray() {
			return new float[] {
				this.A11, this.A12, this.A13, this.A14,
				this.A21, this.A22, this.A23, this.A24,
				this.A31, this.A32, this.A33, this.A34,
				this.A41, this.A42, this.A43, this.A44
			};
		}
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="other">The other matrix</param>
		/// <returns>Returns the resulting matrix that is added together</returns>
		public Matrix Add(Matrix other) { return Add(ref this, ref other); }
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="other">The other matrix</param>
		/// <returns>Returns the resulting matrix that is subtracting the two given matrices</returns>
		public Matrix Subtract(Matrix other) { return Subtract(ref this, ref other); }
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to multiply the matrix with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public Matrix Multiply(float scalar) { return Multiply(scalar, ref this); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="other">The other matrix</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public Matrix Multiply(Matrix other) { return Multiply(ref this, ref other); }
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the matrix with</param>
		/// <returns>Returns the resulting divided matrix</returns>
		public Matrix Divide(float scalar) { return Divide(scalar, ref this); }
		
		/// <summary>Transposes the matrix, which flips the columns with the rows</summary>
		/// <returns>Returns the resulting transposed matrix</returns>
		public Matrix Transpose() { return Transpose(ref this); }
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <returns>Returns the resulting negated matrix</returns>
		public Matrix Negate() { return Negate(ref this); }
		
		/// <summary>Adjugates the matrix, getting the transpose of the cofactor matrix</summary>
		/// <returns>Returns the resulting adjugated matrix</returns>
		public Matrix Adjugate() { return Adjugate(ref this); }
		
		/// <summary>Inverts the matrix</summary>
		/// <returns>Returns the resulting inverted matrix</returns>
		public Matrix Invert() { return Invert(ref this); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="vector">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public Vector4 Multiply(Vector4 vector) { return Multiply(ref this, ref vector); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="vector">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public Vector3 Multiply(Vector3 vector) { return Multiply(ref this, ref vector); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="vector">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public Vector2 Multiply(Vector2 vector) { return Multiply(ref this, ref vector); }
		
		/// <summary>Gets the determinant of the matrix</summary>
		/// <returns>Returns the resulting determinant</returns>
		/// <remarks>If the determinant is 0, then the matrix is non-inversible</remarks>
		public float GetDeterminant() { return GetDeterminant(ref this); }
		
		/// <summary>Finds if the two matrices are equal to each other</summary>
		/// <param name="other">The other matrix to find if its equal to</param>
		/// <returns>Returns true if the two matrices are equal to each other</returns>
		public bool Equals(Matrix other) {
			return (
				this.row1 == other.row1 &&
				this.row2 == other.row2 &&
				this.row3 == other.row3 &&
				this.row4 == other.row4
			);
		}
		
		/// <summary>Finds if the two matrices are equal to each other</summary>
		/// <param name="obj">The other matrix to find if its equal to</param>
		/// <returns>Returns true if the two matrices are equal to each other</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Matrix) {
				return this.Equals((Matrix)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the matrix</summary>
		/// <returns>Returns the hash code from the matrix</returns>
		public override int GetHashCode() {
			return (
				this.row1.GetHashCode() ^
				this.row2.GetHashCode() ^
				this.row3.GetHashCode() ^
				this.row4.GetHashCode()
			);
		}
		
		/// <summary>Gets the matrix in string form</summary>
		/// <returns>Returns the matrix in string form</returns>
		public override string ToString() {
			return (
				"{\n" +
				"\trow_1: " + this.row1 + ",\n" +
				"\trow_2: " + this.row2 + ",\n" +
				"\trow_3: " + this.row3 + ",\n" +
				"\trow_4: " + this.row4 + "\n}"
			);
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two matrices are equal to each other</summary>
		/// <param name="left">The first matrix</param>
		/// <param name="right">The second matrix</param>
		/// <returns>Returns true if the two matrices are equal to each other</returns>
		public static bool operator ==(Matrix left, Matrix right) { return left.Equals(right); }
		
		/// <summary>Finds if the two matrices are not equal to each other</summary>
		/// <param name="left">The first matrix</param>
		/// <param name="right">The second matrix</param>
		/// <returns>Returns true if the two matrices are not equal to each other</returns>
		public static bool operator !=(Matrix left, Matrix right) { return !left.Equals(right); }
		
		/// <summary>Adds the two matrices together</summary>
		/// <param name="left">The first matrix</param>
		/// <param name="right">The second matrix</param>
		/// <returns>Returns the resulting matrix that is added together</returns>
		public static Matrix operator +(Matrix left, Matrix right) { return Add(ref left, ref right); }
		
		/// <summary>Subtracts the two matrices from each other</summary>
		/// <param name="left">The first matrix</param>
		/// <param name="right">The second matrix</param>
		/// <returns>Returns the resulting matrix that is subtracting the two given matrices</returns>
		public static Matrix operator -(Matrix left, Matrix right) { return Subtract(ref left, ref right); }
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="left">The scalar to multiply the matrix with</param>
		/// <param name="right">The matrix to multiply with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix operator *(float left, Matrix right) { return Multiply(left, ref right); }
		
		/// <summary>Multiplies the matrix with the given scalar</summary>
		/// <param name="left">The matrix to multiply with</param>
		/// <param name="right">The scalar to multiply the matrix with</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix operator *(Matrix left, float right) { return Multiply(right, ref left); }
		
		/// <summary>Multiplies the matrix with another matrix</summary>
		/// <param name="left">The first matrix</param>
		/// <param name="right">The second matrix</param>
		/// <returns>Returns the resulting multiplied matrix</returns>
		public static Matrix operator *(Matrix left, Matrix right) { return Multiply(ref left, ref right); }
		
		/// <summary>Divides the matrix with the given scalar</summary>
		/// <param name="left">The scalar to divide the matrix with</param>
		/// <param name="right">The matrix to divide with</param>
		/// <returns>Returns the resulting divided matrix</returns>
		public static Matrix operator /(Matrix left, float right) { return Divide(right, ref left); }
		
		/// <summary>Negates the matrix, turning each element into a negative (or positive if the element is negative)</summary>
		/// <param name="matrix">The matrix to negate</param>
		/// <returns>Returns the resulting negated matrix</returns>
		public static Matrix operator -(Matrix matrix) { return Negate(ref matrix); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="left">The matrix to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector4 operator *(Matrix left, Vector4 right) { return Multiply(ref left, ref right); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="left">The matrix to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector3 operator *(Matrix left, Vector3 right) { return Multiply(ref left, ref right); }
		
		/// <summary>Multiplies the matrix with the vector</summary>
		/// <param name="left">The matrix to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns the resulting multipied vector</returns>
		public static Vector2 operator *(Matrix left, Vector2 right) { return Multiply(ref left, ref right); }
		
		#endregion // Operators
	}
}

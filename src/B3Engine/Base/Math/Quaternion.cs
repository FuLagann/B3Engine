
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A structure for a quaternion (a + b i + c j + d k)</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Quaternion : System.IEquatable<Quaternion>, System.IComparable, System.IComparable<Quaternion> {
		#region Field Variables
		// Variables
		/// <summary>The real component of the quaternion</summary>
		public float a;
		/// <summary>The imaginary i component of the quaternion</summary>
		public float b;
		/// <summary>The imaginary j component of the quaternion</summary>
		public float c;
		/// <summary>The imaginary k component of the quaternion</summary>
		public float d;
		/// <summary>The identity quaternion that represents no rotation</summary>
		public static readonly Quaternion Identity = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the magnitude squared of the quaternion</summary>
		public float MagnitudeSquared { get { return (
			this.a * this.a +
			this.b * this.b +
			this.c * this.c +
			this.d * this.d
		); } }
		
		/// <summary>Gets the magnitude of the quaternion</summary>
		public float Magnitude { get {
			// Variables
			float magnitude = this.MagnitudeSquared;
			
			if(magnitude == 0.0f || magnitude == 1.0f) {
				return magnitude;
			}
			
			return Mathx.Sqrt(magnitude);
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a quaternion with setting the values</summary>
		/// <param name="a">The real component of the quaternion</param>
		/// <param name="b">The imaginary i component of the quaternion</param>
		/// <param name="c">The imaginary j component of the quaternion</param>
		/// <param name="d">The imaginary k component of the quaternion</param>
		public Quaternion(float a, float b, float c, float d) {
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region FromEulerAngles Methods
		
		/// <summary>Converts the euler angles (in radians) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromEulerAngles(ref Vector3 eulerAngles, out Quaternion result) {
			// Variables
			float sinYaw = Mathx.Sin(0.5f * eulerAngles.x);
			float cosYaw = Mathx.Cos(0.5f * eulerAngles.x);
			float sinPitch = Mathx.Sin(0.5f * eulerAngles.y);
			float cosPitch = Mathx.Cos(0.5f * eulerAngles.y);
			float sinRoll = Mathx.Sin(0.5f * eulerAngles.z);
			float cosRoll = Mathx.Cos(0.5f * eulerAngles.z);
			
			result.a = cosYaw * cosPitch * cosRoll + sinYaw * sinPitch * sinRoll;
			result.b = sinYaw * cosPitch * cosRoll + cosYaw * sinPitch * sinRoll;
			result.c = cosYaw * sinPitch * cosRoll - sinYaw * cosPitch * sinRoll;
			result.d = cosYaw * cosPitch * sinRoll - sinYaw * sinPitch * cosRoll;
		}
		
		/// <summary>Converts the euler angles (in radians) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromEulerAngles(Vector3 eulerAngles, out Quaternion result) { FromEulerAngles(ref eulerAngles, out result); }
		
		/// <summary>Converts the euler angles (in radians) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAngles(ref Vector3 eulerAngles) {
			// Variables
			Quaternion result;
			
			FromEulerAngles(ref eulerAngles, out result);
			
			return result;
		}
		
		/// <summary>Converts the euler angles (in radians) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAngles(Vector3 eulerAngles) { return FromEulerAngles(ref eulerAngles); }
		
		/// <summary>Converts the euler angles (in radians) into a rotation quaternion</summary>
		/// <param name="x">The angle rotating around the x-axis</param>
		/// <param name="y">The angle rotating around the y-axis</param>
		/// <param name="z">The angle rotating around the z-axis</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAngles(float x, float y, float z) { return FromEulerAngles(new Vector3(x, y, z)); }
		
		#endregion // FromEulerAngles Methods
		
		#region FromEulerAnglesDeg Methods
		
		/// <summary>Converts the euler angles (in degrees) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromEulerAnglesDeg(ref Vector3 eulerAngles, out Quaternion result) {
			// Variables
			Vector3 eulerAnglesRadians;
			
			eulerAnglesRadians.x = Mathx.DegToRad * eulerAngles.x;
			eulerAnglesRadians.y = Mathx.DegToRad * eulerAngles.y;
			eulerAnglesRadians.z = Mathx.DegToRad * eulerAngles.z;
			
			FromEulerAngles(ref eulerAnglesRadians, out result);
		}
		
		/// <summary>Converts the euler angles (in degrees) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromEulerAnglesDeg(Vector3 eulerAngles, out Quaternion result) { FromEulerAnglesDeg(ref eulerAngles, out result); }
		
		/// <summary>Converts the euler angles (in degrees) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAnglesDeg(ref Vector3 eulerAngles) {
			// Variables
			Quaternion result;
			
			FromEulerAnglesDeg(ref eulerAngles, out result);
			
			return result;
		}
		
		/// <summary>Converts the euler angles (in degrees) into a rotation quaternion</summary>
		/// <param name="eulerAngles">The angles rotating around the relative axis used to create the quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAnglesDeg(Vector3 eulerAngles) { return FromEulerAnglesDeg(ref eulerAngles); }
		
		/// <summary>Converts the euler angles (in degrees) into a rotation quaternion</summary>
		/// <param name="x">The angle rotating around the x-axis</param>
		/// <param name="y">The angle rotating around the y-axis</param>
		/// <param name="z">The angle rotating around the z-axis</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromEulerAnglesDeg(float x, float y, float z) { return FromEulerAnglesDeg(new Vector3(x, y, z)); }
		
		#endregion // FromEulerAnglesDeg Methods
		
		#region FromAxisAngle Methods
		
		/// <summary>Creates a rotation quaternion over the given axis and angle</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle that the quaternion will rotate around</param>
		/// <param name="result">The resulting rotation quaternion</param>
		public static void FromAxisAngle(ref Vector3 axis, float theta, out Quaternion result) {
			// Variables
			float sin = Mathx.Sin(0.5f * theta);
			Vector3 temp;
			
			Mathx.Normalize(ref axis, out temp);
			
			result.a = Mathx.Cos(0.5f * theta);
			result.b = sin * temp.x;
			result.c = sin * temp.y;
			result.d = sin * temp.z;
		}
		
		/// <summary>Creates a rotation quaternion over the given axis and angle</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle that the quaternion will rotate around</param>
		/// <param name="result">The resulting rotation quaternion</param>
		public static void FromAxisAngle(Vector3 axis, float theta, out Quaternion result) { FromAxisAngle(ref axis, theta, out result); }
		
		/// <summary>Creates a rotation quaternion over the given axis and angle</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle that the quaternion will rotate around</param>
		/// <returns>Returns the resulting rotation quaternion</returns>
		public static Quaternion FromAxisAngle(ref Vector3 axis, float theta) {
			// Variables
			Quaternion result;
			
			FromAxisAngle(ref axis, theta, out result);
			
			return result;
		}
		
		/// <summary>Creates a rotation quaternion over the given axis and angle (in radians)</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle (in radians) that the quaternion will rotate around</param>
		/// <returns>Returns the resulting rotation quaternion</returns>
		public static Quaternion FromAxisAngle(Vector3 axis, float theta) { return FromAxisAngle(ref axis, theta); }
		
		#endregion // FromAxisAngle Methods
		
		#region FromAxisAngleDeg Methods
		
		/// <summary>Creates a rotation quaternion over the given axis and angle (in degrees)</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle (in degrees) that the quaternion will rotate around</param>
		/// <param name="result">The resulting rotation quaternion</param>
		public static void FromAxisAngleDeg(ref Vector3 axis, float theta, out Quaternion result) { FromAxisAngle(ref axis, Mathx.DegToRad * theta, out result); }
		
		/// <summary>Creates a rotation quaternion over the given axis and angle (in degrees)</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle (in degrees) that the quaternion will rotate around</param>
		/// <param name="result">The resulting rotation quaternion</param>
		public static void FromAxisAngleDeg(Vector3 axis, float theta, out Quaternion result) { FromAxisAngleDeg(ref axis, theta, out result); }
		
		/// <summary>Creates a rotation quaternion over the given axis and angle (in degrees)</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle (in degrees) that the quaternion will rotate around</param>
		/// <returns>Returns the resulting rotation quaternion</returns>
		public static Quaternion FromAxisAngleDeg(ref Vector3 axis, float theta) {
			// Variables
			Quaternion result;
			
			FromAxisAngleDeg(ref axis, theta, out result);
			
			return result;
		}
		
		/// <summary>Creates a rotation quaternion over the given axis and angle (in degrees)</summary>
		/// <param name="axis">The arbitrary axis that the quaternion will rotate around</param>
		/// <param name="theta">The angle (in degrees) that the quaternion will rotate around</param>
		/// <returns>Returns the resulting rotation quaternion</returns>
		public static Quaternion FromAxisAngleDeg(Vector3 axis, float theta) { return FromAxisAngleDeg(ref axis, theta); }
		
		#endregion // FromAxisAngleDeg Methods
		
		#region FromMatrix Methods
		
		/// <summary>Creates a quaternion from a given rotation matrix</summary>
		/// <param name="matrix">The matrix to convert into a quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromMatrix(ref Matrix matrix, out Quaternion result) {
			result.a = 0.5f * Mathx.Sqrt(1.0f + matrix.A11 + matrix.A22 + matrix.A33);
			result.b = (matrix.A32 - matrix.A23) / (4.0f * result.a);
			result.c = (matrix.A13 - matrix.A31) / (4.0f * result.a);
			result.d = (matrix.A21 - matrix.A12) / (4.0f * result.a);
		}
		
		/// <summary>Creates a quaternion from a given rotation matrix</summary>
		/// <param name="matrix">The matrix to convert into a quaternion</param>
		/// <param name="result">The resulting quaternion</param>
		public static void FromMatrix(Matrix matrix, out Quaternion result) { FromMatrix(ref matrix, out result); }
		
		/// <summary>Creates a quaternion from a given rotation matrix</summary>
		/// <param name="matrix">The matrix to convert into a quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromMatrix(ref Matrix matrix) {
			// Variables
			Quaternion result;
			
			FromMatrix(ref matrix, out result);
			
			return result;
		}
		
		/// <summary>Creates a quaternion from a given rotation matrix</summary>
		/// <param name="matrix">The matrix to convert into a quaternion</param>
		/// <returns>Returns the resulting quaternion</returns>
		public static Quaternion FromMatrix(Matrix matrix) { return FromMatrix(ref matrix); }
		
		#endregion // FromMatrix Methods
		
		// Testing for this does not work, checking all the sources the code should be correct but since it's not and it's faulty, it'll be commented out until it can be figured out
		// TODO: Find a way to correct this
		// #region ToEulerAngles Methods
		
		// /// <summary>Converts the quaternion into a vector holding the euler angles (yaw, pitch, roll)</summary>
		// /// <param name="quaternion">The quaternion to convert</param>
		// /// <param name="result">The resulting vector holding the euler angles (yaw, pitch, roll)</param>
		// public static void ToEulerAngles(ref Quaternion quaternion, out Vector3 result) {
		// 	result.x = Mathx.Arctan(
		// 		2.0f * (quaternion.a * quaternion.b + quaternion.c * quaternion.d),
		// 		1.0f - 2.0f * (quaternion.b * quaternion.b + quaternion.c * quaternion.c)
		// 	);
		// 	result.y = Mathx.Arcsin(
		// 		2.0f * (quaternion.a * quaternion.c - quaternion.d * quaternion.b)
		// 	);
		// 	result.z = Mathx.Arctan(
		// 		2.0f * (quaternion.a * quaternion.d + quaternion.b * quaternion.c),
		// 		1.0f - 2.0f * (quaternion.c * quaternion.c + quaternion.d * quaternion.d)
		// 	);
		// }
		
		// /// <summary>Converts the quaternion into a vector holding the euler angles (yaw, pitch, roll)</summary>
		// /// <param name="quaternion">The quaternion to convert</param>
		// /// <param name="result">The resulting vector holding the euler angles (yaw, pitch, roll)</param>
		// public static void ToEulerAngles(Quaternion quaternion, out Vector3 result) { ToEulerAngles(ref quaternion, out result); }
		
		// /// <summary>Converts the quaternion into a vector holding the euler angles (yaw, pitch, roll)</summary>
		// /// <param name="quaternion">The quaternion to convert</param>
		// /// <returns>Return the resulting vector holding the euler angles (yaw, pitch, roll)</returns>
		// public static Vector3 ToEulerAngles(ref Quaternion quaternion) {
		// 	// Variables
		// 	Vector3 result;
			
		// 	ToEulerAngles(ref quaternion, out result);
			
		// 	return result;
		// }
		
		// /// <summary>Converts the quaternion into a vector holding the euler angles (yaw, pitch, roll)</summary>
		// /// <param name="quaternion">The quaternion to convert</param>
		// /// <returns>Return the resulting vector holding the euler angles (yaw, pitch, roll)</returns>
		// public static Vector3 ToEulerAngles(Quaternion quaternion) { return ToEulerAngles(ref quaternion); }
		
		// #endregion // ToEulerAngles
		
		#region ToMatrix Methods
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void ToMatrix(ref Quaternion quaternion, out Matrix result) {
			// Row 1
			result.row1.x = 1.0f - 2.0f * quaternion.c * quaternion.c - 2.0f * quaternion.d * quaternion.d;
			result.row1.y = 2.0f * quaternion.b * quaternion.c - 2.0f * quaternion.a * quaternion.d;
			result.row1.z = 2.0f * quaternion.b * quaternion.d + 2.0f * quaternion.a * quaternion.c;
			result.row1.w = 0.0f;
			
			// Row 2
			result.row2.x = 2.0f * quaternion.b * quaternion.c + 2.0f * quaternion.a * quaternion.d;
			result.row2.y = 1.0f - 2.0f * quaternion.b * quaternion.b - 2.0f * quaternion.d * quaternion.d;
			result.row2.z = 2.0f * quaternion.c * quaternion.d - 2.0f * quaternion.a * quaternion.b;
			result.row2.w = 0.0f;
			
			// Row 3
			result.row3.x = 2.0f * quaternion.b * quaternion.d - 2.0f * quaternion.a * quaternion.c;
			result.row3.y = 2.0f * quaternion.c * quaternion.d + 2.0f * quaternion.a * quaternion.b;
			result.row3.z = 1.0f - 2.0f * quaternion.b * quaternion.b - 2.0f * quaternion.c * quaternion.c;
			result.row3.w = 0.0f;
			
			// Row 4
			result.row4.x = 0.0f;
			result.row4.y = 0.0f;
			result.row4.z = 0.0f;
			result.row4.w = 1.0f;
		}
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <param name="result">The resulting rotation matrix</param>
		public static void ToMatrix(Quaternion quaternion, out Matrix result) { ToMatrix(ref quaternion, out result); }
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix ToMatrix(ref Quaternion quaternion) {
			// Variables
			Matrix result;
			
			ToMatrix(ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <param name="quaternion">The quaternion to create a rotation matrix from</param>
		/// <returns>Returns the resulting rotation matrix</returns>
		public static Matrix ToMatrix(Quaternion quaternion) { return ToMatrix(ref quaternion); }
		
		#endregion // ToMatrix Methods
		
		#region Conjugate Methods
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <param name="result">The resulting conjugated quaternion</param>
		public static void Conjugate(ref Quaternion quaternion, out Quaternion result) {
			result.a = quaternion.a;
			result.b = -quaternion.b;
			result.c = -quaternion.c;
			result.d = -quaternion.d;
		}
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <param name="result">The resulting conjugated quaternion</param>
		public static void Conjugate(Quaternion quaternion, out Quaternion result) { Conjugate(ref quaternion, out result); }
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <returns>Returns the resulting conjugated quaternion</returns>
		public static Quaternion Conjugate(ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Conjugate(ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <returns>Returns the resulting conjugated quaternion</returns>
		public static Quaternion Conjugate(Quaternion quaternion) { return Conjugate(ref quaternion); }
		
		#endregion // Conjugate Methods
		
		#region Add Methods
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <param name="result">The resulting quaternion that's added together</param>
		public static void Add(ref Quaternion a, ref Quaternion b, out Quaternion result) {
			result.a = a.a + b.a;
			result.b = a.b + b.b;
			result.c = a.c + b.c;
			result.d = a.d + b.d;
		}
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <param name="result">The resulting quaternion that's added together</param>
		public static void Add(Quaternion a, Quaternion b, out Quaternion result) { Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <returns>Returns the resulting quaternion that's added together</returns>
		public static Quaternion Add(ref Quaternion a, ref Quaternion b) {
			// Variables
			Quaternion result;
			
			Add(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <returns>Returns the resulting quaternion that's added together</returns>
		public static Quaternion Add(Quaternion a, Quaternion b) { return Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <param name="result">The resulting quaternion that's subtracted from each other</param>
		public static void Subtract(ref Quaternion a, ref Quaternion b, out Quaternion result) {
			result.a = a.a - b.a;
			result.b = a.b - b.b;
			result.c = a.c - b.c;
			result.d = a.d - b.d;
		}
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <param name="result">The resulting quaternion that's subtracted from each other</param>
		public static void Subtract(Quaternion a, Quaternion b, out Quaternion result) { Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public static Quaternion Subtract(ref Quaternion a, ref Quaternion b) {
			// Variables
			Quaternion result;
			
			Subtract(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public static Quaternion Subtract(Quaternion a, Quaternion b) { return Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Negate Methods
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <param name="result">The resulting negated quaternion</param>
		public static void Negate(ref Quaternion quaternion, out Quaternion result) {
			result.a = -quaternion.a;
			result.b = -quaternion.b;
			result.c = -quaternion.c;
			result.d = -quaternion.d;
		}
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <param name="result">The resulting negated quaternion</param>
		public static void Negate(Quaternion quaternion, out Quaternion result) { Negate(ref quaternion, out result); }
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <returns>Returns the resulting negated quaternion</returns>
		public static Quaternion Negate(ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Negate(ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <returns>Returns the resulting negated quaternion</returns>
		public static Quaternion Negate(Quaternion quaternion) { return Negate(ref quaternion); }
		
		#endregion // Negate Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Multiply(float scalar, ref Quaternion quaternion, out Quaternion result) {
			result.a = scalar * quaternion.a;
			result.b = scalar * quaternion.b;
			result.c = scalar * quaternion.c;
			result.d = scalar * quaternion.d;
		}
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Multiply(float scalar, Quaternion quaternion, out Quaternion result) { Multiply(scalar, ref quaternion, out result); }
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Multiply(float scalar, ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Multiply(scalar, ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Multiply(float scalar, Quaternion quaternion) { return Multiply(scalar, ref quaternion); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting multiplied quaternion</param>
		public static void Multiply(ref Quaternion a, ref Quaternion b, out Quaternion result) {
			// Variables
			Quaternion temp;
			
			temp.a = (a.a * b.a - a.b * b.b - a.c * b.c - a.d * b.d);
			temp.b = (a.b * b.a + a.a * b.b + a.c * b.d - a.d * b.c);
			temp.c = (a.c * b.a + a.a * b.c + a.d * b.b - a.b * b.d);
			temp.d = (a.d * b.a + a.a * b.d + a.b * b.c - a.c * b.b);
			
			result = temp;
		}
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting multiplied quaternion</param>
		public static void Multiply(Quaternion a, Quaternion b, out Quaternion result) { Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting multiplied quaternion</returns>
		public static Quaternion Multiply(ref Quaternion a, ref Quaternion b) {
			// Variables
			Quaternion result;
			
			Multiply(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting multiplied quaternion</returns>
		public static Quaternion Multiply(Quaternion a, Quaternion b) { return Multiply(ref a, ref b); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector4 vec, out Vector4 result) {
			// Variables
			Quaternion temp = new Quaternion(vec.w, vec.x, vec.y, vec.z);
			Quaternion conjugated;
			
			Conjugate(ref quaternion, out conjugated);
			Multiply(ref quaternion, ref temp, out temp);
			Multiply(ref temp, ref conjugated, out temp);
			
			result.x = temp.b;
			result.y = temp.c;
			result.z = temp.d;
			result.w = temp.a;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(Quaternion quaternion, Vector4 vec, out Vector4 result) { Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector4 Multiply(ref Quaternion quaternion, ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Multiply(ref quaternion, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector4 Multiply(Quaternion quaternion, Vector4 vec) { return Multiply(ref quaternion, ref vec); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector3 vec, out Vector3 result) {
			// Variables
			Quaternion temp = new Quaternion(0.0f, vec.x, vec.y, vec.z);
			Quaternion conjugated;
			
			Conjugate(ref quaternion, out conjugated);
			Multiply(ref quaternion, ref temp, out temp);
			Multiply(ref temp, ref conjugated, out temp);
			
			result.x = temp.b;
			result.y = temp.c;
			result.z = temp.d;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(Quaternion quaternion, Vector3 vec, out Vector3 result) { Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector3 Multiply(ref Quaternion quaternion, ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Multiply(ref quaternion, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector3 Multiply(Quaternion quaternion, Vector3 vec) { return Multiply(ref quaternion, ref vec); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector2 vec, out Vector2 result) {
			// Variables
			Quaternion temp = new Quaternion(0.0f, vec.x, vec.y, 0.0f);
			Quaternion conjugated;
			
			Conjugate(ref quaternion, out conjugated);
			Multiply(ref quaternion, ref temp, out temp);
			Multiply(ref temp, ref conjugated, out temp);
			
			result.x = temp.b;
			result.y = temp.c;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(Quaternion quaternion, Vector2 vec, out Vector2 result) { Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector2 Multiply(ref Quaternion quaternion, ref Vector2 vec) {
			// Variables
			Vector2 result;
			
			Multiply(ref quaternion, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>Returns the resulting rotated vector</returns>
		public static Vector2 Multiply(Quaternion quaternion, Vector2 vec) { return Multiply(ref quaternion, ref vec); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Divide(float scalar, ref Quaternion quaternion, out Quaternion result) {
			if(scalar == 0.0f) {
				throw new System.ArgumentOutOfRangeException("scalar", scalar, "Cannot divide by zero!");
			}
			result.a = quaternion.a / scalar;
			result.b = quaternion.b / scalar;
			result.c = quaternion.c / scalar;
			result.d = quaternion.d / scalar;
		}
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Divide(float scalar, Quaternion quaternion, out Quaternion result) { Divide(scalar, ref quaternion, out result); }
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Divide(float scalar, ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Divide(scalar, ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Divide(float scalar, Quaternion quaternion) { return Divide(scalar, ref quaternion); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting divided quaternion</param>
		public static void Divide(ref Quaternion a, ref Quaternion b, out Quaternion result) {
			// Variables
			float magnitude = b.MagnitudeSquared;
			Quaternion temp;
			
			if(magnitude == 0.0f) {
				throw new System.ArgumentOutOfRangeException("b", b, "Cannot divide by zero!");
			}
			Conjugate(ref b, out temp);
			Multiply(ref a, ref temp, out result);
			if(magnitude != 1.0f) {
				Divide(magnitude, ref result, out result);
			}
		}
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting divided quaternion</param>
		public static void Divide(Quaternion a, Quaternion b, out Quaternion result) { Divide(ref a, ref b, out result); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting divided quaternion</returns>
		public static Quaternion Divide(ref Quaternion a, ref Quaternion b) {
			// Variables
			Quaternion result;
			
			Divide(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting divided quaternion</returns>
		public static Quaternion Divide(Quaternion a, Quaternion b) { return Divide(ref a, ref b); }
		
		#endregion // Divide Methods
		
		#region Invert Methods
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <param name="result">The resulting inverted quaternion</param>
		public static void Invert(ref Quaternion quaternion, out Quaternion result) {
			// Variables
			float magnitude = quaternion.MagnitudeSquared;
			
			if(magnitude == 0.0f) {
				result = quaternion;
				return;
			}
			
			Conjugate(ref quaternion, out result);
			if(magnitude != 1.0f) {
				Divide(magnitude, ref result, out result);
			}
		}
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <param name="result">The resulting inverted quaternion</param>
		public static void Invert(Quaternion quaternion, out Quaternion result) { Invert(ref quaternion, out result); }
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <returns>Returns the resulting inverted quaternion</returns>
		public static Quaternion Invert(ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Invert(ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <returns>Returns the resulting inverted quaternion</returns>
		public static Quaternion Invert(Quaternion quaternion) { return Invert(ref quaternion); }
		
		#endregion // Invert Methods
		
		#region Normalize Methods
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <param name="result">The resulting normalized quaternion</param>
		public static void Normalize(ref Quaternion quaternion, out Quaternion result) {
			// Variables
			float magnitude = quaternion.Magnitude;
			
			if(magnitude == 0.0f || magnitude == 1.0f) {
				result = quaternion;
				return;
			}
			Divide(magnitude, ref quaternion, out result);
		}
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <param name="result">The resulting normalized quaternion</param>
		public static void Normalize(Quaternion quaternion, out Quaternion result) { Normalize(ref quaternion, out result); }
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <returns>Returns the resulting normalized quaternion</returns>
		public static Quaternion Normalize(ref Quaternion quaternion) {
			// Variables
			Quaternion result;
			
			Normalize(ref quaternion, out result);
			
			return result;
		}
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <returns>Returns the resulting normalized quaternion</returns>
		public static Quaternion Normalize(Quaternion quaternion) { return Normalize(ref quaternion); }
		
		#endregion // Normalize Methods
		
		#region Dot Methods
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting floating point number representing the angle between the two quaternions</param>
		public static void Dot(ref Quaternion a, ref Quaternion b, out float result) {
			result = a.a * b.a + a.b * b.b + a.c * b.c + a.d * b.d;
		}
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting floating point number representing the angle between the two quaternions</param>
		public static void Dot(Quaternion a, Quaternion b, out float result) { Dot(ref a, ref b, out result); }
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting floating point number representing the angle between the two quaternions</returns>
		public static float Dot(ref Quaternion a, ref Quaternion b) {
			// Variables
			float result;
			
			Dot(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting floating point number representing the angle between the two quaternions</returns>
		public static float Dot(Quaternion a, Quaternion b) { return Dot(ref a, ref b); }
		
		#endregion // Dot Methods
		
		#region Approx Methods
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the quaternions are approximately close to each other</param>
		public static void Approx(ref Quaternion a, ref Quaternion b, float epsilon, out bool result) {
			result = (
				Mathx.Approx(a.a, b.a, epsilon) &&
				Mathx.Approx(a.b, b.b, epsilon) &&
				Mathx.Approx(a.c, b.c, epsilon) &&
				Mathx.Approx(a.d, b.d, epsilon)
			);
		}
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the quaternions are approximately close to each other</param>
		public static void Approx(Quaternion a, Quaternion b, float epsilon, out bool result) { Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(ref Quaternion a, ref Quaternion b, float epsilon) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, epsilon, out result);
			
			return result;
		}
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(Quaternion a, Quaternion b, float epsilon) { return Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="result">Set to true if the quaternions are approximately close to each other</param>
		public static void Approx(ref Quaternion a, ref Quaternion b, out bool result) {
			result = (
				Mathx.Approx(a.a, b.a) &&
				Mathx.Approx(a.b, b.b) &&
				Mathx.Approx(a.c, b.c) &&
				Mathx.Approx(a.d, b.d)
			);
		}
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="result">Set to true if the quaternions are approximately close to each other</param>
		public static void Approx(Quaternion a, Quaternion b, out bool result) { Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(ref Quaternion a, ref Quaternion b) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(Quaternion a, Quaternion b) { return Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Slerp Methods
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <param name="result">The resulting linearly interpolated quaternion</param>
		public static void Slerp(ref Quaternion a, ref Quaternion b, float t, out Quaternion result) {
			// Variables
			Quaternion ua, ub, uc;
			float theta;
			float dot;
			
			Normalize(ref a, out ua);
			Normalize(ref b, out ub);
			Dot(ref ua, ref ub, out dot);
			
			if(dot < 0.0f) {
				ub = -ub;
				dot = -dot;
			}
			if(dot > 0.9995f) {
				Subtract(ref ub, ref ua, out ub);
				Multiply(t, ref ub, out ub);
				Add(ref ua, ref ub, out result);
				Normalize(ref result, out result);
				return;
			}
			
			theta = t * Mathx.Arccos(dot);
			Multiply(dot, ref ua, out uc);
			Subtract(ref ub, ref uc, out ub);
			Normalize(ref ub, out ub);
			Multiply(Mathx.Cos(theta), ref ua, out ua);
			Multiply(Mathx.Sin(theta), ref ub, out ub);
			Add(ref ua, ref ub, out result);
		}
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <param name="result">The resulting linearly interpolated quaternion</param>
		public static void Slerp(Quaternion a, Quaternion b, float t, out Quaternion result) { Slerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <returns>Returns the resulting linearly interpolated quaternion</returns>
		public static Quaternion Slerp(ref Quaternion a, ref Quaternion b, float t) {
			// Variables
			Quaternion result;
			
			Slerp(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <returns>Returns the resulting linearly interpolated quaternion</returns>
		public static Quaternion Slerp(Quaternion a, Quaternion b, float t) { return Slerp(ref a, ref b, t); }
		
		#endregion // Slerp Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		// /// <summary>Converts the quaternion into a vector holding the euler angles (yaw, pitch, roll)</summary>
		//  /// <returns>Return the resulting vector holding the euler angles (yaw, pitch, roll)</returns>
		// public Vector3 ToEulerAngles() { return ToEulerAngles(ref this); }
		
		/// <summary>Creates a rotation matrix from the quaternion</summary>
		/// <returns>Returns the resulting rotation matrix</returns>
		public Matrix ToMatrix() { return ToMatrix(ref this); }
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="other">The other quaternion to add together</param>
		/// <returns>Returns the resulting quaternion that's added together</returns>
		public Quaternion Add(Quaternion other) { return Add(ref this, ref other); }
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="other">The other quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public Quaternion Subtract(Quaternion other) { return Subtract(ref this, ref other); }
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <returns>Returns the resulting negated quaternion</returns>
		public Quaternion Negate() { return Negate(ref this); }
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public Quaternion Multiply(float scalar) { return Multiply(scalar, ref this); }
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <returns>Returns the resulting conjugated quaternion</returns>
		public Quaternion Conjugate() { return Conjugate(ref this); }
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public Quaternion Divide(float scalar) { return Divide(scalar, ref this); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="other">The other quaternion</param>
		/// <returns>Returns the resulting multiplied quaternion</returns>
		public Quaternion Multiply(Quaternion other) { return Multiply(ref this, ref other); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="other">The other quaternion</param>
		/// <returns>Returns the resulting divided quaternion</returns>
		public Quaternion Divide(Quaternion other) { return Divide(ref this, ref other); }
		
		/// <summary>Inverts the quaternion</summary>
		/// <returns>Returns the resulting inverted quaternion</returns>
		public Quaternion Invert() { return Invert(ref this); }
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="other">The other quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <returns>Returns the resulting linearly interpolated quaternion</returns>
		public Quaternion Slerp(Quaternion other, float t) { return Slerp(ref this, ref other, t); }
		
		/// <summary>Normalizes the quaternion</summary>
		/// <returns>Returns the resulting normalized quaternion</returns>
		public Quaternion Normalize() { return Normalize(ref this); }
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="other">The other quaternion</param>
		/// <returns>Returns the resulting floating point number representing the angle between the two quaternions</returns>
		public float Dot(Quaternion other) { return Dot(ref this, ref other); }
		
		/// <summary>Finds if this quaternion and the other quaternion are equal to each other</summary>
		/// <param name="other">The other quaternion to find if they are equal</param>
		/// <returns>Returns true if the two quaternions are equal</returns>
		public bool Equals(Quaternion other) { return (this.a == other.a && this.b == other.b && this.c == other.c && this.d == other.d); }
		
		/// <summary>Compares the two quaternions for sorting</summary>
		/// <param name="other">The other quaternion</param>
		/// <returns>Returns 0 if the two quaternions are the same, &gt; 0 if this quaternion is bigger than the other quaternion, and &lt; 0 otherwise</returns>
		public int CompareTo(Quaternion other) { return (int)(this.Magnitude - other.Magnitude); }
		
		/// <summary>Compares the two quaternions for sorting</summary>
		/// <param name="other">The other quaternion</param>
		/// <returns>Returns 0 if the two quaternions are the same, &gt; 0 if this quaternion is bigger than the other quaternion, and &lt; 0 otherwise</returns>
		public int CompareTo(object other) {
			if(other == null) {
				return 1;
			}
			if(other is Quaternion) {
				return CompareTo((Quaternion)other);
			}
			return 1;
		}
		
		/// <summary>Finds if this quaternion and the other quaternion are equal to each other</summary>
		/// <param name="obj">The other quaternion to find if they are equal</param>
		/// <returns>Returns true if the two quaternions are equal</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Quaternion) {
				return this.Equals((Quaternion)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the quaternion</summary>
		/// <returns>Returns the hash code from the quaternion</returns>
		public override int GetHashCode() { return (int)this.a ^ (int)this.b ^ (int)this.c ^ (int)this.d; }
		
		/// <summary>Gets the quaternion in string form</summary>
		/// <returns>Returns the quaternion in string form</returns>
		public override string ToString() {
			return (
				"{ a: " + this.a +
				", b: " + this.b +
				", c: " + this.c +
				", d: " + this.d + " }"
			);
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two quaternions are equal to each other</summary>
		/// <param name="left">The first quaternion</param>
		/// <param name="right">The second quaternion</param>
		/// <returns>Returns true if the two quaternions are equal to each other</returns>
		public static bool operator ==(Quaternion left, Quaternion right) { return left.Equals(right); }
		
		/// <summary>Finds if the two quaternions are not equal to each other</summary>
		/// <param name="left">The first quaternion</param>
		/// <param name="right">The second quaternion</param>
		/// <returns>Returns true if the two quaternions are not equal to each other</returns>
		public static bool operator !=(Quaternion left, Quaternion right) { return !left.Equals(right); }
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="left">The first quaternion to subtract with</param>
		/// <param name="right">The second quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public static Quaternion operator +(Quaternion left, Quaternion right) { return Add(ref left, ref right); }
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="left">The first quaternion to subtract with</param>
		/// <param name="right">The second quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public static Quaternion operator -(Quaternion left, Quaternion right) { return Subtract(ref left, ref right); }
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <returns>Returns the resulting negated quaternion</returns>
		public static Quaternion operator -(Quaternion quaternion) { return Negate(ref quaternion); }
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="left">The scalar to multiply the quaternion with</param>
		/// <param name="right">The quaternion used to multiply with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion operator *(float left, Quaternion right) { return Multiply(left, ref right); }
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="left">The quaternion used to multiply with</param>
		/// <param name="right">The scalar to multiply the quaternion with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion operator *(Quaternion left, float right) { return Multiply(right, ref left); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="left">The first quaternion</param>
		/// <param name="right">The second quaternion</param>
		/// <returns>Returns the resulting multiplied quaternion</returns>
		public static Quaternion operator *(Quaternion left, Quaternion right) { return Multiply(ref left, ref right); }
		
		/// <summary>Multiplies the vector with the quaternion</summary>
		/// <param name="left">The quaternion to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns a transformed vector</returns>
		public static Vector4 operator *(Quaternion left, Vector4 right) { return Multiply(ref left, ref right); }
		
		/// <summary>Multiplies the vector with the quaternion</summary>
		/// <param name="left">The quaternion to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns a transformed vector</returns>
		public static Vector3 operator *(Quaternion left, Vector3 right) { return Multiply(ref left, ref right); }
		
		/// <summary>Multiplies the vector with the quaternion</summary>
		/// <param name="left">The quaternion to multiply with</param>
		/// <param name="right">The vector to multiply with</param>
		/// <returns>Returns a transformed vector</returns>
		public static Vector2 operator *(Quaternion left, Vector2 right) { return Multiply(ref left, ref right); }
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="left">The quaternion to divide with</param>
		/// <param name="right">The scalar to divide the quaternion with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion operator /(Quaternion left, float right) { return Divide(right, ref left); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="left">The first quaternion</param>
		/// <param name="right">The second quaternion</param>
		/// <returns>Returns the resulting divided quaternion</returns>
		public static Quaternion operator /(Quaternion left, Quaternion right) { return Divide(ref left, ref right); }
		
		#endregion // Operators
	}
}

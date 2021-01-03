
namespace B3 {
	public static partial class Mathx {
		#region Public Static Methods
		
		#region Conjugate Methods
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <param name="result">The resulting conjugated quaternion</param>
		public static void Conjugate(ref Quaternion quaternion, out Quaternion result) { Quaternion.Conjugate(ref quaternion, out result); }
		
		/// <summary>Conjugates the quaternion, so it turns it from (a + b i + c j + d k) to (a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to conjugate</param>
		/// <returns>Returns the resulting conjugated quaternion</returns>
		public static Quaternion Conjugate(ref Quaternion quaternion) { return Quaternion.Conjugate(ref quaternion); }
		
		#endregion // Conjugate Methods
		
		#region Add Methods
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <param name="result">The resulting quaternion that's added together</param>
		public static void Add(ref Quaternion a, ref Quaternion b, out Quaternion result) { Quaternion.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two quaternions together</summary>
		/// <param name="a">The first quaternion to add together</param>
		/// <param name="b">The second quaternion to add together</param>
		/// <returns>Returns the resulting quaternion that's added together</returns>
		public static Quaternion Add(ref Quaternion a, ref Quaternion b) { return Quaternion.Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <param name="result">The resulting quaternion that's subtracted from each other</param>
		public static void Subtract(ref Quaternion a, ref Quaternion b, out Quaternion result) { Quaternion.Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts the two quaternions from each other</summary>
		/// <param name="a">The first quaternion to subtract with</param>
		/// <param name="b">The second quaternion to subtract with</param>
		/// <returns>Returns the resulting quaternion that's subtracted from each other</returns>
		public static Quaternion Subtract(ref Quaternion a, ref Quaternion b) { return Quaternion.Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Negate Methods
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <param name="result">The resulting negated quaternion</param>
		public static void Negate(ref Quaternion quaternion, out Quaternion result) { Quaternion.Negate(ref quaternion, out result); }
		
		/// <summary>Negates the quaternion, so it turns (a + b i + c j + d k) to (- a - b i - c j - d k)</summary>
		/// <param name="quaternion">The quaternion to negate</param>
		/// <returns>Returns the resulting negated quaternion</returns>
		public static Quaternion Negate(ref Quaternion quaternion) {return Quaternion.Negate(ref quaternion); }
		
		#endregion // Negate Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Multiply(float scalar, ref Quaternion quaternion, out Quaternion result) { Quaternion.Multiply(scalar, ref quaternion, out result); }
		
		/// <summary>Multiplies the quaternion with the scalar</summary>
		/// <param name="scalar">The scalar to multiply the quaternion with</param>
		/// <param name="quaternion">The quaternion used to multiply with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Multiply(float scalar, ref Quaternion quaternion) { return Quaternion.Multiply(scalar, ref quaternion); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting multiplied quaternion</param>
		public static void Multiply(ref Quaternion a, ref Quaternion b, out Quaternion result) { Quaternion.Multiply(ref a, ref b, out result); }
		
		/// <summary>Multiplies the two quaternions together</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting multiplied quaternion</returns>
		public static Quaternion Multiply(ref Quaternion a, ref Quaternion b) { return Quaternion.Multiply(ref a, ref b); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector4 vec, out Vector4 result) { Quaternion.Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>The resulting rotated vector</returns>
		public static Vector4 Multiply(ref Quaternion quaternion, ref Vector4 vec) { return Quaternion.Multiply(ref quaternion, ref vec); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector3 vec, out Vector3 result) { Quaternion.Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>The resulting rotated vector</returns>
		public static Vector3 Multiply(ref Quaternion quaternion, ref Vector3 vec) { return Quaternion.Multiply(ref quaternion, ref vec); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <param name="result">The resulting rotated vector</param>
		public static void Multiply(ref Quaternion quaternion, ref Vector2 vec, out Vector2 result) { Quaternion.Multiply(ref quaternion, ref vec, out result); }
		
		/// <summary>Multiplies the quaternion with the vector to rotate the vector</summary>
		/// <param name="quaternion">The quaternion used to rotate</param>
		/// <param name="vec">The vector used to rotate</param>
		/// <returns>The resulting rotated vector</returns>
		public static Vector2 Multiply(ref Quaternion quaternion, ref Vector2 vec) { return Quaternion.Multiply(ref quaternion, ref vec); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <param name="result">The resulting scaled quaternion</param>
		public static void Divide(float scalar, ref Quaternion quaternion, out Quaternion result) { Quaternion.Divide(scalar, ref quaternion, out result); }
		
		/// <summary>Divides the quaternion with the given scalar</summary>
		/// <param name="scalar">The scalar to divide the quaternion with</param>
		/// <param name="quaternion">The quaternion to divide with</param>
		/// <returns>Returns the resulting scaled quaternion</returns>
		public static Quaternion Divide(float scalar, ref Quaternion quaternion) { return Quaternion.Divide(scalar, ref quaternion); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting divided quaternion</param>
		public static void Divide(ref Quaternion a, ref Quaternion b, out Quaternion result) { Quaternion.Divide(ref a, ref b, out result); }
		
		/// <summary>Divides the quaternion from the other quaternion</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting divided quaternion</returns>
		public static Quaternion Divide(ref Quaternion a, ref Quaternion b) { return Quaternion.Divide(ref a, ref b); }
		
		#endregion // Divide Methods
		
		#region Invert Methods
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <param name="result">The resulting inverted quaternion</param>
		public static void Invert(ref Quaternion quaternion, out Quaternion result) { Quaternion.Invert(ref quaternion, out result); }
		
		/// <summary>Inverts the quaternion</summary>
		/// <param name="quaternion">The quaternion to invert</param>
		/// <returns>Returns the resulting inverted quaternion</returns>
		public static Quaternion Invert(ref Quaternion quaternion) { return Quaternion.Invert(ref quaternion); }
		
		#endregion // Invert Methods
		
		#region Normalize Methods
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <param name="result">The resulting normalized quaternion</param>
		public static void Normalize(ref Quaternion quaternion, out Quaternion result) { Quaternion.Normalize(ref quaternion, out result); }
		
		/// <summary>Normalizes the quaternion</summary>
		/// <param name="quaternion">The quaternion to normalize</param>
		/// <returns>Returns the resulting normalized quaternion</returns>
		public static Quaternion Normalize(ref Quaternion quaternion) { return Quaternion.Normalize(ref quaternion); }
		
		#endregion // Normalize Methods
		
		#region Dot Methods
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="result">The resulting floating point number representing the angle between the two quaternions</param>
		public static void Dot(ref Quaternion a, ref Quaternion b, out float result) { Quaternion.Dot(ref a, ref b, out result); }
		
		/// <summary>Dot products the two quaternions together, getting a floating point number representing the angle between the two quaternions</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <returns>Returns the resulting floating point number representing the angle between the two quaternions</returns>
		public static float Dot(ref Quaternion a, ref Quaternion b) { return Quaternion.Dot(ref a, ref b); }
		
		#endregion // Dot Methods
		
		#region Approx Methods
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Returns true if the quaternions are approximately close to each other</param>
		public static void Approx(ref Quaternion a, ref Quaternion b, float epsilon, out bool result) { Quaternion.Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Gets if the two quaternions are approximately close to each other</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(ref Quaternion a, ref Quaternion b, float epsilon) { return Quaternion.Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <param name="result">Returns true if the quaternions are approximately close to each other</param>
		public static void Approx(ref Quaternion a, ref Quaternion b, out bool result) { Quaternion.Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the two quaternions are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first quaternion to approximate</param>
		/// <param name="b">The second quaternion to approximate</param>
		/// <returns>Returns true if the quaternions are approximately close to each other</returns>
		public static bool Approx(ref Quaternion a, ref Quaternion b) { return Quaternion.Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Slerp Methods
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <param name="result">The resulting linearly interpolated quaternion</param>
		public static void Slerp(ref Quaternion a, ref Quaternion b, float t, out Quaternion result) { Quaternion.Slerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates the quaternion by a spherical means</summary>
		/// <param name="a">The first quaternion</param>
		/// <param name="b">The second quaternion</param>
		/// <param name="t">The time difference from the first quaternion towards the second quaternion, must be between 0 and 1</param>
		/// <returns>Returns the resulting linearly interpolated quaternion</returns>
		public static Quaternion Slerp(ref Quaternion a, ref Quaternion b, float t) { return Quaternion.Slerp(ref a, ref b, t); }
		
		#endregion // Slerp Methods
		
		#endregion // Public Static Methods
	}
}

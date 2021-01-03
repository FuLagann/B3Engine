
namespace B3 {
	public static partial class Mathx {
		#region Public Static Methods
		
		#region Add Methods
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(ref Vector2 a, ref Vector2 b, out Vector2 result) { Vector2.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(ref Vector3 a, ref Vector3 b, out Vector3 result) { Vector3.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 result) { Vector4.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector2 Add(ref Vector2 a, ref Vector2 b) { return Vector2.Add(ref a, ref b); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector3 Add(ref Vector3 a, ref Vector3 b) { return Vector3.Add(ref a, ref b); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector4 Add(ref Vector4 a, ref Vector4 b) { return Vector4.Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 result) { Vector4.Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector4 Subtract(ref Vector4 a, ref Vector4 b) { return Vector4.Subtract(ref a, ref b); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(ref Vector3 a, ref Vector3 b, out Vector3 result) { Vector3.Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector3 Subtract(ref Vector3 a, ref Vector3 b) { return Vector3.Subtract(ref a, ref b); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(ref Vector2 a, ref Vector2 b, out Vector2 result) { Vector2.Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector2 Subtract(ref Vector2 a, ref Vector2 b) { return Vector2.Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Multiply(float scalar, ref Vector4 vec, out Vector4 result) { Vector4.Multiply(scalar, ref vec, out result); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Multiply(float scalar, ref Vector4 vec) { return Vector4.Multiply(scalar, ref vec); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Multiply(float scalar, ref Vector3 vec, out Vector3 result) { Vector3.Multiply(scalar, ref vec, out result); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector3 Multiply(float scalar, ref Vector3 vec) { return Vector3.Multiply(scalar, ref vec); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Multiply(float scalar, ref Vector2 vec, out Vector2 result) { Vector2.Multiply(scalar, ref vec, out result); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Multiply(float scalar, ref Vector2 vec) { return Vector2.Multiply(scalar, ref vec); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Divide(float scalar, ref Vector4 vec, out Vector4 result) { Vector4.Divide(scalar, ref vec, out result); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Divide(float scalar, ref Vector4 vec) { return Vector4.Divide(scalar, ref vec); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Divide(float scalar, ref Vector3 vec, out Vector3 result) { Vector3.Divide(scalar, ref vec, out result); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector3 Divide(float scalar, ref Vector3 vec) { return Vector3.Divide(scalar, ref vec); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The scaled vector</param>
		public static void Divide(float scalar, ref Vector2 vec, out Vector2 result) { Vector2.Divide(scalar, ref vec, out result); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Divide(float scalar, ref Vector2 vec) { return Vector2.Divide(scalar, ref vec); }
		
		#endregion // Divide Methods
		
		#region Dot Methods
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(ref Vector4 a, ref Vector4 b, out float result) { Vector4.Dot(ref a, ref b, out result); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(ref Vector4 a, ref Vector4 b) { return Vector4.Dot(ref a, ref b); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(ref Vector3 a, ref Vector3 b, out float result) { Vector3.Dot(ref a, ref b, out result); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(ref Vector3 a, ref Vector3 b) { return Vector3.Dot(ref a, ref b); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(ref Vector2 a, ref Vector2 b, out float result) { Vector2.Dot(ref a, ref b, out result); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(ref Vector2 a, ref Vector2 b) { return Vector2.Dot(ref a, ref b); }
		
		#endregion // Dot Methods
		
		#region Normalize Methods
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The normalized vector</param>
		public static void Normalize(ref Vector4 vec, out Vector4 result) { Vector4.Normalize(ref vec, out result); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector4 Normalize(ref Vector4 vec) { return Vector4.Normalize(ref vec); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The normalized vector</param>
		public static void Normalize(ref Vector3 vec, out Vector3 result) { Vector3.Normalize(ref vec, out result); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector3 Normalize(ref Vector3 vec) { return Vector3.Normalize(ref vec); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The normalized vector</param>
		public static void Normalize(ref Vector2 vec, out Vector2 result) { Vector2.Normalize(ref vec, out result); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector2 Normalize(ref Vector2 vec) { return Vector2.Normalize(ref vec); }
		
		#endregion // Normalize Methods
		
		#region Negate Methods
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The negated vector</param>
		public static void Negate(ref Vector4 vec, out Vector4 result) { Vector4.Negate(ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector4 Negate(ref Vector4 vec) { return Vector4.Negate(ref vec); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The negated vector</param>
		public static void Negate(ref Vector3 vec, out Vector3 result) { Vector3.Negate(ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector3 Negate(ref Vector3 vec) { return Vector3.Negate(ref vec); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The negated vector</param>
		public static void Negate(ref Vector2 vec, out Vector2 result) { Vector2.Negate(ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector2 Negate(ref Vector2 vec) { return Vector2.Negate(ref vec); }
		
		#endregion
		
		#region FromAngle Methods
		
		/// <summary>Creates a new vector from an angle</summary>
		/// <param name="theta">The angle that creates the vector</param>
		/// <param name="result">The resulting vector that is made from the angle</param>
		public static void FromAngle(float theta, out Vector2 result) { Vector2.FromAngle(theta, out result); }
		
		/// <summary>Creates a new vector from an angle</summary>
		/// <param name="theta">The angle that creates the vector</param>
		/// <returns>Returns the vector that is made from the angle</returns>
		public static Vector2 FromAngle(float theta) { return Vector2.FromAngle(theta); }
		
		/// <summary>Creates a vector from two different angles</summary>
		/// <param name="theta">The first angle that helps create the vector</param>
		/// <param name="phi">The second angle that helps create the vector</param>
		/// <param name="result">The resulting vector that is made from the angles</param>
		public static void FromAngle(float theta, float phi, out Vector3 result) { Vector3.FromAngles(theta, phi, out result); }
		
		/// <summary>Creates a vector from two different angles</summary>
		/// <param name="theta">The first angle that helps create the vector</param>
		/// <param name="phi">The second angle that helps create the vector</param>
		/// <returns>The resulting vector that is made from the angles</returns>
		public static Vector3 FromAngle(float theta, float phi) { return Vector3.FromAngles(theta, phi); }
		
		#endregion // FromAngle Methods
		
		#region CreatePerpendicular Methods
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <param name="result">The resulting vector that is perpendicluar to the given vector</param>
		public static void CreatePerpendicular(ref Vector2 vec, out Vector2 result) { Vector2.CreatePerpendicular(ref vec, out result); }
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <returns>Returns the vector that is perpendicluar to the given vector</returns>
		public static Vector2 CreatePerpendicular(ref Vector2 vec) { return Vector2.CreatePerpendicular(ref vec); }
		
		#endregion // CreatePerpendicular Methods
		
		#region CrossProduct Methods
		
		/// <summary>Performs a cross product and creates a vector that is orthogonal to both vectors provided</summary>
		/// <param name="a">The first vector to cross product</param>
		/// <param name="b">The second vector to cross product</param>
		/// <param name="result">The resulting vector that is orthogonal to the vectors provided</param>
		public static void CrossProduct(ref Vector3 a, ref Vector3 b, out Vector3 result) { Vector3.CrossProduct(ref a, ref b, out result); }
		
		/// <summary>Performs a cross product and creates a vector that is orthogonal to both vectors provided</summary>
		/// <param name="a">The first vector to cross product</param>
		/// <param name="b">The second vector to cross product</param>
		/// <returns>Returns the vector that is orthogonal to the vectors provided</returns>
		public static Vector3 CrossProduct(ref Vector3 a, ref Vector3 b) { return Vector3.CrossProduct(ref a, ref b); }
		
		#endregion // CrossProduct Methods
		
		#region Project Methods
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(ref Vector4 a, ref Vector4 b, out Vector4 result) { Vector4.Project(ref a, ref b, out result); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the vector that has been projected onto the second vector</returns>
		public static Vector4 Project(ref Vector4 a, ref Vector4 b) { return Vector4.Project(ref a, ref b); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(ref Vector3 a, ref Vector3 b, out Vector3 result) { Vector3.Project(ref a, ref b, out result); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the vector that has been projected onto the second vector</returns>
		public static Vector3 Project(ref Vector3 a, ref Vector3 b) { return Vector3.Project(ref a, ref b); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(ref Vector2 a, ref Vector2 b, out Vector2 result) { Vector2.Project(ref a, ref b, out result); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the vector that has been projected onto the second vector</returns>
		public static Vector2 Project(ref Vector2 a, ref Vector2 b) { return Vector2.Project(ref a, ref b); }
		
		#endregion // Project Methods
		
		#region Reject Methods
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(ref Vector4 a, ref Vector4 b, out Vector4 result) { Vector4.Reject(ref a, ref b, out result); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector4 Reject(ref Vector4 a, ref Vector4 b) { return Vector4.Reject(ref a, ref b); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(ref Vector3 a, ref Vector3 b, out Vector3 result) { Vector3.Reject(ref a, ref b, out result); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector3 Reject(ref Vector3 a, ref Vector3 b) { return Vector3.Reject(ref a, ref b); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(ref Vector2 a, ref Vector2 b, out Vector2 result) { Vector2.Reject(ref a, ref b, out result); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector2 Reject(ref Vector2 a, ref Vector2 b) { return Vector2.Reject(ref a, ref b); }
		
		#endregion // Reject Methods
		
		#region Min Methods
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(ref Vector4 vec, ref Vector4 min, out Vector4 result) { Vector4.Min(ref vec, ref min, out result); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector4 Min(ref Vector4 vec, ref Vector4 min) { return Vector4.Min(ref vec, ref min); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(ref Vector3 vec, ref Vector3 min, out Vector3 result) { Vector3.Min(ref vec, ref min, out result); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector3 Min(ref Vector3 vec, ref Vector3 min) { return Vector3.Min(ref vec, ref min); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(ref Vector2 vec, ref Vector2 min, out Vector2 result) { Vector2.Min(ref vec, ref min, out result); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector2 Min(ref Vector2 vec, ref Vector2 min) { return Vector2.Min(ref vec, ref min); }
		
		#endregion // Min Methods
		
		#region Max Methods
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(ref Vector4 vec, ref Vector4 max, out Vector4 result) { Vector4.Max(ref vec, ref max, out result); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector4 Max(ref Vector4 vec, ref Vector4 max) { return Vector4.Max(ref vec, ref max); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(ref Vector3 vec, ref Vector3 max, out Vector3 result) { Vector3.Max(ref vec, ref max, out result); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector3 Max(ref Vector3 vec, ref Vector3 max) { return Vector3.Max(ref vec, ref max); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(ref Vector2 vec, ref Vector2 max, out Vector2 result) { Vector2.Max(ref vec, ref max, out result); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector2 Max(ref Vector2 vec, ref Vector2 max) { return Vector2.Max(ref vec, ref max); }
		
		#endregion // Max Methods
		
		#region Clamp Methods
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result) { Vector4.Clamp(ref vec, ref min, ref max, out result); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>The resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector4 Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max) { return Vector4.Clamp(ref vec, ref min, ref max); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result) { Vector3.Clamp(ref vec, ref min, ref max, out result); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>The resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector3 Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max) { return Vector3.Clamp(ref vec, ref min, ref max); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(ref Vector2 vec, ref Vector2 min, ref Vector2 max, out Vector2 result) { Vector2.Clamp(ref vec, ref min, ref max, out result); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>The resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector2 Clamp(ref Vector2 vec, ref Vector2 min, ref Vector2 max) { return Vector2.Clamp(ref vec, ref min, ref max); }
		
		#endregion // Clamp Methods
		
		#region Floor Methods
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(ref Vector4 vec, out Vector4 result) { Vector4.Floor(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector4 Floor(ref Vector4 vec) { return Vector4.Floor(ref vec); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(ref Vector3 vec, out Vector3 result) { Vector3.Floor(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector3 Floor(ref Vector3 vec) { return Vector3.Floor(ref vec); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(ref Vector2 vec, out Vector2 result) { Vector2.Floor(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector2 Floor(ref Vector2 vec) { return Vector2.Floor(ref vec); }
		
		#endregion // Floor Methods
		
		#region Ceiling Methods
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(ref Vector4 vec, out Vector4 result) { Vector4.Ceiling(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector4 Ceiling(ref Vector4 vec) { return Vector4.Ceiling(ref vec); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(ref Vector3 vec, out Vector3 result) { Vector3.Ceiling(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector3 Ceiling(ref Vector3 vec) { return Vector3.Ceiling(ref vec); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(ref Vector2 vec, out Vector2 result) { Vector2.Ceiling(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector2 Ceiling(ref Vector2 vec) { return Vector2.Ceiling(ref vec); }
		
		#endregion // Ceiling Methods
		
		#region Fraction Methods
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(ref Vector4 vec, out Vector4 result) { Vector4.Fraction(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector4 Fraction(ref Vector4 vec) { return Vector4.Fraction(ref vec); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(ref Vector3 vec, out Vector3 result) { Vector3.Fraction(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector3 Fraction(ref Vector3 vec) { return Vector3.Fraction(ref vec); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(ref Vector2 vec, out Vector2 result) { Vector2.Fraction(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector2 Fraction(ref Vector2 vec) { return Vector2.Fraction(ref vec); }
		
		#endregion // Fraction Methods
		
		#region Abs Methods
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(ref Vector4 vec, out Vector4 result) { Vector4.Abs(ref vec, out result); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector4 Abs(ref Vector4 vec) { return Vector4.Abs(ref vec); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(ref Vector3 vec, out Vector3 result) { Vector3.Abs(ref vec, out result); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector3 Abs(ref Vector3 vec) { return Vector3.Abs(ref vec); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(ref Vector2 vec, out Vector2 result) { Vector2.Abs(ref vec, out result); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector2 Abs(ref Vector2 vec) { return Vector2.Abs(ref vec); }
		
		#endregion // Abs Methods
		
		#region MapRange Methods
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(ref Vector4 vec, ref Vector4 inMin, ref Vector4 inMax, ref Vector4 outMin, ref Vector4 outMax, out Vector4 result) {
			Vector4.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector4 MapRange(ref Vector4 vec, ref Vector4 inMin, ref Vector4 inMax, ref Vector4 outMin, ref Vector4 outMax) {
			return Vector4.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(ref Vector3 vec, ref Vector3 inMin, ref Vector3 inMax, ref Vector3 outMin, ref Vector3 outMax, out Vector3 result) {
			Vector3.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector3 MapRange(ref Vector3 vec, ref Vector3 inMin, ref Vector3 inMax, ref Vector3 outMin, ref Vector3 outMax) {
			return Vector3.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(ref Vector2 vec, ref Vector2 inMin, ref Vector2 inMax, ref Vector2 outMin, ref Vector2 outMax, out Vector2 result) {
			Vector2.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector2 MapRange(ref Vector2 vec, ref Vector2 inMin, ref Vector2 inMax, ref Vector2 outMin, ref Vector2 outMax) {
			return Vector2.MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax);
		}
		
		#endregion // MapRange Methods
		
		#region Trunc Methods
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(ref Vector4 vec, out Vector4 result) { Vector4.Trunc(ref vec, out result); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector4 Trunc(ref Vector4 vec) { return Vector4.Trunc(ref vec); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(ref Vector3 vec, out Vector3 result) { Vector3.Trunc(ref vec, out result); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector3 Trunc(ref Vector3 vec) { return Vector3.Trunc(ref vec); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(ref Vector2 vec, out Vector2 result) { Vector2.Trunc(ref vec, out result); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector2 Trunc(ref Vector2 vec) { return Vector2.Trunc(ref vec); }
		
		#endregion // Trunc Methods
		
		#region Sqrt Methods
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(ref Vector4 vec, out Vector4 result) { Vector4.Sqrt(ref vec, out result); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector4 Sqrt(ref Vector4 vec) { return Vector4.Sqrt(ref vec); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(ref Vector3 vec, out Vector3 result) { Vector3.Sqrt(ref vec, out result); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector3 Sqrt(ref Vector3 vec) { return Vector3.Sqrt(ref vec); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(ref Vector2 vec, out Vector2 result) { Vector2.Sqrt(ref vec, out result); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector2 Sqrt(ref Vector2 vec) { return Vector2.Sqrt(ref vec); }
		
		#endregion // Sqrt Methods
		
		#region Round Methods
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(ref Vector4 vec, int digits, out Vector4 result) { Vector4.Round(ref vec, digits, out result); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(ref Vector4 vec, out Vector4 result) { Vector4.Round(ref vec, out result); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector4 Round(ref Vector4 vec, int digits) { return Vector4.Round(ref vec, digits); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector4 Round(ref Vector4 vec) { return Vector4.Round(ref vec); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(ref Vector3 vec, int digits, out Vector3 result) { Vector3.Round(ref vec, digits, out result); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(ref Vector3 vec, out Vector3 result) { Vector3.Round(ref vec, out result); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector3 Round(ref Vector3 vec, int digits) { return Vector3.Round(ref vec, digits); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector3 Round(ref Vector3 vec) { return Vector3.Round(ref vec); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(ref Vector2 vec, int digits, out Vector2 result) { Vector2.Round(ref vec, digits, out result); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(ref Vector2 vec, out Vector2 result) { Vector2.Round(ref vec, out result); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector2 Round(ref Vector2 vec, int digits) { return Vector2.Round(ref vec, digits); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector2 Round(ref Vector2 vec) { return Vector2.Round(ref vec); }
		
		#endregion // Round Methods
		
		#region Smoothstep Methods
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(ref Vector4 x, ref Vector4 leftEdge, ref Vector4 rightEdge, out Vector4 result) { Vector4.Smoothstep(ref x, ref leftEdge, ref rightEdge, out result); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector4 Smoothstep(ref Vector4 x, ref Vector4 leftEdge, ref Vector4 rightEdge) { return Vector4.Smoothstep(ref x, ref leftEdge, ref rightEdge); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(ref Vector3 x, ref Vector3 leftEdge, ref Vector3 rightEdge, out Vector3 result) { Vector3.Smoothstep(ref x, ref leftEdge, ref rightEdge, out result); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector3 Smoothstep(ref Vector3 x, ref Vector3 leftEdge, ref Vector3 rightEdge) { return Vector3.Smoothstep(ref x, ref leftEdge, ref rightEdge); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(ref Vector2 x, ref Vector2 leftEdge, ref Vector2 rightEdge, out Vector2 result) { Vector2.Smoothstep(ref x, ref leftEdge, ref rightEdge, out result); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector2 Smoothstep(ref Vector2 x, ref Vector2 leftEdge, ref Vector2 rightEdge) { return Vector2.Smoothstep(ref x, ref leftEdge, ref rightEdge); }
		
		#endregion // Smoothstep Methods
		
		#region Repeat Methods
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result) { Vector4.Repeat(ref vec, ref min, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector4 Repeat(ref Vector4 vec, ref Vector4 min, ref Vector4 max) { return Vector4.Repeat(ref vec, ref min, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(ref Vector4 vec, ref Vector4 max, out Vector4 result) { Vector4.RepeatFrom0(ref vec, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector4 RepeatFrom0(ref Vector4 vec, ref Vector4 max) { return Vector4.RepeatFrom0(ref vec, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result) { Vector3.Repeat(ref vec, ref min, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector3 Repeat(ref Vector3 vec, ref Vector3 min, ref Vector3 max) { return Vector3.Repeat(ref vec, ref min, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(ref Vector3 vec, ref Vector3 max, out Vector3 result) { Vector3.RepeatFrom0(ref vec, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector3 RepeatFrom0(ref Vector3 vec, ref Vector3 max) { return Vector3.RepeatFrom0(ref vec, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(ref Vector2 vec, ref Vector2 min, ref Vector2 max, out Vector2 result) { Vector2.Repeat(ref vec, ref min, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector2 Repeat(ref Vector2 vec, ref Vector2 min, ref Vector2 max) { return Vector2.Repeat(ref vec, ref min, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(ref Vector2 vec, ref Vector2 max, out Vector2 result) { Vector2.RepeatFrom0(ref vec, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector2 RepeatFrom0(ref Vector2 vec, ref Vector2 max) { return Vector2.RepeatFrom0(ref vec, ref max); }
		
		#endregion // Repeat Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector4 a, ref Vector4 b, float epsilon, out bool result) { Vector4.Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector4 a, ref Vector4 b, out bool result) { Vector4.Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector4 a, ref Vector4 b, float epsilon) { return Vector4.Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector4 a, ref Vector4 b) { return Vector4.Approx(ref a, ref b); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector3 a, ref Vector3 b, float epsilon, out bool result) { Vector3.Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector3 a, ref Vector3 b, out bool result) { Vector3.Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector3 a, ref Vector3 b, float epsilon) { return Vector3.Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector3 a, ref Vector3 b) { return Vector3.Approx(ref a, ref b); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector2 a, ref Vector2 b, float epsilon, out bool result) { Vector2.Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">If the result is true then the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector2 a, ref Vector2 b, out bool result) { Vector2.Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector2 a, ref Vector2 b, float epsilon) { return Vector2.Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector2 a, ref Vector2 b) { return Vector2.Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Lerp Methods
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(ref Vector4 a, ref Vector4 b, float t, out Vector4 result) { Vector4.LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 LerpClamped(ref Vector4 a, ref Vector4 b, float t) { return Vector4.LerpClamped(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(ref Vector4 a, ref Vector4 b, float t, out Vector4 result) { Vector4.Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 Lerp(ref Vector4 a, ref Vector4 b, float t) { return Vector4.Lerp(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(ref Vector3 a, ref Vector3 b, float t, out Vector3 result) { Vector3.LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 LerpClamped(ref Vector3 a, ref Vector3 b, float t) { return Vector3.LerpClamped(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(ref Vector3 a, ref Vector3 b, float t, out Vector3 result) { Vector3.Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 Lerp(ref Vector3 a, ref Vector3 b, float t) { return Vector3.Lerp(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(ref Vector2 a, ref Vector2 b, float t, out Vector2 result) { Vector2.LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector2 LerpClamped(ref Vector2 a, ref Vector2 b, float t) { return Vector2.LerpClamped(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(ref Vector2 a, ref Vector2 b, float t, out Vector2 result) { Vector2.Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector2 Lerp(ref Vector2 a, ref Vector2 b, float t) { return Vector2.Lerp(ref a, ref b, t); }
		
		#endregion // Lerp Methods
		
		#region MinMax Methods
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(ref Vector4 a, ref Vector4 b, out Vector4 min, out Vector4 max) { Vector4.MinMax(ref a, ref b, out min, out max); }
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(ref Vector3 a, ref Vector3 b, out Vector3 min, out Vector3 max) { Vector3.MinMax(ref a, ref b, out min, out max); }
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(ref Vector2 a, ref Vector2 b, out Vector2 min, out Vector2 max) { Vector2.MinMax(ref a, ref b, out min, out max); }
		
		#endregion // MinMax Methods
		
		#endregion // Public Static Methods
	}
}

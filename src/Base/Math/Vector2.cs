
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A vector to represent points and directions in 2D space</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Vector2 : System.IEquatable<Vector2>, System.IComparable, System.IComparable<Vector2> {
		#region Field Variables
		// Variables
		/// <summary>The x coordinate of the 2D vector.</summary>
		public float x;
		/// <summary>The y coordinate of the 2D vector.</summary>
		public float y;
		/// <summary>A 2D vector that points to the origin (0, 0)</summary>
		public static readonly Vector2 Zero = new Vector2(0.0f);
		/// <summary>A vector that points towards the coordinate (1, 1)</summary>
		public static readonly Vector2 One = new Vector2(1.0f);
		/// <summary>A unit vector that points a single unit in the x axis (1, 0)</summary>
		public static readonly Vector2 UnitX = new Vector2(1.0f, 0.0f);
		/// <summary>A unit vector that points a single unit in the y axis (0, 1)</summary>
		public static readonly Vector2 UnitY = new Vector2(0.0f, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the magnitude of the vector in squared form</summary>
		public float MagnitudeSquared { get { return (this.x * this.x + this.y * this.y); } }
		
		/// <summary>Gets the magnitude of the vector</summary>
		public float Magnitude { get { return Mathx.Sqrt(this.MagnitudeSquared); } }
		
		/// <summary>Gets and sets the heading (angle) of the vector</summary>
		public float Heading { get { return Mathx.Arctan(this.y, this.x); } set {
			this.x = (float)System.Math.Cos(value);
			this.y = (float)System.Math.Sin(value);
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for making a new 2D vector</summary>
		/// <param name="x">The x-value of the 2D vector</param>
		/// <param name="y">The y-value of the 2D vector</param>
		public Vector2(float x, float y) {
			this.x = x;
			this.y = y;
		}
		
		/// <summary>A constructor for making a new 2D vector with the same values on each component</summary>
		/// <param name="xy">The x and y value of the 2D vector</param>
		public Vector2(float xy) : this(xy, xy) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region ToVector4 Methods
		
		/// <summary>Converts the vector2 into a vector4, with the w component being 1</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector4(ref Vector2 vec, out Vector4 result) {
			result.x = vec.x;
			result.y = vec.y;
			result.z = 0.0f;
			result.w = 1.0f;
		}
		
		/// <summary>Converts the vector2 into a vector4, with the w component being 1</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector4(Vector2 vec, out Vector4 result) { ToVector4(ref vec, out result); }
		
		/// <summary>Converts the vector2 into a vector4, with the w component being 1</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector4 ToVector4(ref Vector2 vec) {
			// Variables
			Vector4 result;
			
			ToVector4(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Converts the vector2 into a vector4, with the w component being 1</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector4 ToVector4(Vector2 vec) { return ToVector4(ref vec); }
		
		#endregion // ToVector4 Methods
		
		#region ToVector3 Methods
		
		/// <summary>Converts the vector2 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector3(ref Vector2 vec, out Vector3 result) {
			result.x = vec.x;
			result.y = vec.y;
			result.z = 0.0f;
		}
		
		/// <summary>Converts the vector2 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector3(Vector2 vec, out Vector3 result) { ToVector3(ref vec, out result); }
		
		/// <summary>Converts the vector2 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector3 ToVector3(ref Vector2 vec) {
			// Variables
			Vector3 result;
			
			ToVector3(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Converts the vector2 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector3 ToVector3(Vector2 vec) { return ToVector3(ref vec); }
		
		#endregion // ToVector3 Methods
		
		#region Add Methods
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(ref Vector2 a, ref Vector2 b, out Vector2 result) {
			result.x = a.x + b.x;
			result.y = a.y + b.y;
		}
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(Vector2 a, Vector2 b, out Vector2 result) { Vector2.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector2 Add(ref Vector2 a, ref Vector2 b) {
			// Variables
			Vector2 result;
			
			Vector2.Add(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector2 Add(Vector2 a, Vector2 b) { return Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(ref Vector2 a, ref Vector2 b, out Vector2 result) {
			result.x = a.x - b.x;
			result.y = a.y - b.y;
		}
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(Vector2 a, Vector2 b, out Vector2 result) { Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector2 Subtract(ref Vector2 a, ref Vector2 b) {
			// Variables
			Vector2 result;
			
			Subtract(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector2 Subtract(Vector2 a, Vector2 b) { return Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Multiply(float scalar, ref Vector2 vec, out Vector2 result) {
			result.x = scalar * vec.x;
			result.y = scalar * vec.y;
		}
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Multiply(float scalar, Vector2 vec, out Vector2 result) { Multiply(scalar, ref vec, out result); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Multiply(float scalar, ref Vector2 vec) {
			// Variables
			Vector2 result;
			
			Multiply(scalar, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Multiply(float scalar, Vector2 vec) { return Multiply(scalar, ref vec); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Divide(float scalar, ref Vector2 vec, out Vector2 result) {
			// Variables
			float dividedScalar = 1.0f / scalar;
			
			Multiply(dividedScalar, ref vec, out result);
		}
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Divide(float scalar, Vector2 vec, out Vector2 result) { Divide(scalar, ref vec, out result); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Divide(float scalar, ref Vector2 vec) {
			// Variables
			Vector2 result;
			
			Divide(scalar, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 Divide(float scalar, Vector2 vec) { return Divide(scalar, ref vec); }
		
		#endregion // Divide Methods
		
		#region Dot Methods
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(ref Vector2 a, ref Vector2 b, out float result) {
			result = (
				a.x * b.x +
				a.y * b.y
			);
		}
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(Vector2 a, Vector2 b, out float result) { Dot(ref a, ref b, out result); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(ref Vector2 a, ref Vector2 b) {
			// Variables
			float result;
			
			Dot(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(Vector2 a, Vector2 b) { return Dot(ref a, ref b); }
		
		#endregion // Dot Methods
		
		#region Normalize Methods
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The resulting normalized vector</param>
		public static void Normalize(ref Vector2 vec, out Vector2 result) {
			// Variables
			float mag = vec.MagnitudeSquared;
			
			if(mag == 0.0f || mag == 1.0f) {
				result = vec;
				return;
			}
			Divide(Mathx.Sqrt(mag), ref vec, out result);
		}
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The resulting normalized vector</param>
		public static void Normalize(Vector2 vec, out Vector2 result) { Normalize(vec, out result); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector2 Normalize(ref Vector2 vec) {
			// Variables
			Vector2 result;
			
			Normalize(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector2 Normalize(Vector2 vec) { return Normalize(ref vec); }
		
		#endregion // Normalize Methods
		
		#region Negate Methods
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The resulting negated vector</param>
		public static void Negate(ref Vector2 vec, out Vector2 result) { Multiply(-1.0f, ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The resulting negated vector</param>
		public static void Negate(Vector2 vec, out Vector2 result) { Negate(ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector2 Negate(ref Vector2 vec) { return Multiply(-1.0f, ref vec); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector2 Negate(Vector2 vec) { return Negate(ref vec); }
		
		#endregion // Negate Methods
		
		#region Project Methods
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(ref Vector2 a, ref Vector2 b, out Vector2 result) {
			// Variables
			float top;
			float bot;
			
			Dot(ref a, ref b, out top);
			Dot(ref b, ref b, out bot);
			Multiply(top / bot, ref b, out result);
		}
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(Vector2 a, ref Vector2 b, out Vector2 result) { Project(ref a, ref b, out result); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the vector that has been projected onto the second vector</returns>
		public static Vector2 Project(ref Vector2 a, ref Vector2 b) {
			// Variables
			Vector2 result;
			
			Project(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the resulting vector that has been projected onto the second vector</returns>
		public static Vector2 Project(Vector2 a, Vector2 b) { return Project(ref a, ref b); }
		
		#endregion // Project Methods
		
		#region Reject Methods
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(ref Vector2 a, ref Vector2 b, out Vector2 result) {
			Project(ref a, ref b, out result);
			Subtract(ref a, ref result, out result);
		}
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(Vector2 a, Vector2 b, out Vector2 result) { Reject(ref a, ref b, out result); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector2 Reject(ref Vector2 a, ref Vector2 b) {
			// Variables
			Vector2 result;
			
			Reject(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector2 Reject(Vector2 a, Vector2 b) { return Reject(ref a, ref b); }
		
		#endregion // Reject Methods
		
		#region CreatePerpendicular Methods
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <param name="result">The resulting vector that is perpendicluar to the given vector</param>
		public static void CreatePerpendicular(ref Vector2 vec, out Vector2 result) {
			result.x = vec.y;
			result.y = -vec.x;
		}
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <param name="result">The resulting vector that is perpendicluar to the given vector</param>
		public static void CreatePerpendicular(Vector2 vec, out Vector2 result) { CreatePerpendicular(ref vec, out result); }
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <returns>Returns the vector that is perpendicluar to the given vector</returns>
		public static Vector2 CreatePerpendicular(ref Vector2 vec) {
			// Variables
			Vector2 result;
			
			CreatePerpendicular(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Creates a perpendicular vector to the given vector</summary>
		/// <param name="vec">A vector to create a perpendicular from</param>
		/// <returns>Returns the vector that is perpendicluar to the given vector</returns>
		public static Vector2 CreatePerpendicular(Vector2 vec) { return CreatePerpendicular(ref vec); }
		
		#endregion // CreatePerpendicular Methods
		
		/// <summary>Creates a new vector from an angle</summary>
		/// <param name="theta">The angle that creates the vector</param>
		/// <param name="result">The resulting vector that is made from the angle</param>
		public static void FromAngle(float theta, out Vector2 result) {
			result.x = Mathx.Cos(theta);
			result.y = Mathx.Sin(theta);
		}
		
		/// <summary>Creates a new vector from an angle</summary>
		/// <param name="theta">The angle that creates the vector</param>
		/// <returns>Returns the vector that is made from the angle</returns>
		public static Vector2 FromAngle(float theta) {
			// Variables
			Vector2 result;
			
			FromAngle(theta, out result);
			
			return result;
		}
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Converts this vector into a vector4</summary>
		/// <returns>Returns the converted vector</returns>
		public Vector4 ToVector4() { return Vector2.ToVector4(ref this); }
		
		/// <summary>Converts this vector into a vector3</summary>
		/// <returns>Returns the converted vector</returns>
		public Vector3 ToVector3() { return Vector2.ToVector3(ref this); }
		
		/// <summary>Adds the vector with the given vector together</summary>
		/// <param name="other">The other vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public Vector2 Add(Vector2 other) { return Vector2.Add(ref this, ref other); }
		
		/// <summary>Subtracts this vector from another</summary>
		/// <param name="other">The other vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public Vector2 Subtract(Vector2 other) { return Vector2.Subtract(ref this, ref other); }
		
		/// <summary>Multiplies this vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public Vector2 Multiply(float scalar) { return Vector2.Multiply(scalar, ref this); }
		
		/// <summary>Divides this vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public Vector2 Divide(float scalar) { return Vector2.Divide(scalar, ref this); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="vec">The vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public float Dot(Vector2 vec) { return Vector2.Dot(ref this, ref vec); }
		
		/// <summary>Normalizes the vector and returns a unit vector version</summary>
		/// <returns>Returns a unit vector that is the normalized version of the vector</returns>
		public Vector2 Normalize() { return Vector2.Normalize(ref this); }
		
		/// <summary>Negates this vector and returns a negative version of it</summary>
		/// <returns>Returns the negated vector</returns>
		public Vector2 Negate() { return Vector2.Negate(ref this); }
		
		/// <summary>Creates a perpendicular vector that is perpendicular to this vector</summary>
		/// <returns>Returns the vector that is perpendicluar to this vector</returns>
		public Vector2 CreatePerpendicular() { return Vector2.CreatePerpendicular(ref this); }
		
		/// <summary>Finds if this vector is equal to the other vector</summary>
		/// <param name="other">The other vector to compare it to</param>
		/// <returns>Returns true if the two vectors are equal</returns>
		public bool Equals(Vector2 other) { return (this.x == other.x && this.y == other.y); }
		
		/// <summary>Compares this vector with the other vector to find which one is smallest</summary>
		/// <param name="other">The other vector to compare it to</param>
		/// <returns>Returns &lt; 0 if this vector is smaller, &gt; 0 if this vector is bigger, and 0 if the two vectors are the same</returns>
		public int CompareTo(Vector2 other) { return (int)(this.MagnitudeSquared - other.MagnitudeSquared); }
		
		/// <summary>Compares this vector with the other object to find which one is smallest</summary>
		/// <param name="other">The other object to compare it to</param>
		/// <returns>Returns &lt; 0 if this vector is smaller, &gt; 0 if this vector is bigger, and 0 if the two vectors are the same</returns>
		public int CompareTo(object other) {
			if(other == null) {
				return -1;
			}
			if(other is Vector2) {
				return CompareTo((Vector2)other);
			}
			return -1;
		}
		
		/// <summary>Finds if the vector is equal to the other object</summary>
		/// <param name="obj">The object in question</param>
		/// <returns>Returns true if the vector is equal to the other vector</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Vector2) {
				return this.Equals((Vector2)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hashing code of the type</summary>
		/// <returns>Returns the hashing code of the type</returns>
		public override int GetHashCode() { return (int)this.x ^ (int)this.y; }
		
		/// <summary>Gets the vector in string form</summary>
		/// <returns>Returns the vector in string form</returns>
		public override string ToString() { return "{ x: " + this.x + ", y: " + this.y + " }"; }
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>An operator to find if the two vectors are equal to each other</summary>
		/// <param name="left">The left vector to check</param>
		/// <param name="right">The right vector to check</param>
		/// <returns>Returns true if the two vectors are equal</returns>
		public static bool operator ==(Vector2 left, Vector2 right) { return left.Equals(right); }
		
		/// <summary>An operator to find if the two vectors are not equal to each other</summary>
		/// <param name="left">The left vector to check</param>
		/// <param name="right">The right vector to check</param>
		/// <returns>Returns true if the two vectors are not equal</returns>
		public static bool operator !=(Vector2 left, Vector2 right) { return !left.Equals(right); }
		
		/// <summary>An operator to add two vectors together</summary>
		/// <param name="left">The left vector to add together</param>
		/// <param name="right">The right vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector2 operator +(Vector2 left, Vector2 right) { return Vector2.Add(ref left, ref right); }
		
		/// <summary>An operator to subtract one vector from another</summary>
		/// <param name="left">The first vector to subtract from</param>
		/// <param name="right">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector2 operator -(Vector2 left, Vector2 right) { return Vector2.Subtract(ref left, ref right); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="left">The scalar value as a real number used to scale the vector</param>
		/// <param name="right">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 operator *(float left, Vector2 right) { return Vector2.Multiply(left, ref right); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="left">The vector used to scale</param>
		/// <param name="right">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 operator *(Vector2 left, float right) { return Vector2.Multiply(right, ref left); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="left">The vector used to scale</param>
		/// <param name="right">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector2 operator /(Vector2 left, float right) { return Vector2.Divide(right, ref left); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="left">The first vector to dot product with</param>
		/// <param name="right">The first vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float operator *(Vector2 left, Vector2 right) { return Vector2.Dot(ref left, ref right); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector2 operator -(Vector2 vec) { return Vector2.Negate(ref vec); }
		
		/// <summary>Converts the vector2 into a vector4</summary>
		/// <param name="vec">The vector to convert</param>
		public static explicit operator Vector4(Vector2 vec) { return Vector2.ToVector4(ref vec); }
		
		/// <summary>Converts the vector2 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		public static explicit operator Vector3(Vector2 vec) { return Vector2.ToVector3(ref vec); }
		
		#endregion // Operators
	}
}

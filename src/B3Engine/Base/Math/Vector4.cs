
using B3.Graphics;

using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A vector to represent points and directions in 4D space</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Vector4 : IVertexAttributable, IConvertable<Vertex3PC>, IConvertable<Vertex3PCTN>, System.IEquatable<Vector4>, System.IComparable, System.IComparable<Vector4> {
		#region Field Variables
		// Variables
		/// <summary>The x coordinate of the 4D vector</summary>
		public float x;
		/// <summary>The y coordinate of the 4D vector</summary>
		public float y;
		/// <summary>The z coordinate of the 4D vector</summary>
		public float z;
		/// <summary>The w coordinate of the 4D vector</summary>
		public float w;
		/// <summary>A 4D vector that points to the origin (0, 0, 0, 0)</summary>
		public static readonly Vector4 Zero = new Vector4(0.0f);
		/// <summary>A 4D vector that points towards the coordinate (1, 1, 1, 1)</summary>
		public static readonly Vector4 One = new Vector4(1.0f);
		/// <summary>A unit vector that points a single unit in the x axis (1, 0, 0, 0)</summary>
		public static readonly Vector4 UnitX = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
		/// <summary>A unit vector that points a single unit in the y axis (0, 1, 0, 0)</summary>
		public static readonly Vector4 UnitY = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
		/// <summary>A unit vector that points a single unit in the z axis (0, 0, 1, 0)</summary>
		public static readonly Vector4 UnitZ = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
		/// <summary>A unit vector that points a single unit in the w axis (0, 0, 0, 1)</summary>
		public static readonly Vector4 UnitW = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the magnitude of the vector in squared form</summary>
		public float MagnitudeSquared { get { return (this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w); } }
		
		/// <summary>Gets the magnitude of the vector</summary>
		public float Magnitude { get { return Mathx.Sqrt(this.MagnitudeSquared); } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for making a new 4D vector</summary>
		/// <param name="x">The x-value of the 4D vector</param>
		/// <param name="y">The y-value of the 4D vector</param>
		/// <param name="z">The z-value of the 4D vector</param>
		/// <param name="w">The w-value of the 4D vector</param>
		public Vector4(float x, float y, float z, float w) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		
		/// <summary>A constructor for making a new 4D vector from a 3D coordinate. The w value will become 0</summary>
		/// <param name="x">The x-value of the 4D vector</param>
		/// <param name="y">The y-value of the 4D vector</param>
		/// <param name="z">The z-value of the 4D vector</param>
		public Vector4(float x, float y, float z) : this(x, y, z, 1.0f) {}
		
		/// <summary>A constructor for making a new 4D vector from a 2D coordinate. The z and w value will become 0</summary>
		/// <param name="x">The x-value of the 4D vector</param>
		/// <param name="y">The y-value of the 4D vector</param>
		public Vector4(float x, float y) : this(x, y, 0.0f, 1.0f) {}
		
		/// <summary>A constructor for making a new 4D vector with the same values on each component</summary>
		/// <param name="xyzw">The x, y, z, and w values of the 4D vector</param>
		public Vector4(float xyzw) : this(xyzw, xyzw, xyzw, xyzw) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region ToVector3 Methods
		
		/// <summary>Converts the vector4 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector3(ref Vector4 vec, out Vector3 result) {
			result.x = vec.x;
			result.y = vec.y;
			result.z = vec.z;
		}
		
		/// <summary>Converts the vector4 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector3(Vector4 vec, out Vector3 result) { ToVector3(ref vec, out result); }
		
		/// <summary>Converts the vector4 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector3 ToVector3(ref Vector4 vec) {
			// Variables
			Vector3 result;
			
			ToVector3(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Converts the vector4 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector3 ToVector3(Vector4 vec) { return ToVector3(ref vec); }
		
		#endregion // ToVector3 Methods
		
		#region ToVector2 Methods
		
		/// <summary>Converts the vector4 into a vector2</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector2(ref Vector4 vec, out Vector2 result) {
			result.x = vec.x;
			result.y = vec.y;
		}
		
		/// <summary>Converts the vector4 into a vector2</summary>
		/// <param name="vec">The vector to convert</param>
		/// <param name="result">The resulting converted vector</param>
		public static void ToVector2(Vector4 vec, out Vector2 result) { ToVector2(ref vec, out result); }
		
		/// <summary>Converts the vector4 into a vector2</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector2 ToVector2(ref Vector4 vec) {
			// Variables
			Vector2 result;
			
			ToVector2(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Converts the vector4 into a vector2</summary>
		/// <param name="vec">The vector to convert</param>
		/// <returns>Returns the resulting converted vector</returns>
		public static Vector2 ToVector2(Vector4 vec) { return ToVector2(ref vec); }
		
		#endregion // ToVector2 Methods
		
		#region Add Methods
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 result) {
			result.x = a.x + b.x;
			result.y = a.y + b.y;
			result.z = a.z + b.z;
			result.w = a.w + b.w;
		}
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <param name="result">The resulting vector that has the two vecors being added together</param>
		public static void Add(Vector4 a, Vector4 b, out Vector4 result) { Vector4.Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector4 Add(ref Vector4 a, ref Vector4 b) {
			// Variables
			Vector4 result;
			
			Vector4.Add(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Adds the two vectors together</summary>
		/// <param name="a">The first vector to add together</param>
		/// <param name="b">The second vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector4 Add(Vector4 a, Vector4 b) { return Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 result) {
			result.x = a.x - b.x;
			result.y = a.y - b.y;
			result.z = a.z - b.z;
			result.w = a.w - b.w;
		}
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <param name="result">The resulting vector that has the vector subtracted from another vector</param>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static void Subtract(Vector4 a, Vector4 b, out Vector4 result) { Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector4 Subtract(ref Vector4 a, ref Vector4 b) {
			// Variables
			Vector4 result;
			
			Subtract(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Subtracts one vector from another</summary>
		/// <param name="a">The first vector to subtract from</param>
		/// <param name="b">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector4 Subtract(Vector4 a, Vector4 b) { return Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Multiply(float scalar, ref Vector4 vec, out Vector4 result) {
			result.x = scalar * vec.x;
			result.y = scalar * vec.y;
			result.z = scalar * vec.z;
			result.w = scalar * vec.w;
		}
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Multiply(float scalar, Vector4 vec, out Vector4 result) { Multiply(scalar, ref vec, out result); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Multiply(float scalar, ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Multiply(scalar, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Multiply(float scalar, Vector4 vec) { return Multiply(scalar, ref vec); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Divide(float scalar, ref Vector4 vec, out Vector4 result) {
			// Variables
			float dividedScalar = 1.0f / scalar;
			
			Multiply(dividedScalar, ref vec, out result);
		}
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <param name="result">The resulting scaled vector</param>
		public static void Divide(float scalar, Vector4 vec, out Vector4 result) { Divide(scalar, ref vec, out result); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Divide(float scalar, ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Divide(scalar, ref vec, out result);
			
			return result;
		}
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <param name="vec">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 Divide(float scalar, Vector4 vec) { return Divide(scalar, ref vec); }
		
		#endregion // Divide Methods
		
		#region Dot Methods
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(ref Vector4 a, ref Vector4 b, out float result) {
			result = (
				a.x * b.x +
				a.y * b.y +
				a.z * b.z +
				a.w * b.w
			);
		}
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <param name="result">The resulting value that represent the angle between vectors</param>
		public static void Dot(Vector4 a, Vector4 b, out float result) { Dot(ref a, ref b, out result); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(ref Vector4 a, ref Vector4 b) {
			// Variables
			float result;
			
			Dot(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="a">The first vector to dot product with</param>
		/// <param name="b">The second vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float Dot(Vector4 a, Vector4 b) { return Dot(ref a, ref b); }
		
		#endregion // Dot Methods
		
		#region Normalize Methods
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <param name="result">The resulting normalized vector</param>
		public static void Normalize(ref Vector4 vec, out Vector4 result) {
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
		public static void Normalize(Vector4 vec, out Vector4 result) { Normalize(vec, out result); }
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector4 Normalize(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Normalize(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Normalizes the vector and turns it into a unit vector</summary>
		/// <param name="vec">The vector to normalize</param>
		/// <returns>Returns a unit vector that is the normalized vector</returns>
		public static Vector4 Normalize(Vector4 vec) { return Normalize(ref vec); }
		
		#endregion // Normalize Methods
		
		#region Negate Methods
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The resulting negated vector</param>
		public static void Negate(ref Vector4 vec, out Vector4 result) { Multiply(-1.0f, ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <param name="result">The resulting negated vector</param>
		public static void Negate(Vector4 vec, out Vector4 result) { Negate(ref vec, out result); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector4 Negate(ref Vector4 vec) { return Multiply(-1.0f, ref vec); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="vec">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector4 Negate(Vector4 vec) { return Negate(ref vec); }
		
		#endregion // Negate Methods
		
		#region Project Methods
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <param name="result">The resulting vector that has been projected onto the second vector</param>
		public static void Project(ref Vector4 a, ref Vector4 b, out Vector4 result) {
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
		public static void Project(Vector4 a, ref Vector4 b, out Vector4 result) { Project(ref a, ref b, out result); }
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the vector that has been projected onto the second vector</returns>
		public static Vector4 Project(ref Vector4 a, ref Vector4 b) {
			// Variables
			Vector4 result;
			
			Project(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Projects the first vector onto the second vector</summary>
		/// <param name="a">The first vector to be projected</param>
		/// <param name="b">The second vector that will be projected on</param>
		/// <returns>Returns the resulting vector that has been projected onto the second vector</returns>
		public static Vector4 Project(Vector4 a, Vector4 b) { return Project(ref a, ref b); }
		
		#endregion // Project Methods
		
		#region Reject Methods
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(ref Vector4 a, ref Vector4 b, out Vector4 result) {
			Project(ref a, ref b, out result);
			Subtract(ref a, ref result, out result);
		}
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <param name="result">The resulting vector that has been rejected towards the first vector</param>
		public static void Reject(Vector4 a, Vector4 b, out Vector4 result) { Reject(ref a, ref b, out result); }
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector4 Reject(ref Vector4 a, ref Vector4 b) {
			// Variables
			Vector4 result;
			
			Reject(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector that points from the head of the projection vector towards the head of the first vector</summary>
		/// <param name="a">The first vector to be rejected</param>
		/// <param name="b">The second vector that will be rejected on</param>
		/// <returns>Returns the vector that has been rejected towards the first vector</returns>
		public static Vector4 Reject(Vector4 a, Vector4 b) { return Reject(ref a, ref b); }
		
		#endregion // Reject Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Converts the vector into a vector3</summary>
		/// <returns>Returns the converted vector</returns>
		public Vector3 ToVector3() { return Vector4.ToVector3(ref this); }
		
		/// <summary>Converts the vector into a vector2</summary>
		/// <returns>Returns the converted vector</returns>
		public Vector2 ToVector2() { return Vector4.ToVector2(ref this); }
		
		/// <summary>Adds the vector with the given vector together</summary>
		/// <param name="other">The other vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public Vector4 Add(Vector4 other) { return Vector4.Add(ref this, ref other); }
		
		/// <summary>Subtracts this vector from another</summary>
		/// <param name="other">The other vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public Vector4 Subtract(Vector4 other) { return Vector4.Subtract(ref this, ref other); }
		
		/// <summary>Multiplies this vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public Vector4 Multiply(float scalar) { return Vector4.Multiply(scalar, ref this); }
		
		/// <summary>Divides this vector with the scalar</summary>
		/// <param name="scalar">The scalar value as a read number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public Vector4 Divide(float scalar) { return Vector4.Divide(scalar, ref this); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="vec">The vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public float Dot(Vector4 vec) { return Vector4.Dot(ref this, ref vec); }
		
		/// <summary>Normalizes the vector and returns a unit vector version</summary>
		/// <returns>Returns a unit vector that is the normalized version of the vector</returns>
		public Vector4 Normalize() { return Vector4.Normalize(ref this); }
		
		/// <summary>Negates this vector and returns a negative version of it</summary>
		/// <returns>Returns the negated vector</returns>
		public Vector4 Negate() { return Vector4.Negate(ref this); }
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			return new VertexAttributeData[] {
				new VertexAttributeData(4, VertexAttributeDataType.Float, false)
			};
		}
		
		/// <summary>Finds if this vector is equal to the other vector</summary>
		/// <param name="other">The other vector to compare it to</param>
		/// <returns>Returns true if the two vectors are equal</returns>
		public bool Equals(Vector4 other) { return (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w); }
		
		/// <summary>Compares this vector with the other vector to find which one is smallest</summary>
		/// <param name="other">The other vector to compare it to</param>
		/// <returns>Returns &lt; 0 if this vector is smaller, &gt; 0 if this vector is bigger, and 0 if the two vectors are the same</returns>
		public int CompareTo(Vector4 other) { return (int)(this.MagnitudeSquared - other.MagnitudeSquared); }
		
		/// <summary>Compares this vector with the other object to find which one is smallest</summary>
		/// <param name="other">The other object to compare it to</param>
		/// <returns>Returns &lt; 0 if this vector is smaller, &gt; 0 if this vector is bigger, and 0 if the two vectors are the same</returns>
		public int CompareTo(object other) {
			if(other == null) {
				return -1;
			}
			if(other is Vector4) {
				return CompareTo((Vector4)other);
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
			if(obj is Vector4) {
				return this.Equals((Vector4)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hashing code of the type</summary>
		/// <returns>Returns the hashing code of the type</returns>
		public override int GetHashCode() { return (int)this.x ^ (int)this.y ^ (int)this.z ^ (int)this.w; }
		
		/// <summary>Gets the vector in string form</summary>
		/// <returns>Returns the vector in string form</returns>
		public override string ToString() { return "{ x: " + this.x + ", y: " + this.y + ", z: " + this.z + ", w: " + this.w + " }"; }
		
		#endregion // Public Methods
		
		#region Methods
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PC IConvertable<Vertex3PC>.Convert() { return new Vertex3PC(this.ToVector3(), Color.White); }
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PCTN IConvertable<Vertex3PCTN>.Convert() { return new Vertex3PCTN(this.ToVector3(), Color.White, Vector2.Zero, Vector3.Zero); }
		
		#endregion // Methods
		
		#region Operators
		
		/// <summary>An operator to find if the two vectors are equal to each other</summary>
		/// <param name="left">The left vector to check</param>
		/// <param name="right">The right vector to check</param>
		/// <returns>Returns true if the two vectors are equal</returns>
		public static bool operator ==(Vector4 left, Vector4 right) { return left.Equals(right); }
		
		/// <summary>An operator to find if the two vectors are not equal to each other</summary>
		/// <param name="left">The left vector to check</param>
		/// <param name="right">The right vector to check</param>
		/// <returns>Returns true if the two vectors are not equal</returns>
		public static bool operator !=(Vector4 left, Vector4 right) { return !left.Equals(right); }
		
		/// <summary>An operator to add two vectors together</summary>
		/// <param name="left">The left vector to add together</param>
		/// <param name="right">The right vector to add together with</param>
		/// <returns>Returns a vector that has the two vectors added together</returns>
		public static Vector4 operator +(Vector4 left, Vector4 right) { return Vector4.Add(ref left, ref right); }
		
		/// <summary>An operator to subtract one vector from another</summary>
		/// <param name="left">The first vector to subtract from</param>
		/// <param name="right">The second vector to subtract with</param>
		/// <returns>Returns the vector that has the vector subtracted from another vector</returns>
		/// <remarks>Note: The resulting vector holds the direction from the second vector to the first vector. a &lt;-- b</remarks>
		public static Vector4 operator -(Vector4 left, Vector4 right) { return Vector4.Subtract(ref left, ref right); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="left">The scalar value as a real number used to scale the vector</param>
		/// <param name="right">The vector used to scale</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 operator *(float left, Vector4 right) { return Vector4.Multiply(left, ref right); }
		
		/// <summary>Multiplies the vector with the scalar</summary>
		/// <param name="left">The vector used to scale</param>
		/// <param name="right">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 operator *(Vector4 left, float right) { return Vector4.Multiply(right, ref left); }
		
		/// <summary>Divides the vector with the scalar</summary>
		/// <param name="left">The vector used to scale</param>
		/// <param name="right">The scalar value as a real number used to scale the vector</param>
		/// <returns>Returns the scaled vector</returns>
		public static Vector4 operator /(Vector4 left, float right) { return Vector4.Divide(right, ref left); }
		
		/// <summary>Performs a dot product on the two vectors</summary>
		/// <param name="left">The first vector to dot product with</param>
		/// <param name="right">The first vector to dot product with</param>
		/// <returns>Returns the value that represent the angle between vectors</returns>
		public static float operator *(Vector4 left, Vector4 right) { return Vector4.Dot(ref left, ref right); }
		
		/// <summary>Negates the vector to make the vector a negative if it's a positive and a positive if it's a negative</summary>
		/// <param name="obj">The vector to negate</param>
		/// <returns>Returns the negated vector</returns>
		public static Vector4 operator -(Vector4 obj) { return Vector4.Negate(ref obj); }
		
		/// <summary>Converts the vector4 into a vector3</summary>
		/// <param name="vec">The vector to convert</param>
		public static explicit operator Vector3(Vector4 vec) { return Vector4.ToVector3(ref vec); }
		
		/// <summary>Converts the vector4 into a vector2</summary>
		/// <param name="vec">The vector to convert</param>
		public static explicit operator Vector2(Vector4 vec) { return Vector4.ToVector2(ref vec); }
		
		#endregion // Operators
	}
}

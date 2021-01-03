
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A ray that holds a point and a direction (unit vector / normalized)</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Ray : System.IEquatable<Ray> {
		#region Field Variables
		// Variables
		private Vector3 origin;
		private Vector3 direction;
		/// <summary>A ray that has no direction and origin at (0, 0, 0)</summary>
		public static readonly Ray Empty = new Ray(Vector3.Zero, Vector3.Zero);
		/// <summary>A ray that has direction (1, 0, 0) and origin at (0, 0, 0)</summary>
		public static readonly Ray UnitXDir = new Ray(Vector3.Zero, Vector3.UnitX);
		/// <summary>A ray that has direction (0, 1, 0) and origin at (0, 0, 0)</summary>
		public static readonly Ray UnitYDir = new Ray(Vector3.Zero, Vector3.UnitY);
		/// <summary>A ray that has direction (0, 0, 1) and origin at (0, 0, 0)</summary>
		public static readonly Ray UnitZDir = new Ray(Vector3.Zero, Vector3.UnitZ);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the origin of the ray</summary>
		public Vector3 Origin { get { return this.origin; } set { this.origin = value; } }
		
		/// <summary>Gets and sets the direction of the ray, will always be a unit vector</summary>
		public Vector3 Direction { get { return this.direction; } set {
			this.direction = value;
			Mathx.Normalize(ref this.direction, out this.direction);
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a ray</summary>
		/// <param name="origin">The ray's origin</param>
		/// <param name="direction">The ray's direction</param>
		public Ray(Vector3 origin, Vector3 direction) {
			this.origin = origin;
			this.direction = direction;
			Mathx.Normalize(ref this.direction, out this.direction);
		}
		
		/// <summary>A constructor for creating a ray</summary>
		/// <param name="origin">The ray's origin</param>
		/// <param name="direction">The ray's direction</param>
		public Ray(Vector2 origin, Vector2 direction) : this(new Vector3(origin.x, origin.y), new Vector3(direction.x, direction.y)) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region GetPoint Methods
		
		/// <summary>Gets the point in the ray from the given distance</summary>
		/// <param name="distance">The distance to go down the ray to get the point</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <param name="result">The resulting point that lies within the ray</param>
		public static void GetPoint(float distance, ref Ray ray, out Vector3 result) {
			// Variables
			Vector3 temp;
			
			result = ray.origin;
			Mathx.Multiply(distance, ref ray.direction, out temp);
			Mathx.Add(ref result, ref temp, out result);
		}
		
		/// <summary>Gets the point in the ray from the given distance</summary>
		/// <param name="distance">The distance to go down the ray to get the point</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <param name="result">The resulting point that lies within the ray</param>
		public static void GetPoint(float distance, Ray ray, out Vector3 result) { GetPoint(distance, ref ray, out result); }
		
		/// <summary>Gets the point in the ray from the given distance</summary>
		/// <param name="distance">The distance to go down the ray to get the point</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <returns>Returns the resulting point that lies within the ray</returns>
		public static Vector3 GetPoint(float distance, ref Ray ray) {
			// Variables
			Vector3 result;
			
			GetPoint(distance, ref ray, out result);
			
			return result;
		}
		
		/// <summary>Gets the point in the ray from the given distance</summary>
		/// <param name="distance">The distance to go down the ray to get the point</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <returns>Returns the resulting point that lies within the ray</returns>
		public static Vector3 GetPoint(float distance, Ray ray) { return GetPoint(distance, ref ray); }
		
		#endregion // GetPoint Methods
		
		#region GetPointFromPoint Methods
		
		/// <summary>Gets a point on the ray using an arbitrary point in the world. Projects the given point onto the ray</summary>
		/// <param name="point">The point to project into the ray</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <param name="result">The resulting point that is projected onto the ray</param>
		public static void GetPointFromPoint(ref Vector3 point, ref Ray ray, out Vector3 result) {
			// Variables
			Vector3 a;
			
			Mathx.Subtract(ref point, ref ray.origin, out a);
			Mathx.Project(ref a, ref ray.direction, out result);
			Mathx.Add(ref result, ref ray.origin, out result);
		}
		
		/// <summary>Gets a point on the ray using an arbitrary point in the world. Projects the given point onto the ray</summary>
		/// <param name="point">The point to project into the ray</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <param name="result">The resulting point that is projected onto the ray</param>
		public static void GetPointFromPoint(Vector3 point, Ray ray, out Vector3 result) { GetPointFromPoint(ref point, ref ray, out result); }
		
		/// <summary>Gets a point on the ray using an arbitrary point in the world. Projects the given point onto the ray</summary>
		/// <param name="point">The point to project into the ray</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <returns>Returns the resulting point that is projected onto the ray</returns>
		public static Vector3 GetPointFromPoint(ref Vector3 point, ref Ray ray) {
			// Variables
			Vector3 result;
			
			GetPointFromPoint(ref point, ref ray, out result);
			
			return result;
		}
		
		/// <summary>Gets a point on the ray using an arbitrary point in the world. Projects the given point onto the ray</summary>
		/// <param name="point">The point to project into the ray</param>
		/// <param name="ray">The ray used to get the point</param>
		/// <returns>Returns the resulting point that is projected onto the ray</returns>
		public static Vector3 GetPointFromPoint(Vector3 point, Ray ray) { return GetPointFromPoint(ref point, ref ray); }
		
		#endregion // GetPointFromPoint Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Finds if this ray and the other ray are equal</summary>
		/// <param name="ray">The other ray to find if it equals</param>
		/// <returns>Returns true if the two rays are equal to each other</returns>
		public bool Equals(Ray ray) { return (this.origin == ray.origin && this.direction == ray.direction); }
		
		/// <summary>Finds if this ray and the other ray are equal</summary>
		/// <param name="obj">The other ray to find if it equals</param>
		/// <returns>Returns true if the two rays are equal to each other</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Ray) {
				return this.Equals((Ray)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the ray</summary>
		/// <returns>Returns the hash code from the ray</returns>
		public override int GetHashCode() { return (this.origin.GetHashCode() ^ this.direction.GetHashCode()); }
		
		/// <summary>Gets the ray in string form</summary>
		/// <returns>Returns the ray in string form</returns>
		public override string ToString() { return "{ pos: " + this.origin + ", dir: " + this.direction + " }"; }
		
		#endregion // Public Methods
		
		#region Operator
		
		/// <summary>Finds if the two rays are equal</summary>
		/// <param name="left">The first ray to find if it's equal</param>
		/// <param name="right">The second ray to find if it's equal</param>
		/// <returns>Returns true if the rays are equal</returns>
		public static bool operator ==(Ray left, Ray right) { return left.Equals(right); }
		
		/// <summary>Finds if the two rays are not equal</summary>
		/// <param name="left">The first ray to find if it's not equal</param>
		/// <param name="right">The second ray to find if it's not equal</param>
		/// <returns>Returns true if the rays are not equal</returns>
		public static bool operator !=(Ray left, Ray right) { return !left.Equals(right); }
		
		#endregion // Operator
	}
}

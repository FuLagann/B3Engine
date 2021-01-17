
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A representation of a geometric 2D plane that sits in the 3D space.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Plane : System.IEquatable<Plane> {
		#region Field Variables
		// Variables
		/// <summary>The normal that is perpendicular to the plane</summary>
		private Vector3 normal;
		/// <summary>The distance of the plane from the origin up towards the normal</summary>
		private float distance;
		/// <summary>The plane that represents the entire x-y plane</summary>
		public static readonly Plane XYPlane = new Plane(Vector3.UnitZ, 0.0f);
		/// <summary>The plane that represents the entire x-z plane</summary>
		public static readonly Plane XZPlane = new Plane(Vector3.UnitY, 0.0f);
		/// <summary>The plane that represents the entire y-z plane</summary>
		public static readonly Plane YZPlane = new Plane(Vector3.UnitX, 0.0f);
		
		#endregion // Field Variables
		
		#region Public Properites
		
		/// <summary>Gets and sets the normal of the plane</summary>
		public Vector3 Normal { get { return this.normal; } set {
			this.normal = value;
			Mathx.Normalize(ref this.normal, out this.normal);
		} }
		
		/// <summary>Gets and sets the distance of the plane</summary>
		public float Distance { get { return this.distance; } set { this.distance = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a plane</summary>
		/// <param name="normal">The normal that is perpendicular to the plane</param>
		/// <param name="distance">The distance that the plane is from the origin up towards the normal</param>
		public Plane(Vector3 normal, float distance) {
			this.normal = normal;
			this.distance = distance;
			Mathx.Normalize(ref this.normal, out this.normal);
		}
		
		/// <summary>A constructor for creating a plane using a bunch of floats</summary>
		/// <param name="x">The x coordinate of the normal</param>
		/// <param name="y">The y coordinate of the normal</param>
		/// <param name="z">The z coordinate of the normal</param>
		/// <param name="distance">The distance that the plane is from the origin up towards the normal</param>
		/// <returns></returns>
		public Plane(float x, float y, float z, float distance) : this(new Vector3(x, y, z), distance) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region CreateFromThreePoints Methods
		
		/// <summary>Creates a plane from three points in space</summary>
		/// <param name="p0">The first point to be used</param>
		/// <param name="p1">The second point to be used</param>
		/// <param name="p2">The last point to be used</param>
		/// <param name="result">The resulting plane created from the three points</param>
		public static void CreateFromThreePoints(ref Vector3 p0, ref Vector3 p1, ref Vector3 p2, out Plane result) {
			// Variables
			Vector3 temp, temp2;
			
			Mathx.Subtract(ref p1, ref p0, out temp);
			Mathx.Subtract(ref p2, ref p0, out temp2);
			
			Mathx.CrossProduct(ref temp, ref temp2, out result.normal);
			Mathx.Normalize(ref result.normal, out result.normal);
			Mathx.Dot(ref result.normal, ref p0, out result.distance);
			result.distance = -result.distance;
		}
		
		/// <summary>Creates a plane from three points in space</summary>
		/// <param name="p0">The first point to be used</param>
		/// <param name="p1">The second point to be used</param>
		/// <param name="p2">The last point to be used</param>
		/// <param name="result">The resulting plane created from the three points</param>
		public static void CreateFromThreePoints(Vector3 p0, Vector3 p1, Vector3 p2, out Plane result) { CreateFromThreePoints(ref p0, ref p1, ref p2, out result); }
		
		/// <summary>Creates a plane from three points in space</summary>
		/// <param name="p0">The first point to be used</param>
		/// <param name="p1">The second point to be used</param>
		/// <param name="p2">The last point to be used</param>
		/// <returns>Returns the resulting plane created from the three points</returns>
		public static Plane CreateFromThreePoints(ref Vector3 p0, ref Vector3 p1, ref Vector3 p2) {
			// Variables
			Plane result;
			
			CreateFromThreePoints(ref p0, ref p1, ref p2, out result);
			
			return result;
		}
		
		/// <summary>Creates a plane from three points in space</summary>
		/// <param name="p0">The first point to be used</param>
		/// <param name="p1">The second point to be used</param>
		/// <param name="p2">The last point to be used</param>
		/// <returns>Returns the resulting plane created from the three points</returns>
		public static Plane CreateFromThreePoints(Vector3 p0, Vector3 p1, Vector3 p2) { return CreateFromThreePoints(ref p0, ref p1, ref p2); }
		
		#endregion // CreateFromThreePoints Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Finds if the two planes are eqaul to each other</summary>
		/// <param name="other">The other plane</param>
		/// <returns>Returns true if the two planes are equal to each other</returns>
		public bool Equals(Plane other) { return (this.normal == other.normal && this.distance == other.distance); }
		
		/// <summary>Finds if the two planes are eqaul to each other</summary>
		/// <param name="obj">The other plane</param>
		/// <returns>Returns true if the two planes are equal to each other</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			
			if(obj is Plane) {
				return this.Equals((Plane)obj);
			}
			
			return false;
		}
		
		/// <summary>Gets the hash code from the plane</summary>
		/// <returns>Returns the hash code from the plane</returns>
		public override int GetHashCode() { return this.normal.GetHashCode() ^ (int)this.distance; }
		
		/// <summary>Gets the plane in string form</summary>
		/// <returns>Returns the plane in string form</returns>
		public override string ToString() { return "{ normal: " + this.normal + ", distance: " + this.distance + " }"; }
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two planes are equal to each other</summary>
		/// <param name="left">The first plane</param>
		/// <param name="right">The second plane</param>
		/// <returns>Returns true if the two planes are equal to each other</returns>
		public static bool operator ==(Plane left, Plane right) { return left.Equals(right); }
		
		/// <summary>Finds if the two planes are not equal to each other</summary>
		/// <param name="left">The first plane</param>
		/// <param name="right">The second plane</param>
		/// <returns>Returns true if the two planes are not equal to each other</returns>
		public static bool operator !=(Plane left, Plane right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}

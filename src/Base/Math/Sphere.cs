
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 3D representation of a sphere</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Sphere : System.IEquatable<Sphere> {
		#region Field Variables
		// Variables
		/// <summary>The center of the sphere</summary>
		public Vector3 center;
		/// <summary>The radius of the sphere</summary>
		public float radius;
		/// <summary>An empty sphere with radius of 0 {(0, 0, 0), 0}</summary>
		public static readonly Sphere Empty = new Sphere(Vector3.Zero, 0.0f);
		/// <summary>A unit sphere with radius of 1 {(0, 0, 0), 1}</summary>
		public static readonly Sphere Unit = new Sphere(Vector3.Zero, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the x coordinate of the sphere</summary>
		public float X { get { return this.center.x; } set { this.center.x = value; } }
		
		/// <summary>Gets and sets the y coordinate of the sphere</summary>
		public float Y { get { return this.center.y; } set { this.center.y = value; } }
		
		/// <summary>Gets and sets the z coordinate of the sphere</summary>
		public float Z { get { return this.center.z; } set { this.center.z = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a sphere</summary>
		/// <param name="center">The center of the sphere</param>
		/// <param name="radius">The radius of the sphere</param>
		public Sphere(Vector3 center, float radius) {
			this.center = center;
			this.radius = radius;
		}
		
		/// <summary>A constructor for creating a sphere</summary>
		/// <param name="x">The x coordinate of the sphere</param>
		/// <param name="y">The y coordinate of the sphere</param>
		/// <param name="z">The z coordinate of the sphere</param>
		/// <param name="radius">The radius of the sphere</param>
		public Sphere(float x, float y, float z, float radius) : this(new Vector3(x, y, z), radius) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Encompass Methods
		
		/// <summary>Creates a sphere that encompasses the two given spheres</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <param name="result">Returns a sphere that encompases both spheres</param>
		public static void Encompass(ref Sphere a, ref Sphere b, out Sphere result) {
			// Variables
			Vector3 dir;
			float mag;
			float ar = Mathx.Abs(a.radius);
			float br = Mathx.Abs(b.radius);
			
			Mathx.Subtract(ref b.center, ref a.center, out dir);
			mag = dir.Magnitude;
			
			if(mag <= ar - br) {
				result = a;
				return;
			}
			if(mag <= br - ar) {
				result = b;
				return;
			}
			// Variables
			Vector3 s, r;
			
			Mathx.Divide(mag, ref dir, out dir);
			// Gets an endpoint of the sphere
			Mathx.Multiply(ar, ref dir, out s);
			Mathx.Subtract(ref a.center, ref s, out s);
			// Gets the opposite endpoint of the sphere
			Mathx.Multiply(br, ref dir, out r);
			Mathx.Add(ref b.center, ref r, out r);
			// Gets a diameter vector
			Mathx.Subtract(ref r, ref s, out r);
			// Gets a radius vector
			Mathx.Multiply(0.5f, ref r, out result.center);
			Mathx.Add(ref s, ref result.center, out result.center);
			result.radius = 0.5f * r.Magnitude;
		}
		
		/// <summary>Creates a sphere that encompasses the two given spheres</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <param name="result">Returns a sphere that encompases both spheres</param>
		public static void Encompass(Sphere a, Sphere b, out Sphere result) { Encompass(ref a, ref b, out result); }
		
		/// <summary>Creates a sphere that encompasses the two given spheres</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns a sphere that encompases both spheres</returns>
		public static Sphere Encompass(ref Sphere a, ref Sphere b) {
			// Variables
			Sphere result;
			
			Encompass(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Creates a sphere that encompasses the two given spheres</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns a sphere that encompases both spheres</returns>
		public static Sphere Encompass(Sphere a, Sphere b) { return Encompass(ref a, ref b); }
		
		/// <summary>Creates a sphere that encompasses the array of spheres given</summary>
		/// <param name="result">Returns a sphere that encompasses the array of spheres</param>
		/// <param name="spheres">The array of spheres to encompass</param>
		public static void Encompass(out Sphere result, params Sphere[] spheres) {
			if(spheres.Length == 0) {
				result = Sphere.Empty;
				return;
			}
			
			result = spheres[0];
			
			for(int i = 1; i < spheres.Length; i++) {
				Encompass(ref result, ref spheres[i], out result);
			}
		}
		
		/// <summary>Creates a sphere that encompasses the array of spheres given</summary>
		/// <param name="spheres">The array of spheres to encompass</param>
		/// <returns>Returns a sphere that encompasses the array of spheres</returns>
		public static Sphere Encompass(params Sphere[] spheres) {
			// Variables
			Sphere result;
			
			Encompass(out result, spheres);
			
			return result;
		}
		
		#endregion // Encompass Methods
		
		#region IsOverlapping Methods
		
		/// <summary>Finds if the two sphere are overlapping</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns true if the two spheres are overlapping</returns>
		public static bool IsOverlapping(ref Sphere a, ref Sphere b) {
			// Variables
			Vector3 dir;
			
			Mathx.Subtract(ref a.center, ref b.center, out dir);
			
			return (dir.Magnitude <= Mathx.Abs(a.radius) + Mathx.Abs(b.radius));
		}
		
		/// <summary>Finds if the two sphere are overlapping</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns true if the two spheres are overlapping</returns>
		public static bool IsOverlapping(Sphere a, Sphere b) { return IsOverlapping(ref a, ref b); }
		
		#endregion // IsOverlapping Methods
		
		#region IsDisjoint Methods
		
		/// <summary>Finds if the two spheres are disjoint (not intersecting, touching, or contained within each other)</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns true if the two spheres are disjoint</returns>
		public static bool IsDisjoint(ref Sphere a, ref Sphere b) { return !(IsOverlapping(ref a, ref b)); }
		
		/// <summary>Finds if the two spheres are disjoint (not intersecting, touching, or contained within each other)</summary>
		/// <param name="a">The first sphere</param>
		/// <param name="b">The second sphere</param>
		/// <returns>Returns true if the two spheres are disjoint</returns>
		public static bool IsDisjoint(Sphere a, Sphere b) { return IsDisjoint(ref a, ref b); }
		
		#endregion // IsDisjoint Methods
		
		#region IsContained Methods
		
		/// <summary>Finds if the outside sphere is containing the inside sphere</summary>
		/// <param name="outside">The outside sphere</param>
		/// <param name="inside">The inside sphere</param>
		/// <returns>Returns true if the inside sphere is contained within the outside sphere</returns>
		public static bool IsContained(ref Sphere outside, ref Sphere inside) {
			// Variables
			Vector3 dir;
			
			Mathx.Subtract(ref outside.center, ref inside.center, out dir);
			
			return (dir.Magnitude <= Mathx.Abs(outside.radius) - Mathx.Abs(inside.radius));
		}
		
		/// <summary>Finds if the outside sphere is containing the inside sphere</summary>
		/// <param name="outside">The outside sphere</param>
		/// <param name="inside">The inside sphere</param>
		/// <returns>Returns true if the inside sphere is contained within the outside sphere</returns>
		public static bool IsContained(Sphere outside, Sphere inside) { return IsContained(ref outside, ref inside); }
		
		#endregion // IsContained Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Encompasses this sphere and the other sphere</summary>
		/// <param name="other">The other sphere</param>
		/// <returns>Returns a sphere that encompasses this sphere and the other sphere</returns>
		public Sphere Encompass(Sphere other) { return Encompass(ref this, ref other); }
		
		/// <summary>Finds if the two sphere are overlapping</summary>
		/// <param name="other">The other sphere</param>
		/// <returns>Returns true if the two spheres are overlapping</returns>
		public bool IsOverlapping(Sphere other) { return IsOverlapping(ref this, ref other); }
		
		/// <summary>Finds if the two spheres are disjoint (not intersecting, touching, or contained within each other)</summary>
		/// <param name="other">The other sphere</param>
		/// <returns>Returns true if the two spheres are disjoint</returns>
		public bool IsDisjoint(Sphere other) { return IsDisjoint(ref this, ref other); }
		
		/// <summary>Finds if the this sphere is containing the inside sphere</summary>
		/// <param name="inside">The inside sphere</param>
		/// <returns>Returns true if the inside sphere is contained within the this sphere</returns>
		public bool IsContained(Sphere inside) { return IsContained(ref this, ref inside); }
		
		/// <summary>Finds if the two spheres are equal to each other</summary>
		/// <param name="other">The other sphere</param>
		/// <returns>Returns true if the two spheres are equal to each other</returns>
		public bool Equals(Sphere other) { return (this.center == other.center && this.radius == other.radius); }
		
		/// <summary>Finds if the two spheres are equal to each other</summary>
		/// <param name="other">The other sphere</param>
		/// <returns>Returns true if the two spheres are equal to each other</returns>
		public override bool Equals(object other) {
			if(other == null) {
				return false;
			}
			if(other is Sphere) {
				return this.Equals((Sphere)other);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the sphere</summary>
		/// <returns>Returns the hash code from the sphere</returns>
		public override int GetHashCode() { return this.center.GetHashCode() ^ (int)this.radius; }
		
		/// <summary>Gets the sphere in string form</summary>
		/// <returns>Returns the sphere in string form</returns>
		public override string ToString() { return $"{{ center: { this.center }, radius: { this.radius } }}"; }
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two spheres are equal to each other</summary>
		/// <param name="left">The first sphere</param>
		/// <param name="right">The second sphere</param>
		/// <returns>Returns true if the two spheres are equal to each other</returns>
		public static bool operator ==(Sphere left, Sphere right) { return left.Equals(right); }
		
		/// <summary>Finds if the two spheres are not equal to each other</summary>
		/// <param name="left">The first sphere</param>
		/// <param name="right">The second sphere</param>
		/// <returns>Returns true if the two spheres are not equal to each other</returns>
		public static bool operator !=(Sphere left, Sphere right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}

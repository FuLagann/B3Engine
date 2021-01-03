
using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 2D representation of a circle</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Circle : System.IEquatable<Circle> {
		#region Field Variables
		// Variables
		/// <summary>The center of the circle</summary>
		public Vector2 center;
		/// <summary>The radius of the circle</summary>
		public float radius;
		/// <summary>An empty circle with radius of 0 (0, 0), 0}</summary>
		public static readonly Circle Empty = new Circle(Vector2.Zero, 0.0f);
		/// <summary>A unit circle with radius of 1 (0, 0), 1}</summary>
		public static readonly Circle Unit = new Circle(Vector2.Zero, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the x coordinate of the circle</summary>
		public float X { get { return this.center.x; } set { this.center.x = value; } }
		
		/// <summary>Gets and sets the y coordinate of the circle</summary>
		public float Y { get { return this.center.y; } set { this.center.y = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a circle</summary>
		/// <param name="center">The center of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		public Circle(Vector2 center, float radius) {
			this.center = center;
			this.radius = radius;
		}
		
		/// <summary>A constructor for creating a circle</summary>
		/// <param name="x">The x coordinate of the circle</param>
		/// <param name="y">The y coordinate of the circle</param>
		/// <param name="radius">The radius of the circle</param>
		public Circle(float x, float y, float radius) : this(new Vector2(x, y), radius) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Encompass Methods
		
		/// <summary>Creates a circle that encompasses the two given circles</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <param name="result">Returns a circle that encompases both circles</param>
		public static void Encompass(ref Circle a, ref Circle b, out Circle result) {
			// Variables
			Vector2 dir;
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
			Vector2 s, r;
			
			Mathx.Divide(mag, ref dir, out dir);
			// Gets an endpoint of the circle
			Mathx.Multiply(ar, ref dir, out s);
			Mathx.Subtract(ref a.center, ref s, out s);
			// Gets the opposite endpoint of the circle
			Mathx.Multiply(br, ref dir, out r);
			Mathx.Add(ref b.center, ref r, out r);
			// Gets a diameter vector
			Mathx.Subtract(ref r, ref s, out r);
			// Gets a radius vector
			Mathx.Multiply(0.5f, ref r, out result.center);
			Mathx.Add(ref s, ref result.center, out result.center);
			result.radius = 0.5f * r.Magnitude;
		}
		
		/// <summary>Creates a circle that encompasses the two given circles</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <param name="result">Returns a circle that encompases both circles</param>
		public static void Encompass(Circle a, Circle b, out Circle result) { Encompass(ref a, ref b, out result); }
		
		/// <summary>Creates a circle that encompasses the two given circles</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns a circle that encompases both circles</returns>
		public static Circle Encompass(ref Circle a, ref Circle b) {
			// Variables
			Circle result;
			
			Encompass(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Creates a circle that encompasses the two given circles</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns a circle that encompases both circles</returns>
		public static Circle Encompass(Circle a, Circle b) { return Encompass(ref a, ref b); }
		
		/// <summary>Creates a circle that encompasses the array of circles given</summary>
		/// <param name="result">Returns a circle that encompasses the array of circles</param>
		/// <param name="circles">The array of circles to encompass</param>
		public static void Encompass(out Circle result, params Circle[] circles) {
			if(circles.Length == 0) {
				result = Circle.Empty;
				return;
			}
			
			result = circles[0];
			
			for(int i = 1; i < circles.Length; i++) {
				Encompass(ref result, ref circles[i], out result);
			}
		}
		
		/// <summary>Creates a circle that encompasses the array of circles given</summary>
		/// <param name="circles">The array of circles to encompass</param>
		/// <returns>Returns a circle that encompasses the array of circles</returns>
		public static Circle Encompass(params Circle[] circles) {
			// Variables
			Circle result;
			
			Encompass(out result, circles);
			
			return result;
		}
		
		#endregion // Encompass Methods
		
		#region IsOverlapping Methods
		
		/// <summary>Finds if the two circles are overlapping</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns true if the two circles are overlapping</returns>
		public static bool IsOverlapping(ref Circle a, ref Circle b) {
			// Variables
			Vector2 dir;
			
			Mathx.Subtract(ref a.center, ref b.center, out dir);
			
			return (dir.Magnitude <= Mathx.Abs(a.radius) + Mathx.Abs(b.radius));
		}
		
		/// <summary>Finds if the two circles are overlapping</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns true if the two circles are overlapping</returns>
		public static bool IsOverlapping(Circle a, Circle b) { return IsOverlapping(ref a, ref b); }
		
		#endregion // IsOverlapping Methods
		
		#region IsDisjoint Methods
		
		/// <summary>Finds if the two circles are disjoint from each other (not intersecting, touching, or contained within)</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns true if the two circles are disjoint from each other</returns>
		public static bool IsDisjoint(ref Circle a, ref Circle b) { return !IsOverlapping(ref a, ref b); }
		
		/// <summary>Finds if the two circles are disjoint from each other (not intersecting, touching, or contained within)</summary>
		/// <param name="a">The first circle</param>
		/// <param name="b">The second circle</param>
		/// <returns>Returns true if the two circles are disjoint from each other</returns>
		public static bool IsDisjoint(Circle a, Circle b) { return IsDisjoint(ref a, ref b); }
		
		#endregion // IsDisjoint Methods
		
		#region IsContained Methods
		
		/// <summary>Finds if the outside circle is containing the inside circle</summary>
		/// <param name="outside">The outside circle</param>
		/// <param name="inside">The inside circle</param>
		/// <returns>Returns true if the inside circle is contained within the outside circle</returns>
		public static bool IsContained(ref Circle outside, ref Circle inside) {
			// Variables
			Vector2 dir;
			
			Mathx.Subtract(ref outside.center, ref inside.center, out dir);
			
			return (dir.Magnitude <= Mathx.Abs(outside.radius) - Mathx.Abs(inside.radius));
		}
		
		/// <summary>Finds if the outside circle is containing the inside circle</summary>
		/// <param name="outside">The outside circle</param>
		/// <param name="inside">The inside circle</param>
		/// <returns>Returns true if the inside circle is contained within the outside circle</returns>
		public static bool IsContained(Circle outside, Circle inside) { return IsContained(ref outside, ref inside); }
		
		#endregion // IsContained Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Finds if the two circles are overlapping</summary>
		/// <param name="other">The other circle</param>
		/// <returns>Returns true if the two circles are overlapping</returns>
		public bool IsOverlapping(Circle other) { return IsOverlapping(ref this, ref other); }
		
		/// <summary>Finds if the two circles are disjoint from each other (not intersecting, touching, or contained within)</summary>
		/// <param name="other">The other circle</param>
		/// <returns>Returns true if the two circles are disjoint from each other</returns>
		public bool IsDisjoint(Circle other) { return IsDisjoint(ref this, ref other); }
		
		/// <summary>Finds if the outside circle is containing the inside circle</summary>
		/// <param name="inside">The inside circle</param>
		/// <returns>Returns true if the inside circle is contained within the outside circle</returns>
		public bool IsContained(Circle inside) { return IsContained(ref this, ref inside); }
		
		/// <summary>Finds if the two circles are equal to each other</summary>
		/// <param name="other">The other circle</param>
		/// <returns>Returns true if the two circles are equal to each other</returns>
		public bool Equals(Circle other) { return (this.center == other.center && this.radius == other.radius); }
		
		/// <summary>Finds if the two circles are equal to each other</summary>
		/// <param name="other">The other circle</param>
		/// <returns>Returns true if the two circles are equal to each other</returns>
		public override bool Equals(object other) {
			if(other == null) {
				return false;
			}
			if(other is Circle) {
				return this.Equals((Circle)other);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the circle</summary>
		/// <returns>Returns the hash code from the circle</returns>
		public override int GetHashCode() { return this.center.GetHashCode() ^ (int)this.radius; }
		
		/// <summary>Gets the circle in string form</summary>
		/// <returns>Returns the circle in string form</returns>
		public override string ToString() { return "{ center: " + this.center + ", radius: " + this.radius + " }"; }
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two circles are equal to each other</summary>
		/// <param name="left">The first circle</param>
		/// <param name="right">The second circle</param>
		/// <returns>Returns true if the two circles are equal to each other</returns>
		public static bool operator ==(Circle left, Circle right) { return left.Equals(right); }
		
		/// <summary>Finds if the two circles are not equal to each other</summary>
		/// <param name="left">The first circle</param>
		/// <param name="right">The second circle</param>
		/// <returns>Returns true if the two circles are not equal to each other</returns>
		public static bool operator !=(Circle left, Circle right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}


using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 3D structure with and x-y-z coordinate, width, height, and depth. Used to represent rectangular objects in 3D</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Box : System.IEquatable<Box> {
		#region Field Variables
		// Variables
		/// <summary>The x coordinate of the box</summary>
		public float x;
		/// <summary>The y coordinate of the box</summary>
		public float y;
		/// <summary>The z coordinate of the box</summary>
		public float z;
		/// <summary>The width of the box</summary>
		public float width;
		/// <summary>The height of the box</summary>
		public float height;
		/// <summary>The depth of the box</summary>
		public float depth;
		/// <summary>An empty box with location (0, 0, 0) and size (0, 0, 0)</summary>
		public static readonly Box Empty = new Box(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
		/// <summary>A unit box with location (0, 0, 0) and size (1, 1, 1)</summary>
		public static readonly Box One = new Box(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the left most part of the box</summary>
		public float Left { get { return Mathx.Min(this.x, this.x + this.width); } }
		
		/// <summary>Gets the right most part of the box</summary>
		public float Right { get { return Mathx.Max(this.x, this.x + this.width); } }
		
		/// <summary>Gets the top most part of the box</summary>
		public float Top { get { return Mathx.Min(this.y, this.y + height); } }
		
		/// <summary>Gets the bottom most part of the box</summary>
		public float Bottom { get { return Mathx.Max(this.y, this.y + this.height); } }
		
		/// <summary>Gets the near most part of the box</summary>
		public float Near { get { return Mathx.Min(this.z, this.z + this.depth); } }
		
		/// <summary>Gets the far most part of the box</summary>
		public float Far { get { return Mathx.Max(this.z, this.z + this.depth); } }
		
		/// <summary>Gets the farthest top left corner of the box</summary>
		public Vector3 FarTopLeft { get { return new Vector3(this.Left, this.Top, this.Far); } }
		
		/// <summary>Gets the nearthest top left corner of the box</summary>
		public Vector3 NearTopLeft { get { return new Vector3(this.Left, this.Top, this.Near); } }
		
		/// <summary>Gets the farthest top right corner of the box</summary>
		public Vector3 FarTopRight { get { return new Vector3(this.Right, this.Top, this.Far); } }
		
		/// <summary>Gets the nearest top right corner of the box</summary>
		public Vector3 NearTopRight { get { return new Vector3(this.Right, this.Top, this.Near); } }
		
		/// <summary>Gets the farthest bottom left corner of the box</summary>
		public Vector3 FarBottomLeft { get { return new Vector3(this.Left, this.Bottom, this.Far); } }
		
		/// <summary>Gets the nearest bottom left corner of the box</summary>
		public Vector3 NearBottomLeft { get { return new Vector3(this.Left, this.Bottom, this.Near); } }
		
		/// <summary>Gets the farthest bottom right corner of the box</summary>
		public Vector3 FarBottomRight { get { return new Vector3(this.Right, this.Bottom, this.Far); } }
		
		/// <summary>Gets the nearest bottom right corner of the box</summary>
		public Vector3 NearBottomRight { get { return new Vector3(this.Right, this.Bottom, this.Near); } }
		
		/// <summary>Gets and sets the original position of the box</summary>
		/// <remarks>This isn't the corner with the smallest values; to get that use <see cref="B3.Box.NearTopLeft"/> property</remarks>
		public Vector3 Position { get { return new Vector3(this.x, this.y, this.z); } set {
			this.x = value.x;
			this.y = value.y;
			this.z = value.z;
		} }
		
		/// <summary>Gets and sets the original size of the box</summary>
		/// <remarks>Values could be negative</remarks>
		public Vector3 Size { get { return new Vector3(this.width, this.height, this.depth); } set {
			this.width = value.x;
			this.height = value.y;
			this.depth = value.z;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a box</summary>
		/// <param name="x">The x coordinate of the box</param>
		/// <param name="y">The y coordinate of the box</param>
		/// <param name="z">The z coordinate of the box</param>
		/// <param name="width">The width of the box</param>
		/// <param name="height">The height of the box</param>
		/// <param name="depth">The depth of the box</param>
		public Box(float x, float y, float z, float width, float height, float depth) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.width = width;
			this.height = height;
			this.depth = depth;
		}
		
		/// <summary>A constructor for creating a box by using vectors</summary>
		/// <param name="position">The position of the box</param>
		/// <param name="size">The size of the box</param>
		public Box(Vector3 position, Vector3 size) : this(position.x, position.y, position.z, size.x, size.y, size.z) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Encompass Methods
		
		/// <summary>Creates a box that encompases the two boxes given</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <param name="result">The resulting box that encompases the other boxes</param>
		public static void Encompass(ref Box a, ref Box b, out Box result) {
			Mathx.MinMaxRange(
				out result.x, out result.width,
				a.x, b.x, a.x + a.width, b.x + b.width
			);
			Mathx.MinMaxRange(
				out result.y, out result.height,
				a.y, b.y, a.y + a.height, b.y + b.height
			);
			Mathx.MinMaxRange(
				out result.z, out result.depth,
				a.z, b.z, a.z + a.depth, b.z + b.depth
			);
			
			result.width -= result.x;
			result.height -= result.y;
			result.depth -= result.z;
		}
		
		/// <summary>Creates a box that encompases the two boxes given</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <param name="result">The resulting box that encompases the other boxes</param>
		public static void Encompass(Box a, Box b, out Box result) { Encompass(ref a, ref b, out result); }
		
		/// <summary>Creates a box that encompases the two boxes given</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns the resulting box that encompases the other boxes</returns>
		public static Box Encompass(ref Box a, ref Box b) {
			// Variables
			Box result;
			
			Encompass(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Creates a box that encompases the two boxes given</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns the resulting box that encompases the other boxes</returns>
		public static Box Encompass(Box a, Box b) { return Encompass(ref a, ref b); }
		
		/// <summary>Creates a box that encompasses the array of boxes</summary>
		/// <param name="result">The resulting box that encompases the other boxes</param>
		/// <param name="boxes">The array of boxes</param>
		public static void EncompassRange(out Box result, params Box[] boxes) {
			if(boxes.Length == 0) {
				result = Box.Empty;
				return;
			}
			result = boxes[0];
			
			for(int i = 1; i < boxes.Length; i++) {
				Encompass(ref result, ref boxes[i], out result);
			}
		}
		
		/// <summary>Creates a box that encompasses the array of boxes</summary>
		/// <param name="boxes">The array of boxes</param>
		/// <returns>Returns the resulting box that encompases the other boxes</returns>
		public static Box EncompassRange(params Box[] boxes) {
			// Variables
			Box result;
			
			EncompassRange(out result, boxes);
			
			return result;
		}
		
		#endregion // Encompass Methods
		
		#region IsOverlapping Methods
		
		/// <summary>Finds if the two boxes are overlapping</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns true if the two boxes are overlapping</returns>
		public static bool IsOverlapping(ref Box a, ref Box b) {
			// Variables
			float ax, ay, az, aw, ah, ad;
			float bx, by, bz, bw, bh, bd;
			
			Mathx.MinMax(a.x, a.x + a.width, out ax, out aw);
			Mathx.MinMax(a.y, a.y + a.height, out ay, out ah);
			Mathx.MinMax(a.z, a.z + a.depth, out az, out ad);
			Mathx.MinMax(b.x, b.x + b.width, out bx, out bw);
			Mathx.MinMax(b.y, b.y + b.height, out by, out bh);
			Mathx.MinMax(b.z, b.z + b.depth, out bz, out bd);
			
			return (
				(aw >= bx && ax <= bw) &&
				(ah >= by && ay <= bh) &&
				(ad >= bz && az <= bd)
			);
		}
		
		/// <summary>Finds if the two boxes are overlapping</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns true if the two boxes are overlapping</returns>
		public static bool IsOverlapping(Box a, Box b) { return IsOverlapping(ref a, ref b); }
		
		#endregion // IsOverlapping Methods
		
		#region IsContained Methods
		
		/// <summary>Finds if the inside box is contained within the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <returns>Returns true if the inside box is contained within the outside box</returns>
		public static bool IsContained(ref Box outside, ref Box inside) {
			// Variables
			float ax, ay, az, aw, ah, ad;
			float bx, by, bz, bw, bh, bd;
			
			Mathx.MinMax(outside.x, outside.x + outside.width, out ax, out aw);
			Mathx.MinMax(outside.y, outside.y + outside.height, out ay, out ah);
			Mathx.MinMax(outside.z, outside.z + outside.depth, out az, out ad);
			Mathx.MinMax(inside.x, inside.x + inside.width, out bx, out bw);
			Mathx.MinMax(inside.y, inside.y + inside.height, out by, out bh);
			Mathx.MinMax(inside.z, inside.z + inside.depth, out bz, out bd);
			
			return (
				(bx >= ax && bw <= aw) &&
				(by >= ay && bh <= ah) &&
				(bz >= az && bd <= ad)
			);
		}
		
		/// <summary>Finds if the inside box is contained within the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <returns>Returns true if the inside box is contained within the outside box</returns>
		public static bool IsContained(Box outside, Box inside) { return IsContained(ref outside, ref inside); }
		
		#endregion // IsContained Methods
		
		#region IsDisjoint Methods
		
		/// <summary>Finds if the two boxes are disjoint</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns true if the two boxes are disjoint</returns>
		public static bool IsDisjoint(ref Box a, ref Box b) {
			// Variables
			float ax, ay, az, aw, ah, ad;
			float bx, by, bz, bw, bh, bd;
			
			Mathx.MinMax(a.x, a.x + a.width, out ax, out aw);
			Mathx.MinMax(a.y, a.y + a.height, out ay, out ah);
			Mathx.MinMax(a.z, a.z + a.depth, out az, out ad);
			Mathx.MinMax(b.x, b.x + b.width, out bx, out bw);
			Mathx.MinMax(b.y, b.y + b.height, out by, out bh);
			Mathx.MinMax(b.z, b.z + b.depth, out bz, out bd);
			
			return (
				(ax > bw || aw < bx) ||
				(ay > bh || ah < by) ||
				(az > bd || ad < bz)
			);
		}
		
		/// <summary>Finds if the two boxes are disjoint</summary>
		/// <param name="a">The first box</param>
		/// <param name="b">The second box</param>
		/// <returns>Returns true if the two boxes are disjoint</returns>
		public static bool IsDisjoint(Box a, Box b) { return IsDisjoint(ref a, ref b); }
		
		#endregion // IsDisjoint Methods
		
		#region Clip Methods
		
		/// <summary>Clips the inside box with the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <param name="result">The resulting clipped box</param>
		public static void Clip(ref Box outside, ref Box inside, out Box result) {
			// Variables
			float ax, ay, az, aw, ah, ad;
			float bx, by, bz, bw, bh, bd;
			
			Mathx.MinMax(outside.x, outside.x + outside.width, out ax, out aw);
			Mathx.MinMax(outside.y, outside.y + outside.height, out ay, out ah);
			Mathx.MinMax(outside.z, outside.z + outside.depth, out az, out ad);
			Mathx.MinMax(inside.x, inside.x + inside.width, out bx, out bw);
			Mathx.MinMax(inside.y, inside.y + inside.height, out by, out bh);
			Mathx.MinMax(inside.z, inside.z + inside.depth, out bz, out bd);
			
			result.x = Mathx.Clamp(bx, ax, aw);
			result.y = Mathx.Clamp(by, ay, ah);
			result.z = Mathx.Clamp(bz, az, ad);
			result.width = Mathx.Max(Mathx.Min(aw, bw) - result.x, 0.0f);
			result.height = Mathx.Max(Mathx.Min(ah, bh) - result.y, 0.0f);
			result.depth = Mathx.Max(Mathx.Min(ad, bd) - result.z, 0.0f);
		}
		
		/// <summary>Clips the inside box with the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <param name="result">The resulting clipped box</param>
		public static void Clip(Box outside, Box inside, out Box result) { Clip(ref outside, ref inside, out result); }
		
		/// <summary>Clips the inside box with the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <returns>Returns the resulting clipped box</returns>
		public static Box Clip(ref Box outside, ref Box inside) {
			// Variables
			Box result;
			
			Clip(ref outside, ref inside, out result);
			
			return result;
		}
		
		/// <summary>Clips the inside box with the outside box</summary>
		/// <param name="outside">The box that should be outside</param>
		/// <param name="inside">The box that should be inside</param>
		/// <returns>Returns the resulting clipped box</returns>
		public static Box Clip(Box outside, Box inside) { return Clip(ref outside, ref inside); }
		
		#endregion // Clip Methods
		
		#region Scale Methods
		
		/// <summary>Scales the box uniformly</summary>
		/// <param name="scalar">The scalar to scale the box with</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(float scalar, ref Box box, out Box result) { Scale(scalar, scalar, scalar, ref box, out result); }
		
		/// <summary>Scales the box uniformly</summary>
		/// <param name="scalar">The scalar to scale the box with</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(float scalar, Box box, out Box result) { Scale(scalar, ref box, out result); }
		
		/// <summary>Scales the box uniformly</summary>
		/// <param name="scalar">The scalar to scale the box with</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(float scalar, ref Box box) { return Scale(scalar, scalar, scalar, ref box); }
		
		/// <summary>Scales the box uniformly</summary>
		/// <param name="scalar">The scalar to scale the box with</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(float scalar, Box box) { return Scale(scalar, ref box); }
		
		/// <summary>Scales the box using three different scalars</summary>
		/// <param name="widthScalar">The scalar to scale the width of the box</param>
		/// <param name="heightScalar">The scalar to scale the height of the box</param>
		/// <param name="depthScalar">The scalar to scale the depth of the box</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(float widthScalar, float heightScalar, float depthScalar, ref Box box, out Box result) {
			result.x = box.x;
			result.y = box.y;
			result.z = box.z;
			result.width = widthScalar * box.width;
			result.height = heightScalar * box.height;
			result.depth = depthScalar * box.depth;
		}
		
		/// <summary>Scales the box using three different scalars</summary>
		/// <param name="widthScalar">The scalar to scale the width of the box</param>
		/// <param name="heightScalar">The scalar to scale the height of the box</param>
		/// <param name="depthScalar">The scalar to scale the depth of the box</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(float widthScalar, float heightScalar, float depthScalar, Box box, out Box result) { Scale(widthScalar, heightScalar, depthScalar, ref box, out result); }
		
		/// <summary>Scales the box using three different scalars</summary>
		/// <param name="widthScalar">The scalar to scale the width of the box</param>
		/// <param name="heightScalar">The scalar to scale the height of the box</param>
		/// <param name="depthScalar">The scalar to scale the depth of the box</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(float widthScalar, float heightScalar, float depthScalar, ref Box box) {
			// Variables
			Box result;
			
			Scale(widthScalar, heightScalar, depthScalar, ref box, out result);
			
			return result;
		}
		
		/// <summary>Scales the box using three different scalars</summary>
		/// <param name="widthScalar">The scalar to scale the width of the box</param>
		/// <param name="heightScalar">The scalar to scale the height of the box</param>
		/// <param name="depthScalar">The scalar to scale the depth of the box</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(float widthScalar, float heightScalar, float depthScalar, Box box) { return Scale(widthScalar, heightScalar, depthScalar, ref box); }
		
		/// <summary>Scales the box using a 3D vector for three different scalars</summary>
		/// <param name="scalars">The vector that holds all the scalars</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(ref Vector3 scalars, ref Box box, out Box result) { Scale(scalars.x, scalars.y, scalars.z, ref box, out result); }
		
		/// <summary>Scales the box using a 3D vector for three different scalars</summary>
		/// <param name="scalars">The vector that holds all the scalars</param>
		/// <param name="box">The box to scale with</param>
		/// <param name="result">The resulting scaled box</param>
		public static void Scale(Vector3 scalars, Box box, out Box result) { Scale(ref scalars, ref box, out result); }
		
		/// <summary>Scales the box using a 3D vector for three different scalars</summary>
		/// <param name="scalars">The vector that holds all the scalars</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(ref Vector3 scalars, ref Box box) { return Scale(scalars.x, scalars.y, scalars.z, ref box); }
		
		/// <summary>Scales the box using a 3D vector for three different scalars</summary>
		/// <param name="scalars">The vector that holds all the scalars</param>
		/// <param name="box">The box to scale with</param>
		/// <returns>Returns the resulting scaled box</returns>
		public static Box Scale(Vector3 scalars, Box box) { return Scale(ref scalars, ref box); }
		
		#endregion // Scale Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Finds if the two boxes are overlapping</summary>
		/// <param name="other">The other box</param>
		/// <returns>Returns true if the two boxes are overlapping</returns>
		public bool IsOverlapping(Box other) { return IsOverlapping(ref this, ref other); }
		
		/// <summary>Finds if the other box is contained within this box</summary>
		/// <param name="other">The other box</param>
		/// <returns>Returns true if the other box is contained within this box</returns>
		public bool IsContained(Box other) { return IsContained(ref this, ref other); }
		
		/// <summary>Finds if the two boxes are disjoint</summary>
		/// <param name="other">The other box</param>
		/// <returns>Returns true if the two boxes are disjoint</returns>
		public bool IsDisjoint(Box other) { return IsDisjoint(ref this, ref other); }
		
		/// <summary>Finds if the two boxes are equal to each other</summary>
		/// <param name="other">The other box</param>
		/// <returns>Returns true if the two boxes are equal to each other</returns>
		public bool Equals(Box other) {
			return (
				this.x == other.x &&
				this.y == other.y &&
				this.z == other.z &&
				this.width == other.width &&
				this.height == other.height &&
				this.depth == other.depth
			);
		}
		
		/// <summary>Finds if the two boxes are equal to each other</summary>
		/// <param name="other">The other box</param>
		/// <returns>Returns true if the two boxes are equal to each other</returns>
		public override bool Equals(object other) {
			if(other == null) {
				return false;
			}
			if(other is Box) {
				return this.Equals((Box)other);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the box</summary>
		/// <returns>Returns the hah code from the box</returns>
		public override int GetHashCode() {
			return (
				(int)this.x ^ (int)this.y ^ (int)this.z ^
				(int)this.width ^ (int)this.height ^ (int)this.depth
			);
		}
		
		/// <summary>Gets the box in string form</summary>
		/// <returns>Returns the box in string form</returns>
		public override string ToString() {
			return (
				"{ x: " + this.x +
				", y: " + this.y +
				", z: " + this.z +
				", width: " + this.width +
				", height: " + this.height +
				", depth: " + this.depth + " }"
			);
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two boxes are equal to each other</summary>
		/// <param name="left">The left box</param>
		/// <param name="right">The right box</param>
		/// <returns>Returns true if the two boxes are equal to each other</returns>
		public static bool operator ==(Box left, Box right) { return left.Equals(right); }
		
		/// <summary>Finds if the two boxes are not equal to each other</summary>
		/// <param name="left">The left box</param>
		/// <param name="right">The right box</param>
		/// <returns>Returns true if the two boxes are not equal to each other</returns>
		public static bool operator !=(Box left, Box right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}


using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A 2D structure with and x-y coordinate, width, and height. Used to represent rectangular objects in 2D</summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct Rectangle : System.IEquatable<Rectangle> {
		#region Field Variables
		// Variables
		/// <summary>The x coordinate of the rectangle</summary>
		public float x;
		/// <summary>The y coordinate of the rectangle</summary>
		public float y;
		/// <summary>The width of the rectangle</summary>
		public float width;
		/// <summary>The height of the rectangle</summary>
		public float height;
		/// <summary>An empty rectangle (0, 0, 0, 0)</summary>
		public static readonly Rectangle Empty = new Rectangle(0.0f, 0.0f, 0.0f, 0.0f);
		/// <summary>A unit rectangle (0, 0, 1, 1)</summary>
		public static readonly Rectangle Unit = new Rectangle(0.0f, 0.0f, 1.0f, 1.0f);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the left most edge of the rectangle</summary>
		public float Left { get { return Mathx.Min(this.x, this.x + this.width); } }
		
		/// <summary>Gets the right most edge of the rectangle</summary>
		public float Right { get { return Mathx.Max(this.x, this.x + this.width); } }
		
		/// <summary>Gets the top most edge of the rectangle</summary>
		public float Top { get { return Mathx.Min(this.y, this.y + this.height); } }
		
		/// <summary>Gets the bottom most edge of the rectangle</summary>
		public float Bottom { get { return Mathx.Max(this.y, this.y + this.height); } }
		
		/// <summary>Gets the top left point of the rectangle</summary>
		public Vector2 TopLeft { get { return new Vector2(Left, Top); } }
		
		/// <summary>Gets the top right point of the rectangle</summary>
		public Vector2 TopRight { get { return new Vector2(Right, Top); } }
		
		/// <summary>Gets the bottom right point of the rectangle</summary>
		public Vector2 BottomRight { get { return new Vector2(Right, Bottom); } }
		
		/// <summary>Gets the bottom left point of the rectangle</summary>
		public Vector2 BottomLeft { get { return new Vector2(Left, Bottom);} }
		
		/// <summary>Gets and sets the position of the box</summary>
		public Vector2 Position { get { return new Vector2(this.x, this.y); } set {
			this.x = value.x;
			this.y = value.y;
		} }
		
		/// <summary>Gets and sets the size of the box</summary>
		public Vector2 Size { get { return new Vector2(this.width, this.height); } set {
			this.width = value.x;
			this.height = value.y;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a rectangle</summary>
		/// <param name="x">The x coordinate of the rectangle</param>
		/// <param name="y">The y coordinate of the rectangle</param>
		/// <param name="width">The width of the rectangle</param>
		/// <param name="height">The height of the rectangle</param>
		public Rectangle(float x, float y, float width, float height) {
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
		
		/// <summary>A constructor for create a rectangle</summary>
		/// <param name="position">The x-y coordinate of the rectangle</param>
		/// <param name="size">The width and height of the rectangle</param>
		public Rectangle(Vector2 position, Vector2 size) : this(position.x, position.y, size.x, size.y) {}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Encompass Methods
		
		/// <summary>Creates an encompassing rectangle from the two given rectangles</summary>
		/// <param name="a">The first rectangle encompass</param>
		/// <param name="b">The second rectangle encompass</param>
		/// <param name="result">The resulting rectangle the encompasses the two rectangles</param>
		public static void Encompass(ref Rectangle a, ref Rectangle b, out Rectangle result) {
			// Variables
			float axw = a.x + a.width;
			float ayh = a.y + a.height;
			float bxw = b.x + b.width;
			float byh = b.y + b.height;
			
			Mathx.MinMaxRange(
				out result.x, out result.width,
				a.x, b.x,
				a.x + a.width, b.x + b.width
			);
			Mathx.MinMaxRange(
				out result.y, out result.height,
				a.y, b.y,
				a.y + a.height, b.y + b.height
			);
			result.width -= result.x;
			result.height -= result.y;
		}
		
		/// <summary>Creates an encompassing rectangle from the two given rectangles</summary>
		/// <param name="a">The first rectangle encompass</param>
		/// <param name="b">The second rectangle encompass</param>
		/// <param name="result">The resulting rectangle the encompasses the two rectangles</param>
		public static void Encompass(Rectangle a, Rectangle b, out Rectangle result) { Encompass(ref a, ref b, out result); }
		
		/// <summary>Creates an encompassing rectangle from the two given rectangles</summary>
		/// <param name="a">The first rectangle encompass</param>
		/// <param name="b">The second rectangle encompass</param>
		/// <returns>Returns the resulting rectangle the encompasses the two rectangles</returns>
		public static Rectangle Encompass(ref Rectangle a, ref Rectangle b) {
			// Variables
			Rectangle result;
			
			Encompass(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Creates an encompassing rectangle from the two given rectangles</summary>
		/// <param name="a">The first rectangle encompass</param>
		/// <param name="b">The second rectangle encompass</param>
		/// <returns>Returns the resulting rectangle the encompasses the two rectangles</returns>
		public static Rectangle Encompass(Rectangle a, Rectangle b) { return Encompass(ref a, ref b); }
		
		/// <summary>Creates an encompassing rectangle from the array of rectangles</summary>
		/// <param name="result">The resulting rectangle that encompasses the array of rectangles</param>
		/// <param name="rectangles">The array of rectangles to encompass</param>
		public static void EncompassRange(out Rectangle result, params Rectangle[] rectangles) {
			if(rectangles.Length == 0) {
				result = Empty;
				return;
			}
			result = rectangles[0];
			
			for(int i = 1; i < rectangles.Length; i++) {
				Encompass(ref result, ref rectangles[i], out result);
			}
		}
		
		/// <summary>Creates an encompassing rectangle from the array of rectangles</summary>
		/// <param name="rectangles">The array of rectangles to encompass</param>
		/// <returns>Returns the resulting rectangle that encompasses the array of rectangles</returns>
		public static Rectangle EncompassRange(params Rectangle[] rectangles) {
			// Variables
			Rectangle result;
			
			EncompassRange(out result, rectangles);
			
			return result;
		}
		
		#endregion // Encompass Methods
		
		#region IsOverlapping Methods
		
		/// <summary>Finds if the two rectangles are overlapping</summary>
		/// <param name="a">The first rectangle to find is overlapping</param>
		/// <param name="b">The second rectangle to find is overlapping</param>
		/// <returns>Returns true if the rectangles are overlapping</returns>
		public static bool IsOverlapping(ref Rectangle a, ref Rectangle b) {
			// Variables
			float ax, ay, aw, ah;
			float bx, by, bw, bh;
			
			Mathx.MinMax(a.x, a.x + a.width, out ax, out aw);
			Mathx.MinMax(a.y, a.y + a.height, out ay, out ah);
			Mathx.MinMax(b.x, b.x + b.width, out bx, out bw);
			Mathx.MinMax(b.y, b.y + b.height, out by, out bh);
			
			return (
				(aw >= bx && ax <= bw) &&
				(ah >= by && ay <= bh)
			);
		}
		
		/// <summary>Finds if the two rectangles are overlapping</summary>
		/// <param name="a">The first rectangle to find is overlapping</param>
		/// <param name="b">The second rectangle to find is overlapping</param>
		/// <returns>Returns true if the rectangles are overlapping</returns>
		public static bool IsOverlapping(Rectangle a, Rectangle b) { return IsOverlapping(ref a, ref b); }
		
		#endregion // IsOverlapping Methods
		
		#region IsContained Methods
		
		/// <summary>Finds if the second rectangle is contained within the first rectangle</summary>
		/// <param name="outside">The first rectangle to find if it's contained the other rectangle within</param>
		/// <param name="inside">The second rectangle to find if it's contained within the other rectangle</param>
		/// <returns>Returns true if the second rectangle is contained within the first rectangle</returns>
		public static bool IsContained(ref Rectangle outside, ref Rectangle inside) {
			// Variables
			float ax, ay, aw, ah;
			float bx, by, bw, bh;
			
			Mathx.MinMax(outside.x, outside.x + outside.width, out ax, out aw);
			Mathx.MinMax(outside.y, outside.y + outside.height, out ay, out ah);
			Mathx.MinMax(inside.x, inside.x + inside.width, out bx, out bw);
			Mathx.MinMax(inside.y, inside.y + inside.height, out by, out bh);
			
			return (
				(bx >= ax && bw <= aw) &&
				(by >= ay && bh <= ah)
			);
		}
		
		/// <summary>Finds if the second rectangle is contained within the first rectangle</summary>
		/// <param name="outside">The first rectangle to find if it's contained the other rectangle within</param>
		/// <param name="inside">The second rectangle to find if it's contained within the other rectangle</param>
		/// <returns>Returns true if the second rectangle is contained within the first rectangle</returns>
		public static bool IsContained(Rectangle outside, Rectangle inside) { return IsContained(ref outside, ref inside); }
		
		#endregion // IsContained Methods
		
		#region IsDisjoint Methods
		
		/// <summary>Finds if the two rectangles are disjoint from each other</summary>
		/// <param name="a">The first rectangle to find disjoint from the other</param>
		/// <param name="b">The second rectangle to find disjoint from the other</param>
		/// <returns>Returns true if the rectangles are disjoint from each other</returns>
		public static bool IsDisjoint(ref Rectangle a, ref Rectangle b) {
			// Variables
			float ax, ay, aw, ah;
			float bx, by, bw, bh;
			
			Mathx.MinMax(a.x, a.x + a.width, out ax, out aw);
			Mathx.MinMax(a.y, a.y + a.height, out ay, out ah);
			Mathx.MinMax(b.x, b.x + b.width, out bx, out bw);
			Mathx.MinMax(b.y, b.y + b.height, out by, out bh);
			
			return (
				(ax > bw || aw < bx) ||
				(ay > bh || ah < by)
			);
		}
		
		/// <summary>Finds if the two rectangles are disjoint from each other</summary>
		/// <param name="a">The first rectangle to find disjoint from the other</param>
		/// <param name="b">The second rectangle to find disjoint from the other</param>
		/// <returns>Returns true if the rectangles are disjoint from each other</returns>
		public static bool IsDisjoint(Rectangle a, Rectangle b) { return IsDisjoint(ref a, ref b); }
		
		#endregion // IsDisjoint Methods
		
		#region Clip Methods
		
		/// <summary>Clips the second rectangle using the first rectangle, resulting in a rectangle that fits within the first rectangle</summary>
		/// <param name="outside">The outside rectangle used for clipping</param>
		/// <param name="inside">The inside rectangle to get clipped</param>
		/// <param name="result">The resulting clipped rectangle that can fit in the first rectangle</param>
		public static void Clip(ref Rectangle outside, ref Rectangle inside, out Rectangle result) {
			// Variables
			float ax, ay, aw, ah;
			float bx, by, bw, bh;
			
			Mathx.MinMax(outside.x, outside.x + outside.width, out ax, out aw);
			Mathx.MinMax(outside.y, outside.y + outside.height, out ay, out ah);
			Mathx.MinMax(inside.x, inside.x + inside.width, out bx, out bw);
			Mathx.MinMax(inside.y, inside.y + inside.height, out by, out bh);
			
			result.x = Mathx.Clamp(bx, ax, aw);
			result.y = Mathx.Clamp(by, ay, ah);
			result.width = Mathx.Max(Mathx.Min(aw, bw) - result.x, 0.0f);
			result.height = Mathx.Max(Mathx.Min(ah, bh) - result.y, 0.0f);
		}
		
		/// <summary>Clips the second rectangle using the first rectangle, resulting in a rectangle that fits within the first rectangle</summary>
		/// <param name="outside">The outside rectangle used for clipping</param>
		/// <param name="inside">The inside rectangle to get clipped</param>
		/// <param name="result">The resulting clipped rectangle that can fit in the first rectangle</param>
		public static void Clip(Rectangle outside, Rectangle inside, out Rectangle result) { Clip(ref outside, ref inside, out result); }
		
		/// <summary>Clips the second rectangle using the first rectangle, resulting in a rectangle that fits within the first rectangle</summary>
		/// <param name="outside">The outside rectangle used for clipping</param>
		/// <param name="inside">The inside rectangle to get clipped</param>
		/// <returns>Returns the clipped rectangle that can fit in the first rectangle</returns>
		public static Rectangle Clip(ref Rectangle outside, ref Rectangle inside) {
			// Variables
			Rectangle result;
			
			Clip(ref outside, ref inside, out result);
			
			return result;
		}
		
		/// <summary>Clips the second rectangle using the first rectangle, resulting in a rectangle that fits within the first rectangle</summary>
		/// <param name="outside">The outside rectangle used for clipping</param>
		/// <param name="inside">The inside rectangle to get clipped</param>
		/// <returns>Returns the clipped rectangle that can fit in the first rectangle</returns>
		public static Rectangle Clip(Rectangle outside, Rectangle inside) { return Clip(ref outside, ref inside); }
		
		#endregion // Clip Methods
		
		#region Scale Methods
		
		/// <summary>Scales the rectangle's width and height using the single scalar</summary>
		/// <param name="scalar">The scalar used to scale the rectangle uniformly with</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(float scalar, ref Rectangle rect, out Rectangle result) {
			result.x = rect.x;
			result.y = rect.y;
			result.width = scalar * rect.width;
			result.height = scalar * rect.height;
		}
		
		/// <summary>Scales the rectangle's width and height using the single scalar</summary>
		/// <param name="scalar">The scalar used to scale the rectangle uniformly with</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(float scalar, Rectangle rect, out Rectangle result) { Scale(scalar, ref rect, out result); }
		
		/// <summary>Scales the rectangle's width and height using the single scalar</summary>
		/// <param name="scalar">The scalar used to scale the rectangle uniformly with</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(float scalar, ref Rectangle rect) {
			// Variables
			Rectangle result;
			
			Scale(scalar, ref rect, out result);
			
			return result;
		}
		
		/// <summary>Scales the rectangle's width and height using the single scalar</summary>
		/// <param name="scalar">The scalar used to scale the rectangle uniformly with</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(float scalar, Rectangle rect) { return Scale(scalar, ref rect); }
		
		/// <summary>Scales the rectangle's width and height using two scalars</summary>
		/// <param name="widthScalar">The scalar used to scale the rectangle's width</param>
		/// <param name="heightScalar">The scalar used to scale the rectangle's height</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(float widthScalar, float heightScalar, ref Rectangle rect, out Rectangle result) {
			result.x = rect.x;
			result.y = rect.y;
			result.width = widthScalar * rect.width;
			result.height = heightScalar * rect.height;
		}
		
		/// <summary>Scales the rectangle's width and height using two scalars</summary>
		/// <param name="widthScalar">The scalar used to scale the rectangle's width</param>
		/// <param name="heightScalar">The scalar used to scale the rectangle's height</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(float widthScalar, float heightScalar, Rectangle rect, out Rectangle result) { Scale(widthScalar, heightScalar, ref rect, out result); }
		
		/// <summary>Scales the rectangle's width and height using two scalars</summary>
		/// <param name="widthScalar">The scalar used to scale the rectangle's width</param>
		/// <param name="heightScalar">The scalar used to scale the rectangle's height</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(float widthScalar, float heightScalar, ref Rectangle rect) {
			// Variables
			Rectangle result;
			
			Scale(widthScalar, heightScalar, ref rect, out result);
			
			return result;
		}
		
		/// <summary>Scales the rectangle's width and height using two scalars</summary>
		/// <param name="widthScalar">The scalar used to scale the rectangle's width</param>
		/// <param name="heightScalar">The scalar used to scale the rectangle's height</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(float widthScalar, float heightScalar, Rectangle rect) { return Scale(widthScalar, heightScalar, ref rect); }
		
		/// <summary>Scales the rectangle's width and height using two scalars in vector form</summary>
		/// <param name="scalars">The vector used to scale the rectangle's width and height seperately</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(ref Vector2 scalars, ref Rectangle rect, out Rectangle result) { Scale(scalars.x, scalars.y, ref rect, out result); }
		
		/// <summary>Scales the rectangle's width and height using two scalars in vector form</summary>
		/// <param name="scalars">The vector used to scale the rectangle's width and height seperately</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <param name="result">The resulting scaled rectangle</param>
		public static void Scale(Vector2 scalars, Rectangle rect, out Rectangle result) { Scale(ref scalars, ref rect, out result); }
		
		/// <summary>Scales the rectangle's width and height using two scalars in vector form</summary>
		/// <param name="scalars">The vector used to scale the rectangle's width and height seperately</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(ref Vector2 scalars, ref Rectangle rect) { return Scale(scalars.x, scalars.y, ref rect); }
		
		/// <summary>Scales the rectangle's width and height using two scalars in vector form</summary>
		/// <param name="scalars">The vector used to scale the rectangle's width and height seperately</param>
		/// <param name="rect">The rectangle to scale with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public static Rectangle Scale(Vector2 scalars, Rectangle rect) { return Scale(ref scalars, ref rect); }
		
		#endregion // Scale Methods
		
		#region ParallelScale Methods
		
		/// <summary>Parallel scales the rectangle to mimic how an inside rectangle is scaled within an outside rectangle</summary>
		/// <param name="outside">The outside rectangle that has an inside rectangle</param>
		/// <param name="inside">The inside rectangle that sits inside the outside rectangle</param>
		/// <param name="parallelOutside">The parallel rectangle that is used to be scaled</param>
		/// <param name="result">The resulting rectangle that has been parallel scaled to mimic the scale of the outside and inside rectangles</param>
		/// <remarks>
		/// This is mainly used text rendering. Where clipping happens, the texture coordinate rectangle must also be clipped in the same exact way.
		/// A good way of clipping the texture coordinate (which is on a different location and scale) is by parallel scaling the rectangle with
		/// the clipped (inside) and unclipped (outside) rectangles
		/// </remarks>
		public static void ParallelScale(ref Rectangle outside, ref Rectangle inside, ref Rectangle parallelOutside, out Rectangle result) {
			// Variables
			float max;
			float scaleX, scaleY, scaleW, scaleH;
			
			max = outside.Right - outside.Left;
			scaleX = Mathx.Clamp((inside.Left - outside.Left) / max, 0.0f, 1.0f);
			scaleW = Mathx.Clamp((inside.Right - outside.Left) / max, 0.0f, 1.0f);
			max = outside.Bottom - outside.Top;
			scaleY = Mathx.Clamp((inside.Top - outside.Top) / max, 0.0f, 1.0f);
			scaleH = Mathx.Clamp((inside.Bottom - outside.Top) / max, 0.0f, 1.0f);
			
			result.x = parallelOutside.x;
			result.y = parallelOutside.y;
			result.width = parallelOutside.width;
			result.height = parallelOutside.height;
			
			if(scaleX > 0.0f) {
				result.x += scaleX * result.width;
				result.width -= scaleX * result.width;
			}
			if(scaleY > 0.0f) {
				result.y += scaleY * result.height;
				result.height -= scaleY * result.height;
			}
			result.width *= scaleW;
			result.height *= scaleH;
		}
		
		/// <summary>Parallel scales the rectangle to mimic how an inside rectangle is scaled within an outside rectangle</summary>
		/// <param name="outside">The outside rectangle that has an inside rectangle</param>
		/// <param name="inside">The inside rectangle that sits inside the outside rectangle</param>
		/// <param name="parallelOutside">The parallel rectangle that is used to be scaled</param>
		/// <param name="result">The resulting rectangle that has been parallel scaled to mimic the scale of the outside and inside rectangles</param>
		/// <remarks>
		/// This is mainly used text rendering. Where clipping happens, the texture coordinate rectangle must also be clipped in the same exact way.
		/// A good way of clipping the texture coordinate (which is on a different location and scale) is by parallel scaling the rectangle with
		/// the clipped (inside) and unclipped (outside) rectangles
		/// </remarks>
		public static void ParallelScale(Rectangle outside, Rectangle inside, Rectangle parallelOutside, out Rectangle result) { ParallelScale(ref outside, ref inside, ref parallelOutside, out result); }
		
		/// <summary>Parallel scales the rectangle to mimic how an inside rectangle is scaled within an outside rectangle</summary>
		/// <param name="outside">The outside rectangle that has an inside rectangle</param>
		/// <param name="inside">The inside rectangle that sits inside the outside rectangle</param>
		/// <param name="parallelOutside">The parallel rectangle that is used to be scaled</param>
		/// <returns>Returns the resulting rectangle that has been parallel scaled to mimic the scale of the outside and inside rectangles</returns>
		/// <remarks>
		/// This is mainly used text rendering. Where clipping happens, the texture coordinate rectangle must also be clipped in the same exact way.
		/// A good way of clipping the texture coordinate (which is on a different location and scale) is by parallel scaling the rectangle with
		/// the clipped (inside) and unclipped (outside) rectangles
		/// </remarks>
		public static Rectangle ParallelScale(ref Rectangle outside, ref Rectangle inside, ref Rectangle parallelOutside) {
			// Variables
			Rectangle result;
			
			ParallelScale(ref outside, ref inside, ref parallelOutside, out result);
			
			return result;
		}
		
		/// <summary>Parallel scales the rectangle to mimic how an inside rectangle is scaled within an outside rectangle</summary>
		/// <param name="outside">The outside rectangle that has an inside rectangle</param>
		/// <param name="inside">The inside rectangle that sits inside the outside rectangle</param>
		/// <param name="parallelOutside">The parallel rectangle that is used to be scaled</param>
		/// <returns>Returns the resulting rectangle that has been parallel scaled to mimic the scale of the outside and inside rectangles</returns>
		/// <remarks>
		/// This is mainly used text rendering. Where clipping happens, the texture coordinate rectangle must also be clipped in the same exact way.
		/// A good way of clipping the texture coordinate (which is on a different location and scale) is by parallel scaling the rectangle with
		/// the clipped (inside) and unclipped (outside) rectangles
		/// </remarks>
		public static Rectangle ParallelScale(Rectangle outside, Rectangle inside, Rectangle parallelOutside) { return ParallelScale(ref outside, ref inside, ref parallelOutside); }
		
		#endregion // ParallelScale Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Finds if the this and the other rectangles are overlapping</summary>
		/// <param name="other">The other rectangle to find is overlapping</param>
		/// <returns>Returns true if the rectangles are overlapping</returns>
		public bool IsOverlapping(Rectangle other) { return IsOverlapping(ref this, ref other); }
		
		/// <summary>Finds if the other rectangle is contained within this rectangle</summary>
		/// <param name="other">The rectangle to find if it's contained within this rectangle</param>
		/// <returns>Returns true if the other rectangle is contained within this rectangle</returns>
		public bool IsContained(Rectangle other) { return IsContained(ref this, ref other); }
		
		/// <summary>Finds if this rectangle and the other rectangle are disjoint from each other</summary>
		/// <param name="other">The other rectangle to find disjoint from this one</param>
		/// <returns>Returns true if the rectangles are disjoint from each other</returns>
		public bool IsDisjoint(Rectangle other) { return IsDisjoint(ref this, ref other); }
		
		/// <summary>Clips the other rectangle using this rectangle, resulting in a rectangle that fits within this rectangle</summary>
		/// <param name="other">The other rectangle to get clipped</param>
		/// <returns>Returns the clipped rectangle that can fit in this rectangle</returns>
		public Rectangle Clip(Rectangle other) { return Clip(ref this, ref other); }
		
		/// <summary>Scales the rectangle's width and height using the single scalar</summary>
		/// <param name="scalar">The scalar used to scale the rectangle uniformly with</param>
		/// <returns>Returns the scaled rectangle</returns>
		public Rectangle Scale(float scalar) { return Scale(scalar, ref this); }
		
		/// <summary>Scales the rectangle's width and height using two scalars</summary>
		/// <param name="widthScalar">The scalar used to scale the rectangle's width</param>
		/// <param name="heightScalar">The scalar used to scale the rectangle's height</param>
		/// <returns>Returns the scaled rectangle</returns>
		public Rectangle Scale(float widthScalar, float heightScalar) { return Scale(widthScalar, heightScalar, ref this); }
		
		/// <summary>Scales the rectangle's width and height using two scalars in vector form</summary>
		/// <param name="scalars">The vector used to scale the rectangle's width and height seperately</param>
		/// <returns>Returns the scaled rectangle</returns>
		public Rectangle Scale(Vector2 scalars) { return Scale(ref scalars, ref this); }
		
		/// <summary>Finds if this rectangle and the other rectangle are equal</summary>
		/// <param name="other">The other rectangle to find if it's equal</param>
		/// <returns>Returns true if the rectangles are equal to each other</returns>
		public bool Equals(Rectangle other) {
			return (
				this.x == other.x &&
				this.y == other.y &&
				this.width == other.width &&
				this.height == other.height
			);
		}
		
		/// <summary>Finds if this rectangle and the other rectangle are equal</summary>
		/// <param name="obj">The other rectangle to find if it's equal</param>
		/// <returns>Returns true if the rectangles are equal to each other</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Rectangle) {
				return this.Equals((Rectangle)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hash code of the rectangle</summary>
		/// <returns>Returns the hash code</returns>
		public override int GetHashCode() {
			return (int)this.x ^ (int)this.y ^ (int)this.width ^ (int)this.height;
		}
		
		/// <summary>Gets the rectangle in string form</summary>
		/// <returns>Returns the rectangle in string form</returns>
		public override string ToString() {
			return (
				"{ x: " + this.x +
				", y: " + this.y +
				", width: " + this.width +
				", height: " + this.height + " }"
			);
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two rectangles are equal to each other</summary>
		/// <param name="left">The first rectangle</param>
		/// <param name="right">The second rectangle</param>
		/// <returns>Returns true if the rectangles are equal to each other</returns>
		public static bool operator ==(Rectangle left, Rectangle right) { return left.Equals(right); }
		
		/// <summary>Finds if the two rectangles are not equal to each other</summary>
		/// <param name="left">The first rectangle</param>
		/// <param name="right">The second rectangle</param>
		/// <returns>Returns true if the rectangles are not equal to each other</returns>
		public static bool operator !=(Rectangle left, Rectangle right) { return !left.Equals(right); }
		
		#endregion // Operators
	}
}


using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Rectangle"/> structure to make sure it works correctly. Contains 50 tests</summary>
	public class RectangleTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Rectangle(float, float, float, float)"/> functionality.
		/// Creates a rectangle and checks if its constructed correctly
		/// </summary>
		[Fact]
		public void Constructor_DefaultRectangle_Returns1Negative2Negative34Rectangle() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			(float, float, float, float) expected = (1, -2, -3, 4);
			(float, float, float, float) actual = (
				rect.x,
				rect.y,
				rect.width,
				rect.height
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Unit"/> functionality.
		/// Creates a unit rectangle and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Unit_Returns0011Rectangle() {
			// Variables
			Rectangle rect = Rectangle.Unit;
			(float, float, float, float) expected = (0, 0, 1, 1);
			(float, float, float, float) actual = (
				rect.x,
				rect.y,
				rect.width,
				rect.height
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Empty"/> functionality.
		/// Creates an empty rectangle and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Empty_Returns0000Rectangle() {
			// Variables
			Rectangle rect = Rectangle.Empty;
			(float, float, float, float) expected = (0, 0, 0, 0);
			(float, float, float, float) actual = (
				rect.x,
				rect.y,
				rect.width,
				rect.height
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Position"/> functionality.
		/// Creates a rectangle and checks to see if the position is correct
		/// </summary>
		[Fact]
		public void Position_DefaultRectangle_Returns1Negative2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(1, -2);
			Vector2 actual = rect.Position;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Size"/> functionality.
		/// Creates a rectangle and checks to see if the size is correct
		/// </summary>
		[Fact]
		public void Size_DefaultRectangle_ReturnsNegative34() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(-3, 4);
			Vector2 actual = rect.Size;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Left"/> functionality.
		/// Creates a rectangle and checks to see if the left-most part is correct
		/// </summary>
		[Fact]
		public void Left_DefaultRectangle_ReturnsNegative2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			float expected = -2.0f;
			float actual = rect.Left;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Right"/> functionality.
		/// Creates a rectangle and checks to see if the right-most part is correct
		/// </summary>
		[Fact]
		public void Right_DefaultRectangle_Returns1() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			float expected = 1.0f;
			float actual = rect.Right;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Top"/> functionality.
		/// Creates a rectangle and checks to see if the top-most part is correct
		/// </summary>
		[Fact]
		public void Top_DefaultRectangle_ReturnsNegative2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			float expected = -2.0f;
			float actual = rect.Top;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Bottom"/> functionality.
		/// Creates a rectangle and checks to see if the bottom-most part is correct
		/// </summary>
		[Fact]
		public void Bottom_DefaultRectangle_Returns2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			float expected = 2.0f;
			float actual = rect.Bottom;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.TopLeft"/> functionality.
		/// Creates a rectangle and checks to see if the top-left-most part is correct
		/// </summary>
		[Fact]
		public void TopLeft_DefaultRectangle_ReturnsVector2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(-2, -2);
			Vector2 actual = rect.TopLeft;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.TopRight"/> functionality.
		/// Creates a rectangle and checks to see if the top-right-most part is correct
		/// </summary>
		[Fact]
		public void TopRight_DefaultRectangle_ReturnsVector2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(1, -2);
			Vector2 actual = rect.TopRight;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.BottomLeft"/> functionality.
		/// Creates a rectangle and checks to see if the bottom-left-most part is correct
		/// </summary>
		[Fact]
		public void BottomLeft_DefaultRectangle_ReturnsVector2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(-2, 2);
			Vector2 actual = rect.BottomLeft;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.BottomRight"/> functionality.
		/// Creates a rectangle and checks to see if the bottom-right-most part is correct
		/// </summary>
		[Fact]
		public void BottomRight_DefaultRectangle_ReturnsVector2() {
			// Variables
			Rectangle rect = this.CreateDefaultRectangle();
			Vector2 expected = new Vector2(1, 2);
			Vector2 actual = rect.BottomRight;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Encompass(Rectangle, Rectangle)"/> functionality.
		/// Encompasses two rectangles and checks to see if it's correct
		/// </summary>
		[Theory]
		#region Encompass_TwoRectangles_ReturnsRectangle Test Data
		[InlineData(
			10, 15, 15, 15,
			15, 10, 15, 15,
			10, 10, 20, 20
		)]
		[InlineData(
			10, 10, -10, 10,
			10, 10, 20, 20,
			0, 10, 30, 20
		)]
		#endregion // Encompass_TwoRectangles_ReturnsRectangle Test Data
		public void Encompass_TwoRectangles_ReturnsRectangle(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh,
			float ex, float ey, float ew, float eh
		) {
			// Variables
			Rectangle expected = new Rectangle(ex, ey, ew, eh);
			Rectangle actual = new Rectangle(ax, ay, aw, ah);
			Rectangle other = new Rectangle(bx, by, bw, bh);
			
			Rectangle.Encompass(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.EncompassRange(Rectangle[])"/> functionality.
		/// Encompasses three rectangles and checks to see if it's correct
		/// </summary>
		[Theory]
		#region EncompassRange_ThreeRectangles_ReturnsRectangle Test Data
		[InlineData(
			10, 15, 15, 15,
			15, 10, 15, 15,
			10, 20, -10, -20,
			0, 0, 30, 30
		)]
		[InlineData(
			10, 10, -10, 10,
			10, 10, 20, 20,
			15, 15, 5, 5,
			0, 10, 30, 20
		)]
		#endregion // EncompassRange_ThreeRectangles_ReturnsRectangle Test Data
		public void EncompassRange_ThreeRectangles_ReturnsRectangle(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh,
			float cx, float cy, float cw, float ch,
			float ex, float ey, float ew, float eh
		) {
			// Variables
			Rectangle expected = new Rectangle(ex, ey, ew, eh);
			Rectangle actual = new Rectangle(ax, ay, aw, ah);
			Rectangle other = new Rectangle(bx, by, bw, bh);
			Rectangle another = new Rectangle(cx, cy, cw, ch);
			
			Rectangle.EncompassRange(out actual, actual, other, another);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.IsOverlapping(Rectangle)"/> functionality.
		/// Checks to see if two rectangles are overlapping or not
		/// </summary>
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, true)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, true)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, true)]
		public void IsOverlapping_TwoRectangles_ReturnsBoolean(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh, bool expected
		) {
			// Variables
			Rectangle first = new Rectangle(ax, ay, aw, ah);
			Rectangle second = new Rectangle(bx, by, bw, bh);
			bool actual = first.IsOverlapping(second);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.IsContained(Rectangle)"/> functionality.
		/// Checks to see if two rectangles are contained or not
		/// </summary>
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, false)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, false)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, false)]
		[InlineData(25, 25, 100, 100, 50, 50, 50, 50, true)]
		[InlineData(50, 50, 50, 50, 50, 50, 50, 50, true)]
		[InlineData(50, 50, 50, 50, 50, 50, 25, 25, true)]
		public void IsContained_TwoRectangles_ReturnsBoolean(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh, bool expected
		) {
			// Variables
			Rectangle first = new Rectangle(ax, ay, aw, ah);
			Rectangle second = new Rectangle(bx, by, bw, bh);
			bool actual = first.IsContained(second);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.IsDisjoint(Rectangle)"/> functionality.
		/// Checks if two rectangles are disjoint or not
		/// </summary>
		[Theory]
		[InlineData(50, 50, 50, 50, 25, 25, 25, 25, false)]
		[InlineData(50, 50, 50, 50, 0, 25, 45, 45, true)]
		[InlineData(50, 50, 50, 50, 125, 125, -45, -45, false)]
		[InlineData(50, 50, 50, 50, 125, 125, 45, 45, true)]
		[InlineData(50, 50, 50, 50, 25, 25, 100, 100, false)]
		public void IsDisjoint_TwoRectangles_ReturnsBoolean(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh, bool expected
		) {
			// Variables
			Rectangle first = new Rectangle(ax, ay, aw, ah);
			Rectangle second = new Rectangle(bx, by, bw, bh);
			bool actual = first.IsDisjoint(second);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Clip(Rectangle)"/> functionality.
		/// Clips the rectangle using another rectangle and checks if it's correct
		/// </summary>
		[Theory]
		#region Clip_TwoRectangles_ReturnsRectangle Test Data
		[InlineData(
			50, 50, 50, 50,
			25, 25, 25, 25,
			50, 50, 0, 0
		)]
		[InlineData(
			50, 50, 50, 50,
			0, 25, 45, 45,
			50, 50, 0, 20
		)]
		[InlineData(
			50, 50, 50, 50,
			125, 125, -45, -45,
			80, 80, 20, 20
		)]
		[InlineData(
			50, 50, 50, 50,
			125, 125, 45, 45,
			100, 100, 0, 0
		)]
		[InlineData(
			50, 50, 50, 50,
			25, 25, 100, 100,
			50, 50, 50, 50
		)]
		[InlineData(
			25, 25, 100, 100,
			50, 50, 50, 50,
			50, 50, 50, 50
		)]
		[InlineData(
			50, 50, 50, 50,
			50, 50, 50, 50,
			50, 50, 50, 50
		)]
		[InlineData(
			50, 50, 50, 50,
			50, 50, 25, 25,
			50, 50, 25, 25
		)]
		[InlineData(
			50, 50, 0, 0,
			25, 25, 100, 100,
			50, 50, 0, 0
		)]
		[InlineData(
			0, 0, 0, 0,
			25, 25, 25, 25,
			0, 0, 0, 0
		)]
		#endregion // Clip_TwoRectangles_ReturnsRectangle Test Data
		public void Clip_TwoRectangles_ReturnsRectangle(
			float ax, float ay, float aw, float ah,
			float bx, float by, float bw, float bh,
			float ex, float ey, float ew, float eh
		) {
			// Variables
			Rectangle expected = new Rectangle(ex, ey, ew, eh);
			Rectangle actual = new Rectangle(ax, ay, aw, ah);
			Rectangle other = new Rectangle(bx, by, bw, bh);
			
			Rectangle.Clip(ref actual, ref other, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Scale(float)"/> functionality.
		/// Scales the rectangle with a single scalar and checks if it's correct
		/// </summary>
		[Theory]
		[InlineData(0.5f, 50, 50, 50, 50, 50, 50, 25, 25)]
		[InlineData(2, 50, 50, 50, 50, 50, 50, 100, 100)]
		public void Scale_SingleScalar_ReturnsRectangle(
			float scalar, float ax, float ay, float aw, float ah,
			float ex, float ey, float ew, float eh
		) {
			// Variables
			Rectangle expected = new Rectangle(ex, ey, ew, eh);
			Rectangle actual = new Rectangle(ax, ay, aw, ah);
			
			Rectangle.Scale(scalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.Scale(float, float)"/> functionality.
		/// Scales the rectangle with two scalars and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(2, 2, 50, 50, 50, 50, 50, 50, 100, 100)]
		[InlineData(0.5, 2, 0, 0, 100, 100, 0, 0, 50, 200)]
		public void Scale_TwoScalars_ReturnsRectangle(
			float widthScalar, float heightScalar, float ax, float ay, float aw, float ah,
			float ex, float ey, float ew, float eh
		) {
			// Variables
			Rectangle expected = new Rectangle(ex, ey, ew, eh);
			Rectangle actual = new Rectangle(ax, ay, aw, ah);
			
			Rectangle.Scale(widthScalar, heightScalar, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Rectangle.ParallelScale(Rectangle, Rectangle, Rectangle)"/> functionality.
		/// Scales the the third rectangle along with how the first two rectangles are scaling and checks to see if it's correct
		/// </summary>
		[Fact]
		public void ParallelScale_OutsideInsideParallelOutsideRectangles_ReturnsParallelInsideRectangle() {
			// Variables
			Rectangle expected = new Rectangle(0, 0, 50, 50);
			Rectangle outside = new Rectangle(10, 10, 50, 50);
			Rectangle inside = new Rectangle(10, 10, 25, 25);
			Rectangle actual = new Rectangle(0, 0, 100, 100);
			
			Rectangle.ParallelScale(ref outside, ref inside, ref actual, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
		
		#region Private Methods
		
		private Rectangle CreateDefaultRectangle() { return new Rectangle(1, -2, -3, 4); }
		
		#endregion // Private Methods
	}
}

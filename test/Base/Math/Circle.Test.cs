
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Circle"/> structure to make sure it works correctly. Contains 28 tests</summary>
	public class CircleTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.Unit"/> functionality.
		/// Creates a unit circle and checks to see if its correct
		/// </summary>
		[Fact]
		public void Unit_ReturnsCircle() {
			// Variables
			Circle circle = Circle.Unit;
			(float, float, float) expected = (0.0f, 0.0f, 1.0f);
			(float, float, float) actual = (
				circle.X,
				circle.Y,
				circle.radius
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.Empty"/> functionality.
		/// Creates an empty circle and checks to see if its correct
		/// </summary>
		[Fact]
		public void Empty_ReturnsCircle() {
			// Variables
			Circle circle = Circle.Empty;
			(float, float, float) expected = (0.0f, 0.0f, 0.0f);
			(float, float, float) actual = (
				circle.X,
				circle.Y,
				circle.radius
			);
			
			Assert.Equal(expected, actual);
		}
		
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.Encompass(Circle, Circle)"/> functionality.
		/// Creates a circle that encompasses two circles and checks to see if its correct
		/// </summary>
		[Theory]
		#region Encompass_TwoCircles_ReturnsCircle Test Data
		[InlineData(
			-1, 1, 5,
			5, -2, -1,
			0.21114588 , 0.39442706, 6.3541026
		)]
		[InlineData(
			-1, 1, 5,
			0, 1, 7,
			0, 1, 7
		)]
		[InlineData(
			-3, 0, 5,
			0, 5, -3,
			-2.0144958, 1.6425071, 6.9154763
		)]
		[InlineData(
			-3, 0, 0.5,
			0, 0, 3,
			-0.25, 0, 3.25
		)]
		#endregion // Encompass_TwoCircles_ReturnsCircle Test Data
		public void Encompass_TwoCircles_ReturnsCircle(
			float ax, float ay, float ar,
			float bx, float by, float br,
			float ex, float ey, float er
		) {
			// Variables
			Circle actual = new Circle(ax, ay, ar);
			Circle b = new Circle(bx, by, br);
			Circle expected = new Circle(ex, ey, er);
			// TODO: Add a.Encompass(b) method
			
			Circle.Encompass(ref actual, ref b, out actual);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.EncompassRange(Circle[])"/> functionality.
		/// Creates a circle that encompasses multiple circles and checks to see if its correct
		/// </summary>
		[Theory]
		#region EncompassRange_ThreeCircles_ReturnsCircle Test Data
		[InlineData(
			0, 3, 0.5,
			0, 0, 3,
			1, 0, 3,
			0.3787322, 0.15531695, 3.6403883
		)]
		[InlineData(
			0, 0, 3,
			0, 0, 4,
			0, 0, 5,
			0, 0, 5
		)]
		[InlineData(
			-2, 0, 3,
			0, 4, 1,
			2, 0, 3,
			-0.3121152, 0.7415298, 5.428115
		)]
		[InlineData(
			-1, -2, 3,
			1, 0, 4,
			1, 2, 3,
			0.4496621, -0.2529931, 5.3192353
		)]
		#endregion // EncompassRange_ThreeCircles_ReturnsCircle Test Data
		public void EncompassRange_ThreeCircles_ReturnsCircle(
			float ax, float ay, float ar,
			float bx, float by, float br,
			float cx, float cy, float cr,
			float ex, float ey, float er
		) {
			// Variables
			Circle actual = new Circle(ax, ay, ar);
			Circle b = new Circle(bx, by, br);
			Circle c = new Circle(cx, cy, cr);
			Circle expected = new Circle(ex, ey, er);
			// TODO: Add a.EncompassRange(b, c, d, ...);
			
			Circle.EncompassRange(out actual, actual, b, c);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.IsOverlapping(Circle)"/> functionality.
		/// Uses two circles to check if they are overlapping or not
		/// </summary>
		[Theory]
		#region IsOverlapping_TwoCircles_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 3,
			0, -3, 1, true
		)]
		[InlineData(
			0, 0, 3,
			0, -4, -3, true
		)]
		[InlineData(
			0, 0, 3,
			0, -5, -1, false
		)]
		[InlineData(
			0, 0, 3,
			0, 0, 2, true
		)]
		[InlineData(
			0, 0, 2,
			0, 0, 3, true
		)]
		[InlineData(
			1, 2, 3,
			-1, -1, -1, true
		)]
		#endregion // IsOverlapping_TwoCircles_ReturnsBoolean Test Data
		public void IsOverlapping_TwoCircles_ReturnsBoolean(
			float ax, float ay, float ar,
			float bx, float by, float br,
			bool expected
		) {
			// Variables
			Circle a = new Circle(ax, ay, ar);
			Circle b = new Circle(bx, by, br);
			bool actual = a.IsOverlapping(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.IsDisjoint(Circle)"/> functionality.
		/// Uses two circles to check if they are disjoint or not
		/// </summary>
		[Theory]
		#region IsDisjoint_TwoCircles_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 3,
			0, -3, 1, false
		)]
		[InlineData(
			0, 0, 3,
			0, -4, -3, false
		)]
		[InlineData(
			0, 0, 3,
			0, -5, -1, true
		)]
		[InlineData(
			0, 0, 3,
			0, 0, 2, false
		)]
		[InlineData(
			0, 0, 2,
			0, 0, 3, false
		)]
		[InlineData(
			1, 2, 3,
			-1, -1, -1, false
		)]
		#endregion // IsDisjoint_TwoCircles_ReturnsBoolean Test Data
		public void IsDisjoint_TwoCircles_ReturnsBoolean(
			float ax, float ay, float ar,
			float bx, float by, float br,
			bool expected
		) {
			// Variables
			Circle a = new Circle(ax, ay, ar);
			Circle b = new Circle(bx, by, br);
			bool actual = a.IsDisjoint(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Circle.IsContained(Circle)"/> functionality.
		/// Uses two circles to check if they are contained or not
		/// </summary>
		[Theory]
		#region IsContained_TwoCircles_ReturnsBoolean Test Data
		[InlineData(
			0, 0, 3,
			0, -3, 1, false
		)]
		[InlineData(
			0, 0, 3,
			0, -4, -3, false
		)]
		[InlineData(
			0, 0, 3,
			0, -5, -1, false
		)]
		[InlineData(
			0, 0, 3,
			0, 0, 2, true
		)]
		[InlineData(
			0, 0, 2,
			0, 0, 3, false
		)]
		[InlineData(
			1, 2, 3,
			-1, -1, -1, false
		)]
		#endregion // IsContained_TwoCircles_ReturnsBoolean Test Data
		public void IsContained_TwoCircles_ReturnsBoolean(
			float ax, float ay, float ar,
			float bx, float by, float br,
			bool expected
		) {
			// Variables
			Circle a = new Circle(ax, ay, ar);
			Circle b = new Circle(bx, by, br);
			bool actual = a.IsContained(b);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

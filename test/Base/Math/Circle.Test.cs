
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class CircleTest {
		// Variables
		private ITestOutputHelper output;
		
		public CircleTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		// [Fact]
		// public void Constructors() {
		// 	Assert.Equal(new Circle(0, 0, 0), Circle.Empty);
		// 	Assert.Equal(new Circle(0, 0, 1), Circle.Unit);
		// }
		
		// [Theory]
		// [InlineData(-1, 1, 5, 5, -2, -1, 0.2111459, 0.3944271, 6.354102)]
		// [InlineData(-1, 1, 5, 0, 1, 7, 0, 1, 7)]
		// [InlineData(-3, 0, 5, 0, 5, -3, -2.014496, 1.642507, 6.915476)]
		// [InlineData(-3, 0, 0.5, 0, 0, 3, -0.25, 0, 3.25)]
		// public void Encompass(float ax, float ay, float ar, float bx, float by, float br, float ex, float ey, float er) {
		// 	// Variables
		// 	Circle a = new Circle(ax, ay, ar);
		// 	Circle b = new Circle(bx, by, br);
		// 	Circle e = new Circle(ex, ey, er);
			
		// 	a = Circle.Encompass(ref a, ref b);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(
		// 		Mathx.Approx(ref e.center, ref a.center, 0.00001f) &&
		// 		Mathx.Approx(e.radius, a.radius, 0.00001f)
		// 	);
		// }
		
		// [Theory]
		// [InlineData(0, 3, 0.5, 0, 0, 3, 1, 0, 3, 0.3787322, 0.1553169, 3.640388)]
		// [InlineData(0, 0, 3, 0, 0, 4, 0, 0, 5, 0, 0, 5)]
		// [InlineData(-2, 0, 3, 0, 4, 1, 2, 0, 3, -0.3121152, 0.7415298, 5.428115)]
		// [InlineData(-1, -2, 3, 1, 0, 4, 1, 2, 3, 0.4496621, -0.2529931, 5.319235)]
		// public void EncompassRange(float ax, float ay, float ar, float bx, float by, float br, float cx, float cy, float cr, float ex, float ey, float er) {
		// 	// Variables
		// 	Circle a = new Circle(ax, ay, ar);
		// 	Circle b = new Circle(bx, by, br);
		// 	Circle c = new Circle(cx, cy, cr);
		// 	Circle e = new Circle(ex, ey, er);
			
		// 	a = Circle.Encompass(a, b, c);
			
		// 	this.output.WriteLine("Expected:");
		// 	this.output.WriteLine(e.ToString());
		// 	this.output.WriteLine("Actual:");
		// 	this.output.WriteLine(a.ToString());
			
		// 	Assert.True(
		// 		Mathx.Approx(ref e.center, ref a.center, 0.00001f) &&
		// 		Mathx.Approx(e.radius, a.radius, 0.00001f)
		// 	);
		// }
		
		// [Theory]
		// [InlineData(true, 0, 0, 3, 0, -3, 1)]
		// [InlineData(true, 0, 0, 3, 0, -4, -3)]
		// [InlineData(false, 0, 0, 3, 0, -5, -1)]
		// [InlineData(true, 0, 0, 3, 0, 0, 2)]
		// [InlineData(true, 0, 0, 2, 0, 0, 3)]
		// [InlineData(true, 1, 2, 3, -1, -1, -1)]
		// [InlineData(false, 1, 2, 3, -2, -2, -1)]
		// [InlineData(true, 1, 2, 4, -1, -2, -4)]
		// [InlineData(true, 1, 2, 4, 3, 2, 0.4)]
		// [InlineData(true, 1, 2, 4, 3, 2, 4)]
		// public void IsOverlapping(bool isTrue, float ax, float ay, float ar, float bx, float by, float br) {
		// 	// Variables
		// 	Circle a = new Circle(ax, ay, ar);
		// 	Circle b = new Circle(bx, by, br);
			
		// 	if(isTrue)	Assert.True(Circle.IsOverlapping(ref a, ref b));
		// 	else	Assert.False(Circle.IsOverlapping(ref a, ref b));
		// }
		
		// [Theory]
		// [InlineData(false, 0, 0, 3, 0, -3, 1)]
		// [InlineData(false, 0, 0, 3, 0, -4, -3)]
		// [InlineData(true, 0, 0, 3, 0, -5, -1)]
		// [InlineData(false, 0, 0, 3, 0, 0, 2)]
		// [InlineData(false, 0, 0, 2, 0, 0, 3)]
		// [InlineData(false, 1, 2, 3, -1, -1, -1)]
		// [InlineData(true, 1, 2, 3, -2, -2, -1)]
		// [InlineData(false, 1, 2, 4, -1, -2, -4)]
		// [InlineData(false, 1, 2, 4, 3, 2, 0.4)]
		// [InlineData(false, 1, 2, 4, 3, 2, 4)]
		// public void IsDisjoint(
		// 	bool isTrue,
		// 	float ax, float ay, float ar,
		// 	float bx, float by, float br
		// ) {
		// 	// Variables
		// 	Circle a = new Circle(ax, ay, ar);
		// 	Circle b = new Circle(bx, by, br);
			
		// 	if(isTrue)	Assert.True(Circle.IsDisjoint(ref a, ref b));
		// 	else	Assert.False(Circle.IsDisjoint(ref a, ref b));
		// }
		
		// [Theory]
		// [InlineData(false, 0, 0, 3, 0, -3, 1)]
		// [InlineData(false, 0, 0, 3, 0, -4, -3)]
		// [InlineData(false, 0, 0, 3, 0, -5, -1)]
		// [InlineData(true, 0, 0, 3, 0, 0, 2)]
		// [InlineData(false, 0, 0, 2, 0, 0, 3)]
		// [InlineData(false, 1, 2, 3, -1, -1, -1)]
		// [InlineData(false, 1, 2, 3, -2, -2, -1)]
		// [InlineData(false, 1, 2, 4, -1, -2, -4)]
		// [InlineData(true, 1, 2, 4, 3, 2, 0.4)]
		// [InlineData(false, 1, 2, 4, 3, 2, 4)]
		// public void IsContained(bool isTrue, float ax, float ay, float ar, float bx, float by, float br) {
		// 	// Variables
		// 	Circle a = new Circle(ax, ay, ar);
		// 	Circle b = new Circle(bx, by, br);
			
		// 	if(isTrue)	Assert.True(Circle.IsContained(ref a, ref b));
		// 	else	Assert.False(Circle.IsContained(ref a, ref b));
		// }
	}
}

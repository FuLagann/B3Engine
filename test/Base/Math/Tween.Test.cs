
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Tween"/> class to make sure it works correctly. Contains 118 tests</summary>
	public class TweenTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Tween(float, float, float, Tween.TweenCallback)"/> functionality.
		/// Creates a tween and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Constructor_Returns011Linear() {
			// Variables
			Tween tween = new Tween(0, 1, 1, Tween.Linear);
			(float, float, float, Tween.TweenCallback) expected = (0, 1, 1, Tween.Linear);
			(float, float, float, Tween.TweenCallback) actual = (
				tween.Start,
				tween.End,
				tween.Duration,
				tween.Callback
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Tween(float, float, float, Tween.TweenCallback)"/> functionality.
		/// Creates a tween with a null callback and checks to see if it's correct
		/// </summary>
		[Fact]
		public void Constructor_NullCallback_Returns011Linear() {
			// Variables
			Tween tween = new Tween(0, 1, 1, null);
			(float, float, float, Tween.TweenCallback) expected = (0, 1, 1, Tween.Linear);
			(float, float, float, Tween.TweenCallback) actual = (
				tween.Start,
				tween.End,
				tween.Duration,
				tween.Callback
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using a linear function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(10, 20, 5, 4, 18)]
		[InlineData(-10, 10, 10, 6.5221, 3.0442)]
		[InlineData(-10, 10, -10, 6.5221, 3.0442)]
		[InlineData(0, 1, 5, 4, 0.8)]
		[InlineData(0, 0, 5, 4, 0)]
		public void Value_Linear_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.Linear);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in quadratic function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.040000003)]
		[InlineData(0, 1, 1, 0.3, 0.09)]
		[InlineData(0, 1, 1, 0.5, 0.25)]
		[InlineData(0, 1, 1, 0.65, 0.42249995)]
		[InlineData(0, 1, 4, 3, 0.5625)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -0.10000038)]
		[InlineData(3, 100, 1, 0.8, 65.08)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -77.5)]
		public void Value_EaseInQuad_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInQuad);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease out quadratic function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.35999998)]
		[InlineData(0, 1, 1, 0.3, 0.51000005)]
		[InlineData(0, 1, 1, 0.5, 0.75)]
		[InlineData(0, 1, 1, 0.65, 0.8775)]
		[InlineData(0, 1, 4, 3, 0.9375)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4.0999994)]
		[InlineData(3, 100, 1, 0.8, 96.12)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -32.5)]
		public void Value_EaseOutQuad_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutQuad);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in then out quadratic function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.080000006)]
		[InlineData(0, 1, 1, 0.3, 0.18)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.755)]
		[InlineData(0, 1, 4, 3, 0.875)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 3.1999989)]
		[InlineData(3, 100, 1, 0.8, 92.240005)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Value_EaseInOutQuad_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutQuad);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in exponential function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0.0009765625)]
		[InlineData(0, 1, 10, 2, 0.00390625)]
		[InlineData(0, 1, 1, 0.3, 0.0078125)]
		[InlineData(0, 1, 1, 0.5, 0.03125)]
		[InlineData(0, 1, 1, 0.65, 0.08838833)]
		[InlineData(0, 1, 4, 3, 0.17677669)]
		[InlineData(0, 1, 1, 0.86, 0.37892917)]
		[InlineData(0, 1, 1, 0.94, 0.6597539)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -3.75)]
		[InlineData(3, 100, 1, 0.8, 27.250004)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -97.1875)]
		public void Value_EaseInExpo_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInExpo);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease out exponential function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.75)]
		[InlineData(0, 1, 1, 0.3, 0.875)]
		[InlineData(0, 1, 1, 0.5, 0.96875)]
		[InlineData(0, 1, 1, 0.65, 0.98895144)]
		[InlineData(0, 1, 4, 3, 0.9944757)]
		[InlineData(0, 1, 1, 0.86, 0.9974228)]
		[InlineData(0, 1, 1, 0.94, 0.9985198)]
		[InlineData(0, 1, 1, 1, 0.99902343750)]
		[InlineData(-5, 5, 10, 7, 4.921875)]
		[InlineData(3, 100, 1, 0.8, 99.62109)]
		[InlineData(3, 100, 1, 1, 99.905273438)]
		[InlineData(-100, -10, 2, 1, -12.8125)]
		public void Value_EaseOutExpo_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutExpo);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in then out exponential function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0.00048828125000)]
		[InlineData(0, 1, 10, 2, 0.0078125)]
		[InlineData(0, 1, 1, 0.3, 0.03125)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.9375)]
		[InlineData(0, 1, 4, 3, 0.984375)]
		[InlineData(0, 1, 1, 0.86, 0.99659944)]
		[InlineData(0, 1, 1, 0.94, 0.99887824)]
		[InlineData(0, 1, 1, 1, 0.99951171875)]
		[InlineData(-5, 5, 10, 7, 4.6875)]
		[InlineData(3, 100, 1, 0.8, 99.24219)]
		[InlineData(3, 100, 1, 1, 99.952636719)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Value_EaseInOutExpo_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutExpo);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in circular function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.020204127)]
		[InlineData(0, 1, 1, 0.3, 0.0460608)]
		[InlineData(0, 1, 1, 0.5, 0.13397461)]
		[InlineData(0, 1, 1, 0.65, 0.24006575)]
		[InlineData(0, 1, 4, 3, 0.3385622)]
		[InlineData(0, 1, 1, 0.86, 0.48970598)]
		[InlineData(0, 1, 1, 0.94, 0.6588255)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -2.1414285)]
		[InlineData(3, 100, 1, 0.8, 41.800003)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -87.94228)]
		public void Value_EaseInCirc_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInCirc);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease out circular function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.59999996)]
		[InlineData(0, 1, 1, 0.3, 0.71414286)]
		[InlineData(0, 1, 1, 0.5, 0.8660254)]
		[InlineData(0, 1, 1, 0.65, 0.9367497)]
		[InlineData(0, 1, 4, 3, 0.96824586)]
		[InlineData(0, 1, 1, 0.86, 0.9901515)]
		[InlineData(0, 1, 1, 0.94, 0.9981984)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4.5393925)]
		[InlineData(3, 100, 1, 0.8, 98.0402)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -22.057716)]
		public void Value_EaseOutCirc_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutCirc);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Tween.Value"/> functionality.
		/// Updates a tween using an ease in then out circular function and checks to see if it's correct
		/// </summary>
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.041742444)]
		[InlineData(0, 1, 1, 0.3, 0.099999994)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.8570714)]
		[InlineData(0, 1, 4, 3, 0.9330127)]
		[InlineData(0, 1, 1, 0.86, 0.98)]
		[InlineData(0, 1, 1, 0.94, 0.99638695)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4)]
		[InlineData(3, 100, 1, 0.8, 95.95098)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Value_EaseInOutCirc_ReturnsFloat(float start, float end, float duration, float time, float expected) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutCirc);
			float actual;
			
			tween.Update(time);
			actual = tween.Value;
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

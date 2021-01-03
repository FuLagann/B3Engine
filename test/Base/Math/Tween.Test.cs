
using Xunit;
using Xunit.Abstractions;

namespace B3.Testing {
	public class TweenTest {
		// Variables
		private ITestOutputHelper output;
		
		public TweenTest(ITestOutputHelper output) {
			this.output = output;
		}
		
		[Fact]
		public void NullConstructor() {
			// Variables
			Tween tween = new Tween(0, 1, 1, null);
			Tween tween2 = new Tween(0, 1, 1, Tween.Linear);
			object obj = null;
			
			this.output.WriteLine(tween.ToString());
			
			Assert.True(tween.Callback == Tween.Linear);
			Assert.False(tween.Equals(obj));
			Assert.True(tween.Equals((object)tween2));
			Assert.False(tween.Equals(10));
			Assert.Equal(tween, tween2);
		}
		
		[Theory]
		[InlineData(0, 10, 3)]
		[InlineData(10, 20, 4)]
		[InlineData(5, -5, 5)]
		public void Constructors(float start, float end, float duration) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.Linear);
			
			this.output.WriteLine(tween.ToString());
			
			Assert.Equal(start, tween.Start);
			Assert.Equal(end, tween.End);
			Assert.Equal(duration, tween.Duration);
			Assert.False(tween.Callback == Mathx.Lerp);
		}
		
		[Theory]
		[InlineData(10, 20, 5, 4, 18)]
		[InlineData(-10, 10, 10, 6.5221, 3.0442)]
		[InlineData(-10, 10, -10, 6.5221, 3.0442)]
		[InlineData(0, 1, 5, 4, 0.8)]
		[InlineData(0, 0, 5, 4, 0)]
		public void Update_Linear(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.Linear);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.04)]
		[InlineData(0, 1, 1, 0.3, 0.09)]
		[InlineData(0, 1, 1, 0.5, 0.25)]
		[InlineData(0, 1, 1, 0.65, 0.4225)]
		[InlineData(0, 1, 4, 3, 0.5625)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -0.1)]
		[InlineData(3, 100, 1, 0.8, 65.08)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -77.5)]
		public void Update_EaseInQuad(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInQuad);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.36)]
		[InlineData(0, 1, 1, 0.3, 0.51)]
		[InlineData(0, 1, 1, 0.5, 0.75)]
		[InlineData(0, 1, 1, 0.65, 0.8775)]
		[InlineData(0, 1, 4, 3, 0.9375)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4.1)]
		[InlineData(3, 100, 1, 0.8, 96.12)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -32.5)]
		public void Update_EaseOutQuad(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutQuad);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.08)]
		[InlineData(0, 1, 1, 0.3, 0.18)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.755)]
		[InlineData(0, 1, 4, 3, 0.875)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 3.2)]
		[InlineData(3, 100, 1, 0.8, 92.24)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Update_EaseInOutQuad(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutQuad);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0.0009765625)]
		[InlineData(0, 1, 10, 2, 0.0039)]
		[InlineData(0, 1, 1, 0.3, 0.0078125)]
		[InlineData(0, 1, 1, 0.5, 0.03125)]
		[InlineData(0, 1, 1, 0.65, 0.0883883)]
		[InlineData(0, 1, 4, 3, 0.176777)]
		[InlineData(0, 1, 1, 0.86, 0.378929)]
		[InlineData(0, 1, 1, 0.94, 0.659754)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -3.75)]
		[InlineData(3, 100, 1, 0.8, 27.25)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -97.1875)]
		public void Update_EaseInExpo(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInExpo);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.75)]
		[InlineData(0, 1, 1, 0.3, 0.875)]
		[InlineData(0, 1, 1, 0.5, 0.96875)]
		[InlineData(0, 1, 1, 0.65, 0.988951)]
		[InlineData(0, 1, 4, 3, 0.994476)]
		[InlineData(0, 1, 1, 0.86, 0.997423)]
		[InlineData(0, 1, 1, 0.94, 0.99852)]
		[InlineData(0, 1, 1, 1, 0.99902343750)]
		[InlineData(-5, 5, 10, 7, 4.92188)]
		[InlineData(3, 100, 1, 0.8, 99.6211)]
		[InlineData(3, 100, 1, 1, 99.905273438)]
		[InlineData(-100, -10, 2, 1, -12.8125)]
		public void Update_EaseOutExpo(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutExpo);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0.00048828125000)]
		[InlineData(0, 1, 10, 2, 0.0078125)]
		[InlineData(0, 1, 1, 0.3, 0.03125)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.9375)]
		[InlineData(0, 1, 4, 3, 0.984375)]
		[InlineData(0, 1, 1, 0.86, 0.996599)]
		[InlineData(0, 1, 1, 0.94, 0.998878)]
		[InlineData(0, 1, 1, 1, 0.99951171875)]
		[InlineData(-5, 5, 10, 7, 4.6875)]
		[InlineData(3, 100, 1, 0.8, 99.24219)]
		[InlineData(3, 100, 1, 1, 99.952636719)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Update_EaseInOutExpo(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutExpo);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.0202041)]
		[InlineData(0, 1, 1, 0.3, 0.0460608)]
		[InlineData(0, 1, 1, 0.5, 0.133975)]
		[InlineData(0, 1, 1, 0.65, 0.240066)]
		[InlineData(0, 1, 4, 3, 0.338562)]
		[InlineData(0, 1, 1, 0.86, 0.489706)]
		[InlineData(0, 1, 1, 0.94, 0.658826)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, -2.14143)]
		[InlineData(3, 100, 1, 0.8, 41.8)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -87.94228)]
		public void Update_EaseInCirc(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInCirc);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.6)]
		[InlineData(0, 1, 1, 0.3, 0.714143)]
		[InlineData(0, 1, 1, 0.5, 0.866025)]
		[InlineData(0, 1, 1, 0.65, 0.93675)]
		[InlineData(0, 1, 4, 3, 0.968246)]
		[InlineData(0, 1, 1, 0.86, 0.990152)]
		[InlineData(0, 1, 1, 0.94, 0.998198)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4.53939)]
		[InlineData(3, 100, 1, 0.8, 98.0402)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -22.057716)]
		public void Update_EaseOutCirc(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseOutCirc);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
		
		[Theory]
		[InlineData(0, 1, 1, 0, 0)]
		[InlineData(0, 1, 10, 2, 0.0417424)]
		[InlineData(0, 1, 1, 0.3, 0.1)]
		[InlineData(0, 1, 1, 0.5, 0.5)]
		[InlineData(0, 1, 1, 0.65, 0.857071)]
		[InlineData(0, 1, 4, 3, 0.933013)]
		[InlineData(0, 1, 1, 0.86, 0.98)]
		[InlineData(0, 1, 1, 0.94, 0.996387)]
		[InlineData(0, 1, 1, 1, 1)]
		[InlineData(-5, 5, 10, 7, 4)]
		[InlineData(3, 100, 1, 0.8, 95.95098)]
		[InlineData(3, 100, 1, 1, 100)]
		[InlineData(-100, -10, 2, 1, -55)]
		public void Update_EaseInOutCirc(float start, float end, float duration, float t, float e) {
			// Variables
			Tween tween = new Tween(start, end, duration, Tween.EaseInOutCirc);
			
			tween.Update(t);
			
			this.output.WriteLine(tween.ToString());
			this.output.WriteLine("Expected: " + e + "; Actual: " + tween.Value);
			
			Assert.True(Mathx.Approx(e, tween.Value, 0.00001f));
		}
	}
}

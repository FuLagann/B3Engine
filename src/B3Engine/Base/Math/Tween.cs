
namespace B3 {
	/// <summary>A class for tweening (short for in-betweening) floating point numbers</summary>
	public class Tween : System.IEquatable<Tween>, IUpdatable {
		#region Field Variables
		// Variables
		private float start;
		private float end;
		private float t;
		private float duration;
		private InterpolationLoopType loopType;
		private TweenCallback callback;
		
		// Delegates
		/// <summary>The tweening function used by the tween to get the interpolated values</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the current value in relation to the time t given</returns>
		public delegate float TweenCallback(float start, float end, float t);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the starting value of the tween for when t = 0</summary>
		public float Start { get { return this.start; } set { this.start = value; } }
		
		/// <summary>Gets and sets the ending value of the tween for when t = 1</summary>
		public float End { get { return this.end; } set { this.end = value; } }
		
		/// <summary>Gets and sets the duration in seconds of the tween</summary>
		public float Duration { get { return this.duration; } set { this.duration = Mathx.Abs(value); } }
		
		/// <summary>Gets and sets the time value of the tween, is between 0 and 1</summary>
		public float Time { get {
			// Variables
			float time = (this.t / this.duration);
			
			if((int)this.loopType % 2 == 1) {
				time = 1.0f - time;
			}
			
			return time;
		} set { this.t = Mathx.Clamp(value, 0.0f, 1.0f) * this.duration; } }
		
		/// <summary>Gets if the tween has finished tweening</summary>
		public bool IsFinished { get { return (this.t >= this.duration && (int)this.loopType < 2); } }
		
		/// <summary>Gets and sets the callback delegate of the tween, cannot set this to null</summary>
		public TweenCallback Callback { get { return this.callback; } set {
			if(value == null) {
				return;
			}
			this.callback = value;
		} }
		
		/// <summary>Gets the value calculated by the tween</summary>
		public float Value { get { return this.callback(this.start, this.end, this.Time); } }
		
		/// <summary>Gets and sets the looping type of the tween</summary>
		public InterpolationLoopType LoopType { get { return this.loopType; } set { this.loopType = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for a tween</summary>
		/// <param name="start">The starting value that the tween uses when t = 0</param>
		/// <param name="end">The ending value that the tween uses when t = 1</param>
		/// <param name="duration">The duration in seconds</param>
		/// <param name="callback">The tweening function for getting the value, setting it to null will default to a linear tween</param>
		public Tween(float start, float end, float duration, TweenCallback callback) {
			this.start = start;
			this.end = end;
			this.t = 0.0f;
			this.duration = Mathx.Abs(duration);
			this.callback = callback ?? Tween.Linear;
			this.loopType = InterpolationLoopType.NoLoop;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		/// <summary>A linearly interpolation tweening function for making the value go from start to end linearly</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been linearly interpolated</returns>
		public static float Linear(float start, float end, float t) { return  start + t * (end - start); }
		
		#region Quadratic Easing Methods
		
		/// <summary>A quadratic easing in tweening function for making the value go from start to end in a slow start fast end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been quadratically interpolated</returns>
		public static float EaseInQuad(float start, float end, float t) { return start + t * t * (end - start); }
		
		/// <summary>A quadratic easing out tweening function for making the value go from start to end in a fast start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been quadratically interpolated</returns>
		public static float EaseOutQuad(float start, float end, float t) { return start - t * (t - 2.0f) * (end - start); }
		
		/// <summary>A quatratic easing in-out tweening function for making the value go from start to end in a slow start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been quadratically interpolated</returns>
		public static float EaseInOutQuad(float start, float end, float t) {
			return (t <= 0.5f ?
				start + 2.0f * t * t * (end - start) :
				start - (2.0f * t * (t - 2.0f) + 1.0f) * (end - start)
			);
		}
		
		#endregion // Quadratic Easing Methods
		
		#region Exponential Easing Methods
		
		/// <summary>An exponential easing in tweening function for making the value go from start to end in a slow start fast end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been exponentially interpolated</returns>
		public static float EaseInExpo(float start, float end, float t) { return start + (end - start) * Mathx.Pow(2.0f, 10.0f * (t - 1.0f)); }
		
		/// <summary>An exponential easing out tweening function for making the value go from start to end in a fast start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been exponentially interpolated</returns>
		public static float EaseOutExpo(float start, float end, float t) { return start + (end - start) * (1.0f - Mathx.Pow(2.0f, -10.0f * t)); }
		
		/// <summary>A exponential easing in-out tweening function for making the value go from start to end in a slow start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been exponentially interpolated</returns>
		public static float EaseInOutExpo(float start, float end, float t) {
			return (t <= 0.5f ?
				start + (end - start) * Mathx.Pow(2.0f, 20.0f * t - 11.0f) :
				start + (end - start) * (1.0f - Mathx.Pow(2.0f, 9.0f - 20.0f * t))
			);
		}
		
		#endregion // Exponential Easing Methods
		
		#region Circular Easing Methods
		
		/// <summary>A circular easing in tweening function for making the value go from start to end in a slow start fast end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been circularly interpolated</returns>
		public static float EaseInCirc(float start, float end, float t) { return start + (end - start) * (1.0f - Mathx.Sqrt(1.0f - t * t)); }
		
		/// <summary>A circular easing out tweening function for making the value go from start to end in a fast start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been circularly interpolated</returns>
		public static float EaseOutCirc(float start, float end, float t) { return start + (end - start) * Mathx.Sqrt(1.0f - (t-1) * (t-1)); }
		
		/// <summary>A circular easing in-out tweening function for making the value go from start to end in a slow start slow end motion</summary>
		/// <param name="start">The starting value for when t = 0</param>
		/// <param name="end">The ending value for when t = 1</param>
		/// <param name="t">The time value that is between 0 and 1</param>
		/// <returns>Returns the value that has been circular interpolated</returns>
		public static float EaseInOutCirc(float start, float end, float t) {
			return (t < 0.5 ?
				start + 0.5f * (end - start) * (1.0f - Mathx.Sqrt(1.0f - 4.0f * t * t)) :
				start + 0.5f * (end - start) * (1.0f + Mathx.Sqrt(1.0f - 4.0f * (t - 1.0f) * (t - 1.0f)))
			);
		}
		
		#endregion // Circular Easing Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Resets the tween (setting the time back to 0)</summary>
		public void Reset() { this.t = 0.0f; }
		
		/// <summary>Updates the tween with a given elapsed time</summary>
		/// <param name="deltaTime">The time elapsed between frames</param>
		public void Update(float deltaTime) {
			if((int)this.loopType < 2) {
				this.t = Mathx.Clamp(this.t + deltaTime, 0.0f, this.duration);
			}
			else {
				if(this.t + deltaTime > this.duration) {
					if(this.loopType == InterpolationLoopType.YoyoLoop) {
						this.loopType = InterpolationLoopType.YoyoLoopBackwards;
					}
					else if(this.loopType == InterpolationLoopType.YoyoLoopBackwards) {
						this.loopType = InterpolationLoopType.YoyoLoop;
					}
				}
				this.t = Mathx.RepeatFrom0(this.t + deltaTime, this.duration);
			}
		}
		
		/// <summary>Finds if the two tweens are equal to each other</summary>
		/// <param name="other">The other tween</param>
		/// <returns>Returns true if the two tweens are equal to each other</returns>
		public bool Equals(Tween other) {
			if(other == null) {
				return false;
			}
			return (
				this.start == other.start &&
				this.end == other.end &&
				this.duration == other.duration &&
				this.callback == other.callback
			);
		}
		
		/// <summary>Finds if the two tweens are equal to each other</summary>
		/// <param name="other">The other tween</param>
		/// <returns>Returns true if the two tweens are equal to each other</returns>
		public override bool Equals(object other) { return this.Equals(other as Tween); }
		
		/// <summary>Gets the hash code from the tween</summary>
		/// <returns>Returns the hash code from the tween</returns>
		public override int GetHashCode() { return (int)this.start ^ (int)this.end ^ (int)this.t ^ (int)this.duration ^ this.callback.GetHashCode(); }
		
		/// <summary>Gets the tween in string form</summary>
		/// <returns>Returns the tween in string form</returns>
		public override string ToString() {
			return (
				"{ start: " + this.start +
				", end: " + this.end +
				", time: " + this.t +
				", duration: " + this.duration +
				", callback: " + (this.callback.Method.ReflectedType.FullName + "." + this.callback.Method.Name) + " }"
			);
		}
		
		#endregion // Public Methods
	}
}

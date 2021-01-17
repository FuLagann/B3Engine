
using System.Collections;
using System.Collections.Generic;

namespace B3 {
	/// <summary>A class that represents smooth line that goes through each points in the spline used for smoothly moving objects</summary>
	public class Spline : System.IEquatable<Spline>, IList<Vector3>, IUpdatable {
		#region Field Variables
		// Variables
		private Vector3[] points;
		private float t;
		private float duration;
		private InterpolationLoopType loopType;
		private SplineType splineType;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the individual points of the spline</summary>
		public Vector3 this[int index] { get {
			if(index < 0 || index >= this.Count) {
				throw new System.ArgumentOutOfRangeException("index", index, "Index is out of range");
			}
			return this.points[index];
		} set {
			if(index < 0 || index >= this.Count) {
				throw new System.ArgumentOutOfRangeException("index", index, "Index is out of range");
			}
			this.points[index] = value;
		} }
		
		/// <summary>Gets if the spline's data is read-only</summary>
		public bool IsReadOnly { get { return false; } }
		
		/// <summary>Gets the number of points in the spline</summary>
		public int Count { get { return this.points.Length; } }
		
		/// <summary>Gets and sets the points of the spline</summary>
		public Vector3[] Points { get { return this.points; } set {
			if(value == null) {
				return;
			}
			this.points = value;
		} }
		
		/// <summary>Gets and sets the type of interpolation the spline should do overall</summary>
		public SplineType SplineType { get { return this.splineType; } set { this.splineType = value; } }
		
		/// <summary>Gets and sets the loop type of the spline</summary>
		public InterpolationLoopType LoopType { get { return this.loopType; } set { this.loopType = value; } }
		
		/// <summary>Gets and sets the amount of time (in seconds) that the spline has elapsed that is within the range of 0 and 1</summary>
		public float Time { get {
			// Variables
			float time = (this.t / this.duration);
			
			if((int)this.loopType % 2 == 1) {
				time = 1.0f - time;
			}
			
			return time;
		} set { this.t = Mathx.Clamp(value, 0.0f, 1.0f) * this.duration; } }
		
		/// <summary>Gets and sets the amount of time (in seconds) for the point to go from the first point to the last point in the spline</summary>
		public float Duration { get { return this.duration; } set { this.duration = Mathx.Abs(value); } }
		
		/// <summary>Gets the value of the spline in respect to <see cref="B3.Spline.Time"/></summary>
		public Vector3 Value { get {
			if(this.Count == 0) {
				return Vector3.Zero;
			}
			if(this.Count == 1) {
				return this.points[0];
			}
			
			// Variables
			Vector3 result;
			
			if(this.splineType == SplineType.Linear) {
				this.GetValueLinearly(this.Time, out result);
			}
			else {
				this.GetValueByCatmullRom(this.Time, out result);
			}
			
			return result;
		} }
		
		#endregion // Public Properties
		
		#region Private Properties
		
		/// <summary>Gets if the spline is doing a full loop</summary>
		private bool IsFullLooped { get { return ((int)this.loopType / 2 == 1); } }
		
		#endregion // Private Properties
		
		#region Public Constructors
		
		/// <summary>A base class for creating a spline</summary>
		/// <param name="duration">The duration of the spline (in seconds)</param>
		/// <param name="points">The points of the spline</param>
		public Spline(float duration, Vector3[] points) {
			this.t = 0.0f;
			this.duration = duration;
			this.points = points ?? new Vector3[0];
			this.loopType = InterpolationLoopType.NoLoop;
			this.splineType = SplineType.CatmullRom;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		/// <summary>Creates a new spline with a unit duration (the duration (in seconds) between the first two points) to calculate a max duration</summary>
		/// <param name="unitDuration">The duration (in seconds) between the first two points</param>
		/// <param name="points">The points of the spline</param>
		/// <returns>Returns a new spline that has a calculated duration using the unit duration</returns>
		public static Spline WithUnitDuration(float unitDuration, Vector3[] points) {
			if(points.Length <= 1) {
				return new Spline(0.0f, points);
			}
			if(points.Length == 2) {
				return new Spline(unitDuration, points);
			}
			
			// Variables
			float lambdas = 1.0f;
			Vector3 temp;
			float max;
			float delta;
			
			Vector3.Subtract(ref points[1], ref points[0], out temp);
			max = temp.MagnitudeSquared;
			
			for(int i = 1; i < points.Length - 1; i++) {
				Vector3.Subtract(ref points[i + 1], ref points[i], out temp);
				delta = temp.MagnitudeSquared;
				lambdas += (delta / max);
			}
			
			return new Spline(lambdas * unitDuration, points);
		}
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Gets the point at the given time</summary>
		/// <param name="time">The time to get the value from, should be clamped between 0 and 1</param>
		/// <param name="result">The resulting point on the spline with respect to time</param>
		public void GetPointAt(float time, out Vector3 result) {
			if(this.splineType == SplineType.Linear) {
				this.GetValueLinearly(time, out result);
			}
			else {
				this.GetValueByCatmullRom(time, out result);
			}
		}
		
		/// <summary>Gets the point at the given time</summary>
		/// <param name="time">The time to get the value from, should be clamped between 0 and 1</param>
		public Vector3 GetPointAt(float time) {
			// Variables
			Vector3 result;
			
			this.GetPointAt(time, out result);
			
			return result;
		}
		
		/// <summary>Updates the spline</summary>
		/// <param name="deltaTime">The time to update the spline by in seconds</param>
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
		
		/// <summary>Finds if the two splines are equal to each other</summary>
		/// <param name="other">The other spline</param>
		/// <returns>Returns true if the two splines are equal to each other</returns>
		public bool Equals(Spline other) {
			if(other == null) {
				return false;
			}
			if(this.Count != other.Count) {
				return false;
			}
			
			for(int i = 0; i < this.Count; i++) {
				if(this.points[i] != other.points[i]) {
					return false;
				}
			}
			
			return (this.duration == other.duration);
		}
		
		/// <summary>Gets the index of the point if it exists on the spline's data</summary>
		/// <param name="point">The point to search with</param>
		/// <returns>Returns the index of the point in the spline, returns -1 if not found</returns>
		public int IndexOf(Vector3 point) { return System.Array.IndexOf(this.points, point); }
		
		/// <summary>Clears the spline of all it's points</summary>
		public void Clear() { this.points = new Vector3[0]; }
		
		/// <summary>Finds if the point is found within the spline</summary>
		/// <param name="point">The point to search with</param>
		/// <returns>Returns true if the point is found within the spline's data</returns>
		public bool Contains(Vector3 point) { return (this.IndexOf(point) != -1); }
		
		/// <summary>Adds the point into the spline</summary>
		/// <param name="point">The point to add into the spline</param>
		public void Add(Vector3 point) {
			System.Array.Resize(ref this.points, this.Count + 1);
			this.points[this.Count - 1] = point;
		}
		
		/// <summary>Inserts the point into the given index</summary>
		/// <param name="index">The index to insert the point into, should be between 0 and the Count of the spline</param>
		/// <param name="point">The point to insert the spline</param>
		public void Insert(int index, Vector3 point) {
			if(index >= this.Count) {
				this.Add(point);
				return;
			}
			if(index < 0) {
				index = 0;
			}
			System.Array.Resize(ref this.points, this.Count + 1);
			for(int i = this.Count - 1; i > index; i--) {
				this.points[i] = this.points[i - 1];
			}
			this.points[index] = point;
		}
		
		/// <summary>Removes the point of the splinee by the given index</summary>
		/// <param name="index">The index to remove from</param>
		public void RemoveAt(int index) {
			if(index < 0 || index >= this.Count) {
				return;
			}
			
			for(int i = index; i < this.Count - 1; i++) {
				this.points[i] = this.points[i + 1];
			}
			
			System.Array.Resize(ref this.points, this.Count - 1);
		}
		
		/// <summary>Removes the point from the spline</summary>
		/// <param name="point">The point to remove from</param>
		/// <returns>Returns true if the point has been successfully removed</returns>
		public bool Remove(Vector3 point) {
			// Variables
			int index = this.IndexOf(point);
			
			this.RemoveAt(index);
			
			
			return (index != -1);
		}
		
		/// <summary>Copies the points to a new array</summary>
		/// <param name="destination">The destination array to copy to</param>
		/// <param name="index">The starting index of the source array</param>
		public void CopyTo(Vector3[] destination, int index) { this.points.CopyTo(destination, index); }
		
		/// <summary>Gets the enumerator of the spline</summary>
		/// <returns>Returns the enumerator of the spline</returns>
		public IEnumerator<Vector3> GetEnumerator() { return (IEnumerator<Vector3>)this.points.GetEnumerator(); }
		
		/// <summary>Gets the enumerator of the spline</summary>
		/// <returns>Returns the enumerator of the spline</returns>
		IEnumerator IEnumerable.GetEnumerator() { return this.points.GetEnumerator(); }
		
		/// <summary>Gets the spline in string form</summary>
		/// <returns>Returns the spline in string form</returns>
		public override string ToString() {
			// Variables
			string result = "{ points: [";
			
			for(int i = 0; i < this.Count; i++) {
				result += this.points[i] + (i == this.Count - 1 ? "" : ", ");
			}
			
			result += "], duration: " + this.duration + ", loopType: " + this.loopType + ", splineType: " + this.splineType + " }";
			
			return result;
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Gets the point on the spline by a linear interpolation</summary>
		/// <param name="time">The time to get the value from, should be clamped between 0 and 1</param>
		/// <param name="result">The resulting point on the spline with respect to time</param>
		private void GetValueLinearly(float time, out Vector3 result) {
			// Variables
			float t = (time * (this.IsFullLooped ? this.Count : this.Count - 1));
			int index = (int)t;
			
			t = Mathx.Clamp(t - index, 0.0f, 1.0f);
			if(this.IsFullLooped) {
				if(index == this.Count) {
					index = 0;
				}
			}
			else if(index >= this.Count - 1) {
				result = this.points[this.Count - 1];
				return;
			}
			
			Mathx.LerpClamped(
				ref this.points[index],
				ref this.points[index == this.Count - 1 ? 0 : index + 1],
				t,
				out result
			);
		}
		
		/// <summary>Gets the value by using Catmull-Rom spline interpolation</summary>
		/// <param name="time">The time to get the value from, should be clamped between 0 and 1</param>
		/// <param name="result">The resulting point on the spline with respect to time</param>
		private void GetValueByCatmullRom(float time, out Vector3 result) {
			if(this.Count == 0) {
				result = Vector3.Zero;
				return;
			}
			else if(this.Count == 1) {
				result = this.points[0];
				return;
			}
			
			// Variables
			float segments = (this.IsFullLooped ? this.Count : this.Count - 1);
			int index = (int)(this.Time * segments);
			int p0 = this.GetLimits(index - 1);
			int p1 = this.GetLimits(index);
			int p2 = this.GetLimits(index + 1);
			int p3 = this.GetLimits(index + 2);
			float t = (time - (float)index / segments) * segments;
			float t2 = t * t;
			float t3 = t2 * t;
			Vector3 temp, temp2;
			
			Mathx.Multiply(0.5f * (-t3 + 2.0f * t2 - t), ref this.points[p0], out temp);
			Mathx.Multiply(0.5f * (3.0f * t3 - 5.0f * t2 + 2.0f), ref this.points[p1], out temp2);
			Mathx.Add(ref temp, ref temp2, out temp);
			Mathx.Multiply(0.5f * (-3.0f * t3 + 4.0f * t2 + t), ref this.points[p2], out temp2);
			Mathx.Add(ref temp, ref temp2, out temp);
			Mathx.Multiply(0.5f * (t3 - t2), ref this.points[p3], out temp2);
			Mathx.Add(ref temp, ref temp2, out result);
		}
		
		/// <summary>Gets the limit of the indices clamping between the min and max or wrapping around the entire array of points</summary>
		/// <param name="index">The index to query it's limits</param>
		/// <returns>Returns the index that have been clamped or wrapped</returns>
		private int GetLimits(int index) {
			if(this.IsFullLooped) {
				return Mathx.RepeatFrom0(index, this.Count - 1);
			}
			
			if(index < 0) {
				return 0;
			}
			else if(index >= this.Count) {
				return this.Count - 1;
			}
			
			return index;
		}
		
		#endregion // Private Methods
	}
}

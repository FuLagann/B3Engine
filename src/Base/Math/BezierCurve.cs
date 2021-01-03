
using System.Collections;
using System.Collections.Generic;

namespace B3 {
	/// <summary>A class that creates a smooth curve using the points</summary>
	public class BezierCurve : System.IEquatable<BezierCurve>, IList<Vector3>, IUpdatable {
		#region Field Variables
		// Variables
		private Vector3[] points;
		private float t;
		private float duration;
		private InterpolationLoopType loopType;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the points of the curve</summary>
		/// <param name="index">The index to get and set from the hard points that form the curve</param>
		public Vector3 this[int index] { get { return this.points[index]; } set { this.points[index] = value; } }
		
		/// <summary>Gets if the curve is readonly</summary>
		public bool IsReadOnly { get { return false; } }
		
		/// <summary>Gets the amount of points witihn the curve</summary>
		public int Count { get { return this.points.Length; } }
		
		/// <summary>Gets and sets the points of the bezier curve</summary>
		public Vector3[] Points { get { return this.points; } set {
			if(value == null) {
				return;
			}
			this.points = value;
		} }
		
		/// <summary>Gets and sets the duration of the bezier curve in seconds</summary>
		public float Duration { get { return this.duration; } set { this.duration = Mathx.Abs(value); } }
		
		/// <summary>Gets and sets the amount of time (in seconds) that the bezier curve has elapsed that is within the range of 0 and 1</summary>
		public float Time { get {
			// Variables
			float time = (this.t / this.duration);
			
			if((int)this.loopType % 2 == 1) {
				time = 1.0f - time;
			}
			
			return time;
		} set { this.t = Mathx.Clamp(value, 0.0f, 1.0f) * this.duration; } }
		
		/// <summary>Gets and sets the loop type of the bezier curve. Full loops will be replaced with yoyo type</summary>
		public InterpolationLoopType LoopType { get { return this.loopType; } set {
			if(value == InterpolationLoopType.FullLoop) {
				this.loopType = InterpolationLoopType.YoyoLoop;
			}
			else if(value == InterpolationLoopType.FullLoopBackwards) {
				this.loopType = InterpolationLoopType.YoyoLoopBackwards;
			}
			else {
				this.loopType = value;
			}
		} }
		
		/// <summary>Gets the value of the bezier curve with respect to Time</summary>
		public Vector3 Value { get {
			if(this.Count == 0) {
				return Vector3.Zero;
			}
			
			// Variables
			Vector3 result;
			
			this.GetValue(0, this.Count - 1, this.Time, out result);
			
			return result;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a bezier curve</summary>
		/// <param name="duration">The duration of the bezier curve</param>
		/// <param name="points">The points used to create the bezier curve</param>
		public BezierCurve(float duration, Vector3[] points) {
			this.points = points ?? new Vector3[0];
			this.duration = duration;
			this.t = 0.0f;
			this.loopType = InterpolationLoopType.NoLoop;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Updates the bezier curve</summary>
		/// <param name="deltaTime">The time to update the bezier curve by in seconds</param>
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
		
		/// <summary>Finds if the two curves are equal to each other</summary>
		/// <param name="other">The other curve</param>
		/// <returns>Returns true if the two curves are equal to each other</returns>
		public bool Equals(BezierCurve other) {
			if(other == null) {
				return false;
			}
			
			return (this.duration == other.duration && System.Array.Equals(this.points, other.points));
		}
		
		/// <summary>Clears all the points used by the curve</summary>
		public void Clear() {
			this.points = new Vector3[0];
		}
		
		/// <summary>Adds the point onto the list of points</summary>
		/// <param name="point">The point to add</param>
		public void Add(Vector3 point) {
			System.Array.Resize(ref this.points, this.Count + 1);
			this.points[this.Count - 1] = point;
		}
		
		/// <summary>Inserts the point into the given index</summary>
		/// <param name="index">The index to place the point into</param>
		/// <param name="point">The point to add</param>
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
		
		/// <summary>Gets the index of the given point</summary>
		/// <param name="point">The point to search for</param>
		/// <returns>Returns the index of the given point, if its not found then it returns -1</returns>
		public int IndexOf(Vector3 point) {
			for(int i = 0; i < this.Count; i++) {
				if(this.points[i] == point) {
					return i;
				}
			}
			
			return -1;
		}
		
		/// <summary>Finds if the curve has the given point</summary>
		/// <param name="point">The point to find</param>
		/// <returns>Returns true if the point was found</returns>
		public bool Contains(Vector3 point) { return (this.IndexOf(point) != -1); }
		
		/// <summary>Removes the point of the curve at the given index</summary>
		/// <param name="index">The index to remove at</param>
		public void RemoveAt(int index) {
			if(index < 0 || index >= this.Count) {
				return;
			}
			
			for(int i = index; i < this.Count - 1; i++) {
				this.points[i] = this.points[i + 1];
			}
			
			System.Array.Resize(ref this.points, this.Count - 1);
		}
		
		/// <summary>Removes the given point of the curve from the curve</summary>
		/// <param name="point">The point to remove</param>
		/// <returns>Returns true if the point has been successfully removed</returns>
		public bool Remove(Vector3 point) {
			// Variables
			int index = this.IndexOf(point);
			
			if(index == -1) {
				return false;
			}
			
			this.RemoveAt(index);
			
			return true;
		}
		
		/// <summary>Copies the points of the curve onto an array starting at the given index</summary>
		/// <param name="destination">The array to copy to</param>
		/// <param name="index">The index to start at</param>
		public void CopyTo(Vector3[] destination, int index) { this.points.CopyTo(destination, index); }
		
		/// <summary>Gets the enumerator of the curve</summary>
		/// <returns>Returns an enumerator to iterate through the points of the curve</returns>
		public IEnumerator<Vector3> GetEnumerator() { return (IEnumerator<Vector3>)this.points.GetEnumerator(); }
		
		/// <summary>Gets the enumerator of the curve</summary>
		/// <returns>Returns an enumerator to iterate through the points of the curve</returns>
		IEnumerator IEnumerable.GetEnumerator() { return this.points.GetEnumerator(); }
		
		/// <summary>Gets the bezier curve in string form</summary>
		/// <returns>Returns the bezier curve in string form</returns>
		public override string ToString() {
			// Variables
			string result = "{ points: [";
			
			for(int i = 0; i < this.Count; i++) {
				result += this.points[i] + (i == this.Count - 1 ? "" : ", ");
			}
			
			result += "], duration: " + this.duration + ", loopType: " + this.loopType + " }";
			
			return result;
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Gets the point on the curve using a divide and conquer algorithm that lerps each point with each other</summary>
		/// <param name="left">The leftmost index that is being segmented</param>
		/// <param name="right">The rightmost index that is being segmented</param>
		/// <param name="time">The time used to get the interpolated point</param>
		/// <param name="result">The resulting point</param>
		private void GetValue(int left, int right, float time, out Vector3 result) {
			switch(right - left) {
				case 0: {
					result = this.points[left];
				} break;
				case 1: {
					Mathx.Lerp(ref this.points[left], ref this.points[right], time, out result);
				} break;
				default: {
					// Variables
					int half = (right - left) / 2;
					Vector3 a;
					Vector3 b;
					
					this.GetValue(left, left + half, time, out a);
					this.GetValue(left + half, right, time, out b);
					Mathx.Lerp(ref a, ref b, time, out result);
				} break;
			}
		}
		
		#endregion // Private Methods
	}
}

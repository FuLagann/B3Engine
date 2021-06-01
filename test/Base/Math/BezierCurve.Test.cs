
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.BezierCurve"/> class to make sure it works correctly. Contains 58 tests</summary>
	public class BezierCurveTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Points"/> construction.
		/// Checks to see if the points gets constructed correctly
		/// </summary>
		[Theory]
		[InlineData(new float[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1 })]
		[InlineData(new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void Points_Construct_ReturnsArray(float[] points) {
			// Variables
			Vector3[] vertices = this.CreateVector3Array(points);
			BezierCurve curve = new BezierCurve(1.0f, vertices);
			
			Assert.Equal(vertices, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Duration"/> construction.
		/// Checks to see if the duration gets constructed correctly
		/// </summary>
		[Theory]
		[InlineData(10, new float[] { 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1 })]
		[InlineData(3, new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void Duration_Construct_ReturnsFloat(float duration, float[] points) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(duration, points);
			
			Assert.Equal(duration, curve.Duration);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Value"/> and <see cref="B3.BezierCurve.Time"/> functionality.
		/// Checks the value after a specific time has passed
		/// </summary>
		[Theory]
		[InlineData(0, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.08333334, 0.05324074f, 0.6365741f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.1666667, 0.2037037f, 1.203704f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.25, 0.4375f, 1.6875f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.3333333, 0.7407408f, 2.074074f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.4166667, 1.099537f, 2.349537f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.5, 1.5f, 2.5f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.5833334, 1.928241f, 2.511574f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.6666667, 2.37037f, 2.37037f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.75, 2.8125f, 2.0625f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.8333334, 3.240741f, 1.574074f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(0.9166667, 3.641204f, 0.8912035f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		[InlineData(1, 4f, 0f, 0f, new float[] { 0f, 0f, 0f, 0f, 4f, 0f, 4f, 4f, 0f, 4f, 0f, 0f })]
		public void Value_TimeUpdate_ReturnsApproximateFloat(float time, float ex, float ey, float ez, float[] points) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			BezierCurve curve = this.CreateBezierCurve(4.0f, points);
			
			curve.Time = time;
			
			Assert.True(Vector3.Approx(expected, curve.Value, 0.000001f));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Value"/>, <see cref="B3.BezierCurve.Time"/>, and <see cref="B3.BezierCurve.LoopType"/> functionalty.
		/// Checks the value after a specific time has passed and is set to be backwards
		/// </summary>
		[Theory]
		[InlineData(0, 0f, 0f, 12f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.08333334, 0.3310184f, 1.12037f, 9.243056f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.1666667, 0.6481482f, 1.851852f, 6.944444f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.25, 0.9375f, 2.25f, 5.0625f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.3333333, 1.185185f, 2.37037f, 3.555555f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.4166667, 1.377315f, 2.268518f, 2.381944f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.5, 1.5f, 2f, 1.5f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.5833334, 1.539352f, 1.62037f, 0.8680553f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.6666667, 1.481481f, 1.185185f, 0.4444444f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.75, 1.3125f, 0.75f, 0.1875f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.8333334, 1.018518f, 0.3703702f, 0.05555551f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(0.9166667, 0.585648f, 0.1018518f, 0.006944439f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		[InlineData(1, 0f, 0f, 0f, new float[] { 0f, 0f, 0f, 4f, 0f, 0f, 0f, 8f, 0f, 0f, 0f, 12f })]
		public void Value_TimeUpdateNoLoopBackwards_ReturnsApproximateFloat(float time, float ex, float ey, float ez, float[] points) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			BezierCurve curve = this.CreateBezierCurve(4.0f, points);
			
			curve.Time = time;
			curve.LoopType = InterpolationLoopType.NoLoopBackwards;
			
			Assert.True(Vector3.Approx(expected, curve.Value, 0.00001f));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Add(Vector3)"/> functionality.
		/// Adds a point to an already established curve and checks to see if it returns the correct array
		/// </summary>
		[Theory]
		[InlineData(0, 0, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		[InlineData(0, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 1 })]
		[InlineData(0, 0, 1, new float[] {}, new float[] { 0, 0, 1 })]
		public void Add_SingleVector_ReturnsIncreasedArray(float x, float y, float z, float[] points, float[] expectedPoints) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3[] expected = this.CreateVector3Array(expectedPoints);
			Vector3 point = new Vector3(x, y, z);
			
			curve.Add(point);
			
			Assert.Equal(expected, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Remove(Vector3)"/> functionality.
		/// Removes a point from the already established curve and checks to see if it retuns the correct array
		/// </summary>
		[Theory]
		[InlineData(1, 0, 1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		[InlineData(1, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(1, 0, 1, new float[] { 1, 0, 1, 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(1, 0, 1, new float[] {}, new float[] {})]
		public void Remove_SingleVector_ReturnsDecreasedArray(float x, float y, float z, float[] points, float[] expectedPoints) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3[] expected = this.CreateVector3Array(expectedPoints);
			Vector3 point = new Vector3(x, y, z);
			
			curve.Remove(point);
			
			Assert.Equal(expected, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.RemoveAt(int)"/> functionality.
		/// Removes a point from a given index from the already established curve and checks to see if it returns the correct array
		/// </summary>
		[Theory]
		[InlineData(1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		[InlineData(-1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(0, new float[] { 0, 0, 0 }, new float[] {})]
		[InlineData(0, new float[] {}, new float[] {})]
		public void RemoveAt_SingleInteger_ReturnsDecreasedArray(int index, float[] points, float[] expectedPoints) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3[] expected = this.CreateVector3Array(expectedPoints);
			
			curve.RemoveAt(index);
			
			Assert.Equal(expected, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Insert(int, Vector3)"/> functionality.
		/// Inserts a points into a given index from an already established curve and checks to see if it returns the correct array
		/// </summary>
		[Theory]
		[InlineData(1, 0, 1, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1, 1, 0, 0 })]
		[InlineData(0, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		[InlineData(10, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1 })]
		[InlineData(-1, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		[InlineData(1, 0, 1, 1, new float[] {}, new float[] { 0, 1, 1 })]
		public void Insert_SingleVector_ReturnsIncreasedArray(int index, float x, float y, float z, float[] points, float[] expectedPoints) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3[] expected = this.CreateVector3Array(expectedPoints);
			Vector3 point = new Vector3(x, y, z);
			
			curve.Insert(index, point);
			
			Assert.Equal(expected, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.IndexOf(Vector3)"/> functionality.
		/// Finds the index of a point using an index and checks if its the correct index
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(2, 0, 1, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(-1, 0, 2, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void IndexOf_SingleVector_ReturnsIndex(int expected, float x, float y, float z, float[] points) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3 point = new Vector3(x, y, z);
			int actual = curve.IndexOf(point);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Clear"/> functionality.
		/// Clears the entire curve and checks if the array is empty
		/// </summary>
		[Theory]
		[InlineData(new float[] { 0, 0, 0, 1, 2, 3 })]
		[InlineData(new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		[InlineData(new float[] { 0, 0, 0, 0, 0, 1 })]
		[InlineData(new float[] { 0, 0, 1 })]
		[InlineData(new float[] {})]
		public void Clear_ReturnsEmptyArray(float[] points) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3[] expected = new Vector3[0];
			
			curve.Clear();
			
			Assert.Equal(expected, curve.Points);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.BezierCurve.Contains(Vector3)"/> functionality.
		/// Finds if a point 
		/// </summary>
		[Theory]
		[InlineData(true, 0, 0, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(true, 0, 1, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(false, 0, 2, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void Contains_ReturnsBoolean(bool expected, float x, float y, float z, float[] points) {
			// Variables
			BezierCurve curve = this.CreateBezierCurve(1.0f, points);
			Vector3 point = new Vector3(x, y, z);
			bool actual = curve.Contains(point);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
		
		#region Private Methods
		
		private Vector3[] CreateVector3Array(params float[] points) {
			// Variables
			Vector3[] vertices = new Vector3[points.Length / 3];
			for(int i = 0; i < vertices.Length; i++) {
				vertices[i] = new Vector3(points[3 * i], points[3 * i + 1], points[3 * i + 2]);
			}
			
			return vertices;
		}
		
		private BezierCurve CreateBezierCurve(float duration, params float[] points) {
			// Variables
			Vector3[] vertices = this.CreateVector3Array(points);
			
			return new BezierCurve(duration, vertices);
		}
		
		#endregion // Private Methods
	}
}

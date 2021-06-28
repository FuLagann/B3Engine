
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Spline"/> class to make sure it works correctly. Contains 67 tests</summary>
	public class SplineTest {
		#region Public Test Data
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Duration"/> functionality.
		/// Creates a spline and checks to see if the duration is correct
		/// </summary>
		[Fact]
		public void Duration_ReturnsFloat() {
			// Variables
			Spline spline = this.CreateDefaultSpline();
			float expected = 10.0f;
			float actual = spline.Duration;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Points"/> functionality.
		/// Creates a spline and checks to see if the points are correct
		/// </summary>
		[Fact]
		public void Points_ReturnsVector3Array() {
			// Variables
			Spline spline = this.CreateDefaultSpline();
			Vector3[] expected = new Vector3[] {
				new Vector3(0, 0, 0),
				new Vector3(1, 0, 0),
				new Vector3(1, 1, 0),
				new Vector3(1, 1, 1)
			};
			Vector3[] actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Value"/> functionality.
		/// Gets the value using a linear spline and checks to see if it's correct
		/// </summary>
		[Theory]
		#region Value_Linear_ReturnsVector3 Test Data
		[InlineData(0, 0f, 0f, 0f)]
		[InlineData(0.08333334, 0.5833334f, 0f, 0f)]
		[InlineData(0.1666667, 1f, 0.16666687f, 0f)]
		[InlineData(0.25, 1f, 0.75f, 0f)]
		[InlineData(0.3333333, 1f, 1.1666666f, 0.33333325f)]
		[InlineData(0.4166667, 1f, 1.4583334f, 0.91666675f)]
		[InlineData(0.5, 1f, 1.25f, 1.5f)]
		[InlineData(0.5833334, 1f, 0.9166665f, 2f)]
		[InlineData(0.6666667, 1f, 0.33333302f, 2f)]
		[InlineData(0.75, 0.75f, 0f, 2f)]
		[InlineData(0.8333334, 0.16666651f, 0f, 2f)]
		[InlineData(0.9166667, 0f, 0.41666698f, 2f)]
		[InlineData(1, 0f, 1f, 2f)]
		#endregion // Value_Linear_ReturnsVector3 Test Data
		public void Value_Linear_ReturnsVector3(float time, float ex, float ey, float ez) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			float[] vertices = this.GetVertexSetA();
			Spline spline = this.CreateSpline(4.0f, vertices);
			Vector3 actual;
			
			spline.Time = time;
			spline.SplineType = SplineType.Linear;
			actual = spline.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Value"/> functionality.
		/// Gets the value using a Catmull-Rom spline that doesn't loop around and checks to see if it's correct
		/// </summary>
		[Theory]
		#region Value_CatmullRomNoLoop_ReturnsVector3 Test Data
		[InlineData(0, 0f, 0f, 0f)]
		[InlineData(0.08333334, 0.60358804f, -0.07089121f, 0f)]
		[InlineData(0.1666667, 1.0578704f, 0.11458351f, -0.011574099f)]
		[InlineData(0.25, 1.0234375f, 0.76171875f, -0.070312515f)]
		[InlineData(0.3333333, 0.9999999f, 1.2407405f, 0.25925902f)]
		[InlineData(0.4166667, 1.0000001f, 1.4949365f, 0.9134839f)]
		[InlineData(0.5, 1f, 1.34375f, 1.5624999f)]
		[InlineData(0.5833334, 1.0031829f, 0.9309895f, 2.0350115f)]
		[InlineData(0.6666667, 1.0740741f, 0.27777785f, 2.0370374f)]
		[InlineData(0.75, 0.80859387f, -0.070312485f, 2.0234375f)]
		[InlineData(0.8333334, 0.1493054f, -0.01157406f, 2.0578704f)]
		[InlineData(0.9166667, -0.26909727f, 0f, 1.6035879f)]
		[InlineData(1, -0.5f, 0f, 1f)]
		#endregion // Value_CatmullRomNoLoop_ReturnsVector3 Test Data
		public void Value_CatmullRomNoLoop_ReturnsVector3(float time, float ex, float ey, float ez) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			float[] vertices = this.GetVertexSetB();
			Spline spline = this.CreateSpline(4.0f, vertices);
			Vector3 actual;
			
			spline.Time = time;
			spline.SplineType = SplineType.CatmullRom;
			actual = spline.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Value"/> functionality.
		/// Gets the value using a Catmull-Rom spline that loops around and checks to see if it's correct
		/// </summary>
		[Theory]
		#region Value_CatmullRomFullLoop_ReturnsVector3 Test Data
		[InlineData(0, 0f, 0f, 0f)]
		[InlineData(0.08333334, 0.60358804f, -0.07089121f, -0.10127312f)]
		[InlineData(0.1666667, 1.0578704f, 0.11458351f, -0.011574099f)]
		[InlineData(0.25, 1.0234375f, 0.76171875f, -0.070312515f)]
		[InlineData(0.3333333, 0.9999999f, 1.2407405f, 0.25925902f)]
		[InlineData(0.4166667, 1.0000001f, 1.4949365f, 0.9134839f)]
		[InlineData(0.5, 1f, 1.34375f, 1.5624999f)]
		[InlineData(0.5833334, 1.0031829f, 0.9309895f, 2.0350115f)]
		[InlineData(0.6666667, 1.0740741f, 0.27777785f, 2.0370374f)]
		[InlineData(0.75, 0.7968751f, -0.070312485f, 2.046875f)]
		[InlineData(0.8333334, 0.12037024f, -0.01157406f, 2.1157408f)]
		[InlineData(0.9166667, -0.0708912f, 0f, 1.2071757f)]
		[InlineData(1, 0f, 0f, 0f)]
		#endregion // Value_CatmullRomFullLoop_ReturnsVector3 Test Data
		public void Value_CatmullRomFullLoop_ReturnsVector3(float time, float ex, float ey, float ez) {
			// Variables
			Vector3 expected = new Vector3(ex, ey, ez);
			float[] vertices = this.GetVertexSetC();
			Spline spline = this.CreateSpline(4.0f, vertices);
			Vector3 actual;
			
			spline.Time = time;
			spline.SplineType = SplineType.CatmullRom;
			spline.LoopType = InterpolationLoopType.FullLoop;
			actual = spline.Value;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Add(Vector3)"/> functionality.
		/// Adds a vector to the spline and checks to see if the points are correct
		/// </summary>
		[Theory]
		[InlineData(0, 0, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		[InlineData(0, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 1 })]
		[InlineData(0, 0, 1, new float[] {}, new float[] { 0, 0, 1 })]
		public void Add_Vector3_ReturnsVector3Array(float x, float y, float z, float[] vertices, float[] expectedVertices) {
			// Variables
			Vector3[] expected = this.ConvertFloatArrayToVector3Array(expectedVertices);
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3 vector = new Vector3(x, y, z);
			Vector3[] actual;
			
			spline.Add(vector);
			actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Remove(Vector3)"/> functionality.
		/// Removes a vector from the spline and checks to see if the points are correct
		/// </summary>
		[Theory]
		[InlineData(1, 0, 1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		[InlineData(1, 0, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(1, 0, 1, new float[] {}, new float[] {})]
		public void Remove_Vector3_ReturnsVector3Array(float x, float y, float z, float[] vertices, float[] expectedVertices) {
			// Variables
			Vector3[] expected = this.ConvertFloatArrayToVector3Array(expectedVertices);
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3 vector = new Vector3(x, y, z);
			Vector3[] actual;
			
			spline.Remove(vector);
			actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.RemoveAt(int)"/> functionality.
		/// Removes a point using an index from the spline and checks to see if the points are correct
		/// </summary>
		[Theory]
		[InlineData(1, new float[] { 0, 0, 0, 1, 0, 1 }, new float[] { 0, 0, 0 })]
		[InlineData(-1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0 })]
		[InlineData(0, new float[] {}, new float[] {})]
		public void RemoveAt_Int32Index_ReturnsVector3Array(int index, float[] vertices, float[] expectedVertices) {
			// Variables
			Vector3[] expected = this.ConvertFloatArrayToVector3Array(expectedVertices);
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3[] actual;
			
			spline.RemoveAt(index);
			actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Insert(int, Vector3)"/> functionality.
		/// Inserts a vector into the spline and checks to see if the points are correct
		/// </summary>
		[Theory]
		[InlineData(1, 0, 1, 1, new float[] { 0, 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1, 1, 0, 0 })]
		[InlineData(0, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		[InlineData(10, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 0, 0, 0, 1, 1 })]
		[InlineData(-1, 0, 1, 1, new float[] { 0, 0, 0 }, new float[] { 0, 1, 1, 0, 0, 0 })]
		[InlineData(1, 0, 1, 1, new float[] {}, new float[] { 0, 1, 1 })]
		public void Insert_Int32IndexAndVector_ReturnsVector3Array(int index, float x, float y, float z, float[] vertices, float[] expectedVertices) {
			// Variables
			Vector3[] expected = this.ConvertFloatArrayToVector3Array(expectedVertices);
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3 vector = new Vector3(x, y, z);
			Vector3[] actual;
			
			spline.Insert(index, vector);
			actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.IndexOf(Vector3)"/> functionality.
		/// Finds the index of a point in the spline and checks if the index is correct
		/// </summary>
		[Theory]
		#region IndexOf_Vector_ReturnsInt32 Test Data
		[InlineData(
			0, 0, 0, 0,
			new float[] {
				0, 0, 0,
				1, 0, 0,
				0, 1, 0,
				0, 0, 1
			}
		)]
		[InlineData(
			2, 0, 1, 0,
			new float[] {
				0, 0, 0,
				1, 0, 0,
				0, 1, 0,
				0, 0, 1
			}
		)]
		[InlineData(
			-1, 0, 2, 0,
			new float[] {
				0, 0, 0,
				1, 0, 0,
				0, 1, 0,
				0, 0, 1
			}
		)]
		#endregion // IndexOf_Vector_ReturnsInt32 Test Data
		public void IndexOf_Vector_ReturnsInt32(int expected, float x, float y, float z, float[] vertices) {
			// Variables
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3 vector = new Vector3(x, y, z);
			int actual = spline.IndexOf(vector);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Clear"/> functionality.
		/// Clears all the points in the spline and checks to see if it's empty
		/// </summary>
		[Theory]
		[InlineData(new float[] { 0, 0, 0, 1, 2, 3 })]
		[InlineData(new float[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 })]
		[InlineData(new float[] { 0, 0, 0, 0, 0, 1 })]
		[InlineData(new float[] { 0, 0, 1 })]
		[InlineData(new float[] {})]
		public void Clear_ReturnsEmptyArray(float[] vertices) {
			// Variables
			Vector3[] expected = new Vector3[0];
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3[] actual;
			
			spline.Clear();
			actual = spline.Points;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Spline.Contains(Vector3)"/> functionality.
		/// Checks to see if the point is contained within the spline or not
		/// </summary>
		[Theory]
		[InlineData(true, 0, 0, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(true, 0, 1, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		[InlineData(false, 0, 2, 0, new float[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void Contains_Vector3_ReturnsBoolean(bool expected, float x, float y, float z, float[] vertices) {
			// Variables
			Spline spline = this.CreateSpline(10.0f, vertices);
			Vector3 vector = new Vector3(x, y, z);
			bool actual = spline.Contains(vector);
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Data
		
		#region Private Methods
		
		private Spline CreateDefaultSpline() {
			return this.CreateSpline(
				10,
				0, 0, 0,
				1, 0, 0,
				1, 1, 0,
				1, 1, 1
			);
		}
		
		private Vector3[] ConvertFloatArrayToVector3Array(params float[] vertices) {
			// Variables
			Vector3[] points = new Vector3[vertices.Length / 3];
			for(int i = 0; i < points.Length; i++) {
				points[i] = new Vector3(vertices[3 * i], vertices[3 * i + 1], vertices[3 * i + 2]);
			}
			
			return points;
		}
		
		private Spline CreateSpline(float duration, params float[] vertices) {
			// Variables
			Vector3[] points = this.ConvertFloatArrayToVector3Array(vertices);
			
			return new Spline(duration, points);
		}
		
		private float[] GetVertexSetA() {
			return new float[] {
				0f, 0f, 0f,
				1f, 0f, 0f,
				1f, 1f, 0f,
				1f, 1.5f, 1f,
				1f, 1f, 2f,
				1f, 0f, 2f,
				0f, 0f, 2f,
				0f, 1f, 2f
			};
		}
		
		private float[] GetVertexSetB() {
			return new float[] {
				0f, 0f, 0f,
				1f, 0f, 0f,
				1f, 1f, 0f,
				1f, 1.5f, 1f,
				1f, 1f, 2f,
				1f, 0f, 2f,
				0f, 0f, 2f,
				-0.5f, 0f, 1f
			};
		}
		
		private float[] GetVertexSetC() {
			return new float[] {
				0f, 0f, 0f,
				1f, 0f, 0f,
				1f, 1f, 0f,
				1f, 1.5f, 1f,
				1f, 1f, 2f,
				1f, 0f, 2f,
				0f, 0f, 2f
			};
		}
		
		#endregion // Private Methods
	}
}

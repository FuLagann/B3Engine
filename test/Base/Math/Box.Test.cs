
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Box"/> structure to make sure it works correctly. Contains 45 tests</summary>
	public class BoxTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Left"/> functionality.
		/// Creates a box and checks to see if the proprety is correct
		/// </summary>
		[Fact]
		public void Left_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(10, box.Left);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Right"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void Right_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(50, box.Right);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Top"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void Top_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(-20, box.Top);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Bottom"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void Bottom_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(30, box.Bottom);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Near"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void Near_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(-30, box.Near);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Far"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void Far_ReturnsFloat() {
			// Variables
			Box box = this.CreateDefaultBox();
			
			Assert.Equal(30, box.Far);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.NearTopLeft"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void NearTopLeft_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(10, -20, -30);
			
			Assert.Equal(expected, box.NearTopLeft);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.FarTopLeft"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void FarTopLeft_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(10, -20, 30);
			
			Assert.Equal(expected, box.FarTopLeft);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.NearTopRight"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void NearTopRight_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(50, -20, -30);
			
			Assert.Equal(expected, box.NearTopRight);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.FarTopRight"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void FarTopRight_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(50, -20, 30);
			
			Assert.Equal(expected, box.FarTopRight);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.NearBottomLeft"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void NearBottomLeft_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(10, 30, -30);
			
			Assert.Equal(expected, box.NearBottomLeft);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.FarBottomLeft"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void FarBottomLeft_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(10, 30, 30);
			
			Assert.Equal(expected, box.FarBottomLeft);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.NearBottomRight"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void NearBottomRight_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(50, 30, -30);
			
			Assert.Equal(expected, box.NearBottomRight);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.FarBottomRight"/> functionality.
		/// Creates a box and checks to see if the  property is correct
		/// </summary>
		[Fact]
		public void FarBottomRight_ReturnsVector3() {
			// Variables
			Box box = this.CreateDefaultBox();
			Vector3 expected = new Vector3(50, 30, 30);
			
			Assert.Equal(expected, box.FarBottomRight);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.Encompass(Box, Box)"/> functionality.
		/// Creates a box that encompasses two boxes and checks to see to see if its correct
		/// </summary>
		[Theory]
		#region Encompass_TwoBoxes_ReturnsBox Test Data
		[InlineData(
			0, 0, 0, 1, 1, 1,
			5, 5, 5, 2, 2, 2,
			0, 0, 0, 7, 7, 7
		)]
		[InlineData(
			-3.7, -1.7, -1.7, 11.1, 1.6, 1.7,
			2.1, 2.7, -5.1, 0.6, 1, 17,
			-3.7, -1.7, -5.1, 11.1, 5.4, 17
		)]
		[InlineData(
			-0.5, -0.5, -0.5, 2, 2, 2,
			1.5, 1.5, 1.5, -2, -2, -2,
			-0.5, -0.5, -0.5, 2, 2, 2
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, -1, -1, 2, 2, 2,
			-1, -1, -1, 2, 2, 2
		)]
		[InlineData(
			0, 0, 0, 100, 100, 100,
			20, 20, 20, 50, 50, 50,
			0, 0, 0, 100, 100, 100
		)]
		#endregion // Encompass_TwoBoxes_ReturnsBox Test Data
		public void Encompass_TwoBoxes_ReturnsBox(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			float ex, float ey, float ez, float ew, float eh, float ed
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box expected = new Box(ex, ey, ez, ew, eh, ed);
			Box actual = Box.Encompass(a, b);
			// TODO: Add a a.Encompass(b) method
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.EncompassRange(Box[])"/> functionality.
		/// Creates a box that encompasses multiple boxes and checks to see if its correct
		/// </summary>
		[Theory]
		#region EncompassRange_ThreeBoxes_ReturnsBox Test Data
		[InlineData(
			0, 0, 0, 1, 1, 1,
			1.5, 0.6, -0.2, 2, 2, 2,
			1.6, -3.4, 0.2, 2.4, 6.8, 2,
			0, -3.4, -0.2, 4.0, 6.8, 2.4
		)]
		[InlineData(
			-2, 7, 4, 14, 2, 2,
			7, -2, 7, 2, 14, 2,
			4, 4, -2, 2, 2, 14,
			-2, -2, -2, 14, 14, 14
		)]
		[InlineData(
			-2, 6.7, 4, 14, 2.6, 2,
			14, -2, 7, -12, 14, 2,
			14.2, 7.6, -2, -20, 2, 14,
			-5.8, -2, -2, 20, 14, 14
		)]
		[InlineData(
			0, 0, 0, 2, 2, 2,
			-2, 0.1, -3.7, 1.2, 0.8, 3.6,
			-4, -4, -4, 8, 8, 8,
			-4, -4, -4, 8, 8, 8
		)]
		#endregion // EncompassRange_ThreeBoxes_ReturnsBox Test Data
		public void EncompassRange_ThreeBoxes_ReturnsBox(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			float cx, float cy, float cz, float cw, float ch, float cd,
			float ex, float ey, float ez, float ew, float eh, float ed
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box c = new Box(cx, cy, cz, cw, ch, cd);
			Box expected = new Box(ex, ey, ez, ew, eh, ed);
			Box actual = Box.EncompassRange(a, b, c);
			// TODO: Add a a.EncompassRange(b, c) method
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.IsOverlapping(Box)"/> functionality.
		/// Uses two boxes to check to see if there is an overlap or not
		/// </summary>
		[Theory]
		#region IsOverlapping_TwoBoxes_ReturnsBoolean Test Data
		[InlineData(
			-5.7, 8.8, 3.8, 9.4, 3.2, 3.7,
			1.8, -3, 6, 8.1, 12.8, 2, true
		)]
		[InlineData(
			-5.7, 5.6, 3.8, 9.4, 7.3, 3.7,
			6.5, 5.7, 10.9, -7.7, 3.1, -12.3, true
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1, -1, 4, 4, 4, true
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1.1, -1, 4, 4, 4, false
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			0, 0, 0, 2, 2, 2, true
		)]
		#endregion // IsOverlapping_TwoBoxes_ReturnsBoolean Test Data
		public void IsOverlapping_TwoBoxes_ReturnsBoolean(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			bool expected
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			bool actual = a.IsOverlapping(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Box.IsContained(Box)"/> functionality.
		/// Uses two boxes to check to see if one box is contained within another
		/// </summary>
		[Theory]
		#region IsContained_TwoBoxes_ReturnsBoolean Test Data
		[InlineData(
			-5.7, 8.8, 3.8, 9.4, 3.2, 3.7,
			1.8, -3, 6, 8.1, 12.8, 2, false
		)]
		[InlineData(
			-5.7, 5.6, 3.8, 9.4, 7.3, 3.7,
			6.5, 5.7, 10.9, -7.7, 3.1, -12.3, false
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1, -1, 4, 4, 4, false
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1.1, -1, 4, 4, 4, false
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			0, 0, 0, 2, 2, 2, true
		)]
		[InlineData(
			6, 6, 6, -8, -8, -8,
			0, 0, 0, 2, 2, 2, true
		)]
		#endregion // IsContained_TwoBoxes_ReturnsBoolean Test Data
		public void IsContained_TwoBoxes_ReturnsBoolean(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			bool expected
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			bool actual = a.IsContained(b);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region IsDisjoint_TwoBoxes_ReturnsBoolean Test Data
		[InlineData(
			-5.7, 8.8, 3.8, 9.4, 3.2, 3.7,
			1.8, -3, 6, 8.1, 12.8, 2, false
		)]
		[InlineData(
			-5.7, 5.6, 3.8, 9.4, 7.3, 3.7,
			6.5, 5.7, 10.9, -7.7, 3.1, -12.3, false
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1, -1, 4, 4, 4, false
		)]
		[InlineData(
			-1, -1, -1, 2, 2, 2,
			-1, 1.1, -1, 4, 4, 4, true
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			0, 0, 0, 2, 2, 2, false
		)]
		#endregion // IsDisjoint_TwoBoxes_ReturnsBoolean Test Data
		public void IsDisjoint_TwoBoxes_ReturnsBoolean(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			bool expected
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			bool actual = a.IsDisjoint(b);
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Clip_TwoBoxes_ReturnsBox Test Data
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			0, 0, 0, 2, 2, 2,
			0, 0, 0, 2, 2, 2
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			3, 2.6, 2.5, 2, 2, 2,
			3, 2.6, 2.5, 1, 1.4000001, 1.5 // Floating-point rounding error here
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			-5, 3, -1.5, 2, 2, 2,
			-4, 3, -1.5, 1, 1, 2
		)]
		[InlineData(
			-4, -4, -4, 8, 8, 8,
			-7.1, -0.9, -5.6, 2, 2, 2,
			-4, -0.9, -4, 0, 2, 0.4000001 // Floating-point rounding error here
		)]
		#endregion // Clip_TwoBoxes_ReturnsBox Test Data
		public void Clip_TwoBoxes_ReturnsBox(
			float ax, float ay, float az, float aw, float ah, float ad,
			float bx, float by, float bz, float bw, float bh, float bd,
			float ex, float ey, float ez, float ew, float eh, float ed
		) {
			// Variables
			Box a = new Box(ax, ay, az, aw, ah, ad);
			Box b = new Box(bx, by, bz, bw, bh, bd);
			Box expected = new Box(ex, ey, ez, ew, eh, ed);
			Box actual = Box.Clip(a, b);
			// TODO: Add a.Clip(b) method
			
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		#region Scale_VectorAndBox_ReturnsBox Test Data
		[InlineData(
			2, 0.5, -2,
			4, 5, 6, 7, 8, 9,
			4, 5, 6, 14, 4, -18
		)]
		[InlineData(
			0, 1, -2,
			1, 2, 3, 1, 2, 3,
			1, 2, 3, 0, 2, -6
		)]
		#endregion // Scale_VectorAndBox_ReturnsBox Test Data
		public void Scale_VectorAndBox_ReturnsBox(
			float widthScalar, float heightScalar, float depthScalar,
			float ax, float ay, float az, float aw, float ah, float ad,
			float ex, float ey, float ez, float ew, float eh, float ed
		) {
			// Variables
			Box box = new Box(ax, ay, az, aw, ah, ad);
			Vector3 scalar = new Vector3(widthScalar, heightScalar, depthScalar);
			Box expected = new Box(ex, ey, ez, ew, eh, ed);
			Box actual = Box.Scale(scalar, box);
			// TODO: Add scalar * box doesn't exist
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
		
		#region Private Methods
		
		private Box CreateDefaultBox() {
			return new Box(
				10, -20, 30,
				40, 50, -60
			);
		}
		
		#endregion // Private Methods
	}
}

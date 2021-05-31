
using Xunit;

namespace B3.Testing {
	// TRACK: 197 tests
	/// <summary>Tests the <see cref="B3.Color"/> structure to make sure it works correctly. Contains 58 tests</summary>
	public class ColorTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Color(float, float, float, float)"/> functionality.
		/// Creates a color using an sRGB system and checks to see if the returning bytes are correct
		/// </summary>
		[Fact]
		public void Constructor_SetFloat_ReturnsBytes() {
			// Variables
			Color color = new Color(0.15f, 0.25f, 0.99f, 0.5f);
			(byte, byte, byte, byte) expected = (38, 63, 252, 127);
			(byte, byte, byte, byte) actual = (
				color.R,
				color.G,
				color.B,
				color.A
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Color(int, int, int, int)"/> functionality.
		/// Creates a color using an 8 bit system and checks to see if the returning floats are correct
		/// </summary>
		[Fact]
		public void Constructor_SetInt32_ReturnsFloats() {
			// Variables
			Color color = new Color(102, 1, 254, 51);
			(float, float, float, float) expected = (0.4f, 0.003921569f, 0.99607843f, 0.2f);
			(float, float, float, float) actual = (
				color.Redf,
				color.Greenf,
				color.Bluef,
				color.Alphaf
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Color(int)"/> functionality.
		/// Creates a color using a single integer and checks to see if the returns bytes are correct
		/// </summary>
		[Fact]
		public void Constructor_SetSingleInt32_ReturnsBytes() {
			// Variables
			Color color = new Color(0x101820);
			(byte, byte, byte, byte) expected = (16, 24, 32, 255);
			(byte, byte, byte, byte) actual = (
				color.R,
				color.G,
				color.B,
				color.A
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Color(string)"/> functionality.
		/// Creates a color using a hex code or name of a color and checks to see if the bytes are correct
		/// </summary>
		/// <param name="hex">The hex code to create the color from</param>
		/// <param name="expectedRed">The expected red byte</param>
		/// <param name="expectedGreen">The expected green byte</param>
		/// <param name="expectedBlue">The expected blue byte</param>
		/// <param name="expectedAlpha">The expected alpha byte</param>
		[Theory]
		[InlineData("#101820", 16, 24, 32, 255)]
		[InlineData("#10182028", 16, 24, 32, 40)]
		[InlineData("#abc", 170, 187, 204, 255)]
		[InlineData("#abcd", 170, 187, 204, 221)]
		[InlineData("red", 255, 0, 0, 255)]
		[InlineData("GREEN", 0, 128, 0, 255)]
		[InlineData("BlUE", 0, 0, 255, 255)]
		[InlineData("paleturquoise", 175, 238, 238, 255)]
		[InlineData("not-a-color", 0, 0, 0, 255)]
		[InlineData("transparent", 0, 0, 0, 0)]
		public void Constructor_SetString_ReturnsBytes(string hex, byte expectedRed, byte expectedGreen, byte expectedBlue, byte expectedAlpha) {
			// Variables
			Color color = new Color(hex);
			(byte, byte, byte, byte) expected = (expectedRed, expectedGreen, expectedBlue, expectedAlpha);
			(byte, byte, byte, byte) actual = (
				color.R,
				color.G,
				color.B,
				color.A
			);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.ToHex"/> functionality.
		/// Converts a color into a string hex and checks to see if its correct
		/// </summary>
		/// <param name="r">The red byte to set</param>
		/// <param name="g">The green byte to set</param>
		/// <param name="b">The blue byte to set</param>
		/// <param name="a">The alpha byte to set</param>
		/// <param name="expected">The expected hex string to check with</param>
		[Theory]
		[InlineData(1, 2, 3, 255, "#010203")]
		[InlineData(16, 24, 32, 255, "#101820")]
		[InlineData(106, 180, 230, 255, "#6AB4E6")]
		[InlineData(16, 24, 32, 40, "#10182028")]
		public void ToHex_Bytes_ReturnsString(byte r, byte g, byte b, byte a, string expected) {
			// Variables
			Color color = new Color(r, g, b, a);
			string actual = color.ToHex();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Add(Color)"/> functionality.
		/// Adds to colors together and checks to see if its correct
		/// </summary>
		/// <param name="colorA">The first color to add with</param>
		/// <param name="colorB">The second color to add with</param>
		/// <param name="expectedColorHex">The expected color to check with</param>
		[Theory]
		[InlineData("#000", "#fff", "#fff")]
		[InlineData("#fff", "#000", "#fff")]
		[InlineData("#123", "#123456", "#235689")]
		[InlineData("#eee", "#eee", "#fff")]
		public void Add_HexColors_ReturnsColor(string colorA, string colorB, string expectedColorHex) {
			// Variables
			Color left = new Color(colorA);
			Color right = new Color(colorB);
			Color expected = new Color(expectedColorHex);
			Color actual = left + right;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Subtract(Color)"/> functionality.
		/// Subtracts a color from another and chekcs to see if its correct
		/// </summary>
		/// <param name="colorA">The first color to subtract from</param>
		/// <param name="colorB">The second color to subtract with</param>
		/// <param name="expectedColorHex">The expected color to check with</param>
		[Theory]
		[InlineData("#000", "#fff", "#000")]
		[InlineData("#fff", "#000", "#fff")]
		[InlineData("#123456", "#123", "#011223")]
		public void Subtract_HexColors_ReturnsColor(string colorA, string colorB, string expectedColorHex) {
			// Variables
			Color left = new Color(colorA);
			Color right = new Color(colorB);
			Color expected = new Color(expectedColorHex);
			Color actual = left - right;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Invert"/> functionality.
		/// Inverts the color and checks to see if its correct
		/// </summary>
		/// <param name="colorHex">The color to invert</param>
		/// <param name="expectedHex">The expected color to check with</param>
		[Theory]
		[InlineData("#fff", "#000")]
		[InlineData("#123", "#edc")]
		[InlineData("#cd3131", "#32cece")]
		public void Invert_HexColors_ReturnsColor(string colorHex, string expectedHex) {
			// Variables
			Color color = new Color(colorHex);
			Color expected = new Color(expectedHex);
			Color actual = -color;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Grayscale"/> functionality.
		/// Converts the color to grayscale and checks to see if its correct
		/// </summary>
		/// <param name="colorHex">The color to grayscale</param>
		/// <param name="expectedHex">The expected color to check with</param>
		[Theory]
		[InlineData("#777", "#777")]
		[InlineData("#123456", "#343434")]
		[InlineData("#123", "#222")]
		[InlineData("#6ab4e6", "#acacac")]
		public void Grayscale_HexColors_ReturnsColor(string colorHex, string expectedHex) {
			// Variables
			Color color = new Color(colorHex);
			Color expected = new Color(expectedHex);
			Color actual = color.Grayscale();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Brightness"/> functionality.
		/// Checks the brightness percentage and checks to see if its correct
		/// </summary>
		/// <param name="hex">The color to check the brightness</param>
		/// <param name="expected">The expected color to check with</param>
		[Theory]
		[InlineData("red", 0.2126f)]
		[InlineData("#000", 0.0f)]
		[InlineData("white", 1.0f)]
		[InlineData("#111", 0.005605392f)]
		[InlineData("#d24d5e", 0.19817546f)]
		[InlineData("#123", 0.015022418f)]
		[InlineData("yellow", 0.9278f)]
		public void Brightness_HexColors_ReturnsFloat(string hex, float expected) {
			// Variables
			Color color = new Color(hex);
			float actual = color.Brightness();
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Contrast(Color)"/> functionality.
		/// Gets the contrast ratio of the two colors and checks to see if its correct
		/// </summary>
		/// <param name="hexA">The first color to contrast with</param>
		/// <param name="hexB">The second color to contrast with</param>
		/// <param name="expected">The expected color to check with</param>
		[Theory]
		[InlineData("red", "green", 1.2848399f)]
		[InlineData("orange", "darkslateblue", 4.591844f)]
		[InlineData("blue", "blue", 1.0f)]
		[InlineData("white", "black", 20.999998f)]
		[InlineData("#6ab4e6", "black", 9.283972f)]
		public void Contrast_HexColors_ReturnsFloat(string hexA, string hexB, float expected) {
			// Variables
			Color a = new Color(hexA);
			Color b = new Color(hexB);
			float actual = a.Contrast(b);
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Multiply(float)"/> functionality.
		/// Multiplies the color with a scalar and checks to see if its correct
		/// </summary>
		/// <param name="scalar">The scalar used to multiply the color with</param>
		/// <param name="hex">The color to multiply with</param>
		/// <param name="expectedHex">The expected color to check with</param>
		[Theory]
		[InlineData(1.0f, "#508", "#508")]
		[InlineData(2.0f, "#123", "#246")]
		[InlineData(0.1f, "#59a", "#080f11")]
		[InlineData(4.5f, "#101820", "#486c90")]
		[InlineData(5.0f, "#b2b", "#faf")]
		public void Multiply_ScalarHexColors_ReturnsColor(float scalar, string hex, string expectedHex) {
			// Variables
			Color color = new Color(hex);
			Color expected = new Color(expectedHex);
			Color actual = scalar * color;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Color.Divide(float)"/> functionality.
		/// Divides the color with a scalar and checks to see if its color
		/// </summary>
		/// <param name="hex">The color used to divide with</param>
		/// <param name="scalar">The scalar used to divide the color with</param>
		/// <param name="expectedHex">The expected color to check with</param>
		[Theory]
		[InlineData("#123", 1.0f, "#123")]
		[InlineData("#123", 2.0f, "#081119")]
		[InlineData("#123", 0.5f, "#246")]
		[InlineData("#918", 0.1f, "#faf")]
		public void Divide_ScalarHexColors_ReturnsColor(string hex, float scalar, string expectedHex) {
			// Variables
			Color color = new Color(hex);
			Color expected = new Color(expectedHex);
			Color actual = color / scalar;
			
			Assert.Equal(expected, actual);
		}
		
		#endregion // Public Test Methods
	}
}

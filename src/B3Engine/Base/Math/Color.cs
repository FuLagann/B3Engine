
using B3.Graphics;

using System.Runtime.InteropServices;

namespace B3 {
	/// <summary>A structure for color with floats going from 0 to 1</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Color : IVertexAttributable, System.IEquatable<Color> {
		#region Field Variables
		// Variables
		private float red;
		private float green;
		private float blue;
		private float alpha;
		/// <summary>The color white (#FFFFFF)</summary>
		public static readonly Color White = new Color(0xffffff);
		/// <summary>The color black (#000000)</summary>
		public static readonly Color Black = new Color(0x000000);
		/// <summary>The color red (#FF0000)</summary>
		public static readonly Color Red = new Color(0xff0000);
		/// <summary>The color green (#00FF00)</summary>
		public static readonly Color Green = new Color(0x00ff00);
		/// <summary>The color blue (#0000FF)</summary>
		public static readonly Color Blue = new Color(0x0000ff);
		/// <summary>The color yellow (#FFFF00)</summary>
		public static readonly Color Yellow = new Color(0xffff00);
		/// <summary>The color cyan (#00FFFF)</summary>
		public static readonly Color Cyan = new Color(0x00ffff);
		/// <summary>The color magenta (#FF00FF)</summary>
		public static readonly Color Magenta = new Color(0xff00ff);
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the red channel in byte form</summary>
		public byte R { get { return (byte)(255.5f * this.red); } set { this.red = value; } }
		
		/// <summary>Gets and sets the green channel in byte form</summary>
		public byte G { get { return (byte)(255.5f * this.green); } set { this.green = value; } }
		
		/// <summary>Gets and sets the blue channel in bytre form</summary>
		public byte B { get { return (byte)(255.5f * this.blue); } set { this.blue = value; } }
		
		/// <summary>Gets and sets the alpha channel in byte form</summary>
		public byte A { get { return (byte)(255.5f * this.alpha); } set { this.alpha = value; } }
		
		/// <summary>Gets and sets the red channel in float form (from 0 to 1)</summary>
		public float Redf { get { return this.red; } set { this.red = Mathx.Clamp(value, 0.0f, 1.0f); } }
		
		/// <summary>Gets and sets the green channel in float form (from 0 to 1)</summary>
		public float Greenf { get { return this.green; } set { this.green = Mathx.Clamp(value, 0.0f, 1.0f); } }
		
		/// <summary>Gets and sets the blue channel in float form (from 0 to 1)</summary>
		public float Bluef { get { return this.blue; } set { this.blue = Mathx.Clamp(value, 0.0f, 1.0f); } }
		
		/// <summary>Gets and sets the alpha channel in float form (from 0 to 1)</summary>
		public float Alphaf { get { return this.alpha; } set { this.alpha = Mathx.Clamp(value, 0.0f, 1.0f); } }
		
		#endregion // Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor where the red, green, blue, and alpha channels are set in integer form</summary>
		/// <param name="red">The red channel, with min being 0 and max being 255</param>
		/// <param name="green">The green channel, with min being 0 and max being 255</param>
		/// <param name="blue">The blue channel, with min being 0 and max being 255</param>
		/// <param name="alpha">The alpha channel, with min being 0 and max being 255</param>
		public Color(int red, int green, int blue, int alpha) {
			this.red = Mathx.Clamp(red / 255.0f, 0.0f, 1.0f);
			this.green = Mathx.Clamp(green / 255.0f, 0.0f, 1.0f);
			this.blue = Mathx.Clamp(blue / 255.0f, 0.0f, 1.0f);
			this.alpha = Mathx.Clamp(alpha / 255.0f, 0.0f, 1.0f);
		}
		
		/// <summary>A constructor where the red, green, and blue channels are set in integer form</summary>
		/// <param name="red">The red channel, with min being 0 and max being 255</param>
		/// <param name="green">The green channel, with min being 0 and max being 255</param>
		/// <param name="blue">The blue channel, with min being 0 and max being 255</param>
		public Color(int red, int green, int blue) : this(red, green, blue, 255) {}
		
		/// <summary>A base constructor where the red, green, and blue channels are set in hexidecimal form (0x123456)</summary>
		/// <param name="rgb">The red, green, and blue channels as a hexidecimal number (0x123456)</param>
		/// <param name="alpha">The alpha channel, with min being 0 and max being 255</param>
		public Color(int rgb, int alpha) {
			if(rgb > 0x01000000) {
				this.red = Mathx.Clamp(((byte)(rgb >> 24)) / 255.0f, 0.0f, 1.0f);
				this.green = Mathx.Clamp(((byte)(rgb >> 16)) / 255.0f, 0.0f, 1.0f);
				this.blue = Mathx.Clamp(((byte)(rgb >> 8)) / 255.0f, 0.0f, 1.0f);
				this.alpha = Mathx.Clamp(alpha / 255.0f, 0.0f, 1.0f);
			}
			else {
				this.red = Mathx.Clamp(((byte)(rgb >> 16)) / 255.0f, 0.0f, 1.0f);
				this.green = Mathx.Clamp(((byte)(rgb >> 8)) / 255.0f, 0.0f, 1.0f);
				this.blue = Mathx.Clamp(((byte)rgb) / 255.0f, 0.0f, 1.0f);
				this.alpha = Mathx.Clamp(alpha / 255.0f, 0.0f, 1.0f);
			}
		}
		
		/// <summary>A constructor where the red, green, and blue channels are set in hexidecimal form (0x123456)</summary>
		/// <param name="rgb">
		/// The red, green, and blue channels as a hexidecimal number (0x123456)
		/// with the alpha channel being 255
		/// </param>
		public Color(int rgb) : this(rgb, 255) {}
		
		/// <summary>A base constructor where the red, green, blue, and alpha channels are set in float form</summary>
		/// <param name="red">The red channel, with min being 0 and max being 1</param>
		/// <param name="green">The green channel, with min being 0 and max being 1</param>
		/// <param name="blue">The blue channel, with min being 0 and max being 1</param>
		/// <param name="alpha">The alpha channel, with min being 0 and max being 1</param>
		public Color(float red, float green, float blue, float alpha) {
			this.red = Mathx.Clamp(red, 0.0f, 1.0f);
			this.green = Mathx.Clamp(green, 0.0f, 1.0f);
			this.blue = Mathx.Clamp(blue, 0.0f, 1.0f);
			this.alpha = Mathx.Clamp(alpha, 0.0f, 1.0f);
		}
		
		/// <summary>A constructor where the red, green, and blue channels are set in float form</summary>
		/// <param name="red">The red channel, with min being 0 and max being 1</param>
		/// <param name="green">The green channel, with min being 0 and max being 1</param>
		/// <param name="blue">The blue channel, with min being 0 and max being 1</param>
		public Color(float red, float green, float blue) : this(red, green, blue, 1.0f) {}
		
		/// <summary>
		/// A base constructor where the red, green, and blue channels are set in hexidecimal form (#123456).
		/// Optionally an alpha channel can be added to the end of the hexidecimal number (#12345678)
		/// </summary>
		/// <param name="hex">
		/// The red, green, and blue channels as a hexidecimal number (#123456).
		/// Optionally an alpha channel can be added to the end of the hexidecimal number (#12345678).
		/// Omitting the alpha channel will set the alpha channel to 255
		/// </param>
		public Color(string hex) {
			if(!hex.StartsWith("#")) {
				throw new System.ArgumentOutOfRangeException("hex", hex, "The string must represent a hexidecimal color (#123456)");
			}
			
			// Variables
			int rgb;
			
			if(int.TryParse(hex, out rgb)) {
				if(rgb > 0x01000000) {
					this.red = Mathx.Clamp(((byte)(rgb >> 24)) / 255.0f, 0.0f, 1.0f);
					this.green = Mathx.Clamp(((byte)(rgb >> 16)) / 255.0f, 0.0f, 1.0f);
					this.blue = Mathx.Clamp(((byte)(rgb >> 8)) / 255.0f, 0.0f, 1.0f);
					this.alpha = Mathx.Clamp(((byte)rgb) / 255.0f, 0.0f, 1.0f);
				}
				else {
					this.red = Mathx.Clamp(((byte)(rgb >> 16)) / 255.0f, 0.0f, 1.0f);
					this.green = Mathx.Clamp(((byte)(rgb >> 8)) / 255.0f, 0.0f, 1.0f);
					this.blue = Mathx.Clamp(((byte)rgb) / 255.0f, 0.0f, 1.0f);
					this.alpha = 1.0f;
				}
			}
			else {
				throw new System.ArgumentOutOfRangeException("hex", hex, "The string must represent a hexidecimal color (#123456)");
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region Add Methods
		
		/// <summary>Adds the two colors together</summary>
		/// <param name="a">The first color to add with</param>
		/// <param name="b">The second color to add with</param>
		/// <param name="result">The resulting added color</param>
		public static void Add(ref Color a, ref Color b, out Color result) {
			result.red = Mathx.Min(a.red + b.red, 1.0f);
			result.green = Mathx.Min(a.green + b.green, 1.0f);
			result.blue = Mathx.Min(a.blue + b.blue, 1.0f);
			result.alpha = Mathx.Min(a.alpha + b.alpha, 1.0f);
		}
		
		/// <summary>Adds the two colors together</summary>
		/// <param name="a">The first color to add with</param>
		/// <param name="b">The second color to add with</param>
		/// <param name="result">The resulting added color</param>
		public static void Add(Color a, Color b, out Color result) { Add(ref a, ref b, out result); }
		
		/// <summary>Adds the two colors together</summary>
		/// <param name="a">The first color to add with</param>
		/// <param name="b">The second color to add with</param>
		/// <returns>Returns the resulting added color</returns>
		public static Color Add(ref Color a, ref Color b) {
			// Variables
			Color result;
			
			Add(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Adds the two colors together</summary>
		/// <param name="a">The first color to add with</param>
		/// <param name="b">The second color to add with</param>
		/// <returns>Returns the resulting added color</returns>
		public static Color Add(Color a, Color b) { return Add(ref a, ref b); }
		
		#endregion // Add Methods
		
		#region Subtract Methods
		
		/// <summary>Subtracts the first color with the second color</summary>
		/// <param name="a">The first color to subtract with</param>
		/// <param name="b">The second color to subtract with</param>
		/// <param name="result">The resulting subtracted color</param>
		public static void Subtract(ref Color a, ref Color b, out Color result) {
			result.red = Mathx.Max(a.red - b.red, 0.0f);
			result.green = Mathx.Max(a.green - b.green, 0.0f);
			result.blue = Mathx.Max(a.blue - b.blue, 0.0f);
			result.alpha = a.alpha;
		}
		
		/// <summary>Subtracts the first color with the second color</summary>
		/// <param name="a">The first color to subtract with</param>
		/// <param name="b">The second color to subtract with</param>
		/// <param name="result">The resulting subtracted color</param>
		public static void Subtract(Color a, Color b, out Color result) { Subtract(ref a, ref b, out result); }
		
		/// <summary>Subtracts the first color with the second color</summary>
		/// <param name="a">The first color to subtract with</param>
		/// <param name="b">The second color to subtract with</param>
		/// <returns>The resulting subtracted color</returns>
		public static Color Subtract(ref Color a, ref Color b) {
			// Variables
			Color result;
			
			Subtract(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Subtracts the first color with the second color</summary>
		/// <param name="a">The first color to subtract with</param>
		/// <param name="b">The second color to subtract with</param>
		/// <returns>The resulting subtracted color</returns>
		public static Color Subtract(Color a, Color b) { return Subtract(ref a, ref b); }
		
		#endregion // Subtract Methods
		
		#region LerpClamped Methods
		
		/// <summary>Linearly interpolates between the two colors together</summary>
		/// <param name="a">The first color to linearly interpolate with</param>
		/// <param name="b">The second color to linearly interpolate with</param>
		/// <param name="t">The floating point number to give weight which color being a stronger linearly interpolate (goes from 0 to 1)</param>
		/// <param name="result">The resulting linearly interpolated color</param>
		public static void LerpClamped(ref Color a, ref Color b, float t, out Color result) {
			result.red = Mathx.LerpClamped(a.red, b.red, t);
			result.green = Mathx.LerpClamped(a.green, b.green, t);
			result.blue = Mathx.LerpClamped(a.blue, b.blue, t);
			result.alpha = Mathx.LerpClamped(a.alpha, b.alpha, t);
		}
		
		/// <summary>Linearly interpolates between the two colors together</summary>
		/// <param name="a">The first color to linearly interpolate with</param>
		/// <param name="b">The second color to linearly interpolate with</param>
		/// <param name="t">The floating point number to give weight which color being a stronger linearly interpolate (goes from 0 to 1)</param>
		/// <param name="result">The resulting linearly interpolated color</param>
		public static void LerpClamped(Color a, Color b, float t, out Color result) { LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the two colors together</summary>
		/// <param name="a">The first color to linearly interpolate with</param>
		/// <param name="b">The second color to linearly interpolate with</param>
		/// <param name="t">The floating point number to give weight which color being a stronger linearly interpolate (goes from 0 to 1)</param>
		/// <returns>Returns the resulting linearly interpolated color</returns>
		public static Color LerpClamped(ref Color a, ref Color b, float t) {
			// Variables
			Color result;
			
			LerpClamped(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates between the two colors together</summary>
		/// <param name="a">The first color to linearly interpolate with</param>
		/// <param name="b">The second color to linearly interpolate with</param>
		/// <param name="t">The floating point number to give weight which color being a stronger linearly interpolate (goes from 0 to 1)</param>
		/// <returns>Returns the resulting linearly interpolated color</returns>
		public static Color LerpClamped(Color a, Color b, float t) { return LerpClamped(ref a, ref b, t); }
		
		#endregion // LerpClamped Methods
		
		#region Grayscale Methods
		
		/// <summary>Creates a grayscale version of the color</summary>
		/// <param name="color">The color to grayscale</param>
		/// <param name="result">The resulting grayscaled color</param>
		public static void Grayscale(ref Color color, out Color result) {
			// Variables
			float grayscale = (color.red + color.green + color.blue) / 3.0f;
			
			result.red = grayscale; 
			result.green = grayscale; 
			result.blue = grayscale;
			result.alpha = color.alpha; 
		}
		
		/// <summary>Creates a grayscale version of the color</summary>
		/// <param name="color">The color to grayscale</param>
		/// <param name="result">The resulting grayscaled color</param>
		public static void Grayscale(Color color, out Color result) { Grayscale(ref color, out result); }
		
		/// <summary>Creates a grayscale version of the color</summary>
		/// <param name="color">The color to grayscale</param>
		/// <returns>Returns the resulting grayscaled color</returns>
		public static Color Grayscale(ref Color color) {
			// Variables
			Color result;
			
			Grayscale(ref color, out result);
			
			return result;
		}
		
		/// <summary>Creates a grayscale version of the color</summary>
		/// <param name="color">The color to grayscale</param>
		/// <returns>Returns the resulting grayscaled color</returns>
		public static Color Grayscale(Color color) { return Grayscale(ref color); }
		
		#endregion // Grayscale Methods
		
		#region Invert Methods
		
		/// <summary>Inverts the color</summary>
		/// <param name="color">The color to invert</param>
		/// <param name="result">The resulting inverted color</param>
		public static void Invert(ref Color color, out Color result) {
			result.red = 1.0f - color.red;
			result.green = 1.0f - color.green;
			result.blue = 1.0f - color.blue;
			result.alpha = color.alpha;
		}
		
		/// <summary>Inverts the color</summary>
		/// <param name="color">The color to invert</param>
		/// <param name="result">The resulting inverted color</param>
		public static void Invert(Color color, out Color result) { Invert(ref color, out result); }
		
		/// <summary>Inverts the color</summary>
		/// <param name="color">The color to invert</param>
		/// <returns>Returns the resulting inverted color</returns>
		public static Color Invert(ref Color color) {
			// Variables
			Color result;
			
			Invert(ref color, out result);
			
			return result;
		}
		
		/// <summary>Inverts the color</summary>
		/// <param name="color">The color to invert</param>
		/// <returns>Returns the resulting inverted color</returns>
		public static Color Invert(Color color) { return Invert(ref color); }
		
		#endregion // Invert Methods
		
		#region Multiply Methods
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="scalar">The floating point number to multiply the color with</param>
		/// <param name="color">The color to multiply with</param>
		/// <param name="result">The resulting scaled color</param>
		public static void Multiply(float scalar, ref Color color, out Color result) {
			result.red = Mathx.Clamp(scalar * color.red, 0.0f, 1.0f);
			result.green = Mathx.Clamp(scalar * color.green, 0.0f, 1.0f);
			result.blue = Mathx.Clamp(scalar * color.blue, 0.0f, 1.0f);
			result.alpha = color.alpha;
		}
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="scalar">The floating point number to multiply the color with</param>
		/// <param name="color">The color to multiply with</param>
		/// <param name="result">The resulting scaled color</param>
		public static void Multiply(float scalar, Color color, out Color result) { Multiply(scalar, ref color, out result); }
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="scalar">The floating point number to multiply the color with</param>
		/// <param name="color">The color to multiply with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color Multiply(float scalar, ref Color color) {
			// Variables
			Color result;
			
			Multiply(scalar, ref color, out result);
			
			return result;
		}
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="scalar">The floating point number to multiply the color with</param>
		/// <param name="color">The color to multiply with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color Multiply(float scalar, Color color) { return Multiply(scalar, ref color); }
		
		#endregion // Multiply Methods
		
		#region Divide Methods
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="scalar">The floating point number to divide the color with</param>
		/// <param name="color">The color to divide with</param>
		/// <param name="result">The resulting scaled color</param>
		public static void Divide(float scalar, ref Color color, out Color result) { Multiply(1.0f / scalar, ref color, out result); }
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="scalar">The floating point number to divide the color with</param>
		/// <param name="color">The color to divide with</param>
		/// <param name="result">The resulting scaled color</param>
		public static void Divide(float scalar, Color color, out Color result) { Divide(scalar, ref color, out result); }
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="scalar">The floating point number to divide the color with</param>
		/// <param name="color">The color to divide with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color Divide(float scalar, ref Color color) {
			// Variables
			Color result;
			
			Divide(scalar, ref color, out result);
			
			return result;
		}
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="scalar">The floating point number to divide the color with</param>
		/// <param name="color">The color to divide with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color Divide(float scalar, Color color) { return Divide(scalar, ref color); }
		
		#endregion // Divide Methods
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Adds this color with the other color</summary>
		/// <param name="other">The other color to add with</param>
		/// <returns>Returns the resulting added color</returns>
		public Color Add(Color other) { return Add(ref this, ref other); }
		
		/// <summary>Subtracts the this color with the other color</summary>
		/// <param name="other">The other color to subtract with</param>
		/// <returns>The resulting subtracted color</returns>
		public Color Subtract(Color other) { return Subtract(ref this, ref other); }
		
		/// <summary>Linearly interpolates between the this color with another color</summary>
		/// <param name="other">The other color to linearly interpolate with</param>
		/// <param name="t">The floating point number to give weight which color being a stronger linearly interpolate (goes from 0 to 1)</param>
		/// <returns>Returns the resulting linearly interpolated color</returns>
		public Color LerpClamped(Color other, float t) { return LerpClamped(ref this, ref other, t); }
		
		/// <summary>Creates a grayscale version of this color</summary>
		/// <returns>Returns the resulting grayscale color</returns>
		public Color Grayscale() { return Grayscale(ref this); }
		
		/// <summary>Inverts the color</summary>
		/// <returns>Returns the resulting inverted color</returns> 
		public Color Invert() { return Invert(ref this); }
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="scalar">The floating point number to multiply the color with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public Color Multiply(float scalar) { return Multiply(scalar, ref this); }
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="scalar">The floating point number to divide the color with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public Color Divide(float scalar) { return Divide(scalar, ref this); }
		
		/// <summary>Gets the color in hexadecimal string form</summary>
		/// <returns>Returns the color in hexadecimal form</returns>
		public string ToHex() {
			if(this.A == 255) {
				return "#" + this.ToInt32().ToString("X6");
			}
			return "#" + this.ToInt32().ToString("X8");
		}
		
		/// <summary>Gets the color in hexadecimal integer form</summary>
		/// <returns>Returns the color in hexadecimal form</returns>
		public int ToInt32() {
			// Variables
			int alpha = (int)this.A;
			
			if(alpha == 255) {
				return (
					(int)(this.R << 16) +
					(int)(this.G << 8) +
					(int)this.B
				);
			}
			else {
				return (
					(int)(this.R << 24) +
					(int)(this.G << 16) +
					(int)(this.B << 8) +
					alpha
				);
			}
		}
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			return new VertexAttributeData[] {
				new VertexAttributeData(4, VertexAttributeDataType.Float, true)
			};
		}
		
		/// <summary>Finds if the given color is equal to this color</summary>
		/// <param name="other">The other color to find if it equals</param>
		/// <returns>Returns true if the two colors are equal to each other</returns>
		public bool Equals(Color other) {
			return (
				this.R == other.R &&
				this.G == other.G &&
				this.B == other.B &&
				this.A == other.A
			);
		}
		
		/// <summary>Finds if the given color is equal to this color</summary>
		/// <param name="obj">The other color to find if it equals</param>
		/// <returns>Returns true if the two colors are equal to each other</returns>
		public override bool Equals(object obj) {
			if(obj == null) {
				return false;
			}
			if(obj is Color) {
				return this.Equals((Color)obj);
			}
			return false;
		}
		
		/// <summary>Gets the hash code from the color</summary>
		/// <returns>Returns the hash code from the color</returns>
		public override int GetHashCode() { return (int)(this.R ^ this.G ^ this.B ^ this.A); }
		
		/// <summary>Gets the color in string form</summary>
		/// <returns>Returns the color in string form</returns>
		public override string ToString() {
			return (
				"{ r: " + this.red +
				", g: " + this.green +
				", b: " + this.blue +
				", a: " + this.alpha +
				", hex: " + this.ToHex() + " }"
			);
		}
		
		#endregion // Public Methods
		
		#region Operators
		
		/// <summary>Finds if the two colors are equal to each other</summary>
		/// <param name="left">The first color</param>
		/// <param name="right">The second color</param>
		/// <returns>Returns true if the colors are equal to each other</returns>
		public static bool operator ==(Color left, Color right) { return left.Equals(right); }
		
		/// <summary>Finds if the two colors are not equal to each other</summary>
		/// <param name="left">The first color</param>
		/// <param name="right">The second color</param>
		/// <returns>Returns true if the colors are not equal to each other</returns>
		public static bool operator !=(Color left, Color right) { return !left.Equals(right); }
		
		/// <summary>Adds the two colors together using the operator</summary>
		/// <param name="left">The left color to add with</param>
		/// <param name="right">The right color to add with</param>
		/// <returns>Returrns the resulting added color</returns>
		public static Color operator +(Color left, Color right) { return Add(ref left, ref right); }
		
		/// <summary>Subtracts the first color with the second color</summary>
		/// <param name="left">The first color to subtract with</param>
		/// <param name="right">The second color to subtract with</param>
		/// <returns>The resulting subtracted color</returns>
		public static Color operator -(Color left, Color right) { return Subtract(ref left, ref right); }
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="left">The floating point number to multiply the color with</param>
		/// <param name="right">The color to multiply with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color operator *(float left, Color right) { return Multiply(left, ref right); }
		
		/// <summary>Multiplies the color with the scalar</summary>
		/// <param name="left">The color to multiply with</param>
		/// <param name="right">The floating point number to multiply the color with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color operator *(Color left, float right) { return Multiply(right, ref left); }
		
		/// <summary>Divides the color with the scalar</summary>
		/// <param name="left">The color to divide with</param>
		/// <param name="right">The floating point number to divide the color with</param>
		/// <returns>Returns the resulting scaled color</returns>
		public static Color operator /(Color left, float right) { return Divide(right, ref left); }
		
		#endregion // Operators
	}
}

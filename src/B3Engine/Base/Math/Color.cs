
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
		public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		/// <summary>The color black (#000000)</summary>
		public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
		/// <summary>The color red (#FF0000)</summary>
		public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		/// <summary>The color green (#00FF00)</summary>
		public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		/// <summary>The color blue (#0000FF)</summary>
		public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
		/// <summary>The color yellow (#FFFF00)</summary>
		public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);
		/// <summary>The color cyan (#00FFFF)</summary>
		public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);
		/// <summary>The color magenta (#FF00FF)</summary>
		public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);
		
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
			// Variables
			string temp = hex.Trim();
			
			if(!temp.StartsWith("#")) {
				switch(hex.ToLower()) {
					default: case "black": { temp = "#000"; } break;
					case "aliceblue": { temp = "#f0f8ff"; } break;
					case "antiquewhite": { temp = "#faebd7"; } break;
					case "aqua": { temp = "#0ff"; } break;
					case "aquamarine": { temp = "#7fffd4"; } break;
					case "azure": { temp = "#f0ffff"; } break;
					case "beige": { temp = "#f5f5dc"; } break;
					case "bisque": { temp = "#ffe4c4"; } break;
					case "blanchedalmond": { temp = "#ffebcd"; } break;
					case "blue": { temp = "#00f"; } break;
					case "blueviolet": { temp = "#8a2be2"; } break;
					case "brown": { temp = "#a52a2a"; } break;
					case "burlywood": { temp = "#deb887"; } break;
					case "cadetblue": { temp = "#5f9ea0"; } break;
					case "charteuse": { temp = "#7fff00"; } break;
					case "chocolate": { temp = "#d2691e"; } break;
					case "coral": { temp = "#ff7f50"; } break;
					case "cornflowerblue": { temp = "#6495ed"; } break;
					case "cornsilk": { temp = "#fff8dc"; } break;
					case "crimson": { temp = "#dc143c"; } break;
					case "cyan": { temp = "#0ff"; } break;
					case "darkblue": { temp = "#00008b"; } break;
					case "darkcyan": { temp = "#008b8b"; } break;
					case "darkgoldenrod": { temp = "#b8860b"; } break;
					case "darkgray": case "darkgrey": { temp = "#a9a9a9"; } break;
					case "darkgreen": { temp = "#006400"; } break;
					case "darkkhaki": { temp = "#bdb76b"; } break;
					case "darkmagenta": { temp = "#8b008b"; } break;
					case "darkolivegreen": { temp = "#556b2f"; } break;
					case "darkorange": { temp = "#ff8c00"; } break;
					case "darkorchid": { temp = "#9932cc"; } break;
					case "darkred": { temp = "#8b0000"; } break;
					case "darksalmon": { temp = "#e9967a"; } break;
					case "darkseagreen": { temp = "#8fbc8f"; } break;
					case "darkslateblue": { temp = "#483d8b"; } break;
					case "darkslategray": case "darkslategrey": { temp = "#2f4f4f"; } break;
					case "darkturquoise": { temp = "#00ced1"; } break;
					case "darkviolet": { temp = "#9400d3"; } break;
					case "deeppink": { temp = "#ff1493"; } break;
					case "deepskyblue": { temp = "#00bfff"; } break;
					case "dimgray": case "dimgrey": { temp = "#696969"; } break;
					case "dodgerblue": { temp = "#1e90ff"; } break;
					case "firebrick": { temp = "#b22222"; } break;
					case "floralwhite": { temp = "#fffaf0"; } break;
					case "forestgreen": { temp = "#228b22"; } break;
					case "fuchsia": { temp = "#f0f"; } break;
					case "gainsboro": { temp = "#dcdcdc"; } break;
					case "ghostwhite": { temp = "#f8f8ff"; } break;
					case "gold": { temp = "#ffd700"; } break;
					case "goldenrod": { temp = "#daa520"; } break;
					case "gray": case "grey": { temp = "#808080"; } break;
					case "green": { temp = "#008000"; } break;
					case "greenyellow": { temp = "#adff2f"; } break;
					case "honeydew": { temp = "#f0fff0"; } break;
					case "hotpink": { temp = "#ff69b4"; } break;
					case "indianred": { temp = "#cd5c5c"; } break;
					case "indigo": { temp = "#4b0082"; } break;
					case "ivory": { temp = "#fffff0"; } break;
					case "khaki": { temp = "#f0e68c"; } break;
					case "lavender": { temp = "#e6e6fa"; } break;
					case "lavenderblush": { temp = "#fff0f5"; } break;
					case "lawngreen": { temp = "#7cfc00"; } break;
					case "lemonchiffon": { temp = "#fffacd"; } break;
					case "lightblue": { temp = "#add8e6"; } break;
					case "lightcoral": { temp = "#f08080"; } break;
					case "lightcyan": { temp = "#e0ffff"; } break;
					case "lightgoldenrodyellow": { temp = "#fafad2"; } break;
					case "lightgray": case "lightgrey": { temp = "#d3d3d3"; } break;
					case "lightgreen": { temp = "#90ee90"; } break;
					case "lightpink": { temp = "#ffb6c1"; } break;
					case "lightsalmon": { temp = "#ffa07a"; } break;
					case "lightseagreen": { temp = "#20b2aa"; } break;
					case "lightskyblue": { temp = "#87cefa"; } break;
					case "lightslategray": case "lightslategrey": { temp = "#789"; } break;
					case "lightsteelblue": { temp = "#b0c4de"; } break;
					case "lightyellow": { temp = "#ffffe0"; } break;
					case "lime": { temp = "#0f0"; } break;
					case "limegreen": { temp = "#32cd32"; } break;
					case "linen": { temp = "#faf0e6"; } break;
					case "magenta": { temp = "#f0f"; } break;
					case "maroon": { temp = "#800000"; } break;
					case "mediumaquamarine": { temp = "#66cdaa"; } break;
					case "mediumblue": { temp = "#0000cd"; } break;
					case "mediumorchid": { temp = "#ba55d3"; } break;
					case "mediumpurple": { temp = "#9370db"; } break;
					case "mediumseagreen": { temp = "#3cb371"; } break;
					case "mediumturquoise": { temp = "#48d1cc"; } break;
					case "mediumvioletred": { temp = "#c71585"; } break;
					case "midnightblue": { temp = "#191970"; } break;
					case "mintcream": { temp = "#f5fffa"; } break;
					case "mistyrose": { temp = "#ffe4e1"; } break;
					case "moccasin": { temp = "#ffe4b5"; } break;
					case "navajowhite": { temp = "#ffdead"; } break;
					case "navy": { temp = "#000080"; } break;
					case "oldlace": { temp = "#fdf5e6"; } break;
					case "olive": { temp = "#808000"; } break;
					case "olivedrab": { temp = "#6b8e23"; } break;
					case "orange": { temp = "#ffa500"; } break;
					case "orangered": { temp = "#ff4500"; } break;
					case "orchid": { temp = "#da70d6"; } break;
					case "palegoldenrod": { temp = "#eee8aa"; } break;
					case "palegreen": { temp = "#98fb98"; } break;
					case "paleturquoise": { temp = "#afeeee"; } break;
					case "palevioletred": { temp = "#db7093"; } break;
					case "papayawhip": { temp = "#ffefd5"; } break;
					case "peachpuff": { temp = "#ffdab9"; } break;
					case "peru": { temp = "#cd853f"; } break;
					case "pink": { temp = "#ffc0cb"; } break;
					case "plum": { temp = "#dda0dd"; } break;
					case "powderblue": { temp = "#b0e0e6"; } break;
					case "purple": { temp = "#800080"; } break;
					case "rebeccapurple": { temp = "#639"; } break;
					case "red": { temp = "#f00"; } break;
					case "rosybrown": { temp = "#bc8f8f"; } break;
					case "royalblue": { temp = "#4169e1"; } break;
					case "saddlebrown": { temp = "#8b4513"; } break;
					case "salmon": { temp = "#fa8072"; } break;
					case "sandybrown": { temp = "#f4a460"; } break;
					case "seagreen": { temp = "#2e8b57"; } break;
					case "seashell": { temp = "#fff5ee"; } break;
					case "sienna": { temp = "#a0522d"; } break;
					case "silver": { temp = "#c0c0c0"; } break;
					case "skyblue": { temp = "#87ceeb"; } break;
					case "slateblue": { temp = "#6a5acd"; } break;
					case "slategray": case "slategrey": { temp = "#708090"; } break;
					case "snow": { temp = "#fffafa"; } break;
					case "springgreen": { temp = "#00ff7f"; } break;
					case "steelblue": { temp = "#4682b4"; } break;
					case "tan": { temp = "#d2b48c"; } break;
					case "teal": { temp = "#008080"; } break;
					case "thistle": { temp = "#d8bfd8"; } break;
					case "tomato": { temp = "#ff6347"; } break;
					case "turquoise": { temp = "#40e0d0"; } break;
					case "violet": { temp = "#ee82ee"; } break;
					case "wheat": { temp = "#f5deb3"; } break;
					case "white": { temp = "#000"; } break;
					case "whitesmoke": { temp = "#f5f5f5"; } break;
					case "yellow": { temp = "#ff0"; } break;
					case "yellowgreen": { temp = "#9acd32"; } break;
					case "transparent": { temp = "#0000"; } break;
				}
			}
			
			// Variables
			bool isLong = temp.Length > 5;
			string redHex = "0x" + (isLong ? temp.Substring(1, 2) : $"{temp[1]}{temp[1]}");
			string greenHex = "0x" + (isLong ? temp.Substring(3, 2) : $"{temp[2]}{temp[2]}");
			string blueHex = "0x" + (isLong ? temp.Substring(5, 2) : $"{temp[3]}{temp[3]}");
			string alphaHex = "0xff";
			
			if(temp.Length == 5 || temp.Length == 9) {
				alphaHex = "0x" + (isLong ? temp.Substring(7, 2) : $"{temp[4]}{temp[4]}");
			}
			
			this.red = (float)System.Convert.ToInt32(redHex, 16) / 255.0f;
			this.green = (float)System.Convert.ToInt32(greenHex, 16) / 255.0f;
			this.blue = (float)System.Convert.ToInt32(blueHex, 16) / 255.0f;
			this.alpha = (float)System.Convert.ToInt32(alphaHex, 16) / 255.0f;
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
		
		/// <summary>Inverts the color</summary>
		/// <param name="uniary">The color to invert</param>
		/// <returns>Returns the resulting inverted color</returns>
		public static Color operator -(Color uniary) { return Invert(ref uniary); }
		
		#endregion // Operators
	}
}

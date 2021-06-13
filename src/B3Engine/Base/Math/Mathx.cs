
namespace B3 {
	/// <summary>
	/// A helper class used to help the user with mathematics.
	/// This class expands on the System.Math class
	/// </summary>
	public static partial class Mathx {
		#region Field Variables
		// Variables
		/// <summary>The number pi to make a half rotation, Pi = 3.14159265359f</summary>
		public const float Pi = 3.14159265359f;
		/// <summary>Pi divided by two to make a quarter rotation, PiOverTwo = 1.570796326f</summary>
		public const float PiOverTwo = 1.570796326f;
		/// <summary>Two time Pi which makes a full rotation, TwoPi = 6.28318530718f</summary>
		public const float TwoPi = 6.28318530718f;
		/// <summary>The number E = 2.71828182845f</summary>
		public const float E = 2.71828182845f;
		/// <summary>A conversion ratio to convert from degrees to radians (pi / 180)</summary>
		public const float DegToRad = (Pi / 180.0f);
		/// <summary>A conversion ratio to convert from radians to degrees (180 / pi)</summary>
		public const float RadToDeg = (180.0f / Pi);
		/// <summary>The smallest possible number used to approximate numbers, Epsilon = 1.401298E-45f</summary>
		public const float Epsilon = float.Epsilon;
		/// <summary>Infinity, the biggest positive number in float form</summary>
		public const float Infinity = float.PositiveInfinity;
		/// <summary>Negative infinity, the biggest negative number in float form</summary>
		public const float NegativeInfinity = float.NegativeInfinity;
		
		#endregion // Field Variables
		
		#region Public Static Methods
		
		#region Trig Functions
		
		/// <summary>Gets the sine of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the sine of the given angle (theta)</returns>
		public static float Sin(float theta) { return (float)System.Math.Sin(theta); }
		
		/// <summary>Gets the cosine of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the cosine of the given angle (theta)</returns>
		public static float Cos(float theta) { return (float)System.Math.Cos(theta); }
		
		/// <summary>Gets the tangent of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the tangent of the given angle (theta)</returns>
		public static float Tan(float theta) { return (float)System.Math.Tan(theta); }
		
		/// <summary>Gets the cosecant of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the cosecant of the given angle (theta)</returns>
		public static float Csc(float theta) { return 1.0f / Sin(theta); }
		
		/// <summary>Gets the secant of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the secant of the given angle (theta)</returns>
		public static float Sec(float theta) { return 1.0f / Cos(theta); }
		
		/// <summary>Gets the cotangent of the given angle (theta)</summary>
		/// <param name="theta">The angle (in radians)</param>
		/// <returns>Returns the cotangent of the given angle (theta)</returns>
		public static float Cot(float theta) { return 1.0f / Tan(theta); }
		
		/// <summary>Gets the angle using the arcsine of the given ratio (y / hypothenuse)</summary>
		/// <param name="val">The value (y / hypothenuse)</param>
		/// <returns>Returns the angle (in radians) of the given ratio (y / hypothenuse)</returns>
		public static float Arcsin(float val) { return (float)System.Math.Asin(val); }
		
		/// <summary>Gets the angle using the arccosine of the given ratio (x / hypothenuse)</summary>
		/// <param name="val">The value (x / hypothenuse)</param>
		/// <returns>Returns the angle (in radians) of the given ratio (x / hypothenuse)</returns>
		public static float Arccos(float val) { return (float)System.Math.Acos(val); }
		
		/// <summary>Gets the angle using the arctangent of the given ratio (y / x)</summary>
		/// <param name="val">The value (y / x)</param>
		/// <returns>Returns the angle (in radians) of the given ratio (y / x)</returns>
		public static float Arctan(float val) { return (float)System.Math.Atan(val); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="y">The y value used to get the angle</param>
		/// <param name="x">The x value used to get the angle</param>
		/// <returns>Returns the angle (in radians) of the given x and y values</returns>
		public static float Arctan(float y, float x) { return (float)System.Math.Atan2(y, x); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="vec">The 2D vector that contains the x and y values</param>
		/// <returns>Returns the angle (in radians) of the given x and y values</returns>
		public static float Arctan(ref Vector2 vec) { return Arctan(vec.y, vec.x); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="vec">The 2D vector that contains the x and y values</param>
		/// <returns>Returns the angle (in radians) of the given x and y values</returns>
		public static float Arctan(Vector2 vec) { return Arctan(vec.y, vec.x); }
		
		#endregion // Trig Functions
		
		// TODO: Add testing for these functions
		#region Trig Functions in Degrees
		
		/// <summary>Gets the sine of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the sine of the given angle (theta)</returns>
		public static float SinDeg(float theta) { return Sin(DegToRad * theta); }
		
		/// <summary>Gets the cosine of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the cosine of the given angle (theta)</returns>
		public static float CosDeg(float theta) { return Cos(DegToRad * theta); }
		
		/// <summary>Gets the tangent of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the tangent of the given angle (theta)</returns>
		public static float TanDeg(float theta) { return Tan(DegToRad * theta); }
		
		/// <summary>Gets the cosecant of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the cosecant of the given angle (theta)</returns>
		public static float CscDeg(float theta) { return Csc(DegToRad * theta); }
		
		/// <summary>Gets the secant of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the secant of the given angle (theta)</returns>
		public static float SecDeg(float theta) { return Sec(DegToRad * theta); }
		
		/// <summary>Gets the cotangent of the given angle (theta)</summary>
		/// <param name="theta">The angle (in degrees)</param>
		/// <returns>Returns the cotangent of the given angle (theta)</returns>
		public static float CotDeg(float theta) { return Cot(DegToRad * theta); }
		
		/// <summary>Gets the angle using the arcsine of the given ratio (y / hypothenuse)</summary>
		/// <param name="val">The value (y / hypothenuse)</param>
		/// <returns>Returns the angle (in degrees) of the given ratio (y / hypothenuse)</returns>
		public static float ArcsinDeg(float val) { return RadToDeg * Arcsin(val); }
		
		/// <summary>Gets the angle using the arccosine of the given ratio (x / hypothenuse)</summary>
		/// <param name="val">The value (x / hypothenuse)</param>
		/// <returns>Returns the angle (in degrees) of the given ratio (x / hypothenuse)</returns>
		public static float ArccosDeg(float val) { return RadToDeg * Arccos(val); }
		
		/// <summary>Gets the angle using the arctangent of the given ratio (y / x)</summary>
		/// <param name="val">The value (y / x)</param>
		/// <returns>Returns the angle (in degrees) of the given ratio (y / x)</returns>
		public static float ArctanDeg(float val) { return RadToDeg * Arctan(val); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="y">The y value used to get the angle</param>
		/// <param name="x">The x value used to get the angle</param>
		/// <returns>Returns the angle (in degrees) of the given x and y values</returns>
		public static float ArctanDeg(float y, float x) { return RadToDeg * Arctan(y, x); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="vec">The 2D vector that contains the x and y values</param>
		/// <returns>Returns the angle (in degrees) of the given x and y values</returns>
		public static float ArctanDeg(ref Vector2 vec) { return RadToDeg * Arctan(ref vec); }
		
		/// <summary>Gets the angle using the arctangent of the given x and y values</summary>
		/// <param name="vec">The 2D vector that contains the x and y values</param>
		/// <returns>Returns the angle (in degrees) of the given x and y values</returns>
		public static float ArctanDeg(Vector2 vec) { return RadToDeg * Arctan(ref vec); }
		
		#endregion // Trig Functions in Degrees
		
		#region Hyperbolic Trig Functions
		
		/// <summary>Gets the hyperbolic sine</summary>
		/// <param name="theta">The angle used to get the hyperbolic sine (in radians)</param>
		/// <returns>Returns the hyperbolic sine of the given angle</returns>
		public static float Sinh(float theta) { return (float)System.Math.Sinh(theta); }
		
		/// <summary>Gets the hyperbolic cosine</summary>
		/// <param name="theta">The angle used to get the hyperbolic cosine (in radians)</param>
		/// <returns>Returns the hyperbolic cosine of the given angle</returns>
		public static float Cosh(float theta) { return (float)System.Math.Cosh(theta); }
		
		/// <summary>Gets the hyperbolic tangent</summary>
		/// <param name="theta">The angle used to get the hyperbolic tangent (in radians)</param>
		/// <returns>Returns the hyperbolic tangent of the given angle</returns>
		public static float Tanh(float theta) { return (float)System.Math.Tanh(theta); }
		
		/// <summary>Gets the hyperbolic cosecant</summary>
		/// <param name="theta">The angle used to get the hyperbolic cosecant (in radians)</param>
		/// <returns>Returns the hyperbolic cosecant of the given angle</returns>
		public static float Csch(float theta) { return 1.0f / Sinh(theta); }
		
		/// <summary>Gets the hyperbolic secant</summary>
		/// <param name="theta">The angle used to get the hyperbolic secant (in radians)</param>
		/// <returns>Returns the hyperbolic secant of the given angle</returns>
		public static float Sech(float theta) { return 1.0f / Cosh(theta); }
		
		/// <summary>Gets the hyperbolic cotangent</summary>
		/// <param name="theta">The angle used to get the hyperbolic cotangent (in radians)</param>
		/// <returns>Returns the hyperbolic cotangent of the given angle</returns>
		public static float Coth(float theta) { return 1.0f / Tanh(theta); }
		
		#endregion // Hyperbolic Trig Functions
		
		#region Min Methods
		
		/// <summary>Gets the minimum value from the two given values</summary>
		/// <param name="val">The value to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given values</returns>
		public static float Min(float val, float min) { return (val > min ? min : val); }
		
		/// <summary>Gets the minimum value from the two given values</summary>
		/// <param name="val">The value to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given values</returns>
		public static int Min(int val, int min) { return (val > min ? min : val); }
		
		/// <summary>Gets the minimum value from the given array of values</summary>
		/// <param name="vals">The array of values to check</param>
		/// <returns>Returns the minimum value from the given array of values</returns>
		public static float MinRange(params float[] vals) {
			// Variables
			float min = float.MaxValue;
			
			for(int i = 0; i < vals.Length; i++) {
				min = Min(min, vals[i]);
			}
			
			return min;
		}
		
		/// <summary>Gets the minimum value from the given array of values</summary>
		/// <param name="vals">The array of values to check</param>
		/// <returns>Returns the minimum value from the given array of values</returns>
		public static int MinRange(params int[] vals) {
			// Variables
			int min = int.MaxValue;
			
			for(int i = 0; i < vals.Length; i++) {
				min = Min(min, vals[i]);
			}
			
			return min;
		}
		
		#endregion // Min Methods
		
		#region Max Methods
		
		/// <summary>Gets the maximum value from the two given values</summary>
		/// <param name="val">The value to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given values</returns>
		public static float Max(float val, float max) { return (val < max ? max : val); }
		
		/// <summary>Gets the maximum value from the two given values</summary>
		/// <param name="val">The value to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given values</returns>
		public static int Max(int val, int max) { return (val < max ? max : val); }
		
		/// <summary>Gets the maximum value from the given array of values</summary>
		/// <param name="vals">The array of values to check</param>
		/// <returns>Returns the maximum value from the given array of values</returns>
		public static float MaxRange(params float[] vals) {
			// Variables
			float max = float.MinValue;
			
			for(int i = 0; i < vals.Length; i++) {
				max = Max(max, vals[i]);
			}
			
			return max;
		}
		
		/// <summary>Gets the maximum value from the given array of values</summary>
		/// <param name="vals">The array of values to check</param>
		/// <returns>Returns the maximum value from the given array of values</returns>
		public static int MaxRange(params int[] vals) {
			// Variables
			int max = int.MinValue;
			
			for(int i = 0; i < vals.Length; i++) {
				max = Max(max, vals[i]);
			}
			
			return max;
		}
		
		#endregion // Max Methods
		
		#region Clamp Methods
		
		/// <summary>Clamps the value between the minimum and maximum value provided</summary>
		/// <param name="val">The value to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the clamped value from the minimum and maximum value provided</returns>
		public static float Clamp(float val, float min, float max) {
			if(val < min) { return min; }
			else if(val > max) { return max; }
			return val;
		}
		
		/// <summary>Clamps the value between the minimum and maximum value provided</summary>
		/// <param name="val">The value to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the clamped value from the minimum and maximum value provided</returns>
		public static int Clamp(int val, int min, int max) {
			if(val < min) { return min; }
			else if(val > max) { return max; }
			return val;
		}
		
		#endregion // Clamp Methods
		
		#region Floor, Ceiling, and Fractional Functions
		
		/// <summary>Gets the largest integer number that is less than or equal to the given number</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns the largest integer number that is less than or equal to the given number</returns>
		public static int Floor(float val) {
			// Variables
			int results = (int)val;
			
			if(results == val) { return results; }
			
			return results - (val < 0.0f ? 1 : 0);
		}
		
		/// <summary>Gets the smallest integer number that is greater than or equal to the given number</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns the smallest integer number that is greater than or equal to the given number</returns>
		public static int Ceiling(float val) {
			// Variables
			int results = (int)val;
			
			if(results == val) { return results; }
			
			return results + (val < 0.0f ? 0 : 1);
		}
		
		/// <summary>Gets the fractional part of the value, getting only a value between 0 and 1</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns the fractional part of the value, getting only a value between 0 and 1</returns>
		public static float Fraction(float val) {
			// Variables
			float result = val - Floor(val);
			
			return result;
		}
		
		#endregion // Floor, Ceiling, and Fractional Functions
		
		#region Abs Methods
		
		/// <summary>Gets the absolute (positive) value of the given value</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns the absolute (positive) value of the given value</returns>
		public static float Abs(float val) { return (val < 0.0f ? -val : val); }
		
		/// <summary>Gets the absolute (positive) value of the given value</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns the absolute (positive) value of the given value</returns>
		public static int Abs(int val) { return (val < 0 ? -val : val); }
		
		#endregion // Abs Methods
		
		#region Sign Methods
		
		/// <summary>Gets the sign (positive or negative) of the given value</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns 1 if the value is positive, 0 if the value is 0, and -1 if the value is negative</returns>
		public static int Sign(float val) { return (val < 0.0f ? -1 : (val == 0.0f ? 0 : 1)); }
		
		/// <summary>Gets the sign (positive or negative) of the given value</summary>
		/// <param name="val">The value to check with</param>
		/// <returns>Returns 1 if the value is positive, 0 if the value is 0, and -1 if the value is negative</returns>
		public static int Sign(int val) { return (val < 0 ? -1 : (val == 0 ? 0 : 1)); }
		
		#endregion // Sign Methods
		
		#region Pow Methods
		
		/// <summary>Gets the value that takes the first number to the power of the second number. a ^ b</summary>
		/// <param name="a">The base number to iterate through</param>
		/// <param name="b">The power number to iterate with</param>
		/// <returns>Returns the value that takes the first number to the power of the second number. a ^ b</returns>
		public static float Pow(float a, float b) { return (float)System.Math.Pow(a, b); }
		
		/// <summary>Gets the value that takes the first number to the power of the second number. a ^ b</summary>
		/// <param name="a">The base number to iterate through</param>
		/// <param name="b">The power number to iterate with</param>
		/// <returns>Returns the value that takes the first number to the power of the second number. a ^ b</returns>
		public static float Pow(int a, int b) { return (float)System.Math.Pow(a, b); }
		
		/// <summary>Gets the value that takes e to the power of the given number. e ^ val</summary>
		/// <param name="val">The power number to iterate with</param>
		/// <returns>Returns the value that takes e to the power of the given number. e ^ val</returns>
		public static float Pow(float val) { return Pow(E, val); }
		
		/// <summary>Gets the value that takes e to the power of the given number. e ^ val</summary>
		/// <param name="val">The power number to iterate with</param>
		/// <returns>Returns the value that takes e to the power of the given number. e ^ val</returns>
		public static float Pow(int val) { return Pow(E, val); }
		
		#endregion // Pow Methods
		
		#region MapRange Methods
		
		/// <summary>Maps the value to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="val">The value to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the value that gets mapped from the first range to the second range</returns>
		public static float MapRange(float val, float inMin, float inMax, float outMin, float outMax) { return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin; }
		
		/// <summary>Maps the value to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="val">The value to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the value that gets mapped from the first range to the second range</returns>
		public static int MapRange(int val, int inMin, int inMax, int outMin, int outMax) { return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin; }
		
		#endregion // MapRange Methods
		
		#region Logarithmic Functions
		
		/// <summary>Gets the logarithmic number of the given value in the given base</summary>
		/// <param name="val">The value to perform the logarithmic function with</param>
		/// <param name="newBase">The new base to do the logarithm with</param>
		/// <returns>Returns the logarithmic number of the given number in the given base</returns>
		public static float Log(float val, float newBase) { return (float)System.Math.Log(val, newBase); }
		
		/// <summary>Gets the logarithmic number of the given value in the given base</summary>
		/// <param name="val">The value to perform the logarithmic function with</param>
		/// <param name="newBase">The new base to do the logarithm with</param>
		/// <returns>Returns the logarithmic number of the given number in the given base</returns>
		public static float Log(int val, int newBase) { return (float)System.Math.Log(val, newBase); }
		
		/// <summary>Gets the logarithmic number of the given value in base 10</summary>
		/// <param name="val">The value to perform the logarithmic function with</param>
		/// <returns>Returns the logarithmic number of the given number in base 10</returns>
		public static float Log(float val) { return (float)System.Math.Log10(val); }
		
		/// <summary>Gets the logarithmic number of the given value in base 10</summary>
		/// <param name="val">The value to perform the logarithmic function with</param>
		/// <returns>Returns the logarithmic number of the given number in base 10</returns>
		public static float Log(int val) { return (float)System.Math.Log10(val); }
		
		/// <summary>Gets the natural logarithmic number of the given value in base e</summary>
		/// <param name="val">The value to perform the natural logarithmic function with</param>
		/// <returns>Returns the natural logarithmic number of the given value in base e</returns>
		public static float Ln(float val) { return (float)System.Math.Log(val); }
		
		/// <summary>Gets the natural logarithmic number of the given value in base e</summary>
		/// <param name="val">The value to perform the natural logarithmic function with</param>
		/// <returns>Returns the natural logarithmic number of the given value in base e</returns>
		public static float Ln(int val) { return (float)System.Math.Log(val); }
		
		#endregion // Logarithmic Functions
		
		#region Trunc Methods
		
		/// <summary>Truncates the given value</summary>
		/// <param name="val">The value to truncate with</param>
		/// <returns>Returns the truncated value</returns>
		public static int Trunc(float val) { return (int)val; }
		
		#endregion // Trunc Methods
		
		#region Sqrt Methods
		
		/// <summary>Gets the square root of the given value</summary>
		/// <param name="val">The value to square root</param>
		/// <returns>Returns the square root of the given value</returns>
		public static float Sqrt(float val) { return (float)System.Math.Sqrt(val); }
		
		/// <summary>Gets the square root of the given value</summary>
		/// <param name="val">The value to square root</param>
		/// <returns>Returns the square root of the given value</returns>
		public static float Sqrt(int val) { return (float)System.Math.Sqrt(val); }
		
		#endregion // Sqrt Methods
		
		#region Round Methods
		
		/// <summary>Rounds the given value, down if even and up if odd</summary>
		/// <param name="val">The value to round with</param>
		/// <returns>Returns the rounded value</returns>
		public static int Round(float val) {
			// Variables
			float frac = Fraction(val);
			int trunc = Trunc(val);
			
			if(val < 0.0f) { frac = 1.0f - frac; }
			
			if(frac >= 0.5f) {
				return trunc + Sign(val);
			}
			else {
				return trunc;
			}
		}
		
		/// <summary>Rounds the given value to the given digits</summary>
		/// <param name="val">The value to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the rounded value to the given digits</returns>
		public static float Round(float val, int digits) {
			if(digits < -15 || digits > 15) {
				throw new System.ArgumentOutOfRangeException("digits", digits, "Digits must be between -15 and 15");
			}
			// Variables
			float pow10 = Pow(10, digits);
			float poweredVal = val * pow10;
			float frac = Fraction(poweredVal);
			int trunc = Trunc(poweredVal);
			
			if(frac == 0.0f) { return val; }
			if(val < 0.0f) { frac = 1.0f - frac; }
			
			if(frac >= 0.5f) {
				return (trunc + Sign(val)) / pow10;
			}
			else {
				return (float)trunc / pow10;
			}
		}
		
		#endregion // Round Methods
		
		#region Smoothstep Methods
		
		/// <summary>Computes a smooth Hermite interpolation that returns a number between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns a smooth Hermite interpolation that returns a number between 0 and 1</returns>
		public static float Smoothstep(float x, float leftEdge, float rightEdge) {
			// Variables
			float y = Clamp((x - leftEdge) / (rightEdge - leftEdge), 0.0f, 1.0f);
			
			return y * y * (3.0f - 2.0f * y);
		}
		
		/// <summary>Computes a smooth Hermite interpolation that returns a number between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns a smooth Hermite interpolation that returns a number between 0 and 1</returns>
		public static float Smoothstep(int x, int leftEdge, int rightEdge) { return Smoothstep((float)leftEdge, (float)rightEdge, (float)x); }
		
		#endregion // Smoothstep Methods
		
		#region Repeat Methods
		
		/// <summary>Repeats the value over and over be within the minimum and maximum range</summary>
		/// <param name="val">The value to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the repeated value that is within the minimum and maximum range</returns>
		public static float Repeat(float val, float min, float max) {
			if(val >= min && val <= max) {
				return val;
			}
			
			// Variables
			float x = val - min;
			float dist = max - min;
			
			if(x < 0.0f) {
				return max - dist * Fraction(x / dist);
			}
			else {
				return dist * Fraction(x / dist) + min;
			}
		}
		
		/// <summary>Repeats the value over and over be within 0 and the maximum range</summary>
		/// <param name="val">The value to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the repeated value that is within 0 and the maximum range</returns>
		public static float RepeatFrom0(float val, float max) {
			if(val >= 0 && val <= max) {
				return val;
			}
			
			// Variables
			float x = val / max;
			
			if(val < 0.0f) {
				return (int)(max - max * (x - (int)x));
			}
			else {
				return (int)(max * (x - (int)x));
			}
		}
		
		/// <summary>Repeats the value over and over be within the minimum and maximum range</summary>
		/// <param name="val">The value to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the repeated value that is within the minimum and maximum range</returns>
		public static int Repeat(int val, int min, int max) {
			if(val >= min && val <= max) {
				return val;
			}
			
			// Variables
			float x = val - min;
			float dist = max - min;
			
			if(x < 0.0f) {
				return (int)(max - dist * Fraction(x / dist));
			}
			else {
				return (int)(dist * Fraction(x / dist) + min);
			}
		}
		
		/// <summary>Repeats the value over and over be within 0 and the maximum range</summary>
		/// <param name="val">The value to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the repeated value that is within 0 and the maximum range</returns>
		public static int RepeatFrom0(int val, int max) {
			if(val >= 0 && val <= max) {
				return val;
			}
			
			// Variables
			float x = val / max;
			
			if(val < 0.0f) {
				return (int)(max - max * (x - (int)x));
			}
			else {
				return (int)(max * (x - (int)x));
			}
		}
		
		#endregion // Repeat Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the values are approximately close to each other</summary>
		/// <param name="a">The first value to approximate</param>
		/// <param name="b">The second value to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the values are approximately close, false otherwise</returns>
		public static bool Approx(float a, float b, float epsilon) { return (a >= (b - epsilon) && a <= (b + epsilon)); }
		
		/// <summary>Finds if the values are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first value to approximate</param>
		/// <param name="b">The second value to approximate</param>
		/// <returns>Returns true if the values are approximately close, false otherwise</returns>
		public static bool Approx(float a, float b) { return Approx(a, b, 0.0000001f); }
		
		#endregion // Approx Methods
		
		#region Lerp Methods
		
		/// <summary>Linearly interpolates between the first and second value given a value between 0 and 1</summary>
		/// <param name="a">The first value to linearly interpolate with</param>
		/// <param name="b">The second value to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first value towards the second value to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated value</returns>
		public static float LerpClamped(float a, float b, float t) {
			// Variables
			float temp = Clamp(t, 0.0f, 1.0f);
			
			return (1.0f - temp) * a + b * temp;
		}
		
		/// <summary>Linearly interpolates between the first and second value</summary>
		/// <param name="a">The first value to linearly interpolate with</param>
		/// <param name="b">The second value to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first value towards the second value to get the interpolation</param>
		/// <returns>Returns the linearly interpolated value</returns>
		public static float Lerp(float a, float b, float t) { return a + t * (b - a); }
		
		#endregion // Lerp Methods
		
		#region MinMax Methods
		
		/// <summary>Gets the minimum and maximum values from the two given values. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first value to get the minimum and maximum</param>
		/// <param name="b">The second value to get the minimum and maximum</param>
		/// <param name="min">The minimum value from the two values</param>
		/// <param name="max">The maximum value from the two values</param>
		public static void MinMax(float a, float b, out float min, out float max) {
			// Variables
			float temp = Max(a, b);
			
			min = Min(a, b);
			max = temp;
		}
		
		/// <summary>Gets the minimum and maximum values from the two given values. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first value to get the minimum and maximum</param>
		/// <param name="b">The second value to get the minimum and maximum</param>
		/// <param name="min">The minimum value from the two values</param>
		/// <param name="max">The maximum value from the two values</param>
		public static void MinMax(int a, int b, out int min, out int max) {
			// Variables
			int temp = Max(a, b);
			
			min = Min(a, b);
			max = temp;
		}
		
		/// <summary>Gets the minimum and maximum values from the given array of values. Used for sorting max and min in a single line of code</summary>
		/// <param name="min">The minimum value from the array of values</param>
		/// <param name="max">The maximum value from the array of values</param>
		/// <param name="vals">The array of values to get the minimum and maximum values</param>
		public static void MinMaxRange(out float min, out float max, params float[] vals) {
			// Variables
			float temp = MaxRange(vals);
			
			min = MinRange(vals);
			max = temp;
		}
		
		/// <summary>Gets the minimum and maximum values from the given array of values. Used for sorting max and min in a single line of code</summary>
		/// <param name="min">The minimum value from the array of values</param>
		/// <param name="max">The maximum value from the array of values</param>
		/// <param name="vals">The array of values to get the minimum and maximum values</param>
		public static void MinMaxRange(out int min, out int max, params int[] vals) {
			// Variables
			int temp = MaxRange(vals);
			
			min = MinRange(vals);
			max = temp;
		}
		
		#endregion // MinMax Methods
		
		#endregion // Public Static Methods
	}
}

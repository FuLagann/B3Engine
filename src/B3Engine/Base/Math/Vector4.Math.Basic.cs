
namespace B3 {
	public partial struct Vector4 {
		#region Public Static Methods
		
		#region Min Methods
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(ref Vector4 vec, ref Vector4 min, out Vector4 result) {
			result.x = Mathx.Min(vec.x, min.x);
			result.y = Mathx.Min(vec.y, min.y);
			result.z = Mathx.Min(vec.z, min.z);
			result.w = Mathx.Min(vec.w, min.w);
		}
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(Vector4 vec, Vector4 min, out Vector4 result) { Min(ref vec, ref min, out result); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector4 Min(ref Vector4 vec, ref Vector4 min) {
			// Variables
			Vector4 result;
			
			Min(ref vec, ref min, out result);
			
			return result;
		}
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector4 Min(Vector4 vec, Vector4 min) { return Min(ref vec, ref min); }
		
		#endregion // Min Methods
		
		#region Max Methods
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(ref Vector4 vec, ref Vector4 max, out Vector4 result) {
			result.x = Mathx.Max(vec.x, max.x);
			result.y = Mathx.Max(vec.y, max.y);
			result.z = Mathx.Max(vec.z, max.z);
			result.w = Mathx.Max(vec.w, max.w);
		}
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(Vector4 vec, Vector4 max, out Vector4 result) { Max(ref vec, ref max, out result); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector4 Max(ref Vector4 vec, ref Vector4 max) {
			// Variables
			Vector4 result;
			
			Max(ref vec, ref max, out result);
			
			return result;
		}
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector4 Max(Vector4 vec, Vector4 max) { return Max(ref vec, ref max); }
		
		#endregion // Max Methods
		
		#region Clamp Methods
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result) {
			// Variables
			Vector4 tempMin;
			Vector4 tempMax;
			
			Min(ref min, ref max, out tempMin);
			Max(ref min, ref max, out tempMax);
			result.x = Mathx.Clamp(vec.x, tempMin.x, tempMax.x);
			result.y = Mathx.Clamp(vec.y, tempMin.y, tempMax.y);
			result.z = Mathx.Clamp(vec.z, tempMin.z, tempMax.z);
			result.w = Mathx.Clamp(vec.w, tempMin.w, tempMax.w);
		}
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(Vector4 vec, Vector4 min, Vector4 max, out Vector4 result) { Clamp(ref vec, ref min, ref max, out result); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>Returns the resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector4 Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max) {
			// Variables
			Vector4 result;
			
			Clamp(ref vec, ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>Returns the resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector4 Clamp(Vector4 vec, Vector4 min, Vector4 max) { return Clamp(ref vec, ref min, ref max); }
		
		#endregion // Clamp Methods
		
		#region Floor Methods
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Floor(vec.x);
			result.y = Mathx.Floor(vec.y);
			result.z = Mathx.Floor(vec.z);
			result.w = Mathx.Floor(vec.w);
		}
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(Vector4 vec, out Vector4 result) { Floor(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector4 Floor(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Floor(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector4 Floor(Vector4 vec) { return Floor(ref vec); }
		
		#endregion // Floor Methods
		
		#region Ceiling Methods
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Ceiling(vec.x);
			result.y = Mathx.Ceiling(vec.y);
			result.z = Mathx.Ceiling(vec.z);
			result.w = Mathx.Ceiling(vec.w);
		}
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(Vector4 vec, out Vector4 result) { Ceiling(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector4 Ceiling(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Ceiling(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector4 Ceiling(Vector4 vec) { return Ceiling(ref vec); }
		
		#endregion // Ceiling Methods
		
		#region Fraction Methods
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Fraction(vec.x);
			result.y = Mathx.Fraction(vec.y);
			result.z = Mathx.Fraction(vec.z);
			result.w = Mathx.Fraction(vec.w);
		}
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(Vector4 vec, out Vector4 result) { Fraction(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector4 Fraction(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Fraction(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector4 Fraction(Vector4 vec) { return Fraction(ref vec); }
		
		#endregion // Fraction Methods
		
		#region Abs Methods
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Abs(vec.x);
			result.y = Mathx.Abs(vec.y);
			result.z = Mathx.Abs(vec.z);
			result.w = Mathx.Abs(vec.w);
		}
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(Vector4 vec, out Vector4 result) { Abs(ref vec, out result); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector4 Abs(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Abs(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector4 Abs(Vector4 vec) { return Abs(ref vec); }
		
		#endregion // Abs Methods
		
		#region MapRange Methods
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(ref Vector4 vec, ref Vector4 inMin, ref Vector4 inMax, ref Vector4 outMin, ref Vector4 outMax, out Vector4 result) {
			result.x = Mathx.MapRange(vec.x, inMin.x, inMax.x, outMin.x, outMax.x);
			result.y = Mathx.MapRange(vec.y, inMin.y, inMax.y, outMin.y, outMax.y);
			result.z = Mathx.MapRange(vec.z, inMin.z, inMax.z, outMin.z, outMax.z);
			result.w = Mathx.MapRange(vec.w, inMin.w, inMax.w, outMin.w, outMax.w);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(Vector4 vec, Vector4 inMin, Vector4 inMax, Vector4 outMin, Vector4 outMax, out Vector4 result) { MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result); }
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector4 MapRange(ref Vector4 vec, ref Vector4 inMin, ref Vector4 inMax, ref Vector4 outMin, ref Vector4 outMax) {
			// Variables
			Vector4 result;
			
			MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result);
			
			return result;
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector4 MapRange(Vector4 vec, Vector4 inMin, Vector4 inMax, Vector4 outMin, Vector4 outMax) { return MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax); }
		
		#endregion // MapRange Methods
		
		#region Trunc Methods
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Trunc(vec.x);
			result.y = Mathx.Trunc(vec.y);
			result.z = Mathx.Trunc(vec.z);
			result.w = Mathx.Trunc(vec.w);
		}
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(Vector4 vec, out Vector4 result) { Vector4.Trunc(ref vec, out result); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector4 Trunc(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Trunc(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector4 Trunc(Vector4 vec) { return Vector4.Trunc(ref vec); }
		
		#endregion // Trunc Methods
		
		#region Sqrt Methods
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Sqrt(vec.x);
			result.y = Mathx.Sqrt(vec.y);
			result.z = Mathx.Sqrt(vec.z);
			result.w = Mathx.Sqrt(vec.w);
		}
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(Vector4 vec, out Vector4 result) { Vector4.Sqrt(ref vec, out result); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector4 Sqrt(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Sqrt(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector4 Sqrt(Vector4 vec) { return Sqrt(ref vec); }
		
		#endregion // Sqrt Methods
		
		#region Round Methods
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(ref Vector4 vec, int digits, out Vector4 result) {
			result.x = Mathx.Round(vec.x, digits);
			result.y = Mathx.Round(vec.y, digits);
			result.z = Mathx.Round(vec.z, digits);
			result.w = Mathx.Round(vec.w, digits);
		}
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(ref Vector4 vec, out Vector4 result) {
			result.x = Mathx.Round(vec.x);
			result.y = Mathx.Round(vec.y);
			result.z = Mathx.Round(vec.z);
			result.w = Mathx.Round(vec.w);
		}
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(Vector4 vec, int digits, out Vector4 result) { Round(ref vec, digits, out result); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(Vector4 vec, out Vector4 result) { Round(ref vec, out result); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector4 Round(ref Vector4 vec, int digits) {
			// Variables
			Vector4 result;
			
			Round(ref vec, digits, out result);
			
			return result;
		}
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector4 Round(ref Vector4 vec) {
			// Variables
			Vector4 result;
			
			Round(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector4 Round(Vector4 vec, int digits) { return Round(ref vec, digits); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector4 Round(Vector4 vec) { return Round(ref vec); }
		
		#endregion // Round Methods
		
		#region Smoothstep Methods
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(ref Vector4 x, ref Vector4 leftEdge, ref Vector4 rightEdge, out Vector4 result) {
			// Variables
			Vector4 tempLeftEdge;
			Vector4 tempRightEdge;
			
			Min(ref leftEdge, ref rightEdge, out tempLeftEdge);
			Max(ref leftEdge, ref rightEdge, out tempRightEdge);
			
			result.x = Mathx.Smoothstep(x.x, tempLeftEdge.x, tempRightEdge.x);
			result.y = Mathx.Smoothstep(x.y, tempLeftEdge.y, tempRightEdge.y);
			result.z = Mathx.Smoothstep(x.z, tempLeftEdge.z, tempRightEdge.z);
			result.w = Mathx.Smoothstep(x.w, tempLeftEdge.w, tempRightEdge.w);
		}
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(Vector4 x, Vector4 leftEdge, Vector4 rightEdge, out Vector4 result) { Smoothstep(ref x, ref leftEdge, ref rightEdge, out result); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns the resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector4 Smoothstep(ref Vector4 x, ref Vector4 leftEdge, ref Vector4 rightEdge) {
			// Variables
			Vector4 result;
			
			Smoothstep(ref x, ref leftEdge, ref rightEdge, out result);
			
			return result;
		}
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns the resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector4 Smoothstep(Vector4 x, Vector4 leftEdge, Vector4 rightEdge) { return Smoothstep(ref x, ref leftEdge, ref rightEdge); }
		
		#endregion // Smoothstep Methods
		
		#region Repeat Methods
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result) {
			result.x = Mathx.Repeat(vec.x, min.x, max.x);
			result.y = Mathx.Repeat(vec.y, min.y, max.y);
			result.z = Mathx.Repeat(vec.z, min.z, max.z);
			result.w = Mathx.Repeat(vec.w, min.w, max.w);
		}
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(Vector4 vec, Vector4 min, Vector4 max, out Vector4 result) { Repeat(ref vec, ref min, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector4 Repeat(ref Vector4 vec, ref Vector4 min, ref Vector4 max) {
			// Variables
			Vector4 result;
			
			Repeat(ref vec, ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector4 Repeat(Vector4 vec, Vector4 min, Vector4 max) { return Repeat(ref vec, ref min, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(ref Vector4 vec, ref Vector4 max, out Vector4 result) {
			result.x = Mathx.RepeatFrom0(vec.x, max.x);
			result.y = Mathx.RepeatFrom0(vec.y, max.y);
			result.z = Mathx.RepeatFrom0(vec.z, max.z);
			result.w = Mathx.RepeatFrom0(vec.w, max.w);
		}
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(Vector4 vec, Vector4 max, out Vector4 result) { RepeatFrom0(ref vec, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector4 RepeatFrom0(ref Vector4 vec, ref Vector4 max) {
			// Variables
			Vector4 result;
			
			RepeatFrom0(ref vec, ref max, out result);
			
			return result;
		}
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector4 RepeatFrom0(Vector4 vec, Vector4 max) { return RepeatFrom0(ref vec, ref max); }
		
		#endregion // Repeat Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector4 a, ref Vector4 b, float epsilon, out bool result) {
			result = (
				Mathx.Approx(a.x, b.x, epsilon) &&
				Mathx.Approx(a.y, b.y, epsilon) &&
				Mathx.Approx(a.z, b.z, epsilon) &&
				Mathx.Approx(a.w, b.w, epsilon)
			);
		}
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector4 a, ref Vector4 b, out bool result) {
			result = (
				Mathx.Approx(a.x, b.x) &&
				Mathx.Approx(a.y, b.y) &&
				Mathx.Approx(a.z, b.z) &&
				Mathx.Approx(a.w, b.w)
			);
		}
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(Vector4 a, Vector4 b, float epsilon, out bool result) { Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(Vector4 a, Vector4 b, out bool result) { Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector4 a, ref Vector4 b, float epsilon) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, epsilon, out result);
			
			return result;
		}
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector4 a, ref Vector4 b) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, out result);
			
			return result;
		}
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(Vector4 a, Vector4 b, float epsilon) { return Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(Vector4 a, Vector4 b) { return Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Lerp Methods
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(ref Vector4 a, ref Vector4 b, float t, out Vector4 result) {
			result.x = Mathx.LerpClamped(a.x, b.x, t);
			result.y = Mathx.LerpClamped(a.y, b.y, t);
			result.z = Mathx.LerpClamped(a.z, b.z, t);
			result.w = Mathx.LerpClamped(a.w, b.w, t);
		}
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(Vector4 a, Vector4 b, float t, out Vector4 result) { LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 LerpClamped(ref Vector4 a, ref Vector4 b, float t) {
			// Variables
			Vector4 result;
			
			LerpClamped(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 LerpClamped(Vector4 a, Vector4 b, float t) { return LerpClamped(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(ref Vector4 a, ref Vector4 b, float t, out Vector4 result) {
			result.x = Mathx.Lerp(a.x, b.x, t);
			result.y = Mathx.Lerp(a.y, b.y, t);
			result.z = Mathx.Lerp(a.z, b.z, t);
			result.w = Mathx.Lerp(a.w, b.w, t);
		}
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(Vector4 a, Vector4 b, float t, out Vector4 result) { Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 Lerp(ref Vector4 a, ref Vector4 b, float t) {
			// Variables
			Vector4 result;
			
			Lerp(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector4 Lerp(Vector4 a, Vector4 b, float t) { return Lerp(ref a, ref b, t); }
		
		#endregion // Lerp Methods
		
		#region MinMax Methods
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(ref Vector4 a, ref Vector4 b, out Vector4 min, out Vector4 max) {
			Mathx.MinMax(a.x, b.x, out min.x, out max.x);
			Mathx.MinMax(a.y, b.y, out min.y, out max.y);
			Mathx.MinMax(a.z, b.z, out min.z, out max.z);
			Mathx.MinMax(a.w, b.w, out min.w, out max.w);
		}
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(Vector4 a, Vector4 b, out Vector4 min, out Vector4 max) { MinMax(ref a, ref b, out min, out max); }
		
		#endregion // MinMax Methods
		
		#endregion // Public Static Methods
	}
}

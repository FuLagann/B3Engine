
namespace B3 {
	public partial struct Vector3 {
		#region Public Static Methods
		
		#region Min Methods
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(ref Vector3 vec, ref Vector3 min, out Vector3 result) {
			result.x = Mathx.Min(vec.x, min.x);
			result.y = Mathx.Min(vec.y, min.y);
			result.z = Mathx.Min(vec.z, min.z);
		}
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <param name="result">The resulting the minimum value from the two given vectors</param>
		public static void Min(Vector3 vec, Vector3 min, out Vector3 result) { Min(ref vec, ref min, out result); }
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector3 Min(ref Vector3 vec, ref Vector3 min) {
			// Variables
			Vector3 result;
			
			Min(ref vec, ref min, out result);
			
			return result;
		}
		
		/// <summary>Gets the minimum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum value to check with</param>
		/// <returns>Returns the minimum value from the two given vectors</returns>
		public static Vector3 Min(Vector3 vec, Vector3 min) { return Min(ref vec, ref min); }
		
		#endregion // Min Methods
		
		#region Max Methods
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(ref Vector3 vec, ref Vector3 max, out Vector3 result) {
			result.x = Mathx.Max(vec.x, max.x);
			result.y = Mathx.Max(vec.y, max.y);
			result.z = Mathx.Max(vec.z, max.z);
		}
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <param name="result">The resulting the maximum value from the two given vectors</param>
		public static void Max(Vector3 vec, Vector3 max, out Vector3 result) { Max(ref vec, ref max, out result); }
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector3 Max(ref Vector3 vec, ref Vector3 max) {
			// Variables
			Vector3 result;
			
			Max(ref vec, ref max, out result);
			
			return result;
		}
		
		/// <summary>Gets the maximum vector from the two given vectors</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="max">The maximum value to check with</param>
		/// <returns>Returns the maximum value from the two given vectors</returns>
		public static Vector3 Max(Vector3 vec, Vector3 max) { return Max(ref vec, ref max); }
		
		#endregion // Max Methods
		
		#region Clamp Methods
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result) {
			// Variables
			Vector3 tempMin;
			Vector3 tempMax;
			
			Min(ref min, ref max, out tempMin);
			Max(ref min, ref max, out tempMax);
			result.x = Mathx.Clamp(vec.x, tempMin.x, tempMax.x);
			result.y = Mathx.Clamp(vec.y, tempMin.y, tempMax.y);
			result.z = Mathx.Clamp(vec.z, tempMin.z, tempMax.z);
		}
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <param name="result">The resulting vector that is clamped to the minimum and maximum values provided</param>
		public static void Clamp(Vector3 vec, Vector3 min, Vector3 max, out Vector3 result) { Clamp(ref vec, ref min, ref max, out result); }
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>Returns the resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector3 Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max) {
			// Variables
			Vector3 result;
			
			Clamp(ref vec, ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Clamps the vector between the minimum and maximum vectors provided</summary>
		/// <param name="vec">The vector to check</param>
		/// <param name="min">The minimum vector to check with</param>
		/// <param name="max">The maximum vector to check with</param>
		/// <returns>Returns the resulting vector that is clamped to the minimum and maximum values provided</returns>
		public static Vector3 Clamp(Vector3 vec, Vector3 min, Vector3 max) { return Clamp(ref vec, ref min, ref max); }
		
		#endregion // Clamp Methods
		
		#region Floor Methods
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Floor(vec.x);
			result.y = Mathx.Floor(vec.y);
			result.z = Mathx.Floor(vec.z);
		}
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the largest integer number that is less than or equal to the number that the component had</param>
		public static void Floor(Vector3 vec, out Vector3 result) { Floor(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector3 Floor(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Floor(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having the largest integer number that is less than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the largest integer number that is less than or equal to the number that the component had</returns>
		public static Vector3 Floor(Vector3 vec) { return Floor(ref vec); }
		
		#endregion // Floor Methods
		
		#region Ceiling Methods
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Ceiling(vec.x);
			result.y = Mathx.Ceiling(vec.y);
			result.z = Mathx.Ceiling(vec.z);
		}
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having the smallest integer number that is greater than or equal to the number that the component had</param>
		public static void Ceiling(Vector3 vec, out Vector3 result) { Ceiling(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector3 Ceiling(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Ceiling(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having the smallest integer number that is greater than or equal to the number that the component had</returns>
		public static Vector3 Ceiling(Vector3 vec) { return Ceiling(ref vec); }
		
		#endregion // Ceiling Methods
		
		#region Fraction Methods
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Fraction(vec.x);
			result.y = Mathx.Fraction(vec.y);
			result.z = Mathx.Fraction(vec.z);
		}
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting vector with each component having only the fractional part of what the component had</param>
		public static void Fraction(Vector3 vec, out Vector3 result) { Fraction(ref vec, out result); }
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector3 Fraction(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Fraction(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with each component having only the fractional part of what the component had</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the vector with each component having only the fractional part of what the component had</returns>
		public static Vector3 Fraction(Vector3 vec) { return Fraction(ref vec); }
		
		#endregion // Fraction Methods
		
		#region Abs Methods
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Abs(vec.x);
			result.y = Mathx.Abs(vec.y);
			result.z = Mathx.Abs(vec.z);
		}
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <param name="result">The resulting absolute (positive) vector where each component is positive</param>
		public static void Abs(Vector3 vec, out Vector3 result) { Abs(ref vec, out result); }
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector3 Abs(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Abs(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the absolute (positive) vector where each component becomes positive</summary>
		/// <param name="vec">The vector to check with</param>
		/// <returns>Returns the absolute (positive) vector where each component is positive</returns>
		public static Vector3 Abs(Vector3 vec) { return Abs(ref vec); }
		
		#endregion // Abs Methods
		
		#region MapRange Methods
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(ref Vector3 vec, ref Vector3 inMin, ref Vector3 inMax, ref Vector3 outMin, ref Vector3 outMax, out Vector3 result) {
			result.x = Mathx.MapRange(vec.x, inMin.x, inMax.x, outMin.x, outMax.x);
			result.y = Mathx.MapRange(vec.y, inMin.y, inMax.y, outMin.y, outMax.y);
			result.z = Mathx.MapRange(vec.z, inMin.z, inMax.z, outMin.z, outMax.z);
		}
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <param name="result">The resulting vector that gets mapped from the first range to the second range</param>
		public static void MapRange(Vector3 vec, Vector3 inMin, Vector3 inMax, Vector3 outMin, Vector3 outMax, out Vector3 result) { MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax, out result); }
		
		/// <summary>Maps the vector to go from the first range [inMin, inMax] to the second range [outMin, outMax]</summary>
		/// <param name="vec">The vector to map with</param>
		/// <param name="inMin">The first range's minimum number</param>
		/// <param name="inMax">The first range's maximum number</param>
		/// <param name="outMin">The second range's minimum number</param>
		/// <param name="outMax">The second range's maximum number</param>
		/// <returns>Returns the vector that gets mapped from the first range to the second range</returns>
		public static Vector3 MapRange(ref Vector3 vec, ref Vector3 inMin, ref Vector3 inMax, ref Vector3 outMin, ref Vector3 outMax) {
			// Variables
			Vector3 result;
			
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
		public static Vector3 MapRange(Vector3 vec, Vector3 inMin, Vector3 inMax, Vector3 outMin, Vector3 outMax) { return MapRange(ref vec, ref inMin, ref inMax, ref outMin, ref outMax); }
		
		#endregion // MapRange Methods
		
		#region Trunc Methods
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Trunc(vec.x);
			result.y = Mathx.Trunc(vec.y);
			result.z = Mathx.Trunc(vec.z);
		}
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <param name="result">The resulting truncated vector</param>
		public static void Trunc(Vector3 vec, out Vector3 result) { Vector3.Trunc(ref vec, out result); }
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector3 Trunc(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Trunc(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Truncates all the components within the vector</summary>
		/// <param name="vec">The vector to truncate</param>
		/// <returns>Returns the truncated vector</returns>
		public static Vector3 Trunc(Vector3 vec) { return Vector3.Trunc(ref vec); }
		
		#endregion // Trunc Methods
		
		#region Sqrt Methods
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Sqrt(vec.x);
			result.y = Mathx.Sqrt(vec.y);
			result.z = Mathx.Sqrt(vec.z);
		}
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <param name="result">The resulting vector with all the components square rooted</param>
		public static void Sqrt(Vector3 vec, out Vector3 result) { Vector3.Sqrt(ref vec, out result); }
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector3 Sqrt(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Sqrt(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Gets the vector with all the components square rooted</summary>
		/// <param name="vec">The vector to square root with</param>
		/// <returns>Returns the vector with all the components square rooted</returns>
		public static Vector3 Sqrt(Vector3 vec) { return Sqrt(ref vec); }
		
		#endregion // Sqrt Methods
		
		#region Round Methods
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(ref Vector3 vec, int digits, out Vector3 result) {
			result.x = Mathx.Round(vec.x, digits);
			result.y = Mathx.Round(vec.y, digits);
			result.z = Mathx.Round(vec.z, digits);
		}
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(ref Vector3 vec, out Vector3 result) {
			result.x = Mathx.Round(vec.x);
			result.y = Mathx.Round(vec.y);
			result.z = Mathx.Round(vec.z);
		}
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <param name="result">The resulting vector with all the components rounded to the given digits</param>
		public static void Round(Vector3 vec, int digits, out Vector3 result) { Round(ref vec, digits, out result); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="result">The resulting vector with all the components rounded</param>
		public static void Round(Vector3 vec, out Vector3 result) { Round(ref vec, out result); }
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector3 Round(ref Vector3 vec, int digits) {
			// Variables
			Vector3 result;
			
			Round(ref vec, digits, out result);
			
			return result;
		}
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector3 Round(ref Vector3 vec) {
			// Variables
			Vector3 result;
			
			Round(ref vec, out result);
			
			return result;
		}
		
		/// <summary>Rounds all the components of the given vector to the given digits</summary>
		/// <param name="vec">The vector used to round</param>
		/// <param name="digits">The amount of digits past the decimal point to round (anything between negative 15 and positive 15 are accepted)</param>
		/// <returns>Returns the vector with all the components rounded to the given digits</returns>
		public static Vector3 Round(Vector3 vec, int digits) { return Round(ref vec, digits); }
		
		/// <summary>Rounds all the components of the given vector</summary>
		/// <param name="vec">The vector used to round</param>
		/// <returns>Returns the vector with all the components rounded</returns>
		public static Vector3 Round(Vector3 vec) { return Round(ref vec); }
		
		#endregion // Round Methods
		
		#region Smoothstep Methods
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(ref Vector3 x, ref Vector3 leftEdge, ref Vector3 rightEdge, out Vector3 result) {
			// Variables
			Vector3 tempLeftEdge;
			Vector3 tempRightEdge;
			
			Min(ref leftEdge, ref rightEdge, out tempLeftEdge);
			Max(ref leftEdge, ref rightEdge, out tempRightEdge);
			
			result.x = Mathx.Smoothstep(x.x, tempLeftEdge.x, tempRightEdge.x);
			result.y = Mathx.Smoothstep(x.y, tempLeftEdge.y, tempRightEdge.y);
			result.z = Mathx.Smoothstep(x.z, tempLeftEdge.z, tempRightEdge.z);
		}
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <param name="result">The resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</param>
		public static void Smoothstep(Vector3 x, Vector3 leftEdge, Vector3 rightEdge, out Vector3 result) { Smoothstep(ref x, ref leftEdge, ref rightEdge, out result); }
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns the resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector3 Smoothstep(ref Vector3 x, ref Vector3 leftEdge, ref Vector3 rightEdge) {
			// Variables
			Vector3 result;
			
			Smoothstep(ref x, ref leftEdge, ref rightEdge, out result);
			
			return result;
		}
		
		/// <summary>Computes a smooth Hermite interpolation that turns all the components to a value between 0 and 1</summary>
		/// <param name="x">The value for the interpolation, where leftEdge &lt; x &lt; rightEdge</param>
		/// <param name="leftEdge">The leftmost edge to where 0 would start at</param>
		/// <param name="rightEdge">The rightmost edge to where 1 would end at</param>
		/// <returns>Returns the resulting vector that has each component computed with a smooth Hermite interpolation where the value is between 0 and 1</returns>
		public static Vector3 Smoothstep(Vector3 x, Vector3 leftEdge, Vector3 rightEdge) { return Smoothstep(ref x, ref leftEdge, ref rightEdge); }
		
		#endregion // Smoothstep Methods
		
		#region Repeat Methods
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result) {
			result.x = Mathx.Repeat(vec.x, min.x, max.x);
			result.y = Mathx.Repeat(vec.y, min.y, max.y);
			result.z = Mathx.Repeat(vec.z, min.z, max.z);
		}
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within the minimum and maximum range</param>
		public static void Repeat(Vector3 vec, Vector3 min, Vector3 max, out Vector3 result) { Repeat(ref vec, ref min, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector3 Repeat(ref Vector3 vec, ref Vector3 min, ref Vector3 max) {
			// Variables
			Vector3 result;
			
			Repeat(ref vec, ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Repeats the vector over and over so the components will be within the minimum and maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="min">The minimum bounds to repeat the value around</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within the minimum and maximum range</returns>
		public static Vector3 Repeat(Vector3 vec, Vector3 min, Vector3 max) { return Repeat(ref vec, ref min, ref max); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(ref Vector3 vec, ref Vector3 max, out Vector3 result) {
			result.x = Mathx.RepeatFrom0(vec.x, max.x);
			result.y = Mathx.RepeatFrom0(vec.y, max.y);
			result.z = Mathx.RepeatFrom0(vec.z, max.z);
		}
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <param name="result">The resulting repeated value that is within 0 and the maximum range</param>
		public static void RepeatFrom0(Vector3 vec, Vector3 max, out Vector3 result) { RepeatFrom0(ref vec, ref max, out result); }
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector3 RepeatFrom0(ref Vector3 vec, ref Vector3 max) {
			// Variables
			Vector3 result;
			
			RepeatFrom0(ref vec, ref max, out result);
			
			return result;
		}
		
		/// <summary>Repeats the vector over and over so the components will be within 0 and the maximum range</summary>
		/// <param name="vec">The vector to repeat with</param>
		/// <param name="max">The maximum bounds to repeat the value around</param>
		/// <returns>Returns the resulting repeated value that is within 0 and the maximum range</returns>
		public static Vector3 RepeatFrom0(Vector3 vec, Vector3 max) { return RepeatFrom0(ref vec, ref max); }
		
		#endregion // Repeat Methods
		
		#region Approx Methods
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector3 a, ref Vector3 b, float epsilon, out bool result) {
			result = (
				Mathx.Approx(a.x, b.x, epsilon) &&
				Mathx.Approx(a.y, b.y, epsilon) &&
				Mathx.Approx(a.z, b.z, epsilon)
			);
		}
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(ref Vector3 a, ref Vector3 b, out bool result) {
			result = (
				Mathx.Approx(a.x, b.x) &&
				Mathx.Approx(a.y, b.y) &&
				Mathx.Approx(a.z, b.z)
			);
		}
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(Vector3 a, Vector3 b, float epsilon, out bool result) { Approx(ref a, ref b, epsilon, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="result">Set to true if the vectors are approximately close, false otherwise</param>
		public static void Approx(Vector3 a, Vector3 b, out bool result) { Approx(ref a, ref b, out result); }
		
		/// <summary>Finds if the vectors are approximately close to each other</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <param name="epsilon">The value used to check how close is close enough to be approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector3 a, ref Vector3 b, float epsilon) {
			// Variables
			bool result;
			
			Approx(ref a, ref b, epsilon, out result);
			
			return result;
		}
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(ref Vector3 a, ref Vector3 b) {
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
		public static bool Approx(Vector3 a, Vector3 b, float epsilon) { return Approx(ref a, ref b, epsilon); }
		
		/// <summary>Finds if the vectors are approximately close to each other (where its within 0.0000001 away from each other)</summary>
		/// <param name="a">The first vector to approximate</param>
		/// <param name="b">The second vector to approximate</param>
		/// <returns>Returns true if the vectors are approximately close, false otherwise</returns>
		public static bool Approx(Vector3 a, Vector3 b) { return Approx(ref a, ref b); }
		
		#endregion // Approx Methods
		
		#region Lerp Methods
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(ref Vector3 a, ref Vector3 b, float t, out Vector3 result) {
			result.x = Mathx.LerpClamped(a.x, b.x, t);
			result.y = Mathx.LerpClamped(a.y, b.y, t);
			result.z = Mathx.LerpClamped(a.z, b.z, t);
		}
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void LerpClamped(Vector3 a, Vector3 b, float t, out Vector3 result) { LerpClamped(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 LerpClamped(ref Vector3 a, ref Vector3 b, float t) {
			// Variables
			Vector3 result;
			
			LerpClamped(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates between the first and second vectors given a value between 0 and 1</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation, must be between 0 and 1</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 LerpClamped(Vector3 a, Vector3 b, float t) { return LerpClamped(ref a, ref b, t); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(ref Vector3 a, ref Vector3 b, float t, out Vector3 result) {
			result.x = Mathx.Lerp(a.x, b.x, t);
			result.y = Mathx.Lerp(a.y, b.y, t);
			result.z = Mathx.Lerp(a.z, b.z, t);
		}
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <param name="result">Returns the linearly interpolated vector</param>
		public static void Lerp(Vector3 a, Vector3 b, float t, out Vector3 result) { Lerp(ref a, ref b, t, out result); }
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 Lerp(ref Vector3 a, ref Vector3 b, float t) {
			// Variables
			Vector3 result;
			
			Lerp(ref a, ref b, t, out result);
			
			return result;
		}
		
		/// <summary>Linearly interpolates between the first and second vectors</summary>
		/// <param name="a">The first vector to linearly interpolate with</param>
		/// <param name="b">The second vector to linearly interpolate with</param>
		/// <param name="t">The time elapsed from the first vector towards the second vector to get the interpolation</param>
		/// <returns>Returns the linearly interpolated vector</returns>
		public static Vector3 Lerp(Vector3 a, Vector3 b, float t) { return Lerp(ref a, ref b, t); }
		
		#endregion // Lerp Methods
		
		#region MinMax Methods
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(ref Vector3 a, ref Vector3 b, out Vector3 min, out Vector3 max) {
			Mathx.MinMax(a.x, b.x, out min.x, out max.x);
			Mathx.MinMax(a.y, b.y, out min.y, out max.y);
			Mathx.MinMax(a.z, b.z, out min.z, out max.z);
		}
		
		/// <summary>Gets the minimum and maximum vectors from the two given vectors. Used for sorting max and min in a single line of code</summary>
		/// <param name="a">The first vector to get the minimum and maximum</param>
		/// <param name="b">The second vector to get the minimum and maximum</param>
		/// <param name="min">The minimum vector from the two vectors</param>
		/// <param name="max">The maximum vector from the two vectors</param>
		public static void MinMax(Vector3 a, Vector3 b, out Vector3 min, out Vector3 max) { MinMax(ref a, ref b, out min, out max); }
		
		#endregion // MinMax Methods
		
		#endregion // Public Static Methods
	}
}

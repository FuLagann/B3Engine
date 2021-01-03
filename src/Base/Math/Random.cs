
namespace B3 {
	/// <summary>A helper class for random number generation. Encompases random generation of objects like vectors</summary>
	public static class Random {
		#region Field Variables
		// Variables
		private static int seed;
		private static System.Random random;
		private static Vector2 NOne2 = -Vector2.One;
		private static Vector3 NOne3 = -Vector3.One;
		private static Vector4 NOne4 = -Vector4.One;
		private static Vector2 One2 = Vector2.One;
		private static Vector3 One3 = Vector3.One;
		private static Vector4 One4 = Vector4.One;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the randomizer's seed</summary>
		public static int Seed { get { return seed; } set {
			seed = value;
			random = new System.Random(value);
		} }
		
		/// <summary>Gets the next random value that's between 0 (inclusive) and 1 (exclusive)</summary>
		public static float Value { get { return (float)random.NextDouble(); } }
		
		/// <summary>Gets the next random value in integer form that's non-negative</summary>
		public static int ValueInt32 { get { return random.Next(); } }
		
		/// <summary>Gets a unit vector that fits within a unit circle</summary>
		public static Vector2 UnitVector2 { get {
			// Variables
			Vector2 result;
			
			Range(ref NOne2, ref One2, out result);
			Mathx.Normalize(ref result, out result);
			
			return result;
		} }
		
		/// <summary>Gets a unit vector that fits within a unit sphere</summary>
		public static Vector3 UnitVector3 { get {
			// Variables
			Vector3 result;
			
			Range(ref NOne3, ref One3, out result);
			Mathx.Normalize(ref result, out result);
			
			return result;
		} }
		
		/// <summary>Gets a unit vector that fits within a unit hypersphere</summary>
		public static Vector4 UnitVector4 { get {
			// Variables
			Vector4 result;
			
			Range(ref NOne4, ref One4, out result);
			Mathx.Normalize(ref result, out result);
			
			return result;
		} }
		
		/// <summary>Gets the next random color</summary>
		public static Color Color { get { return new Color(Range0To(256), Range0To(256), Range0To(256)); } }
		
		/// <summary>Gets the next random value that's between 0 (inclusive) and 2 PI (exclusive)</summary>
		public static float Angle { get { return 2.0f * Mathx.Pi * Value; } }
		
		/// <summary>Gets the next random value that's between 0 (inclusive) and 360 (exclusive)</summary>
		public static float AngleDeg { get { return 360.0f * Value; } }
		
		#endregion // Public Properties
		
		#region Static Constructor
		
		/// <summary>A static constructor for setting up the random static class</summary>
		static Random() { Seed = System.Environment.TickCount; }
		
		#endregion // Static Constructor
		
		#region Public Static Methods
		
		#region Range Methods
		
		/// <summary>Makes a random number that is within the given range</summary>
		/// <param name="min">The minimum extent of the random number (inclusive)</param>
		/// <param name="max">The maximum extent of the random number (exclusive)</param>
		/// <returns>Returns the randomly generated number that's within the given range</returns>
		public static float Range(float min, float max) { return ((max - min) * Value + min); }
		
		/// <summary>Makes a random number that is within the given range</summary>
		/// <param name="min">The minimum extent of the random number (inclusive)</param>
		/// <param name="max">The maximum extent of the random number (exclusive)</param>
		/// <returns>Returns the randomly generated number that's within the given range</returns>
		public static int Range(int min, int max) { return (int)((max - min) * Value + min); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(ref Vector2 min, ref Vector2 max, out Vector2 result) {
			result.x = Range(min.x, max.x);
			result.y = Range(min.y, max.y);
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(Vector2 min, Vector2 max, out Vector2 result) { Range(ref min, ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector2 Range(ref Vector2 min, ref Vector2 max) {
			// Variables
			Vector2 result;
			
			Range(ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector2 Range(Vector2 min, Vector2 max) { return Range(ref min, ref max); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(ref Vector3 min, ref Vector3 max, out Vector3 result) {
			result.x = Range(min.x, max.x);
			result.y = Range(min.y, max.y);
			result.z = Range(min.z, max.z);
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(Vector3 min, Vector3 max, out Vector3 result) { Range(ref min, ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector3 Range(ref Vector3 min, ref Vector3 max) {
			// Variables
			Vector3 result;
			
			Range(ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector3 Range(Vector3 min, Vector3 max) { return Range(ref min, ref max); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(ref Vector4 min, ref Vector4 max, out Vector4 result) {
			result.x = Range(min.x, max.x);
			result.y = Range(min.y, max.y);
			result.z = Range(min.z, max.z);
			result.w = Range(min.w, max.w);
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range(Vector4 min, Vector4 max, out Vector4 result) { Range(ref min, ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector4 Range(ref Vector4 min, ref Vector4 max) {
			// Variables
			Vector4 result;
			
			Range(ref min, ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range</summary>
		/// <param name="min">The minimum extent of the random vector (inclusive)</param>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector4 Range(Vector4 min, Vector4 max) { return Range(ref min, ref max); }
		
		#endregion // Range Methods
		
		#region Range0To Methods
		
		/// <summary>Makes a random number that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random number (exclusive)</param>
		/// <returns>Returns the randomly generated number that's within the given range</returns>
		public static float Range0To(float max) { return Range(0.0f, max); }
		
		/// <summary>Makes a random number that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random number (exclusive)</param>
		/// <returns>Returns the randomly generated number that's within the given range</returns>
		public static int Range0To(int max) { return Range(0, max); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(ref Vector2 max, out Vector2 result) {
			result.x = Range0To(max.x);
			result.y = Range0To(max.y);
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(Vector2 max, out Vector2 result) { Range0To(ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector2 Range0To(ref Vector2 max) {
			// Variables
			Vector2 result;
			
			Range0To(ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector2 Range0To(Vector2 max) { return Range0To(ref max); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(ref Vector3 max, out Vector3 result) {
			result.x = Range0To(max.x);
			result.y = Range0To(max.y);
			result.z = Range0To(max.z);
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(Vector3 max, out Vector3 result) { Range0To(ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector3 Range0To(ref Vector3 max) {
			// Variables
			Vector3 result;
			
			Range0To(ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector3 Range0To(Vector3 max) { return Range0To(ref max); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(ref Vector4 max, out Vector4 result) {
			result.x = Range0To(max.x);
			result.y = Range0To(max.y);
			result.z = Range0To(max.z);
			result.w = Range0To(max.w);
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <param name="result">The resulting randomly generated vector that's within the given range</param>
		public static void Range0To(Vector4 max, out Vector4 result) { Range0To(ref max, out result); }
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector4 Range0To(ref Vector4 max) {
			// Variables
			Vector4 result;
			
			Range0To(ref max, out result);
			
			return result;
		}
		
		/// <summary>Makes a random vector that is within the given range with a minimum of 0</summary>
		/// <param name="max">The maximum extent of the random vector (exclusive)</param>
		/// <returns>Returns the randomly generated vector that's within the given range</returns>
		public static Vector4 Range0To(Vector4 max) { return Range0To(ref max); }
		
		#endregion // Range0To Methods
		
		#region Chance Methods
		
		/// <summary>Finds if the chance of the given percentage is rolled true</summary>
		/// <param name="percentage">The percentage of chance used to roll with, must be between 0 and 1</param>
		/// <returns>Returns true if the chance roll is within the percentage provided</returns>
		public static bool Chance(float percentage) {
			if(Mathx.Abs(percentage) >= 1.0f) {
				return true;
			}
			
			return (Value <= Mathx.Abs(percentage));
		}
		
		/// <summary>Finds if the chance of the given percentage is rolled true</summary>
		/// <param name="percentage">The percentage of chance used to roll with, must be between 0 and 100</param>
		/// <returns>Returns true if the chance roll is within the percentage provided</returns>
		public static bool Chance(int percentage) { return Chance((float)percentage / 100.0f); }
		
		#endregion // Chance Methods
		
		#endregion // Public Static Methods
	}
}

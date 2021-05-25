
namespace B3 {
	/// <summary>A helper class for random number generation. Encompases random generation of objects like vectors</summary>
	public static class Random {
		#region Field Variables
		// Variables
		private static int seed;
#if TESTABLE
		/// <summary>The state of the random number generator, exposed for testing to make sure it's consistant</summary>
		public static int state;
#else
		private static int state;
#endif
		private static Vector2 NOne2 = -Vector2.One;
		private static Vector3 NOne3 = -Vector3.One;
		private static Vector4 NOne4 = -Vector4.One;
		private static Vector2 One2 = Vector2.One;
		private static Vector3 One3 = Vector3.One;
		private static Vector4 One4 = Vector4.One;
		private static readonly int[] Primes = new int[] {
			198491317,
			6542989,
			325144229,
			25752877,
			42070339
		};
		private const uint Noise1 = 0x68E31DA4;
		private const uint Noise2 = 0xB5297A4D;
		private const uint Noise3 = 0x1B56C4E9;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the randomizer's seed</summary>
		public static int Seed { get { return seed; } set { seed = value; } }
		
		/// <summary>Gets the next random value that's between 0 (inclusive) and 1 (exclusive)</summary>
		public static float Value { get { return GenerateNextFloat01(out state, state); } }
		
		/// <summary>Gets the next random value in integer form that's non-negative</summary>
		public static int ValueInt32 { get { return GenerateNextInt32(out state, state); } }
		
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
		public static float Angle { get { return Mathx.TwoPi * Value; } }
		
		/// <summary>Gets the next random value that's between 0 (inclusive) and 360 (exclusive)</summary>
		public static float AngleDeg { get { return 360.0f * Value; } }
		
		#endregion // Public Properties
		
		#region Static Constructor
		
		/// <summary>A static constructor for setting up the random static class</summary>
		static Random() {
			Seed = System.Environment.TickCount;
			state = System.Environment.TickCount / 4;
		}
		
		#endregion // Static Constructor
		
		#region Public Static Methods
		
		#region Noise Methods
		
		/// <summary>Transforms a set of floating point numbers into a singular floating point number using a noise hash function</summary>
		/// <param name="xyzwplus">The list of numbers used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(params float[] xyzwplus) {
			// Variables
			int[] converted = new int[xyzwplus.Length];
			float floor;
			int temp;
			
			for(int i = 0; i < xyzwplus.Length; i++) {
				converted[i] = (int)xyzwplus[i];
				floor = Mathx.Fraction(xyzwplus[i]);
				if(!Mathx.Approx(floor, 0.0f)) {
					foreach(char c in $"{floor}") {
						converted[i] += (int)c;
					}
				}
			}
			
			return GenerateNextFloat01(out temp, converted);
		}
		//0.07283131
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xy">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(ref Vector2 xy) { return Noise(xy.x, xy.y); }
		
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xy">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(Vector2 xy) { return Noise(ref xy); }
		
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xyz">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(ref Vector3 xyz) { return Noise(xyz.x, xyz.y, xyz.z); }
		
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xyz">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(Vector3 xyz) { return Noise(ref xyz); }
		
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xyzw">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(ref Vector4 xyzw) { return Noise(xyzw.x, xyzw.y, xyzw.z, xyzw.w); }
		
		/// <summary>Transforms a vector into a singular floating point number using a noise hash function</summary>
		/// <param name="xyzw">The vector used for the arguments</param>
		/// <returns>Returns a number scrambled using a noise function</returns>
		public static float Noise(Vector4 xyzw) { return Noise(ref xyzw); }
		
		#endregion // Noise Methods
		
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
		
		#region Private Static Methods
		
		/// <summary>Generates the next random float number using the list of positions</summary>
		/// <param name="outPosition">The new position that gets outputted to use as a reoccurring state</param>
		/// <param name="positions">The list of positions to generate with</param>
		/// <returns>Returns a randomly generated float</returns>
#if TESTABLE
		public static float GenerateNextFloat01(out int outPosition, params int[] positions) {
#else
		private static float GenerateNextFloat01(out int outPosition, params int[] positions) {
#endif
			// Variables
			uint generated = GenerateNext(positions);
			
			outPosition = (int)generated;
			
			return (float)((ushort)generated) / (float)ushort.MaxValue;
		}
		
		/// <summary>Generates the next random integer number using the list of positions</summary>
		/// <param name="outPosition">The new position that gets outputted to use as a reoccurring state</param>
		/// <param name="positions">The list of positions to generate with</param>
		/// <returns>Returns a randomly generate integer</returns>
#if TESTABLE
		public static int GenerateNextInt32(out int outPosition, params int[] positions) {
#else
		private static int GenerateNextInt32(out int outPosition, params int[] positions) {
#endif
			// Variables
			int generated = (int)GenerateNext(positions);
			
			outPosition = generated;
			
			return generated;
		}
		
		/// <summary>Generates the next random number using the list of positions</summary>
		/// <param name="positions">The list of positions to generate with</param>
		/// <returns>Returns a randomly generated unsigned integer</returns>
#if TESTABLE
		public static uint GenerateNext(params int[] positions) {
#else
		private static uint GenerateNext(params int[] positions) {
#endif
			// Variables
			int position = 0;
			int index = -1;
			uint mangled;
			
			foreach(int pos in positions) {
				if(index == -1) {
					position += pos;
					index++;
				}
				else {
					position += (Random.Primes[index++] * pos);
					index %= Random.Primes.Length;
				}
				position += pos;
			}
			mangled = (uint)position;
			
			mangled *= Random.Noise1;
			mangled += (uint)seed;
			mangled ^= (mangled >> 8);
			mangled += Random.Noise2;
			mangled ^= (mangled << 8);
			mangled *= Random.Noise3;
			mangled ^= (mangled >> 8);
			
			return mangled;
		}
		
		#endregion // Private Static Methods
	}
}

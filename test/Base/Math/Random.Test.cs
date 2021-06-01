
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Random"/> static class to make sure it works correctly. Contains 68 tests</summary>
	[CollectionDefinition("Random", DisableParallelization = true)]
	public class RandomTest {
		#region Public Constructors
		
		public RandomTest() {
			Random.Seed = 1234567890;
		}
		
		#endregion // Public Constructors
		
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Random.GenerateNext(int[])"/> functionality.
		/// Inputs a state and checks to see if the output is correct
		/// </summary>
		[Theory]
		[InlineData(0, 3063190229)]
		[InlineData(1, 2689250694)]
		[InlineData(2, 2971965099)]
		[InlineData(3, 1712531249)]
		[InlineData(4, 1387866811)]
		public void GenerateNext_SimpleStates_ReturnsUInt32(int state, uint expected) {
			Assert.Equal(expected, Random.GenerateNext(state));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.GenerateNextInt32(out int, int[])"/> functionality.
		/// Inputs a state and checks to see if the output is correct
		/// </summary>
		[Theory]
		[InlineData(0, -1231777067)]
		[InlineData(-1231777067, 1495252724)]
		[InlineData(1495252724, -1727860201)]
		[InlineData(-1727860201, 430456237)]
		[InlineData(430456237, -2136687156)]
		public void GenerateNextInt32_ContinuousStates_ReturnsInt32(int state, int expected) {
			// Variables
			int temp;
			
			Assert.Equal(expected, Random.GenerateNextInt32(out temp, state));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.GenerateNextFloat01(out int, int[])"/> functionality.
		/// Inputs a state and checks to see if the output is correct
		/// </summary>
		[Theory]
		[InlineData(0, 0.5735714f)]
		[InlineData(-1231777067, 0.745922f)]
		[InlineData(1495252724, 0.9456779f)]
		[InlineData(-1727860201, 0.2409247f)]
		[InlineData(430456237, 0.74140537f)]
		public void GenerateNextFloat01_ContinuousStates_ReturnsFloat(int state, float expected) {
			// Variables
			int temp;
			
			Assert.Equal(expected, Random.GenerateNextFloat01(out temp, state));
		}
		
		#region Noise Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(float[])"/> functionality using simple whole numbers.
		/// Inputs a state that are just whole numbers and checks to see if the output is correct
		/// </summary>
		[Theory]
		[InlineData(0.5735714f, 0)]
		[InlineData(0.7090868f, 1)]
		[InlineData(0.58855575f, 2)]
		[InlineData(0.15309377f, 3)]
		[InlineData(0.16691844f, 4)]
		public void Noise_SimpleNumbers_ReturnsFloat(float expected, float x) {
			Assert.Equal(expected, Random.Noise(x));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(float[])"/> functionality using fractional numbers.
		/// Inputs a state that are fractional numbers and checks to see if the output is correct
		/// </summary>
		[Theory]
		[InlineData(0.5735714f, 0)]
		[InlineData(0.07731746f, 0.1)]
		[InlineData(0.14233616f, 0.2)]
		[InlineData(0.079835206f, 0.3)]
		[InlineData(0.9072404f, 0.4)]
		public void Noise_FractionalNumbers_ReturnsFloat(float expected, float x) {
			Assert.Equal(expected, Random.Noise(x));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(float[])"/> functionality using a set of numbers.
		/// Inputs a state that are a list of numbers and checks to see if the input is correct
		/// </summary>
		[Theory]
		[InlineData(0.6561532f, 1, 2, 3)]
		[InlineData(0.3563897f, 1, 2, 4)]
		[InlineData(0.21994354f, 2, 2, 4)]
		[InlineData(0.3123827f, 2, 3, 4)]
		[InlineData(0.5735714f, 0, 0, 0)]
		public void Noise_SetOfNumbers_ReturnsFloat(float expected, float x, float y, float z) {
			Assert.Equal(expected, Random.Noise(x, y, z));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(ref Vector2)"/> functionality using a 2D vector.
		/// Inputs a state that is a vector and checks to see if the input is correct
		/// </summary>
		[Theory]
		[InlineData(0.94288546f, 1, 1)]
		[InlineData(0.30435646f, 1.1, 1)]
		[InlineData(0.06736858f, 1.1, 1.1)]
		[InlineData(0.7502556f, 1.1, 1.2)]
		[InlineData(0.8491798f, 1.5, 1.5)]
		public void Noise_Vector2_ReturnsFloat(float expected, float x, float y) {
			// Variables
			Vector2 vec = new Vector2(x, y);
			
			Assert.Equal(expected, Random.Noise(ref vec));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(ref Vector3)"/> functionality using a 3D vector.
		/// Inputs a state that is a vector and checks to see if the input is correct
		/// </summary>
		[Theory]
		[InlineData(0.6561532f, 1, 2, 3)]
		[InlineData(0.3563897f, 1, 2, 4)]
		[InlineData(0.21994354f, 2, 2, 4)]
		[InlineData(0.3123827f, 2, 3, 4)]
		[InlineData(0.5735714f, 0, 0, 0)]
		public void Noise_Vector3_ReturnsFloat(float expected, float x, float y, float z) {
			// Variables
			Vector3 vec = new Vector3(x, y, z);
			
			Assert.Equal(expected, Random.Noise(ref vec));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Noise(ref Vector4)"/> functionality using a 4D vector.
		/// Inputs a state that is a vector and checks to see if the input is correct
		/// </summary>
		[Theory]
		[InlineData(0.52636f, -1, 1, -1, 1)]
		[InlineData(0.055344474f, -10, 10, -100, 100)]
		[InlineData(0.8081483f, -10, -0.1, -100, -1)]
		[InlineData(0.44077212f, 0, 10, 0, 0.1)]
		[InlineData(0.93966585f, -0, 10, -10, 30)]
		public void Noise_Vector4_ReturnsFloat(float expected, float x, float y, float z, float w) {
			// Variables
			Vector4 vec = new Vector4(x, y, z, w);
			
			Assert.Equal(expected, Random.Noise(ref vec));
		}
		
		#endregion // Noise Test Methods
		
		#region Range Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Range(float, float)"/> functionality.
		/// Gets a number within a specific range and checks to see if its within that range
		/// </summary>
		[Theory]
		[InlineData(0, 0, 0.00001f)]
		[InlineData(255, 0, 1)]
		[InlineData(1024, -1, 1)]
		[InlineData(-100, -1000, 0)]
		[InlineData(int.MaxValue, -12, -4)]
		public void Range_ReturnsWithinRange(int state, float min, float max) {
			Random.state = state;
			Assert.InRange(Random.Range(min, max), min, max);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Range(float, float)"/> functionality.
		/// Gets a number within a specific range at state 0 and checks to see if its the correct number
		/// </summary>
		[Theory]
		[InlineData(0.05735714, 0, 0.1f)]
		[InlineData(0.5735714, 0, 1)]
		[InlineData(0.14714277, -1, 1)]
		[InlineData(-426.4286, -1000, 0)]
		[InlineData(-7.411429, -12, -4)]
		public void Range_ReturnsFloat(float expected, float min, float max) {
			Random.state = 0;
			Assert.Equal(expected, Random.Range(min, max));
		}
		
		#endregion // Range Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Random.Angle"/> functionality.
		/// Gets a number within a radian angle [0, 2 pi] and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		public void Angle_ReturnsWithinRange(int state) {
			Random.state = state;
			Assert.InRange(Random.Angle, 0.0f, Mathx.TwoPi);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.AngleDeg"/> functionality.
		/// Gets a number within a radian angle [0, 360] and checks to see if its correct
		/// </summary>
		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		public void AngleDeg_ReturnsWithinRange(int state) {
			Random.state = state;
			Assert.InRange(Random.AngleDeg, 0.0f, 360.0f);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.UnitVector2"/> functionality.
		/// Checks to see if the randomizer returns back a normalized vector
		/// </summary>
		[Fact]
		public void UnitVector2_ReturnsUnitVector2() {
			// Variables
			Vector2 expected = new Vector2(0.2866143f, 0.958046f);
			
			Random.state = 0;
			Assert.Equal(expected, Random.UnitVector2);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.UnitVector3"/> functionality.
		/// Checks to see if the randomizer returns back a normalized vector
		/// </summary>
		[Fact]
		public void UnitVector3_ReturnsUnitVector3() {
			// Variables
			Vector3 expected = new Vector3(0.14304754f, 0.47815523f, 0.8665478f);
			
			Random.state = 0;
			Assert.Equal(expected, Random.UnitVector3);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Random.UnitVector4"/> functionality.
		/// Checks to see if the randomizer returns back a normalized vector
		/// </summary>
		[Fact]
		public void UnitVector4_ReturnsUnitVector4() {
			// Variables
			Vector4 expected = new Vector4(0.12775445f, 0.42703605f, 0.77390593f, -0.44987628f);
			
			Random.state = 0;
			Assert.Equal(expected, Random.UnitVector4);
		}
		
		#endregion // Public Test Methods
	}
}


namespace B3.Graphics {
	/// <summary>A class that holds parameters for setting up textures</summary>
	public class TexParam {
		#region Field Variables
		// Variables
		/// <summary>Sets the wrap for the texture coordinate going left and right</summary>
		public WrapMode wrapS;
		/// <summary>Sets the wrap for the texture coordintate going up and down</summary>
		public WrapMode wrapT;
		/// <summary>Sets the wrap for the texture coordinate going in and out (for 3D textures)</summary>
		public WrapMode? wrapR;
		/// <summary>Sets the minimum level-of-detail, a float that limits the selection of the highest resolution mipmap (lowest mipmap level). Initially -1000</summary>
		public float? minLOD;
		/// <summary>Sets the maximum level-of-detail, a float that limits the selection of the lowest resolution mipmap (highest mipmap level). Initially 1000</summary>
		public float? maxLOD;
		/// <summary>Specifies a fixed bias value to set the level-of-detail. Initially 0.0</summary>
		public float? lodBias;
		/// <summary>Specifies the index of the lowest defined mipmap level. Initially 0</summary>
		public int? baseLevel;
		/// <summary>Specifies the index of the highest defined mipmap level. Initially 1000</summary>
		public int? maxLevel;
		/// <summary>Sets the texture minifying function used in the level-of-detail function</summary>
		public Filter minFilter;
		/// <summary>Sets the texture magnifying function used in the level-of-detail function</summary>
		public Filter magFilter;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for setting up the texture parameters</summary>
		public TexParam() {
			this.wrapS = WrapMode.Repeat;
			this.wrapT = WrapMode.Repeat;
			this.minFilter = Filter.Nearest;
			this.magFilter = Filter.Nearest;
			this.wrapR = null;
			this.minLOD = null;
			this.maxLOD = null;
			this.lodBias = null;
			this.baseLevel = null;
			this.maxLevel = null;
		}
		
		#endregion // Public Constructors
		
		#region Nested Objects
		
		/// <summary>The type of wrapping used in <see cref="B3.Graphics.TexParam.wrapS"/>, <see cref="B3.Graphics.TexParam.wrapT"/>, and <see cref="B3.Graphics.TexParam.wrapR"/></summary>
		public enum WrapMode : int {
			/// <summary>Repeats the same texture if the UV boundary goes past 0.0 or 1.0</summary>
			Repeat = 10497,
			/// <summary>A border will appear when the UV boundary goes past 0.0 or 1.0</summary>
			ClampToBorder = 33069,
			/// <summary>The UV boundary will be bound to 0.0 and 1.0</summary>
			ClampToEdge = 33071,
			/// <summary>Repeats the same texture, mirroring each iteration, if the UV boundary goes past 0.0 or 1.0</summary>
			MirroredRepeat = 33648
		}
		
		/// <summary>The type of filtering used in <see cref="B3.Graphics.TexParam.minFilter"/> and <see cref="B3.Graphics.TexParam.magFilter"/></summary>
		public enum Filter {
			/// <summary>Returns the pixel that is closest to the coordinates (aliased texture)</summary>
			Nearest = 9728,
			/// <summary>Returns the weighted average of the 4 pixels surrounding the given coordinates (anti-aliased texture)</summary>
			Linear = 9729,
			/// <summary>Texture uses <see cref="B3.Graphics.TexParam.Filter.Nearest"/> while mipmap uses <see cref="B3.Graphics.TexParam.Filter.Nearest"/></summary>
			NearestMipmapNearest = 9984,
			/// <summary>Texture uses <see cref="B3.Graphics.TexParam.Filter.Linear"/> while mipmap uses <see cref="B3.Graphics.TexParam.Filter.Nearest"/></summary>
			LinearMipmapNearest = 9985,
			/// <summary>Texture uses <see cref="B3.Graphics.TexParam.Filter.Nearest"/> while mipmap uses <see cref="B3.Graphics.TexParam.Filter.Linear"/></summary>
			NearestMipmapLinear = 9986,
			/// <summary>Texture uses <see cref="B3.Graphics.TexParam.Filter.Linear"/> while mipmap uses <see cref="B3.Graphics.TexParam.Filter.Linear"/></summary>
			LinearMipmapLinear = 9987
		}
		
		#endregion // Nested Objects
	}
}

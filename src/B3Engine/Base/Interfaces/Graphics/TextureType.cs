
namespace B3.Graphics {
	/// <summary>An enumeration of all the different texture types</summary>
	public enum TextureType {
		/// <summary>A one dimensional texture (typically just a strip of colors)</summary>
		Texture1D,
		/// <summary>An array of one dimensional textures</summary>
		Texture1DArray,
		/// <summary>A two dimensional texture (typically just an image)</summary>
		Texture2D,
		/// <summary>An array of two dimensional textures</summary>
		Texture2DArray,
		/// <summary>Holds the data storage, format, dimensions, and number of samples of a multisample texture's image</summary>
		Texture2DMultiSample,
		/// <summary>An array that holds the data storage, format, dimensions, and number of samples of a multisample texture's image</summary>
		Texture2DMultiSampleArray,
		/// <summary>A three dimensional texture</summary>
		Texture3D,
		/// <summary>A cube of textures where each side is a different texture</summary>
		TextureCubeMap,
		/// <summary>An array of cubes of textures where each side is a different texture</summary>
		TextureCubeMapArray,
		/// <summary>A two dimensional texture where the max width and height are the to the pixel size and not to 1.0</summary>
		TextureRectangle
	}
}

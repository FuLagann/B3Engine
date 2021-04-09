
namespace B3.Graphics {
	/// <summary>An interface for textures</summary>
	public interface ITexture : IGraphicsBuffer {
		#region Properties
		
		/// <summary>Gets the type of texture that the texture is</summary>
		TextureType Target { get; }
		
		/// <summary>Gets and sets the parameters of the texture</summary>
		TexParam Parameters { get; set; }
		
		#endregion // Properties
		
		#region Methods
		
		/// <summary>Sets the texture from the given file</summary>
		/// <param name="location">The location of the file</param>
		void SetFromFile(string location);
		
		#endregion // Methods
	}
}

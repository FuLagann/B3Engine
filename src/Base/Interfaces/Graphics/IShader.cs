
namespace B3.Graphics {
	/// <summary>An interface for shaders to be used by the shader program</summary>
	public interface IShader : System.IDisposable {
		#region Properties
		
		/// <summary>Gets the handle of the shader to be used by the graphics library</summary>
		int Handle { get; }
		
		/// <summary>Gets the type of shader that the shader is</summary>
		ShaderType ShaderType { get; }
		
		#endregion // Properties
	}
}

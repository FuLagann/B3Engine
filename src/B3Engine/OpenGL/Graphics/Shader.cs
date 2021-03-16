
using B3.Events;

using OpenTK.Graphics.OpenGL;

using ShaderType = B3.Graphics.ShaderType;

using TKShaderType = OpenTK.Graphics.OpenGL.ShaderType;

namespace B3.Graphics {
	/// <summary>A class that creates an OpenGL shader</summary>
	public class Shader : IShader {
		#region Field Variables
		// Variables
		private int handle;
		private ShaderType type;
		private string errorMessage;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the handle of the shader to be used by the graphics library</summary>
		public int Handle { get { return this.handle; } }
		
		/// <summary>Gets the type of shader that the shader is</summary>
		public ShaderType ShaderType { get { return this.type; } }
		
		/// <summary>Gets if the shader had an error while compiling</summary>
		public bool HasError { get { return !string.IsNullOrEmpty(this.errorMessage); } }
		
		/// <summary>Gets the error message while compiling if any</summary>
		public string ErrorMessage { get { return this.errorMessage; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a shader</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="type">The type of shader to create</param>
		/// <param name="shaderCode">The code of the shader to create with</param>
		public Shader(IGame game, ShaderType type, string shaderCode) {
			this.type = type;
			this.errorMessage = "";
			if(game.IsInitialized) {
				this.Initialize(shaderCode);
			}
			else {
				game.OnLoad += delegate(EventArgs args) {
					this.Initialize(shaderCode);
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		/// <summary>Creates a shader from a file location</summary>
		/// <param name="game">The game used to make sure OpenGL was loaded in correctly</param>
		/// <param name="type">The type of shader to create</param>
		/// <param name="location">The location of the file to get the shader's code from</param>
		/// <returns>Returns a new shader</returns>
		public static Shader FromFile(IGame game, ShaderType type, string location) {
			return new Shader(game, type, FS.Read(location));
		}
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Disposes of the shader</summary>
		public void Dispose() { GL.DeleteShader(this.handle); }
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Initializes the shader</summary>
		/// <param name="shaderCode">The shader's code</param>
		private void Initialize(string shaderCode) {
			this.handle = GL.CreateShader(this.GetOpenGLShaderType());
			GL.ShaderSource(this.handle, shaderCode);
			GL.CompileShader(this.handle);
			this.errorMessage = GL.GetShaderInfoLog(this.handle);
		}
		
		/// <summary>Gets the opengl enumeration of shader type</summary>
		/// <returns>Returns the OpenGL shader type</returns>
		private TKShaderType GetOpenGLShaderType() {
			switch(this.type) {
				default:
				case ShaderType.Vertex: return TKShaderType.VertexShader;
				case ShaderType.Compute: return TKShaderType.ComputeShader;
				case ShaderType.Fragment: return TKShaderType.FragmentShader;
				case ShaderType.Geometry: return TKShaderType.GeometryShader;
				case ShaderType.TessellationControl: return TKShaderType.TessControlShader;
				case ShaderType.TessellationEvaluation: return TKShaderType.TessEvaluationShader;
			}
		}
		
		#endregion // Private Methods
	}
}

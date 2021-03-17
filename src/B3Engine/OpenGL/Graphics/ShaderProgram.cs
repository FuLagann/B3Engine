
using B3.Events;

using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	/// <summary>A class for a shader program used by OpenGL to use shaders on meshes and models</summary>
	public class ShaderProgram : IShaderProgram {
		#region Field Variables
		// Variables
		private int handle;
		private IShader[] shaders;
		private string errorMessage;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the handle used by graphics libraries to reference the shader program</summary>
		public int Handle { get { return handle; } }
		
		/// <summary>Gets and sets the shaders used in the program</summary>
		public IShader[] Shaders { get; set; }
		
		/// <summary>Gets if the shader had an error while compiling</summary>
		public bool HasError { get {
			// foreach(Shader shader in this.shaders) {
			// 	if(shader.HasError) { return true; }
			// }
			// return false;
			return !string.IsNullOrEmpty(this.errorMessage);
		} }
		
		/// <summary>Gets the error message while compiling if any</summary>
		public string ErrorMessage { get {
			// Variables
			// string error = "";
			
			// foreach(Shader shader in this.shaders) {
			// 	error += $"{shader.ShaderType}:\n\t{(shader.HasError ? shader.ErrorMessage : "No Errors.")}";
			// }
			
			// return error;
			return this.errorMessage;
		} }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the shader program</summary>
		/// <param name="game">The game used to check if OpenGL is loaded in correctly</param>
		/// <param name="shaders">The list of shaders to include in the program</param>
		public ShaderProgram(IGame game, params Shader[] shaders) {
			this.shaders = shaders;
			this.errorMessage = "";
			if(game.IsInitialized) {
				this.Initialize();
			}
			else {
				game.OnLoad += delegate(EventArgs args) {
					this.Initialize();
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Uses the shader program</summary>
		public void Use() { GL.UseProgram(this.handle); }
		
		/// <summary>Gets the location of the attribute from the given name</summary>
		/// <param name="name">The name of the attribute</param>
		/// <returns>Returns the location of the attribute to be used by the graphics libraries</returns>
		public int GetAttributeLocation(string name) { return GL.GetAttribLocation(this.handle, name); }
		
		/// <summary>Gets the location of the uniform from the given name</summary>
		/// <param name="name">The name of the uniform</param>
		/// <returns>Returns the location of the uniform to be used by the graphics library</returns>
		public int GetUniformLocation(string name) { return GL.GetUniformLocation(this.handle, name); }
		
		/// <summary>Sends over a single floating point number</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="unif1">The number to send over to the shaders</param>
		public void SendUniform(string name, float unif1) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			GL.Uniform1(index, unif1);
		}
		
		/// <summary>Sends over a single integer</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="unif1">The number to send over to the shaders</param>
		public void SendUniform(string name, int unif1) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			GL.Uniform1(index, unif1);
		}
		
		/// <summary>Sends over a single boolean</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="unif1">The number to send over to the shaders</param>
		public void SendUniform(string name, bool unif1) { this.SendUniform(name, unif1 ? 0 : 1); }
		
		/// <summary>Sends over two floating point numbers as a <see cref="B3.Vector2"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector2"/> to send over to the shaders</param>
		public void SendUniform(string name, Vector2 vec) { this.SendUniform(name, ref vec); }
		
		/// <summary>Sends over two floating point numbers as a <see cref="B3.Vector2"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector2"/> to send over to the shaders</param>
		public void SendUniform(string name, ref Vector2 vec) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			GL.Uniform2(index, vec.x, vec.y);
		}
		
		/// <summary>Sends over three floating point numbers as a <see cref="B3.Vector3"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector3"/> to send over to the shaders</param>
		public void SendUniform(string name, Vector3 vec) { this.SendUniform(name, ref vec); }
		
		/// <summary>Sends over three floating point numbers as a <see cref="B3.Vector3"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector3"/> to send over to the shaders</param>
		public void SendUniform(string name, ref Vector3 vec) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			GL.Uniform3(index, vec.x, vec.y, vec.z);
		}
		
		/// <summary>Sends over four floating point numbers as a <see cref="B3.Vector4"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector4"/> to send over to the shaders</param>
		public void SendUniform(string name, Vector4 vec) { this.SendUniform(name, ref vec); }
		
		/// <summary>Sends over four floating point numbers as a <see cref="B3.Vector4"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector4"/> to send over to the shaders</param>
		public void SendUniform(string name, ref Vector4 vec) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			GL.Uniform4(index, vec.x, vec.y, vec.z, vec.w);
		}
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		public void SendUniform(string name, Matrix matrix) { this.SendUniform(name, false, ref matrix); }
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		public void SendUniform(string name, ref Matrix matrix) { this.SendUniform(name, false, ref matrix); }
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="transpose">Set to true to transpose the matrix before passing it through</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		public void SendUniform(string name, bool transpose, Matrix matrix) { this.SendUniform(name, transpose, matrix); }
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="transpose">Set to true to transpose the matrix before passing it through</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		public void SendUniform(string name, bool transpose, ref Matrix matrix) {
			// Variables
			int index = this.GetUniformLocation(name);
			
			if(index == -1) { return; }
			// Variables
			float[] marr = matrix.ToArray();
			
			GL.UniformMatrix4(index, marr.Length, transpose, marr);
		}
		
		/// <summary>Disposes of the shader program</summary>
		public void Dispose() {
			foreach(Shader shader in this.shaders) {
				shader.Dispose();
			}
			GL.DeleteProgram(this.handle);
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Initializes the shader program</summary>
		private void Initialize() {
			this.handle = GL.CreateProgram();
			foreach(Shader shader in this.shaders) {
				GL.AttachShader(this.handle, shader.Handle);
			}
			GL.LinkProgram(this.handle);
			this.errorMessage = GL.GetProgramInfoLog(this.handle);
			foreach(Shader shader in this.shaders) {
				shader.Dispose();
			}
		}
		
		#endregion // Private Methods
	}
}

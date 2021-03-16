
namespace B3.Graphics {
	/// <summary>An interface for shader programs used to render the scenes in unique ways</summary>
	public interface IShaderProgram : System.IDisposable {
		#region Properties
		
		/// <summary>Gets the handle used by graphics libraries to reference the shader program</summary>
		int Handle { get; }
		
		/// <summary>Gets and sets the shaders used in the program</summary>
		IShader[] Shaders { get; set; }
		
		/// <summary>Gets if the shader had an error while compiling</summary>
		bool HasError { get; }
		
		/// <summary>Gets the error message while compiling if any</summary>
		string ErrorMessage { get; }
		
		#endregion // Properties
		
		#region Methods
		
		/// <summary>Uses the shader program</summary>
		void Use();
		
		/// <summary>Gets the location of the attribute from the given name</summary>
		/// <param name="name">The name of the attribute</param>
		/// <returns>Returns the location of the attribute to be used by the graphics libraries</returns>
		int GetAttributeLocation(string name);
		
		/// <summary>Gets the location of the uniform from the given name</summary>
		/// <param name="name">The name of the uniform</param>
		/// <returns>Returns the location of the uniform to be used by the graphics library</returns>
		int GetUniformLocation(string name);
		
		/// <summary>Sends over a single floating point number</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="unif1">The number to send over to the shaders</param>
		void SendUniform(string name, float unif1);
		
		/// <summary>Sends over two floating point numbers as a <see cref="B3.Vector2"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector2"/> to send over to the shaders</param>
		void SendUniform(string name, Vector2 vec);
		
		/// <summary>Sends over two floating point numbers as a <see cref="B3.Vector2"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vector">The <see cref="B3.Vector2"/> to send over to the shaders</param>
		void SendUniform(string name, ref Vector2 vector);
		
		/// <summary>Sends over three floating point numbers as a <see cref="B3.Vector3"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector3"/> to send over to the shaders</param>
		void SendUniform(string name, Vector3 vec);
		
		/// <summary>Sends over three floating point numbers as a <see cref="B3.Vector3"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector3"/> to send over to the shaders</param>
		void SendUniform(string name, ref Vector3 vec);
		
		/// <summary>Sends over four floating point numbers as a <see cref="B3.Vector4"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector4"/> to send over to the shaders</param>
		void SendUniform(string name, Vector4 vec);
		
		/// <summary>Sends over four floating point numbers as a <see cref="B3.Vector4"/></summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="vec">The <see cref="B3.Vector4"/> to send over to the shaders</param>
		void SendUniform(string name, ref Vector4 vec);
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		void SendUniform(string name, Matrix matrix);
		
		/// <summary>Sends over the <see cref="B3.Matrix"/> 4x4</summary>
		/// <param name="name">The name of the uniform found within the shader</param>
		/// <param name="matrix">The <see cref="B3.Matrix"/> to send over to the shaders</param>
		void SendUniform(string name, ref Matrix matrix);
		
		#endregion // Methods
	}
}

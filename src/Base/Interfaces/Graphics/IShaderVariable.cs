
namespace B3.Graphics {
	/// <summary>An interface for when an object is able to set uniforms to the shader program</summary>
	public interface IShaderVariable {
		#region Methods
		
		/// <summary>Sets the uniform of the object</summary>
		/// <param name="program">The program used to set the uniform with</param>
		void SetUniform(IShaderProgram program);
		
		#endregion // Methods
	}
}

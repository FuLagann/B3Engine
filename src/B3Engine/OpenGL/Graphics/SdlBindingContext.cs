
using B3.Utilities;

using OpenTK;

namespace B3.Graphics {
	/// <summary>A class for using SDL to bind contexts for OpenTK</summary>
	public sealed class SdlBindingContext : IBindingsContext {
		#region Public Methods
		
		/// <summary>Gets the pointer address of a named OpenGL process</summary>
		/// <param name="procName">The name of the process</param>
		/// <returns>Returns a pointer to the process</returns>
		public System.IntPtr GetProcAddress(string procName) { return SDL.GL_GetProcAddress(procName); }
		
		#endregion // Public Methods
	}
}

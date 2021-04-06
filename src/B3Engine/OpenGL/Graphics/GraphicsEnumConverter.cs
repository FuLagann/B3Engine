
using OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	internal static class GraphicsEnumConverter {
		#region Public Static Methods
		
		/// <summary>An extension to convert the <see cref="B3.Graphics.BufferUsage"/> to the OpenTK BufferUsageHint</summary>
		/// <param name="type">The buffer usage enum to convert</param>
		/// <returns>Returns a OpenTK version of the buffer usage to use</returns>
		public static BufferUsageHint ToOpenGL(this BufferUsage type) {
			switch(type) {
				default:
				case BufferUsage.StaticDraw: return BufferUsageHint.StaticDraw;
				case BufferUsage.StaticRead: return BufferUsageHint.StaticRead;
				case BufferUsage.StaticCopy: return BufferUsageHint.StaticCopy;
				case BufferUsage.StreamCopy: return BufferUsageHint.StreamCopy;
				case BufferUsage.StreamDraw: return BufferUsageHint.StreamDraw;
				case BufferUsage.StreamRead: return BufferUsageHint.StreamRead;
				case BufferUsage.DynamicCopy: return BufferUsageHint.DynamicCopy;
				case BufferUsage.DynamicDraw: return BufferUsageHint.DynamicDraw;
				case BufferUsage.DynamicRead: return BufferUsageHint.DynamicRead;
			}
		}
		
		#endregion // Public Static Methods
	}
}

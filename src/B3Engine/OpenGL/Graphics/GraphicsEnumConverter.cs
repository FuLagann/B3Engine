
using OGL = OpenTK.Graphics.OpenGL;

namespace B3.Graphics {
	internal static class GraphicsEnumConverter {
		#region Public Static Methods
		
		/// <summary>An extension to convert the <see cref="B3.Graphics.BufferUsage"/> to the OpenTK BufferUsageHint</summary>
		/// <param name="type">The buffer usage enum to convert</param>
		/// <returns>Returns a OpenTK version of the buffer usage to use</returns>
		public static OGL.BufferUsageHint ToOpenGL(this BufferUsage type) {
			switch(type) {
				default:
				case BufferUsage.StaticDraw: return OGL.BufferUsageHint.StaticDraw;
				case BufferUsage.StaticRead: return OGL.BufferUsageHint.StaticRead;
				case BufferUsage.StaticCopy: return OGL.BufferUsageHint.StaticCopy;
				case BufferUsage.StreamCopy: return OGL.BufferUsageHint.StreamCopy;
				case BufferUsage.StreamDraw: return OGL.BufferUsageHint.StreamDraw;
				case BufferUsage.StreamRead: return OGL.BufferUsageHint.StreamRead;
				case BufferUsage.DynamicCopy: return OGL.BufferUsageHint.DynamicCopy;
				case BufferUsage.DynamicDraw: return OGL.BufferUsageHint.DynamicDraw;
				case BufferUsage.DynamicRead: return OGL.BufferUsageHint.DynamicRead;
			}
		}
		
		/// <summary>An extension to convert the <see cref="B3.Graphics.TextureType"/> to the OpenTK texture target</summary>
		/// <param name="type">The texture type enum to convert</param>
		/// <returns>Returns a OpenTK version of the texture target</returns>
		public static OGL.TextureTarget ToOpenGL(this TextureType type) {
			switch(type) {
				default:
				case TextureType.Texture2D: return OGL.TextureTarget.Texture2D;
				case TextureType.Texture1D: return OGL.TextureTarget.Texture1D;
				case TextureType.Texture1DArray: return OGL.TextureTarget.Texture1DArray;
				case TextureType.Texture2DArray: return OGL.TextureTarget.Texture2DArray;
				case TextureType.Texture2DMultiSample: return OGL.TextureTarget.Texture2DMultisample;
				case TextureType.Texture2DMultiSampleArray: return OGL.TextureTarget.Texture2DMultisampleArray;
				case TextureType.Texture3D: return OGL.TextureTarget.Texture3D;
				case TextureType.TextureCubeMap: return OGL.TextureTarget.TextureCubeMap;
				case TextureType.TextureCubeMapArray: return OGL.TextureTarget.TextureCubeMapArray;
				case TextureType.TextureRectangle: return OGL.TextureTarget.TextureRectangle;
			}
		}
		
		#endregion // Public Static Methods
	}
}

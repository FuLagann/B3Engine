
using System.IO;
using System.Runtime.InteropServices;

using Drawing = System.Drawing;
using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Loads a bitmap using the filepath</summary>
		/// <param name="filepath">The path to the image file</param>
		/// <returns>Returns a managed pointer to the bitmap</returns>
		public static IntPtr LoadBitmap(string filepath) {
			// Variables
			IntPtr ptr;
			
			using(Stream stream = FS.ReadStream(filepath)) {
				Drawing.Image image = Drawing.Image.FromStream(stream);
				
				ptr = LoadBitmap(image);
			}
			
			return ptr;
		}
		
		/// <summary>Loads a bitmap using the image</summary>
		/// <param name="image">The image to use</param>
		/// <returns>Returns a managed pointer to the bitmap</returns>
		public static IntPtr LoadBitmap(Drawing.Image image) {
			// Variables
			string guid = System.Guid.NewGuid().ToString();
			string filepath = $"{FS.BasePath}/{guid}.bmp";
			IntPtr ptr;
			
			image.Save(filepath, Drawing.Imaging.ImageFormat.Bmp);
			ptr = GetError(Surface.loadBmp(Surface.rwFromFile(filepath, "rb"), 1));
			FS.Delete(filepath);
			
			return ptr;
		}
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		private static class Surface {
			#region Field Variables
			// Variables
			internal static SDL_LoadBMP_RW loadBmp = FuncLoader.LoadFunc<SDL_LoadBMP_RW>(library, "SDL_LoadBMP_RW");
			internal static SDL_RWFromFile rwFromFile = FuncLoader.LoadFunc<SDL_RWFromFile>(library, "SDL_RWFromFile");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_RWFromFile(string file, string mode);
			
			#endregion // Field Variables
		}
		
		#endregion // Nested Types
	}
}


using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

using Bitmap = System.Drawing.Bitmap;
using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Creates a new window</summary>
		/// <param name="title">The name of the window</param>
		/// <param name="x">The x coordinate of the window</param>
		/// <param name="y">The y coordinate of the window</param>
		/// <param name="w">The width of the window</param>
		/// <param name="h">The height of the window</param>
		/// <param name="flags">Any window flags to use</param>
		/// <returns>Returns the managed pointer to the window</returns>
		public static IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags) {
			return GetError(Window.create(title, x, y, w, h, (int)flags));
		}
		
		/// <summary>Sets the title of window</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="title">The new title to set to the window</param>
		public static void SetWindowTitle(IntPtr window, string title) { Window.setTitle(window, title); }
		
		/// <summary>Sets the icon of the window to the image given it's file location</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="file">The file of the image to set the icon to</param>
		public static void SetWindowIcon(IntPtr window, string file) { Window.setIcon(window, LoadBmp(file)); }
		
		/// <summary>Loads the bitmap for the use of SDL specific use</summary>
		/// <param name="file">The location of the file to get the image from</param>
		/// <returns>Returns the managed pointer to the bitmap</returns>
		public static IntPtr LoadBmp(string file) {
			// Variables
			string guid = System.Guid.NewGuid().ToString();
			string filepath = $"{FS.BasePath}/{guid}.bmp";
			IntPtr ptr;
			
			using(Stream fstream = FS.ReadStream(file)) {
				// Variables
				Bitmap bmp = Bitmap.FromStream(fstream) as Bitmap;
				
				bmp.Save(filepath, ImageFormat.Bmp);
			}
			ptr = GetError(Window.loadBmp(Window.rwFromFile(filepath, "rb"), 1));
			FS.Delete(filepath);
			
			return ptr;
		}
		
		/// <summary>Sets the window's position</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="x">The new x position of the window</param>
		/// <param name="y">The new y position of the window</param>
		public static void SetWindowPosition(IntPtr window, int x, int y) { Window.setPosition(window, x, y); }
		
		/// <summary>Sets the window's size</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="w">The new width of the window</param>
		/// <param name="h">The new height of the window</param>
		public static void SetWindowSize(IntPtr window, int w, int h) { Window.setSize(window, w, h); }
		
		/// <summary>Destroys the window</summary>
		/// <param name="window">The managed pointer to the window to destroy</param>
		public static void DestroyWindow(IntPtr window) { Window.destroy(window); }
		
		/// <summary>Sets if the window should be resizable</summary>
		/// <param name="window">The window to set if it should be resizable</param>
		/// <param name="resizable">Set to true to make the window resizable</param>
		public static void SetWindowResizable(IntPtr window, bool resizable) { Window.setResizable(window, resizable); }
		
		/// <summary>Gets a managed pointer to the OpenGL</summary>
		/// <param name="proc">The name of the OpenGL function</param>
		/// <returns>Returns the managed pointer to the OpenGL function</returns>
		public static IntPtr GL_GetProcAddress(string proc) { return Window.getProcAddress(proc); }
		
		/// <summary>Creates an OpenGL context that is related to the window</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <returns>Returns the managed pointer to the OpenGL context</returns>
		public static IntPtr GL_CreateContext(IntPtr window) { return GetError(Window.createContext(window)); }
		
		/// <summary>Makes the OpenGL context current in relation to the window</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="context">The managed pointer to the OpenGL context</param>
		/// <returns>Returns 0 if it's successful and -1 if there are errors</returns>
		public static int GL_MakeCurrent(IntPtr window, IntPtr context) { return GetError(Window.makeCurrent(window, context)); }
		
		/// <summary>Deletes the OpenGL context</summary>
		/// <param name="context">The managed pointer to the context to delete</param>
		public static void GL_DeleteContext(IntPtr context) { Window.deleteContext(context); }
		
		/// <summary>Swaps the window's buffers</summary>
		/// <param name="window">The window to swap</param>
		public static void GL_SwapWindow(IntPtr window) { Window.swap(window); }
		
		#endregion //Public Static Methods
		
		#region Nested Types
		
		private class Window {
			#region Field Variables
			// Variables
			internal static SDL_CreateWindow create = FuncLoader.LoadFunc<SDL_CreateWindow>(library, "SDL_CreateWindow");
			internal static SDL_SetWindowTitle setTitle = FuncLoader.LoadFunc<SDL_SetWindowTitle>(library, "SDL_SetWindowTitle");
			internal static SDL_SetWindowIcon setIcon = FuncLoader.LoadFunc<SDL_SetWindowIcon>(library, "SDL_SetWindowIcon");
			internal static SDL_LoadBMP_RW loadBmp = FuncLoader.LoadFunc<SDL_LoadBMP_RW>(library, "SDL_LoadBMP_RW");
			internal static SDL_RWFromFile rwFromFile = FuncLoader.LoadFunc<SDL_RWFromFile>(library, "SDL_RWFromFile");
			internal static SDL_GL_GetProcAddress getProcAddress = FuncLoader.LoadFunc<SDL_GL_GetProcAddress>(library, "SDL_GL_GetProcAddress");
			internal static SDL_GL_CreateContext createContext = FuncLoader.LoadFunc<SDL_GL_CreateContext>(library, "SDL_GL_CreateContext");
			internal static SDL_GL_MakeCurrent makeCurrent = FuncLoader.LoadFunc<SDL_GL_MakeCurrent>(library, "SDL_GL_MakeCurrent");
			internal static SDL_SetWindowPosition setPosition = FuncLoader.LoadFunc<SDL_SetWindowPosition>(library, "SDL_SetWindowPosition");
			internal static SDL_SetWindowSize setSize = FuncLoader.LoadFunc<SDL_SetWindowSize>(library, "SDL_SetWindowSize");
			internal static SDL_DestroyWindow destroy = FuncLoader.LoadFunc<SDL_DestroyWindow>(library, "SDL_DestroyWindow");
			internal static SDL_DestroyWindow deleteContext = FuncLoader.LoadFunc<SDL_DestroyWindow>(library, "SDL_GL_DeleteContext");
			internal static SDL_DestroyWindow swap = FuncLoader.LoadFunc<SDL_DestroyWindow>(library, "SDL_GL_SwapWindow");
			internal static SDL_SetWindowResizable setResizable = FuncLoader.LoadFunc<SDL_SetWindowResizable>(library, "SDL_SetWindowResizable");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, int flags);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetWindowTitle(IntPtr window, string title);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetWindowIcon(IntPtr window, IntPtr icon);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_LoadBMP_RW(IntPtr bmp, int freesrc);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_RWFromFile(string file, string mode);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_GL_GetProcAddress(string proc);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_GL_CreateContext(IntPtr window);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_GL_MakeCurrent(IntPtr window, IntPtr context);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetWindowPosition(IntPtr window, int x, int y);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetWindowSize(IntPtr window, int w, int h);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_DestroyWindow(IntPtr window);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetWindowResizable(IntPtr window, bool resizable);
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for a display event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct DisplayEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the display</summary>
			public uint displayId;
			/// <summary>The id of the display event</summary>
			public DisplayEventId eventId;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			/// <summary>No description</summary>
			public byte padding3;
			/// <summary>The event dependent data</summary>
			public int data;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for a window event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WindowEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the window</summary>
			public uint windowId;
			/// <summary>The id of the window event</summary>
			public WindowEventId eventId;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			/// <summary>No description</summary>
			public byte padding3;
			/// <summary>The first event dependent data</summary>
			public int data1;
			/// <summary>The second event dependent data</summary>
			public int data2;
			
			#endregion // Field Variables
		}
		
		#endregion // Nested Types
	}
}

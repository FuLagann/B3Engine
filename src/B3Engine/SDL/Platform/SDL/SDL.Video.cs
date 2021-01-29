
using System.Runtime.InteropServices;

using Drawing = System.Drawing;
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
		public static void SetWindowIcon(IntPtr window, string file) { Window.setIcon(window, LoadBitmap(file)); }
		
		/// <summary>Sets the window's icon</summary>
		/// <param name="window">The managed pointer to the window</param>
		/// <param name="image">The image to set the icon to</param>
		public static void SetWindowIcon(IntPtr window, Drawing.Image image) { Window.setIcon(window, LoadBitmap(image)); }
		
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
		
		private static class Window {
			#region Field Variables
			// Variables
			internal static SDL_CreateWindow create = FuncLoader.LoadFunc<SDL_CreateWindow>(library, "SDL_CreateWindow");
			internal static SDL_SetWindowTitle setTitle = FuncLoader.LoadFunc<SDL_SetWindowTitle>(library, "SDL_SetWindowTitle");
			internal static SDL_SetWindowIcon setIcon = FuncLoader.LoadFunc<SDL_SetWindowIcon>(library, "SDL_SetWindowIcon");
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
		
		/// <summary>The id of the window event</summary>
		public enum WindowEventId {
			/// <summary>No event</summary>
			None,
			/// <summary>When the window is being shown</summary>
			Shown,
			/// <summary>When the window is being hidden</summary>
			Hidden,
			/// <summary>When the window is being exposed and should be redrawn</summary>
			Exposed,
			/// <summary>When the window has moved, cooridnates found in <see cref="B3.Utilities.SDL.WindowEvent.data1"/> and <see cref="B3.Utilities.SDL.WindowEvent.data2"/></summary>
			Moved,
			/// <summary>When the window has resized, the size is found in <see cref="B3.Utilities.SDL.WindowEvent.data1"/> and <see cref="B3.Utilities.SDL.WindowEvent.data2"/></summary>
			Resized,
			/// <summary>When the window's size has changed</summary>
			SizeChanged,
			/// <summary>When the window has been minimized</summary>
			Minimized,
			/// <summary>When the window has been maximized</summary>
			Maximized,
			/// <summary>When the window has been restored to normal size and position</summary>
			Restored,
			/// <summary>When the window has gained mouse focus</summary>
			Enter,
			/// <summary>When the window has lost mouse focus</summary>
			Leave,
			/// <summary>When the window has gained keyboard focus</summary>
			FocusGained,
			/// <summary>When the window has lost keyboard focus</summary>
			FocusLost,
			/// <summary>When the window is requesting to be closed</summary>
			Close,
			/// <summary>When the window is being offered focus</summary>
			TakeFocus,
			/// <summary>When the window had a hit test</summary>
			HitTest
		}
		
		/// <summary>THe event id for displays</summary>
		public enum DisplayEventId {
			/// <summary>No event</summary>
			None,
			/// <summary>When the display orientation is changed, orientation data is found in <see cref="B3.Utilities.SDL.DisplayEvent.data"/></summary>
			Orientation,
			/// <summary>When a display is added</summary>
			Connected,
			/// <summary>When a display is removed</summary>
			Disconnected
		}
		
		/// <summary>An enumeration for flags made for window specific properties</summary>
		[System.Flags]
		public enum WindowFlags {
			/// <summary>Has no flags to use</summary>
			None = 0,
			/// <summary>Fullscreens the window</summary>
			Fullscreen = 1,
			/// <summary>Makes the window usable with OpenGL contexts</summary>
			OpenGL = 2,
			/// <summary>Makes the window visible</summary>
			Show = 4,
			/// <summary>Makes the window not visible</summary>
			Hidden = 8,
			/// <summary>Gives no decoration to the window</summary>
			Borderless = 16,
			/// <summary>Allows the window to be resized</summary>
			Resizable = 32,
			/// <summary>Makes the window minimized</summary>
			Minimized = 64,
			/// <summary>Makes the window maximized</summary>
			Maximized = 128,
			/// <summary>The window has grabbed input focus</summary>
			InputGrabbed = 256,
			/// <summary>The window has input focus</summary>
			InputFocus = 512,
			/// <summary>The window has mouse focus</summary>
			MouseFocus = 1024,
			/// <summary>For when the window is not created by SDL</summary>
			Foreign = 2048,
			/// <summary>Fullscreen the window</summary>
			FullscreenDesktop = Fullscreen | 4096,
			/// <summary>Creates the window with high-dpi mode on if supported</summary>
			AllowHighDpi = 8192,
			/// <summary>The window has captured the mouse</summary>
			MouseCapture = 16384,
			/// <summary>Makes the window always be above other</summary>
			AlwaysOnTop = 32768,
			/// <summary>Makes the window not be added to the taskbar</summary>
			SkipTaskbar = 65536,
			/// <summary>Treats the window as a utility window</summary>
			Utility = 131072,
			/// <summary>Treats the window as a tooltip</summary>
			Tooltip = 262144,
			/// <summary>Treats the window as a popup menu</summary>
			PopupMenu = 524288,
			/// <summary>Makes the window usable with vulkan</summary>
			Vulkan = 268435456,
			/// <summary>Makes the window usable with metal</summary>
			Metal = 536870912
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


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
		
		/// <summary>Gets the id of the window</summary>
		/// <param name="window">The window to query the id of</param>
		/// <returns>Returns the id of the window, returning 0 means there's an error</returns>
		public static uint GetWindowId(IntPtr window) { return Window.getId(window); }
		
		/// <summary>Shows the given window</summary>
		/// <param name="window">The window to show</param>
		public static void ShowWindow(IntPtr window) { Window.show(window); }
		
		/// <summary>Hides the given window</summary>
		/// <param name="window">The window to hide</param>
		public static void HideWindow(IntPtr window) { Window.hide(window); }
		
		/// <summary>Sets the window to be a modal for the given parent window</summary>
		/// <param name="window">The window to make into a modal</param>
		/// <param name="parent">The window to parent to</param>
		/// <returns>Returns true if the method was called successfully</returns>
		public static bool SetWindowModalFor(IntPtr window, IntPtr parent) { return GetError(Window.setModalFor(window, parent)) == 0; }
		
		/// <summary>Sets the window to fullscreen</summary>
		/// <param name="window">The window to set to fullscreen</param>
		/// <param name="mode">
		/// Sets the fullscreen mode to the following:
		/// * <see cref="B3.WindowMode.Windowed"/> will return the window to normal.
		/// * <see cref="B3.WindowMode.Fullscreen"/> will make the window into a "true" fullscreen.
		/// * <see cref="B3.WindowMode.BorderlessFullscreen"/> will make the window into a "false" fullscreen that will be a borderless full sized window.
		/// </param>
		/// <returns>Returns true if the method was called sucessfully</returns>
		public static bool SetWindowFullscreen(IntPtr window, WindowMode mode) {
			// Variables
			WindowFlags flags = WindowFlags.None;
			
			if(mode == WindowMode.Fullscreen) { flags = WindowFlags.Fullscreen; }
			if(mode == WindowMode.BorderlessFullscreen) { flags = WindowFlags.FullscreenDesktop; }
			
			return (GetError(Window.setFullscreen(window, flags)) == 0);
		}
		
		/// <summary>Sets the window's brightness</summary>
		/// <param name="window">The window to change the brightness to</param>
		/// <param name="brightness">The gamma brightness. Where 0.0f is completely dark and 1.0f is normal brightness</param>
		/// <returns>Returns true if the method was called successfully</returns>
		public static bool SetWindowBrightness(IntPtr window, float brightness) { return (GetError(Window.setBrightness(window, brightness)) == 0); }
		
		/// <summary>Sets if the window should be bordered or unbordered</summary>
		/// <param name="window">The window to set if it will have borders or not</param>
		/// <param name="bordered">Set to true to make the window bordered</param>
		public static void SetWindowBordered(IntPtr window, bool bordered) { Window.setBordered(window, bordered); }
		
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
		
		/// <summary>Sets the OpenGL attribute</summary>
		/// <param name="attr">The attribute to set</param>
		/// <param name="value">The value to set the attribute to</param>
		public static void GL_SetAttribute(GLAttribute attr, int value) { GetError(Window.setAttribute(attr, value)); }
		
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
			internal static SDL_GL_SetAttribute setAttribute = FuncLoader.LoadFunc<SDL_GL_SetAttribute>(library, "SDL_GL_SetAttribute");
			internal static SDL_GetWindowID getId = FuncLoader.LoadFunc<SDL_GetWindowID>(library, "SDL_GetWindowID");
			internal static SDL_DestroyWindow show = FuncLoader.LoadFunc<SDL_DestroyWindow>(library, "SDL_ShowWindow");
			internal static SDL_DestroyWindow hide = FuncLoader.LoadFunc<SDL_DestroyWindow>(library, "SDL_HideWindow");
			internal static SDL_GL_MakeCurrent setModalFor = FuncLoader.LoadFunc<SDL_GL_MakeCurrent>(library, "SDL_SetWindowModalFor");
			internal static SDL_SetWindowFullscreen setFullscreen = FuncLoader.LoadFunc<SDL_SetWindowFullscreen>(library, "SDL_SetWindowFullscreen");
			internal static SDL_SetWindowResizable setBordered = FuncLoader.LoadFunc<SDL_SetWindowResizable>(library, "SDL_SetWindowBordered");
			internal static SDL_SetWindowBrightness setBrightness = FuncLoader.LoadFunc<SDL_SetWindowBrightness>(library, "SDL_SetWindowBrightness");
			
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
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_GL_SetAttribute(GLAttribute attribute, int value);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint SDL_GetWindowID(IntPtr window);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_SetWindowFullscreen(IntPtr window, WindowFlags flags);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_SetWindowBrightness(IntPtr window, float brightness);
			
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
		public enum WindowFlags : uint {
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
		
		/// <summary>An enumeration of all the OpenGL attributes used with SDL to set an attribute</summary>
		public enum GLAttribute {
			/// <summary>The minimum number of bits for the red channel of the color buffer; defaults to 3</summary>
			RedSize,
			/// <summary>The minimum number of bits for the green channel of the color buffer; defaults to 3</summary>
			GreenSize,
			/// <summary>The minimum number of bits for the blue channel of the color buffer; defaults to 2</summary>
			BlueSize,
			/// <summary>The minimum number of bits for the alpha channel of the color buffer; defaults to 0</summary>
			AlphaSize,
			/// <summary>The minimum number of bits for frame buffer size; defaults to 0</summary>
			BufferSize,
			/// <summary>Whether the output is single or double buffered; defaults to double buffering on</summary>
			DoubleBuffer,
			/// <summary>The minimum number of bits in the depth buffer; defaults to 16</summary>
			DepthSize,
			/// <summary>The minimum number of bits in the stencil buffer; defaults to 0</summary>
			StencilSize,
			/// <summary>The minimum number of bits for the red channel of the accumulation buffer; defaults to 0</summary>
			AccumRedSize,
			/// <summary>The minimum number of bits for the green channel of the accumulation buffer; defaults to 0</summary>
			AccumGreenSize,
			/// <summary>The minimum number of bits for the blue channel of the accumulation buffer; defaults to 0</summary>
			AccumBlueSize,
			/// <summary>The minimum number of bits for the alpha channel of the accumulation buffer; defaults to 0</summary>
			AccumAlphaSize,
			/// <summary>Whether the output is stereo 3D; defaults to off</summary>
			Stereo,
			/// <summary>The number of buffers used for multisample anti-aliasing; defaults to 0</summary>
			MultiSampleBuffers,
			/// <summary>The number of samples used around the current pixel used for multisample anti-aliasing; defaults to 0</summary>
			MultiSampleSamples,
			/// <summary>Set to 1 to require hardware acceleration, set to 0 to force software rendering</summary>
			AcceleratedVisual,
			/// <summary>Not used (deprecated)</summary>
			RetainedBacking,
			/// <summary>OpenGL context major version</summary>
			ContextMajorVersion,
			/// <summary>OpenGL context minor version</summary>
			ContextMinorVersion,
			/// <summary>Not used (deprecated)</summary>
			ContextEGL,
			/// <summary>Some combination of 0 or more of elements of the <see cref="B3.Utilities.SDL.GLFlags"/></summary>
			ContextFlags,
			/// <summary>Type of GL context (Core, Compatibility, ES). Uses the <see cref="B3.Utilities.SDL.GLProfile"/> enumeration</summary>
			ContextProfileMask,
			/// <summary>OpenGL context sharing; defaults to 0</summary>
			ShareWithCurrentContext,
			/// <summary>Requests sRGB capable visual; defaults to 0 (>= SDL 2.0.1)</summary>
			FrameBufferSrgbCapable,
			/// <summary>Sets the context's release behavior; defaults to 1 (>= SDL 2.0.4)</summary>
			ContextReleaseBehavior,
			/// <summary>Resets the context's notification</summary>
			ContextResetNotification,
			/// <summary>Sets the context to hold no error</summary>
			ContextNoError
		}
		
		/// <summary>The flags of OpenGL context configurations</summary>
		[System.Flags]
		public enum GLFlags {
			/// <summary>Intended to put the GL into debug mode</summary>
			Debug = 1,
			/// <summary>Intended to put the GL into a forward compatible mode</summary>
			ForwardCompatible = 2,
		}
		
		/// <summary>The profile of the OpenGL context to use</summary>
		[System.Flags]
		public enum GLProfile {
			/// <summary>The OpenGL core profile. Deprecated functions are disabled</summary>
			Core = 1,
			/// <summary>The OpenGL compatibility profile. Deprecated functions are allowed</summary>
			Compatibility = 2,
			/// <summary>The OpenGL ES profile. Only a subset of the base OpenGL functionality is available</summary>
			ES = 4
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

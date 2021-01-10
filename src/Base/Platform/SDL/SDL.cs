
using System.Runtime.InteropServices;

namespace B3.Utilities {
	/// <summary>A static class for all the SDL2 functionalities</summary>
	public static class SDL {
		#region Field Variables
		// Variables
		private static System.IntPtr library = SDL.GetNativeLibrary();
		private static SDL_GetError sdl_GetError = FuncLoader.LoadFunc<SDL_GetError>(library, "SDL_GetError");
		private static SDL_Init sdl_Init = FuncLoader.LoadFunc<SDL_Init>(library, "SDL_Init");
		private static SDL_Init sdl_InitSubSystem = FuncLoader.LoadFunc<SDL_Init>(library, "SDL_InitSubSystem");
		private static System.Action sdl_Quit = FuncLoader.LoadFunc<System.Action>(library, "SDL_Quit");
		private static SDL_QuitSubSystem sdl_QuitSubSystem = FuncLoader.LoadFunc<SDL_QuitSubSystem>(library, "SDL_QuitSubSystem");
		private static SDL_CreateWindow sdl_CreateWindow = FuncLoader.LoadFunc<SDL_CreateWindow>(library, "SDL_CreateWindow");
		private static SDL_GetVersion sdl_GetVersion = FuncLoader.LoadFunc<SDL_GetVersion>(library, "SDL_GetVersion");
		private static SDL_PollEvent sdl_PollEvent = FuncLoader.LoadFunc<SDL_PollEvent>(library, "SDL_PollEvent");
		private static SDL_GetHint sdl_GetHint = FuncLoader.LoadFunc<SDL_GetHint>(library, "SDL_GetHint");
		private static SDL_SetHint sdl_SetHint = FuncLoader.LoadFunc<SDL_SetHint>(library, "SDL_SetHint");
		
		// Delegates
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void Action();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate System.IntPtr SDL_GetError();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int SDL_Init(int flags);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void SDL_QuitSubSystem(int flags);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate System.IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, int flags);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void SDL_GetVersion(out Version version);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int SDL_PollEvent([Out] out Event e);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int SDL_SetHint(string name, string value);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate System.IntPtr SDL_GetHint(string name);
		
		#endregion // Field Variables
		
		#region Public Static Methods
		
		#region GetError Methods
		
		/// <summary>Gets the SDL2 error</summary>
		/// <returns>Returns the SDL2 error string</returns>
		public static string GetError() { return FuncLoader.IntPtrToString(sdl_GetError()); }
		
		/// <summary>Gets the SDL2 error that returns an int</summary>
		/// <param name="value">The int to evaluate, negative numbers will log the error</param>
		/// <returns>Returns the int that got passed through</returns>
		public static int GetError(int value) {
			if(value < 0) {
				Logger.Error(GetError());
			}
			
			return value;
		}
		
		/// <summary>Gets the SDL2 error that returns a managed pointer</summary>
		/// <param name="handle">The managed pointer to evaluate, pointer of 0 will log the error</param>
		/// <returns>Returns the managed pointer that got passed through</returns>
		public static System.IntPtr GetError(System.IntPtr handle) {
			if(handle == System.IntPtr.Zero) {
				Logger.Error(GetError());
			}
			
			return handle;
		}
		
		#endregion // GetError Methods
		
		#region SDL Window Methods
		
		/// <summary>Creates a new window</summary>
		/// <param name="title">The name of the window</param>
		/// <param name="x">The x coordinate of the window</param>
		/// <param name="y">The y coordinate of the window</param>
		/// <param name="w">The width of the window</param>
		/// <param name="h">The height of the window</param>
		/// <param name="flags">Any window flags to use</param>
		/// <returns>Returns the managed pointer to the window</returns>
		public static System.IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags) {
			return GetError(sdl_CreateWindow(title, x, y, w, h, (int)flags));
		}
		
		#endregion // SDL Window Methods
		
		#region SDL Event Methods
		
		/// <summary>Polls any events that may arise</summary>
		/// <returns>Returns the event that got polled</returns>
		public static Event PollEvent() {
			// Variables
			Event e;
			
			GetError(sdl_PollEvent(out e));
			
			return e;
		}
		
		#endregion // SDL Event Methods
		
		#region SDL Misc Methods
		
		/// <summary>Initiates the SDL2 framework</summary>
		/// <param name="flags">The initialization flags to initialize with</param>
		/// <returns>Returns the error code</returns>
		public static int Init(InitFlags flags) { return GetError(sdl_Init((int)flags)); }
		
		/// <summary>Initiates a subsystem</summary>
		/// <param name="flags">The initialization flags to initiate the subsystem</param>
		/// <returns>Returns the error code</returns>
		public static int InitSubSystem(InitFlags flags) { return GetError(sdl_InitSubSystem((int)flags)); }
		
		/// <summary>Quits from the SDL2 framework</summary>
		public static void Quit() { sdl_Quit(); }
		
		/// <summary>Quits from a specific subsystem</summary>
		/// <param name="flags">The initialization flags to quit from</param>
		public static void QuitSubSystem(InitFlags flags) { sdl_QuitSubSystem((int)flags); }
		
		/// <summary>Gets the version of the SDL library</summary>
		/// <returns>Returns the version of the SDL library</returns>
		public static Version GetVersion() {
			// Variables
			Version version;
			
			sdl_GetVersion(out version);
			
			return version;
		}
		
		public static string GetHint(string name) {
			return FuncLoader.IntPtrToString(GetError(sdl_GetHint(name)));
		}
		
		public static bool SetHint(string name, string value) {
			return (GetError(sdl_SetHint(name, value)) != 0);
		}
		
		#endregion // SDL Misc Methods
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Loads in the SDL2 unmanaged library</summary>
		/// <returns>Returns the managed pointer to the SDL2 library</returns>
		private static System.IntPtr GetNativeLibrary() {
			if(Platform.OS == OS.Windows) {
				try {
					return FuncLoader.LoadLibraryExt("SDL2.dll");
				}
				catch {
					if(Platform.Rid.Contains("x86")) {
						return FuncLoader.LoadLibraryExt("SDL2-x86.dll");
					}
					else {
						return FuncLoader.LoadLibraryExt("SDL2-x64.dll");
					}
				}
			}
			else if(Platform.OS == OS.Linux) {
				return FuncLoader.LoadLibraryExt("libSDL2-2.0.so.0");
			}
			else if(Platform.OS == OS.MacOSX) {
				return FuncLoader.LoadLibraryExt("libSDL2-2.0.0.dylib");
			}
			else {
				return FuncLoader.LoadLibraryExt("sdl2");
			}
		}
		
		#endregion // Private Static Methods
		
		#region Nested Types
		
		#region Enumerations
		
		/// <summary>An enumeration for all the initialization flags for SDL2</summary>
		[System.Flags]
		public enum InitFlags : uint {
			/// <summary>Initialize the SDL2 Timer system</summary>
			Timer = 1,
			/// <summary>Initialize the SDL2 Audio system</summary>
			Audio = 16,
			/// <summary>Initialize the SDL2 Video system</summary>
			Video = 32,
			/// <summary>Initialize the SDL2 Joystick system</summary>
			Joystick = 512,
			/// <summary>Initialize the SDL2 Haptic system</summary>
			Haptic = 4096,
			/// <summary>Initialize the SDL2 Game Controller system</summary>
			GameController = 8192,
			/// <summary>Initialize the SDL2 Events system</summary>
			Events = 16384,
			/// <summary>Initialize the SDL2 Sensor system</summary>
			Sensor = 32768,
			/// <summary>Initialize the SDL2 No Parachute system</summary>
			NoParachute = 1048576,
			/// <summary>Initialize all the SDL2 systems</summary>
			Everything = (
				Timer | Audio | Video | Joystick | Haptic |
				GameController | Events | Sensor | NoParachute
			)
		}
		
		/// <summary>The type of event that the SDL event system has</summary>
		public enum EventType {
			/// <summary>Used internally</summary>
			First = 0,
			/// <summary>When the user is quiting from the application</summary>
			Quit = 256,
			/// <summary>(Android/iOS/WinRT specific) When the OS is terminating the application</summary>
			AppTerminating,
			/// <summary>(Android/iOS/WinRT specific) When the OS is low on memory</summary>
			AppLowMemory,
			/// <summary>(Android/iOS/WinRT specific) When the application is entering the background</summary>
			AppWillEnterBackground,
			/// <summary>(Android/iOS/WinRT specific) When the application entered the background</summary>
			AppDidEnterBackground,
			/// <summary>(Android/iOS/WinRT specific) When the application is entering the foreground</summary>
			AppWillEnterForeground,
			/// <summary>(Android/iOS/WinRT specific) When the application entered the foreground</summary>
			AppDidEnterForeground,
			/// <summary>When the user's locale preferences have changed</summary>
			LocaleChanged,
			/// <summary>When the display state has changed</summary>
			Display = 336,
			/// <summary>When the window state has changed</summary>
			Window = 512,
			/// <summary>When a system specific event is triggered</summary>
			Sysw,
			/// <summary>When a key is down on a keyboard</summary>
			KeyDown = 768,
			/// <summary>When a key is up on a keyboard</summary>
			KeyUp,
			/// <summary>When the user is editing text (composition)</summary>
			TextEditing,
			/// <summary>When the keyboard has text input</summary>
			TextInput,
			/// <summary>When the keymap has changed (implemented from >= SDL 2.0.4)</summary>
			KeyMapChanged,
			/// <summary>When the mouse has moved</summary>
			MouseMotion = 1024,
			/// <summary>When the mouse button is pressed</summary>
			MouseButtonDown,
			/// <summary>When the mouse button is released</summary>
			MouseButtonUp,
			/// <summary>When the mouse wheel is in motion</summary>
			MouseWheel,
			/// <summary>When a joystick axis is in motion</summary>
			JoyAxisMotion = 1536,
			/// <summary>When a joystick trackball is in motion</summary>
			JoyBallMotion,
			/// <summary>When a joystick hat position has changed</summary>
			JoyHatMotion,
			/// <summary>When a joystick button is pressed</summary>
			JoyButtonDown,
			/// <summary>When a joystick button is released</summary>
			JoyButtonUp,
			/// <summary>When a joystick device has been added</summary>
			JoyDeviceAdded,
			/// <summary>When a joystick device has been removed</summary>
			JoyDeviceRemoved,
			/// <summary>When a controller's axis is in motion</summary>
			ControllerAxisMotion = 1616,
			/// <summary>When a controller button is pressed</summary>
			ControllerButtonDown,
			/// <summary>When a controller button is released</summary>
			ControllerButtonUp,
			/// <summary>When a controller device is added</summary>
			ControllerDeviceAdded,
			/// <summary>When a controller device is removed</summary>
			ControllerDeviceRemoved,
			/// <summary>When a controller device is remapped</summary>
			ControllerDeviceRemapped,
			/// <summary>When a controller touchpad is pressed</summary>
			ControllerTouchpadDown,
			/// <summary>When a controller touchpad is in motion</summary>
			ControllerTouchpadMotion,
			/// <summary>When a controller touchpad is released</summary>
			ControllerTouchpadUp,
			/// <summary>When a controller touchpad is pressed</summary>
			ControllerSensorUpdate,
			/// <summary>When a user has touched the input device</summary>
			FingerDown = 1792,
			/// <summary>When a user has stopped touching the input device</summary>
			FingerUp,
			/// <summary>When a user is dragging finger on input device</summary>
			FingerMotion,
			/// <summary>No description</summary>
			DollarGesture = 2048,
			/// <summary>No description</summary>
			DollarRecord,
			/// <summary>No description</summary>
			MultiGesture,
			/// <summary>When the clipboard has been changed</summary>
			ClipboardUpdate = 2304,
			/// <summary>When the system requests a file open</summary>
			DropFile = 4096,
			/// <summary>When the user drags and drops text</summary>
			DropText,
			/// <summary>When a new set of drops is beginning (implemented in >= SDL 2.0.5)</summary>
			DropBegin,
			/// <summary>When a new set of drops is complete (implemented in >= SDL 2.0.5)</summary>
			DropComplete,
			/// <summary>When a new audio device is added (implemented in >= SDL 2.0.4)</summary>
			AudioDeviceAdded = 4352,
			/// <summary>When a new audio device is removed (implemented in >= SDL 2.0.4)</summary>
			AudioDeviceRemoved,
			/// <summary>When a sensor is updated</summary>
			SensorUpdate = 4608,
			/// <summary>When the render targets have been reset and their contents needs to be updated (implemented in >= SDL 2.0.2)</summary>
			RenderTargetsReset = 8192,
			/// <summary>When the device has been reset and all textures need to be recreated (implemented in >= SDL 2.0.4)</summary>
			RenderDeviceReset,
			/// <summary>A user-defined event</summary>
			User = 32768,
			/// <summary>Used internally</summary>
			Last = 65535
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
		
		/// <summary>An enumeration of key modifiers used for keyboard events</summary>
		[System.Flags]
		public enum KeyModifiers : ushort {
			/// <summary>No key modifiers</summary>
			None = 0,
			/// <summary>The Left Shift key</summary>
			LShift = 1,
			/// <summary>The Right Shift key</summary>
			RShift = 2,
			/// <summary>The Left Control key</summary>
			LCtrl = 64,
			/// <summary>The Right Control key</summary>
			RCtrl = 128,
			/// <summary>The Left Alt key</summary>
			LAlt = 256,
			/// <summary>The Right Alt key</summary>
			RAlt = 512,
			/// <summary>The Left Windows key</summary>
			LWindows = 1024,
			/// <summary>The Right Windows key</summary>
			RWindows = 2048,
			/// <summary>The Num key</summary>
			Num = 4096,
			/// <summary>The Capslock key</summary>
			Caps = 8192,
			/// <summary>The Insert key</summary>
			Insert = 16384,
			/// <summary>The reserved key</summary>
			Reserved = 32768,
			/// <summary>The Control key (either left or right)</summary>
			Ctrl = LCtrl | RCtrl,
			/// <summary>The Shift key (either left or right)</summary>
			Shift = LShift | RShift,
			/// <summary>The Alt key (either left or right)</summary>
			Alt = LAlt | RAlt,
			/// <summary>The Windows key (either left or right)</summary>
			Windows = LWindows | RWindows
		}
		
		/// <summary>An enumeration for flags made for window specific properties</summary>
		[System.Flags]
		public enum WindowFlags {
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
		
		#endregion // Enumerations
		
		#region Structures
		
		/// <summary>A structure for the version of the SDL framework</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct Version {
			#region Field Variables
			// Variables
			/// <summary>The major version</summary>
			public byte major;
			/// <summary>The minor version</summary>
			public byte minor;
			/// <summary>The patch version</summary>
			public byte patch;

			#endregion // Field Variables

			#region Public Methods
			
			/// <summary>Gets the version in string form</summary>
			/// <returns>Returns the version in string form</returns>
			public override string ToString() { return $"{major}.{minor}.{patch}"; }

			
			#endregion // Public Methods
		}
		
		/// <summary>The structure for the key symbol</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct KeySymbol {
			#region Field Variables
			// Variables
			/// <summary>The scancode of the key on the keyboard</summary>
			public int scancode;
			/// <summary>The keycode of the key on the keyboard</summary>
			public int keycode;
			/// <summary>Any modifiers applied by the users</summary>
			public KeyModifiers modifiers;
			/// <summary>No description</summary>
			public uint unused;
			
			#endregion // Field Variables
		}
		
		#region Events
		
		/// <summary>The structure for a common event that is shared between every event</summary>
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		public struct Event {
			#region Field Variables
			// Variables
			/// <summary>The type of event</summary>
			[FieldOffset(0)]
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			[FieldOffset(0)]
			public uint timestamp;
			/// <summary>The event for the window</summary>
			[FieldOffset(0)]
			public WindowEvent window;
			/// <summary>The event for the display</summary>
			[FieldOffset(0)]
			public DisplayEvent display;
			/// <summary>The event for keyboard inputs</summary>
			[FieldOffset(0)]
			public KeyboardEvent keyboard;
			
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
		
		/// <summary>The structure for the keyboard event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct KeyboardEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the window the keyboard has focus on</summary>
			public uint windowId;
			/// <summary>The state of the keyboard, pressed or released</summary>
			public byte state;
			/// <summary>Non-zero if the key is being repeated</summary>
			public byte repeat;
			/// <summary>No description</summary>
			public byte padding2;
			/// <summary>No description</summary>
			public byte padding3;
			/// <summary>The key that was pressed or released</summary>
			public KeySymbol keySymbol;
			
			#endregion // Field Variables
		}
		
		#endregion // Events
		
		#endregion // Structures
		
		#endregion // Nested Types
	}
}

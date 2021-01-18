
using System.Runtime.InteropServices;

namespace B3.Utilities {
	/// <summary>A static class for all the SDL2 functionalities</summary>
	public static class SDL {
		#region Field Variables
		// Variables
		private static bool isInitiated = false;
		private static System.IntPtr library = SDL.GetNativeLibrary();
		private static SDL_CreateWindow sdl_CreateWindow = FuncLoader.LoadFunc<SDL_CreateWindow>(library, "SDL_CreateWindow");
		private static SDL_GetVersion getVersion = FuncLoader.LoadFunc<SDL_GetVersion>(library, "SDL_GetVersion");
		
		// Delegates
		/// <summary>A delegate for event handling</summary>
		/// <param name="e">The event that holds what the user is doing</param>
		public delegate void EventHandler(Event e);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void Action();
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate System.IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, int flags);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void SDL_GetVersion(out Version version);
		
		#endregion // Field Variables
		
		#region Public Static Events
		
		/// <summary>An event for when SDL events are triggered</summary>
		public static event EventHandler OnEvent;
		
		#endregion // Public Static Events
		
		#region Public Static Methods
		
		#region GetError Methods
		
		/// <summary>Gets the SDL2 error</summary>
		/// <returns>Returns the SDL2 error string</returns>
		public static string GetError() { return Convert.IntPtrToString(Misc.getError()); }
		
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
		
		#region SDL Keyboard Methods
		
		/// <summary>Starts the text input</summary>
		public static void StartTextInput() { Keyboard.startTextInput(); }
		
		/// <summary>Stops the text input</summary>
		public static void StopTextInput() { Keyboard.stopTextInput(); }
		
		/// <summary>Finds if the text input is currently active</summary>
		/// <returns>Returns true if the text input is active</returns>
		public static bool IsTextInputActive() { return Keyboard.isTextInputActive(); }
		
		#endregion // SDL Keyboard Methods
		
		#region SDL Joystick Methods
		
		/// <summary>Gets the number of joysticks present</summary>
		/// <returns>Returns the number of joysticks present</returns>
		public static int NumJoysticks() { return GetError(Joystick.numJoysticks()); }
		
		/// <summary>Opens up a joystick</summary>
		/// <param name="index">The index to open the joystick with</param>
		/// <returns>Returns the managed pointer to the joystick</returns>
		public static System.IntPtr JoystickOpen(int index) { return GetError(Joystick.open(index)); }
		
		/// <summary>Closes the given joystick</summary>
		/// <param name="joystick">The managed pointer to the joystick to close</param>
		public static void JoystickClose(System.IntPtr joystick) { Joystick.close(joystick); }
		
		/// <summary>Sets the LED color of the joystick</summary>
		/// <param name="joystick">The joystick to set the LED color to</param>
		/// <param name="color">The color to set the LED to</param>
		/// <returns>Returns 0 if successful, -1 if the joystick does not have an LED</returns>
		public static int JoystickSetLed(System.IntPtr joystick, Color color) { return GetError(Joystick.setLed(joystick, color.R, color.G, color.B)); }
		
		/// <summary>Gets the joystick from the given instance id</summary>
		/// <param name="index">The index of the joystick to get from</param>
		/// <returns>Returns a managed pointer to the joystick</returns>
		public static System.IntPtr JoystickFromInstanceId(int index) { return GetError(Joystick.fromInstanceId(index)); }
		
		/// <summary>Finds if the given joystick is a gamepad using an index</summary>
		/// <param name="index">The index of the joystick</param>
		/// <returns>Returns true if the joystick is a gamepad</returns>
		public static bool IsGamepad(int index) { return (GetError(Joystick.isGameController(index)) > 0);}
		
		#endregion // SDL Joystick Methods
		
		#region SDL Event Methods
		
		/// <summary>Polls any events that may arise</summary>
		/// <returns>Returns the event that got polled</returns>
		public static Event PollEvent() {
			// Variables
			Event e;
			
			GetError(Events.pollEvent(out e));
			
			return e;
		}
		
		/// <summary>Pumps the event loop, gathering events from the input devices.</summary>
		public static void PumpEvents() { Events.pumpEvent(); }
		
		#endregion // SDL Event Methods
		
		#region SDL Misc Methods
		
		/// <summary>Initiates the SDL2 framework</summary>
		/// <param name="flags">The initialization flags to initialize with</param>
		/// <returns>Returns the error code</returns>
		public static int Init(InitFlags flags) {
			// Variables
			int results = GetError(Misc.init((int)flags));
			
			if(!isInitiated) {
				AddEventWatch(Events.eventWatch, System.IntPtr.Zero);
				isInitiated = true;
			}
			
			return results;
		}
		
		/// <summary>Initiates a subsystem</summary>
		/// <param name="flags">The initialization flags to initiate the subsystem</param>
		/// <returns>Returns the error code</returns>
		public static int InitSubSystem(InitFlags flags) { return GetError(Misc.initSubSystem((int)flags)); }
		
		/// <summary>Quits from the SDL2 framework</summary>
		public static void Quit() { Misc.quit(); }
		
		/// <summary>Quits from a specific subsystem</summary>
		/// <param name="flags">The initialization flags to quit from</param>
		public static void QuitSubSystem(InitFlags flags) { Misc.quitSubSystem((int)flags); }
		
		/// <summary>Gets the version of the SDL library</summary>
		/// <returns>Returns the version of the SDL library</returns>
		public static Version GetVersion() {
			// Variables
			Version version;
			
			getVersion(out version);
			
			return version;
		}
		
		/// <summary>Gets the hint from the given name</summary>
		/// <param name="hint">The hint to query for</param>
		/// <returns>Returns the hint's details</returns>
		public static string GetHint(Hint hint) { return GetHint(hint.ConvertToString()); }
		
		/// <summary>Sets the SDL hint</summary>
		/// <param name="hint">The hint to set</param>
		/// <param name="value">The value of the hint</param>
		/// <returns>Returns true if the hint was set</returns>
		public static bool SetHint(Hint hint, string value) { return SetHint(hint.ConvertToString(), value); }
		
		/// <summary>Gets the hint from the given name</summary>
		/// <param name="hintName">The name of the hint to query for</param>
		/// <returns>Returns the hint's details</returns>
		public static string GetHint(string hintName) { return Convert.IntPtrToString(GetError(Misc.getHint(hintName))); }
		
		/// <summary>Sets the SDL hint</summary>
		/// <param name="hintName">The name of the hint to set</param>
		/// <param name="value">The value of the hint</param>
		/// <returns>Returns true if the hint was set</returns>
		public static bool SetHint(string hintName, string value) { return (GetError(Misc.setHint(hintName, value)) != 0); }
		
		/// <summary>Clears all the SDL hints stored</summary>
		public static void ClearHints() { Misc.clearHints(); }
		
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
		
		/// <summary>Called when the event watch is called</summary>
		/// <param name="data">Any user data, not used</param>
		/// <param name="e">The event that get generated</param>
		/// <returns>Returns 0</returns>
		private static int OnEventWatch(System.IntPtr data, ref Event e) {
			OnEvent?.Invoke(e);
			return 0;
		}
		
		/// <summary>Adds an event listener to SDL's events</summary>
		/// <param name="callback">The event callback</param>
		/// <param name="data">Any user data, not used</param>
		private static void AddEventWatch(Events.SDL_EventFilter callback, System.IntPtr data) {
			Events.addEventWatch(callback, data);
		}
		
		#endregion // Private Static Methods
		
		#region Internal Static Methods
		
		/// <summary>Converts the hint into a string</summary>
		/// <param name="hint">The hint enumeration to extend</param>
		/// <returns>Returns the name of the hint as a string</returns>
		internal static string ConvertToString(this Hint hint) {
			switch(hint) {
				case Hint.FramebufferAcceleration: return "SDL_FRAMEBUFFER_ACCELERATION";
				case Hint.RenderDriver: return "SDL_RENDER_DRIVER";
				case Hint.RenderScaleQuality: return "SDL_RENDER_SCALE_QUALITY";
				case Hint.RenderVSync: return "SDL_RENDER_VSYNC";
				case Hint.FrameUsableWhileCursorHidden: return "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";
				case Hint.EnableMessageLoop: return "SDL_WINDOWS_ENABLE_MESSAGELOOP";
				case Hint.GrabKeyboard: return "SDL_GRAB_KEYBOARD";
				case Hint.DoubleClickTime: return "SDL_MOUSE_DOUBLE_CLICK_TIME";
				case Hint.MinimizeOnFocusLoss: return "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
				case Hint.XInputEnabled: return "SDL_XINPUT_ENABLED";
				case Hint.GameControllerType: return "SDL_GAMECONTROLLERTYPE";
				case Hint.AllowJoystickBackgroundEvents: return "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
				case Hint.NoCloseOnAltF4: return "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";
				case Hint.DoubleBuffer: return "SDL_VIDEO_DOUBLE_BUFFER";
			}
			
			return "";
		}
		
		#endregion // Internal Static Methods
		
		#region Nested Types
		
		#region Enumerations
		
		/// <summary>An enumeration for all the initialization flags for SDL2</summary>
		[System.Flags]
		public enum InitFlags : uint {
			/// <summary>Initialize the SDL2 Video system</summary>
			Video = 32,
			/// <summary>Initialize the SDL2 Joystick system</summary>
			Joystick = 512,
			/// <summary>Initialize the SDL2 Haptic system</summary>
			Haptic = 4096,
			/// <summary>Initialize the SDL2 Game Controller system</summary>
			GameController = 8192,
			/// <summary>Initialize the SDL2 Sensor system</summary>
			Sensor = 32768,
			/// <summary>Initialize all the SDL2 systems</summary>
			Everything = (
				Video | Joystick | Haptic |
				GameController | Sensor
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
			/// <summary>When the keymap has changed (implemented from &gt;= SDL 2.0.4)</summary>
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
			JoystickAxisMotion = 1536,
			/// <summary>When a joystick trackball is in motion</summary>
			JoystickBallMotion,
			/// <summary>When a joystick dpad position has changed</summary>
			JoystickDpadMotion,
			/// <summary>When a joystick button is pressed</summary>
			JoystickButtonDown,
			/// <summary>When a joystick button is released</summary>
			JoystickButtonUp,
			/// <summary>When a joystick device has been added</summary>
			JoystickDeviceAdded,
			/// <summary>When a joystick device has been removed</summary>
			JoystickDeviceRemoved,
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
			/// <summary>When a new set of drops is beginning (implemented in &gt;= SDL 2.0.5)</summary>
			DropBegin,
			/// <summary>When a new set of drops is complete (implemented in &gt;= SDL 2.0.5)</summary>
			DropComplete,
			/// <summary>When a new audio device is added (implemented in &gt;= SDL 2.0.4)</summary>
			AudioDeviceAdded = 4352,
			/// <summary>When a new audio device is removed (implemented in &gt;= SDL 2.0.4)</summary>
			AudioDeviceRemoved,
			/// <summary>When a sensor is updated</summary>
			SensorUpdate = 4608,
			/// <summary>When the render targets have been reset and their contents needs to be updated (implemented in &gt;= SDL 2.0.2)</summary>
			RenderTargetsReset = 8192,
			/// <summary>When the device has been reset and all textures need to be recreated (implemented in &gt;= SDL 2.0.4)</summary>
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
		
		/// <summary>
		/// An enumeration for hints used by SDL that is also used internally by the engine,
		/// there are various hints that were left out on purpose. Look up other hints if you
		/// choose to use SDL exclusively. (https://www.libsdl.org)
		/// </summary>
		public enum Hint {
			/// <summary>
			/// A variables controlling how 3D acceleration is used to accelerate the SDL screen surface.
			/// The following values are accepted:
			/// * "0" - Disable 3D acceleration.
			/// * "1" - Enable 3D acceleration, using the default renderer.
			/// * "X" - Enable 3D acceleration, using X where X is one of the valid rendering drivers. (e.g. "direct3d", "opengl", etc)
			/// </summary>
			FramebufferAcceleration,
			/// <summary>
			/// The variable specifying which render driver to use.
			/// The following values are accepted (and are case insensitive):
			/// * "direct3d"
			/// * "opengl"
			/// * "opengles2"
			/// * "opengles"
			/// * "metal"
			/// * "software"
			/// </summary>
			RenderDriver,
			/// <summary>
			/// A variable controlling the scaling quality.
			/// The following values are accepted:
			/// * "0" or "nearest" - Nearest pixel sampling.
			/// * "1" or "linear"  - Linear filtering (supported by OpenGL and Direct3D).
			/// * "2" or "best" - Currently this is the same as "linear".
			/// </summary>
			RenderScaleQuality,
			/// <summary>
			/// A variable controlling whether updates to the SDL screen surface should be synchronized with the vsync to avoid tearing.
			/// The following values are accepted:
			/// * "0" - Disable vsync.
			/// * "1" - Enable vsync.
			/// </summary>
			RenderVSync,
			/// <summary>
			/// A variable controlling whether the window frame and title bar are interactive when the cursor is hidden.
			/// The following values are accepted:
			/// * "0" - The window frame is not interactive (no move, resize, etc).
			/// * "1" - The window frame is interactive.
			/// </summary>
			FrameUsableWhileCursorHidden,
			/// <summary>
			/// A variable controlling whether the windows message loop is processed by SDL.
			/// The following values are accpeted:
			/// * "0" - The window message loop is not run.
			/// * "1" - The window message loop is processed in PumpEvents().
			/// </summary>
			EnableMessageLoop,
			/// <summary>
			/// A variable controlling whether grabbing input grabs the keyboard.
			/// The following values are accepted:
			/// * "0" - Grab will affect only the mouse.
			/// * "1" - Grab will affect mouse and keyboard.
			/// </summary>
			GrabKeyboard,
			/// <summary>A variable setting the double click time, in milliseconds.</summary>
			DoubleClickTime,
			/// <summary>Minimizes the window if it loses key focus when in fullscreen mode. Defaults to true for &lt; SDL Version 2.0.14, false for &gt;= SDL Version 2.0.14.</summary>
			MinimizeOnFocusLoss,
			/// <summary>
			/// A variable that lets you disable the detection and use of XInput gamepad devices.
			/// The following values that are accepted:
			/// * "0" - Disable XInput detection.
			/// * "1" - Enable XInput detection (default).
			/// </summary>
			XInputEnabled,
			/// <summary>
			/// A variable that overrides the automatic controller type detection.
			/// Should be in a comma separated entries in the form of:
			/// ```
			/// VID/PID=type
			/// ```
			/// The following values are accepted:
			/// * "Xbox360".
			/// * "XboxOne".
			/// * "PS3".
			/// * "PS4".
			/// * "PS5".
			/// * "SwitchPro".
			/// </summary>
			GameControllerType,
			/// <summary>
			/// A variable that lets you enable joystick (and game controller) events even when your app is in the background.
			/// The following values are accepted:
			/// * "0" - Disable joystick &amp; game controller input events when the application is in the background.
			/// * "1" - Enable joystick &amp; game controller input events when the application is in the background.
			/// </summary>
			AllowJoystickBackgroundEvents,
			/// <summary>
			/// Tells SDL not to generate window-close events for Alt + F4 on Windows.
			/// The following values are accepted:
			/// * "0" - SDL will generate a window-close event when it sees Alt + F4.
			/// * "1" - SDL will only do normal key handling for Alt + F4.
			/// </summary>
			NoCloseOnAltF4,
			/// <summary>
			/// Tells the video driver that we only want a double buffer.
			/// By default, most lowlevel 2D APIs will use a triple buffer scheme that
			/// wastes no CPU time on waiting for vsync after issuing a flip, but
			/// introduces a frame of latency. On the other hand, using a double buffer
			/// scheme instead is recommended for cases where low latency is an important
			/// factor because we save a whole frame of latency.
			/// </summary>
			DoubleBuffer
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
			
			#region Public Properties
			
			/// <summary>Gets the keycode in key enum form</summary>
			public Keys Key { get {
				// Variables
				int f1 = 1073741882;
				int printScreen = 1073741894;
				int pageDown = 1073741902;
				int right = 1073741903;
				int up = 1073741906;
				int numlock = 1073741907;
				int decimalBtn = 1073741923;
				int leftCtrl = 1073742048;
				int rightAlt = 1073742054;
				int menu = 1073741925;
				int capslock = 1073741881;
				
				// a-z keys on keyboard
				if(this.keycode >= 'a' && this.keycode <= 'z') {
					return (Keys)(this.keycode - 'a');
				}
				
				// 0-9 keys on keyboard
				if(this.keycode >= '0' && this.keycode <= '9') {
					return (Keys)(this.keycode - '0' + Keys.Zero);
				}
				
				// Straight checks, check the ascii table for the numbers
				if(this.keycode == 8) { return Keys.Backspace; }
				if(this.keycode == 9) { return Keys.Tab; }
				if(this.keycode == 13) { return Keys.Enter; }
				if(this.keycode == 27) { return Keys.Escape; }
				if(this.keycode == 32) { return Keys.Space; }
				if(this.keycode == 39) { return Keys.SingleQuote; }
				// Comma, Dash, Period, Forwardslash
				if(this.keycode >= 44 && this.keycode <= 47) {
					return (Keys)(this.keycode - 44 + Keys.Comma);
				}
				if(this.keycode == 59) { return Keys.Semicolon; }
				if(this.keycode == 61) { return Keys.Equals; }
				// Left Square Bracket, Backslash, Right Square Bracket
				if(this.keycode >= 91 && this.keycode <= 93) {
					return (Keys)(this.keycode - 91 + Keys.LeftSquareBracket);
				}
				if(this.keycode == 96) { return Keys.GraveAccent; }
				if(this.keycode == 127) { return Keys.Delete; }
				if(this.keycode == menu) { return Keys.Menu; }
				if(this.keycode == capslock) { return Keys.CapsLock; }
				
				// Print Screen - Page Down buttons
				if(this.keycode >= printScreen && this.keycode <= pageDown) {
					return (Keys)(this.keycode - printScreen + Keys.PrintScreen);
				}
				
				// Right, Left, Down, Up buttons
				if(this.keycode >= right && this.keycode <= up) {
					return (Keys)(this.keycode - right + Keys.Right);
				}
				
				// F1 - F25 buttons
				if(this.keycode >= f1 && this.keycode <= (f1 + 24)) {
					return (Keys)(this.keycode - f1 + Keys.F1);
				}
				
				// Numpad buttons
				if(this.keycode >= numlock && this.keycode <= decimalBtn) {
					return (Keys)(this.keycode - numlock + Keys.NumLock);
				}
				
				// Left Ctrl to Right Alt buttons
				if(this.keycode >= leftCtrl && this.keycode <= rightAlt) {
					return (Keys)(this.keycode - leftCtrl + Keys.LeftCtrl);
				}
				
				return Keys.Unknown;
			} }
			
			#endregion // Public Properties
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
			/// <summary>The event for mouse motion</summary>
			[FieldOffset(0)]
			public MouseMotionEvent mouse;
			/// <summary>The event for mouse button</summary>
			[FieldOffset(0)]
			public MouseButtonEvent mouseButton;
			/// <summary>The event for mouse wheel</summary>
			[FieldOffset(0)]
			public MouseWheelEvent mouseWheel;
			/// <summary>The event for joystick axis</summary>
			[FieldOffset(0)]
			public JoystickAxisEvent joystickAxis;
			/// <summary>The event for joystick buttons</summary>
			[FieldOffset(0)]
			public JoystickButtonEvent joystickButton;
			/// <summary>The event for joystick trackball</summary>
			[FieldOffset(0)]
			public JoystickBallEvent joystickBall;
			/// <summary>The event for joystick dpad</summary>
			[FieldOffset(0)]
			public JoystickDpadEvent joystickDpad;
			/// <summary>The event for controller axis</summary>
			[FieldOffset(0)]
			public JoystickAxisEvent controllerAxis;
			/// <summary>The event for controller button</summary>
			[FieldOffset(0)]
			public JoystickButtonEvent controllerButton;
			/// <summary>The event for joystick device</summary>
			[FieldOffset(0)]
			public JoystickDeviceEvent joystickDevice;
			/// <summary>The event for controller device</summary>
			[FieldOffset(0)]
			public JoystickDeviceEvent controllerDevice;
			/// <summary>The event for controller touchpad</summary>
			[FieldOffset(0)]
			public ControllerTouchpadEvent controllerTouchpad;
			/// <summary>The event for controller sensor</summary>
			[FieldOffset(0)]
			public ControllerSensorEvent controllerSensor;
			
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
		
		/// <summary>The structure for the mouse motion event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseMotionEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the window the keyboard has focus on</summary>
			public uint windowId;
			/// <summary>The mouse instance id</summary>
			public uint which;
			/// <summary>The current button state</summary>
			public uint state;
			/// <summary>The x coordinate of the mouse relative to the window</summary>
			public int x;
			/// <summary>The y coordinate of the mouse relative to the window</summary>
			public int y;
			/// <summary>The relative motion in the x direction</summary>
			public int xRel;
			/// <summary>The relative motion in the y direction</summary>
			public int yRel;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the mouse button event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseButtonEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the window the keyboard has focus on</summary>
			public uint windowId;
			/// <summary>The mouse instance id</summary>
			public uint which;
			/// <summary>The button of the mouse</summary>
			public byte button;
			/// <summary>The state of the mouse (either pressed or released)</summary>
			public byte state;
			/// <summary>The amount of clicks (single-click, double-click, triple-click, etc)</summary>
			public byte clicks;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>The x coordinate of the mouse relative to the window</summary>
			public int x;
			/// <summary>The y coordinate of the mouse relative to the window</summary>
			public int y;
			
			#endregion // Field Variables
			
			#region Public Properties
			
			/// <summary>Gets if a mouse button is pressed</summary>
			public bool IsPressed { get { return (this.state > 0); } }
			
			/// <summary>Gets the mouse button in enum form</summary>
			public MouseButton Button { get { return (MouseButton)(this.button - 1); } }
			
			#endregion // Public Properties
		}
		
		/// <summary>The structure for the mouse wheel event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseWheelEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The id of the window the keyboard has focus on</summary>
			public uint windowId;
			/// <summary>The mouse instance id</summary>
			public uint which;
			/// <summary>The amount scrolled horiontally, positive to the right and negative to the left</summary>
			public int x;
			/// <summary>The amount scrolled vertically, positive away from the user and negative towards the user</summary>
			public int y;
			/// <summary>Set to one of the mouse wheel deinitions, when flipped the values in X and Y will be the opposite</summary>
			public uint direction;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the joystick axis event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickAxisEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The joystick/controller instance id</summary>
			public int which;
			/// <summary>The index of the axis</summary>
			public byte axis;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			/// <summary>No description</summary>
			public byte padding3;
			/// <summary>The value of the axis, ranges from -32768 to 32767</summary>
			public short value;
			/// <summary>No description</summary>
			public ushort padding4;
			
			#endregion // Field Variables
			
			#region Public Properties
			
			/// <summary>Gets the axis of the joystick/controller</summary>
			public GamepadAxis Axis { get { return (GamepadAxis)(this.axis); } }
			
			/// <summary>Gets the value of the axis in float form (from -1 to 1)</summary>
			public float FloatValue { get { return Mathx.Clamp((float)this.value / (float)short.MaxValue, -1.0f, 1.0f); } }
			
			#endregion // Public Properties
		}
		
		/// <summary>The structure for the joystick ball event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickBallEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The joystick/controller instance id</summary>
			public int which;
			/// <summary>The index of the ball</summary>
			public byte ball;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			/// <summary>No description</summary>
			public byte padding3;
			/// <summary>The relative motion in the x direction</summary>
			public short xRel;
			/// <summary>The relative motion in the y direction</summary>
			public short yRel;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the joystick dpad event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickDpadEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The joystick/controller instance id</summary>
			public int which;
			/// <summary>The index of the hat</summary>
			public byte hat;
			/// <summary>
			/// The hat position value.
			/// The following values can exist:
			/// * 0 - Centered
			/// * 1 - Up
			/// * 2 - Right
			/// * 3 - Up-Right
			/// * 4 - Down
			/// * 6 - Down-Right
			/// * 8 - Left
			/// * 9 - Up-Left
			/// * 12 - Down-Left
			/// </summary>
			public byte value;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the joystick button event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickButtonEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The joystick/controller instance id</summary>
			public int which;
			/// <summary>The index of the button</summary>
			public byte button;
			/// <summary>The state of the button (either pressed or released)</summary>
			public byte state;
			/// <summary>No description</summary>
			public byte padding1;
			/// <summary>No description</summary>
			public byte padding2;
			
			#endregion // Field Variables
			
			#region Public Properties
			
			/// <summary>Gets the button on the joystick/controller</summary>
			public GamepadButton Buton { get { return (GamepadButton)this.button; } }
			
			#endregion // Public Properties
		}
		
		/// <summary>The structure for the joystick device event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JoystickDeviceEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The joystick/controller instance id</summary>
			public int which;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the controller touchpad event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerTouchpadEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The controller instance id</summary>
			public int which;
			/// <summary>The index of the touchpad</summary>
			public int touchpad;
			/// <summary>The index of the finger on the touchpad</summary>
			public int finger;
			/// <summary>The x coordinate of the touchpad normalized to be within the range of 0 to 1</summary>
			public float x;
			/// <summary>The y coordinate of the touchpad normalized to be within the range of 0 to 1</summary>
			public float y;
			/// <summary>The amount of pressure the user placed on the touchpad, normalized from 0 to 1</summary>
			public float pressure;
			
			#endregion // Field Variables
		}
		
		/// <summary>The structure for the controller sensor event</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct ControllerSensorEvent {
			#region Field Variables
			// Variables
			/// <summary>The type of the event</summary>
			public EventType type;
			/// <summary>The timestamp (in milliseconds) of when the event was triggered</summary>
			public uint timestamp;
			/// <summary>The controller instance id</summary>
			public int which;
			/// <summary>The index of the sensor</summary>
			public int sensor;
			/// <summary>The acceleration on the x axis</summary>
			public float x;
			/// <summary>The acceleration on the y axis</summary>
			public float y;
			/// <summary>The acceleration on the z axis</summary>
			public float z;
			
			#endregion // Field Variables
		}
		
		#endregion // Events
		
		#endregion // Structures
		
		#region Classes
		
		/// <summary>The initialization portion of the SDL framework</summary>
		private static class Misc {
			#region Field Variables
			// Variables
			internal static SDL_GetError getError = FuncLoader.LoadFunc<SDL_GetError>(library, "SDL_GetError");
			internal static SDL_Init init = FuncLoader.LoadFunc<SDL_Init>(SDL.library, "SDL_Init");
			internal static SDL_Init initSubSystem = FuncLoader.LoadFunc<SDL_Init>(SDL.library, "SDL_InitSubSystem");
			internal static SDL.Action quit = FuncLoader.LoadFunc<SDL.Action>(SDL.library, "SDL_Quit");
			internal static SDL_QuitSubSystem quitSubSystem = FuncLoader.LoadFunc<SDL_QuitSubSystem>(SDL.library, "SDL_QuitSubSystem");
			internal static SDL_GetHint getHint = FuncLoader.LoadFunc<SDL_GetHint>(library, "SDL_GetHint");
			internal static SDL_SetHint setHint = FuncLoader.LoadFunc<SDL_SetHint>(library, "SDL_SetHint");
			internal static SDL.Action clearHints = FuncLoader.LoadFunc<SDL.Action>(library, "SDL_ClearHints");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate System.IntPtr SDL_GetError();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_Init(int flags);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_QuitSubSystem(int flags);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_SetHint(string name, string value);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate System.IntPtr SDL_GetHint(string name);
			
			#endregion // Field Variables
		}
		
		/// <summary>The events portion of the SDL framework</summary>
		private static class Events {
			#region Field Variables
			// Variables
			internal static SDL.Action pumpEvent = FuncLoader.LoadFunc<SDL.Action>(library, "SDL_PumpEvents");
			internal static SDL_PollEvent pollEvent = FuncLoader.LoadFunc<SDL_PollEvent>(library, "SDL_PollEvent");
			internal static SDL_AddEventWatch addEventWatch = FuncLoader.LoadFunc<SDL_AddEventWatch>(library, "SDL_AddEventWatch");
			internal static readonly SDL_EventFilter eventWatch = SDL.OnEventWatch;
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_PollEvent([Out] out Event e);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_EventFilter(System.IntPtr data, ref Event e);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_AddEventWatch(SDL_EventFilter filter, System.IntPtr data);
			
			#endregion // Field Variables
		}
		
		/// <summary>The keyboard portion of the SDL framework</summary>
		private static class Keyboard {
			#region Field Variables
			// Variables
			internal static SDL.Action startTextInput = FuncLoader.LoadFunc<SDL.Action>(library, "SDL_StartTextInput");
			internal static SDL.Action stopTextInput = FuncLoader.LoadFunc<SDL.Action>(library, "SDL_StopTextInput");
			internal static SDL_IsTextInputActive isTextInputActive = FuncLoader.LoadFunc<SDL_IsTextInputActive>(library, "SDL_IsTextInputActive");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool SDL_IsTextInputActive(); 
			
			#endregion // Field Variables
		}
		
		/// <summary>The joystick portion of the SDL framework</summary>
		private static class Joystick {
			#region Field Variables
			// Variables
			internal static SDL_NumJoysticks numJoysticks = FuncLoader.LoadFunc<SDL_NumJoysticks>(library, "SDL_NumJoysticks");
			internal static SDL_JoystickOpen open = FuncLoader.LoadFunc<SDL_JoystickOpen>(library, "SDL_JoystickOpen");
			internal static SDL_JoystickClose close = FuncLoader.LoadFunc<SDL_JoystickClose>(library, "SDL_JoystickClose");
			internal static SDL_JoystickSetLed setLed = FuncLoader.LoadFunc<SDL_JoystickSetLed>(library, "SDL_JoystickSetLED");
			internal static SDL_JoystickOpen fromInstanceId = FuncLoader.LoadFunc<SDL_JoystickOpen>(library, "SDL_JoystickFromInstanceID");
			internal static SDL_IsGameController isGameController = FuncLoader.LoadFunc<SDL_IsGameController>(library, "SDL_IsGameController");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_NumJoysticks();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate System.IntPtr SDL_JoystickOpen(int index);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_JoystickClose(System.IntPtr joystick);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_JoystickSetLed(System.IntPtr joystick, byte red, byte green, byte blue);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_IsGameController(int index);
			
			#endregion // Field Variables
		}
		
		#endregion // Classes
		
		#endregion // Nested Types
	}
}


using System.Runtime.InteropServices;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Gets the state of the mouse</summary>
		/// <param name="x">The x coordinate of the mouse</param>
		/// <param name="y">The y coordinate of the mouse</param>
		/// <returns>Returns the array of input states of the mouse buttons</returns>
		public static InputState[] GetMouseState(out float x, out float y) {
			// Variables
			int tx, ty;
			uint buttons = Mouse.getState(out tx, out ty);
			InputState[] results = new InputState[System.Enum.GetNames(typeof(MouseButton)).Length - 1];
			int temp;
			
			for(int i = 0; i < results.Length; i++) {
				temp = (int)Mathx.Pow(2, i);
				results[i] = ((buttons & temp) == 0) ? InputState.Released : InputState.Pressed;
			}
			
			x = tx;
			y = ty;
			
			return results;
		}
		
		/// <summary>Sets if SDL should capture the mouse if it's outside the window</summary>
		/// <param name="enabled">Set to true to capture the mouse even if its outside the window</param>
		/// <returns>Returns true if the method succeeded</returns>
		public static bool CaptureMouse(bool enabled) { return (GetError(Mouse.capture(enabled ? 1 : 0)) == 0); }
		
		/// <summary>Shows or hides the cursor</summary>
		/// <param name="show">Set to true to show the cursor, otherwise hides the cursor</param>
		/// <returns>Returns true if the cursor is shown</returns>
		public static bool ShowCursor(bool show) { return (GetError(Mouse.show(show ? 1 : 0)) == 0); }
		
		/// <summary>Sets the cursor to the managed pointer of a cursor</summary>
		/// <param name="cursor">The managed pointer to the cursor to use</param>
		public static void SetCursor(IntPtr cursor) { Mouse.set(cursor); }
		
		/// <summary>Frees the cursor so that</summary>
		/// <param name="cursor">The managed pointer to the cursor to free</param>
		public static void FreeCursor(IntPtr cursor) { Mouse.free(cursor); }
		
		/// <summary>Gets the active cursor</summary>
		/// <returns>Returns the managed pointer to the active cursor</returns>
		public static IntPtr GetCursor() { return GetError(Mouse.get()); }
		
		/// <summary>Creates a system cursor</summary>
		/// <param name="type">The type of system cursor to create</param>
		/// <returns>Returns the managed pointer to a system cursor</returns>
		public static IntPtr CreateSystemCursor(SystemCursorType type) { return GetError(Mouse.createSystem(type)); }
		
		/// <summary>Creates an image cursor</summary>
		/// <param name="surface">The managed pointer to the SDL surface</param>
		/// <param name="x">The x coordinate of where the clicking would happen</param>
		/// <param name="y">The y coordinate of where the clicking would happen</param>
		/// <returns>Returns the managed pointer to an image cursor</returns>
		public static IntPtr CreateColorCursor(IntPtr surface, int x, int y) { return GetError(Mouse.createColorCursor(surface, x, y)); }
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		private static class Mouse {
			#region Field Variables
			// Variables
			internal static SDL_GetMouseState getState = FuncLoader.LoadFunc<SDL_GetMouseState>(library, "SDL_GetMouseState");
			internal static SDL_CaptureMouse capture = FuncLoader.LoadFunc<SDL_CaptureMouse>(library, "SDL_CaptureMouse");
			internal static SDL_CaptureMouse show = FuncLoader.LoadFunc<SDL_CaptureMouse>(library, "SDL_ShowCursor");
			internal static SDL_FreeCursor free = FuncLoader.LoadFunc<SDL_FreeCursor>(library, "SDL_FreeCursor");
			internal static SDL_FreeCursor set = FuncLoader.LoadFunc<SDL_FreeCursor>(library, "SDL_SetCursor");
			internal static SDL_GetCursor get = FuncLoader.LoadFunc<SDL_GetCursor>(library, "SDL_GetCursor");
			internal static SDL_CreateSystemCursor createSystem = FuncLoader.LoadFunc<SDL_CreateSystemCursor>(library, "SDL_CreateSystemCursor");
			internal static SDL_CreateColorCursor createColorCursor = FuncLoader.LoadFunc<SDL_CreateColorCursor>(library, "SDL_CreateColorCursor");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint SDL_GetMouseState([Out] out int x, [Out] out int y);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_CaptureMouse(int enabled);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_FreeCursor(IntPtr cursor);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_GetCursor();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_CreateSystemCursor(SystemCursorType type);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_CreateColorCursor(IntPtr surface, int x, int y);
			
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
		
		#endregion // Nested Types
	}
}

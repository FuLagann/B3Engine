
using System.Runtime.InteropServices;
using System.Text;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Gets the number of joysticks present</summary>
		/// <returns>Returns the number of joysticks present</returns>
		public static int NumJoysticks() { return GetError(Joystick.num()); }
		
		/// <summary>Opens up a joystick</summary>
		/// <param name="index">The index to open the joystick with</param>
		/// <returns>Returns the managed pointer to the joystick</returns>
		public static IntPtr JoystickOpen(int index) { return GetError(Joystick.open(index)); }
		
		/// <summary>Closes the given joystick</summary>
		/// <param name="joystick">The managed pointer to the joystick to close</param>
		public static void JoystickClose(IntPtr joystick) { Joystick.close(joystick); }
		
		/// <summary>Sets the LED color of the joystick</summary>
		/// <param name="joystick">The joystick to set the LED color to</param>
		/// <param name="color">The color to set the LED to</param>
		/// <returns>Returns 0 if successful, -1 if the joystick does not have an LED</returns>
		public static int JoystickSetLed(IntPtr joystick, Color color) { return GetError(Joystick.setLed(joystick, color.R, color.G, color.B)); }
		
		/// <summary>Finds if the given joystick is a gamepad using an index</summary>
		/// <param name="index">The index of the joystick</param>
		/// <returns>Returns true if the joystick is a gamepad</returns>
		public static bool IsGamepad(int index) { return (GetError(Joystick.isGameController(index)) > 0);}
		
		/// <summary>Finds if the given joystick is opened</summary>
		/// <param name="joystick">The joystick to query if it is opened</param>
		/// <returns>Returns true if the joystick is opened</returns>
		public static bool JoystickGetAttached(IntPtr joystick) { return (GetError(Joystick.getAttached(joystick)) == 1); }
		
		/// <summary>Gets the name of the joystick</summary>
		/// <param name="joystick">The joystick to query the name of</param>
		/// <returns>Returns the name of the joystick</returns>
		public static string JoystickName(IntPtr joystick) { return Convert.IntPtrToString(GetError(Joystick.name(joystick))); }
		
		/// <summary>Gets the number of buttons on the joystick</summary>
		/// <param name="joystick">The joystick to query the number of buttons</param>
		/// <returns>Returns the number of buttons found on the joystick</returns>
		public static int JoystickNumButtons(IntPtr joystick) { return GetError(Joystick.numButtons(joystick)); }
		
		/// <summary>Gets if the button is pressed</summary>
		/// <param name="joystick">The joystick to query if a button is pressed</param>
		/// <param name="button">The id of the button to query</param>
		/// <returns>Returns true if the button is pressed</returns>
		public static bool JoystickGetButton(IntPtr joystick, int button) { return Joystick.getButton(joystick, button) == 1; }
		
		/// <summary>Gets the number of axes that the joystick has</summary>
		/// <param name="joystick">The joystick to query how many axes it contains</param>
		/// <returns>Returns the number of axes the joystick contains</returns>
		public static int JoystickNumAxes(IntPtr joystick) { return GetError(Joystick.numAxis(joystick)); }
		
		/// <summary>Gets the axis data from the joystick</summary>
		/// <param name="joystick">The joystick to query about the axis data</param>
		/// <param name="axis">The axis to query about</param>
		/// <returns>Returns the state of the axis in short form</returns>
		public static short JoystickGetAxis(IntPtr joystick, int axis) { return Joystick.getAxis(joystick, axis); }
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		private static class Joystick {
			#region Field Variables
			// Variables
			internal static SDL_NumJoysticks num = FuncLoader.LoadFunc<SDL_NumJoysticks>(library, "SDL_NumJoysticks");
			internal static SDL_JoystickOpen open = FuncLoader.LoadFunc<SDL_JoystickOpen>(library, "SDL_JoystickOpen");
			internal static SDL_JoystickClose close = FuncLoader.LoadFunc<SDL_JoystickClose>(library, "SDL_JoystickClose");
			internal static SDL_JoystickSetLed setLed = FuncLoader.LoadFunc<SDL_JoystickSetLed>(library, "SDL_JoystickSetLED");
			internal static SDL_IsGameController isGameController = FuncLoader.LoadFunc<SDL_IsGameController>(library, "SDL_IsGameController");
			internal static SDL_JoystickGetAttached getAttached = FuncLoader.LoadFunc<SDL_JoystickGetAttached>(library, "SDL_JoystickGetAttached");
			internal static SDL_JoystickName name = FuncLoader.LoadFunc<SDL_JoystickName>(library, "SDL_JoystickName");
			internal static SDL_JoystickGetAttached numButtons = FuncLoader.LoadFunc<SDL_JoystickGetAttached>(library, "SDL_JoystickNumButtons");
			internal static SDL_JoystickGetAttached numAxis = FuncLoader.LoadFunc<SDL_JoystickGetAttached>(library, "SDL_JoystickNumAxes");
			internal static SDL_JoystickGetButton getButton = FuncLoader.LoadFunc<SDL_JoystickGetButton>(library, "SDL_JoystickGetButton");
			internal static SDL_JoystickGetAxis getAxis = FuncLoader.LoadFunc<SDL_JoystickGetAxis>(library, "SDL_JoystickGetAxis");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_NumJoysticks();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_JoystickOpen(int index);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_JoystickClose(IntPtr joystick);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_JoystickSetLed(IntPtr joystick, byte red, byte green, byte blue);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_IsGameController(int index);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_JoystickGetAttached(IntPtr ptr);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_JoystickName(IntPtr joystick);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate byte SDL_JoystickGetButton(IntPtr joystick, int button);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate short SDL_JoystickGetAxis(IntPtr joystick, int axis);
			
			#endregion // Field Variables
		}
		
		#endregion // Nested Types
	}
}

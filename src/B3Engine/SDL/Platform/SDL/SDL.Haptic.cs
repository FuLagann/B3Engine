
using System.Runtime.InteropServices;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Gets the number of haptic devices available to use</summary>
		/// <returns>Returns the number of haptic devices available</returns>
		public static int NumHaptic() { return GetError(Haptic.num()); }
		
		/// <summary>Opens the haptic device found within the index</summary>
		/// <param name="index">The index of the haptic device to open on</param>
		/// <returns>Returns the managed pointer to the haptic device</returns>
		public static IntPtr HapticOpen(int index) { return GetError(Haptic.open(index)); }
		
		/// <summary>Opens the haptic device tied directly to a joystick</summary>
		/// <param name="joystick">The managed pointer to the joystick</param>
		/// <returns>Returns the managed pointer to the haptic device</returns>
		/// <remarks>
		/// Do note that sometimes the haptic device isn't always directly tied to the joystick
		/// and this might return null while <see cref="B3.Utilities.SDL.HapticOpen(int)"/> of a
		/// given valid index will return the haptic device that will affect the joystick you were
		/// trying to use in the parameter
		/// </remarks>
		public static IntPtr HapticOpenFromJoystick(IntPtr joystick) { return GetError(Haptic.openFromJoystick(joystick)); }
		
		/// <summary>Initializes the simple rumble feedback of a controller</summary>
		/// <param name="haptic">The managed pointer to the haptic device to affect</param>
		/// <returns>Returns true if the initialization succeeded</returns>
		public static bool HapticRumbleInit(IntPtr haptic) { return (GetError(Haptic.rumbleInit(haptic)) == 0); }
		
		/// <summary>Plays a haptic rumble on the chosen device</summary>
		/// <param name="haptic">The managed pointer to the haptic device to rumble</param>
		/// <param name="strength">The strength of the rumble, going from 0 to 1</param>
		/// <param name="length">The length of the rumble in milliseconds</param>
		/// <returns>Returns true if the rumble could be played</returns>
		public static bool HapticRumblePlay(IntPtr haptic, float strength, uint length) {
			return (GetError(
				Haptic.rumblePlay(haptic, Mathx.Clamp(strength, 0.0f, 1.0f), length)
			) == 0);
		}
		
		/// <summary>Stops the haptic rumble on the chosen device</summary>
		/// <param name="haptic">The managed pointer to the haptic device to stop the rumble</param>
		/// <returns>Returns true if the rumble could be stopped (or the function could be called)</returns>
		public static bool HapticRumbleStop(IntPtr haptic) { return (GetError(Haptic.rumbleStop(haptic)) == 0); }
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		/// <summary>The haptic feedback portion of the SDL framework</summary>
		private static class Haptic {
			#region Field Variables
			// Variables
			internal static Joystick.SDL_NumJoysticks num = FuncLoader.LoadFunc<Joystick.SDL_NumJoysticks>(library, "SDL_NumHaptics");
			internal static Joystick.SDL_JoystickOpen open = FuncLoader.LoadFunc<Joystick.SDL_JoystickOpen>(library, "SDL_HapticOpen");
			internal static SDL_HapticOpenFromJoystick openFromJoystick = FuncLoader.LoadFunc<SDL_HapticOpenFromJoystick>(library, "SDL_HapticOpenFromJoystick");
			internal static SDL_HapticRumbleInit rumbleInit = FuncLoader.LoadFunc<SDL_HapticRumbleInit>(library, "SDL_HapticRumbleInit");
			internal static SDL_HapticRumblePlay rumblePlay = FuncLoader.LoadFunc<SDL_HapticRumblePlay>(library, "SDL_HapticRumblePlay");
			internal static SDL_HapticRumbleInit rumbleStop = FuncLoader.LoadFunc<SDL_HapticRumbleInit>(library, "SDL_HapticRumbleStop");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_HapticRumbleInit(IntPtr haptic);
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_HapticRumblePlay(IntPtr haptic, float strength, uint length);
			
			#endregion // Field Variables
		}
		
		#endregion // Nested Types
	}
}

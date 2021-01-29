
using System.Runtime.InteropServices;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Gets the state of the keyboard</summary>
		/// <returns>Returns the array of all the keys and their input state</returns>
		public static InputState[] GetKeyboardState() {
			// Variables
			int size;
			IntPtr ptr = Keyboard.getState(out size);
			byte[] bytes = new byte[size];
			Keys key;
			InputState[] results = new InputState[System.Enum.GetNames(typeof(Keys)).Length - 1];
			
			Marshal.Copy(ptr, bytes, 0, size);
			
			for(int i = 0; i < size; i++) {
				key = ConvertScancode(i);
				if(key != Keys.Unknown) { results[(int)key] = (InputState)bytes[i]; }
			}
			
			return results;
		}
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Converts the scancode into a keys enumeration</summary>
		/// <param name="scancode">The scan code to convert</param>
		/// <returns>Returns the converted keys enumeration</returns>
		private static Keys ConvertScancode(int scancode) {
			// Keys for a-z
			if(scancode >= 4 && scancode <= 29) {
				return Keys.A + (scancode - 4);
			}
			// Keys for 1-0 non-numpad keys
			if(scancode >= 30 && scancode <= 39) {
				return Keys.One + (scancode - 30);
			}
			// Enter, Escape, Backspace, Tab, Space, Minus, Equals,
			// Left Square Bracket, Right Square Bracket,
			// and Backslash keys
			if(scancode >= 40 && scancode <= 49) {
				return Keys.Enter + (scancode - 40);
			}
			// Semicolon, Single Quote, Grave, Comma, Period, Forwardslash,
			// Capslock keys
			if(scancode >= 51 && scancode <= 57) {
				return Keys.Semicolon + (scancode - 51);
			}
			// Keys for F1-F12
			if(scancode >= 58 && scancode <= 69) {
				return Keys.F1 + (scancode - 58);
			}
			if(scancode >= 70 && scancode <= 99) {
				return Keys.PrintScreen + (scancode - 70);
			}
			if(scancode == 101) { return Keys.Menu; }
			if(scancode >= 224 && scancode <= 230) {
				return Keys.LeftCtrl + (scancode - 224);
			}
			return Keys.Unknown;
		}
		
		#endregion // Private Static Methods
		
		#region Nested Types
		
		/// <summary>The keyboard portion of the SDL framework</summary>
		private static class Keyboard {
			#region Field Variables
			// Variables
			internal static SDL_GetKeyboardState getState = FuncLoader.LoadFunc<SDL_GetKeyboardState>(library, "SDL_GetKeyboardState");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_GetKeyboardState([Out] out int numKeys);
			
			#endregion // Field Variables
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
			public Keys Key { get { return SDL.ConvertScancode(this.scancode); } }
			
			#endregion // Public Properties
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
		
		#endregion // Nested Types
	}
}

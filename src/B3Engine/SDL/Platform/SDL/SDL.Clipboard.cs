
using System.Runtime.InteropServices;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	public static partial class SDL {
		#region Public Static Methods
		
		/// <summary>Finds if the clipboard holds any text</summary>
		/// <returns>Returns true if the clipboard contains any text</returns>
		public static bool HasClipboardText() { return (GetError(Clipboard.hasText()) == 1); }
		
		/// <summary>Gets the text from the clipboard</summary>
		/// <returns>Returns the text from the clipboard</returns>
		public static string GetClipboardText() { return Convert.IntPtrToString(GetError(Clipboard.getText())); }
		
		/// <summary>Sets the text saved on the clipboard</summary>
		/// <param name="text">The text to save onto the clipboard</param>
		public static void SetClipboardText(string text) { Clipboard.setText(text); }
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		private static class Clipboard {
			#region Field Variables
			// Variables
			internal static SDL_HasClipboardText hasText = FuncLoader.LoadFunc<SDL_HasClipboardText>(library, "SDL_HasClipboardText");
			internal static SDL_GetClipboardText getText = FuncLoader.LoadFunc<SDL_GetClipboardText>(library, "SDL_GetClipboardText");
			internal static SDL_SetClipboardText setText = FuncLoader.LoadFunc<SDL_SetClipboardText>(library, "SDL_SetClipboardText");
			
			// Delegates
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int SDL_HasClipboardText();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr SDL_GetClipboardText();
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SDL_SetClipboardText(string text);
			
			#endregion // Field Variables
		}
		
		#endregion // Nested Types
	}
}

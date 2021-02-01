
using B3.Utilities;

namespace B3 {
	public partial struct ClipboardState {
		#region Partial Methods
		
		/// <summary>A partial method that finds if the clipboard has any text</summary>
		/// <returns>Returns true if the clipboard has any text</returns>
		partial void PartialHasText() { this.hasText = SDL.HasClipboardText(); }
		
		/// <summary>A partial method that gets the text from the clipboard</summary>
		/// <returns>Returns the string of the text on the clipboard</returns>
		partial void PartialGetText() { this.text = SDL.GetClipboardText(); }
		
		/// <summary>A partial method that sets the text of the clipboard</summary>
		/// <param name="text">The text to set the clipboard</param>
		partial void PartialSetText(string text) { SDL.SetClipboardText(text); }
		
		#endregion // Partial Methods
	}
}


using B3.Utilities;

namespace B3 {
	public partial struct KeyboardState {
		#region Partial Methods
		
		/// <summary>A partial method that starts the text input</summary>
		partial void PartialStartTextInput() { SDL.StartTextInput(); }
		
		/// <summary>A partial method that stops the text input</summary>
		partial void PartialStopTextInput() { SDL.StopTextInput(); }
		
		#endregion // Partial Methods
	}
}

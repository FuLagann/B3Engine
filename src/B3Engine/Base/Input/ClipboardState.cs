
namespace B3 {
	/// <summary>The state of the clipboard to get text from</summary>
	public partial struct ClipboardState {
		#region Field Variables
		// Variables
		private bool hasText;
		private string text;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for setting up the state of the clipboard</summary>
		/// <param name="text">The text to start out the state of the clipboard</param>
		public ClipboardState(string text) {
			this.hasText = !string.IsNullOrEmpty(text);
			this.text = text;
		}
		
		#endregion // Public Constructors
		
		#region Public Properties
		
		/// <summary>Gets and sets the text of the clipboard</summary>
		public string Text { get {
			this.PartialGetText();
			return this.text;
		} }
		
		/// <summary>Gets if the clipboard holds any text</summary>
		public bool HasText { get {
			this.PartialHasText();
			return this.hasText;
		} }
		
		#endregion // Public Properties
		
		#region Public Methods
		
		/// <summary>Sets the text on the clipboard</summary>
		/// <param name="text">The text to set onto the clipboard</param>
		public void SetText(string text) { this.PartialSetText(text); }
		
		#endregion // Public Methods
		
		#region Partial Methods
		
		/// <summary>A partial method that finds if the clipboard has any text</summary>
		/// <returns>Returns true if the clipboard has any text</returns>
		partial void PartialHasText();
		
		/// <summary>A partial method that gets the text from the clipboard</summary>
		/// <returns>Returns the string of the text on the clipboard</returns>
		partial void PartialGetText();
		
		/// <summary>A partial method that sets the text of the clipboard</summary>
		/// <param name="text">The text to set the clipboard</param>
		partial void PartialSetText(string text);
		
		#endregion // Partial Methods
	}
}

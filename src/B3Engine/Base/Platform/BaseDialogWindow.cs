
namespace B3 {
	/// <summary>A base dialog window that works similar to the game window but with a couple caveats</summary>
	public abstract class BaseDialogWindow : BaseGameWindow, IDialogWindow {
		#region Public Properties
		
		/// <summary>Gets and sets the data of the dialog window</summary>
		public object Data { get; set; }
		
		#endregion // Public Properties
		
		#region Public Methods
		
		// TODO: Complete this method to work like whats listed on the B3Engine project (https://github.com/FuLagann/B3Engine/projects/1)
		/// <summary>Shows the dialog window with the given data</summary>
		/// <param name="interrupt">Set to true to interrupt the primary windows inputs</param>
		/// <param name="data">The data to set the dialog window with</param>
		/// <returns>Returns the data the dialog window returns</returns>
		/// <remarks>Setting the <paramref name="data"/> to null will use the data already set in the <see cref="B3.IDialogWindow.Data"/></remarks>
		public abstract object Prompt(bool interrupt, object data);
		
		#endregion // Public Methods
	}
}

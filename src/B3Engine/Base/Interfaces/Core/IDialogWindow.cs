
namespace B3 {
	/// <summary>An interface for a secondary window that acts somewhat like the primary (game) window but is able to interrupt</summary>
	public interface IDialogWindow : IGameWindow {
		#region Properties
		
		/// <summary>Gets and sets the data of the dialog window</summary>
		object Data { get; set; }
		
		#endregion // Properties
		
		#region Methods
		
		/// <summary>Shows the dialog window with the given data</summary>
		/// <param name="interrupt">Set to true to interrupt the primary windows inputs</param>
		/// <param name="data">The data to set the dialog window with</param>
		/// <returns>Returns the data the dialog window returns</returns>
		/// <remarks>Setting the <paramref name="data"/> to null will use the data already set in the <see cref="B3.IDialogWindow.Data"/></remarks>
		object Prompt(bool interrupt, object data);
		
		#endregion // Methods
	}
}

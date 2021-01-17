
using B3.Events;

namespace B3 {
	/// <summary>An interface for a game window, can be easily changed by platformed</summary>
	public interface IGameWindow : System.IDisposable {
		#region Properties
		
		/// <summary>Gets and sets the title of the window</summary>
		string Title { get; set; }
		
		/// <summary>Gets and sets the position of the window</summary>
		Vector2 Position { get; set; }
		
		/// <summary>Gets and sets the size of the window</summary>
		Vector2 Size { get; set; }
		
		/// <summary>Gets the rectangle boundaries of the window</summary>
		Rectangle Bounds { get; }
		
		/// <summary>Gets and sets if the window is able to be resized</summary>
		bool AllowResize { get; set; }
		
		/// <summary>Gets and sets if the window is able to use Alt + F4 to close the window. This is meant for input purposes</summary>
		bool AllowAltF4 { get; set; }
		
		/// <summary>Gets and sets if the window is borderless</summary>
		bool IsBorderless { get; set; }
		
		/// <summary>Gets and sets the max fps the game can run on</summary>
		int MaxFps { get; set; }
		
		#endregion // Properties
		
		#region Events
		
		/// <summary>An event for when the title of the window is changing</summary>
		event EventHandler<EventArgs> OnTitleChanging;
		
		/// <summary>An event for when the position of the window is changing</summary>
		event EventHandler<EventArgs> OnPositionChanging;
		
		/// <summary>An event for when row size of the window is changing</summary>
		event EventHandler<EventArgs> OnSizeChanging;
		
		/// <summary>An event for when the window has finally loaded</summary>
		event EventHandler<EventArgs> OnLoading;
		
		/// <summary>An event for when the window is closing</summary>
		event EventHandler<EventArgs> OnClosing;
		
		/// <summary>An event for when the window is updating</summary>
		event EventHandler<UpdateEventArgs> OnUpdating;
		
		/// <summary>An event for when the window is rendering</summary>
		event EventHandler<UpdateEventArgs> OnRendering;
		
		#endregion // Events
		
		#region Methods
		
		/// <summary>Runs the window</summary>
		void Run();
		
		/// <summary>Runs the window</summary>
		void Close();
		
		#endregion // Methods
	}
}

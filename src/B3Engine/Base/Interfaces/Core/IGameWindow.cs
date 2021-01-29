
using B3.Events;

using Drawing = System.Drawing;
using IntPtr = System.IntPtr;

namespace B3 {
	/// <summary>An interface for a game window, can be easily changed by platformed</summary>
	public interface IGameWindow : System.IDisposable {
		#region Properties
		
		/// <summary>Gets the managed pointer to the window</summary>
		IntPtr WindowHandle { get; }
		
		/// <summary>Gets the managed pointer to the rendering context</summary>
		IntPtr ContextHandle { get; }
		
		/// <summary>Gets and sets the title of the window</summary>
		string Title { get; set; }
		
		/// <summary>Gets and sets the position of the window</summary>
		Vector2 Position { get; set; }
		
		/// <summary>Gets and sets the size of the window</summary>
		Vector2 Size { get; set; }
		
		/// <summary>Gets the rectangle boundaries of the window</summary>
		Rectangle Bounds { get; }
		
		/// <summary>Gets and sets the mode of the window</summary>
		WindowMode WindowMode { get; set; }
		
		/// <summary>Gets and sets the max fps the game can run on</summary>
		int MaxFps { get; set; }
		
		/// <summary>Gets and sets if the window is able to be resized</summary>
		bool AllowResize { get; set; }
		
		/// <summary>Gets and sets if the window is able to use Alt + F4 to close the window. This is meant for input purposes</summary>
		bool AllowAltF4 { get; set; }
		
		/// <summary>Gets if the game is multi-threaded</summary>
		bool IsMultiThreaded { get; }
		
		/// <summary>Gets if the game is running slowly</summary>
		bool IsRunningSlowly { get; }
		
		/// <summary>Gets if the game window is trying to exit</summary>
		bool IsExiting { get; }
		
		/// <summary>Gets if the game window exists</summary>
		bool Exists { get; }
		
		/// <summary>Gets if the game window is already initialized</summary>
		bool IsInitialized { get; }
		
		/// <summary>Gets and sets the window's icon</summary>
		Drawing.Image Icon { get; set; }
		
		#endregion // Properties
		
		#region Events
		
		/// <summary>An event for when the window has finally loaded</summary>
		event EventHandler<EventArgs> OnLoad;
		
		/// <summary>An event for when the window is closing</summary>
		event EventHandler<EventArgs> OnClose;
		
		/// <summary>An event for when the title of the window is changing</summary>
		event EventHandler<EventArgs> OnTitleChange;
		
		/// <summary>An event for when the position of the window is changing</summary>
		event EventHandler<EventArgs> OnPositionChange;
		
		/// <summary>An event for when row size of the window is changing</summary>
		event EventHandler<EventArgs> OnSizeChange;
		
		/// <summary>An event for when the window is updating</summary>
		event EventHandler<UpdateEventArgs> OnUpdate;
		
		/// <summary>An event for when the window is rendering</summary>
		event EventHandler<UpdateEventArgs> OnRender;
		
		/// <summary>An event for when the window is being destroyed</summary>
		event EventHandler<EventArgs> OnDestroy;
		
		#endregion // Events
		
		#region Methods
		
		/// <summary>Initializes the window</summary>
		void Initialize();
		
		/// <summary>Runs the window</summary>
		/// <param name="maxFps">The maximum frames per second when running. Set it to -1 to not cap the fps</param>
		void Run(int maxFps);
		
		/// <summary>Runs the window</summary>
		void Close();
		
		/// <summary>Swaps the buffers, used to render each frame</summary>
		void SwapBuffers();
		
		/// <summary>Polls or pumps events so that the game loop can continue</summary>
		void PollEvents();
		
		/// <summary>Makes the window's context current</summary>
		/// <param name="shouldMakeCurrent">Set to true to make the context current, set to false to make the context not current</param>
		void MakeContextCurrent(bool shouldMakeCurrent);
		
		#endregion // Methods
	}
}

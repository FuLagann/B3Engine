
using B3.Events;

using System.Diagnostics;
using System.Threading;

using Drawing = System.Drawing;
using IntPtr = System.IntPtr;

namespace B3 {
	/// <summary>An abstract class to set up the game window for any platform</summary>
	public abstract class BaseGameWindow : IGameWindow {
		#region Field Variables
		// Variables
		/// <summary>The bounds of the game window</summary>
		protected Rectangle bounds;
		/// <summary>The title of the game window</summary>
		protected string title;
		/// <summary>The maximum fps of the game window</summary>
		protected int maxFps;
		/// <summary>The managed pointer to the window</summary>
		protected IntPtr window;
		/// <summary>The managed pointer to the rendering context</summary>
		protected IntPtr context;
		private Thread renderThread;
		private Stopwatch renderWatch;
		private Stopwatch updateWatch;
		private float renderFrequency;
		private float updateFrequency;
		private float updateEpsilon;
		private EventArgs args;
		private bool isMultiThreaded;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the managed pointer to the window</summary>
		public IntPtr WindowHandle { get { return this.window; } }
		
		/// <summary>Gets the managed pointer to the rendering context</summary>
		public IntPtr ContextHandle { get { return this.context; } }
		
		/// <summary>Gets and sets the title of the window</summary>
		public virtual string Title { get { return this.title; } set {
			this.title = value;
			this.CallOnTitleChange();
		} }
		
		/// <summary>Gets and sets the position of the window</summary>
		public virtual Vector2 Position { get { return this.bounds.Position; } set {
			this.bounds.Position = value;
			this.CallOnPositionChange();
		} }
		
		/// <summary>Gets and sets the size of the window</summary>
		public virtual Vector2 Size { get { return this.bounds.Size; } set {
			this.bounds.Size = value;
			this.CallOnSizeChange();
		} }
		
		/// <summary>Gets the rectangle boundaries of the window</summary>
		public Rectangle Bounds { get { return this.bounds; } }
		
		/// <summary>Gets and sets the mode of the window</summary>
		public virtual WindowMode WindowMode { get; set; }
		
		/// <summary>Gets and sets the max fps the game can run on</summary>
		public int MaxFps { get { return this.maxFps; } set {
			this.maxFps = Mathx.Max(value, 0);
			this.updateFrequency = this.maxFps;
			this.renderFrequency = this.maxFps;
		} }
		
		/// <summary>Gets and sets if the window is able to be resized</summary>
		public virtual bool AllowResize { get; set; }
		
		/// <summary>Gets and sets if the window is able to use Alt + F4 to close the window. This is meant for input purposes</summary>
		public virtual bool AllowAltF4 { get; set; }
		
		/// <summary>Gets and sets if the game is multi-threaded</summary>
		/// <remarks>Setting only works before running the window</remarks>
		public bool IsMultiThreaded { get { return this.isMultiThreaded; } set {
			if(!this.IsInitialized) {
				this.isMultiThreaded = value;
			}
		} }
		
		/// <summary>Gets if the game is running slowly</summary>
		public bool IsRunningSlowly { get; protected set; }
		
		/// <summary>Gets if the game window is trying to exit</summary>
		public bool IsExiting { get; protected set; }
		
		/// <summary>Gets if the game window exists</summary>
		public bool Exists { get; protected set; }
		
		/// <summary>Gets if the game window has finished initialized</summary>
		public bool IsInitialized { get; protected set; }
		
		/// <summary>Gets and sets the window's icon</summary>
		public virtual Drawing.Image Icon { get; set; }
		
		#endregion // Public Properties
		
		#region Public Events
		
		/// <summary>An event for when the window has finally loaded</summary>
		public event EventHandler<EventArgs> OnLoad;
		
		/// <summary>An event for when the window is closing</summary>
		public event EventHandler<EventArgs> OnClose;
		
		/// <summary>An event for when the title of the window is changing</summary>
		public event EventHandler<EventArgs> OnTitleChange;
		
		/// <summary>An event for when the position of the window is changing</summary>
		public event EventHandler<EventArgs> OnPositionChange;
		
		/// <summary>An event for when row size of the window is changing</summary>
		public event EventHandler<EventArgs> OnSizeChange;
		
		/// <summary>An event for when the window is updating</summary>
		public event EventHandler<UpdateEventArgs> OnUpdate;
		
		/// <summary>An event for when the window is rendering</summary>
		public event EventHandler<UpdateEventArgs> OnRender;
		
		/// <summary>An event for when the window is being destroyed</summary>
		public event EventHandler<EventArgs> OnDestroy;
		
		#endregion // Public Events
		
		#region Protected Constructors
		
		/// <summary>A base protected constructor that sets up the base game window</summary>
		protected BaseGameWindow() {
			this.args = new EventArgs(this);
			this.renderWatch = new Stopwatch();
			this.updateWatch = new Stopwatch();
			this.IsExiting = false;
			this.Exists = true;
			this.IsMultiThreaded = false;
			this.updateEpsilon = 0.0f;
			this.MaxFps = 60;
			this.IsInitialized = false;
			this.Position = new Vector2(100, 100);
			this.Size = new Vector2(800, 640);
			this.Title = "";
		}
		
		#endregion // Protected Constructors
		
		#region Public Methods
		
		/// <summary>Initializes the window</summary>
		public abstract void Initialize();
		
		/// <summary>Swaps the buffers, used to render each frame</summary>
		public abstract void SwapBuffers();
		
		/// <summary>Polls or pumps events so that the game loop can continue</summary>
		public abstract void PollEvents();
		
		/// <summary>Makes the window's context current</summary>
		/// <param name="shouldMakeCurrent">Set to true to make the context current, set to false to make the context not current</param>
		public abstract void MakeContextCurrent(bool shouldMakeCurrent);
		
		/// <summary>Runs the window</summary>
		/// <param name="maxFps">The maximum frames per second when running. Set it to 0 to not cap the fps</param>
		public void Run(int maxFps) {
			this.MaxFps = maxFps;
			Logger.Log("Initializing the Game Window...");
			this.Initialize();
			Logger.Log("Initializing window is done.");
			this.CallOnLoad();
			
			if(this.IsMultiThreaded) {
				this.MakeContextCurrent(false);
				this.renderThread = new Thread(this.RenderThread);
				this.renderThread.Start();
			}
			else { this.MakeContextCurrent(true); }
			
			this.renderWatch.Start();
			this.updateWatch.Start();
			
			while(this.Exists && !this.IsExiting) {
				this.PollEvents();
				Input.ProcessInput();
				this.PostUpdate();
				if(!this.IsMultiThreaded) {
					this.PostRender();
					this.SwapBuffers();
				}
			}
			this.DestroyWindow();
		}
		
		/// <summary>Runs the window</summary>
		public void Close() {
			this.CallOnClose();
			this.IsExiting = true;
		}
		
		/// <summary>Disposes of the window</summary>
		public virtual void Dispose() { this.DestroyWindow(); }
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Destroys the window</summary>
		protected abstract void DestroyWindow();
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnDestroy"/> event for use in the hierarchy</summary>
		protected void CallOnDestroy() { this.OnDestroy?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnLoad"/> event for use in the hierarchy</summary>
		protected void CallOnLoad() { this.OnLoad?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnClose"/> event for use in the hierarchy</summary>
		protected void CallOnClose() { this.OnClose?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnTitleChange"/> event for use in the hierarchy</summary>
		protected void CallOnTitleChange() { this.OnTitleChange?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnPositionChange"/> event for use in the hierarchy</summary>
		protected void CallOnPositionChange() { this.OnPositionChange?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnSizeChange"/> event for use in the hierarchy</summary>
		protected void CallOnSizeChange() { this.OnSizeChange?.Invoke(this.args); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnUpdate"/> event for use in the hierarchy</summary>
		/// <param name="delta">The time between frames to use in the update function</param>
		protected void CallOnUpdate(float delta) { this.OnUpdate?.Invoke(new UpdateEventArgs(this, delta)); }
		
		/// <summary>Calls the <see cref="B3.BaseGameWindow.OnRender"/> event for use in the hierarchy</summary>
		/// <param name="delta">The time between frames to use in the render function</param>
		protected void CallOnRender(float delta) { this.OnRender?.Invoke(new UpdateEventArgs(this, delta)); }
		
		/// <summary>Checks if the window isn't trying to exit, destroys the window if it does</summary>
		/// <returns>Returns true if the window isn't trying to exit</returns>
		protected bool IsNotTryingToExit() {
			if(this.IsExiting) {
				this.DestroyWindow();
				return false;
			}
			return true;
		}
		
		#endregion // Protected Methods
		
		#region Private Methods
		
		/// <summary>The render thread that renders on a seperate thread</summary>
		private void RenderThread() {
			this.MakeContextCurrent(true);
			this.renderWatch.Start();
			while(this.Exists && !this.IsExiting) {
				this.PostRender();
				this.SwapBuffers();
			}
		}
		
		/// <summary>Posts the update from</summary>
		private void PostUpdate() {
			// Variables
			int slowRunRetries = 4;
			float delta = (float)this.updateWatch.Elapsed.TotalSeconds;
			float updatePeriod = (this.updateFrequency == 0.0f ? 0.0f : 1.0f / this.updateFrequency);
			
			while(delta > 0.0f && delta + this.updateEpsilon >= updatePeriod) {
				this.updateWatch.Restart();
				this.CallOnUpdate(delta);
				this.updateEpsilon += delta - updatePeriod;
				if(this.updateFrequency <= Mathx.Epsilon) {
					break;
				}
				this.IsRunningSlowly = (this.updateEpsilon >= updatePeriod);
				if(this.IsRunningSlowly && --slowRunRetries == 0) {
					break;
				}
				delta = (float)this.updateWatch.Elapsed.TotalSeconds;
			}
		}
		
		/// <summary>Posts the render frame</summary>
		private void PostRender() {
			// Variables
			float delta = (float)this.renderWatch.Elapsed.TotalSeconds;
			float renderPeriod = (this.renderFrequency == 0.0f ? 0.0f : 1.0f / this.renderFrequency);
			
			if(delta > 0 && delta >= renderPeriod) {
				this.renderWatch.Restart();
				this.CallOnRender(delta);
			}
		}
		
		#endregion // Private Methods
	}
}

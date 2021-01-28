
using B3.Utilities;

namespace B3 {
	public class SdlGameWindow : BaseGameWindow {
		#region Public Properties
		
		/// <summary>Gets and sets the title of the window</summary>
		public override string Title { set {
			base.Title = value;
			if(this.IsInitialized) {
				SDL.SetWindowTitle(this.window, this.title);
			}
		} }
		
		/// <summary>Gets and sets the position of the window</summary>
		public override Vector2 Position { set {
			base.Position = value;
			if(this.IsInitialized) {
				SDL.SetWindowPosition(this.window, (int)this.Position.x, (int)this.Position.y);
			}
		} }
		
		/// <summary>Gets and sets the size of the window</summary>
		public override Vector2 Size { set {
			base.Size = value;
			if(this.IsInitialized) {
				SDL.SetWindowSize(this.window, (int)this.Size.x, (int)this.Size.y);
			}
		} }
		
		/// <summary>Gets and sets if the window is able to be resized</summary>
		public override bool AllowResize { set {
			base.AllowResize = value;
			if(this.IsInitialized) {
				SDL.SetWindowResizable(this.window, this.AllowResize);
			}
		} }
		
		#endregion // Public Properties
		
		#region Public Methods
		
		/// <summary>Initializes the window</summary>
		public override void Initialize() {
			// Variables
			SDL.WindowFlags flags = SDL.WindowFlags.None;
			
			SdlHelper.Initialize();
			if(!SdlHelper.IsOnMainThread) { throw new System.Exception("Can only create windows on main thread"); }
			flags |= SDL.WindowFlags.Resizable;
			this.AllowResize = true;
			flags |= SDL.WindowFlags.Show;
			flags |= SDL.WindowFlags.OpenGL;
			this.window = SDL.CreateWindow(
				this.title,
				(int)this.Position.x,
				(int)this.Position.y,
				(int)this.Size.x,
				(int)this.Size.y,
				flags
			);
			this.context = SDL.GL_CreateContext(this.window);
			Input.SetProcessor(new SdlInputProcessor());
			this.MakeContextCurrent(true);
			SDL.OnEvent += WindowEventListener;
			this.IsInitialized = true;
		}
		
		/// <summary>Swaps the buffers, used to render each frame</summary>
		public override void SwapBuffers() { SDL.GL_SwapWindow(this.window); }
		
		/// <summary>Polls or pumps events so that the game loop can continue</summary>
		public override void PollEvents() {
			if(!this.IsNotTryingToExit()) { return; }
			SDL.PumpEvents();
		}
		
		/// <summary>Makes the window's context current</summary>
		/// <param name="shouldMakeCurrent">Set to true to make the context current, set to false to make the context not current</param>
		public override void MakeContextCurrent(bool shouldMakeCurrent) {
			if(shouldMakeCurrent) {
				SDL.GL_MakeCurrent(this.window, this.context);
			}
			else {
				SDL.GL_MakeCurrent(System.IntPtr.Zero, System.IntPtr.Zero);
			}
		}
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Destroys the window</summary>
		protected override void DestroyWindow() {
			if(this.Exists) {
				this.Exists = false;
				SDL.DestroyWindow(this.window);
				SDL.GL_DeleteContext(this.context);
			}
		}
		
		#endregion // Protected Methods
		
		#region Private Methods
		
		/// <summary>Called when the SDL events are posted</summary>
		/// <param name="e">The SDL event to get data from</param>
		private void WindowEventListener(SDL.Event e) {
			if(e.type == SDL.EventType.Quit) {
				this.IsExiting = true;
			}
			else if(e.type == SDL.EventType.Window) {
				if(e.window.eventId == SDL.WindowEventId.Close) {
					this.IsExiting = true;
				}
				else if(
					e.window.eventId == SDL.WindowEventId.Resized
					|| e.window.eventId == SDL.WindowEventId.SizeChanged
					|| e.window.eventId == SDL.WindowEventId.Maximized
					|| e.window.eventId == SDL.WindowEventId.Minimized
				) {
					base.Size = new Vector2(e.window.data1, e.window.data2);
				}
				else if(e.window.eventId == SDL.WindowEventId.Moved) {
					base.Position = new Vector2(e.window.data1, e.window.data2);
				}
			}
		}
		
		#endregion // Private Methods
	}
}

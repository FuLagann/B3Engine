
using B3.Events;
using B3.Graphics;

namespace B3 {
	/// <summary>A base class that sets up the central class for the game to use and gather resources from</summary>
	public abstract class BaseGame : IGame {
		#region Field Variables
		// Variables
		private IGameWindow window;
		private bool isInitialized;
		private bool debugMode;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		// /// <summary>Gets the managers that the engine uses</summary>
		// Dictionary<ManagerType, IManager> Managers { get; }
		
		/// <summary>Gets and sets the clearing color of the game</summary>
		/// <remarks>Settings the alpha to 0 will make it so the game doesn't clear the color</remarks>
		public Color ClearColor { get; set; }
		
		/// <summary>Gets if the game is currently loading and unloading assets</summary>
		public bool IsLoadingAssets { get; protected set; }
		
		/// <summary>Gets the window of the game</summary>
		public IGameWindow Window { get { return this.window; } }
		
		/// <summary>Gets and sets if the game is in debug mode</summary>
		public bool DebugMode { get { return this.debugMode; } set {
			this.debugMode = value;
			this.OnDebugModeChangeCall();
		} }
		
		/// <summary>Gets and sets the default shader program that the game uses</summary>
		public IShaderProgram DefaultProgram { get; set; }
		
		/// <summary>Gets if the window has finished initializing</summary>
		public bool IsWindowInitialized { get { return this.window.IsInitialized; } }
		
		/// <summary>Gets if the game has finished initializing</summary>
		public bool IsInitialized { get { return this.IsWindowInitialized && this.isInitialized; } }
		
		#endregion // Public Properties
		
		#region Public Events
		
		/// <summary>An event for when the game is loading</summary>
		public event EventHandler OnLoad;
		
		/// <summary>An event for when the game is rendering</summary>
		public event EventHandler<UpdateEventArgs> OnRender;
		
		/// <summary>An event for when the game is updating</summary>
		public event EventHandler<UpdateEventArgs> OnUpdate;
		
		/// <summary>An event for when the game's debug mode has changed</summary>
		public event EventHandler OnDebugModeChange;
		
		#endregion // Public Events
		
		#region Protected Constructors
		
		/// <summary>A base constructor for the base for the central game class</summary>
		/// <param name="window">The game window for the game to run on</param>
		protected BaseGame(IGameWindow window) {
			this.DebugMode = false;
			this.IsLoadingAssets = false;
			this.window = window;
			this.ClearColor = new Color(0x6AB4E6);
			this.DefaultProgram = null;
			this.isInitialized = false;
			//this.managers = new Dictionary<ManagerType, IManager>();
		}
		
		#endregion // Protected Constructors
		
		#region Public Methods
		
		/// <summary>The callback for setting global uniform variables for shaders</summary>
		/// <param name="program">The program to set uniforms to</param>
		public abstract void GlobalSetUniforms(IShaderProgram program);
		
		/// <summary>Initializes the game</summary>
		public abstract void Initialize();
		
		/// <summary>Updates the object</summary>
		/// <param name="delta">The time elapsed between frames</param>
		public virtual void Update(float delta) {}
		
		/// <summary>Renders the object</summary>
		public void Render() {}
		
		/// <summary>Renders the object when debugging mode is on using a specific shader program</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		/// <param name="program">The shading program used</param>
		public virtual void DebugRender(IGame game, IShaderProgram program) {}
		
		/// <summary>Renders the object when debugging mode is on</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		public void DebugRender(IGame game) { this.DebugRender(this, this.DefaultProgram); }
		
		/// <summary>Runs the game with a set fps</summary>
		/// <param name="fps">The frames per second that the game should be set at</param>
		public virtual void Run(int fps) {
			this.InternalInitialize();
			this.window.Run(fps);
		}
		
		/// <summary>Runs the game</summary>
		public void Run() { this.Run(60); }
		
		/// <summary>Disposes of the game</summary>
		public virtual void Dispose() { this.window.Dispose(); }
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Loads any bindings needed before actual initiations need to happen</summary>
		protected abstract void LoadBindings();
		
		// /// <summary>Initializes all the managers of the game</summary>
		// protected virtual void InitializeManagers() {}
		
		/// <summary>Calls the <see cref="B3.BaseGame.OnLoad"/> event</summary>
		protected virtual void OnLoadCall() { this.OnLoad?.Invoke(); }
		
		/// <summary>Calls the <see cref="B3.BaseGame.OnDebugModeChange"/> event</summary>
		protected virtual void OnDebugModeChangeCall() { this.OnDebugModeChange?.Invoke(); }
		
		/// <summary>Calls the <see cref="B3.BaseGame.OnRender"/> event</summary>
		/// <param name="args">The arguments that hold the time that elapsed between frames</param>
		protected virtual void OnRenderCall(UpdateEventArgs args) { this.OnRender?.Invoke(args); }
		
		/// <summary>Calls the <see cref="B3.BaseGame.OnUpdate"/> event</summary>
		/// <param name="args">The arguments that hold the time that elapsed between frames</param>
		protected virtual void OnUpdateCall(UpdateEventArgs args) {
			Time.SetDeltaTime(args.DeltaTime);
			this.OnUpdate?.Invoke(args);
		}
		
		#endregion // Protected Methods
		
		#region Private Methods
		
		/// <summary>Initializes the game internally</summary>
		private void InternalInitialize() {
			if(this.isInitialized) { return; }
			this.window.OnLoad += this.OnWindowLoad;
			this.window.OnUpdate += this.OnWindowUpdate;
			this.window.OnRender += this.OnWindowRender;
		}
		
		/// <summary>Called when the window is rendering</summary>
		/// <param name="args">The arguments that hold the time that elapsed between frames</param>
		private void OnWindowRender(UpdateEventArgs args) {
			this.Render();
			this.OnRenderCall(args);
		}
		
		/// <summary>Called when the window is updating</summary>
		/// <param name="args">The arguments that hold the time that elapsed between frames</param>
		private void OnWindowUpdate(UpdateEventArgs args) {
			this.Update(args.DeltaTime);
			this.OnUpdateCall(args);
		}
		
		/// <summary>Called when the window is loading</summary>
		/// <param name="args">The arguments passed from the window, this is not used</param>
		private void OnWindowLoad(EventArgs args) {
			this.LoadBindings();
			//this.InitializeManagers();
			this.Initialize();
			this.OnLoadCall();
			this.isInitialized = true;
		}
		
		#endregion // Private Methods
	}
}


using B3.Events;
using B3.Graphics;

using System.Collections.Generic;

namespace B3 {
	/// <summary>An interface for the game, can be easily modified and changed</summary>
	public interface IGame : IUpdatable, IRenderable, IDebugRenderable, System.IDisposable {
		#region Properties
		
		// /// <summary>Gets the managers that the engine uses</summary>
		// Dictionary<ManagerType, IManager> Managers { get; }
		
		/// <summary>Gets and sets the clearing color of the game</summary>
		/// <remarks>Settings the alpha to 0 will make it so the game doesn't clear the color</remarks>
		Color ClearColor { get; set; }
		
		/// <summary>Gets if the game is currently loading and unloading assets</summary>
		bool IsLoadingAssets { get; }
		
		/// <summary>Gets the window of the game</summary>
		IGameWindow Window { get; }
		
		/// <summary>Gets and sets if the game is in debug mode</summary>
		bool DebugMode { get; set; }
		
		/// <summary>Gets and sets the default shader program that the game uses</summary>
		IShaderProgram DefaultProgram { get; set; }
		
		/// <summary>Gets if the window has finished initializing</summary>
		bool IsWindowInitialized { get; }
		
		/// <summary>Gets if the game has finished initializing</summary>
		bool IsInitialized { get; }
		
		#endregion // Properties
		
		#region Events
		
		/// <summary>An event for when the game is loading</summary>
		event EventHandler OnLoad;
		
		/// <summary>An event for when the game is rendering</summary>
		event EventHandler<UpdateEventArgs> OnRender;
		
		/// <summary>An event for when the game is updating</summary>
		event EventHandler<UpdateEventArgs> OnUpdate;
		
		/// <summary>An event for when the game's debug mode has changed</summary>
		event EventHandler OnDebugModeChange;
		
		#endregion // Events
		
		#region Methods
		
		/// <summary>The callback for setting global uniform variables for shaders</summary>
		/// <param name="program">The program to set uniforms to</param>
		void GlobalSetUniforms(IShaderProgram program);
		
		/// <summary>Initializes the game</summary>
		void Initialize();
		
		/// <summary>Runs the game</summary>
		void Run();
		
		/// <summary>Runs the game with a set fps</summary>
		/// <param name="fps">The frames per second that the game should be set at</param>
		void Run(int fps);
		
		#endregion // Methods
	}
}

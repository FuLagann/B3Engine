
using B3.Graphics;

namespace B3 {
	/// <summary>An interface for rendering things only seen while in debug mode</summary>
	public interface IDebugRenderable {
		#region Methods
		
		/// <summary>Renders the object when debugging mode is on</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		void DebugRender(IGame game);
		
		// /// <summary>Renders the object when debugging mode is on using a specific shader program</summary>
		// /// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		// /// <param name="program">The shading program used</param>
		// void DebugRender(IGame game, IShaderProgram program);
		
		#endregion // Methods
	}
}

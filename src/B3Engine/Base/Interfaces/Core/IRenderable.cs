
using B3.Graphics;

namespace B3 {
	/// <summary>An interface for when types are renderable</summary>
	public interface IRenderable {
		#region Methods
		
		/// <summary>Renders the object with no special shading</summary>
		/// <param name="game">The reference to the game, used to get to the RenderingContext</param>
		void Render(IGame game);
		
		/// <summary>Renders the object with a specific shading program</summary>
		/// <param name="program">The shader program used to render the object</param>
		void Render(IShaderProgram program);
		
		#endregion // Methods
	}
}


using B3.Graphics;

using OpenTK.Graphics.OpenGL;

namespace B3 {
	/// <summary>A centralized class that runs the game</summary>
	public class Game : BaseGame {
		#region Public Constructor
		
		/// <summary>A base constructor that sets up the game</summary>
		public Game() : base(new SdlGameWindow()) {
			this.renderer = new OpenGLRenderer(this);
		}
		
		#endregion // Public Constructor
		
		#region Public Methods
		
		/// <summary>The callback for setting global uniform variables for shaders</summary>
		/// <param name="program">The program to set uniforms to</param>
		public override void GlobalSetUniforms(IShaderProgram program) {
			base.GlobalSetUniforms(program);
		}
		
		/// <summary>Initializes the game</summary>
		public override void Initialize() {}
		
		#endregion // Public Methods
		
		#region Protected Methods
		
		/// <summary>Loads any bindings needed before actual initiations need to happen</summary>
		protected override void LoadBindings() { GL.LoadBindings(new SdlBindingContext()); }
		
		#endregion // Protected Methods
	}
}

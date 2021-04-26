
using B3.Graphics;
using B3.Graphics.VertexStructures;

using OpenTK.Graphics.OpenGL;

namespace B3.Testing {
	public sealed class GlslGame : Game {
		#region Field Variables
		// Variables
		private bool[] held;
		private IShaderProgram program;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		public GlslGame() : base() {
			this.Window.Title = "GLSL Testing";
			this.held = new bool[1];
		}

		#endregion // Public Constructors

		#region Public Methods

		public override void Update(float delta) {
			if(Input.IsDown(Keys.One) && !this.held[0]) {
				Logger.Log($"Hello");
				this.held[0] = true;
				// TODO: Fix input
				// TODO: Add empty shader program
			}
			else if(this.held[0] && !Input.IsDown(Keys.One)) {
				this.held[0] = false;
			}
		}

		
		public override void Render() {
			GL.ClearColor(1.0f, 0.0f, 1.0f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			
			this.renderer.Batch(
				new Vector2(0.5f, 0.5f),
				new Vector2(-0.5f, 0.5f),
				new Vector2(-0.5f, -0.5f)
			);
			
			this.renderer.Batch(
				new Vector2(-0.5f, -0.5f),
				new Vector2(0.5f, -0.5f),
				new Vector2(0.5f, 0.5f)
			);
			
			this.renderer.Render();
		}
		
		#endregion // Public Methods
	}
}

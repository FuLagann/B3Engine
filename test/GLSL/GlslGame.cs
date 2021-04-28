
using B3.Graphics;
using B3.Graphics.VertexStructures;

using TK = OpenTK.Graphics.OpenGL;

namespace B3.Testing {
	public sealed class GlslGame : Game {
		#region Field Variables
		// Variables
		private bool[] held;
		private IShaderProgram defaultProgram;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		public GlslGame() : base() {
			this.Window.Title = "GLSL Testing";
			this.held = new bool[1];
		}

		#endregion // Public Constructors

		#region Public Methods

		public override void Initialize() {
			this.defaultProgram = new ShaderProgram(
				this,
				new Shader(this, ShaderType.Vertex, FS.Read(FS.BasePath + "default.vert.glsl")),
				new Shader(this, ShaderType.Fragment, FS.Read(FS.BasePath + "default.frag.glsl"))
			);
		}

		
		public override void Update(float delta) {
			// TODO: Add empty shader program
			if(Input.IsDown(Keys.One) && !this.held[0]) {
				this.held[0] = true;
				this.renderer.MeshShaderProgram = this.defaultProgram;
			}
			else if(this.held[0] && !Input.IsDown(Keys.One)) {
				this.held[0] = false;
			}
		}

		
		public override void Render() {
			TK.GL.ClearColor(1.0f, 0.0f, 1.0f, 1.0f);
			TK.GL.Clear(TK.ClearBufferMask.ColorBufferBit | TK.ClearBufferMask.DepthBufferBit);
			
			this.renderer.Batch(
				new Vector2(1.0f, 1.0f),
				new Vector2(-1.0f, 1.0f),
				new Vector2(-1.0f, -1.0f)
			);
			
			this.renderer.Batch(
				new Vector2(-1.0f, -1.0f),
				new Vector2(1.0f, -1.0f),
				new Vector2(1.0f, 1.0f)
			);
			
			this.renderer.Render();
		}
		
		#endregion // Public Methods
	}
}


using B3.Events;
using B3G = B3.Graphics;
using B3.Utilities;

using OpenTK.Graphics.OpenGL;

using System.Runtime.InteropServices;
using System.IO;
using Drawing = System.Drawing;

namespace B3.Testing {
	public static class Program {
		// Variables
		private static B3G.ShaderProgram program;
		private static B3G.Mesh<B3G.Vertex3PCT> mesh;
		private static B3G.VertexArray<B3G.Vertex3PCT> array;
		private static B3G.FrameBuffer frameBuffer;
		private static B3G.Texture2D texture;
		private static B3G.Texture2D texture2;
		private static B3G.Texture2D texture3;
		private static B3G.Vertex3PCT[] vertices = new B3G.Vertex3PCT[] {
			new B3G.Vertex3PCT(new Vector3(0.5f, 0.5f, 0.0f), Color.Red, new Vector2(1.0f, 0.0f)),
			new B3G.Vertex3PCT(new Vector3(0.5f, -0.5f, 0.0f), Color.Green, new Vector2(1.0f, 1.0f)),
			new B3G.Vertex3PCT(new Vector3(-0.5f, -0.5f, 0.0f), Color.Blue, new Vector2(0.0f, 1.0f)),
			new B3G.Vertex3PCT(new Vector3(-0.5f, 0.5f, 0.0f), Color.Magenta, new Vector2(0.0f, 0.0f))
		};
		private static B3G.Vertex3PCT[] arrayVertices = new B3G.Vertex3PCT[] {
			new B3G.Vertex3PCT(new Vector3(0.0f, 0.8f, 0.0f), Color.Magenta, new Vector2(0.0f, 0.0f)),
			new B3G.Vertex3PCT(new Vector3(0.5f, 0.6f, 0.0f), Color.Yellow, new Vector2(1.0f, 0.0f)),
			new B3G.Vertex3PCT(new Vector3(-0.5f, 0.6f, 0.0f), Color.Yellow, new Vector2(0.5f, 1.0f))
		};
		// private static Vector3[] vertices = new Vector3[] {
		// 	new Vector3(0.5f, 0.5f, 0.0f),
		// 	new Vector3(0.5f, -0.5f, 0.0f),
		// 	new Vector3(-0.5f, -0.5f, 0.0f),
		// 	new Vector3(-0.5f, 0.5f, 0.0f)
		// };
		private static uint[] indices = new uint[] {
			0, 1, 3,
			1, 2, 3
		};
		private static string vertexFile = FS.BasePath + @"basic.vert";
		private static string fragmentFile = FS.BasePath + @"basic.frag";
		private static Game game;
		
		public static void Main(string[] args) {
			game = new Game();
			
			game.Window.Title = "Hello";
			game.OnLoad += Load;
			game.OnRender += Render;
			game.Run();
		}
		
		
		public static void Load() {
			program = new B3G.ShaderProgram(
				null,
				new B3G.Shader(null, B3G.ShaderType.Vertex, FS.Read(vertexFile)),
				new B3G.Shader(null, B3G.ShaderType.Fragment, FS.Read(fragmentFile))
			);
			array = new B3G.VertexArray<B3G.Vertex3PCT>(null, new B3G.VertexBuffer<B3G.Vertex3PCT>(null, arrayVertices, B3G.BufferUsage.StaticDraw));
			array.Bind();
			array.Buffer();
			mesh = new B3G.Mesh<B3G.Vertex3PCT>(
				null,
				new B3G.VertexBuffer<B3G.Vertex3PCT>(null, vertices, B3G.BufferUsage.StaticDraw),
				new B3G.IndexBuffer(null, indices, B3G.BufferUsage.StaticDraw)
			);
			mesh.Bind();
			mesh.Buffer();
			
			texture = new B3G.Texture2D(null, @"https://media.discordapp.net/attachments/692488800823410710/828774678121545738/image0.jpg?width=507&height=676");
			texture2 = new B3G.Texture2D(null, @"https://serebii.net/Banner.jpg");
			texture3 = new B3G.Texture2D(null, "600;800");
			
			program.OnUse += delegate(EventArgs args) {
				// Variables
				B3G.ShaderProgram prog = args.Sender as B3G.ShaderProgram;
				
				prog.SendUniform("uTime", (float)Time.TotalTime.TotalSeconds);
				prog.SendUniform("uCursor", Input.Mouse.Position);
				prog.SendUniform("tex", texture, 0);
				prog.SendUniform("tex2", texture2, 1);
			};
			
			frameBuffer = new B3G.FrameBuffer(game, 0);
			frameBuffer.OnRender += delegate(EventArgs args) {
				program.Use();
				array.Render();
				mesh.Render();
			};
		}
		
		public static void Render(UpdateEventArgs args) {
			game.Renderer.MeshShaderProgram = program;
			game.Renderer.Batch(
				new B3G.Vertex2P(new Vector2(0.5f, 0.5f)),
				new B3G.Vertex2P(new Vector2(-0.5f, 0.5f)),
				new B3G.Vertex2P(new Vector2(-0.5f, -0.5f))
			);
			B3G.Renderer.Instance.Batch(
				new Vector2(-0.5f, -0.5f),
				new Vector2(0.5f, -0.5f),
				new Vector2(0.5f, 0.5f)
			);
			
			B3G.Renderer renderer = B3G.Renderer.Instance;
			
			renderer.Batch(
				new Vector2(-1.0f, 0.7f),
				new Vector2(1.0f, 0.7f),
				new Vector3(0.0f, 0.6f, -0.1f)
			);
			renderer.Batch(
				new Vector3(-0.4f, -0.6f, 0.0f),
				new Vector3(0.4f, -0.6f, 0.0f)
			);
			
			game.Renderer.Render();
		}
	}
	
	public class SdlBindingContext : OpenTK.IBindingsContext {
		public System.IntPtr GetProcAddress(string procName) {
			return SDL.GL_GetProcAddress(procName);
		}
	}
	
	public class Game : BaseGame {
		public Game() : base(new SdlGameWindow()) {
			this.renderer = new B3G.OpenGLRenderer(this);
		}
		
		/// <summary>The callback for setting global uniform variables for shaders</summary>
		/// <param name="program">The program to set uniforms to</param>
		public override void GlobalSetUniforms(B3G.IShaderProgram program) {}
		
		/// <summary>Initializes the game</summary>
		public override void Initialize() {
			GL.ClearColor(this.ClearColor.Redf, this.ClearColor.Greenf, this.ClearColor.Bluef, this.ClearColor.Alphaf);
		}
		
		protected override void LoadBindings() {
			GL.LoadBindings(new SdlBindingContext());
		}
	}
}

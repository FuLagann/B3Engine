
using B3.Events;
using B3G = B3.Graphics;
using B3.Utilities;

using OpenTK.Graphics.OpenGL;

using System.Runtime.InteropServices;

namespace B3.Testing {
	public static class Program {
		// Variables
		private static B3G.ShaderProgram program;
		private static B3G.Mesh<B3G.Vertex3PC> mesh;
		private static B3G.VertexArray<B3G.Vertex3PC> array;
		private static B3G.Vertex3PC[] vertices = new B3G.Vertex3PC[] {
			new B3G.Vertex3PC(new Vector3(0.5f, 0.5f, 0.0f), Color.Red),
			new B3G.Vertex3PC(new Vector3(0.5f, -0.5f, 0.0f), Color.Green),
			new B3G.Vertex3PC(new Vector3(-0.5f, -0.5f, 0.0f), Color.Blue),
			new B3G.Vertex3PC(new Vector3(-0.5f, 0.5f, 0.0f), Color.Magenta)
		};
		private static B3G.Vertex3PC[] arrayVertices = new B3G.Vertex3PC[] {
			new B3G.Vertex3PC(new Vector3(0.0f, 0.8f, 0.0f), Color.Magenta),
			new B3G.Vertex3PC(new Vector3(0.5f, 0.6f, 0.0f), Color.Yellow),
			new B3G.Vertex3PC(new Vector3(-0.5f, 0.6f, 0.0f), Color.Yellow)
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
		private static string vertexCode = @"#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec4 aColor;

out vec4 oColor;

void main()
{
    gl_Position = vec4(aPos.xyz, 1.0);
	oColor = aColor;
}";
		private static string fragmentCode = @"#version 330 core
in vec4 oColor;
out vec4 FragColor;

void main()
{
    FragColor = oColor;
}";
		
		public static void Main(string[] args) {
			Game game = new Game();
			
			game.Window.Title = "Hello";
			game.OnLoad += Load;
			game.OnRender += Render;
			game.Run();
		}
		
		public static void Load(EventArgs args) {
			program = new B3G.ShaderProgram(
				null,
				new B3G.Shader(null, B3G.ShaderType.Vertex, vertexCode),
				new B3G.Shader(null, B3G.ShaderType.Fragment, fragmentCode)
			);
			array = new B3G.VertexArray<B3G.Vertex3PC>(null, new B3G.VertexBuffer<B3G.Vertex3PC>(null, arrayVertices, B3G.BufferUsage.StaticDraw));
			array.Bind();
			array.Buffer();
			mesh = new B3G.Mesh<B3G.Vertex3PC>(
				null,
				new B3G.VertexBuffer<B3G.Vertex3PC>(null, vertices, B3G.BufferUsage.StaticDraw),
				new B3G.IndexBuffer(null, indices, B3G.BufferUsage.StaticDraw)
			);
			mesh.Bind();
			mesh.Buffer();
		}
		
		public static void Render(UpdateEventArgs args) {
			GL.ClearColor(0.05f, 0.15f, 0.1f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			
			array.Render(program);
			mesh.Render(program);
		}
	}
	
	public class SdlBindingContext : OpenTK.IBindingsContext {
		public System.IntPtr GetProcAddress(string procName) {
			return SDL.GL_GetProcAddress(procName);
		}
	}
	
	public class Game : BaseGame {
		
		public Game() : base(new SdlGameWindow()) {}
		
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

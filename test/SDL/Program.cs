
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
		private static string vertexCode = @"#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec4 aColor;
layout (location = 2) in vec2 aTexCoord;

out vec4 oColor;
out vec2 oTexCoord;

void main()
{
    gl_Position = vec4(aPos.xyz, 1.0);
	oColor = aColor;
	oTexCoord = aTexCoord;
}";
		private static string fragmentCode = @"#version 330 core
in vec4 oColor;
in vec2 oTexCoord;
out vec4 FragColor;

uniform sampler2D tex;
uniform float uTime;

void main()
{
    FragColor = oColor * max(abs(sin(uTime)), abs(cos(uTime))) * texture(tex, oTexCoord);
}";
		
		public static void Main(string[] args) {
			Game game = new Game();
			
			game.Window.Title = "Hello";
			game.OnLoad += Load;
			game.OnRender += Render;
			game.Run();
		}
		
		private static int texture;
		
		public static void Load(EventArgs args) {
			program = new B3G.ShaderProgram(
				null,
				new B3G.Shader(null, B3G.ShaderType.Vertex, vertexCode),
				new B3G.Shader(null, B3G.ShaderType.Fragment, fragmentCode)
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
			texture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, texture);
			using(Stream stream = FS.ReadStream(@"https://media.discordapp.net/attachments/692488800823410710/828774678121545738/image0.jpg?width=507&height=676")) {
				Drawing.Bitmap bmp = Drawing.Bitmap.FromStream(stream) as Drawing.Bitmap;
				System.Drawing.Imaging.BitmapData data = bmp.LockBits(
					new Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
					Drawing.Imaging.ImageLockMode.ReadOnly,
					Drawing.Imaging.PixelFormat.Format32bppArgb
				);
				
				GL.TexImage2D(
					TextureTarget.Texture2D,
					0,
					PixelInternalFormat.Rgba,
					bmp.Width,
					bmp.Height,
					0,
					PixelFormat.Rgba,
					PixelType.UnsignedByte,
					data.Scan0
				);
				bmp.UnlockBits(data);
				GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
			}
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
			
			program.OnUse += delegate(EventArgs args) {
				// Variables
				B3G.ShaderProgram prog = args.Sender as B3G.ShaderProgram;
				
				prog.SendUniform("uTime", (float)Time.TotalTime.TotalSeconds);
				prog.SendUniform("uCursor", Input.Mouse.Position);
				GL.BindTexture(TextureTarget.Texture2D, texture);
			};
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

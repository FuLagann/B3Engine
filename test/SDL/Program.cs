
using B3.Events;
using B3G = B3.Graphics;
using B3.Utilities;

using OpenTK.Graphics.OpenGL;

using System.Runtime.InteropServices;

namespace B3.Testing {
	public static class Program {
		// Variables
		private static IGameWindow window;
		private static System.IntPtr joystick;
		private static bool held;
		private static int id = -1;
		private static int fragid;
		private static int vertid;
		private static int progid;
		private static int bufferid;
		private static int indexid;
		private static int arrayid;
		private static Vector3[] vertices = new Vector3[] {
			new Vector3(0.5f, 0.5f, 0.0f),
			new Vector3(0.5f, -0.5f, 0.0f),
			new Vector3(-0.5f, -0.5f, 0.0f),
			new Vector3(-0.5f, 0.5f, 0.0f)
		};
		private static uint[] indices = new uint[] {
			0, 1, 3,
			1, 2, 3
		};
		private static string vertexCode = @"#version 330 core
layout (location = 0) in vec3 aPos;

void main()
{
    gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);
}";
		private static string fragmentCode = @"#version 330 core
out vec4 FragColor;

void main()
{
    FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);
}";
		
		public static void Main(string[] args) {
			Game game = new Game();
			
			game.Window.Title = "Hello";
			game.Run();
			// Program.window = new SdlGameWindow();
			
			// Program.window.OnRender += Render;
			// Program.window.OnUpdate += Update;
			// Program.window.OnLoad += Load;
			// Program.window.OnDestroy += Destroy;
			// Program.window.Title = "Testing";
			// Program.held = false;
			// Program.window.Icon = System.Drawing.Image.FromStream(FS.ReadStream(@"https://www.telegraph.co.uk/content/dam/technology/2021/01/28/Screenshot-2021-01-28-at-13-20-35_trans_NvBQzQNjv4BqEGKV9LrAqQtLUTT1Z0gJNRFI0o2dlzyIcL3Nvd0Rwgc.png?imwidth=450"));
			
			// Program.window.Run(60);
		}
		
		public static void Destroy(EventArgs args) {
			SDL.ShowCursor(true);
			SDL.SetWindowBrightness(Program.window.WindowHandle, 1f);
			SDL.JoystickClose(Program.joystick);
		}
		
		public static void Load(EventArgs args) {
			Logger.Log("Loading in the bindings!");
			GL.LoadBindings(new SdlBindingContext());
			Program.joystick = SDL.JoystickOpen(1);
			
			// Shaders
			vertid = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vertid, vertexCode);
			GL.CompileShader(vertid);
			Logger.Log(GL.GetShaderInfoLog(vertid));
			
			fragid = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(fragid, fragmentCode);
			GL.CompileShader(fragid);
			Logger.Log(GL.GetShaderInfoLog(fragid));
			
			progid = GL.CreateProgram();
			GL.AttachShader(progid, vertid);
			GL.AttachShader(progid, fragid);
			GL.LinkProgram(progid);
			GL.DeleteShader(fragid);
			GL.DeleteShader(vertid);
			
			// Buffers
			/*
			bufferid = GL.GenBuffer();
			arrayid = GL.GenVertexArray();
			GL.BindVertexArray(arrayid);
			GL.BindBuffer(BufferTarget.ArrayBuffer, bufferid);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * Marshal.SizeOf<Vector3>(), vertices, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Marshal.SizeOf<Vector3>(), System.IntPtr.Zero);
			GL.EnableVertexAttribArray(0);
			*/
			bufferid = GL.GenBuffer();
			indexid = GL.GenBuffer();
			arrayid = GL.GenVertexArray();
			GL.BindVertexArray(arrayid);
			GL.BindBuffer(BufferTarget.ArrayBuffer, bufferid);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * Marshal.SizeOf<Vector3>(), vertices, BufferUsageHint.StaticDraw);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexid);
			GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Marshal.SizeOf<Vector3>(), System.IntPtr.Zero);
			GL.EnableVertexAttribArray(0);
		}
		
		public static void Update(UpdateEventArgs args) {
			if(id >= 0) {
				Vector2 dir = Input.Gamepads[id].Triggers;
				
				if(dir != Vector2.Zero) {
					Logger.Log(dir);
				}
			}
			else {
				id = Input.GetGamepadIdFromButtons(GamepadButton.LeftShoulder, GamepadButton.RightShoulder);
				if(id != -1) {
					Logger.Log("Player 1 Connected!");
				}
			}
			if(Input.IsDown(GamepadButton.A)) {
				Logger.Log("AS");
			}
			if(!Program.held && Input.IsDown(Keys.P)) {
				Program.held = true;
			}
			else if(Program.held && Input.IsUp(Keys.P)) {
				Program.held = false;
			}
		}
		
		public static void Render(UpdateEventArgs args) {
			GL.ClearColor(0.05f, 0.15f, 0.1f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			
			/*
			GL.UseProgram(progid);
			GL.BindVertexArray(arrayid);
			GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
			*/
			GL.UseProgram(progid);
			GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
			GL.BindVertexArray(arrayid);
			GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, System.IntPtr.Zero);
			GL.BindVertexArray(0);
			GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
		}
	}
	
	public class SdlBindingContext : OpenTK.IBindingsContext {
		public System.IntPtr GetProcAddress(string procName) {
			return SDL.GL_GetProcAddress(procName);
		}
	}
	
	public class Game : BaseGame {
		
		public Game() : base(new SdlGameWindow()) {
			
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

		public override void Render(B3G.IShaderProgram program) {
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.Begin(PrimitiveType.Triangles);
			{
				float sin = 0.5f + 0.5f * Mathx.Sin((float)Time.TotalTime.TotalSeconds);
				float cos = 0.5f + 0.5f * Mathx.Cos((float)Time.TotalTime.TotalSeconds);
				GL.Color4(cos, sin, cos, 1.0f);
				GL.Vertex2(0.5f, 0.5f);
				GL.Vertex2(0.5f, -0.5f);
				GL.Vertex2(-0.5f, -0.5f);
			}
			GL.End();
		}

		
	}
}

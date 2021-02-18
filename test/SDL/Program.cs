
using B3.Events;
using B3.Utilities;

using OpenTK.Graphics.OpenGL;

namespace B3.Testing {
	public static class Program {
		// Variables
		private static IGameWindow window;
		private static System.IntPtr joystick;
		private static bool held;
		private static int id = -1;
		
		public static void Main(string[] args) {
			Program.window = new SdlGameWindow();
			
			Program.window.OnRender += Render;
			Program.window.OnUpdate += Update;
			Program.window.OnLoad += Load;
			Program.window.OnDestroy += Destroy;
			Program.window.Title = "Testing";
			Program.held = false;
			Program.window.Icon = System.Drawing.Image.FromStream(FS.ReadStream(@"https://www.telegraph.co.uk/content/dam/technology/2021/01/28/Screenshot-2021-01-28-at-13-20-35_trans_NvBQzQNjv4BqEGKV9LrAqQtLUTT1Z0gJNRFI0o2dlzyIcL3Nvd0Rwgc.png?imwidth=450"));
			
			Program.window.Run(60);
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
			GL.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			
			GL.Begin(PrimitiveType.Triangles);
			{
				GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
				GL.Vertex3(0.5f, 0.0f, 0.0f);
				GL.Vertex3(-0.5f, 0.5f, 0.0f);
				GL.Vertex3(-0.5f, 0.0f, 0.0f);
			}
			GL.End();
		}
	}
	
	public class SdlBindingContext : OpenTK.IBindingsContext {
		public System.IntPtr GetProcAddress(string procName) {
			return SDL.GL_GetProcAddress(procName);
		}
	}
}

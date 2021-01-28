
using B3.Events;
using B3.Utilities;

using OpenTK.Graphics.OpenGL;

namespace B3.Testing {
	public static class Program {
		// Variables
		private static IGameWindow window;
		
		public static void Main(string[] args) {
			Program.window = new SdlGameWindow();
			
			Program.window.OnRender += Render;
			Program.window.OnLoad += Load;
			Program.window.Title = "Testing";
			
			Program.window.Run(60);
		}
		
		public static void Load(EventArgs args) {
			Logger.Log("Loading in the bindings!");
			GL.LoadBindings(new SdlBindingContext());
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


using B3.Utilities;

using System.Collections.Generic;

namespace B3.Testing {
	public static class Program {
		public static void Main(string[] args) {
			// Variables
			SDL.WindowFlags flags = SDL.WindowFlags.Show;
			bool canQuit = false;
			int num;
			System.IntPtr joystick;
			
			SDL.Init(SDL.InitFlags.Video | SDL.InitFlags.Joystick | SDL.InitFlags.GameController);
			SDL.CreateWindow("Hello World", 200, 120, 500, 500, flags);
			
			num = SDL.NumJoysticks();
			
			for(int i = 0; i < num; i++) {
				SDL.JoystickOpen(i);
			}
			
			joystick = SDL.JoystickFromInstanceId(0);
			Logger.Log(joystick);
			
			SDL.OnEvent += delegate(SDL.Event e) {
				if(e.type == SDL.EventType.JoyAxisMotion) {
					if(e.joystickAxis.axis == 0 && e.joystickAxis.value > 30000) {
						
					}
				}
				if(e.type == SDL.EventType.Quit) {
					canQuit = true;
				}
			};
			
			Logger.Log(SDL.GetVersion());
			
			while(!canQuit) {
				SDL.PumpEvents();
			}
		}
	}
}

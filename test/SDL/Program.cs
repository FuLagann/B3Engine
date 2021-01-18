
using B3.Utilities;

using System.Collections.Generic;

namespace B3.Testing {
	public static class Program {
		public static void Main(string[] args) {
			// Variables
			SDL.WindowFlags flags = SDL.WindowFlags.Show;
			bool canQuit = false;
			
			Input.SetProcessor(new SdlInputProcessor());
			SDL.Init(SDL.InitFlags.Everything);
			SDL.CreateWindow("Hello World", 200, 120, 500, 500, flags);
			
			System.IntPtr joystick = SDL.JoystickOpen(0);
			Logger.Log(SDL.NumHaptic());
			
			System.IntPtr haptic = SDL.HapticOpen(0);
			SDL.HapticEffect hapticEffect = new SDL.HapticEffect();
			
			hapticEffect.type = (ushort)(1u<<0);
			hapticEffect.constant.type = 0;
			hapticEffect.constant.direction.type = SDL.HapticDirectionType.Polar;
			hapticEffect.constant.length = 1000;
			hapticEffect.constant.delay = 500;
			hapticEffect.constant.button = 0;
			hapticEffect.constant.interval = 1000;
			hapticEffect.constant.level = 100;
			hapticEffect.constant.attackLength = 1000;
			hapticEffect.constant.attackLevel = 50;
			hapticEffect.constant.fadeLength = 200;
			hapticEffect.constant.fadeLevel = 30;
			
			int effect = SDL.HapticNewEffect(haptic, hapticEffect);
			
			SDL.OnEvent += delegate(SDL.Event e) {
				if(e.type == SDL.EventType.JoystickButtonDown) {
					Logger.Log($"{e.joystickButton.Button}");
				}
				if(e.type == SDL.EventType.Quit) {
					canQuit = true;
				}
			};
			
			bool hold = false;
			
			Logger.Log(SDL.GetVersion());
			
			while(!canQuit) {
				SDL.PumpEvents();
				Update();
				if(!hold && Input.IsDown(GamepadButton.A)) {
					hold = true;
					SDL.HapticRunEffect(haptic, effect, 4);
				}
				else if(hold && Input.IsUp(GamepadButton.A)) {
					hold = false;
				}
			}
		}
		
		public static void Update() {
			Input.ProcessInput();
		}
	}
}

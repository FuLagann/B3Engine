
using B3.Utilities;

namespace B3.Testing {
	public static class Program {
		public static void Main(string[] args) {
			// Variables
			SDL.WindowFlags flags = SDL.WindowFlags.Show;
			
			SDL.Init(SDL.InitFlags.Video);
			SDL.CreateWindow("Hello World", 200, 120, 500, 100, flags);
			
			Logger.Log(SDL.GetVersion());
			
			while(true) {
				// Variables
				SDL.Event e = SDL.PollEvent();
				
				if(e.type == SDL.EventType.Quit) {
					break;
				}
			}
		}
	}
}

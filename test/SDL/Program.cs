
using B3;

namespace B3.Testing {
	public class Program : Game {
		// Variables
		private int state;
		
		public static void Main(string[] args) {
			// Variables
			Program program = new Program();
			
			program.Window.Title = "SDL Testing";
			
			program.Run();
		}
		
		public override void Initialize() {
			InputMapping.LoadMappingFromXml("res://InputMapping.xml");
			this.SetState(0);
		}
		
		public override void Update(float delta) {
			if(Input.IsPressed(Keys.One)) { this.SetState(0); }
			else if(Input.IsPressed(Keys.Two)) { this.SetState(1); }
			else if(Input.IsPressed(Keys.Three)) { this.SetState(2); }
			else if(Input.IsPressed(Keys.Four)) { this.SetState(3); }
			else if(Input.IsPressed(Keys.Five)) { this.SetState(4); }
			else if(Input.IsPressed(Keys.Six)) { this.SetState(5); }
			// else if(Input.IsPressed(Keys.Seven)) { this.SetState(7); }
			// else if(Input.IsPressed(Keys.Eight)) { this.SetState(8); }
			// else if(Input.IsPressed(Keys.Nine)) { this.SetState(9); }
			// else if(Input.IsPressed(Keys.Zero)) { this.SetState(0); }
			
			if(state == 0) {
				this.Window.Title = $"Gamepad Left Stick; x: {Input.GetAxis("horizontal")}, y: {Input.GetAxis("vertical")}";
				this.ClearColor = new Color(
					(Input.GetAxis("horizontal") + 1.0f) / 2.0f,
					(Input.GetAxis("vertical") + 1.0f) / 2.0f,
					0.0f
				);
			}
			else if(state == 1) {
				this.Window.Title = $"Gamepad Right Stick; x: {Input.GetAxis("camera-horizontal")}, y: {Input.GetAxis("camera-vertical")}";
				this.ClearColor = new Color(
					(Input.GetAxis("camera-horizontal") + 1.0f) / 2.0f,
					(Input.GetAxis("camera-vertical") + 1.0f) / 2.0f,
					0.0f
				);
			}
			else if(state == 2) {
				if(Input.Gamepad.PreviousButtons.Length > 0) {
					this.Window.Title = $"Gamepad Button; Button: {Input.Gamepad.PreviousButtons[Input.Gamepad.PreviousButtons.Length - 1]}";
				}
				else {
					this.Window.Title = "Gamepad Button...";
				}
			}
			else if(state == 3) {
				this.Window.Title = $"Mouse Movement; s: {Input.Mouse.Scroll}; x: {Input.Mouse.Movement.x}, y: {Input.Mouse.Movement.y}; px: {Input.Mouse.Position.x}, py: {Input.Mouse.Position.y}";
				this.ClearColor = new Color(
					Mathx.Clamp(Input.Mouse.Position.x / this.Window.Size.x, 0.0f, 1.0f),
					Mathx.Clamp(Input.Mouse.Position.y / this.Window.Size.y, 0.0f, 1.0f),
					0.0f
				);
			}
			else if(state == 4) {
				if(Input.Mouse.PreviousButtons.Length > 0) {
					this.Window.Title = $"Mouse Button; Butotn: {Input.Mouse.PreviousButtons[Input.Mouse.PreviousButtons.Length - 1]}";
				}
				else {
					this.Window.Title = "Mouse Button...";
				}
			}
			else if(state == 5) {
				if(Input.Keyboard.PreviousKeys.Length > 0) {
					this.Window.Title = $"Keyboard Key; Key: {Input.Keyboard.PreviousKeys[Input.Keyboard.PreviousKeys.Length - 1]}";
				}
				else {
					this.Window.Title = "Keyboard Key...";
				}
			}
		}
		
		private void SetState(int state) {
			this.state = state;
			switch(this.state) {
				case 0: {
					Logger.Log("Tracking left stick movement.");
					this.OpenHelpMenu();
				} break;
				case 1: {
					Logger.Log("Tracking right stick movement.");
					this.OpenHelpMenu();
				} break;
				case 2: {
					Logger.Log("Tracking gamepad input.");
					this.OpenHelpMenu();
				} break;
				case 3: {
					Logger.Log("Tracking mouse movement.");
					this.OpenHelpMenu();
				} break;
				case 4: {
					Logger.Log("Tracking mouse input.");
					this.OpenHelpMenu();
				} break;
				case 5: {
					Logger.Log("Tracking keyboard input.");
					this.OpenHelpMenu();
				} break;
			}
		}
		
		private void OpenHelpMenu() {
			Logger.Log("Press (1) to track gamepad left stick");
			Logger.Log("Press (2) to track gamepad right stick");
			Logger.Log("Press (3) to track any gamepad input");
			Logger.Log("Press (4) to track mouse movement");
			Logger.Log("Press (5) to track any mouse input");
			Logger.Log("Press (6) to track any keyboard input");
		}
	}
}

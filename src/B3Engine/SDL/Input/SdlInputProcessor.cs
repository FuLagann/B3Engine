
using System.Collections.Generic;

namespace B3.Utilities {
	/// <summary>The input processor for SDL</summary>
	public class SdlInputProcessor : IInputProcessor {
		#region Field Variables
		// Variables
		private Vector2 mousePos;
		private float mouseWheel;
		private bool shouldConnectController;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor that sets up the input processor</summary>
		public SdlInputProcessor() {
			this.mousePos = Vector2.Zero;
			this.mouseWheel = 0.0f;
			this.shouldConnectController = true;
			
			SDL.OnEvent += this.InputEventsCallback;
		}
		
		/// <summary>A base destructor that takes out the input event callback</summary>
		~SdlInputProcessor() { SDL.OnEvent -= this.InputEventsCallback; }
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Processes the input for later use</summary>
		/// <param name="keyboard">The reference to the keyboard's input structure</param>
		/// <param name="mouse">The reference to the mouse's input structure</param>
		/// <param name="generalGamepad">The reference to the general gamepad</param>
		/// <param name="gamepads">The reference to an array of gamepad's input structure</param>
		public void ProcessInput(ref KeyboardState keyboard, ref MouseState mouse, ref GamepadState generalGamepad, ref GamepadState[] gamepads) {
			// Variables
			InputState[] state = SDL.GetKeyboardState();
			bool pressed = false;
			short axis = 0;
			float normedAxis = 0.0f;
			
			for(int i = 0; i < state.Length; i++) {
				// TODO: This makes the keyboard input release, change this to events
				keyboard[(Keys)i] = state[i];
			}
			keyboard.CheckForClearing();
			
			state = SDL.GetMouseState(out this.mousePos.x, out this.mousePos.y);
			mouse.Position = this.mousePos;
			mouse.Scroll = this.mouseWheel;
			this.mouseWheel = 0.0f;
			for(int i = 0; i < state.Length; i++) {
				mouse[(MouseButton)i] = state[i];
			}
			mouse.CheckForClearing();
			
			if(this.shouldConnectController) {
				// Variables
				List<System.IntPtr> joysticks = this.ConnectControllers();
				
				gamepads = new GamepadState[joysticks.Count];
				for(int i = 0; i < gamepads.Length; i++) {
					gamepads[i] = new GamepadState(joysticks[i], 10, true);
				}
				this.shouldConnectController = false;
			}
			
			for(int a = 0; a < gamepads.Length; a++) {
				for(int b = 0; b < gamepads[a].NumButtons; b++) {
					pressed = SDL.JoystickGetButton(gamepads[a].Handle, b);
					gamepads[a][(GamepadButton)b] = pressed ? InputState.Pressed : InputState.Released;
					generalGamepad[(GamepadButton)b] = pressed ? InputState.Pressed : InputState.Released;
				}
				for(int b = 0; b < gamepads[a].NumAxes; b++) {
					axis = SDL.JoystickGetAxis(gamepads[a].Handle, b);
					normedAxis = Mathx.Clamp((float)axis / (float)short.MaxValue, -1.0f, 1.0f);
					if((GamepadAxis)b == GamepadAxis.TriggerLeft || (GamepadAxis)b == GamepadAxis.TriggerRight) {
						if(axis != 0) {
							normedAxis = Mathx.MapRange(normedAxis, -1.0f, 1.0f, 0.0f, 1.0f);
						}
					}
					gamepads[a][(GamepadAxis)b] = normedAxis;
					if(a == 0 || (Mathx.Abs(normedAxis) >= generalGamepad.DeadZone && Mathx.Abs(generalGamepad[(GamepadAxis)b]) < Mathx.Abs(normedAxis))) {
						generalGamepad[(GamepadAxis)b] = normedAxis;
					}
				}
				gamepads[a].CheckForClearing();
			}
			generalGamepad.CheckForClearing();
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Connects all the controllers currently available</summary>
		/// <returns>Returns the list of managed pointers to the gamepad joysticks</returns>
		private List<System.IntPtr> ConnectControllers() {
			// Variables
			int num = SDL.NumJoysticks();
			List<System.IntPtr> joysticks = new List<System.IntPtr>();
			
			for(int i = 0; i < num; i++) {
				if(SDL.IsGamepad(i)) {
					joysticks.Add(SDL.JoystickOpen(i));
				}
			}
			
			return joysticks;
		}
		
		/// <summary>The callback to the SDL events to process the input with</summary>
		/// <param name="e">The event to get all the data from</param>
		private void InputEventsCallback(SDL.Event e) {
			if(e.type == SDL.EventType.MouseWheel) {
				this.mouseWheel += e.mouseWheel.y;
			}
		}
		
		#endregion // Private Methods
	}
}

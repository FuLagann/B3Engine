
using System.Collections.Generic;

namespace B3.Utilities {
	/// <summary>The input processor for SDL</summary>
	public class SdlInputProcessor : IInputProcessor {
		#region Field Variables
		// Variables
		private Queue<Keys> keys;
		private Queue<Keys> keysUp;
		private Queue<MouseButtonAndClicks> mbuttons;
		private Queue<MouseButtonAndClicks> mbuttonsUp;
		private Queue<GamepadButtonAndId> gbuttons;
		private Queue<GamepadButtonAndId> gbuttonsUp;
		private Queue<GamepadAxisIdAndValue> gaxes;
		private Vector2 mousePos;
		private float mouseWheel;
		private bool shouldConnectController;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor that sets up the input processor</summary>
		public SdlInputProcessor() {
			this.keys = new Queue<Keys>();
			this.keysUp = new Queue<Keys>();
			this.mbuttons = new Queue<MouseButtonAndClicks>();
			this.mbuttonsUp = new Queue<MouseButtonAndClicks>();
			this.gbuttons = new Queue<GamepadButtonAndId>();
			this.gbuttonsUp = new Queue<GamepadButtonAndId>();
			this.gaxes = new Queue<GamepadAxisIdAndValue>();
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
			GamepadButtonAndId gbutton;
			GamepadAxisIdAndValue gaxis;
			bool shouldCheck = false;
			
			for(int i = 0; i < state.Length; i++) {
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
			
			while(this.gbuttonsUp.Count > 0) {
				gbutton = this.gbuttonsUp.Dequeue();
				gamepads[gbutton.id][gbutton.button] = InputState.Released;
				generalGamepad[gbutton.button] = InputState.Released;
				shouldCheck = true;
			}
			if(shouldCheck) {
				for(int i = 0; i < gamepads.Length; i++) {
					gamepads[i].CheckForClearing();
				}
				generalGamepad.CheckForClearing();
			}
			while(this.gbuttons.Count > 0) {
				gbutton = this.gbuttons.Dequeue();
				gamepads[gbutton.id][gbutton.button] = InputState.Pressed;
				gamepads[gbutton.id].IsAnyButtonDown = true;
				generalGamepad[gbutton.button] = InputState.Pressed;
				generalGamepad.IsAnyButtonDown = true;
			}
			while(this.gaxes.Count > 0) {
				gaxis = this.gaxes.Dequeue();
				gamepads[gaxis.id][gaxis.axis] = gaxis.value;
				generalGamepad[gaxis.axis] = gaxis.value;
			}
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
			
			// TODO: The OnUp events sometimes get skipped, maybe the event style system shouldnt be used and this should be reoriganized to call the sdl methods directly
			
			if(e.type == SDL.EventType.MouseMotion) {
				this.mousePos.x = e.mouse.x;
				this.mousePos.y = e.mouse.y;
			}
			if(e.type == SDL.EventType.MouseWheel) {
				this.mouseWheel += e.mouseWheel.y;
			}
			if(e.type == SDL.EventType.MouseButtonDown) {
				// Variables
				MouseButton button = e.mouseButton.Button;
				int clicks = e.mouseButton.clicks;
				
				if(button != MouseButton.Unknown) { this.mbuttons.Enqueue(new MouseButtonAndClicks(button, clicks)); }
			}
			if(e.type == SDL.EventType.MouseButtonUp) {
				// Variables
				MouseButton button = e.mouseButton.Button;
				int clicks = e.mouseButton.clicks;
				
				if(button != MouseButton.Unknown) { this.mbuttons.Enqueue(new MouseButtonAndClicks(button, clicks)); }
			}
			if(e.type == SDL.EventType.JoystickButtonDown) {
				// Variables
				GamepadButton button = e.joystickButton.Button;
				int index = e.joystickButton.which;
				
				if(button != GamepadButton.Unknown) { this.gbuttons.Enqueue(new GamepadButtonAndId(button, index)); }
			}
			if(e.type == SDL.EventType.JoystickButtonUp) {
				// Variables
				GamepadButton button = e.joystickButton.Button;
				int index = e.joystickButton.which;
				
				if(button != GamepadButton.Unknown) { this.gbuttonsUp.Enqueue(new GamepadButtonAndId(button, index)); }
			}
			if(e.type == SDL.EventType.JoystickAxisMotion) {
				// Variables
				GamepadAxis axis = e.joystickAxis.Axis;
				int index = e.joystickAxis.which;
				float value = e.joystickAxis.FloatValue;
				
				if(axis != GamepadAxis.Unknown) { this.gaxes.Enqueue(new GamepadAxisIdAndValue(axis, index, value)); }
			}
		}
		
		#endregion // Private Methods
		
		#region Private Nested Objects
		
		/// <summary>A class to hold the data for the game controller button and it's index to the game controller</summary>
		private class GamepadButtonAndId {
			#region Field Variables
			// Variables
			/// <summary>The gamepad button to keep track of</summary>
			public GamepadButton button;
			/// <summary>The id of the gamepad to keep track of</summary>
			public int id;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			/// <summary>A base constructors that holds the button and id of the game controller</summary>
			/// <param name="button">The button that is being pressed down or not</param>
			/// <param name="id">The index of the game controller</param>
			public GamepadButtonAndId(GamepadButton button, int id) {
				this.button = button;
				this.id = id;
			}
			
			#endregion // Public Constructors
		}
		
		/// <summary>A class to hold the data for the game controller axis and it's index</summary>
		private class GamepadAxisIdAndValue {
			#region Field Variables
			// Variables
			/// <summary>The axis of the gamepad</summary>
			public GamepadAxis axis;
			/// <summary>The index of the gamepad</summary>
			public int id;
			/// <summary>The direction of the axis</summary>
			public float value;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			/// <summary>A base constructor that holds the axis, index of the controller, and the direction of the axis</summary>
			/// <param name="axis">The axis of the controller</param>
			/// <param name="id">The index of the controller</param>
			/// <param name="value">The value of the axis</param>
			public GamepadAxisIdAndValue(GamepadAxis axis, int id, float value) {
				this.axis = axis;
				this.id = id;
				this.value = value;
			}
			
			#endregion // Public Constructors
		}
		
		/// <summary>A class to hold the data for the mouse button and the amount of clicks done</summary>
		private class MouseButtonAndClicks {
			#region Field Variables
			// Variables
			/// <summary>The button of the mouse that was clicked</summary>
			public MouseButton button;
			/// <summary>The amount of clicks of the button</summary>
			public int clicks;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			/// <summary>A base constructors that holds the button and amount of clicks of the mouse</summary>
			/// <param name="button">The button that is being pressed down or not</param>
			/// <param name="clicks">The amount of clicks of the button</param>
			public MouseButtonAndClicks(MouseButton button, int clicks) {
				this.button = button;
				this.clicks = clicks;
			}
			
			#endregion // Public Constructors
		}
		
		#endregion // Private Nested Objects
	}
}

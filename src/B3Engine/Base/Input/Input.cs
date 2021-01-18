
namespace B3 {
	/// <summary>A class that holds all the input information from the user</summary>
	public class Input {
		#region Field Variables
		// Variables
		private static IInputProcessor processor;
		private static KeyboardState keyboard;
		private static MouseState mouse;
		private static GamepadState gamepad;
		private static GamepadState[] gamepads;
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets the keyboard input</summary>
		public static KeyboardState Keyboard { get { return keyboard; } }
		
		/// <summary>Gets the mouse input</summary>
		public static MouseState Mouse { get { return mouse; } }
		
		/// <summary>Gets the general gamepad (everyone's input gets placed into a single gamepad)</summary>
		public static GamepadState Gamepad { get { return gamepad; } }
		
		/// <summary>Gets the array of gamepads</summary>
		public static GamepadState[] Gamepads { get { return gamepads; } }
		
		#endregion // Public Static Properties
		
		#region Public Constructors
		
		/// <summary>A static constructor for the input</summary>
		static Input() {
			processor = null;
			keyboard = new KeyboardState(10);
			mouse = new MouseState(10);
			gamepad = new GamepadState(System.IntPtr.Zero, 10, true);
			gamepads = null;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		#region IsDown Methods
		
		/// <summary>Finds if the key is pressed or held down</summary>
		/// <param name="key">The key to query if it's down</param>
		/// <returns>Returns true if the key is pressed or held down</returns>
		public static bool IsDown(Keys key) { return keyboard.IsDown(key); }
		
		/// <summary>Finds if the button is pressed or held down</summary>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public static bool IsDown(MouseButton button) { return mouse.IsDown(button); }
		
		/// <summary>Finds if the button from the primary gamepad is pressed or held down</summary>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public static bool IsDown(GamepadButton button) { return gamepad.IsDown(button); }
		
		/// <summary>Finds if the button is pressed or held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public static bool IsDown(int playerId, GamepadButton button) { return gamepads[playerId].IsDown(button); }
		
		/// <summary>Finds if the given axis is pressed or held down</summary>
		/// <param name="axis">The axis to query if it's down</param>
		/// <returns>Returns true if the axis is pressed or held down</returns>
		public static bool IsDown(GamepadAxis axis) { return gamepad.IsDown(axis); }
		
		/// <summary>Finds if the given axis is pressed or held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's down</param>
		/// <returns>Returns true if the axis is pressed or held down</returns>
		public static bool IsDown(int playerId, GamepadAxis axis) { return gamepads[playerId].IsDown(axis); }
		
		#endregion // IsDown Methods
		
		#region IsUp Methods
		
		/// <summary>Finds if the key is not pressed or held down</summary>
		/// <param name="key">The key to query if it's up</param>
		/// <returns>Returns true if the key is not pressed or held down</returns>
		public static bool IsUp(Keys key) { return keyboard.IsUp(key); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public static bool IsUp(MouseButton button) { return mouse.IsUp(button); }
		
		/// <summary>Finds if the button from the primary gamepad is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public static bool IsUp(GamepadButton button) { return gamepad.IsUp(button); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public static bool IsUp(int playerId, GamepadButton button) { return gamepads[playerId].IsUp(button); }
		
		/// <summary>Finds if the axis is not pressed or held down</summary>
		/// <param name="axis">The axis to query if it's up</param>
		/// <returns>Returns true if the axis is not pressed or held down</returns>
		public static bool IsUp(GamepadAxis axis) { return gamepad.IsUp(axis); }
		
		/// <summary>Finds if the axis is not pressed or held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's up</param>
		/// <returns>Returns true if the axis is not pressed or held down</returns>
		public static bool IsUp(int playerId, GamepadAxis axis) { return gamepads[playerId].IsUp(axis); }
		
		#endregion // IsUp Methods
		
		#region IsHeldDown Methods
		
		/// <summary>Finds if the key is held down</summary>
		/// <param name="key">The key to query if it's held down</param>
		/// <returns>Returns true if the given key is held down</returns>
		public static bool IsHeldDown(Keys key) { return keyboard.IsHeldDown(key); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the given button is held down</returns>
		public static bool IsHeldDown(MouseButton button) { return mouse.IsHeldDown(button); }
		
		/// <summary>Finds if the button from the primary gamepad is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the given button is held down</returns>
		public static bool IsHeldDown(GamepadButton button) { return gamepad.IsHeldDown(button); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the given button is held down</returns>
		public static bool IsHeldDown(int playerId, GamepadButton button) { return gamepads[playerId].IsHeldDown(button); }
		
		/// <summary>Finds if the axis is held down</summary>
		/// <param name="axis">The axis to query if it's held down</param>
		/// <returns>Returns true if the axis is held down</returns>
		public static bool IsHeldDown(GamepadAxis axis) { return gamepad.IsHeldDown(axis); }
		
		/// <summary>Finds if the axis is held down</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's held down</param>
		/// <returns>Returns true if the axis is held down</returns>
		public static bool IsHeldDown(int playerId, GamepadAxis axis) { return gamepads[playerId].IsHeldDown(axis); }
		
		#endregion // IsHeldDown Methods
		
		#region GetHeldDuration Methods
		
		/// <summary>Gets the amount of time spent holding down a specific key</summary>
		/// <param name="key">The key to see the duration for</param>
		/// <returns>Returns the timespan of the key being held down</returns>
		public static System.TimeSpan GetHeldDuration(Keys key) { return keyboard.GetHeldDuration(key); }
		
		/// <summary>Gets the amount of time spent holding down a specific mouse button</summary>
		/// <param name="button">The mouse button to see the duration for</param>
		/// <returns>Returns the timespan of the mouse button being held down</returns>
		public static System.TimeSpan GetHeldDuration(MouseButton button) { return mouse.GetHeldDuration(button); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad button</summary>
		/// <param name="button">The gamepad button to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad button being held down</returns>
		public static System.TimeSpan GetHeldDuration(GamepadButton button) { return gamepad.GetHeldDuration(button); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad axis</summary>
		/// <param name="axis">The gamepad axis to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad axis being held down</returns>
		public static System.TimeSpan GetHeldDuration(GamepadAxis axis) { return gamepad.GetHeldDuration(axis); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad button</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="button">The gamepad button to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad button being held down</returns>
		public static System.TimeSpan GetHeldDuration(int playerId, GamepadButton button) { return gamepads[playerId].GetHeldDuration(button); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad axis</summary>
		/// <param name="playerId">The id of the gamepad to check with</param>
		/// <param name="axis">The gamepad axis to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad axis being held down</returns>
		public static System.TimeSpan GetHeldDuration(int playerId, GamepadAxis axis) { return gamepads[playerId].GetHeldDuration(axis); }
		
		#endregion // GetHeldDuration Methods
		
		/// <summary>Sets the input processor</summary>
		/// <param name="inputProcessor">The input processor</param>
		public static void SetProcessor(IInputProcessor inputProcessor) { processor = inputProcessor; }
		
		/// <summary>Processes the input</summary>
		public static void ProcessInput() { processor.ProcessInput(ref keyboard, ref mouse, ref gamepad, ref gamepads); }
		
		#endregion // Public Static Methods
	}
}

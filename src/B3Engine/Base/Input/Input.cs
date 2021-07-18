
using System.Collections.Generic;

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
		private static ClipboardState clipboard;
		
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
		
		/// <summary>Gets the clipboard input</summary>
		public static ClipboardState Clipboard { get { return clipboard; } }
		
		#endregion // Public Static Properties
		
		#region Public Constructors
		
		/// <summary>A static constructor for the input</summary>
		static Input() {
			processor = null;
			keyboard = new KeyboardState(10);
			mouse = new MouseState(10);
			gamepad = new GamepadState(System.IntPtr.Zero, 10, true);
			clipboard = new ClipboardState("");
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
		
		/// <summary>Finds if the axis is being moved</summary>
		/// <param name="axis">The axis to query</param>
		/// <returns>Returns true if the axis is being moved</returns>
		public static bool IsDown(MouseAxis axis) { return mouse.IsDown(axis); }
		
		/// <summary>Finds if the button from the primary gamepad is pressed or held down</summary>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public static bool IsDown(GamepadButton button) { return gamepad.IsDown(button); }
		
		/// <summary>Finds if the button is pressed or held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public static bool IsDown(int playerId, GamepadButton button) { return gamepads[playerId].IsDown(button); }
		
		/// <summary>Finds if the given axis is pressed or held down</summary>
		/// <param name="axis">The axis to query if it's down</param>
		/// <returns>Returns true if the axis is pressed or held down</returns>
		public static bool IsDown(GamepadAxis axis) { return gamepad.IsDown(axis); }
		
		/// <summary>Finds if the given axis is pressed or held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's down</param>
		/// <returns>Returns true if the axis is pressed or held down</returns>
		public static bool IsDown(int playerId, GamepadAxis axis) { return gamepads[playerId].IsDown(axis); }
		
		/// <summary>Finds if the given action is pressed or held down</summary>
		/// <param name="action">The name of the action</param>
		/// <returns>Returns true if the action is pressed or held down</returns>
		public static bool IsDown(string action) {
			if(!InputMapping.namedActions.ContainsKey(action)) {
				throw new System.Exception($"Action does not exist: {action}. Please add in an action through B3.InputMapping.");
			}
			
			// Variables
			List<object> keys = InputMapping.namedActions[action];
			
			foreach(object key in keys) {
				if(key is Keys && IsDown((Keys)key)) {
					return true;
				}
				if(key is MouseButton && IsDown((MouseButton)key)) {
					return true;
				}
				if(key is MouseAxis && IsDown((MouseAxis)key)) {
					return true;
				}
				if(key is GamepadButton && IsDown((GamepadButton)key)) {
					return true;
				}
				if(key is GamepadAxis && IsDown((GamepadAxis)key)) {
					return true;
				}
				if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					if(IsDown(indexButton.Item1, indexButton.Item2)) {
						return true;
					}
				}
				if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int,GamepadAxis>)key;
					
					if(IsDown(indexAxis.Item1, indexAxis.Item2)) {
						return true;
					}
				}
			}
			
			return false;
		}
		
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
		
		/// <summary>Finds if the axis is not being moved</summary>
		/// <param name="axis">The axis to query</param>
		/// <returns>Returns true if the axis is not being moved</returns>
		public static bool IsUp(MouseAxis axis) { return mouse.IsUp(axis); }
		
		/// <summary>Finds if the button from the primary gamepad is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public static bool IsUp(GamepadButton button) { return gamepad.IsUp(button); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public static bool IsUp(int playerId, GamepadButton button) { return gamepads[playerId].IsUp(button); }
		
		/// <summary>Finds if the axis is not pressed or held down</summary>
		/// <param name="axis">The axis to query if it's up</param>
		/// <returns>Returns true if the axis is not pressed or held down</returns>
		public static bool IsUp(GamepadAxis axis) { return gamepad.IsUp(axis); }
		
		/// <summary>Finds if the axis is not pressed or held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's up</param>
		/// <returns>Returns true if the axis is not pressed or held down</returns>
		public static bool IsUp(int playerId, GamepadAxis axis) { return gamepads[playerId].IsUp(axis); }
		
		/// <summary>Finds if the action is not pressed or held down</summary>
		/// <param name="action">The name of the action to query</param>
		/// <returns>Returns true if the action is not pressed or held down</returns>
		public static bool IsUp(string action) {
			if(!InputMapping.namedActions.ContainsKey(action)) {
				throw new System.Exception($"Action does not exist: {action}. Please add in an action through B3.InputMapping.");
			}
			
			// Variables
			List<object> keys = InputMapping.namedActions[action];
			
			foreach(object key in keys) {
				if(key is Keys && !IsUp((Keys)key)) {
					return false;
				}
				if(key is MouseButton && !IsUp((MouseButton)key)) {
					return false;
				}
				if(key is MouseAxis && !IsUp((MouseAxis)key)) {
					return false;
				}
				if(key is GamepadButton && !IsUp((GamepadButton)key)) {
					return false;
				}
				if(key is GamepadAxis && !IsUp((GamepadAxis)key)) {
					return false;
				}
				if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					if(!IsUp(indexButton.Item1, indexButton.Item2)) {
						return false;
					}
				}
				if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int, GamepadAxis>)key;
					
					if(!IsUp(indexAxis.Item1, indexAxis.Item2)) {
						return false;
					}
				}
			}
			
			return true;
		}
		
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
		
		/// <summary>Finds if the axis is being moved</summary>
		/// <param name="axis">The axis to query</param>
		/// <returns>Returns true if the axis is being moved</returns>
		public static bool IsHeldDown(MouseAxis axis) { return mouse.IsHeldDown(axis); }
		
		/// <summary>Finds if the button from the primary gamepad is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the given button is held down</returns>
		public static bool IsHeldDown(GamepadButton button) { return gamepad.IsHeldDown(button); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the given button is held down</returns>
		public static bool IsHeldDown(int playerId, GamepadButton button) { return gamepads[playerId].IsHeldDown(button); }
		
		/// <summary>Finds if the axis is held down</summary>
		/// <param name="axis">The axis to query if it's held down</param>
		/// <returns>Returns true if the axis is held down</returns>
		public static bool IsHeldDown(GamepadAxis axis) { return gamepad.IsHeldDown(axis); }
		
		/// <summary>Finds if the axis is held down</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="axis">The axis to query if it's held down</param>
		/// <returns>Returns true if the axis is held down</returns>
		public static bool IsHeldDown(int playerId, GamepadAxis axis) { return gamepads[playerId].IsHeldDown(axis); }
		
		/// <summary>Finds if the action is held down</summary>
		/// <param name="action">The name of the action to query</param>
		/// <returns>Returns true if the action is being held down</returns>
		public static bool IsHeldDown(string action) {
			if(!InputMapping.namedActions.ContainsKey(action)) {
				throw new System.Exception($"Action does not exist: {action}. Please add in an action through B3.InputMapping.");
			}
			
			// Variables
			List<object> keys = InputMapping.namedActions[action];
			
			foreach(object key in keys) {
				if(key is Keys && IsHeldDown((Keys)key)) {
					return true;
				}
				if(key is MouseButton && IsHeldDown((MouseButton)key)) {
					return true;
				}
				if(key is MouseAxis && IsHeldDown((MouseAxis)key)) {
					return true;
				}
				if(key is GamepadButton && IsHeldDown((GamepadButton)key)) {
					return true;
				}
				if(key is GamepadAxis && IsHeldDown((GamepadAxis)key)) {
					return true;
				}
				if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					if(IsHeldDown(indexButton.Item1, indexButton.Item2)) {
						return true;
					}
				}
				if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int,GamepadAxis>)key;
					
					if(IsHeldDown(indexAxis.Item1, indexAxis.Item2)) {
						return true;
					}
				}
			}
			
			return false;
		}
		
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
		
		/// <summary>Gets the amount of time spent holding moving around a specific axis</summary>
		/// <param name="axis">The axis to query</param>
		/// <returns>Returns the timespan of the axis being moved around</returns>
		public static System.TimeSpan GetHeldDuration(MouseAxis axis) { return mouse.GetHeldDuration(axis); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad button</summary>
		/// <param name="button">The gamepad button to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad button being held down</returns>
		public static System.TimeSpan GetHeldDuration(GamepadButton button) { return gamepad.GetHeldDuration(button); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad axis</summary>
		/// <param name="axis">The gamepad axis to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad axis being held down</returns>
		public static System.TimeSpan GetHeldDuration(GamepadAxis axis) { return gamepad.GetHeldDuration(axis); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad button</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="button">The gamepad button to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad button being held down</returns>
		public static System.TimeSpan GetHeldDuration(int playerId, GamepadButton button) { return gamepads[playerId].GetHeldDuration(button); }
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad axis</summary>
		/// <param name="playerId">The index of the gamepad to check with</param>
		/// <param name="axis">The gamepad axis to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad axis being held down</returns>
		public static System.TimeSpan GetHeldDuration(int playerId, GamepadAxis axis) { return gamepads[playerId].GetHeldDuration(axis); }
		
		/// <summary>Gets the amount of time spent holding down an action</summary>
		/// <param name="action">The name of the action to query</param>
		/// <returns>Returns the amount of time the action has been held down</returns>
		/// <remarks>Actions can hold multiple inputs, the input with the least amount of time will be returned</remarks>
		public static System.TimeSpan GetHeldDuration(string action) {
			if(!InputMapping.namedActions.ContainsKey(action)) {
				throw new System.Exception($"Action does not exist: {action}. Please add in an action through B3.InputMapping.");
			}
			
			// Variables
			List<object> keys = InputMapping.namedActions[action];
			System.TimeSpan best = System.TimeSpan.MaxValue;
			System.TimeSpan temp = System.TimeSpan.Zero;
			
			if(keys.Count == 0) {
				return System.TimeSpan.Zero;
			}
			
			foreach(object key in keys) {
				if(key is Keys) {
					temp = GetHeldDuration((Keys)key);
				}
				if(key is MouseButton) {
					temp = GetHeldDuration((MouseButton)key);
				}
				if(key is MouseAxis) {
					temp = GetHeldDuration((MouseAxis)key);
				}
				if(key is GamepadButton) {
					temp = GetHeldDuration((GamepadButton)key);
				}
				if(key is GamepadAxis) {
					temp = GetHeldDuration((GamepadAxis)key);
				}
				if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					temp = GetHeldDuration(indexButton.Item1, indexButton.Item2);
				}
				if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int,GamepadAxis>)key;
					
					temp = GetHeldDuration(indexAxis.Item1, indexAxis.Item2);
				}
				if(best == System.TimeSpan.MaxValue || (temp < best && temp.TotalMilliseconds > 1)) {
					best = temp;
				}
				else if(temp.TotalMilliseconds > 1 && best.TotalMilliseconds <= 1) {
					best = temp;
				}
			}
			
			return best;
		}
		
		#endregion // GetHeldDuration Methods
		
		#region GetStrength Methods
		
		/// <summary>Gets the strength of the key being pressed down</summary>
		/// <param name="key">The key to see the strength of</param>
		/// <returns>Returns 1 if the key is pressed, 0 otherwise</returns>
		public static float GetStrength(Keys key) { return IsDown(key) ? 1.0f : 0.0f; }
		
		/// <summary>Gets the strength of the mouse button being pressed down</summary>
		/// <param name="button">The mouse button to see the strength of</param>
		/// <returns>Returns 1 if the mouse button is pressed, 0 otherwise</returns>
		public static float GetStrength(MouseButton button) { return IsDown(button) ? 1.0f : 0.0f; }
		
		/// <summary>Gets the strength of the mouse axis movements</summary>
		/// <param name="axis">The mouse axis to see the strength of</param>
		/// <returns>Returns a range between 0 and positive infinity of the mouse's movements</returns>
		public static float GetStrength(MouseAxis axis) { return mouse[axis]; }
		
		/// <summary>Gets the strength of the gamepad button being pressed down</summary>
		/// <param name="button">The gamepad button to see the strength of</param>
		/// <returns>Returns 1 if the gamepad button is pressed, 0 otherwise</returns>
		public static float GetStrength(GamepadButton button) { return IsDown(button) ? 1.0f : 0.0f; }
		
		/// <summary>Gets the strength of the gamepad button being pressed down</summary>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="button">The gamepad button to see the strength of</param>
		/// <returns>Returns 1 if the gamepad button is pressed, 0 otherwise</returns>
		public static float GetStrength(int playerId, GamepadButton button) { return IsDown(playerId, button) ? 1.0f : 0.0f; }
		
		/// <summary>Gets the strength of the gamepad axis</summary>
		/// <param name="axis">The gamepad axis to get the strength of</param>
		/// <returns>Returns a number between 0 and 1 of the strength of the gamepad axis</returns>
		public static float GetStrength(GamepadAxis axis) { return gamepad[axis]; }
		
		/// <summary>Gets the strength of the gamepad axis</summary>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="axis">The gamepad axis to get the strength of</param>
		/// <returns>Returns a number between 0 and 1 of the strength of the gamepad axis</returns>
		public static float GetStrength(int playerId, GamepadAxis axis) { return gamepads[playerId][axis]; }
		
		/// <summary>Gets the strength of the action</summary>
		/// <param name="action">The name of the action to query</param>
		/// <returns>Returns the strength of the action</returns>
		/// <remarks>Actions have multiple inputs, the input with the least strength gets returned</remarks>
		public static float GetStrength(string action) {
			if(!InputMapping.namedActions.ContainsKey(action)) {
				throw new System.Exception($"Action does not exist: {action}. Please add in an action through B3.InputMapping.");
			}
			
			// Variables
			List<object> keys = InputMapping.namedActions[action];
			float best = float.MaxValue;
			float temp = 0.0f;
			
			if(keys.Count == 0) {
				return 0.0f;
			}
			
			foreach(object key in keys) {
				if(key is Keys) {
					temp = GetStrength((Keys)key);
				}
				if(key is MouseButton) {
					temp = GetStrength((MouseButton)key);
				}
				if(key is MouseAxis) {
					temp = GetStrength((MouseAxis)key);
				}
				if(key is GamepadButton) {
					temp = GetStrength((GamepadButton)key);
				}
				if(key is GamepadAxis) {
					temp = GetStrength((GamepadAxis)key);
				}
				if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					temp = GetStrength(indexButton.Item1, indexButton.Item2);
				}
				if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int,GamepadAxis>)key;
					
					temp = GetStrength(indexAxis.Item1, indexAxis.Item2);
				}
				if(best == float.MaxValue || (temp < best && temp > 0.0f)) {
					best = temp;
				}
				if(temp > 0.0f && best == 0.0f) {
					best = temp;
				}
			}
			
			return best;
		}
		
		#endregion // GetStrength Methods
		
		/// <summary>Gets the axis from the given axis name</summary>
		/// <param name="axisName">The name of the axis that contains the positive and negative actions</param>
		/// <returns>Returns a number between -1 and 1 of the given axis</returns>
		public static float GetAxis(string axisName) {
			if(!InputMapping.axes.ContainsKey(axisName)) {
				throw new System.Exception($"Axis does not exist: {axisName}. Please add in an axis through B3.InputMapping.");
			}
			
			// Variables
			(string, string) negPos = InputMapping.axes[axisName];
			float positive = GetStrength(negPos.Item1);
			float negative = GetStrength(negPos.Item2);
			
			return positive - negative;
		}
		
		/// <summary>Gets the index of the gamepad from the first gamepad that pressed the specific list of buttons</summary>
		/// <param name="buttons">The list of buttons to check for</param>
		/// <returns>Returns the index of the gamepad that has pressed the list of buttons</returns>
		public static int GetGamepadIdFromButtons(params GamepadButton[] buttons) {
			// Variables
			int amount;
			
			for(int i = 0; i < gamepads.Length; i++) {
				amount = 0;
				foreach(GamepadButton button in buttons) {
					if(gamepads[i][button] != InputState.Released) {
						amount++;
					}
				}
				if(amount == buttons.Length) {
					return i;
				}
			}
			return -1;
		}
		
		/// <summary>Sets the input processor</summary>
		/// <param name="inputProcessor">The input processor</param>
		public static void SetProcessor(IInputProcessor inputProcessor) { processor = inputProcessor; }
		
		/// <summary>Processes the input</summary>
		public static void ProcessInput() { processor.ProcessInput(ref keyboard, ref mouse, ref gamepad, ref gamepads); }
		
		#endregion // Public Static Methods
	}
}

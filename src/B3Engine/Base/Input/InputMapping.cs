
using System.Collections.Generic;

namespace B3 {
	/// <summary>A static class that helps with remapping input and quick input uses</summary>
	public static class InputMapping {
		#region Field Variables
		// Variables
		internal static Dictionary<string, List<object>> namedActions;
		internal static Dictionary<string, (string, string)> axes;
		
		#endregion // Field Variables
		
		#region Public Static Constructors
		
		static InputMapping() {
			namedActions = new Dictionary<string, List<object>>();
			axes = new Dictionary<string, (string, string)>();
		}
		
		#endregion // Public Static Constructors
		
		#region Public Static Methods
		
		/// <summary>Adds a new empty action into the mapping</summary>
		/// <param name="action">The name of the action to add in</param>
		public static void AddNewAction(string action) {
			namedActions.Add(action, new List<object>());
		}
		
		/// <summary>Removes an action from the mapping</summary>
		/// <param name="action">The name of the action to remove</param>
		/// <returns>Returns true if the action has been removed</returns>
		public static bool RemoveAction(string action) {
			return namedActions.Remove(action);
		}
		
		/// <summary>Adds a new axis to use</summary>
		/// <param name="axis">The name of the new axis to use</param>
		/// <param name="positiveAction">The name of the action used for a positive movement</param>
		/// <param name="negativeAction">The name of the action used for a negtive movement</param>
		public static void AddNewAxis(string axis, string positiveAction, string negativeAction) {
			axes.Add(axis, (positiveAction, negativeAction));
		}
		
		/// <summary>Removes an axis from the mapping</summary>
		/// <param name="axis">The name of the axis to remove</param>
		/// <returns>Returns true if the action has been removed</returns>
		public static bool RemoveAxis(string axis) {
			return axes.Remove(axis);
		}
		
		/// <summary>Clears all the axes and actions from the mapping</summary>
		public static void ClearAll() {
			namedActions.Clear();
			axes.Clear();
		}
		
		/// <summary>Clears all the actions from the mapping</summary>
		public static void ClearActions() { namedActions.Clear(); }
		
		/// <summary>Clears all the axes from the mapping</summary>
		public static void ClearAxes() { axes.Clear(); }
		
		#region AddInputToAction Methods
		
		/// <summary>Adds a keyboard key into the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="key">The keyboard key to bind it to</param>
		public static void AddInputToAction(string action, Keys key) { namedActions[action].Add(key); }
		
		/// <summary>Adds a mouse button into the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="button">The mouse button to bind it to</param>
		public static void AddInputToAction(string action, MouseButton button) { namedActions[action].Add(button); }
		
		/// <summary>Adds a mouse axis into the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="axis">The mouse axis to bind it to</param>
		public static void AddInputToAction(string action, MouseAxis axis) { namedActions[action].Add(axis); }
		
		/// <summary>Adds a gamepad button into the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="button">The gamepad button to bind it to</param>
		public static void AddInputToAction(string action, GamepadButton button) { namedActions[action].Add(button); }
		
		/// <summary>Adds a gamepad axis into the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="axis">The gamepad axis button to bind it to</param>
		public static void AddInputToAction(string action, GamepadAxis axis) { namedActions[action].Add(axis); }
		
		/// <summary>Adds a gamepad button into the action from a specific gamepad</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="button">The gamepad button to bind it to</param>
		public static void AddInputToAction(string action, int playerId, GamepadButton button) { namedActions[action].Add((playerId, button)); }
		
		/// <summary>Adds a gamepad axis into the action from a specific gamepad</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="axis">The gamepad button to bind it to</param>
		public static void AddInputToAction(string action, int playerId, GamepadAxis axis) { namedActions[action].Add((playerId, axis)); }
		
		#endregion // AddInputToAction Methods
		
		#region RemoveInputFromAction Methods
		
		/// <summary>Removes the keyboard key from the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="key">The keyboard key to remove</param>
		public static void RemoveInputFromAction(string action, Keys key) {
			while(namedActions[action].Remove(key)) {}
		}
		
		/// <summary>Removes the mouse button from the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="button">The mouse button to remove</param>
		public static void RemoveInputFromAction(string action, MouseButton button) {
			while(namedActions[action].Remove(button)) {}
		}
		
		/// <summary>Removes the mouse axis from the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="axis">The mouse axis to remove</param>
		public static void RemoveInputFromAction(string action, MouseAxis axis) {
			while(namedActions[action].Remove(axis)) {}
		}
		
		/// <summary>Removes the gamepad button from the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="button">The gamepad button to remove</param>
		public static void RemoveInputFromAction(string action, GamepadButton button) {
			while(namedActions[action].Remove(button)) {}
		}
		
		/// <summary>Removes the gamepad axis from the action</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="axis">The gamepad axis to remove</param>
		public static void RemoveInputFromAction(string action, GamepadAxis axis) {
			while(namedActions[action].Remove(axis)) {}
		}
		
		/// <summary>Removes the gamepad button from the action of a specific gamepad</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="button">THe gamepad button to remove</param>
		public static void RemoveInputFromAction(string action, int playerId, GamepadButton button) {
			while(namedActions[action].Remove((playerId, button))) {}
		}
		
		/// <summary>Removes the gamepad axis from the action of a specific gamepad</summary>
		/// <param name="action">The name of the action to update</param>
		/// <param name="playerId">The index of the gamepad</param>
		/// <param name="axis">The gamepad axis to remove</param>
		public static void RemoveInputFromAction(string action, int playerId, GamepadAxis axis) {
			while(namedActions[action].Remove((playerId, axis))) {}
		}
		
		#endregion // RemoveInputFromAction Methods
		
		// TODO: Add a LoadMappingFromXml(string path); method
		// TODO: Add a SaveMappingToXml(string path); method
		
		#endregion // Public Static Methods
	}
}

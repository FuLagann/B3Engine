
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace B3 {
	/// <summary>A static class that helps with remapping input and quick input uses</summary>
	public static class InputMapping {
		#region Field Variables
		// Variables
		internal static readonly Dictionary<string, List<object>> namedActions;
		internal static readonly Dictionary<string, (string, string)> axes;
		
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
			if(namedActions.ContainsKey(action)) {
				namedActions.Remove(action);
			}
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
			if(axes.ContainsKey(axis)) {
				axes.Remove(axis);
			}
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
		
		/// <summary>Loads the current input mapping from an external xml file</summary>
		/// <param name="path">The path to the xml file</param>
		public static void LoadMappingFromXml(string path) {
			// Variables
			XmlDocument document = new XmlDocument();
			XmlNode node;
			
			using(Stream stream = FS.ReadStream(path)) {
				document.Load(stream);
			}
			
			node = document["InputMapping"];
			
			LoadNamedActionsFromList(node["NamedActions"].GetElementsByTagName("Action"));
			LoadAxesFromList(node["Axes"].GetElementsByTagName("Axis"));
		}
		
		/// <summary>Saves the current input mapping into a file in xml format</summary>
		/// <param name="path">The file location to save it to</param>
		public static void SaveMapingToXml(string path) {
			// Variables
			string results = "\n<InputMapping>\n";
			
			results += "\t<NamedActions>\n";
			results += GetNamedActionsInXmlString();
			results += "\t</NamedActions>\n";
			results += "\t<Axes>\n";
			results += GetAxesInXmlString();
			results += "\t</Axes>\n";
			results += "</InputMapping>\n";
			
			FS.Write(path, results);
		}
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Transforms all the named actions and their inputs into an xml string</summary>
		/// <returns>Returns all the named actions in xml string form</returns>
		private static string GetNamedActionsInXmlString() {
			// Variables
			string results = "";
			
			foreach(KeyValuePair<string, List<object>> actionKV in namedActions) {
				results += $"\t\t<Action Name=\"{actionKV.Key}\">\n";
				results += GetActionInputsInXmlString(actionKV.Value);
				results += $"\t\t</Action>\n";
			}
			
			return results;
		}
		
		/// <summary>Transforms all the action inputs into an xml string</summary>
		/// <param name="keys">The list of inputs in general form</param>
		/// <returns>Returns all the action inputs in xml string form</returns>
		private static string GetActionInputsInXmlString(List<object> keys) {
			// Variables
			string results = "";
			
			foreach(object key in keys) {
				results += "\t\t\t<Input ";
				if(key is Keys) {
					results += $"Type=\"Keyboard\" Key=\"{(Keys)key}\"";
				}
				else if(key is MouseButton) {
					results += $"Type=\"Mouse\" Button=\"{(MouseButton)key}\"";
				}
				else if(key is MouseAxis) {
					results += $"Type=\"Mouse\" Axis=\"{(MouseAxis)key}\"";
				}
				else if(key is GamepadButton) {
					results += $"Type=\"Gamepad\" Button=\"{(GamepadButton)key}\"";
				}
				else if(key is GamepadAxis) {
					results += $"Type=\"Gamepad\" Axis=\"{(GamepadAxis)key}\"";
				}
				else if(key is System.ValueTuple<int, GamepadButton>) {
					// Variables
					(int, GamepadButton) indexButton = (System.ValueTuple<int, GamepadButton>)key;
					
					results += $"Type=\"Gamepad\" Index=\"{indexButton.Item1}\" Button=\"{indexButton.Item2}\"";
				}
				else if(key is System.ValueTuple<int, GamepadAxis>) {
					// Variables
					(int, GamepadAxis) indexAxis = (System.ValueTuple<int, GamepadAxis>)key;
					
					results += $"Type=\"Gamepad\" Index=\"{indexAxis.Item1}\" Axis=\"{indexAxis.Item2}\"";
				}
				results += "/>\n";
			}
			
			return results;
		}
		
		/// <summary>Transforms the <see cref="B3.InputMapping.axes"/> dictionary into a xml string for saving into a file</summary>
		/// <returns>Returns the <see cref="B3.InputMapping.axes"/> dictionary in xml string form</returns>
		private static string GetAxesInXmlString() {
			// Variables
			string results = "";
			
			foreach(KeyValuePair<string, (string, string)> axisKV in axes) {
				results += $"\t\t<Axis Name=\"{axisKV.Key}\" Positive=\"{axisKV.Value.Item1}\" Negative=\"{axisKV.Value.Item2}\"/>\n";
			}
			
			return results;
		}
		
		/// <summary>Loads all the axes from the given list</summary>
		/// <param name="list">The list of Axis xml elements to load the data with</param>
		private static void LoadAxesFromList(XmlNodeList list) {
			foreach(XmlElement node in list) {
				// Variables
				string axis = node.Attributes["Name"].Value;
				string positive = node.Attributes["Positive"].Value;
				string negative = node.Attributes["Negative"].Value;
				
				AddNewAxis(axis, positive, negative);
			}
		}
		
		/// <summary>Loads all the named actions from the given list</summary>
		/// <param name="list">The list of Action xml elements to load the data with</param>
		private static void LoadNamedActionsFromList(XmlNodeList list) {
			foreach(XmlElement node in list) {
				// Variables
				string action = node.Attributes["Name"].Value;
				
				AddNewAction(action);
				LoadActionInputsFromList(action, node.GetElementsByTagName("Input"));
			}
		}
		
		/// <summary>Loads in all the inputs from an action given the list</summary>
		/// <param name="action">The name of the action to load the inputs into</param>
		/// <param name="list">The list of Input xml elements to load the data with</param>
		private static void LoadActionInputsFromList(string action, XmlNodeList list) {
			foreach(XmlElement node in list) {
				switch(node.Attributes["Type"].Value.ToLower()) {
					case "keyboard": {
						AddInputToAction(
							action,
							(Keys)(System.Enum.Parse(
								typeof(Keys),
								node.Attributes["Key"].Value.Replace("-", ""),
								true
							))
						);
					} break;
					case "mouse": {
						if(node.Attributes["Button"] != null) {
							AddInputToAction(
								action,
								(MouseButton)(System.Enum.Parse(
									typeof(MouseButton),
									node.Attributes["Button"].Value.Replace("-", ""),
									true
								))
							);
						}
						else {
							AddInputToAction(
								action,
								(MouseAxis)(System.Enum.Parse(
									typeof(MouseAxis),
									node.Attributes["Axis"].Value.Replace("-", ""),
									true
								))
							);
						}
					} break;
					case "gamepad": {
						// Variables
						bool usingButton = (node.Attributes["Button"] != null);
						
						if(node.Attributes["Index"] != null) {
							// Variables
							int index = int.Parse(node.Attributes["Index"].Value);
							
							if(usingButton) {
								AddInputToAction(
									action,
									index,
									(GamepadButton)(System.Enum.Parse(
										typeof(GamepadButton),
										node.Attributes["Button"].Value.Replace("-", ""),
										true
									))
								);
							}
							else {
								AddInputToAction(
									action,
									index,
									(GamepadAxis)(System.Enum.Parse(
										typeof(GamepadAxis),
										node.Attributes["Axis"].Value.Replace("-", ""),
										true
									))
								);
							}
						}
						else {
							if(usingButton) {
								AddInputToAction(
									action,
									(GamepadButton)(System.Enum.Parse(
										typeof(GamepadButton),
										node.Attributes["Button"].Value.Replace("-", ""),
										true
									))
								);
							}
							else {
								AddInputToAction(
									action,
									(GamepadAxis)(System.Enum.Parse(
										typeof(GamepadAxis),
										node.Attributes["Axis"].Value.Replace("-", ""),
										true
									))
								);
							}
						}
					} break;
				}
			}
		}
		
		#endregion // Private Static Methods
	}
}


namespace B3 {
	/// <summary>An enumeration of all the axes of a gamepad that the player can use</summary>
	public enum GamepadAxis : int {
		/// <summary>If the axis is unknown</summary>
		Unknown = -1,
		/// <summary>The Left Stick's X-Axis</summary>
		LeftX,
		/// <summary>The Left Stick's Y-Axis</summary>
		LeftY,
		/// <summary>The Right Stick's X-Axis</summary>
		RightX,
		/// <summary>The Right Stick's Y-Axis</summary>
		RightY,
		/// <summary>The Left Trigger's Axis (also known as the Positive Z-Axis)</summary>
		TriggerLeft,
		/// <summary>The Right Trigger's Axis (also known as the Negative Z-Axis)</summary>
		TriggerRight,
	}
}

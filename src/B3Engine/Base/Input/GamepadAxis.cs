
namespace B3 {
	/// <summary>An enumeration of all the axes of a gamepad that the player can use</summary>
	public enum GamepadAxis : int {
		/// <summary>If the axis is unknown</summary>
		Unknown = -1,
		/// <summary>The Left Stick's X-Axis (in the positive direction)</summary>
		LeftXPositive = 0,
		/// <summary>The Left Stick's Y-Axis (in the positive direction)</summary>
		LeftYPositive = 1,
		/// <summary>The Right Stick's X-Axis (in the positive direction)</summary>
		RightXPositive = 2,
		/// <summary>The Right Stick's Y-Axis (in the positive direction)</summary>
		RightYPositive = 3,
		/// <summary>The Left Trigger's Axis (also known as the Positive Z-Axis)</summary>
		TriggerLeft = 4,
		/// <summary>The Right Trigger's Axis (also known as the Negative Z-Axis)</summary>
		TriggerRight = 5,
		/// <summary>The Left Stick's X-Axis (in the negative direction)</summary>
		LeftXNegative = 6,
		/// <summary>The Left Stick's Y-Axis (in the negative direction)</summary>
		LeftYNegative = 7,
		/// <summary>The Right Stick's X-Axis (in the negative direction)</summary>
		RightXNegative = 8,
		/// <summary>The Right Stick's Y-Axis (in the negative direction)</summary>
		RightYNegative = 9,
	}
}

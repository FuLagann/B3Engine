
namespace B3 {
	/// <summary>An enumeration for the different mouse axis movements</summary>
	public enum MouseAxis : int {
		/// <summary>For when the mouse axis is unknown</summary>
		Unknown = -1,
		/// <summary>The upward mouse axis (y-axis)</summary>
		Up = 0,
		/// <summary>The downward mouse axis (-y-axis)</summary>
		Down = 1,
		/// <summary>The leftward mouse axis (-x-axis)</summary>
		Left = 2,
		/// <summary>The rightward mouse axis (x-axis)</summary>
		Right = 3,
		/// <summary>The scroll wheel moving upward</summary>
		ScrollUp = 4,
		/// <summary>The scroll wheel moving downward</summary>
		ScrollDown = 5,
	}
}

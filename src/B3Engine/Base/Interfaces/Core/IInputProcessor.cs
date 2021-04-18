
namespace B3 {
	/// <summary>An interface used for processing the input generically</summary>
	public interface IInputProcessor {
		#region Methods
		
		/// <summary>Processes the input for later use</summary>
		/// <param name="keyboard">The reference to the keyboard's input structure</param>
		/// <param name="mouse">The reference to the mouse's input structure</param>
		/// <param name="generalGamepad">The reference to the general gamepad</param>
		/// <param name="gamepads">The reference to an array of gamepad's input structure</param>
		void ProcessInput(ref KeyboardState keyboard, ref MouseState mouse, ref GamepadState generalGamepad, ref GamepadState[] gamepads);
		
		#endregion // Methods
	}
}

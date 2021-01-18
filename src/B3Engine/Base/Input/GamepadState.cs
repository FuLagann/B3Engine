
using System.Collections.Generic;

namespace B3 {
	/// <summary>A structure that keeps track of the gamepad's inputs</summary>
	public partial struct GamepadState {
		#region Field Variables
		// Variables
		private System.IntPtr handle;
		private InputType[] buttons;
		private float[] axes;
		private Queue<GamepadButton> prevButtons;
		private int trackingAmount;
		private bool isAnyButtonDown;
		private float deadZone;
		private long[] timestamps;
		private bool isConnected;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the managed handle of the gamepad</summary>
		public System.IntPtr Handle { get { return this.handle; } }
		
		/// <summary>Gets and sets the gamepad buttons that are pressed</summary>
		/// <param name="button">The gamepad button to get or set the input type from/to</param>
		public InputType this[GamepadButton button] { get { return this.buttons[(int)button]; } internal set {
			// Variables
			bool isPreviouslyUp = (this.buttons[(int)button] == InputType.Released);
			InputType setType = InputType.Released;
			
			if(this.buttons[(int)button] == InputType.Pressed && value == InputType.Pressed) {
				setType = InputType.Held;
			}
			else {
				setType = value;
			}
			
			if(setType == InputType.Released) {
				this.timestamps[(int)button] = 0;
			}
			this.buttons[(int)button] = setType;
			
			if(isPreviouslyUp && value == InputType.Pressed) {
				this.timestamps[(int)button] = System.DateTime.Now.Ticks;
				this.prevButtons.Enqueue(button);
				if(this.prevButtons.Count > this.trackingAmount) {
					this.prevButtons.Dequeue();
				}
			}
		} }
		
		/// <summary>Gets and sets the value from the given axis</summary>
		/// <param name="axis">The axis to check the value of</param>
		public float this[GamepadAxis axis] { get {
			return (Mathx.Abs(this.axes[(int)axis]) >= this.deadZone ?
				this.axes[(int)axis] :
				0.0f
			);
		} internal set {
			// Variables
			bool isPreviouslyUp = (Mathx.Abs(this.axes[(int)axis]) < this.deadZone);
			int offset = this.buttons.Length;
			
			if(Mathx.Abs(value) < this.deadZone) {
				this.timestamps[(int)axis + offset] = 0;
			}
			else if(isPreviouslyUp && Mathx.Abs(value) >= this.deadZone) {
				this.timestamps[(int)axis + offset] = System.DateTime.Now.Ticks;
			}
			this.axes[(int)axis] = value;
		} }
		
		/// <summary>Gets and sets the left stick axis movement in vector form</summary>
		public Vector2 LeftStick { get { return new Vector2(this[GamepadAxis.LeftX], this[GamepadAxis.LeftY]); } }
		
		/// <summary>Gets and sets the right stick axis movement in vector form</summary>
		public Vector2 RightStick { get { return new Vector2(this[GamepadAxis.RightX], this[GamepadAxis.RightY]); } }
		
		/// <summary>Gets and sets the triggers movements in vector form</summary>
		public Vector2 Triggers { get { return new Vector2(this[GamepadAxis.TriggerLeft], this[GamepadAxis.TriggerRight]); } }
		
		/// <summary>Gets the previous buttons that were pressed</summary>
		public GamepadButton[] PreviousButtons { get { return this.prevButtons.ToArray(); } }
		
		/// <summary>Gets and sets how many buttons to keep track of that were being pressed</summary>
		public int TrackingAmount { get { return this.trackingAmount; } set {
			this.trackingAmount = Mathx.Abs(value);
			while(this.prevButtons.Count > this.trackingAmount) {
				this.prevButtons.Dequeue();
			}
		} }
		
		/// <summary>Gets and sets if any buttons have been pressed or held down</summary>
		public bool IsAnyButtonDown { get { return this.isAnyButtonDown; } internal set { this.isAnyButtonDown = value; } }
		
		/// <summary>Gets and sets the dead zone of the controller so accidental drift doesn't happen</summary>
		public float DeadZone { get { return this.deadZone; } set { this.deadZone = value; } }
		
		/// <summary>Gets if the gamepad is actually connected</summary>
		public bool IsConnected { get { return this.isConnected; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the mouse input structure</summary>
		/// <param name="handle">The managed handle to the gamepad for later use</param>
		/// <param name="trackingAmount">The amount of presses to keep track of</param>
		/// <param name="isConnected">Set to true if the gamepad is actually connected; or if its a default version that doesn't matter</param>
		public GamepadState(System.IntPtr handle, int trackingAmount, bool isConnected) {
			this.handle = handle;
			this.trackingAmount = trackingAmount;
			this.buttons = new InputType[System.Enum.GetNames(typeof(GamepadButton)).Length - 1];
			this.axes = new float[System.Enum.GetNames(typeof(GamepadAxis)).Length - 1];
			this.prevButtons = new Queue<GamepadButton>();
			this.isAnyButtonDown = false;
			this.deadZone = 0.24f;
			this.timestamps = new long[this.buttons.Length + this.axes.Length];
			this.isConnected = isConnected;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Clears all the buttons' presses</summary>
		public void Clear() {
			for(int i = 0; i < this.buttons.Length; i++) {
				this.buttons[i] = InputType.Released;
			}
			this.isAnyButtonDown = false;
		}
		
		/// <summary>Checks if the gamepad is not pressed, to set the <see cref="B3.GamepadState.IsAnyButtonDown"/> value</summary>
		public void CheckForClearing() {
			// Variables
			bool isClear = true;
			
			for(int i = 0; i < this.buttons.Length; i++) {
				if(this.buttons[i] != InputType.Released) {
					isClear = false;
					break;
				}
			}
			if(isClear) { this.isAnyButtonDown = false; }
		}
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad button</summary>
		/// <param name="button">The gamepad button to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad button being held down</returns>
		public System.TimeSpan GetHeldDuration(GamepadButton button) {
			// Variables
			System.DateTime lastTime = (this.timestamps[(int)button] == 0 ?
				System.DateTime.Now :
				new System.DateTime(this.timestamps[(int)button])
			);
			System.TimeSpan timeSpan = (System.DateTime.Now - lastTime);
			
			return timeSpan;
		}
		
		/// <summary>Gets the amount of time spent holding down a specific gamepad axis</summary>
		/// <param name="axis">The gamepad axis to see the duration for</param>
		/// <returns>Returns the timespan of the gamepad axis being held down</returns>
		public System.TimeSpan GetHeldDuration(GamepadAxis axis) {
			// Variables
			int offset = this.buttons.Length;
			System.DateTime lastTime = (this.timestamps[(int)axis + offset] == 0 ?
				System.DateTime.Now :
				new System.DateTime(this.timestamps[(int)axis + offset])
			);
			System.TimeSpan timeSpan = (System.DateTime.Now - lastTime);
			
			return timeSpan;
		}
		
		/// <summary>Finds if the given button is pressed or held down</summary>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public bool IsDown(GamepadButton button) { return (this.buttons[(int)button] != InputType.Released); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public bool IsUp(GamepadButton button) { return (this.buttons[(int)button] == InputType.Released); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the button is held down</returns>
		public bool IsHeldDown(GamepadButton button) { return (this.buttons[(int)button] == InputType.Held); }
		
		/// <summary>Finds if the given axis is pressed or held down</summary>
		/// <param name="axis">The axis to query if it's down</param>
		/// <returns>Returns true if the axis is pressed or held down</returns>
		public bool IsDown(GamepadAxis axis) { return (Mathx.Abs(this.axes[(int)axis]) >= this.deadZone); }
		
		/// <summary>Finds if the axis is not pressed or held down</summary>
		/// <param name="axis">The axis to query if it's up</param>
		/// <returns>Returns true if the axis is not pressed or held down</returns>
		public bool IsUp(GamepadAxis axis) { return (Mathx.Abs(this.axes[(int)axis]) < this.deadZone); }
		
		/// <summary>Finds if the axis is held down</summary>
		/// <param name="axis">The axis to query if it's held down</param>
		/// <returns>Returns true if the axis is held down</returns>
		public bool IsHeldDown(GamepadAxis axis) { return (Mathx.Abs(this.axes[(int)axis]) >= this.deadZone); }
		
		/// <summary>Clears all the previous buttons</summary>
		public void ClearPreviousButtons() { this.prevButtons.Clear(); }
		
		#endregion // Public Methods
	}
}

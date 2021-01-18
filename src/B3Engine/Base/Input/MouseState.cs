
using System.Collections.Generic;

namespace B3 {
	/// <summary>A structure for holding the mouse input data</summary>
	public struct MouseState {
		#region Field Variables
		// Variables
		private Vector2 position;
		private float scroll;
		private int trackingAmount;
		private InputType[] buttons;
		private int[] clicks;
		private Queue<MouseButton> prevButtons;
		private bool isAnyButtonDown;
		private long[] timestamps;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the mouse buttons that are pressed</summary>
		/// <param name="button">The mouse button to get or set the input type from/to</param>
		public InputType this[MouseButton button] { get { return this.buttons[(int)button]; } internal set {
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
				this.timestamps[(int)button] = System.DateTime.UtcNow.Ticks;
				this.prevButtons.Enqueue(button);
				if(this.prevButtons.Count > this.trackingAmount) {
					this.prevButtons.Dequeue();
				}
			}
		} }
		
		/// <summary>Gets and sets the position of the mouse</summary>
		public Vector2 Position { get { return this.position; } internal set { this.position = value; } }
		
		/// <summary>Gets and sets the scrolling of the mouse</summary>
		public float Scroll { get { return this.scroll; } internal set { this.scroll = value; } }
		
		/// <summary>Gets the previous buttons that were pressed</summary>
		public MouseButton[] PreviousButtons { get { return this.prevButtons.ToArray(); } }
		
		/// <summary>Gets and sets how many buttons to keep track of that were being pressed</summary>
		public int TrackingAmount { get { return this.trackingAmount; } set {
			this.trackingAmount = Mathx.Abs(value);
			while(this.prevButtons.Count > this.trackingAmount) {
				this.prevButtons.Dequeue();
			}
		} }
		
		/// <summary>Gets and sets if any buttons have been pressed or held down</summary>
		public bool IsAnyButtonDown { get { return this.isAnyButtonDown; } internal set { this.isAnyButtonDown = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the mouse input structure</summary>
		/// <param name="trackingAmount">The amount of presses to keep track of</param>
		public MouseState(int trackingAmount) {
			this.position = Vector2.Zero;
			this.trackingAmount = trackingAmount;
			this.scroll = 0.0f;
			this.buttons = new InputType[System.Enum.GetNames(typeof(MouseButton)).Length - 1];
			this.prevButtons = new Queue<MouseButton>();
			this.isAnyButtonDown = false;
			this.timestamps = new long[this.buttons.Length];
			this.clicks = new int[this.buttons.Length];
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Gets the amount of clicks done by a specific button</summary>
		/// <param name="button">The button to check how many clicks have been done</param>
		/// <returns>Returns the amount of clicks done on the button</returns>
		/// <remarks>When the mouse button gets lifted, the amount of clicks might stay the same</remarks>
		public int GetClicks(MouseButton button) { return this.clicks[(int)button]; }
		
		/// <summary>Clears all the buttons' presses</summary>
		public void Clear() {
			for(int i = 0; i < this.buttons.Length; i++) {
				this.buttons[i] = InputType.Released;
			}
			this.isAnyButtonDown = false;
		}
		
		/// <summary>Checks if the mouse is not pressed, to set the <see cref="B3.MouseState.IsAnyButtonDown"/> value</summary>
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
		
		/// <summary>Gets the amount of time spent holding down a specific mouse button</summary>
		/// <param name="button">The mouse button to see the duration for</param>
		/// <returns>Returns the timespan of the mouse button being held down</returns>
		public System.TimeSpan GetHeldDuration(MouseButton button) {
			// Variables
			System.DateTime lastTime = (this.timestamps[(int)button] == 0 ?
				System.DateTime.Now :
				new System.DateTime(this.timestamps[(int)button])
			);
			System.TimeSpan timeSpan = (System.DateTime.Now - lastTime);
			
			return timeSpan;
		}
		
		/// <summary>Finds if the given button is pressed or held down</summary>
		/// <param name="button">The button to query if it's down</param>
		/// <returns>Returns true if the button is pressed or held down</returns>
		public bool IsDown(MouseButton button) { return (this.buttons[(int)button] != InputType.Released); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public bool IsUp(MouseButton button) { return (this.buttons[(int)button] == InputType.Released); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the button is held down</returns>
		public bool IsHeldDown(MouseButton button) { return (this.buttons[(int)button] == InputType.Held); }
		
		/// <summary>Clears all the previous buttons</summary>
		public void ClearPreviousButtons() { this.prevButtons.Clear(); }
		
		#endregion // Public Methods
		
		#region Internal Methods
		
		/// <summary>Sets the amount of clicks done by a specific button</summary>
		/// <param name="button">The button to set how many clicks have been done</param>
		/// <param name="clicks">The amount of clicks to be set</param>
		public void SetClicks(MouseButton button, int clicks) { this.clicks[(int)button] = clicks; }
		
		#endregion // Internal Methods
	}
}

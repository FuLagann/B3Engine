
using System.Collections.Generic;

using Drawing = System.Drawing;

namespace B3 {
	/// <summary>A structure for holding the mouse input data</summary>
	public partial struct MouseState {
		#region Field Variables
		// Variables
		private Vector2 position;
		private float scroll;
		private int trackingAmount;
		private InputState[] buttons;
		private int[] clicks;
		private Queue<MouseButton> prevButtons;
		private bool isAnyButtonDown;
		private long[] timestamps;
		private System.IntPtr cursorHandle;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the mouse buttons that are pressed</summary>
		/// <param name="button">The mouse button to get or set the input type from/to</param>
		public InputState this[MouseButton button] { get { return this.buttons[(int)button]; } internal set {
			// Variables
			bool isPreviouslyUp = (this.buttons[(int)button] == InputState.Released);
			InputState setType = InputState.Released;
			
			if(this.buttons[(int)button] == InputState.Pressed && value == InputState.Pressed) {
				setType = InputState.Held;
			}
			else {
				setType = value;
			}
			
			if(setType == InputState.Released) {
				this.timestamps[(int)button] = 0;
			}
			this.buttons[(int)button] = setType;
			
			if(isPreviouslyUp && value == InputState.Pressed) {
				this.timestamps[(int)button] = System.DateTime.UtcNow.Ticks;
				this.prevButtons.Enqueue(button);
				if(this.prevButtons.Count > this.trackingAmount) {
					this.prevButtons.Dequeue();
				}
			}
		} }
		
		/// <summary>Gets the position of the mouse</summary>
		public Vector2 Position { get { return this.position; } internal set { this.position = value; } }
		
		/// <summary>Gets the scrolling of the mouse</summary>
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
		
		/// <summary>Gets if any buttons have been pressed or held down</summary>
		public bool IsAnyButtonDown { get { return this.isAnyButtonDown; } internal set { this.isAnyButtonDown = value; } }
		
		/// <summary>Gets the handle to the cursor</summary>
		public System.IntPtr CursorHandle { get { return this.cursorHandle; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for the mouse input structure</summary>
		/// <param name="trackingAmount">The amount of presses to keep track of</param>
		public MouseState(int trackingAmount) {
			this.position = Vector2.Zero;
			this.trackingAmount = trackingAmount;
			this.scroll = 0.0f;
			this.buttons = new InputState[System.Enum.GetNames(typeof(MouseButton)).Length - 1];
			this.prevButtons = new Queue<MouseButton>();
			this.isAnyButtonDown = false;
			this.timestamps = new long[this.buttons.Length];
			this.clicks = new int[this.buttons.Length];
			this.cursorHandle = System.IntPtr.Zero;
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
				this.buttons[i] = InputState.Released;
			}
			this.isAnyButtonDown = false;
		}
		
		/// <summary>Checks if the mouse is not pressed, to set the <see cref="B3.MouseState.IsAnyButtonDown"/> value</summary>
		public void CheckForClearing() {
			// Variables
			bool isClear = true;
			
			for(int i = 0; i < this.buttons.Length; i++) {
				if(this.buttons[i] != InputState.Released) {
					isClear = false;
					break;
				}
			}
			if(isClear) { this.isAnyButtonDown = false; }
			else { this.isAnyButtonDown = true; }
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
		public bool IsDown(MouseButton button) { return (this.buttons[(int)button] != InputState.Released); }
		
		/// <summary>Finds if the button is not pressed or held down</summary>
		/// <param name="button">The button to query if it's up</param>
		/// <returns>Returns true if the button is not pressed or held down</returns>
		public bool IsUp(MouseButton button) { return (this.buttons[(int)button] == InputState.Released); }
		
		/// <summary>Finds if the button is held down</summary>
		/// <param name="button">The button to query if it's held down</param>
		/// <returns>Returns true if the button is held down</returns>
		public bool IsHeldDown(MouseButton button) { return (this.buttons[(int)button] == InputState.Held); }
		
		/// <summary>Clears all the previous buttons</summary>
		public void ClearPreviousButtons() { this.prevButtons.Clear(); }
		
		/// <summary>Sets the cursor to the given system cursor</summary>
		/// <param name="type">The type of system cursor to set the cursor to</param>
		public void SetCursor(SystemCursorType type) { this.PartialSetCursor(type); }
		
		/// <summary>Sets the cursor to the given image via filepath</summary>
		/// <param name="filepath">The path to the file to use</param>
		/// <param name="x">The x coordintae of where the clicking would happen</param>
		/// <param name="y">The y coordintae of where the clicking would happen</param>
		public void SetCursor(string filepath, int x, int y) { this.PartialSetCursor(filepath, x, y); }
		
		#endregion // Public Methods
		
		#region Internal Methods
		
		/// <summary>Sets the amount of clicks done by a specific button</summary>
		/// <param name="button">The button to set how many clicks have been done</param>
		/// <param name="clicks">The amount of clicks to be set</param>
		internal void SetClicks(MouseButton button, int clicks) { this.clicks[(int)button] = clicks; }
		
		/// <summary>Sets the cursor for the mouse to use the handle</summary>
		/// <param name="cursor">The managed pointer to the cursor</param>
		internal void SetCursor(ref System.IntPtr cursor) { this.cursorHandle = cursor; }
		
		#endregion // Internal Methods
		
		#region Partial Methods
		
		/// <summary>A partial method that sets the cursor using a system cursor</summary>
		/// <param name="type">The type of system cursor to set the cursor</param>
		partial void PartialSetCursor(SystemCursorType type);
		
		/// <summary>A partial method that sets the cursor using an image via filepath</summary>
		/// <param name="filepath">The path to the file to read from</param>
		/// <param name="x">The x coordintae of where the clicking would happen</param>
		/// <param name="y">The y coordintae of where the clicking would happen</param>
		partial void PartialSetCursor(string filepath, int x, int y);
		
		/// <summary>A partial method that sets the cursor using an image</summary>
		/// <param name="image">The image to use</param>
		/// <param name="x">The x coordinate of where the clicking would happen</param>
		/// <param name="y">The y coordinate of where the clicking would happen</param>
		partial void PartialSetCursor(Drawing.Image image, int x, int y);
		
		#endregion // Partial Methods
	}
}

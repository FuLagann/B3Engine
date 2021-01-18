
using System.Collections.Generic;

namespace B3 {
	/// <summary>The state of the keyboard input</summary>
	public struct KeyboardState {
		#region Field Variables
		// Variables
		private InputType[] keys;
		private long[] timestamps;
		private Queue<Keys> prevKeys;
		private int trackingAmount;
		private bool isAnyKeyDown;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the input type from the given key</summary>
		/// <param name="key">The key to inquery</param>
		public InputType this[Keys key] { get { return this.keys[(int)key]; } internal set {
			// Variables
			bool isPreviouslyUp = (this.keys[(int)key] == InputType.Released);
			InputType setType = InputType.Released;
			
			if(this.keys[(int)key] == InputType.Pressed && value == InputType.Pressed) {
				setType = InputType.Held;
			}
			else {
				setType = value;
			}
			if(setType == InputType.Released) {
				this.timestamps[(int)key] = 0;
			}
			this.keys[(int)key] = setType;
			
			if(isPreviouslyUp && value == InputType.Pressed) {
				this.timestamps[(int)key] = System.DateTime.Now.Ticks;
				this.prevKeys.Enqueue(key);
				if(this.prevKeys.Count > this.trackingAmount) {
					this.prevKeys.Dequeue();
				}
			}
		} }
		
		/// <summary>Gets the previous keys that were pressed</summary>
		public Keys[] PreviousKeys { get { return this.prevKeys.ToArray(); } }
		
		/// <summary>Gets and sets how many keys to keep track of that were being pressed</summary>
		public int TrackingAmount { get { return this.trackingAmount; } set {
			this.trackingAmount = Mathx.Abs(value);
			while(this.prevKeys.Count > this.trackingAmount) {
				this.prevKeys.Dequeue();
			}
		} }
		
		/// <summary>Gets and sets if any keys have been pressed or held down</summary>
		public bool IsAnyKeyDown { get { return this.isAnyKeyDown; } internal set { this.isAnyKeyDown = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for created the keyboard input structure</summary>
		/// <param name="trackingAmount">The amount of keys to keep track of</param>
		public KeyboardState(int trackingAmount) {
			this.trackingAmount = Mathx.Abs(trackingAmount);
			this.keys = new InputType[System.Enum.GetNames(typeof(Keys)).Length - 1];
			this.prevKeys = new Queue<Keys>();
			this.isAnyKeyDown = false;
			this.timestamps = new long[this.keys.Length];
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Clears all the keys' presses</summary>
		public void Clear() {
			for(int i = 0; i < this.keys.Length; i++) {
				this.keys[i] = InputType.Released;
				this.timestamps[i] = 0;
			}
			this.isAnyKeyDown = false;
		}
		
		/// <summary>Checks if the keyboard is not pressed, to set the <see cref="B3.KeyboardState.IsAnyKeyDown"/> value</summary>
		public void CheckForClearing() {
			// Variables
			bool isClear = true;
			
			for(int i = 0; i < this.keys.Length; i++) {
				if(this.keys[i] != InputType.Released) {
					isClear = false;
					break;
				}
			}
			if(isClear) {
				this.isAnyKeyDown = false;
				for(int i = 0; i < this.timestamps.Length; i++) {
					this.timestamps[i] = 0;
				}
			}
		}
		
		/// <summary>Gets the amount of time spent holding down a specific key</summary>
		/// <param name="key">The key to see the duration for</param>
		/// <returns>Returns the timespan of the key being held down</returns>
		public System.TimeSpan GetHeldDuration(Keys key) {
			// Variables
			System.DateTime lastTime = (this.timestamps[(int)key] == 0 ?
				System.DateTime.Now :
				new System.DateTime(this.timestamps[(int)key])
			);
			System.TimeSpan timeSpan = (System.DateTime.Now - lastTime);
			
			return timeSpan;
		}
		
		/// <summary>Finds if the given key is pressed or held down</summary>
		/// <param name="key">The key to query if it's down</param>
		/// <returns>Returns true if the key is pressed or held down</returns>
		public bool IsDown(Keys key) { return (this.keys[(int)key] != InputType.Released); }
		
		/// <summary>Finds if the key is not pressed or held down</summary>
		/// <param name="key">The key to query if it's up</param>
		/// <returns>Returns true if the key is not pressed or held down</returns>
		public bool IsUp(Keys key) { return (this.keys[(int)key] == InputType.Released); }
		
		/// <summary>Finds if the key is held down</summary>
		/// <param name="key">The key to query if it's held down</param>
		/// <returns>Returns true if the key is held down</returns>
		public bool IsHeldDown(Keys key) { return (this.keys[(int)key] == InputType.Held); }
		
		/// <summary>Clears all the previous keys</summary>
		public void ClearPreviousKeys() { this.prevKeys.Clear(); }
		
		#endregion // Public Methods
	}
}

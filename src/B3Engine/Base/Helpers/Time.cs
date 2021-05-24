
namespace B3 {
	/// <summary>A helper class for time based things</summary>
	public static class Time {
		#region Field Variables
		// Variables
		private static float deltaTime = 0.0f;
		private static System.DateTime startTime = System.DateTime.UtcNow;
		private static float rate = 1.0f;
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets the time elapsed between frames</summary>
		public static float DeltaTime { get { return rate * deltaTime; } }
		
		/// <summary>Gets the total time spent between the start of the application and now in seconds</summary>
		public static float TotalTime { get { return (float)TotalTimeSpan.TotalSeconds; } }
		
		/// <summary>Gets the starting time of the application</summary>
		public static System.DateTime StartTime { get { return startTime; } }
		
		/// <summary>Gets the total time spent between the start of the application and now</summary>
		public static System.TimeSpan TotalTimeSpan { get { return (System.DateTime.UtcNow - startTime); } }
		
		/// <summary>Gets and sets the rate of time; setting to 1 would make time run normally, while setting to 0 would make time stop</summary>
		public static float Rate { get { return rate; } set { rate = value; } }
		
		#endregion // Public Static Properties
		
		#region Internal Static Methods
		
		// TODO: Set this to internal
		/// <summary>Sets the delta time, this is used internally; should not be used externally or timing gets messed up</summary>
		/// <param name="elapsedTime">The time elapsed between frames</param>
#if DEBUG
		public static void SetDeltaTime(float elapsedTime) { deltaTime = elapsedTime; }
#else
		internal static void SetDeltaTime(float elapsedTime) { deltaTime = elapsedTime; }
#endif
		
		#endregion // Internal Static Methods
	}
}

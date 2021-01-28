
using System.Threading;

namespace B3.Utilities {
	/// <summary>A helper class for initializing the SDL library</summary>
	internal static class SdlHelper {
		#region Field Variables
		// Variables
		private static Thread thread;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets if the current thread is on the main thread</summary>
		public static bool IsOnMainThread { get { return thread == Thread.CurrentThread; } }
		
		#endregion // Public Properties
		
		#region Public Static Methods
		
		/// <summary>Initializes the SDL library</summary>
		public static void Initialize() {
			if(thread != null) { return; }
			thread = Thread.CurrentThread;
			SDL.Init(SDL.InitFlags.Everything);
		}
		
		#endregion // Public Static Methods
	}
}

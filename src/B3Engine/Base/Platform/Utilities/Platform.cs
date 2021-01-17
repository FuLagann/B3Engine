
using System.Runtime.InteropServices;

namespace B3.Utilities {
	/// <summary>A static class for getting the operating system of the platform</summary>
	public static class Platform {
		#region Field Variables
		// Variables
		private static OS os;
		private static bool isInitialized;
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets the operating system of the platform</summary>
		public static OS OS { get {
			Initialize();
			return os;
		} }
		
		/// <summary>Gets the relative identifier of the platform</summary>
		public static string Rid {
			get {
				if(os == OS.Windows) { return $"win-x{(System.Environment.Is64BitProcess ? "64" : "86")}"; }
				else if(os == OS.Linux) { return "linux-x64"; }
				else if(os == OS.MacOSX) { return "osx"; }
				else { return "unknown"; }
			}
		}
		
		#endregion // Public Static Properties
		
		#region Private Constructors
		
		/// <summary>A static constructor that sets the variables</summary>
		static Platform() {
			isInitialized = false;
			os = OS.Unknown;
		}
		
		#endregion // Private Constructors
		
		#region Private Static External Methods
		
		[DllImport("libc")]
		private static extern int uname(System.IntPtr buffer);
		
		#endregion // Private Static External Methods
		
		#region Public Static Methods
		
		/// <summary>Initializes the platform information</summary>
		public static void Initialize() {
			if(isInitialized) { return; }
			
			// Variables
			System.PlatformID platform = System.Environment.OSVersion.Platform;
			
			switch(platform) {
				default: { os = OS.Unknown; } break;
				case System.PlatformID.Win32NT:
				case System.PlatformID.Win32S:
				case System.PlatformID.Win32Windows:
				case System.PlatformID.WinCE: {
					os = OS.Windows;
				} break;
				case System.PlatformID.MacOSX: { os = OS.MacOSX; } break;
				case System.PlatformID.Unix: {
					// Variables
					System.IntPtr buffer = System.IntPtr.Zero;
					
					os = OS.MacOSX;
					try {
						buffer = Marshal.AllocHGlobal(8192);
						
						if(uname(buffer) == 0 && Marshal.PtrToStringAnsi(buffer) == "Linux") {
							os = OS.Linux;
						}
					}
					catch {}
					finally {
						if(buffer != System.IntPtr.Zero) {
							Marshal.FreeHGlobal(buffer);
						}
					}
				} break;
				
			}
			
			isInitialized = true;
		}
		
		#endregion // Public Static Methods
	}
}

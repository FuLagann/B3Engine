
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace B3.Utilities {
	/// <summary>A static helper class that loads in functions from unmanaged code in a more streamlined way</summary>
	public unsafe static class FuncLoader {
		#region Public Static Methods
		
		/// <summary>Converts the managed pointer into a string</summary>
		/// <param name="handle">The managed pointer to convert</param>
		/// <returns>Returns the converted string</returns>
		public static unsafe string IntPtrToString(System.IntPtr handle) {
			if(handle == System.IntPtr.Zero) {
				return "";
			}
			
			// Variables
			byte* ptr = (byte*)handle;
			long len;
			byte[] bytes;
			
			while(*ptr != 0) {
				ptr++;
			}
			
			len = ptr - (byte*)handle;
			if(len == 0) {
				return "";
			}
			
			bytes = new byte[len];
			Marshal.Copy(handle, bytes, 0, bytes.Length);
			
			return Encoding.UTF8.GetString(bytes);
		}
		
		/// <summary>Loads in the unmanaged library</summary>
		/// <param name="libname">The name of the library</param>
		/// <returns>Returns the managed pointer to the library</returns>
		public static System.IntPtr LoadLibrary(string libname) {
			switch(Platform.OS) {
				default:
				case OS.Linux: return Linux.dlopen(libname, 0x0001);
				case OS.Windows: return Windows.LoadLibraryW(libname);
				case OS.MacOSX: return MacOSX.dlopen(libname, 0x0001);
			}
		}
		
		/// <summary>Loads in the unmanaged library with checking various locations</summary>
		/// <param name="libname">The name of the library</param>
		/// <returns>Returns the managed pointer to the library</returns>
		public static System.IntPtr LoadLibraryExt(string libname) {
			// Variables
			System.IntPtr results = System.IntPtr.Zero;
			string assemblyLocation = Path.GetDirectoryName(typeof(FuncLoader).Assembly.Location ?? "./");
			
			if(Platform.OS == OS.MacOSX) {
				results = LoadLibrary(Path.Combine(assemblyLocation, libname));
				if(results == System.IntPtr.Zero) {
					results = LoadLibrary(Path.Combine(assemblyLocation, "..", "Frameworks", libname));
				}
			}
			else {
				if(System.Environment.Is64BitProcess) {
					results = LoadLibrary(Path.Combine(assemblyLocation, "x64", libname));
				}
				else {
					results = LoadLibrary(Path.Combine(assemblyLocation, "x86", libname));
				}
			}
			
			if(results == System.IntPtr.Zero) {
				results = LoadLibrary(Path.Combine(assemblyLocation, "runtimes", Platform.Rid, "native", libname));
			}
			if(results == System.IntPtr.Zero) {
				results = LoadLibrary(Path.Combine(assemblyLocation, libname));
			}
			if(results == System.IntPtr.Zero) {
				results = LoadLibrary(Path.Combine(FS.BasePath, libname));
			}
			if(results == System.IntPtr.Zero) {
				results = LoadLibrary(libname);
			}
			if(results == System.IntPtr.Zero) {
				throw new System.Exception($"Failed load library [{libname}]");
			}
			
			return results;
		}
		
		/// <summary>Loads in a specific function from the given library</summary>
		/// <param name="library">The managed pointer of a library found from either <see cref="B3.Utilities.FuncLoader.LoadLibrary(string)"/> or <see cref="B3.Utilities.FuncLoader.LoadLibraryExt(string)"/></param>
		/// <param name="function">The name of the function to load from the library</param>
		/// <param name="throwIfNotFound">Set to true to throw if nothing is found. Defaults to false</param>
		/// <typeparam name="T">The type to return the function (delegate) as</typeparam>
		/// <returns>Returns the function found within the library</returns>
		public static T LoadFunc<T>(System.IntPtr library, string function, bool throwIfNotFound = false) {
			// Variables
			System.IntPtr results = System.IntPtr.Zero;
			
			if(Platform.OS == OS.Windows) {
				results = Windows.GetProcAddress(library, function);
			}
			else if(Platform.OS == OS.MacOSX) {
				results = MacOSX.dlsym(library, function);
			}
			else {
				results = Linux.dlsym(library, function);
			}
			
			if(results == System.IntPtr.Zero) {
				if(throwIfNotFound) {
					throw new System.Exception($"Entry point not found for function [{function}]");
				}
				
				return default(T);
			}
			
			return Marshal.GetDelegateForFunctionPointer<T>(results);
		}
		
		#endregion // Public Static Methods
		
		#region Nested Types
		
		private class Windows {
			#region Public External Methods
			
			[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
			public static extern System.IntPtr GetProcAddress(System.IntPtr hModule, string procName);
			
			[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
			public static extern System.IntPtr LoadLibraryW(string lpszLib);
			
			#endregion // Public External Methods
		}
		
		private class Linux {
			#region Public External Methods
			
			[DllImport("libdl.so.2")]
			public static extern System.IntPtr dlopen(string path, int flags);
			
			[DllImport("libdl.so.2")]
			public static extern System.IntPtr dlsym(System.IntPtr handle, string symbol);
			
			#endregion // Public External Methods
		}
		
		private class MacOSX {
			[DllImport("/usr/lib/libSystem.dylib")]
			public static extern System.IntPtr dlopen(string path, int flags);
			
			[DllImport("/usr/lib/libSystem.dylib")]
			public static extern System.IntPtr dlsym(System.IntPtr handle, string symbol);
		}
		
		#endregion // Nested Types
	}
}

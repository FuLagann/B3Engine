
using System.Runtime.InteropServices;
using System.Text;

using IntPtr = System.IntPtr;

namespace B3.Utilities {
	/// <summary>A class meant to specifically convert values</summary>
	public static partial class Convert {
		#region Public Static Methods
		
		/// <summary>Converts the managed pointer into a string</summary>
		/// <param name="handle">The managed pointer to convert</param>
		/// <returns>Returns the converted string</returns>
		public static unsafe string IntPtrToString(IntPtr handle) {
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
		
		/// <summary>Converts the array into a managed pointer</summary>
		/// <param name="arr">The array to convert</param>
		/// <param name="ptr">The managed pointer to return the data from</param>
		/// <typeparam name="T">The type of the array to convert</typeparam>
		public static void ArrayToIntPtr<T>(T[] arr, out IntPtr ptr) {
			// Variables
			int size = Marshal.SizeOf<T>() * arr.Length;
			long longPtr;
			
			ptr = Marshal.AllocHGlobal(size);
			longPtr = ptr.ToInt64();
			
			try {
				for(int i = 0; i < arr.Length; i++) {
					// Variables
					IntPtr tempPtr = new IntPtr(longPtr);
					
					Marshal.StructureToPtr<T>(arr[i], tempPtr, false);
					longPtr += Marshal.SizeOf<T>();
				}
			}
			finally { Marshal.FreeHGlobal(ptr); }
		}
		
		#endregion // Public Static Methods
	}
}

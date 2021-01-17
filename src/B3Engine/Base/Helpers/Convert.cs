
using System.Runtime.InteropServices;
using System.Text;

namespace B3.Utilities {
	/// <summary>A class meant to specifically convert values</summary>
	public static partial class Convert {
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
		
		
		#endregion // Public Static Methods
	}
}

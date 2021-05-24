
using System.IO;
using System.Runtime.InteropServices;

using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.FS"/> class to make sure it works correctly. Contains 16 tests</summary>
	public class FSTest {
		#region Field Variables
		// Variables
		private static readonly string WebFile = @"https://gist.githubusercontent.com/FuLagann/70cf9e17e55bdf2b6adf9f5a4c3b3383/raw/4ea86690918692a79d0f8cf5643b1b530f47a8b1/Testing.txt";
		private static readonly string WebExpected = (
			"Testing, Testing, 1, 2, 3\n" +
			"Checking to see if the external systems can scrape this file and read it\n" +
			"this is for testing purposes"
		);
		
		#endregion // Field Variables
		
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.FS.BasePath"/> functionality.
		/// Checks if the base path is the same as the directory where the binaries are found
		/// </summary>
		[Fact]
		public void BasePath_ReturnsBaseDirectoryOfBinary() {
			// Variables
			string expected = System.AppDomain.CurrentDomain.BaseDirectory;
			string actual = FS.BasePath;
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadFromWeb(string)"> functionality using the <see cref="B3.FS.Read(string)"/> method.
		/// Checks if the the file from the web is returned correctly
		/// </summary>
		[Fact]
		public void Read_FromWeb_ReturnsString() {
			// Variables
			string actual = FS.Read(FSTest.WebFile);
			
			Assert.Equal(FSTest.WebExpected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadStreamFromWeb(string)"> functionality using the <see cref="B3.FS.ReadStream(string)"/> method.
		/// Checks if the the file from the web is returned correctly via a stream
		/// </summary>
		[Fact]
		public void ReadStream_FromWeb_ReturnsString() {
			// Variables
			Stream expected = new MemoryStream();
			StreamWriter expectedWriter = new StreamWriter(expected);
			Stream actual = FS.ReadStream(FSTest.WebFile);
			StreamReader expectedReader;
			StreamReader actualReader;
			string expectedStr, actualStr;
			
			expectedWriter.Write(FSTest.WebExpected);
			expectedWriter.Flush();
			expected.Position = 0;
			expectedReader = new StreamReader(expected);
			actualReader = new StreamReader(actual);
			expectedStr = expectedReader.ReadToEnd();
			actualStr = actualReader.ReadToEnd();
			
			Assert.Equal(expectedStr, actualStr);
			
			expectedWriter.Close();
			expectedReader.Close();
			expected.Close();
			actualReader.Close();
			actual.Close();
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadFromFile(string)"> functionality using the <see cref="B3.FS.Read(string)"/> method.
		/// Checks if the the file from the local file system is returned correctly
		/// </summary>
		[Fact]
		public void Read_FromFile_ReturnsString() {
			// Variables
			string newline = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
			string expected = (
				"Testing. 1, 2, 3." + newline +
				"Checking to see if the external system can read from this." + newline +
				"This is for testing purposes."
			);
			string actual = FS.Read(@"assets/Testing.txt");
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadStreamFromFile(string)"> functionality using the <see cref="B3.FS.ReadStream(string)"/> method.
		/// Checks if the the file from the local file system is returned correctly via a stream
		/// </summary>
		[Fact]
		public void ReadStream_FromFile_ReturnsString() {
			// Variables
			string newline = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
			Stream expected = new MemoryStream();
			StreamWriter expectedWriter = new StreamWriter(expected);
			Stream actual = FS.ReadStream(@"assets/Testing.txt");
			StreamReader expectedReader;
			StreamReader actualReader;
			string expectedStr, actualStr;
			
			expectedWriter.Write(
				"Testing. 1, 2, 3." + newline +
				"Checking to see if the external system can read from this." + newline +
				"This is for testing purposes."
			);
			expectedWriter.Flush();
			expected.Position = 0;
			expectedReader = new StreamReader(expected);
			actualReader = new StreamReader(actual);
			expectedStr = expectedReader.ReadToEnd();
			actualStr = actualReader.ReadToEnd();
			
			Assert.Equal(expectedStr, actualStr);
			
			expectedWriter.Close();
			expectedReader.Close();
			expected.Close();
			actualReader.Close();
			actual.Close();
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadFromEmbedded(string)"> functionality using the <see cref="B3.FS.Read(string)"/> method.
		/// Checks if the the file from the embedded file system is returned correctly
		/// </summary>
		[Fact]
		public void Read_FromEmbedded_ReturnsString() {
			// Variables
			string newline = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
			string expected = (
				"Testing." + newline +
				"Checking to see if the external system can read from embedded files." + newline +
				"This is for testing purposes."
			);
			string actual = FS.Read(@"embedded://Testing.Embedded.txt");
			
			Assert.Equal(expected, actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.ReadStreamFromEmbedded(string)"> functionality using the <see cref="B3.FS.ReadStream(string)"/> method.
		/// Checks if the the file from the web is returned correctly
		/// </summary>
		[Fact]
		public void ReadStream_FromEmbedded_ReturnsString() {
			// Variables
			string newline = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
			Stream expected = new MemoryStream();
			StreamWriter expectedWriter = new StreamWriter(expected);
			Stream actual = FS.ReadStream(@"embedded://Testing.Embedded.txt");
			StreamReader expectedReader;
			StreamReader actualReader;
			string expectedStr, actualStr;
			
			expectedWriter.Write(
				"Testing." + newline +
				"Checking to see if the external system can read from embedded files." + newline +
				"This is for testing purposes."
			);
			expectedWriter.Flush();
			expected.Position = 0;
			expectedReader = new StreamReader(expected);
			actualReader = new StreamReader(actual);
			expectedStr = expectedReader.ReadToEnd();
			actualStr = actualReader.ReadToEnd();
			
			Assert.Equal(expectedStr, actualStr);
			
			expectedWriter.Close();
			expectedReader.Close();
			expected.Close();
			actualReader.Close();
			actual.Close();
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.FileExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file exists in the local file system
		/// </summary>
		[Fact]
		public void Exists_File_FindsRealFile() {
			Assert.True(FS.Exists(FS.BasePath + "assets/Testing.txt"));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.FileExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file does not exists in the local file system
		/// </summary>
		[Fact]
		public void Exists_File_DoesNotFindRealFile() {
			Assert.False(FS.Exists(FS.BasePath + "assets/Testing-NotReal.txt"));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.WebExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file exists on the web
		/// </summary>
		[Fact]
		public void Exists_Web_FindsRealFile() {
			Assert.True(FS.Exists(FSTest.WebFile));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.WebExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file does not exists on the web
		/// </summary>
		[Fact]
		public void Exists_Web_DoesNotFindRealFile() {
			Assert.False(FS.Exists(@"https://gist.githubusercontent.com/FuLagann/70cf9e17e55bdf2b6adf9f5a4c3b3383/raw/4ea86690918692a79d0f8cf5643b1b530f47a8b1/Testing-NotReal.txt"));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.EmbeddedExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file exists in the embedded file system
		/// </summary>
		[Fact]
		public void Exists_Embedded_FindsRealFile() {
			Assert.True(FS.Exists(@"embedded://Testing.Embedded.txt"));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.EmbeddedExists(string)"/> functionality using the <see cref="B3.FS.Exists(string)"/> method.
		/// Checks if the file does not exists in the embedded file system
		/// </summary>
		[Fact]
		public void Exists_Embedded_DoesNotFindRealFile() {
			Assert.False(FS.Exists(@"embedded://Testing.Embedded.NotReal.txt"));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.Write(string, string)"/> functionality.
		/// Checks if the the file gets written into the local file system
		/// </summary>
		[Fact]
		public void Write_File_ReturnsString() {
			// Variables
			string expected = "Testing...";
			string filename = @"assets/TestingWrite.txt";
			
			FS.Write(filename, expected);
			
			Assert.Equal(expected, FS.Read(filename));
			
			FS.Delete(filename);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.Delete(string)"/> functionality.
		/// Checks to see if the newly created file gets deleted
		/// </summary>
		[Fact]
		public void Delete_File_ReturnsTrue() {
			// Variables
			string filename = @"assets/TestingDelete_Real.txt";
			bool deleted;
			
			FS.Write(filename, "Testing...");
			deleted = FS.Delete(filename);
			
			Assert.True(deleted);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.FS.Delete(string)"/> functionality.
		/// Checks to see if it doesnt crash when trying to delete a non-existant file
		/// </summary>
		[Fact]
		public void Delete_File_ReturnsFalse() {
			// Variables
			string filename = @"assets/TestingDelete_Real.txt";
			bool deleted = FS.Delete(filename);
			
			Assert.False(deleted);
		}
		
		#endregion // Public Test Methods
	}
}


using System.Runtime.InteropServices;

using Xunit;

namespace B3.Testing {
	public class FSTest {
		[Fact]
		public void BasePath() {
			// Variables
			string expected = System.AppDomain.CurrentDomain.BaseDirectory;
			string actual = FS.BasePath;
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void ReadFromWeb() {
			// Variables
			string expected = (
				"Testing, Testing, 1, 2, 3\n" +
				"Checking to see if the external systems can scrape this file and read it\n" +
				"this is for testing purposes"
			);
			string actual = FS.Read(@"https://gist.githubusercontent.com/FuLagann/70cf9e17e55bdf2b6adf9f5a4c3b3383/raw/4ea86690918692a79d0f8cf5643b1b530f47a8b1/Testing.txt");
			
			Assert.Equal(expected, actual);
		}
		
		[Fact]
		public void ReadFromFile() {
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
		
		[Fact]
		public void ReadFromEmbedded() {
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
		
		[Fact]
		public void WriteAndDeleteFile() {
			// Variables
			string expected = "Testing...";
			string filename = @"assets/TestingWrite.txt";
			
			FS.Write(filename, expected);
			Assert.Equal(expected, FS.Read(filename));
			Assert.True(FS.Delete(filename));
			Assert.False(FS.Delete(filename));
		}
	}
}

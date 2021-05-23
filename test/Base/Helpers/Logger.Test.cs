
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Logger"/> class to make sure it works correctly. Contains 8 tests</summary>
	public class LoggerTest {
		#region Field Variables
		// Variables
		internal string actual;
		public const string Prefix = "[B3Engine.Base.Test|B3.Testing.LoggerTest]";
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		public LoggerTest() {
			this.actual = "";
			Logger.Output = new LoggerTestOutput(this);
		}
		
		~LoggerTest() {
			Logger.Output = new DefaultLoggerOutput();
		}
		
		#endregion // Public Constructors
		
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> functionality where it writes a new line.
		/// Writes a line to the logger and checks if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_WriteLine_ReturnsHelloWorld() {
			this.actual = "";
			Logger.Log("Hello World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> functionality where it doesn't write a new line.
		/// Writes some text and then writes a line and checks if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_Write_ReturnsHelloWorld() {
			this.actual = "";
			Logger.Log("Hello", false);
			Logger.Log("World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} HelloWorld!\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> color coding functionality.
		/// Writes some text in red and then writes some text with normal coloring and checks to see if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_WriteColorCodeWord_ReturnsRedHelloNormalWorld() {
			this.actual = "";
			Logger.Log("", false);
			Logger.Log("Hello", false, "red");
			Logger.Log(" World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} \\{{begin:red}}Hello\\{{end:red}} World!\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.OutputOnDebugOnly"/> and <see cref="B3.Logger.IsInDebugMode"/> functionality where debug mode is on.
		/// Turns on debug and debug only modes and writes a line and checks to see if anything is written
		/// </summary>
		[Fact]
		public void LogOnlyOnDebug_DebugOn_ReturnsString() {
			this.actual = "";
			Logger.OutputOnDebugOnly = true;
			Logger.IsInDebugMode = true;
			Logger.Log("Hello World!");
			Logger.OutputOnDebugOnly = false;
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.OutputOnDebugOnly"/> and <see cref="B3.Logger.IsInDebugMode"/> functionality where debug mode is off.
		/// Turns off debug and turns on debug only modes and writes a line and checks to see if nothing is written
		/// </summary>
		[Fact]
		public void LogOnlyOnDebug_DebugOff_ReturnsEmptyString() {
			this.actual = "";
			Logger.OutputOnDebugOnly = true;
			Logger.IsInDebugMode = false;
			Logger.Log("Hello World!");
			Logger.OutputOnDebugOnly = false;
			
			Assert.Equal("", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Info(object, bool, string)"/> functionality.
		/// Writes a line as an info log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Info_WriteLine_ReturnsInfoString() {
			this.actual = "";
			Logger.Info("Hello World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Warning(object, bool)"/> functionality.
		/// Writes a line as a warning log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Warning_WriteLine_ReturnsWarningString() {
			this.actual = "";
			Logger.Warning("Hello World!");
			
			Assert.Equal($"\\{{begin:yellow}}(WARNING) {LoggerTest.Prefix} Hello World!\\{{end:yellow}}\n", this.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Error(object, bool)"/> functionality.
		/// Writes a line as an error log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Error_WriteLine_ReturnsErrorString() {
			this.actual = "";
			Logger.Error("Hello World!");
			
			Assert.Equal($"\\{{begin:red}}(ERROR) {LoggerTest.Prefix} Hello World!\\{{end:red}}\n", this.actual);
		}
		
		#endregion // Public Test Methods
		
		#region Nested Objects
		
		private class LoggerTestOutput : ILoggerOutput {
			#region Field Variables
			// Variables
			public LoggerTest test;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			public LoggerTestOutput(LoggerTest test) {
				this.test = test;
			}
			
			#endregion // Public Constructors
			
			#region Public Methods
			
			public void WriteLine(string output) { test.actual += $"{output}\n"; }
			
			public void Write(string output) { test.actual += output; }
			
			public string ColorCodeStart(string colorName) {
				if(colorName == "") { return ""; }
				return $"\\{{begin:{colorName}}}";
			}
			
			public string ColorCodeEnd(string colorName) {
				if(colorName == "") { return ""; }
				return $"\\{{end:{colorName}}}";
			}
			
			#endregion // Public Methods
		}
		
		#endregion // Nested Objects
	}
}

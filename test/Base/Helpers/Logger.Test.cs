
using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Logger"/> class to make sure it works correctly. Contains 8 tests</summary>
	public class LoggerTest {
		#region Field Variables
		// Variables
		public const string Prefix = "[B3Engine.Base.Test|B3.Testing.LoggerTest]";
		
		#endregion // Field Variables
		
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> functionality where it writes a new line.
		/// Writes a line to the logger and checks if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_WriteLine_ReturnsHelloWorld() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.LogLocal("Hello World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> functionality where it doesn't write a new line.
		/// Writes some text and then writes a line and checks if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_Write_ReturnsHelloWorld() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.LogLocal("Hello", false);
			logger.LogLocal("World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} HelloWorld!\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Log(object, bool, string, LoggingType)"/> color coding functionality.
		/// Writes some text in red and then writes some text with normal coloring and checks to see if it gets written correctly
		/// </summary>
		[Fact]
		public void Log_WriteColorCodeWord_ReturnsRedHelloNormalWorld() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.LogLocal("", false);
			logger.LogLocal("Hello", false, "red");
			logger.LogLocal(" World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} \\{{begin:red}}Hello\\{{end:red}} World!\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.OutputOnDebugOnly"/> and <see cref="B3.Logger.IsInDebugMode"/> functionality where debug mode is on.
		/// Turns on debug and debug only modes and writes a line and checks to see if anything is written
		/// </summary>
		[Fact]
		public void LogOnlyOnDebug_DebugOn_ReturnsString() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.OutputOnDebugOnly = true;
			logger.IsInDebugMode = true;
			logger.LogLocal("Hello World!");
			logger.OutputOnDebugOnly = false;
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.OutputOnDebugOnly"/> and <see cref="B3.Logger.IsInDebugMode"/> functionality where debug mode is off.
		/// Turns off debug and turns on debug only modes and writes a line and checks to see if nothing is written
		/// </summary>
		[Fact]
		public void LogOnlyOnDebug_DebugOff_ReturnsEmptyString() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.OutputOnDebugOnly = true;
			logger.IsInDebugMode = false;
			logger.LogLocal("Hello World!");
			logger.OutputOnDebugOnly = false;
			
			Assert.Equal("", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Info(object, bool, string)"/> functionality.
		/// Writes a line as an info log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Info_WriteLine_ReturnsInfoString() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.InfoLocal("Hello World!");
			
			Assert.Equal($"(INFO) {LoggerTest.Prefix} Hello World!\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Warning(object, bool)"/> functionality.
		/// Writes a line as a warning log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Warning_WriteLine_ReturnsWarningString() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.WarningLocal("Hello World!");
			
			Assert.Equal($"\\{{begin:yellow}}(WARNING) {LoggerTest.Prefix} Hello World!\\{{end:yellow}}\n", output.actual);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Logger.Error(object, bool)"/> functionality.
		/// Writes a line as an error log and checks to see if its written correctly
		/// </summary>
		[Fact]
		public void Error_WriteLine_ReturnsErrorString() {
			// Variables
			Logger logger = new Logger();
			LoggerTestOutput output = new LoggerTestOutput();
			
			logger.Output = output;
			logger.ErrorLocal("Hello World!");
			
			Assert.Equal($"\\{{begin:red}}(ERROR) {LoggerTest.Prefix} Hello World!\\{{end:red}}\n", output.actual);
		}
		
		#endregion // Public Test Methods
		
		#region Nested Objects
		
		private class LoggerTestOutput : ILoggerOutput {
			#region Field Variables
			// Variables
			public string actual;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			public LoggerTestOutput() {
				this.actual = "";
			}
			
			#endregion // Public Constructors
			
			#region Public Methods
			
			public void WriteLine(string output) { this.actual += $"{output}\n"; }
			
			public void Write(string output) { this.actual += output; }
			
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

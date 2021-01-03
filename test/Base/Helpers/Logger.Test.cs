
using Xunit;

namespace B3.Testing {
	public class LoggerTest {
		// Variables
		internal string logContent;
		public const string prefix = "[B3Engine.Base.Test|B3.Testing.LoggerTest]";
		
		public LoggerTest() {
			this.logContent = "";
		}
		
		[Fact]
		public void Log() {
			// Variables
			string expected = (
				$"(INFO) {LoggerTest.prefix} Hello World!\n" +
				$"(INFO) {LoggerTest.prefix} Testing...Tested!\n" +
				$"(WARNING) {LoggerTest.prefix} Test Warning\n" +
				$"(ERROR) {LoggerTest.prefix} Test Error\n"
			);
			
			Logger.Output = new LoggerTestOutput(this);
			Logger.Log("Hello World!");
			Logger.Log("Testing...", false);
			Logger.Log("Tested!");
			Logger.Log("Test Warning", true, LoggingType.Warning);
			Logger.Log("Test Error", true, LoggingType.Error);
			Logger.Output = Logger.DefaultOutput;
			
			Assert.Equal(expected, this.logContent);
		}
		
		[Fact]
		public void LogOnlyOnDebug() {
			// Variables
			string expected = (
				$"(INFO) {LoggerTest.prefix} Logging on debug with restriction\n" +
				$"(INFO) {LoggerTest.prefix} Logging on production\n" +
				$"(INFO) {LoggerTest.prefix} Logging on debug\n"
			);
			
			Logger.Output = new LoggerTestOutput(this);
			Logger.OutputOnDebugOnly = true;
			Logger.IsInDebugMode = false;
			Logger.Log("Logging on production with restriction");
			Logger.IsInDebugMode = true;
			Logger.Log("Logging on debug with restriction");
			Logger.OutputOnDebugOnly = false;
			Logger.IsInDebugMode = false;
			Logger.Log("Logging on production");
			Logger.IsInDebugMode = true;
			Logger.Log("Logging on debug");
			Logger.IsInDebugMode = true;
			Logger.OutputOnDebugOnly = true;
			Logger.Output = Logger.DefaultOutput;
			
			Assert.Equal(expected, this.logContent);
		}
		
		[Theory]
		[InlineData("Hello World!")]
		[InlineData("Testing...Testing")]
		[InlineData("1234567890")]
		public void Info(string content) {
			// Variables
			string expected = $"(INFO) {LoggerTest.prefix} {content}\n";
			
			Logger.Output = new LoggerTestOutput(this);
			Logger.Info(content);
			Logger.Output = Logger.DefaultOutput;
			
			Assert.Equal(expected, this.logContent);
		}
		
		[Theory]
		[InlineData("Hello World!")]
		[InlineData("Testing...Testing")]
		[InlineData("1234567890")]
		public void Warning(string content) {
			// Variables
			string expected = $"(WARNING) {LoggerTest.prefix} {content}\n";
			
			Logger.Output = new LoggerTestOutput(this);
			Logger.Warning(content);
			Logger.Output = Logger.DefaultOutput;
			
			Assert.Equal(expected, this.logContent);
		}
		
		[Theory]
		[InlineData("Hello World!")]
		[InlineData("Testing...Testing")]
		[InlineData("1234567890")]
		public void Error(string content) {
			// Variables
			string expected = $"(ERROR) {LoggerTest.prefix} {content}\n";
			
			Logger.Output = new LoggerTestOutput(this);
			Logger.Error(content);
			Logger.Output = Logger.DefaultOutput;
			
			Assert.Equal(expected, this.logContent);
		}
		
		public class LoggerTestOutput : ILoggerOutput {
			// Variables
			private LoggerTest test;
			
			public LoggerTestOutput(LoggerTest test) {
				this.test = test;
				this.test.logContent = "";
			}
			
			public void WriteLine(string output) { test.logContent += $"{output}\n"; }
			
			public void Write(string output) { test.logContent += output; }
		}
	}
}

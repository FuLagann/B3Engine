
using System.Diagnostics;

namespace B3 {
	/// <summary>The logger that logs any information for debugging purposes</summary>
	public static class Logger {
		#region Field Variables
		// Variables
		private static ILoggerOutput output;
		private static int frameDistance;
		private static bool isPrevNewline;
		/// <summary>The default output that outputs to the <see cref="System.Console"/></summary>
		public static readonly ILoggerOutput DefaultOutput = new DefaultLoggerOutput();
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets and sets the output of the logger</summary>
		public static ILoggerOutput Output { get { return output; } set { output = value; } }
		
		/// <summary>Gets and sets if the logger should write to the output only when in debug mode</summary>
		public static bool OutputOnDebugOnly { get; set; }
		
		/// <summary>Gets and sets if the logger is in debug mode</summary>
		public static bool IsInDebugMode { get; set; }
		
		#endregion // Public Static Properties
		
		#region Public Static Constructors
		
		/// <summary>A static constructor to set the logger to be the default output if the output has not yet been specified</summary>
		static Logger() {
			if(output == null) {
				output = DefaultOutput;
			}
			frameDistance = 1;
			isPrevNewline = true;
			OutputOnDebugOnly = true;
			IsInDebugMode = true;
		}
		
		#endregion // Public Static Constructors
		
		#region Public Static Methods
		
		/// <summary>Logs the given object</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		/// <param name="loggingType">The type of log the report; either info, warning, or error</param>
		public static void Log(object obj, bool newline = true, LoggingType loggingType = LoggingType.Info) {
			if(OutputOnDebugOnly && !IsInDebugMode) {
				return;
			}
			
			// Variables
			StackFrame frame = (new StackTrace()).GetFrame(frameDistance);
			System.Reflection.MethodBase method = frame.GetMethod();
			System.Type type = method.DeclaringType;
			
			if(frame != null && method != null && type != null) {
				// Variables
				int lineNum = frame.GetFileLineNumber();
				string prefix = $"({ loggingType.ToString().ToUpper() }) [{ type.Assembly.GetName().Name }|{ type.ToString() }{ (lineNum > 0 ? "|" + lineNum : "") }]";
				
				if(obj == null) {
					if(isPrevNewline) {
						Write(newline, $"{prefix} Object presented is null");
					}
					else {
						Write(newline, "");
					}
				}
				else {
					if(isPrevNewline) {
						Write(newline, $"{prefix} {obj}");
					}
					else {
						Write(newline, obj.ToString());
					}
				}
			}
			else {
				// Variables
				string prefix = $"({ loggingType.ToString().ToUpper() })";
				
				if(obj == null) {
					if(isPrevNewline) {
						Write(newline, $"{prefix} ");
					}
					else {
						Write(newline, "");
					}
				}
				else {
					if(isPrevNewline) {
						Write(newline, $"{prefix} {obj}");
					}
					else {
						Write(newline, obj.ToString());
					}
				}
			}
			isPrevNewline = newline;
		}
		
		/// <summary>Logs the given object as informational</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public static void Info(object obj, bool newline = true) {
			frameDistance = 2;
			Log(obj, newline, LoggingType.Info);
			frameDistance = 1;
		}
		
		/// <summary>Logs the given object as a warning</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public static void Warning(object obj, bool newline = true) {
			frameDistance = 2;
			Log(obj, newline, LoggingType.Warning);
			frameDistance = 1;
		}
		
		/// <summary>Logs the given object as an error</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public static void Error(object obj, bool newline = true) {
			frameDistance = 2;
			Log(obj, newline, LoggingType.Error);
			frameDistance = 1;
		}
		
		#endregion // Public Static Methods
		
		#region Private Static Methods
		
		/// <summary>Writes the content to the output</summary>
		/// <param name="addNewline">Set to true to have the content write out to a new line</param>
		/// <param name="content">The content to write out</param>
		private static void Write(bool addNewline, string content) {
			if(addNewline) { output.WriteLine(content); }
			else { output.Write(content); }
		}
		
		#endregion // Private Static Methods
	}
}

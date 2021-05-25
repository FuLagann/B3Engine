
using System.Diagnostics;

namespace B3 {
	/// <summary>The logger that logs any information for debugging purposes</summary>
	public sealed class Logger {
		#region Field Variables
		// Variables
		private ILoggerOutput output;
		private int frameDistance;
		private bool isPrevNewline;
		private static readonly Logger instance = new Logger();
		/// <summary>The default output that outputs to the <see cref="System.Console"/></summary>
		public static readonly ILoggerOutput DefaultOutput = new DefaultLoggerOutput();
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets and sets the output of the logger</summary>
		public ILoggerOutput Output { get { return this.output; } set { this.output = value; } }
		
		/// <summary>Gets and sets if the logger should write to the output only when in debug mode</summary>
		public bool OutputOnDebugOnly { get; set; }
		
		/// <summary>Gets and sets if the logger is in debug mode</summary>
		public bool IsInDebugMode { get; set; }
		
		#endregion // Public Static Properties
		
		#region Public Constructors
		
		/// <summary>A debug constructor to test the logger's functionality</summary>
		public Logger() {
			this.output = DefaultOutput;
			this.frameDistance = 1;
			this.isPrevNewline = true;
			this.OutputOnDebugOnly = true;
			this.IsInDebugMode = true;
		}
		
		#endregion // Public Constructors
		
		#region Public Static Methods
		
		/// <summary>Logs the given object</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		/// <param name="colorName">The color to color code the message with</param>
		/// <param name="loggingType">The type of log the report; either info, warning, or error</param>
		public static void Log(object obj, bool newline = true, string colorName = "", LoggingType loggingType = LoggingType.Info) {
			instance.LogLocal(obj, newline, colorName, loggingType);
		}
		
		/// <summary>Logs the given object as informational</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		/// <param name="colorName">The color to color code the message with</param>
		public static void Info(object obj, bool newline = true, string colorName = "") {
			instance.InfoLocal(obj, newline, colorName);
		}
		
		/// <summary>Logs the given object as a warning</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public static void Warning(object obj, bool newline = true) {
			instance.WarningLocal(obj, newline);
		}
		
		/// <summary>Logs the given object as an error</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public static void Error(object obj, bool newline = true) {
			instance.ErrorLocal(obj, newline);
		}
		
		#endregion // Public Static Methods
		
		#region Public Methods
		
		/// <summary>Logs the given object</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		/// <param name="colorName">The color to color code the message with</param>
		/// <param name="loggingType">The type of log the report; either info, warning, or error</param>
		public void LogLocal(object obj, bool newline = true, string colorName = "", LoggingType loggingType = LoggingType.Info) {
			if(this.OutputOnDebugOnly && !this.IsInDebugMode) {
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
					if(this.isPrevNewline) {
						this.Write(newline, $"{prefix} Object presented is null", colorName);
					}
					else {
						this.Write(newline, "", colorName);
					}
				}
				else {
					if(this.isPrevNewline) {
						this.Write(newline, $"{prefix} {obj}", colorName);
					}
					else {
						this.Write(newline, obj.ToString(), colorName);
					}
				}
			}
			else {
				// Variables
				string prefix = $"({ loggingType.ToString().ToUpper() })";
				
				if(obj == null) {
					if(this.isPrevNewline) {
						this.Write(newline, $"{prefix} ", colorName);
					}
					else {
						this.Write(newline, "", colorName);
					}
				}
				else {
					if(this.isPrevNewline) {
						this.Write(newline, $"{prefix} {obj}", colorName);
					}
					else {
						this.Write(newline, obj.ToString(), colorName);
					}
				}
			}
			this.isPrevNewline = newline;
		}
		
		/// <summary>Logs the given object as informational</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		/// <param name="colorName">The color to color code the message with</param>
		public void InfoLocal(object obj, bool newline = true, string colorName = "") {
			this.frameDistance = 2;
			this.LogLocal(obj, newline, colorName, LoggingType.Info);
			this.frameDistance = 1;
		}
		
		/// <summary>Logs the given object as a warning</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public void WarningLocal(object obj, bool newline = true) {
			this.frameDistance = 2;
			this.LogLocal(obj, newline, "yellow", LoggingType.Warning);
			this.frameDistance = 1;
		}
		
		/// <summary>Logs the given object as an error</summary>
		/// <param name="obj">The object to log</param>
		/// <param name="newline">Set to true if you want the log to create a new line afterwards</param>
		public void ErrorLocal(object obj, bool newline = true) {
			this.frameDistance = 2;
			this.LogLocal(obj, newline, "red", LoggingType.Error);
			this.frameDistance = 1;
		}
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>Writes the content to the output</summary>
		/// <param name="addNewline">Set to true to have the content write out to a new line</param>
		/// <param name="content">The content to write out</param>
		/// <param name="color">The name of the color to use on the message</param>
		private void Write(bool addNewline, string content, string color) {
			if(addNewline) {
				this.output.WriteLine(
					this.output.ColorCodeStart(color) +
					content +
					this.output.ColorCodeEnd(color)
				);
			}
			else {
				this.output.Write(
					this.output.ColorCodeStart(color) +
					content +
					this.output.ColorCodeEnd(color)
				);
			}
		}
		
		#endregion // Private Methods
	}
}

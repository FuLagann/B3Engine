
namespace B3 {
	/// <summary>The default logger output that writes to the <see cref="System.Console"/></summary>
	public sealed class DefaultLoggerOutput : ILoggerOutput {
		#region Public Methods
		
		/// <summary>Writes to the output with a newline at the end</summary>
		/// <param name="output">The string to output</param>
		public void WriteLine(string output) {
			System.Console.WriteLine(output);
			System.Console.ForegroundColor = System.ConsoleColor.Gray;
		}
		
		/// <summary>Writes to the output without a newline at the end</summary>
		/// <param name="output">The string to output</param>
		public void Write(string output) {
			System.Console.Write(output);
			System.Console.ForegroundColor = System.ConsoleColor.Gray;
		}
		
		/// <summary>Starts coloring the log message</summary>
		/// <param name="colorName">The name of the color to color code the message with</param>
		public string ColorCodeStart(string colorName) {
			// Variables
			System.ConsoleColor ccolor = System.ConsoleColor.Gray;
			
			switch(colorName.ToLower()) {
				case "black": { ccolor = System.ConsoleColor.Black; } break;
				case "blue": { ccolor = System.ConsoleColor.Blue; } break;
				case "cyan": { ccolor = System.ConsoleColor.Cyan; } break;
				case "darkblue": { ccolor = System.ConsoleColor.DarkBlue; } break;
				case "darkcyan": { ccolor = System.ConsoleColor.DarkCyan; } break;
				case "darkgray": { ccolor = System.ConsoleColor.DarkGray; } break;
				case "darkgreen": { ccolor = System.ConsoleColor.DarkGreen; } break;
				case "darkmagenta": { ccolor = System.ConsoleColor.DarkMagenta; } break;
				case "darkred": { ccolor = System.ConsoleColor.DarkRed; } break;
				case "darkyellow": { ccolor = System.ConsoleColor.DarkYellow; } break;
				case "gray": { ccolor = System.ConsoleColor.Gray; } break;
				case "green": { ccolor = System.ConsoleColor.Green; } break;
				case "magenta": { ccolor = System.ConsoleColor.Magenta; } break;
				case "red": { ccolor = System.ConsoleColor.Red; } break;
				case "white": { ccolor = System.ConsoleColor.White; } break;
				case "yellow": { ccolor = System.ConsoleColor.Yellow; } break;
			}
			
			System.Console.ForegroundColor = ccolor;
			
			return "";
		}
		
		/// <summary>Ends coloring the log message</summary>
		/// <param name="colorName">The name of the color to color code the message with</param>
		public string ColorCodeEnd(string colorName) { return ""; }
		
		#endregion // Public Methods
	}
}

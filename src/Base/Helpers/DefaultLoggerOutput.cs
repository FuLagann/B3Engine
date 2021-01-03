
namespace B3 {
	/// <summary>The default logger output that writes to the <see cref="System.Console"/></summary>
	public sealed class DefaultLoggerOutput : ILoggerOutput {
		#region Public Methods
		
		/// <summary>Writes to the output with a newline at the end</summary>
		/// <param name="output">The string to output</param>
		public void WriteLine(string output) { System.Console.WriteLine(output); }
		
		/// <summary>Writes to the output without a newline at the end</summary>
		/// <param name="output">The string to output</param>
		public void Write(string output) { System.Console.Write(output); }
		
		#endregion // Public Methods
	}
}

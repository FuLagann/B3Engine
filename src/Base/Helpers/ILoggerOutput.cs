
namespace B3 {
	/// <summary>An interface for an output for the <see cref="B3.Logger"/></summary>
	public interface ILoggerOutput {
		#region Methods
		
		/// <summary>Writes to the output with a newline at the end</summary>
		/// <param name="output">The string to output</param>
		void WriteLine(string output);
		
		/// <summary>Writes to the output without a newline at the end</summary>
		/// <param name="output">The string to output</param>
		void Write(string output);
		
		#endregion // Methods
	}
}

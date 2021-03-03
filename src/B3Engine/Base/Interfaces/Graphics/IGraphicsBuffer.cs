
namespace B3.Graphics {
	/// <summary>An interface for a graphics buffer in general</summary>
	public interface IGraphicsBuffer : System.IDisposable {
		#region Properties
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		int Handle { get; }
		
		#endregion // Properties
		
		#region Methods
		
		/// <summary>Binds the buffer to use</summary>
		void Bind();
		
		/// <summary>Buffers the data</summary>
		void Buffer();
		
		#endregion // Methods
	}
}

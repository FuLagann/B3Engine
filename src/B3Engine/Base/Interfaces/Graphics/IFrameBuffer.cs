
using B3.Events;

namespace B3.Graphics {
	/// <summary>An interface for creating a frame buffer, used for post-processing and creating render textures</summary>
	public interface IFrameBuffer : IGraphicsBuffer {
		#region Properties
		
		/// <summary>Gets and sets the level of MSAA (used for anti-aliasing)</summary>
		int MsaaLevel { get; set; }
		
		/// <summary>Gets and sets the width of the frame buffer, typically set by the window's width</summary>
		int Width { get; set; }
		
		/// <summary>Gets and sets the height of the frame buffer, typically set by the window's height</summary>
		int Height { get; set; }
		
		/// <summary>Gets the render texture created by the frame buffer</summary>
		ITexture RenderTexture { get; }
		
		#endregion // Properties
		
		#region Events
		
		/// <summary>An event for when the frame gets rendered; anything in this event will get rendered into the frame buffer instead</summary>
		event EventHandler<EventArgs> OnRender;
		
		#endregion // Events
	}
}


using B3.Utilities;

using Drawing = System.Drawing;

namespace B3 {
	public partial struct MouseState {
		#region Partial Methods
		
		/// <summary>A partial method that sets the cursor using a system cursor</summary>
		/// <param name="type">The type of system cursor to set the cursor</param>
		partial void PartialSetCursor(SystemCursorType type) {
			SDL.FreeCursor(this.cursorHandle);
			this.cursorHandle = SDL.CreateSystemCursor(type);
			SDL.SetCursor(this.cursorHandle);
		}
		
		/// <summary>A partial method that sets the cursor using an image via filepath</summary>
		/// <param name="filepath">The path to the file to read from</param>
		/// <param name="x">The x coordintae of where the clicking would happen</param>
		/// <param name="y">The y coordintae of where the clicking would happen</param>
		partial void PartialSetCursor(string filepath, int x, int y) {
			SDL.FreeCursor(this.cursorHandle);
			this.cursorHandle = SDL.CreateColorCursor(SDL.LoadBitmap(filepath), x, y);
			SDL.SetCursor(this.cursorHandle);
		}
		
		/// <summary>A partial method that sets the cursor using an image</summary>
		/// <param name="image">The image to use</param>
		/// <param name="x">The x coordinate of where the clicking would happen</param>
		/// <param name="y">The y coordinate of where the clicking would happen</param>
		partial void PartialSetCursor(Drawing.Image image, int x, int y) {
			SDL.FreeCursor(this.cursorHandle);
			this.cursorHandle = SDL.CreateColorCursor(SDL.LoadBitmap(image), x, y);
			SDL.SetCursor(this.cursorHandle);
		}
		
		#endregion // Partial Methods
	}
}

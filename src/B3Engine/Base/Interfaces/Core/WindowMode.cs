
namespace B3 {
	/// <summary>The enumeration of which modes the window can be</summary>
	public enum WindowMode : byte {
		/// <summary>Set the window in normal window mode, able to use <see cref="B3.IGameWindow.AllowResize"/></summary>
		Windowed,
		/// <summary>Set the window to be maximized and borderless, should be the same as fullscreen but with a better way of tabbing out</summary>
		BorderlessFullscreen,
		/// <summary>Sets the window to be fullscreen</summary>
		Fullscreen
	}
}

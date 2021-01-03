
namespace B3.Events {
	/// <summary>An event handler for use within the engine that uses an <see cref="B3.Events.EventArgs"/> as its only parameter</summary>
	/// <param name="args">The event arguments for the callback to use</param>
	/// <typeparam name="T">The type of arguments it will be set to, must be derived from <see cref="B3.Events.EventArgs"/></typeparam>
	public delegate void EventHandler<T>(T args) where T : EventArgs;
}

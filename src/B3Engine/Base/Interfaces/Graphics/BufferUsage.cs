
namespace B3.Graphics {
	/// <summary>An enumeration of all the different type of usages a vertex buffer can do</summary>
	public enum BufferUsage {
		/// <summary>
		/// The data stores contents that will be modified once and used at most a few times.
		/// The contents are also modified by the application and used as the source for
		/// the graphics library to draw and image specific commands
		/// </summary>
		StreamDraw,
		/// <summary>
		/// The data stores contents that will be modified once and used at most a few times.
		/// The contents are also modified by reading data from the graphics library and used
		/// to return that data when queried by the application
		/// </summary>
		StreamRead,
		/// <summary>
		/// The data stores contents that will be modified once and used at most a few times.
		/// The contents are also modified by reading data from the graphics library and used
		/// as the source for drawing and image specific commands.
		/// </summary>
		StreamCopy,
		/// <summary>
		/// The data stores contents that will be modified once and used many times.
		/// The contents are also modified by the application and used as the source for
		/// the graphics library to draw and image specific commands
		/// </summary>
		StaticDraw,
		/// <summary>
		/// The data stores contents that will be modified once and used many times.
		/// The contents are also modified by reading data from the graphics library and used
		/// to return that data when queried by the application
		/// </summary>
		StaticRead,
		/// <summary>
		/// The data stores contents that will be modified once and used many times.
		/// The contents are also modified by reading data from the graphics library and used
		/// as the source for drawing and image specific commands.
		/// </summary>
		StaticCopy,
		/// <summary>
		/// The data stores contents that will be modified repeatedly and used many times.
		/// The contents are also modified by the application and used as the source for
		/// the graphics library to draw and image specific commands
		/// </summary>
		DynamicDraw,
		/// <summary>
		/// The data stores contents that will be modified repeatedly and used many times.
		/// The contents are also modified by reading data from the graphics library and used
		/// to return that data when queried by the application
		/// </summary>
		DynamicRead,
		/// <summary>
		/// The data stores contents that will be modified repeatedly and used many times.
		/// The contents are also modified by reading data from the graphics library and used
		/// as the source for drawing and image specific commands.
		/// </summary>
		DynamicCopy
	}
}

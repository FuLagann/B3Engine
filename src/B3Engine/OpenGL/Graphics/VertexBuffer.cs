
using OpenTK.Graphics.OpenGL;

using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex buffer that holds data about the vertices for OpenGL to use</summary>
	public class VertexBuffer<T> : IVertexBuffer<T> where T : struct {
		#region Field Variables
		// Variables
		private T[] vertices;
		private BufferUsage type;
		private readonly int BufferId;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets if the vertex buffer is static</summary>
		public bool IsStatic { get {
			return (
				type != BufferUsage.DynamicCopy
				&& type != BufferUsage.DynamicDraw
				&& type != BufferUsage.DynamicRead
			);
		} }
		
		/// <summary>Gets and sets the type of usage</summary>
		public BufferUsage BufferUsageType { get { return this.type; } set { this.type = value; } }
		
		/// <summary>Gets and sets the data within the buffer</summary>
		public T[] Vertices { get { return this.vertices; } set {
			if(this.IsStatic || value == null) {
				Logger.Warning(this.IsStatic ?
					"Vertex buffer is static but trying to be modified" :
					"Vertex buffer is trying to be modified with a null array"
				);
				return;
			}
			this.vertices = value;
			this.Bind();
			this.Buffer();
		} }
		
		/// <summary>Gets the id handle of the buffer that gets generated and used by the graphics library</summary>
		public int Handle { get { return this.BufferId; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex buffer</summary>
		/// <param name="vertices">The list of vertices used to populate the buffer with</param>
		/// <param name="type">The type of usage the buffer will be used for</param>
		public VertexBuffer(T[] vertices, BufferUsage type) {
			this.vertices = vertices ?? new T[0];
			this.type = type;
			this.BufferId = GL.GenBuffer();
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() { GL.BindBuffer(BufferTarget.ArrayBuffer, this.Handle); }
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {
			GL.BufferData(
				BufferTarget.ArrayBuffer,
				this.vertices.Length * Marshal.SizeOf<T>(),
				this.vertices,
				this.ToOpenGL(this.type)
			);
		}
		
		/// <summary>Disposes of the buffer</summary>
		public void Dispose() { GL.DeleteBuffer(this.Handle); }
		
		#endregion // Public Methods
		
		#region Private Methods
		
		/// <summary>An extension to convert the <see cref="B3.Graphics.BufferUsage"/> to the OpenTK BufferUsageHint</summary>
		/// <param name="type">The buffer usage enum to convert</param>
		/// <returns>Returns a OpenTK version of the buffer usage to use</returns>
		private BufferUsageHint ToOpenGL(BufferUsage type) {
			switch(type) {
				default:
				case BufferUsage.StaticDraw: return BufferUsageHint.StaticDraw;
				case BufferUsage.StaticRead: return BufferUsageHint.StaticRead;
				case BufferUsage.StaticCopy: return BufferUsageHint.StaticCopy;
				case BufferUsage.StreamCopy: return BufferUsageHint.StreamCopy;
				case BufferUsage.StreamDraw: return BufferUsageHint.StreamDraw;
				case BufferUsage.StreamRead: return BufferUsageHint.StreamRead;
				case BufferUsage.DynamicCopy: return BufferUsageHint.DynamicCopy;
				case BufferUsage.DynamicDraw: return BufferUsageHint.DynamicDraw;
				case BufferUsage.DynamicRead: return BufferUsageHint.DynamicRead;
			}
		}
		
		#endregion // Private Methods
	}
}

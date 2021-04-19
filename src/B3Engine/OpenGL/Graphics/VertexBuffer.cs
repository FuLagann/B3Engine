
using B3.Events;

using OpenTK.Graphics.OpenGL;

using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex buffer that holds data about the vertices for OpenGL to use</summary>
	/// <typeparam name="T">The data type of the vertex, needs to be a struct</typeparam>
	public sealed class VertexBuffer<T> : IVertexBuffer<T> where T : struct {
		#region Field Variables
		// Variables
		private T[] vertices;
		private BufferUsage type;
		private int handle;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets the size of the buffer</summary>
		public int Count { get { return this.vertices.Length; } }
		
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
		public int Handle { get { return this.handle; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex buffer</summary>
		/// <param name="game">The game to check if it's initialized or not and generate the buffer appropriately</param>
		/// <param name="vertices">The list of vertices used to populate the buffer with</param>
		/// <param name="type">The type of usage the buffer will be used for</param>
		public VertexBuffer(IGame game, T[] vertices, BufferUsage type) {
			this.vertices = vertices ?? new T[0];
			this.type = type;
			if(game == null || game.IsWindowInitialized) {
				this.handle = GL.GenBuffer();
			}
			else {
				game.OnLoad += () => {
					this.handle = GL.GenBuffer();
				};
			}
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Binds the buffer to use</summary>
		public void Bind() { GL.BindBuffer(BufferTarget.ArrayBuffer, this.Handle); }
		
		/// <summary>Buffers the data</summary>
		public void Buffer() {
			GL.BufferData(
				BufferTarget.ArrayBuffer,
				this.Count * Marshal.SizeOf<T>(),
				this.vertices,
				this.type.ToOpenGL()
			);
		}
		
		/// <summary>Disposes of the buffer</summary>
		public void Dispose() { GL.DeleteBuffer(this.Handle); }
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			if(this.vertices != null && this.vertices.Length > 0 && this.vertices[0] is IVertexAttributable) {
				// Variables
				IVertexAttributable attr = this.vertices[0] as IVertexAttributable;
				
				return attr.GetVertexAttributes();
			}
			
			return new VertexAttributeData[0];
		}
		
		#endregion // Public Methods
	}
}

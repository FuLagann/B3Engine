
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 2D position and a texture coordinate</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2PT {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector2 position;
		/// <summary>The texture coordinate of the vertex</summary>
		public Vector2 texcoord;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 2D position and a texture coordinate</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="texcoord">The texture coordinate of the vertex</param>
		public Vertex2PT(Vector2 position, Vector2 texcoord) {
			this.position = position;
			this.texcoord = texcoord;
		}
		
		#endregion // Public Constructors
	}
}


using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 2D position, a texture coordinate, and a normal</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2PTN {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector2 position;
		/// <summary>The texture coordinate of the vertex</summary>
		public Vector2 texcoord;
		/// <summary>The normal of the vertex</summary>
		public Vector2 normal;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 2D position, a texture coordinate, and a normal</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="texcoord">The texture coordinate of the vertex</param>
		/// <param name="normal">The normal of the vertex</param>
		public Vertex2PTN(Vector2 position, Vector2 texcoord, Vector2 normal) {
			this.position = position;
			this.texcoord = texcoord;
			this.normal = normal;
		}
		
		#endregion // Public Constructors
	}
}

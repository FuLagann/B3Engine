
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 3D position, a color, and a texture coordinate</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex3PCT {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector3 position;
		/// <summary>The color of the vertex</summary>
		public Color color;
		/// <summary>The texture coordinate of the vertex</summary>
		public Vector2 texcoord;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 3D position, a color, and a texture coordinate</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="color">The color of the vertex</param>
		/// <param name="texcoord">The texture coordinate of the vertex</param>
		public Vertex3PCT(Vector3 position, Color color, Vector2 texcoord) {
			this.position = position;
			this.color = color;
			this.texcoord = texcoord;
		}
		
		#endregion // Public Constructors
	}
}

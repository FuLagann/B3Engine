
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 2D position and a color</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2PC {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector2 position;
		/// <summary>The color of the vertex</summary>
		public Color color;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 2D position and a color</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="color">The color of the vertex</param>
		public Vertex2PC(Vector2 position, Color color) {
			this.position = position;
			this.color = color;
		}
		
		#endregion // Public Constructors
	}
}

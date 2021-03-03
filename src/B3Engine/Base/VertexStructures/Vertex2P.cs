
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 2D position</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2P : IVertexAttributable {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector2 position;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 2D position</summary>
		/// <param name="position">The position of the vertex</param>
		public Vertex2P(Vector2 position) {
			this.position = position;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() { return this.position.GetVertexAttributes(); }
		
		#endregion // Public Methods
	}
}

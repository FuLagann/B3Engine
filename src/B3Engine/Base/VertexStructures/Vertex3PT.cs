
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 3D position and a texture coordinate</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex3PT : IVertexAttributable {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector3 position;
		/// <summary>The texture coordinate of the vertex</summary>
		public Vector2 texcoord;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 3D position and a texture coordinate</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="texcoord">The texture coordinate of the vertex</param>
		public Vertex3PT(Vector3 position, Vector2 texcoord) {
			this.position = position;
			this.texcoord = texcoord;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			// Variables
			List<VertexAttributeData> data = new List<VertexAttributeData>();
			
			data.AddRange(this.position.GetVertexAttributes());
			data.AddRange(this.texcoord.GetVertexAttributes());
			
			return data.ToArray();
		}
		
		#endregion // Public Methods
	}
}

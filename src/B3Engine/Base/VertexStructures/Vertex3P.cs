
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace B3.Graphics {
	/// <summary>A vertex structure that holds a 3D position</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex3P : IVertexAttributable {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector3 position;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 3D position</summary>
		/// <param name="position">The position of the vertex</param>
		public Vertex3P(Vector3 position) {
			this.position = position;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			// Variables
			List<VertexAttributeData> data = new List<VertexAttributeData>();
			
			data.AddRange(this.position.GetVertexAttributes());
			
			return data.ToArray();
		}
		
		#endregion // Public Methods
	}
}

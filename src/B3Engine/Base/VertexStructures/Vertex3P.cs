
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace B3.Graphics.VertexStructures {
	/// <summary>A vertex structure that holds a 3D position</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex3P : IVertexAttributable, IConvertable<Vertex3PC>, IConvertable<Vertex3PCTN> {
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
		
		#region Methods
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PC IConvertable<Vertex3PC>.Convert() { return new Vertex3PC(this.position, Color.White); }
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PCTN IConvertable<Vertex3PCTN>.Convert() { return new Vertex3PCTN(this.position, Color.White, Vector2.Zero, Vector3.Zero); }
		
		#endregion // Methods
	}
}

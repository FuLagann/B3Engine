
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace B3.Graphics.VertexStructures {
	/// <summary>A vertex structure that holds a 3D position and a color</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex3PC : IVertexAttributable, IConvertable<Vertex3PC>, IConvertable<Vertex3PCTN> {
		#region Field Variables
		// Variables
		/// <summary>The position of the vertex</summary>
		public Vector3 position;
		/// <summary>The color of the vertex</summary>
		public Color color;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating a vertex with a 3D position and a color</summary>
		/// <param name="position">The position of the vertex</param>
		/// <param name="color">The color of the vertex</param>
		public Vertex3PC(Vector3 position, Color color) {
			this.position = position;
			this.color = color;
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		public VertexAttributeData[] GetVertexAttributes() {
			// Variables
			List<VertexAttributeData> data = new List<VertexAttributeData>();
			
			data.AddRange(this.position.GetVertexAttributes());
			data.AddRange(this.color.GetVertexAttributes());
			
			return data.ToArray();
		}
		
		#endregion // Public Methods
		
		#region Methods
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PC IConvertable<Vertex3PC>.Convert() { return this; }
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PCTN IConvertable<Vertex3PCTN>.Convert() { return new Vertex3PCTN(this.position, this.color, Vector2.Zero, Vector3.Zero); }
		
		#endregion // Methods
	}
}

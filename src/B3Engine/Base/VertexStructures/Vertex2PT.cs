
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace B3.Graphics.VertexStructures {
	/// <summary>A vertex structure that holds a 2D position and a texture coordinate</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex2PT : IVertexAttributable, IConvertable<Vertex3PC>, IConvertable<Vertex3PCTN> {
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
		
		#region Methods
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PC IConvertable<Vertex3PC>.Convert() { return new Vertex3PC(this.position.ToVector3(), Color.White); }
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		Vertex3PCTN IConvertable<Vertex3PCTN>.Convert() { return new Vertex3PCTN(this.position.ToVector3(), Color.White, this.texcoord, Vector3.Zero); }
		
		#endregion // Methods
	}
}

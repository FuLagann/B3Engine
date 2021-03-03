
namespace B3.Graphics {
	/// <summary>A structor for setting up the vertex attribute data</summary>
	public struct VertexAttributeData {
		#region Field Variables
		// Variables
		/// <summary>The number of components in the attribute, must be 1, 2, 3, or 4</summary>
		public int size;
		/// <summary>The data type of the attribute</summary>
		public VertexAttributeDataType dataType;
		/// <summary>Set to true to normalize the points attribute</summary>
		public bool isNormalized;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating the vertex attribute data</summary>
		/// <param name="size">The number of components in the attribute, must be 1, 2, 3, or 4</param>
		/// <param name="dataType">The data type of the attribute</param>
		/// <param name="isNormalized">Set to true to normalize the attribute</param>
		public VertexAttributeData(int size, VertexAttributeDataType dataType, bool isNormalized) {
			this.size = size;
			this.dataType = dataType;
			this.isNormalized = isNormalized;
		}
		
		#endregion // Public Constructors
	}
}


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
		/// <summary>The size in bytes to skip over this attribute</summary>
		public int stride;
		
		#endregion // Field Variables
		
		#region Public Constructors
		
		/// <summary>A base constructor for creating the vertex attribute data</summary>
		/// <param name="size">The number of components in the attribute, must be 1, 2, 3, or 4</param>
		/// <param name="dataType">The data type of the attribute</param>
		/// <param name="isNormalized">Set to true to normalize the attribute</param>
		public VertexAttributeData(int size, VertexAttributeDataType dataType, bool isNormalized) {
			this.dataType = dataType;
			this.isNormalized = isNormalized;
			this.size = size;
			this.stride = 1;
			
			switch(dataType) {
				case VertexAttributeDataType.Byte: this.stride = sizeof(sbyte); break;
				case VertexAttributeDataType.UByte: this.stride = sizeof(byte); break;
				case VertexAttributeDataType.Short: this.stride = sizeof(short); break;
				case VertexAttributeDataType.UShort: this.stride = sizeof(ushort); break;
				case VertexAttributeDataType.Int: this.stride = sizeof(int); break;
				case VertexAttributeDataType.UInt: this.stride = sizeof(uint); break;
				case VertexAttributeDataType.Float: this.stride = sizeof(float); break;
				case VertexAttributeDataType.Double: this.stride = sizeof(double); break;
			}
			this.stride *= size;
		}
		
		#endregion // Public Constructors
	}
}

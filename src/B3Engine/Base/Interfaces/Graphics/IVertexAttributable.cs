
namespace B3.Graphics {
	/// <summary>An interface for retrieving the attributes from a vertex</summary>
	public interface IVertexAttributable {
		#region Methods
		
		/// <summary>Gets the list of attributes the vertex contains</summary>
		VertexAttributeData[] GetVertexAttributes();
		
		#endregion // Methods
	}
}


namespace B3 {
	/// <summary>An object that lets you convert into a different object</summary>
	/// <typeparam name="T">The type of object to convert into</typeparam>
	public interface IConvertable<T> {
		#region Methods
		
		/// <summary>Converts the object into the target convertable object</summary>
		/// <returns>Returns the converted object</returns>
		T Convert();
		
		#endregion // Methods
	}
}

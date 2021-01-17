
namespace B3 {
	/// <summary>An interface for when types are updatable</summary>
	public interface IUpdatable {
		#region Methods
		
		/// <summary>Updates the object</summary>
		/// <param name="delta">The time elapsed between frames</param>
		void Update(float delta);
		
		#endregion // Methods
	}
}

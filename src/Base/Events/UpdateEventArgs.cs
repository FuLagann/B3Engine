
namespace B3.Events {
	/// <summary>An event args that holds the update (delta time) information for updating and rendering</summary>
	public sealed class UpdateEventArgs : EventArgs {
		#region Field Variables
		// Variables
		private float deltaTime;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the time elapsed between frames</summary>
		public float DeltaTime { get { return this.deltaTime; } set { this.deltaTime = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor that is used for update and render function events</summary>
		/// <param name="sender">The object that creates the event</param>
		/// <param name="deltaTime">The time elapsed between frames</param>
		public UpdateEventArgs(object sender, float deltaTime) : base(sender) {
			this.deltaTime = deltaTime;
		}
		
		#endregion // Public Constructors
	}
}


namespace B3.Events {
	/// <summary>A base event arguments class, used for the <see cref="B3.Events.EventHandler{T}"/></summary>
	public class EventArgs {
		#region Field Variables
		// Variables
		private object sender;
		
		#endregion // Field Variables
		
		#region Public Properties
		
		/// <summary>Gets and sets the object that created the event to begin with</summary>
		public object Sender { get { return this.sender; } set { this.sender = value; } }
		
		#endregion // Public Properties
		
		#region Public Constructor
		
		/// <summary>A base constructor for creating the event arguments</summary>
		/// <param name="sender">The object that is creating the event</param>
		public EventArgs(object sender) {
			this.sender = sender;
		}
		
		#endregion // Public Constructor
		
		#region Public Methods
		
		/// <summary>Gets the sender while casting it to the type</summary>
		/// <typeparam name="T">The type to cast to</typeparam>
		/// <returns>Returns the casted sender</returns>
		public T GetSender<T>() { return (T)this.sender; }
		
		#endregion // Public Methods
	}
}

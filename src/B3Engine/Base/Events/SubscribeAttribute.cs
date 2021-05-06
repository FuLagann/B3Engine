
namespace B3.Events {
	/// <summary>An attribute used to subscribe to events in the <see cref="B3.Events.EventBus"/></summary>
	public sealed class SubscribeAttribute : System.Attribute {
		#region Public Properties
		
		/// <summary>Gets and sets the priority of the subscription</summary>
		public int Priority { get; set; }
		
		#endregion // Public Properties
	}
}

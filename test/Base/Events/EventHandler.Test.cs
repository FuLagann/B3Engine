
using Xunit;

namespace B3.Events.Testing {
	/// <summary>Tests the functionalities of <see cref="B3.Events.EventHandler"/>, <see cref="B3.Events.EventArgs"/>, and <see cref="B3.Events.UpdateEventArgs"/>. Contains 8 tests</summary>
	public class EventHandlerTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventHandler{T}"/> functionality.
		/// Uses a premade method.
		/// Checks to see if the <see cref="B3.Events.EventArgs.Sender"/> is this object
		/// </summary>
		[Fact]
		public void Invoke_PremadeMethod_ReturnsThis() {
			// Variables
			EventHandler<EventArgs> handler = this.CheckSenderThis;
			
			handler.Invoke(new EventArgs(this));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventHandler{T}"/> functionality.
		/// Uses a premade method.
		/// Checks to see if the <see cref="B3.Events.EventArgs.GetSender{T}"/> is this object
		/// </summary>
		[Fact]
		public void Invoke_PremadeMethodGetSender_ReturnsThis() {
			// Variables
			EventHandler<EventArgs> handler = this.CheckGetSenderThis;
			
			handler.Invoke(new EventArgs(this));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventHandler{T}"/> functionality.
		/// Uses a delegate method.
		/// Checks to see the input float is the same inside the event arguments
		/// </summary>
		[Theory]
		[InlineData(1.0f)]
		[InlineData(0.15f)]
		[InlineData(0.125f)]
		public void Invoke_Delegate_ReturnsInputFloat(float expected) {
			// Variables
			EventHandler<UpdateEventArgs> handler = delegate(UpdateEventArgs args) {
				Assert.Equal(expected, args.DeltaTime);
			};
			
			handler.Invoke(new UpdateEventArgs(this, expected));
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventHandler{T}"/> functionality.
		/// Uses a lambda method.
		/// Checks to see the input float is the same inside the event arguments
		/// </summary>
		[Theory]
		[InlineData(1.0f)]
		[InlineData(0.15f)]
		[InlineData(0.125f)]
		public void Invoke_Lambda_ReturnsInputFloat(float expected) {
			// Variables
			EventHandler<UpdateEventArgs> handler = (UpdateEventArgs args) => {
				Assert.Equal(expected, args.DeltaTime);
			};
			
			handler.Invoke(new UpdateEventArgs(this, expected));
		}
		
		#endregion // Public Test Methods
		
		#region Private Methods
		
		private void CheckSenderThis(EventArgs args) {
			Assert.Equal(this, args.Sender);
		}
		
		private void CheckGetSenderThis(EventArgs args) {
			Assert.Equal(this, args.GetSender<EventHandlerTest>());
		}
		
		#endregion // Private Methods
	}
}

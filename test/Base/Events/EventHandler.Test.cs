
using Xunit;

namespace B3.Events.Testing {
	public class EventHandlerTest {
		[Fact]
		public void TestingEventArgs() {
			// Variables
			EventHandler<EventArgs> handler = this.SampleEventArgs;
			
			handler.Invoke(new EventArgs(this));
		}
		
		[Theory]
		[InlineData(1f)]
		[InlineData(0.15f)]
		[InlineData(0.125f)]
		public void TestingUpdateEventArgs(float delta) {
			EventHandler<UpdateEventArgs> update = delegate(UpdateEventArgs args) {
				Assert.Equal(delta, args.DeltaTime);
			};
			
			update.Invoke(new UpdateEventArgs(this, delta));
		}
		
		private void SampleEventArgs(EventArgs args) {
			Assert.Equal(typeof(EventHandlerTest), args.Sender.GetType());
			Assert.Equal(this, args.GetSender<EventHandlerTest>());
		}
	}
}

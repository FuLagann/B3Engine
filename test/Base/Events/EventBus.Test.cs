
using Xunit;
using Xunit.Abstractions;

namespace B3.Events.Testing {
	public class EventBusTest {
		// Variables
		private ITestOutputHelper output;
		private string name;
		
		public EventBusTest(ITestOutputHelper output) {
			this.output = output;
			this.name = "";
		}
		
		[Fact]
		public void Listen_Unlisten_Emit() {
			// Variables
			EventBus bus = new EventBus();
			DummyClass dummy = new DummyClass(this);
			string id;
			
			Logger.Output = new TestLogger(this);
			
			this.name = "Testing 123";
			
			id = bus.Register((EventArgs args) => {
				Assert.Equal("Regular priority", this.name);
			});
			bus.Register(dummy);
			bus.Register(new DummyClass2(this));
			
			bus.Emit(new EventArgs(this));
			bus.Emit(new UpdateEventArgs(this, 10.4f));
			
			bus.Unregister(dummy);
			
			Assert.Throws<System.Reflection.TargetInvocationException>(() => {
				bus.Emit(new UpdateEventArgs(this, 10.0f));
			});
			bus.Unregister<EventArgs>(id);
			bus.Emit(new EventArgs(this));
			this.name = "Regular priority";
			bus.Unregister(new DummyClass2(this));
			bus.Emit(new EventArgs(this));
			
			Logger.Output = Logger.DefaultOutput;
		}
		
		public class TestLogger : ILoggerOutput {
			// Variables
			EventBusTest test;
			
			public TestLogger(EventBusTest test) {
				this.test = test;
			}
			
			/// <summary>Writes to the output with a newline at the end</summary>
			/// <param name="output">The string to output</param>
			public void WriteLine(string output) {
				this.test.output.WriteLine(output);
			}
			
			/// <summary>Writes to the output without a newline at the end</summary>
			/// <param name="output">The string to output</param>
			public void Write(string output) { this.WriteLine(output); }
		}
		
		public class DummyClass {
			// Variables
			EventBusTest test;
			
			public DummyClass(EventBusTest test) {
				this.test = test;
			}
			
			[Subscribe(Priority = -1)]
			public void CalledLast(EventArgs args) {
				Assert.Equal("Last Testing Call", this.test.name);
			}
			
			[Subscribe]
			public void CalledWithRegularPriority(EventArgs args) {
				Assert.Equal("Regular priority", this.test.name);
				this.test.name = "Last Testing Call";
			}
			
			[Subscribe]
			public void AlsoCalledWithRegularPriority(EventArgs args) {
				Assert.NotEqual("Regular priority", this.test.name);
			}
			
			[Subscribe(Priority = 2)]
			public void CalledFirst(EventArgs args) {
				Assert.Equal("Testing 123", this.test.name);
				this.test.name = "Going down a priority";
			}
			
			[Subscribe(Priority = 1)]
			public void CalledSecond(EventArgs args) {
				Assert.Equal("Going down a priority", this.test.name);
				this.test.name = "Regular priority";
			}
			
			[Subscribe(Priority = 100)]
			public void StopsPropagation(UpdateEventArgs args) {
				Assert.Equal(10.4f, args.DeltaTime);
				args.StopPropagation();
			}
			
			[Subscribe]
			public void ThrowsException(UpdateEventArgs args) {
				throw new System.NotImplementedException();
			}
			
			[Subscribe]
			public void AlsoThrowsException(UpdateEventArgs args) {
				throw new System.NotImplementedException();
			}
		}
		
		public class DummyClass2 {
			// Variables
			EventBusTest test;
			
			public DummyClass2(EventBusTest test) {
				this.test = test;
			}
			
			[Subscribe]
			public void AlsoHasRegularPriorty(EventArgs args) {
				Assert.NotEqual("Regular priority", this.test.name);
			}
			
			[Subscribe(Priority = 100)]
			public void ThrowsException(UpdateEventArgs args) {
				throw new System.NotImplementedException();
			}
		}
	}
}

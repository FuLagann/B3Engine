
using Xunit;
using Xunit.Abstractions;

namespace B3.Events.Testing {
	/// <summary>Tests the <see cref="B3.Events.EventBus"/> class to make sure it works correctly. Contains 21 tests</summary>
	public class EventBusTest {
		#region Public Test Methods
		
		#region Register Tests
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register(object)"/> functionality.
		/// Uses only a single class as a subscriber.
		/// Should alter the data into 123 and checks for that
		/// </summary>
		[Fact]
		public void Register_SingleSubscriber_Returns123() {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject();
			
			bus.Register(new DataShifter_123(dataObj));
			bus.Emit<EventArgs>(new EventArgs(this));
			
			Assert.Equal("123", dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register(object)"/> functionality.
		/// Uses only a single class as a subscriber that has priorities set.
		/// Should alter the data into 24351 and checks for that
		/// </summary>
		[Fact]
		public void Register_SingleSubscriberWithPriority_Returns24351() {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject();
			
			bus.Register(new DataShifter_24351(dataObj));
			bus.Emit(new EventArgs(this));
			
			Assert.Equal("24351", dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register(object)"/> functionality.
		/// Uses two classes that are subscribers. First one adds in 123, second one add in 24351 but as priorities
		/// Should alter the data into 24123351 and checks for that
		/// </summary>
		[Fact]
		public void Register_MultipleSubscribers_Returns24123351() {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject();
			
			bus.Register(new DataShifter_123(dataObj));
			bus.Register(new DataShifter_24351(dataObj));
			bus.Emit(new EventArgs(this));
			
			Assert.Equal("24123351", dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register(object)"/> functionality.
		/// Uses a single subscriber class.
		/// Should only fire off one type of argument and alter the data into 4 and checks for that
		/// </summary>
		[Fact]
		public void Register_SingleSubscriberDifferentArgument_Returns4() {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject();
			
			bus.Register(new DataShifter_123(dataObj));
			bus.Emit(new UpdateEventArgs(this, 0.0f));
			
			Assert.Equal("4", dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register{TArgs}(EventHandler{TArgs})"/> functionality.
		/// Uses a single delegate.
		/// Should alter the data into "Hello World!" and checks for that
		/// </summary>
		[Fact]
		public void Register_Delegate_ReturnsHelloWorld() {
			// Variables
			EventBus bus = new EventBus();
			string data = "Incorrect";
			
			bus.Register(delegate(EventArgs args) {
				data = "Hello World!";
			});
			bus.Emit(new EventArgs(this));
			
			Assert.Equal("Hello World!", data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Register{TArgs}(EventHandler{TArgs})"/> functionality.
		/// Uses a single lambda method.
		/// Should alter the data into the input string and checks for that
		/// </summary>
		[Theory]
		[InlineData("123")]
		[InlineData("Hello World!")]
		[InlineData("Should change")]
		public void Register_Lambda_ReturnsInputString(string expected) {
			// Variables
			EventBus bus = new EventBus();
			string data = "Incorrect";
			
			bus.Register((EventArgs args) => {
				data = expected;
			});
			bus.Emit(new EventArgs(this));
			
			Assert.Equal(expected, data);
		}
		
		#endregion // Register Tests
		
		#region Unregister Tests
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Unregister(object)"/> functionality.
		/// Uses a single subscriber class.
		/// Should not alter any data and checks if its the same as the input string
		/// </summary>
		[Theory]
		[InlineData("123")]
		[InlineData("Hello World!")]
		[InlineData("Nothing should change")]
		public void Unregister_SingleSubscriber_ReturnsInputString(string expected) {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject(expected);
			DataShifter_123 shifter = new DataShifter_123(dataObj);
			
			bus.Register(shifter);
			bus.Unregister(shifter);
			bus.Emit(new EventArgs(this));
			
			Assert.Equal(expected, dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Unregister(object)"/> functionality.
		/// Uses two subscriber classes.
		/// Should not alter any data and checks if its the same as the input string
		/// </summary>
		[Theory]
		[InlineData("123")]
		[InlineData("Hello World!")]
		[InlineData("Nothing should change")]
		public void Unregister_MultipleSubscribers_ReturnsInputString(string expected) {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject(expected);
			DataShifter_123 shifter = new DataShifter_123(dataObj);
			
			bus.Register(shifter);
			bus.Register(new DataShifter_24351(dataObj));
			bus.Unregister(shifter);
			bus.Unregister(new DataShifter_24351(dataObj));
			bus.Emit(new EventArgs(this));
			
			Assert.Equal(expected, dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Unregister(object)"/> functionality.
		/// Uses two subscriber classes, but only removes one of them.
		/// Should alter the data into 123 and checks for that
		/// </summary>
		[Fact]
		public void Unregister_MultipleSubscribers_Returns123() {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject();
			
			bus.Register(new DataShifter_123(dataObj));
			bus.Register(new DataShifter_24351(dataObj));
			bus.Unregister(new DataShifter_24351(dataObj));
			bus.Emit(new EventArgs(this));
			
			Assert.Equal("123", dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Unregister{TArgs}(string)"/> functionality.
		/// Uses a delegate.
		/// Should not alter the data
		/// </summary>
		[Theory]
		[InlineData("123")]
		[InlineData("Hello World!")]
		[InlineData("Nothing should change")]
		public void Unregister_Delegate_ReturnsInputString(string expected) {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject(expected);
			string id = "";
			
			id = bus.Register(delegate(EventArgs args) {
				dataObj.data += "Incorrect";
			});
			bus.Unregister<EventArgs>(id);
			bus.Emit(new EventArgs(this));
			
			Assert.Equal(expected, dataObj.data);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Events.EventBus.Unregister{TArgs}(string)"/> functionality.
		/// Uses two lambdas and removes only one of them.
		/// Should alter the data to add 1 to the input string
		/// </summary>
		[Theory]
		[InlineData("123")]
		[InlineData("Hello World!")]
		[InlineData("Nothing should change")]
		public void Unregister_Lambda_ReturnsInputString1(string expected) {
			// Variables
			EventBus bus = new EventBus();
			DataObject dataObj = new DataObject(expected);
			string id = "";
			
			id = bus.Register((EventArgs args) => {
				dataObj.data += "Incorrect";
			});
			bus.Register((EventArgs args) => {
				dataObj.data += "1";
			});
			bus.Unregister<EventArgs>(id);
			bus.Emit(new EventArgs(this));
			
			Assert.Equal($"{expected}1", dataObj.data);
		}
		
		#endregion // Unregister Tests
		
		#endregion // Public Test Methods
		
		#region Nested Objects
		
		private class DataObject {
			#region Field Variables
			// Variables
			public string data;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			public DataObject(string data) {
				this.data = data;
			}
			
			public DataObject() : this("") {}
			
			#endregion // Public Constructors
		}
		
		/// <summary>Changes the data object into adding 123 into it's data</summary>
		private class DataShifter_123 {
			#region Field Variables
			// Variables
			public DataObject dataObj;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			public DataShifter_123(DataObject dataObj) {
				this.dataObj = dataObj;
			}
			
			#endregion // Public Constructors
			
			#region Public Methods
			
			[Subscribe]
			public void Add1(EventArgs args) { this.dataObj.data += "1"; }
			
			[Subscribe]
			public void Add2(EventArgs args) { this.dataObj.data += "2"; }
			
			[Subscribe]
			public void Add3(EventArgs args) { this.dataObj.data += "3"; }
			
			[Subscribe]
			public void Add4(UpdateEventArgs args) { this.dataObj.data += "4"; }
			
			#endregion // Public Methods
		}
		
		private class DataShifter_24351 {
			#region Field Variables
			// Variables
			public DataObject dataObj;
			
			#endregion // Field Variables
			
			#region Public Constructors
			
			public DataShifter_24351(DataObject dataObj) {
				this.dataObj = dataObj;
			}
			
			#endregion // Public Constructors
			
			#region Public Methods
			
			[Subscribe(Priority = -1)]
			public void Add1(EventArgs args) { this.dataObj.data +=  "1"; }
			
			[Subscribe(Priority = 1)]
			public void Add2(EventArgs args) { this.dataObj.data += "2"; }
			
			[Subscribe]
			public void Add3(EventArgs args) { this.dataObj.data += "3"; }
			
			[Subscribe(Priority = 1)]
			public void Add4(EventArgs args) { this.dataObj.data += "4"; }
			
			[Subscribe]
			public void Add5(EventArgs args) { this.dataObj.data += "5"; }
			
			#endregion // Public Methods
		}
		#endregion // Nested Objects
	}
}


using Xunit;

namespace B3.Testing {
	/// <summary>Tests the <see cref="B3.Time"/> class to make sure it works correctly. Contains 6 tests</summary>
	public class TimeTest {
		#region Public Test Methods
		
		/// <summary>
		/// Tests the <see cref="B3.Time.DeltaTime"/> and <see cref="B3.Time.Rate"/> functionality.
		/// Checks to see if setting the delta time and rate gets done correctly
		/// </summary>
		/// <param name="deltaTime">The delta time to set with</param>
		/// <param name="rate">The rate of time to set with</param>
		/// <param name="expected">The expected outcome</param>
		[Theory]
		[InlineData(1.0f, 1.0f, 1.0f)]
		[InlineData(1.0f, 0.5f, 0.5f)]
		[InlineData(0.5f, 1.0f, 0.5f)]
		[InlineData(0.5f, 0.25f, 0.125f)]
		public void DeltaTime_SetDeltaTime_ReturnsFloat(float deltaTime, float rate, float expected) {
			Time.SetDeltaTime(deltaTime);
			Time.Rate = rate;
			
			Assert.Equal(expected, Time.DeltaTime);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Time.StartTime"/> functionality.
		/// Checks to see if the start time is at least populated
		/// </summary>
		[Fact]
		public void StartTime_ReturnsLargerThan0() {
			Assert.True(Time.StartTime.Ticks > 0);
		}
		
		/// <summary>
		/// Tests the <see cref="B3.Time.TotalTimeSpan"/> functionality.
		/// Checks to see if the time span is correct from now and half a second from now
		/// </summary>
		[Fact]
		public void TotalTime_ThreadSleep_ReturnsLong() {
			System.Threading.Thread.Sleep(500);
			
			Assert.Equal((System.DateTime.UtcNow - Time.StartTime).Milliseconds, Time.TotalTimeSpan.Milliseconds);
		}
		
		#endregion // Public Test Methods
	} 
}

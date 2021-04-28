
using Xunit;

namespace B3.Testing {
	public class TimeTest {
		/*
		[Theory]
		[InlineData(1.0f, 0.5f, 0.5f)]
		[InlineData(0.5f, 1.0f, 0.5f)]
		[InlineData(0.5f, 0.25f, 0.125f)]
		public void DeltaTimeAndRate(float deltaTime, float rate, float expectedWithRate) {
			Time.SetDeltaTime(deltaTime);
			Assert.Equal(deltaTime, Time.DeltaTime);
			Time.Rate = rate;
			Assert.Equal(expectedWithRate, Time.DeltaTime);
			Time.Rate = 1.0f;
		}
		*/
		
		[Fact]
		public void StartTimeAndTotalTime() {
			Assert.True(Time.StartTime.Ticks > 0);
			Assert.Equal((System.DateTime.UtcNow - Time.StartTime).Milliseconds, Time.TotalTimeSpan.Milliseconds);
			System.Threading.Thread.Sleep(1000);
			Assert.Equal((System.DateTime.UtcNow - Time.StartTime).Milliseconds, Time.TotalTimeSpan.Milliseconds);
		}
	} 
}

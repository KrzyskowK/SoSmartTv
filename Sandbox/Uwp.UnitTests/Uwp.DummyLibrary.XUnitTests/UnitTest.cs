using Xunit;

namespace Uwp.DummyLibrary.MsTests
{
	public class UnitTest
	{
		private ICounter Sut { get; set; }

		public UnitTest()
		{
			Sut = new Counter();
		}

		[Fact]
		public void IsInitiated_returns_false()
		{
			Assert.False(Sut.IsInitiated());
		}

		[Fact]
		public void IsInitiated_returns_true()
		{
			Sut.Init();
			Assert.True(Sut.IsInitiated());
		}

		[Theory]
		[InlineData(5, 5)]
		[InlineData(10, 10)]
		public void Add_should_increase_counter_status_value(int addParam, int expectedStatus)
		{
			Sut.Init();
			Sut.Add(addParam);
			Assert.Equal(expectedStatus, Sut.GetStatus());
		}

	}
}
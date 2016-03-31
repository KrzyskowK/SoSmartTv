using NUnit.Framework;

namespace Uwp.DummyLibrary.NUnitTests
{
	[TestFixture]
	public class UnitTest
	{
		private ICounter Sut { get; set; }

		[SetUp]
		public void Setup()
		{
			Sut = new Counter();
		}

		[Test]
		public void IsInitiated_returns_false()
		{
			Assert.IsFalse(Sut.IsInitiated());
		}

		[Test]
		public void IsInitiated_returns_true()
		{
			Sut.Init();
			Assert.IsTrue(Sut.IsInitiated());
		}

		[TestCase(5, 5)]
		[TestCase(10, 10)]
		public void Add_should_increase_counter_status_value(int addParam, int expectedStatus)
		{
			Sut.Init();
			Sut.Add(addParam);
			Assert.AreEqual(expectedStatus, Sut.GetStatus());
		}

	}
}
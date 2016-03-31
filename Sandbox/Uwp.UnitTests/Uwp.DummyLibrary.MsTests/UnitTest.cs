using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Assert = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.Assert;

namespace Uwp.DummyLibrary.MsTests
{
	[TestClass]
	public class UnitTest1
	{
		private ICounter Sut { get; set; }

		[TestInitialize]
		public void Initialize()
		{
			Sut = new Counter();
		}

		[TestMethod]
		public void IsInitiated_returns_false()
		{
			Assert.IsFalse(Sut.IsInitiated());
		}

		[TestMethod]
		public void IsInitiated_returns_true()
		{
			Sut.Init();
			Assert.IsTrue(Sut.IsInitiated());
		}
		
		[DataTestMethod]
		[DataRow(5,5)]
		[DataRow(10,10)]
		public void Add_should_increase_counter_status_value(int addParam, int expectedStatus)
		{
			Sut.Init();
			Sut.Add(addParam);
			Assert.AreEqual(expectedStatus,Sut.GetStatus());
		}

	}
}

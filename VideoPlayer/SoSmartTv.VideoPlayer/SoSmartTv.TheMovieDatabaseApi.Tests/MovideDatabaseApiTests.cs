using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	[TestClass]
	public class MovideDatabaseApiTests
	{
		private IMovieDatabasApi _sut;

		[TestInitialize]
		public void Setup()
		{
			_sut = new MovideDatabaseApi();
		}

		[TestMethod]
		public void Search_returns_correct_result()
		{
			var result = _sut.SearchVideo("batman");
			result.Wait();
			var x = result.Result;
			Assert.IsNotNull(x);
		}
	}

	[TestClass]
	public class UnderscoreToPascalCaseContractResolverTests
	{
		private UnderscoreToPascalCaseContractResolver _sut;

		[TestInitialize]
		public void Setup()
		{
			_sut = new UnderscoreToPascalCaseContractResolver();
		}

		[TestMethod]
		public void Dummy()
		{
			Assert.AreEqual(1, 1);
		}
		
		[DataTestMethod]
		[DataRow("Page", "page")]
		[DataRow("PageNumber", "page_number")]
		[DataRow("PageNumberTwo", "page_number_two")]
		[DataRow("page", "page")]
		public void Should_return_correct_property_names(string input, string expectedOutput)
		{
			var output = _sut.GetResolvedPropertyName(input);
			Assert.AreEqual(expectedOutput, output);
		}
	}
}

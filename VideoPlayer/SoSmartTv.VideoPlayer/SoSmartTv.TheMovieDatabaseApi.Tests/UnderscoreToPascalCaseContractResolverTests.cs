using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SoSmartTv.TheMovieDatabaseApi.JsonResolvers;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
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
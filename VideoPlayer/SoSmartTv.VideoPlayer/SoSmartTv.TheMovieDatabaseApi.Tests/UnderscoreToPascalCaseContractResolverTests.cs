using SoSmartTv.TheMovieDatabaseApi.JsonResolvers;
using Xunit;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	public class UnderscoreToPascalCaseContractResolverTests
	{
		private readonly UnderscoreToPascalCaseContractResolver _sut;

		public UnderscoreToPascalCaseContractResolverTests()
		{
			_sut = new UnderscoreToPascalCaseContractResolver();
		}

		[Fact]
		public void Dummy()
		{
			Assert.Equal(1, 1);
		}
		
		[Theory]
		[InlineData("Page", "page")]
		[InlineData("PageNumber", "page_number")]
		[InlineData("PageNumberTwo", "page_number_two")]
		[InlineData("page", "page")]
		public void Should_return_correct_property_names(string input, string expectedOutput)
		{
			var output = _sut.GetResolvedPropertyName(input);
			Assert.Equal(expectedOutput, output);
		}
	}
}
using Newtonsoft.Json;
using SoSmartTv.TheMovieDatabaseApi.JsonConverters;
using Xunit;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	public class ImageAbsolutePathJsonItemConverterTests
	{
		private class SutIncorrect
		{
			public string Output { get; set; }
		}

		private class SutCorrect
		{
			[JsonConverter(typeof(ImageAbsolutePathJsonConverter))]
			public string Output { get; set; }
		}

		private string _json = "{ 'output': '/simplePath.jpg'}";

		[Fact]
		public void Deserialization_without_converter_should_return_same_value()
		{
			SutIncorrect result = JsonConvert.DeserializeObject<SutIncorrect>(_json);
			Assert.Equal("/simplePath.jpg", result.Output);
		}

		[Fact]
		public void Deserialization_with_converter_should_return_correct_absolute_path()
		{
			SutCorrect result = JsonConvert.DeserializeObject<SutCorrect>(_json);
			Assert.Equal(string.Format(Urls.Images.WidthOriginal, "/simplePath.jpg"), result.Output);
		}
	}
}
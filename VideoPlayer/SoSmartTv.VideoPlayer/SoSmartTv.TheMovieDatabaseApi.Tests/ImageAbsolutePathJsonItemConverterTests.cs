using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using SoSmartTv.TheMovieDatabaseApi.JsonConverters;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	[TestClass]
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

		[TestMethod]
		public void Deserialization_without_converter_should_return_same_value()
		{
			SutIncorrect result = JsonConvert.DeserializeObject<SutIncorrect>(_json);
			Assert.AreEqual("/simplePath.jpg", result.Output);
		}

		[TestMethod]
		public void Deserialization_with_converter_should_return_correct_absolute_path()
		{
			SutCorrect result = JsonConvert.DeserializeObject<SutCorrect>(_json);
			Assert.AreEqual(string.Format(Urls.Images.Base, "/simplePath.jpg"), result.Output);
		}
	}
}
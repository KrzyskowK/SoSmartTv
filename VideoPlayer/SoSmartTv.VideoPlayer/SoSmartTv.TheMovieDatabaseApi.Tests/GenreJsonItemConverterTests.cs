using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using SoSmartTv.TheMovieDatabaseApi.Dtos;
using SoSmartTv.TheMovieDatabaseApi.JsonConverters;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	[TestClass]
	public class GenreJsonItemConverterTests
	{
		private class SutIncorrect
		{
			public List<Genre> Output { get; set; }
		}

		private class SutCorrect
		{
			[JsonProperty(ItemConverterType = typeof(GenresJsonConverter))]
			public List<Genre> Output { get; set; }
		}

		private string _json = "{ 'output': [{ 'name': 'FakeName', 'id': 24 },{ 'name': 'FakeName', 'id': 23 }]}";

		[TestMethod]
		public void Deserialization_without_converter_should_throw_exception()
		{
			Assert.ThrowsException<JsonSerializationException>(() =>
			{
				SutIncorrect result = JsonConvert.DeserializeObject<SutIncorrect>(_json);
			});
		}

		[TestMethod]
		public void Deserialization_with_converter_should_return_correct_id_result()
		{
			SutCorrect result = JsonConvert.DeserializeObject<SutCorrect>(_json);
			Assert.AreEqual((Genre)24, result.Output[0]);
			Assert.AreEqual((Genre)23, result.Output[1]);
		}
	}
}
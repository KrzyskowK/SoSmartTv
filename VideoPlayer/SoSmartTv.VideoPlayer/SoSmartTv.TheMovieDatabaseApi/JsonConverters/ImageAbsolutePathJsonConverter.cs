using System;
using Newtonsoft.Json;

namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class ImageAbsolutePathJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new System.NotImplementedException();
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return string.Format(Urls.Images.Base, reader.Value);
		}
	}
}
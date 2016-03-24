using System;
using Newtonsoft.Json;

namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class ImageAbsolutePathJsonConverter : JsonConverter
	{
		protected virtual string BaseImageUrl { get; } = Urls.Images.WidthOriginal;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException("This converter supports only read mode.");
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (string.IsNullOrEmpty(BaseImageUrl))
				throw new ArgumentException("baseImageUrl cannot be null or empty.");
			return string.Format(BaseImageUrl, reader.Value);
		}
	}
}
using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public abstract class AbstractJsonConverter<T> : JsonConverter
	{
		public abstract string PropertyPath { get; }

		public abstract object ConvertResult(T value);

		public override bool CanWrite { get; } = false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException("This converter supports only read mode.");
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType.IsInstanceOfType(typeof(T));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if(string.IsNullOrEmpty(PropertyPath))
				throw new ArgumentException("PropertyPath cannot be null or empty");

			var jObject = JObject.Load(reader);
			var value =  jObject.SelectToken(PropertyPath).Value<T>();
			return ConvertResult(value);
		}
	}
}
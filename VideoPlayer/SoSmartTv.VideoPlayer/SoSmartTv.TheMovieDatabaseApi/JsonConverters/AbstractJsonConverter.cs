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

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType.IsInstanceOfType(typeof(T));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			var value = string.IsNullOrEmpty(PropertyPath) ? jObject.Value<T>() : jObject.SelectToken(PropertyPath).Value<T>();
			return ConvertResult(value);
		}
	}
}
namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class NameJsonConverter : AbstractJsonConverter<string>
	{
		public override string PropertyPath => "name";
		public override object ConvertResult(string value)
		{
			return value;
		}
	}
}
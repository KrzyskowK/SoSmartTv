namespace SoSmartTv.TheMovieDatabaseApi.JsonItemConverters
{
	public class NameJsonItemConverter : AbstractJsonItemConverter<string>
	{
		public override string PropertyPath => "name";
		public override object ConvertResult(string value)
		{
			return value;
		}
	}
}
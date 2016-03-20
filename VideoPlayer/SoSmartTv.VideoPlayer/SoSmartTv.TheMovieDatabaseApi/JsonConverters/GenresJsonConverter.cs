using SoSmartTv.TheMovieDatabaseApi.Dtos;

namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class GenresJsonConverter : AbstractJsonConverter<int>
	{
		public override string PropertyPath => "id";
		public override object ConvertResult(int value)
		{
			return (Genre) value;
		}
	}
}
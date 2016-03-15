using SoSmartTv.TheMovieDatabaseApi.Dtos;

namespace SoSmartTv.TheMovieDatabaseApi.JsonItemConverters
{
	public class GenresJsonItemConverter : AbstractJsonItemConverter<int>
	{
		public override string PropertyPath => "id";
		public override object ConvertResult(int value)
		{
			return (Genre) value;
		}
	}
}
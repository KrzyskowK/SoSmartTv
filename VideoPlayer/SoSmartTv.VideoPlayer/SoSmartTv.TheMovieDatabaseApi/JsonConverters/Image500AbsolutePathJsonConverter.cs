namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class Image500AbsolutePathJsonConverter : ImageAbsolutePathJsonConverter
	{
		protected override string BaseImageUrl { get; } = Urls.Images.Width500;
	}
}
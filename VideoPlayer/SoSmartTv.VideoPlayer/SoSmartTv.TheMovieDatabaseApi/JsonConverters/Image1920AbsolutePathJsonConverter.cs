namespace SoSmartTv.TheMovieDatabaseApi.JsonConverters
{
	public class Image1920AbsolutePathJsonConverter : ImageAbsolutePathJsonConverter
	{
		protected override string BaseImageUrl { get; } = Urls.Images.Width1920;
	}
}
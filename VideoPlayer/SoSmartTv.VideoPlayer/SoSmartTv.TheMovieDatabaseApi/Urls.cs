namespace SoSmartTv.TheMovieDatabaseApi
{
	public static class Urls
	{
		public static string Api { get; } = "http://api.themoviedb.org/3/";

		public static string MockApi { get; } = "http://private-0a2a7-themoviedb.apiary-mock.com/3/";

		public static class Images
		{
			public static string Width500 { get; } = "http://image.tmdb.org/t/p/w500{0}";

			public static string Width1920 { get; } = "http://image.tmdb.org/t/p/w1920{0}";

			public static string WidthOriginal { get; } = "http://image.tmdb.org/t/p/original{0}";
		}

		public static class Requests
		{
			public static string SearchMovie { get; } = "search/movie?query={0}";

			public static string GetMovie { get; } = "movie/{0}";
		}
	}
}

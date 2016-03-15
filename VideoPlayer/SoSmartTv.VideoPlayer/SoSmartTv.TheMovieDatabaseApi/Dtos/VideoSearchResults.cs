using System.Collections.Generic;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public class VideoSearchResults
	{
		public int Page { get; set; }
		public List<VideoInfo> Results { get; set; }
		public int TotalPages { get; set; }
		public int TotalResults { get; set; }
	}
}
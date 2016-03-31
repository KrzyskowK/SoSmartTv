namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoDetailsItem : VideoItem, IVideoDetailsItem
	{
		public string OriginalLanguage { get; set; }
		public string OriginalTitle { get; set; }
		public string ReleaseDate { get; set; }
		public int Revenue { get; set; }
		public int Runtime { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}

	public class VideoCreditsItem
	{
		
	}
}
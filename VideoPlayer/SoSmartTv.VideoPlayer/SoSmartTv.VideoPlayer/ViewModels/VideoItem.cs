namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoItem : IVideoItem
	{
		public VideoItem(string title, string sourcePath, string genre, string description, string posterSource)
		{
			Title = title;
			SourcePath = sourcePath;
			Genre = genre;
			Description = description;
			PosterSource = posterSource;
		}

		public string Title { get; }
		public string SourcePath { get; }
		public string Genre { get; }
		public string Description { get; }
		public string PosterSource { get; }
	}
}
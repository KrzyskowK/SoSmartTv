namespace SoSmartTv.VideoService.Dto
{
	public class VideoItem : IVideoItem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string SourcePath { get; set; }
		public string BackdropPath { get; set; }
		public string Genre { get; set; }
		public string Description { get; set; }
		public string PosterPath { get; set; }
	}
}
namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoItem
	{
		string Title { get; }
		string SourcePath { get; }
		string BackdropPath { get; }
		string Genre { get; }
		string Description { get; }
		string PosterSource { get; }
	}
}
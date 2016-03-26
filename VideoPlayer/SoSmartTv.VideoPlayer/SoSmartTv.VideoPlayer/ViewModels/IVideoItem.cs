namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoItem
	{
		int Id { get; }
		string Title { get; }
		string SourcePath { get; }
		string BackdropPath { get; }
		string Genre { get; }
		string Description { get; }
		string PosterPath { get; }
	}
}
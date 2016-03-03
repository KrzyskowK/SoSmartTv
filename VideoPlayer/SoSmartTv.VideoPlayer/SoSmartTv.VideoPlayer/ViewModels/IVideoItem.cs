namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoItem
	{
		string SourcePath { get; }
		string Genre { get; }
		string Description { get; }
		string PosterSource { get; }
	}
}
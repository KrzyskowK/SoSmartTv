namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoDetailsItem : IVideoItem
	{
		string OriginalLanguage { get; }
		string OriginalTitle { get; }
		string ReleaseDate { get; }
		int Revenue { get; }
		int Runtime { get; }
		double VoteAverage { get; }
		int VoteCount { get; }
	}
}
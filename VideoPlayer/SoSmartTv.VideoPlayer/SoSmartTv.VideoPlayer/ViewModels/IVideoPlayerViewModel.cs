using Windows.UI.Xaml;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoPlayerViewModel
	{
		string VideoSourcePath { get; }

		void OnClick(object sender, RoutedEventArgs e);
	}
}
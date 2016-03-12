using Windows.UI.Xaml;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoPlayerViewModel : ViewModelBase, IVideoPlayerViewModel
	{
		private readonly INavigationService _navigationService;

		public VideoPlayerViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public string VideoSourcePath { get; private set; }

		public void OnClick(object sender, RoutedEventArgs e)
		{
			_navigationService.Navigate("VideoCollection", null);
		}
	}
}
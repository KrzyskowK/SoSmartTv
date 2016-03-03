using Prism.Windows.Mvvm;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoPlayerPageViewModel : ViewModelBase, IVideoPlayerPageViewModel
	{
		public VideoPlayerPageViewModel()
		{
			
		}

		public string VideoSourcePath { get; private set; }
	}
}
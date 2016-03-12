using Prism.Windows.Mvvm;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoPlayerViewModel : ViewModelBase, IVideoPlayerViewModel
	{
		public VideoPlayerViewModel()
		{
			
		}

		public string VideoSourcePath { get; private set; }
	}
}
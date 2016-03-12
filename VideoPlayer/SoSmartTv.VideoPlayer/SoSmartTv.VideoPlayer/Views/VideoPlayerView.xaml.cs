using Windows.UI.Xaml;
using Prism.Windows.Mvvm;
using SoSmartTv.VideoPlayer.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SoSmartTv.VideoPlayer.Views
{
	public sealed partial class VideoPlayerView : SessionStateAwarePage
	{
		public VideoPlayerView()
		{
			this.InitializeComponent();
			this.DataContextChanged += VideoPlayerPage_DataContextChanged;
		}

		private void VideoPlayerPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
		{
			//throw new System.NotImplementedException();
		}

		public IVideoPlayerViewModel ViewModel => DataContext as IVideoPlayerViewModel;

		
	}
}

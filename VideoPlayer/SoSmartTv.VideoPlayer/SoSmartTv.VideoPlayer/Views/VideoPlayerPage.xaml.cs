using Windows.UI.Xaml.Controls;
using Prism.Windows.Mvvm;
using SoSmartTv.VideoPlayer.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SoSmartTv.VideoPlayer.Views
{
	public sealed partial class VideoPlayerPage : SessionStateAwarePage
	{
		public VideoPlayerPage()
		{
			this.InitializeComponent();
		}
		
		public IVideoPlayerViewModel ViewModel
		{
			get { return DataContext as IVideoPlayerViewModel; }
		}
	}
}

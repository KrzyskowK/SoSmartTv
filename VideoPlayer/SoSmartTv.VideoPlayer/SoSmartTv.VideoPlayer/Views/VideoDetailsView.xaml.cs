using Windows.UI.Xaml.Controls;
using SoSmartTv.VideoPlayer.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SoSmartTv.VideoPlayer.Views
{
	public sealed partial class VideoDetailsView : Page
	{
		public VideoDetailsView()
		{
			this.InitializeComponent();
		}

		public IVideoDetailsViewModel ViewModel => DataContext as IVideoDetailsViewModel;
	}
}

using Windows.UI.Xaml.Controls;
using SoSmartTv.VideoPlayer.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SoSmartTv.VideoPlayer.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class VideoCollectionView : Page
	{
		public VideoCollectionView()
		{
			this.InitializeComponent();
		}

		public IVideoCollectionViewModel ViewModel => DataContext as IVideoCollectionViewModel;
	}
}

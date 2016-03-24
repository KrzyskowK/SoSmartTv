using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoCollectionViewModel : ViewModelBase, IVideoCollectionViewModel
	{
		private ObservableCollection<IVideoItem> _videos;
		private readonly INavigationService _navigationService;

		public VideoCollectionViewModel(IVideoItemsProvider provider, INavigationService navigationService)
		{
			_navigationService = navigationService;
			PopulateVideos(provider);
		}

		private async void PopulateVideos(IVideoItemsProvider provider)
		{
			var v = await provider.GetVideoItems();
			Videos = new ObservableCollection<IVideoItem>(v);
		}

		public ObservableCollection<IVideoItem> Videos
		{
			get { return _videos; }
			private set
			{
				_videos = value;
				OnPropertyChanged();
			}
		}

		public int SelectedVideoId { get; set; }

		public void OnVideoClick(object sender, ItemClickEventArgs e)
		{
			_navigationService.Navigate("VideoDetails", (e.ClickedItem as IVideoItem).Id);
		}
	}
}
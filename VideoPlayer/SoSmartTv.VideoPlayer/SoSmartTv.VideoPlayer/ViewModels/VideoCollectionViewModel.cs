using System.Collections.ObjectModel;
using Prism.Windows.Mvvm;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoCollectionViewModel : ViewModelBase, IVideoCollectionViewModel
	{
		private ObservableCollection<IVideoItem> _videos;

		public VideoCollectionViewModel(IVideoItemsProvider provider)
		{
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

	}
}
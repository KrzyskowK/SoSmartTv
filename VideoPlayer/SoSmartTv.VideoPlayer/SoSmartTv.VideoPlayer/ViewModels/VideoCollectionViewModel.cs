using System;
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
			provider.GetVideoItems().Subscribe(x => Videos = new ObservableCollection<IVideoItem>(x));
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
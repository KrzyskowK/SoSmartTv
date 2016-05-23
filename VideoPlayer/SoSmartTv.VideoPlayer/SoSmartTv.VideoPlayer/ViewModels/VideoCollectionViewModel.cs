using System;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using Windows.UI.Xaml.Controls;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SoSmartTv.VideoService;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoCollectionViewModel : ViewModelBase, IVideoCollectionViewModel
	{
		private ObservableCollection<VideoItem> _videos;
		private readonly INavigationService _navigationService;

		public VideoCollectionViewModel(IVideoItemsProvider provider, INavigationService navigationService)
		{
			_navigationService = navigationService;
			
			provider.GetVideoItems()
				.ObserveOn(CoreDispatcherScheduler.Current)
				.Subscribe(x => Videos = new ObservableCollection<VideoItem>(x));
		}
		
		public ObservableCollection<VideoItem> Videos
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
			_navigationService.Navigate("VideoDetails", (e.ClickedItem as VideoItem).Id);
		}
	}
}
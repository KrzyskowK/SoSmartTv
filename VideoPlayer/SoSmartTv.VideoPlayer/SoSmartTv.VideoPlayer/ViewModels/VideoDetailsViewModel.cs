using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Threading;
using SoSmartTv.VideoService;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoDetailsViewModel : ViewModelBase, IVideoDetailsViewModel
	{
		private VideoItem _details;
		private readonly IVideoItemsProvider _videoItemsProvider;

		public VideoDetailsViewModel(IVideoItemsProvider videoItemsProvider)
		{
			_videoItemsProvider = videoItemsProvider;
		}

		public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
		{
			var context = SynchronizationContext.Current;
			_videoItemsProvider.GetVideoItem((int) e.Parameter)
				.ObserveOn(context)
				.Subscribe(x => Details = x);
			base.OnNavigatedTo(e, viewModelState);
		}

		public VideoItem Details
		{
			get { return _details; }
			private set
			{
				_details = value;
				OnPropertyChanged();
			}
		}
	}
}
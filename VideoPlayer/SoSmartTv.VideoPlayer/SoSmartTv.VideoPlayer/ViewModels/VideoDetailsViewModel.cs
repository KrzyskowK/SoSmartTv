using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoDetailsViewModel : ViewModelBase, IVideoDetailsViewModel
	{
		private IVideoItem _details;
		private readonly IVideoItemsProvider _videoItemsProvider;

		public VideoDetailsViewModel(IVideoItemsProvider videoItemsProvider)
		{
			_videoItemsProvider = videoItemsProvider;
		}

		public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
		{
			_videoItemsProvider.GetVideoItem((int) e.Parameter).Subscribe(x => Details = x);
			base.OnNavigatedTo(e, viewModelState);
		}

		public IVideoItem Details
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
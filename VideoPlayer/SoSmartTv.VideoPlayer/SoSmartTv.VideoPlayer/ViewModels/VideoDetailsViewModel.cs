using System.Collections.Generic;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoDetailsViewModel : ViewModelBase, IVideoDetailsViewModel
	{
		private IVideoItem _details;

		public VideoDetailsViewModel()
		{
			
		}

		public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
		{
			Details = e.Parameter as IVideoItem;
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
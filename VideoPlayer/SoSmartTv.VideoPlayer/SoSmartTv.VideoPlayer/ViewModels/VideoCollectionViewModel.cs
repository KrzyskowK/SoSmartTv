using System.Collections.ObjectModel;
using Prism.Windows.Mvvm;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public class VideoCollectionViewModel : ViewModelBase, IVideoCollectionViewModel
	{
		public VideoCollectionViewModel(IVideoItemsProvider provider)
		{
			Videos = new ObservableCollection<IVideoItem>(provider.GetVideoItems());
		}

		public ObservableCollection<IVideoItem> Videos { get; }
	}
}
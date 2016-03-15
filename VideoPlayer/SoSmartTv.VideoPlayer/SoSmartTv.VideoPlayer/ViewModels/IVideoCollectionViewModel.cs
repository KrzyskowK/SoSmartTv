using System.Collections.ObjectModel;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoCollectionViewModel
	{
		ObservableCollection<IVideoItem> Videos { get; }

		int SelectedVideoId { get; set; }
	}
}
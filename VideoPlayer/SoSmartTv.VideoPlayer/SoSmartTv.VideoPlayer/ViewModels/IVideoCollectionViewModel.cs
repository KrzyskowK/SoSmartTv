using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoPlayer.ViewModels
{
	public interface IVideoCollectionViewModel
	{
		ObservableCollection<VideoItem> Videos { get; }

		int SelectedVideoId { get; set; }

		void OnVideoClick(object sender, ItemClickEventArgs e);

	}
}
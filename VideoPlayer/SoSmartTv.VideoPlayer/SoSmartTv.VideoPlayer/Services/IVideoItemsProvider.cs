using System.Collections.Generic;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public interface IVideoItemsProvider
	{
		IList<IVideoItem> GetVideoItems();
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public interface IVideoItemsProvider
	{
		Task<IList<IVideoItem>> GetVideoItems();
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public interface IVideoItemsProvider
	{
		Task<IList<IVideoItem>> GetVideoItems();

		Task<IVideoItemDetails> GetVideoItem(int id);
	}

	public interface IVideoItemDetails : IVideoItem
	{
	}

	public class VideoItemDetails : VideoItem, IVideoItemDetails
	{
		public VideoItemDetails(int id, string title, string sourcePath, string genre, string description, string posterSource, string backdropPath) : base(id, title, sourcePath, genre, description, posterSource, backdropPath)
		{
		}
	}
}
using System.Collections.Generic;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public class MockedVideoItemsProvider : IVideoItemsProvider
	{
		public IList<IVideoItem> GetVideoItems()
		{
			return new List<IVideoItem>();
		}
	}
}
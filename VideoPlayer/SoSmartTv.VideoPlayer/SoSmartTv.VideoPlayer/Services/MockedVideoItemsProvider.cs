using System.Collections.Generic;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public class MockedVideoItemsProvider : IVideoItemsProvider
	{
		public IList<IVideoItem> GetVideoItems()
		{
			var path = "ms-appx:///TestData/{0}";
			return new List<IVideoItem>()
			{
				new VideoItem(1,"Dark Knight Rises", "path", "Action", "Long Description...", string.Format(path,"dark knight rises.jpg")),
				new VideoItem(2,"Dark Knight", "path", "Action", "Long Description...", string.Format(path,"dark knight.jpg")),
				new VideoItem(3,"Avengers", "path", "Action", "Long Description...", string.Format(path,"avengers.jpg")),
				new VideoItem(4,"Avengers Age Of Ultron", "path", "Action", "Long Description...", string.Format(path,"avengers age of ultron.jpg")),
				new VideoItem(5,"Django", "path", "Action", "Long Description...", string.Format(path,"django.jpg"))
			};
		}
	}
}
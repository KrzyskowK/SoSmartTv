using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public class MockedVideoItemsProvider : IVideoItemsProvider
	{
		private readonly IMovieDatabaseApi _movieDatabaseApi;
		private readonly IVideoFilesProvider _videoFilesProvider;

		public MockedVideoItemsProvider(IMovieDatabaseApi movideDatabaseApi, IVideoFilesProvider videoFilesProvider)
		{
			_movieDatabaseApi = movideDatabaseApi;
			_videoFilesProvider = videoFilesProvider;
		}

		private async Task<IVideoItem> FetchVideoDetails(string title)
		{
			var searchResult = (await _movieDatabaseApi.SearchVideo(title)).Results.FirstOrDefault();
			if (searchResult == null)
				return null;
			var result = Mapper.Map<VideoItem>(searchResult);
			return result;
		}

		private async Task PopulateVideoDetails(IEnumerable<string> titles)
		{
			_videoItems = new List<IVideoItem>();
			var tasks = titles.Select(async x => await FetchVideoDetails(x)).ToList();
			_videoItems = (await Task.WhenAll(tasks)).Where(x => x != null).ToList();
		}

		private IList<IVideoItem> _videoItems;

		public async Task<IList<IVideoItem>> GetVideoItems()
		{
			var videoFiles = await _videoFilesProvider.GetAllVideoFiles();
			if (_videoItems == null)
				//await PopulateVideoDetails(new List<string>
				//{
				//	"Dark Knight Rises",
				//	"Dark Knight",
				//	"Avengers",
				//	"Avengers Age Of Ultron",
				//	"King Kong",
				//	"Matrix",
				//	"Deadpool",
				//});
				await PopulateVideoDetails(videoFiles.Select(x => x.Title));
			return _videoItems;
		}

		public async Task<IVideoDetailsItem> GetVideoItem(int id)
		{
			var details = await _movieDatabaseApi.GetVideoDetails(id);
			if (details == null)
				return null;
			var result = Mapper.Map<VideoDetailsItem>(details);
			return result;
			//return new VideoItemDetails(details.Id, details.Title, null, details.Genres.FirstOrDefault().ToString(), details.Overview, details.PosterPath, details.BackdropPath);
		}
	}
}
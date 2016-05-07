using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public class MockedVideoItemsProvider : IVideoItemsProvider
	{
		private readonly IMovieDatabaseApi _movieDatabaseApi;
		private readonly IVideoFilesProvider _videoFilesProvider;
		private readonly VideoDbContext _context;

		public MockedVideoItemsProvider(VideoDbContext context, IMovieDatabaseApi movideDatabaseApi, IVideoFilesProvider videoFilesProvider)
		{
			_movieDatabaseApi = movideDatabaseApi;
			_videoFilesProvider = videoFilesProvider;
			_context = context;

			
		}
		
		public IObservable<IList<IVideoItem>> GetVideoItems()
		{
			return _videoFilesProvider.GetVideoFiles()
					.SelectMany(items => items.Select(item => FetchVideoDetails(item.Title)).Concat().ToList());
		}

		public IObservable<IVideoDetailsItem> GetVideoItem(int id)
		{
			return _movieDatabaseApi.GetVideoDetails(id).ToObservable()
				.Select(x => Mapper.Map<VideoDetailsItem>(x));
		}

		private IObservable<IVideoItem> FetchVideoDetails(string title)
		{
			return _movieDatabaseApi.SearchVideo(title).ToObservable()
				.Select(x => x.Results.FirstOrDefault())
				.Where(x => x != null)
				.Select(x => Mapper.Map<VideoItem>(x));
		}

		private IObservable<IList<IVideoItem>> PopulateVideoDetails(IEnumerable<string> titles)
		{
			return titles.Select(FetchVideoDetails).Concat().ToList();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public class VideoItemsProvider : IVideoItemsProvider
	{
		private readonly VideoDbContext _context;

		public VideoItemsProvider(VideoDbContext context, IMovieDatabaseApi movideDatabaseApi, IVideoFilesProvider videoFilesProvider)
		{
			_context = context;
		}

		public IObservable<IList<IVideoItem>> GetVideoItems()
		{
			throw new NotImplementedException();
			//return _videoFilesProvider.GetVideoFiles()
			//		.SelectMany(items => items.Select(item => FetchVideoDetails(item.Title)).Concat().ToList());
		}

		public IObservable<IVideoDetailsItem> GetVideoItem(int id)
		{
			throw new NotImplementedException();
			//return _movieDatabaseApi.GetVideoDetails(id).ToObservable()
			//	.Select(x => Mapper.Map<VideoDetailsItem>(x));
		}


		private IObservable<IList<IVideoItem>> PopulateVideoDetails(IEnumerable<string> titles)
		{
			throw new NotImplementedException();
			//return titles.Select(FetchVideoDetails).Concat().ToList();
		}
	}
}
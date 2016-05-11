using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public class VideoItemsProvider : IVideoItemsProvider
	{
		private readonly IVideoFilesProvider _videoFilesProvider;

		public VideoItemsProvider(VideoDbContext context, IMovieDatabaseApi movideDatabaseApi, IVideoFilesProvider videoFilesProvider)
		{
			_videoFilesProvider = videoFilesProvider;
		}

		public IObservable<IList<VideoItem>> GetVideoItems()
		{
			//_videoFilesProvider.GetVideoFiles()
			//	.Select(x => x)

			throw new NotImplementedException();
			//return 
			//		.SelectMany(items => items.Select(item => FetchVideoDetails(item.Title)).Concat().ToList());
		}

		public IObservable<VideoDetailsItem> GetVideoItem(int id)
		{
			throw new NotImplementedException();
			//return _movieDatabaseApi.GetVideoDetails(id).ToObservable()
			//	.Select(x => Mapper.Map<VideoDetailsItem>(x));
		}


		private IObservable<IList<VideoItem>> PopulateVideoDetails(IEnumerable<string> titles)
		{
			throw new NotImplementedException();
			//return titles.Select(FetchVideoDetails).Concat().ToList();
		}
	}
}
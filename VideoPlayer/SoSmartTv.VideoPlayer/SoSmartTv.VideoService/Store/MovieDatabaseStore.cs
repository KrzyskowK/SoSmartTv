using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Store
{
	public class MovieDatabaseStore : IVideoItemsStoreReader
	{
		private readonly IMovieDatabaseApi _api;

		public MovieDatabaseStore(IMovieDatabaseApi api)
		{
			_api = api;
		}

		public IObservable<VideoItem> GetVideoItem(string title)
		{
			return _api.SearchVideo(title).ToObservable().Select(x => Mapper.Map<VideoItem>(x));
		}

		public IObservable<IList<VideoItem>> GetVideoItems(IEnumerable<string> titles)
		{
			return titles.Select(GetVideoItem).Concat().ToList();
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return _api.GetVideoDetails(id).ToObservable()
				.Select(x => Mapper.Map<VideoDetailsItem>(x));
		}
	}
}
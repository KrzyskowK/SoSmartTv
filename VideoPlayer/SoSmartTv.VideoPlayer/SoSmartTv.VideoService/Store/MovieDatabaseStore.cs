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
	public class MovieDatabaseStore : IVideoItemsStoreReader
	{
		private readonly IMovieDatabaseApi _api;

		public MovieDatabaseStore(IMovieDatabaseApi api)
		{
			_api = api;
		}

		public IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			return files.Select(item => SearchByTitle(item.Title)).Concat().ToList();
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return _api.GetVideoDetails(id).ToObservable()
				.Select(x => Mapper.Map<VideoDetailsItem>(x));
		}

		private IObservable<VideoItem> SearchByTitle(string title)
		{
			return _api.SearchVideo(title).ToObservable()
				.Select(x => x.Results.FirstOrDefault())
				.Where(x => x != null)
				.Select(x => Mapper.Map<VideoItem>(x));
		}
	}
}
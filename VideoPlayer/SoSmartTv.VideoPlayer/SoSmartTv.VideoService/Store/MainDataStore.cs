using System;
using System.Collections.Generic;
using System.Linq;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Store
{
	public class MainDataStore : IVideoItemsStore
	{
		private readonly IRedundantDataStore _store;

		public MainDataStore(IRedundantDataStore store)
		{
			_store = store;
		}

		public IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			var titles = files.Select(x => x.Title).ToList();

			return _store.FetchCollection(titles,
				p => p, e => e.Title, (p, e) => p == e.Title,
				(reader, items) => reader.GetVideoItems(items),
				(writer, items) => writer.PersistVideoItems(items));
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return
				_store.Fetch(id,
					(reader, item) => reader.GetVideoDetailsItem(item),
					(writer, item) => writer.PersistVideoDetailsItem(item));
		}
	}
}
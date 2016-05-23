using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Store;

namespace SoSmartTv.VideoService.Services
{
	public class VideoItemsProvider : IVideoItemsProvider
	{
		private readonly IVideoFilesProvider _filesProvider;
		private readonly IVideoItemsStore _store;

		public VideoItemsProvider(IVideoItemsStore store, IVideoFilesProvider filesProvider)
		{
			_filesProvider = filesProvider;
			_store = store;
		}

		public IObservable<IList<VideoItem>> GetVideoItems()
		{
			return _filesProvider.GetVideoFiles()
				.SelectMany(x => _store.GetVideoItems(x));
		}

		public IObservable<VideoDetailsItem> GetVideoItem(int id)
		{
			return _store.GetVideoDetailsItem(id);
		}
	}
}
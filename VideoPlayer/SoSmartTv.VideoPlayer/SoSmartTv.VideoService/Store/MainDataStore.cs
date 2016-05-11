using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public class MainDataStore : IVideoItemsStoreReader
	{
		private readonly IVideoItemsStoreReader _localStoreReader;
		private readonly IVideoItemsStoreWritter _localStoreWritter;
		private readonly IList<IVideoItemsStoreReader> _externalStoreReaders;

		public MainDataStore(IVideoItemsStoreReader localStoreReader, IVideoItemsStoreWritter localStoreWritter, IList<IVideoItemsStoreReader> externalStoreReaders)
		{
			_localStoreReader = localStoreReader;
			_localStoreWritter = localStoreWritter;
			_externalStoreReaders = externalStoreReaders;
		}

		public IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			return _localStoreReader.GetVideoItems(files);
			//.Where();
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			throw new NotImplementedException();
		}
	}
}
using System;
using System.Collections.Generic;
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

		public IObservable<IList<IVideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			throw new NotImplementedException();
		}

		public IObservable<IVideoDetailsItem> GetVideoDetailsItem(int id)
		{
			throw new NotImplementedException();
		}
	}
}
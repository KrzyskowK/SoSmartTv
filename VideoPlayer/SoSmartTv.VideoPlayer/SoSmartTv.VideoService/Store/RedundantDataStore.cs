using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace SoSmartTv.VideoService.Store
{
	public class RedundantDataStore : IRedundantDataStore
	{
		private readonly IVideoItemsStoreReader _localStoreReader;
		private readonly IVideoItemsStoreWriter _localStoreWriter;
		private readonly IVideoItemsStoreReader _externalStoreReaders;

		public RedundantDataStore(IVideoItemsStoreReader localStoreReader, IVideoItemsStoreWriter localStoreWriter, IVideoItemsStoreReader externalStoreReaders)
		{
			_localStoreReader = localStoreReader;
			_localStoreWriter = localStoreWriter;
			_externalStoreReaders = externalStoreReaders;
		}

		public IObservable<IEnumerable<TResult>> FetchCollection<TResult, TParam>(IEnumerable<TParam> parameters, Func<TParam, string> innerKey, Func<TResult, string> outerKey, Func<TParam, TResult, bool> joinSelector,
			Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IEnumerable<TResult>>> fetchData, Action<IVideoItemsStoreWriter, IEnumerable<TResult>> writeData)
		{
			return
				fetchData(_localStoreReader, parameters)
					.Select(x => parameters.ToUnifiedCollection(x, joinSelector, innerKey, outerKey))
					.SelectMany(x => x.IsAnyNotJoined ? FetchDataAndJoin(fetchData, writeData, x) : Observable.Return(x))
					.Select(x => x.OnlyJoined.ToList());
		}

		public IObservable<IList<TResult>> FetchCollection<TResult, TParam>(IEnumerable<TParam> parameters, Func<TParam, string> innerKey, Func<TResult, string> outerKey, Func<TParam, TResult, bool> joinSelector,
			Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IList<TResult>>> fetchData, Action<IVideoItemsStoreWriter, IList<TResult>> writeData)
		{
			return
				fetchData(_localStoreReader, parameters)
					.Select(x => parameters.ToUnifiedCollection(x, joinSelector, innerKey, outerKey))
					.SelectMany(x => x.IsAnyNotJoined ? FetchDataAndJoin(fetchData, writeData, x) : Observable.Return(x))
					.Select(x => x.OnlyJoined.ToList());
		}

		public IObservable<TResult> Fetch<TResult, TParam>(TParam parameter,
			Func<IVideoItemsStoreReader, TParam, IObservable<TResult>> fetchData,
			Action<IVideoItemsStoreWriter, TResult> writeData)
		{
			return
				fetchData(_localStoreReader, parameter)
					.Select(x => x != null ? x : fetchData(_externalStoreReaders, parameter)
						.Do(e => writeData(_localStoreWriter, e))
						.Wait());
		}


		private IObservable<RedundantCollection<TParam, TResult>> FetchDataAndJoin<TResult, TParam>(Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IEnumerable<TResult>>> fetchData, Action<IVideoItemsStoreWriter, IEnumerable<TResult>> writeData, RedundantCollection<TParam, TResult> collection)
		{
			return fetchData(_externalStoreReaders, collection.OnlyNotJoined)
				.Do(e => writeData(_localStoreWriter, e))
				.Select(e => collection.JoinIfEmpty(e));
		}

		private IObservable<RedundantCollection<TParam, TResult>> FetchDataAndJoin<TResult, TParam>(Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IList<TResult>>> fetchData, Action<IVideoItemsStoreWriter, IList<TResult>> writeData, RedundantCollection<TParam, TResult> collection)
		{
			return fetchData(_externalStoreReaders, collection.OnlyNotJoined)
				.Do(e => writeData(_localStoreWriter, e))
				.Select(e => collection.JoinIfEmpty(e));
		}

	}
}
using System;
using System.Collections.Generic;

namespace SoSmartTv.VideoService.Store
{
	public interface IRedundantDataStore
	{
		IObservable<IEnumerable<TResult>> FetchCollection<TResult, TParam>(
			IEnumerable<TParam> parameters,
			Func<TParam, TResult, bool> joinSelector,
			Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IEnumerable<TResult>>> fetchData,
			Action<IVideoItemsStoreWriter, IEnumerable<TResult>> writeData);

		IObservable<IList<TResult>> FetchCollection<TResult, TParam>(
			IEnumerable<TParam> parameters,
			Func<TParam, TResult, bool> joinSelector,
			Func<IVideoItemsStoreReader, IEnumerable<TParam>, IObservable<IList<TResult>>> fetchData,
			Action<IVideoItemsStoreWriter, IList<TResult>> writeData);


		IObservable<TResult> Fetch<TResult, TParam>(
			TParam parameter,
			Func<IVideoItemsStoreReader, TParam, IObservable<TResult>> fetchData,
			Action<IVideoItemsStoreWriter, TResult> writeData);
	}
}
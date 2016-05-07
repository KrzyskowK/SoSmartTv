using System;
using System.Collections.Generic;
using System.Reactive;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public interface IVideoItemsStoreWritter
	{
		IObservable<Unit> PersistVideoItems(IList<IVideoItem> items);

		IObservable<Unit> PersistVideoDetailsItem(IVideoDetailsItem item);
	}
}
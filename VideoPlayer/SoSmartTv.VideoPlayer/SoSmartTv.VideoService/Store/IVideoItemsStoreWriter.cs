using System;
using System.Collections.Generic;
using System.Reactive;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Store
{
	public interface IVideoItemsStoreWriter
	{
		IObservable<Unit> PersistVideoItems(IList<VideoItem> items);

		IObservable<Unit> PersistVideoDetailsItem(VideoDetailsItem item);
	}
}
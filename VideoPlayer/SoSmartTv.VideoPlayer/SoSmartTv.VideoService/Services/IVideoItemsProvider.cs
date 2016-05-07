using System;
using System.Collections.Generic;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public interface IVideoItemsProvider
	{
		IObservable<IList<IVideoItem>> GetVideoItems();

		IObservable<IVideoDetailsItem> GetVideoItem(int id);
	}
}
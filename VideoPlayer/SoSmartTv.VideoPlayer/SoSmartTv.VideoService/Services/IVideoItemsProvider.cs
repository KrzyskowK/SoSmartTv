using System;
using System.Collections.Generic;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public interface IVideoItemsProvider
	{
		IObservable<IList<VideoItem>> GetVideoItems();

		IObservable<VideoDetailsItem> GetVideoItem(int id);
	}
}
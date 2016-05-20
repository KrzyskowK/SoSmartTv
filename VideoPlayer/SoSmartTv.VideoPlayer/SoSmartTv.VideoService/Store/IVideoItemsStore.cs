using System;
using System.Collections.Generic;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Store
{
	public interface IVideoItemsStore
	{
		IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files);

		IObservable<VideoDetailsItem> GetVideoDetailsItem(int id);
	}
}
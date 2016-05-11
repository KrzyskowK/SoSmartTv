using System;
using System.Collections.Generic;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public interface IVideoItemsStoreReader
	{
		IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files);

		IObservable<VideoDetailsItem> GetVideoDetailsItem(int id);
	}
}
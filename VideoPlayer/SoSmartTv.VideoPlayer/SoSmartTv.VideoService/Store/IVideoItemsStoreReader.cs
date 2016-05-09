using System;
using System.Collections.Generic;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public interface IVideoItemsStoreReader
	{
		IObservable<IList<IVideoItem>> GetVideoItems(IList<VideoFileProperty> files);

		IObservable<IVideoDetailsItem> GetVideoDetailsItem(int id);
	}
}
using System;
using System.Collections.Generic;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Services
{
	public interface IVideoItemsProvider
	{
		IObservable<IList<IVideoItem>> GetVideoItems();

		IObservable<IVideoDetailsItem> GetVideoItem(int id);
	}
}
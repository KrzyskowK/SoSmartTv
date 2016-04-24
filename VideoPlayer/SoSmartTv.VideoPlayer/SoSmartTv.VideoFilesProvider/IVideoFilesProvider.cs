using System;
using System.Collections.Generic;
using System.Reactive;

namespace SoSmartTv.VideoFilesProvider
{
	public interface IVideoFilesProvider
	{
		IObservable<IList<VideoFileProperty>> GetVideoFiles();

		IObservable<IList<VideoFileProperty>> GetVideoFiles(int offset, int filesNumber);

		IObservable<Unit> VideoFilesChangeNotification { get; }
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Omu.ValueInjecter;
using SoSmartTv.VideoFilesProvider.TorrentFileNameParser;

namespace SoSmartTv.VideoFilesProvider
{
	public class VideoFilesProvider : IVideoFilesProvider
	{
		private readonly List<string> _videoFormatTypes = new List<string>
		{
			".wm",
			".m4v",
			".wmv",
			".asf",
			".mov",
			".3g2",
			".3gp",
			".mp4v",
			".avi",
			".pyv",
			".3gpp",
			".3gp2"
		};

		private readonly StorageFileQueryResult _fileQuery;

		public VideoFilesProvider()
		{
			_fileQuery = KnownFolders.VideosLibrary.CreateFileQueryWithOptions(CreateVideoOptions());
			VideoFilesChangeNotification = Observable.FromEventPattern<TypedEventHandler<IStorageQueryResultBase, object>, object>(
				h => _fileQuery.ContentsChanged += h,
				h => _fileQuery.ContentsChanged -= h)
				.Select(_ => Unit.Default);
		}

		private QueryOptions CreateVideoOptions()
		{
			return new QueryOptions(CommonFileQuery.OrderByTitle, _videoFormatTypes) { FolderDepth = FolderDepth.Deep };
		}

		private async Task<IList<VideoFileProperty>> GetVideoProperties(Func<Task<IReadOnlyList<StorageFile>>> fetchFiles)
		{
			var files = await fetchFiles();
			
			var videoProperties = new List<VideoFileProperty>();
			foreach (var file in files)
			{
				var videoProperty = await file.Properties.GetVideoPropertiesAsync().AsTask();
				
				var torrentProperty = TorrenVideoFileParser.Parse(file.Name);
				var property = (VideoFileProperty)new VideoFileProperty(file.Path)
					.InjectFrom(videoProperty)
					.InjectFrom(torrentProperty);
				if (!string.IsNullOrEmpty(property.Title))
					videoProperties.Add(property);
			}
			return videoProperties;
		}

		public IObservable<IList<VideoFileProperty>> GetVideoFiles()
		{
			return Observable.FromAsync(() => GetVideoProperties(() => _fileQuery.GetFilesAsync().AsTask()));
		}

		public IObservable<IList<VideoFileProperty>> GetVideoFiles(int offset, int filesNumber)
		{
			return Observable.FromAsync(() => GetVideoProperties(() => _fileQuery.GetFilesAsync((uint) offset, (uint) filesNumber).AsTask()));
		}

		public IObservable<Unit> VideoFilesChangeNotification { get; }
	}
}
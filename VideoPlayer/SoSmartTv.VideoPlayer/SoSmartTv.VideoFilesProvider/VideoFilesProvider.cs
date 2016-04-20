using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using SoSmartTv.VideoFilesProvider.TorrentFileNameParser;

namespace SoSmartTv.VideoFilesProvider
{
	public class VideoFilesProvider : IVideoFilesProvider
	{
		public async Task IncludeDirectoryIntoVideoLibrary()
		{
			await (await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos)).RequestAddFolderAsync();
		}

		public async Task ExcludeDirectoryIntoVideoLibrary(StorageFolder folder)
		{
			await (await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos)).RequestRemoveFolderAsync(folder);
		}

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

		private QueryOptions CreateVideoOptions()
		{
			return new QueryOptions(CommonFileQuery.OrderByTitle, _videoFormatTypes) { FolderDepth = FolderDepth.Deep };
		}

		public async Task<IList<VideoProperties>> GetAllVideoFiles()
		{
			var videoFolder = KnownFolders.VideosLibrary;
			var query = videoFolder.CreateFileQueryWithOptions(CreateVideoOptions());
			var files = await query.GetFilesAsync();
			
			var videoProperties = new List<VideoProperties>();
			foreach (var file in files)
			{
				var property = await file.Properties.GetVideoPropertiesAsync();
				if (!string.IsNullOrEmpty(property.Title))
					videoProperties.Add(property);
				else
				{
					var torrentInfo = TorrenVideoFileParser.Parse(file.Name);
					property.Title = torrentInfo.Title;
					videoProperties.Add(property);
				}
			}
			return videoProperties;
		}
	}
}
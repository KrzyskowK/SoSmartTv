using System;
using System.Collections.Generic;
using System.IO;

namespace SoSmartTv.VideoFilesProvider
{
	public class VideoFileWatcher : IVideoFileWatcher
	{
		private IList<DirectoryInfo> _watchedDirectories;

		public VideoFileWatcher(IList<DirectoryInfo> watchedDirectories)
		{
			_watchedDirectories = watchedDirectories ?? new List<DirectoryInfo>();
		}

		public void Start()
		{
			
		}

		public void Stop()
		{
			throw new NotImplementedException();
		}

		public void IncludeDirectory(DirectoryInfo directory)
		{
			throw new NotImplementedException();
		}

		public void ExcludeDirectory(DirectoryInfo directory)
		{
			throw new NotImplementedException();
		}

		public void WatchedDirectories(DirectoryInfo directory)
		{
			throw new NotImplementedException();
		}

		public void OnFileChange()
		{
			throw new NotImplementedException();
		}
	}
}
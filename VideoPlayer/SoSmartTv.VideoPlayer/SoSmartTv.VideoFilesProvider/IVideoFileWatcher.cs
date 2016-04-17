using System.IO;

namespace SoSmartTv.VideoFilesProvider
{
	public interface IVideoFileWatcher
	{
		void Start();

		void Stop();

		void IncludeDirectory(DirectoryInfo directory);

		void ExcludeDirectory(DirectoryInfo directory);

		void WatchedDirectories(DirectoryInfo directory);

		void OnFileChange();
	}
}
using Windows.Storage.FileProperties;
using Omu.ValueInjecter;

namespace SoSmartTv.VideoFilesProvider.TorrentFileNameParser
{
	public class MapperConfiguration
	{
		public MapperConfiguration()
		{
			//Mapper.AddMap<VideoProperties, TorrentVideoFileInfo>(src =>
			//{
			//	var video = new VideoProperties();
			//	dst.InjectFrom(src);
			//	dst.Description = src.Overview;
			//	dst.Genre = string.Join(", ", src.GenreIds.Cast<Genre>());
			//	return dst;
			//});
		} 
	}
}
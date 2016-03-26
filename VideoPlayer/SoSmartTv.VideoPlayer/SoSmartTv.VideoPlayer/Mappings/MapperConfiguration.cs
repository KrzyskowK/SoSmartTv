using System.Linq;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi.Dtos;
using SoSmartTv.VideoPlayer.ViewModels;

namespace SoSmartTv.VideoPlayer.Mappings
{
	public class MapperConfiguration
	{
		public MapperConfiguration()
		{
			Mapper.AddMap<VideoInfo, VideoItem>(src =>
			 {
				 var dst = new VideoItem();
				 dst.InjectFrom(src);
				 dst.Description = src.Overview;
				 dst.Genre = string.Join(", ", src.GenreIds.Cast<Genre>());
				 return dst;
			 });

			Mapper.AddMap<VideoDetailsInfo, VideoDetailsItem>(src =>
			{
				var dst = new VideoDetailsItem();
				dst.InjectFrom(src);
				dst.Description = src.Overview;
				dst.Genre = string.Join(", ", src.Genres);
				return dst;
			});
		}
	}
}
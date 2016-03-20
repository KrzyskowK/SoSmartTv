using System.Threading.Tasks;
using SoSmartTv.TheMovieDatabaseApi.Dtos;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public interface IMovieDatabaseApi
	{
		Task<VideoSearchResults> SearchVideo(string searchText);

		Task<VideoDetailsInfo> GetVideoDetails(int id);
	}
}
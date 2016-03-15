using System.Threading.Tasks;
using SoSmartTv.TheMovieDatabaseApi.Dtos;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public interface IMovieDatabasApi
	{
		Task<VideoSearchResults> SearchVideo(string searchText);
	}
}
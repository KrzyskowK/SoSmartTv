using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SoSmartTv.TheMovieDatabaseApi.Dtos;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public class MovideDatabaseApi : IMovieDatabasApi
	{
		private readonly HttpClient _http;

		public MovideDatabaseApi()
		{
			_http = new HttpClient();
			_http.BaseAddress = new Uri(Urls.Api);
		}

		public async Task<VideoSearchResults> SearchVideo(string searchText)
		{
			return await GetFromApi<VideoSearchResults>(string.Format("search/movie?query={0}", searchText));
		}

		public async Task<VideoDetailsInfo> GetVideoDetails(int id)
		{
			return await GetFromApi<VideoDetailsInfo>(string.Format("movie/{0}", id));
		}

		private async Task<T> GetFromApi<T>(string query)
		{
			var response = await _http.GetAsync(query);
			var jsonData = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings() { ContractResolver = new UnderscoreToPascalCaseContractResolver() };
			var result = JsonConvert.DeserializeObject<T>(jsonData, settings);

			return result;
		}
	}
}
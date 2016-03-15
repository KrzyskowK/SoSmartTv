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
			var response = await _http.GetAsync(string.Format("search/movie?query={0}", searchText));
			var jsonData = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings() { ContractResolver = new UnderscoreToPascalCaseContractResolver() };
			var result = JsonConvert.DeserializeObject<VideoSearchResults>(jsonData, settings);

			return result;
		}
	}
}
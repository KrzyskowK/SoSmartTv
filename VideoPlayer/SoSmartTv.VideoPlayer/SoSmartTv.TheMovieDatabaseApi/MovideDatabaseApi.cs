using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Omu.ValueInjecter;
using SoSmartTv.TheMovieDatabaseApi.Dtos;
using SoSmartTv.TheMovieDatabaseApi.JsonResolvers;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public class MovideDatabaseApi : IMovieDatabaseApi
	{
		private readonly HttpClient _http;

		public MovideDatabaseApi()
		{
			_http = new HttpClient();
			_http.BaseAddress = new Uri(Urls.Api);
		}

		public async Task<VideoSearchResults> SearchVideo(string searchText)
		{
			return await GetFromApi<VideoSearchResults>(FormatWithApiKey(Urls.Requests.SearchMovie, searchText));
		}

		public async Task<VideoDetailsInfo> GetVideoDetails(int id)
		{
			return await GetFromApi<VideoDetailsInfo>(FormatWithApiKey(Urls.Requests.GetMovie, id));
		}

		public async Task<VideoDetailsInfoWithCast> GetVideoDetailsWithCredits(int id)
		{
			var creditsTask = GetFromApi<VideoDetailsInfoWithCast>(FormatWithApiKey(Urls.Requests.GetMovieCredits, id));
			var detailsTask = GetFromApi<VideoDetailsInfo>(FormatWithApiKey(Urls.Requests.GetMovie, id));
			await Task.WhenAll(creditsTask, detailsTask);
			var credits = creditsTask.Result;
			var details = detailsTask.Result;
			return (VideoDetailsInfoWithCast)credits.InjectFrom(details);
		}

		private async Task<T> GetFromApi<T>(string query)
		{
			var response = await _http.GetAsync(query);
			var jsonData = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings() { ContractResolver = new UnderscoreToPascalCaseContractResolver() };
			var result = JsonConvert.DeserializeObject<T>(jsonData, settings);

			return result;
		}

		private static string FormatWithApiKey(string template, params object[] param)
		{
			if (template.Contains("?"))
				return string.Format(template, param) + "&api_key=da63548086e399ffc910fbc08526df05";
			return string.Format(template, param) + "?api_key=da63548086e399ffc910fbc08526df05";
		}
	}
}
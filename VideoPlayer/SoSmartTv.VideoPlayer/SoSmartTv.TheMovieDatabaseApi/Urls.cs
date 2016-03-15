using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public static class Urls
	{
		public static string Api { get; } = "http://private-0a2a7-themoviedb.apiary-mock.com/3/";

	}

	public interface IMovieDatabasApi
	{
		Task<VideoSearchResults> SearchVideo(string searchText);
	}

	public class UnderscoreToPascalCaseContractResolver : DefaultContractResolver
	{
		protected override string ResolvePropertyName(string propertyName)
		{
			var builder = new StringBuilder();
			foreach (var c in propertyName)
			{
				if (char.IsUpper(c))
					builder.Append('_');
				builder.Append(char.ToLower(c));
			}
			if (char.IsUpper(propertyName, 0))
				builder.Remove(0, 1);
			return base.ResolvePropertyName(builder.ToString());
		}
	}

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

	public class VideoDetailsInfo
	{
		public bool Adult { get; set; }
		public string BackdropPath { get; set; }
		public object BelongsToCollection { get; set; }
		public int Budget { get; set; }
		public List<Genre> Genres { get; set; } //class
		public string Homepage { get; set; }
		public int Id { get; set; }
		public string ImdbId { get; set; }
		public string OriginalLanguage { get; set; }
		public string OriginalTitle { get; set; }
		public string Overview { get; set; }
		public double Popularity { get; set; }
		public string PosterPath { get; set; }
		public List<string> ProductionCompanies { get; set; } //class
		public List<string> ProductionCountries { get; set; } //class
		public string ReleaseDate { get; set; }
		public int Revenue { get; set; }
		public int Runtime { get; set; }
		public List<string> SpokenLanguages { get; set; } //class
		public string Status { get; set; }
		public string Tagline { get; set; }
		public string Title { get; set; }
		public bool Video { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}

	public class VideoInfo
	{
		public bool Adult { get; set; }
		public string BackdropPath { get; set; }
		public List<int> GenreIds { get; set; }
		public int Id { get; set; }
		public string OriginalLanguage { get; set; }
		public string OriginalTitle { get; set; }
		public string Overview { get; set; }
		public string ReleaseDate { get; set; }
		public string PosterPath { get; set; }
		public double Popularity { get; set; }
		public string Title { get; set; }
		public bool Video { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}

	public class VideoSearchResults
	{
		public int Page { get; set; }
		public List<VideoInfo> Results { get; set; }
		public int TotalPages { get; set; }
		public int TotalResults { get; set; }
	}

	public enum Genre
	{

	}
}

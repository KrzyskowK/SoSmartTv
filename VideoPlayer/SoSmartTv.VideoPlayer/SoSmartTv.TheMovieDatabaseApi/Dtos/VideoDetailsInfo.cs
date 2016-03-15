using System.Collections.Generic;

namespace SoSmartTv.TheMovieDatabaseApi.Dtos
{
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
}
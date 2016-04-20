using Xunit;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	public class MovideDatabaseApiTests
	{
		private IMovieDatabaseApi _sut;

		public MovideDatabaseApiTests()
		{
			_sut = new MovideDatabaseApi();
		}

		[Fact]
		public void SearchVideo_returns_many_results_correctly()
		{
			var reposne = _sut.SearchVideo("batman");
			reposne.Wait();
			Assert.True(reposne.Result.Results.Count > 0);
		}

		[Fact]
		public void GetVideoDetails_returns_correct_result()
		{
			var reposne = _sut.GetVideoDetails(272);
			reposne.Wait();
			Assert.Equal("Batman Begins", reposne.Result.Title);
			Assert.Equal("2005-06-14", reposne.Result.ReleaseDate);
			Assert.True(reposne.Result.PosterPath.Contains(Urls.Images.Width500.Replace("{0}","")));
		}
	}
}

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	[TestClass]
	public class MovideDatabaseApiTests
	{
		private IMovieDatabaseApi _sut;

		[TestInitialize]
		public void Setup()
		{
			_sut = new MovideDatabaseApi();
		}

		[TestMethod]
		public void SearchVideo_returns_many_results_correctly()
		{
			var reposne = _sut.SearchVideo("batman");
			reposne.Wait();
			Assert.IsTrue(reposne.Result.Results.Count > 0);
		}

		[TestMethod]
		public void GetVideoDetails_returns_correct_result()
		{
			var reposne = _sut.GetVideoDetails(272);
			reposne.Wait();
			Assert.AreEqual("Batman Begins", reposne.Result.Title);
			Assert.AreEqual("2005-06-14", reposne.Result.ReleaseDate);
			Assert.IsTrue(reposne.Result.PosterPath.Contains(Urls.Images.Base.Replace("{0}","")));
		}
	}
}

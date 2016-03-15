using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace SoSmartTv.TheMovieDatabaseApi.Tests
{
	[TestClass]
	public class MovideDatabaseApiTests
	{
		private IMovieDatabasApi _sut;

		[TestInitialize]
		public void Setup()
		{
			_sut = new MovideDatabaseApi();
		}

		[TestMethod]
		public void SearchVideo_returns_correct_result()
		{
			var result = _sut.SearchVideo("batman");
			result.Wait();
			Assert.IsNotNull(result.Result);
		}

		[TestMethod]
		public void GetVideoDetails_returns_correct_result()
		{
			var result = _sut.GetVideoDetails(550);
			result.Wait();
			Assert.IsNotNull(result.Result);
		}
	}
}

using System;
using System.Reactive.Linq;
using FakeItEasy;
using SoSmartTv.VideoService.Dto;
using Xunit;

namespace SoSmartTv.VideoService.Tests.Store
{
	public class FetchTests : RedundantDataStoreTests
	{
		private void Arrange(VideoDetailsItem localStoreItem, VideoDetailsItem externalStoreItem)
		{
			A.CallTo(() => _localStoreReader.GetVideoDetailsItem(A<int>._))
				.Returns(Observable.Return(localStoreItem));
			A.CallTo(() => _externalStoreReader.GetVideoDetailsItem(A<int>._))
				.Returns(Observable.Return(externalStoreItem));
		}

		private IObservable<VideoDetailsItem> Act(int id)
		{
			return _sut.Fetch(id,
				(reader, item) => reader.GetVideoDetailsItem(item),
				(writer, item) => writer.PersistVideoDetailsItem(item));
		}

		private void AssertFetch(VideoDetailsItem results, VideoDetailsItem expected)
		{
			Assert.Equal(results.Title,expected.Title);
			Assert.Equal(results.Id, expected.Id);
		}

		[Fact]
		public void Fetch_returns_all_data_from_localReader_and_ignores_externalReader()
		{
			var local = new VideoDetailsItem() {Id = 1, Title = "Title1"};
			var external = new VideoDetailsItem() { Id = 100, Title = "Title1" };

			Arrange(local,external);
			var result = Act(1).Wait();
			AssertFetch(result,local);
			A.CallTo(() => _externalStoreReader.GetVideoDetailsItem(A<int>._)).MustNotHaveHappened();
		}
		
		[Fact]
		public void FetchCollection_returns_all_data_from_externalReader_when_localReader_empty()
		{
			var local = (VideoDetailsItem)null;
			var external = new VideoDetailsItem() { Id = 100, Title = "Title1" };

			Arrange(local, external);
			var result = Act(1).Wait();
			AssertFetch(result, external);
		}
		
		[Fact]
		public void FetchCollection_returns_null_when_no_matched_records()
		{
			var local = (VideoDetailsItem)null;
			var external = (VideoDetailsItem)null;

			Arrange(local, external);
			var result = Act(1).Wait();
			Assert.Null(result);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Store;
using Xunit;
using Assert = Xunit.Assert;

namespace SoSmartTv.VideoService.Tests.Store
{
	public abstract class RedundantDataStoreTests
	{
		protected IRedundantDataStore _sut;
		protected IVideoItemsStoreReader _localStoreReader;
		protected IVideoItemsStoreReader _externalStoreReader;
		protected IVideoItemsStoreWriter _localStoreWriter;

		protected RedundantDataStoreTests()
		{
			_localStoreReader = A.Fake<IVideoItemsStoreReader>();
			_externalStoreReader = A.Fake<IVideoItemsStoreReader>();
			_localStoreWriter = A.Fake<IVideoItemsStoreWriter>();

			_sut = new RedundantDataStore(_localStoreReader, _localStoreWriter, _externalStoreReader);
		}
	}

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

	public class FetchCollectionTests : RedundantDataStoreTests
	{
		private IList<VideoItem> GetVideoItems()
		{
			return Enumerable.Range(0, 20).Select(x => new VideoItem() {Id = x, Title = "Title" + x}).ToList();
		}

		private void Arrange(IList<VideoItem> localStoreItems, IList<VideoItem> externalStoreItems)
		{
			A.CallTo(() => _localStoreReader.GetVideoItems(A<IEnumerable<string>>._))
				.Returns(Observable.Return(localStoreItems));
			A.CallTo(() => _externalStoreReader.GetVideoItems(A<IEnumerable<string>>._))
				.Returns(Observable.Return(externalStoreItems));
		}

		private IObservable<IList<VideoItem>> Act(IEnumerable<string> titles)
		{
			return _sut.FetchCollection(titles, x => x, y => y.Title, (x, y) => x == y.Title,
				(store, x) => store.GetVideoItems(x),
				(store, x) => store.PersistVideoItems(x));
		}

		private void AssertFetchCollection(IList<VideoItem> results, IList<VideoItem> expected)
		{
			Assert.Equal(results.Count, expected.Count);
			CollectionAssert.AreEqual(results.Select(x => x.Id).ToList(), expected.Select(x => x.Id).ToList());
			CollectionAssert.AreEqual(results.Select(x => x.Title).ToList(), expected.Select(x => x.Title).ToList());
		}

		[Fact]
		public void FetchCollection_returns_all_data_from_localReader_and_ignores_externalReader()
		{
			var localItems = GetVideoItems();
			var externalItems = GetVideoItems().Do(x => x.Id += 100).ToList();

			Arrange(localItems, externalItems);
			var results = Act(GetVideoItems().Select(i => i.Title)).Wait();

			AssertFetchCollection(results, localItems);
			A.CallTo(() => _externalStoreReader.GetVideoItems(A<IEnumerable<string>>._)).MustNotHaveHappened();
		}

		[Fact]
		public void FetchCollection_returns_all_data_from_externalReader_when_localReader_empty()
		{
			var localItems = new List<VideoItem>();
			var externalItems = GetVideoItems().Do(x => x.Id += 100).ToList();

			Arrange(localItems, externalItems);
			var results = Act(GetVideoItems().Select(i => i.Title)).Wait();
			AssertFetchCollection(results, externalItems);
		}

		[Fact]
		public void FetchCollection_returns_part_of_data_from_externalReader_when_localReader_returns_only_part_of_it()
		{
			var localItems = GetVideoItems().Take(2).Skip(2).Take(2).TakeLast(2).ToList();
			var externalItems = GetVideoItems().Skip(2).Take(2).Skip(2).Take(12).Do(x => x.Id += 100).ToList();
			var expected = localItems.Concat(externalItems).OrderBy(x => x.Title).ToList();

			Arrange(localItems, externalItems);
			var results = Act(GetVideoItems().Select(i => i.Title)).Wait();
			AssertFetchCollection(results, expected);
		}

		[Fact]
		public void FetchCollection_returns_only_matched_records()
		{
			var localItems = GetVideoItems().Take(2).ToList();
			var externalItems = GetVideoItems().TakeLast(2).Do(x => x.Id += 100).ToList();
			var expected = localItems.Concat(externalItems).OrderBy(x => x.Title).ToList();

			Arrange(localItems, externalItems);
			var results = Act(GetVideoItems().Select(i => i.Title)).Wait();
			AssertFetchCollection(results, expected);
		}

		[Fact]
		public void FetchCollection_returns_empty_when_no_matched_records()
		{
			var localItems = new List<VideoItem>();
			var externalItems = new List<VideoItem>();
			
			Arrange(localItems, externalItems);
			var results = Act(GetVideoItems().Select(i => i.Title)).Wait();
			AssertFetchCollection(results, new List<VideoItem>());
		}
	}
}
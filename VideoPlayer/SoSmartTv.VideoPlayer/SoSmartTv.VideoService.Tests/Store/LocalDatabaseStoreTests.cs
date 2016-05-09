using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Collections.Immutable;
using FakeItEasy;
using Microsoft.Data.Entity;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Services;
using Xunit;

namespace SoSmartTv.VideoService.Tests.Store
{
	public class LocalDatabaseStoreTests
	{
		private IVideoItemsStoreReader _sut;
		private List<VideoItem> _data;

		public LocalDatabaseStoreTests()
		{
			_data = new List<VideoItem>
			{
				new VideoItem() {Title = "A"},
				new VideoItem() {Title = "D"},
				new VideoItem() {Title = "F"},
			};

			var context = SetupDbContextWithDbSet(dbContext => dbContext.AddRange(_data));

			_sut = new LocalDatabaseStore(context);
		}

		private VideoDbContext SetupDbContextWithDbSet(Action<VideoDbContext> setupDbSet)
		{
			var optionsBuilder = new DbContextOptionsBuilder<VideoDbContext>();
			optionsBuilder.UseInMemoryDatabase();

			var context = new VideoDbContext(optionsBuilder.Options);
			setupDbSet(context);
			context.SaveChanges();
			return context;
		}

		[Fact]
		public void GetVideoItems_returns_correct_results()
		{
			var files = new List<VideoFileProperty>()
			{
				new VideoFileProperty("path") {Title = "A"},
				new VideoFileProperty("path") {Title = "B"},
				new VideoFileProperty("path") {Title = "C"},
				new VideoFileProperty("path") {Title = "D"},
				new VideoFileProperty("path") {Title = "E"},
				new VideoFileProperty("path") {Title = "F"},
				new VideoFileProperty("path") {Title = "G"}
			};
			var result = _sut.GetVideoItems(files).Wait();
			Assert.Equal(result.Count,files.Count(x => x.Title == "A" || x.Title == "B" || x.Title == "C"));
		}
	}
}
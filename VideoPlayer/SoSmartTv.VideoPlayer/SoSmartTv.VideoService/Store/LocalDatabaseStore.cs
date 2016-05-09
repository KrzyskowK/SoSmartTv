using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Microsoft.Data.Entity;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Services
{
	public class LocalDatabaseStore : IVideoItemsStoreReader, IVideoItemsStoreWritter
	{
		private readonly VideoDbContext _context;

		public LocalDatabaseStore(VideoDbContext context)
		{
			_context = context;
		}

		public IObservable<IList<IVideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			return _context.VideoItems
				.Where(x => files.Any(f => f.Title == x.Title))
				.AsAsyncEnumerable<IVideoItem>()
				.ToObservable().ToList();
		}

		public IObservable<IVideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return _context.VideoDetailsItems
				.AsAsyncEnumerable<IVideoDetailsItem>()
				.Where(x => x.Id == id)
				.FirstOrDefault()
				.ToObservable();
		}

		public IObservable<Unit> PersistVideoItems(IList<IVideoItem> items)
		{
			_context.VideoItems.AddRange(items.Cast<VideoItem>());
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);

		}

		public IObservable<Unit> PersistVideoDetailsItem(IVideoDetailsItem item)
		{
			_context.VideoDetailsItems.Add(item as VideoDetailsItem);
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);
		}
	}
}
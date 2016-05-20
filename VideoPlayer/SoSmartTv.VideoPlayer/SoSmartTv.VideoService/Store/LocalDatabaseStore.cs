using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Microsoft.Data.Entity;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService.Store
{
	public class LocalDatabaseStore : IVideoItemsStoreReader, IVideoItemsStoreWriter
	{
		private readonly VideoDbContext _context;

		public LocalDatabaseStore(VideoDbContext context)
		{
			_context = context;
		}

		public IObservable<VideoItem> GetVideoItem(string title)
		{
			return _context.VideoItems
				.FirstOrDefaultAsync(x => x.Title == title)
				.ToObservable();
		}

		public IObservable<IList<VideoItem>> GetVideoItems(IEnumerable<string> titles)
		{
			return _context.VideoItems
				.Where(x => titles.Any(title => title == x.Title))
				.ToListAsync()
				.ToObservable();
		}

		private VideoItem VideoItemOrDefault(VideoItem videoItem, string title)
		{
			if (videoItem == null)
				return new VideoItem() { Title = title };
			return videoItem;
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return _context.VideoDetailsItems
				.FirstOrDefaultAsync(x => x.Id == id)
				.ToObservable();
		}

		public IObservable<Unit> PersistVideoItems(IList<VideoItem> items)
		{
			_context.VideoItems.AddRange(items);
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);
		}

		public IObservable<Unit> PersistVideoDetailsItem(VideoDetailsItem item)
		{
			_context.VideoDetailsItems.Add(item);
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);
		}
	}
}
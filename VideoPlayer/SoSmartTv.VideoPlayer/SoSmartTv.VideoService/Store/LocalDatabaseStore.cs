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

		public IObservable<IList<VideoItem>> GetVideoItems(IList<VideoFileProperty> files)
		{
			return _context.VideoItems
				.Where(x => files.Any(f => f.Title == x.Title))
				.Join(files,x => x.Title,y=> y.Title, VideoItemOrDefault)
				.ToObservable().ToList();
		}

		private VideoItem VideoItemOrDefault(VideoItem videoItem, VideoFileProperty property)
		{
			if(videoItem == null)
				return new VideoItem() {Title = property.Title};
			return videoItem;
		}

		public IObservable<VideoDetailsItem> GetVideoDetailsItem(int id)
		{
			return _context.VideoDetailsItems
				.Where(x => x.Id == id)
				.ToObservable()
				.FirstOrDefaultAsync();
		}

		public IObservable<Unit> PersistVideoItems(IList<VideoItem> items)
		{
			_context.VideoItems.AddRange(items.Cast<VideoItem>());
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);

		}

		public IObservable<Unit> PersistVideoDetailsItem(VideoDetailsItem item)
		{
			_context.VideoDetailsItems.Add(item as VideoDetailsItem);
			return _context.SaveChangesAsync().ToObservable().Select(_ => Unit.Default);
		}
	}
}
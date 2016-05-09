using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService
{
	public class VideoDbContext : DbContext
	{
		public VideoDbContext(DbContextOptions options) : base(options)
		{
			
		}

		public virtual DbSet<VideoItem> VideoItems { get; set; }
		public virtual DbSet<VideoDetailsItem> VideoDetailsItems { get; set; } 

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}
	}
}

using Microsoft.Data.Entity;
using SoSmartTv.VideoService.Dto;

namespace SoSmartTv.VideoService
{
	public class VideoDbContext : DbContext
	{
		public DbSet<VideoItem> VideoItems { get; set; }
		public DbSet<VideoDetailsItem> VideoDetailsItems { get; set; } 

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=sosmarttv.db");
		}
	}
}

using Autofac;
using Microsoft.Data.Entity;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Mappings;
using SoSmartTv.VideoService.Services;

namespace SoSmartTv.VideoService
{
	public static class ServiceBootstrap
	{
		public static void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<MovideDatabaseApi>().As<IMovieDatabaseApi>();
			builder.RegisterType<VideoFilesProvider.VideoFilesProvider>().As<IVideoFilesProvider>();
			builder.RegisterType<MockedVideoItemsProvider>().As<IVideoItemsProvider>();
			builder.RegisterInstance(new MapperConfiguration());
		}

		public static void IncludeMigrations()
		{
			#if DEBUG
			using (var db = new VideoDbContext())
			{
				db.Database.Migrate();
			}
			#endif
		}
	}
}

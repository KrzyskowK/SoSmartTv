using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Microsoft.Data.Entity;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Mappings;
using SoSmartTv.VideoService.Services;
using SoSmartTv.VideoService.Store;

namespace SoSmartTv.VideoService
{
	public static class ServiceBootstrap
	{
		public static void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<MovideDatabaseApi>().As<IMovieDatabaseApi>().InstancePerLifetimeScope();
			builder.RegisterType<VideoFilesProvider.VideoFilesProvider>().As<IVideoFilesProvider>().InstancePerLifetimeScope();

			builder.RegisterType<LocalDatabaseStore>().InstancePerLifetimeScope();
			builder.RegisterType<MovieDatabaseStore>().InstancePerLifetimeScope();
			builder.RegisterType<MainDataStore>().As<IVideoItemsStore>().InstancePerLifetimeScope();
			builder.RegisterType<RedundantDataStore>().As<IRedundantDataStore>().InstancePerLifetimeScope()
				.WithParameter((p, c) => p.Name == "localStoreReader", (p, c) => c.Resolve<LocalDatabaseStore>())
				.WithParameter((p, c) => p.Name == "externalStoreReader", (p, c) => c.Resolve<MovieDatabaseStore>())
				.WithParameter((p, c) => p.Name == "localStoreWriter", (p, c) => c.Resolve<LocalDatabaseStore>());
			
			builder.RegisterType<VideoItemsProvider>().As<IVideoItemsProvider>().InstancePerLifetimeScope();

			var optionsBuilder = new DbContextOptionsBuilder<VideoDbContext>();
			optionsBuilder.UseSqlite("Filename=sosmarttv.db");
			builder.RegisterInstance(new VideoDbContext(optionsBuilder.Options));
			builder.RegisterInstance(new MapperConfiguration());
		}

		public static void IncludeMigrations()
		{
#if DEBUG
			var optionsBuilder = new DbContextOptionsBuilder<VideoDbContext>();
			optionsBuilder.UseSqlite("Filename=sosmarttv.db");
			using (var db = new VideoDbContext(optionsBuilder.Options))
			{
				db.Database.Migrate();
			}
#endif
		}
	}
}

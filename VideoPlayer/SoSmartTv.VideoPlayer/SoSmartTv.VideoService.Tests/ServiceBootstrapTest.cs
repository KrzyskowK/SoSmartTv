using Autofac;
using Microsoft.Data.Entity;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoService.Services;
using SoSmartTv.VideoService.Store;
using Xunit;

namespace SoSmartTv.VideoService.Tests
{
	public static class ContainerAssertion
	{
		public static void IsSingletone<T>(IContainer container)
		{
			var instance1 = container.Resolve<T>();
			var instance2 = container.Resolve<T>();
			Assert.Same(instance1, instance2);
		}
	}

	public class ServiceBootstrapTest
	{
		private readonly IContainer _container;

		public ServiceBootstrapTest()
		{
			var builder = new ContainerBuilder();
			ServiceBootstrap.ConfigureContainer(builder);
			_container = builder.Build();
		}

		[Fact]
		public void IMovieDatabaseApi_should_be_singletone()
		{
			ContainerAssertion.IsSingletone<IMovieDatabaseApi>(_container);
		}

		[Fact]
		public void IVideoFileProvider_should_be_singletone()
		{
			ContainerAssertion.IsSingletone<IVideoFilesProvider>(_container);
		}

		[Fact]
		public void VideoDbContext_should_be_singletone()
		{
			ContainerAssertion.IsSingletone<VideoDbContext>(_container);
		}

		[Fact]
		public void MovideDatabaseStore_should_be_singletone()
		{
			ContainerAssertion.IsSingletone<MovieDatabaseStore>(_container);
		}
	}
}
using System;
using System.Globalization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using Prism.Autofac.Windows;
using SoSmartTv.TheMovieDatabaseApi;
using SoSmartTv.VideoPlayer.Services;

namespace SoSmartTv.VideoPlayer
{
	public sealed partial class App : PrismAutofacApplication
	{
		public App()
		{
			InitializeComponent();
		}

		protected override UIElement CreateShell(Frame rootFrame)
		{
			var shell = Container.Resolve<AppShell>();
			shell.SetContentFrame(rootFrame);	
			return shell;
		}

		protected override Type GetPageType(string pageToken)
		{
			var type = Type.GetType(string.Format(CultureInfo.InvariantCulture, GetType().AssemblyQualifiedName.Replace(GetType().FullName, GetType().Namespace + ".Views.{0}View"), pageToken));
			if (type != null)
				return type;
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourceLoader.GetForCurrentView("/Prism.Windows/Resources/").GetString("DefaultPageTypeLookupErrorMessage"), pageToken, GetType().Namespace + ".Views"), nameof(pageToken));
		}

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<MovideDatabaseApi>().As<IMovieDatabaseApi>();
			builder.RegisterType<MockedVideoItemsProvider>().As<IVideoItemsProvider>();
			
			base.ConfigureContainer(builder);
		}

		protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
		{
			NavigationService.Navigate("VideoPlayer", null);
			Window.Current.Activate();
			return Task.FromResult(true);
		}
	}
}

using System;
using System.Globalization;
using System.Reactive.Concurrency;
using System.Reflection;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using Prism.Autofac.Windows;
using Prism.Mvvm;
using SoSmartTv.VideoService;
using SoSmartTv.VideoService.Services;

namespace SoSmartTv.VideoPlayer
{
	public sealed partial class App : PrismAutofacApplication
	{
		public App()
		{
			InitializeComponent();
			ServiceBootstrap.IncludeMigrations();
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

		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();
			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
			{
				var viewName = viewType.FullName;
				viewName = viewName.Replace(".Views.", ".ViewModels.");
				var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
				var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
				var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}", viewName, suffix);

				var assembly = viewType.GetTypeInfo().Assembly;
				var type = assembly.GetType(viewModelName, true, true);

				return type;
			});
		}

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			ServiceBootstrap.ConfigureContainer(builder);

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

using System;
using System.Globalization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using Prism.Autofac.Windows;

namespace Uwp.Xaml.Navigation.Prism
{
	sealed partial class App : PrismAutofacApplication
	{
		public App()
		{
			this.InitializeComponent();
		}

		protected override UIElement CreateShell(Frame rootFrame)
		{
			var shell = Container.Resolve<MainPage>();
			shell.SetFrame(rootFrame);
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
		}

		protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
		{
			NavigationService.Navigate("First", new object());
			Window.Current.Activate();
			return Task.FromResult(true);
		}
	}
}

using Windows.UI.Xaml.Controls;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.ViewModels;

namespace Uwp.Xaml.Navigation
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			this.Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			ViewModel = new MainViewModel(NavigationServiceProvider.GetNavigationService());
			Bindings.Update();
		}

		public MainViewModel ViewModel { get; private set; }

		public Frame RootFrame => this.Frame;

	}
}

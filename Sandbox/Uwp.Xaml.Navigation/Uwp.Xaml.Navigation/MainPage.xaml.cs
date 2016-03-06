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
			ViewModel = new MainViewModel(NestedNavigationServiceProvider.GetNavigationServiceAndRegisterFrame(FrameTargets.RootFrame, RootFrame));
		}

		public MainViewModel ViewModel { get; private set; }

		public Frame RootFrame => this.Frame;

	}
}

using Windows.UI.Xaml;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.Pages;

namespace Uwp.Xaml.Navigation.ViewModels
{
	public class PageOneViewModel
	{
		private readonly INestedNavigationService _navigationService;

		public PageOneViewModel(INestedNavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void OnClick(object sender, RoutedEventArgs e)
		{
			_navigationService.Navigate(FrameTargets.RootFrame,PageTargets.PageThree);
		}
	}
}
using Windows.UI.Xaml;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.Pages;

namespace Uwp.Xaml.Navigation.ViewModels
{
	public class PageOneViewModel
	{
		private readonly INavigationService _navigationService;

		public PageOneViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void OnClick(object sender, RoutedEventArgs e)
		{
			_navigationService.Navigate(typeof (PageThree));
		}
	}
}
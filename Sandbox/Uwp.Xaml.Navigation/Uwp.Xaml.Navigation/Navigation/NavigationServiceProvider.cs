using Windows.UI.Xaml;

namespace Uwp.Xaml.Navigation.Navigation
{
	public static class NavigationServiceProvider
	{
		private static INavigationService _navigationService;

		private static INavigationService CreateNavigationService()
		{
			var frame = ((MainPage)Window.Current.Content).RootFrame;
			return new NavigationService(frame);
		}

		public static INavigationService GetNavigationService()
		{
			return _navigationService ?? (_navigationService = CreateNavigationService());
		}
	}
}
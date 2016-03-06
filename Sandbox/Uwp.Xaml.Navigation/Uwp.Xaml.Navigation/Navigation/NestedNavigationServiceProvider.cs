using Windows.UI.Xaml.Controls;

namespace Uwp.Xaml.Navigation.Navigation
{
	public static class NestedNavigationServiceProvider
	{
		private static INestedNavigationService _navigationService;

		private static INestedNavigationService CreateNavigationService()
		{
			return new NestedNavigationService();
		}

		public static INestedNavigationService GetNavigationService()
		{
			return _navigationService ?? (_navigationService = CreateNavigationService());
		}

		public static INestedNavigationService GetNavigationServiceAndRegisterFrame(string frameTargetKey, Frame frame)
		{
			var service = GetNavigationService();
			service.RegisterFrame(frameTargetKey, frame);
			return service;
		}
	}
}
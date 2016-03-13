using System.Collections.Generic;
using Windows.UI.Xaml;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace Uwp.Xaml.Navigation.Prism.ViewModels
{
	public class FirstViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationNavigationService;

		public FirstViewModel(INavigationService navigationService)
		{
			_navigationNavigationService = navigationService;
		}
		
		public string Title => "First View Model";

		public void OnClickPageThree(object sender, RoutedEventArgs e)
		{
			_navigationNavigationService.Navigate("Third", null);
		}

		public void OnClickPageTwo(object sender, RoutedEventArgs e)
		{
			_navigationNavigationService.Navigate("Second", null);
		}

		public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> dictionary)
		{
			base.OnNavigatedTo(e, dictionary);
		}

		public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
		{
			base.OnNavigatingFrom(e, viewModelState, suspending);
		}
	}
}
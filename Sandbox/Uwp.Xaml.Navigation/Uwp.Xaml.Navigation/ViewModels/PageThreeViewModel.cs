using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.Pages;
using Uwp.Xaml.Navigation.Pages.SubPages;

namespace Uwp.Xaml.Navigation.ViewModels
{
	public class PageThreeViewModel : NotificationObject
	{
		public PageThreeViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			_navigationService.Navigated += OnNavigated;
			SubNavigationTargets = new List<NavigationTargeViewModel>()
			{
				new NavigationTargeViewModel("Page A", typeof(SubPageA)),
				new NavigationTargeViewModel("Page B", typeof(SubPageB)),
			};
		}

		private void OnNavigated(object sender, NavigationEventArgs e)
		{
			if (SubNavigationTargets.Any(x => x.TargetType == e.SourcePageType))
				SelectedSubNavigationTarget = SubNavigationTargets.Single(x => x.TargetType == e.SourcePageType);
		}

		private NavigationTargeViewModel _selectedSubNavigationTarget;
		private readonly INavigationService _navigationService;
		public IList<NavigationTargeViewModel> SubNavigationTargets { get; }

		public NavigationTargeViewModel SelectedSubNavigationTarget
		{
			get { return _selectedSubNavigationTarget; }
			set
			{
				_selectedSubNavigationTarget = value;
				OnPropertyChanged();
			}
		}

		public void OnSubNavigationTargetClick(object sender, ItemClickEventArgs e)
		{
			var navigationTarget = e.ClickedItem as NavigationTargeViewModel;
			if (navigationTarget != null)
				_navigationService.Navigate(navigationTarget.TargetType, navigationTarget);
		}
	}
}
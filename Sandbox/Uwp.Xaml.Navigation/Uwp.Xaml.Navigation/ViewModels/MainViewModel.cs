using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.Pages;

namespace Uwp.Xaml.Navigation.ViewModels
{
	public class MainViewModel : NotificationObject
	{
		public MainViewModel(INestedNavigationService navigationService)
		{
			_navigationService = navigationService;
			_navigationService.Navigated += OnNavigated;
			_navigationService.Disposing += OnDisposing;
			NavigationTargets = new List<NavigationTargeViewModel>()
			{
				new NavigationTargeViewModel("Page One", PageTargets.PageOne),
				new NavigationTargeViewModel("Page Two", PageTargets.PageTwo),
				new NavigationTargeViewModel("Page Three", PageTargets.PageThree)
			};
		}

		public IList<NavigationTargeViewModel> NavigationTargets { get; }

		public NavigationTargeViewModel SelectedNavigationTarget
		{
			get { return _selectedNavigationTarget; }
			set
			{
				_selectedNavigationTarget = value;
				OnPropertyChanged();
			}
		}

		public void OnNavigationTargetClick(object sender, ItemClickEventArgs e)
		{
			var navigationTarget = e.ClickedItem as NavigationTargeViewModel;
			if (navigationTarget != null)
				_navigationService.Navigate(FrameTargets.RootFrame, navigationTarget.TargetType, navigationTarget);
		}
		
		private void OnDisposing(object sender, string e)
		{
			if (e != FrameTargets.RootFrame) return;
			_navigationService.Navigated -= OnNavigated;
			_navigationService.Disposing -= OnDisposing;
		}

		private void OnNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
		{
			if (NavigationTargets.Any(x => x.TargetType == e.SourcePageType))
				SelectedNavigationTarget = NavigationTargets.Single(x => x.TargetType == e.SourcePageType);
		}

		private readonly INestedNavigationService _navigationService;
		private NavigationTargeViewModel _selectedNavigationTarget;
	}
}
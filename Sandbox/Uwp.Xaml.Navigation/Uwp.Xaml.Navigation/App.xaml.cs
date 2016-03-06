using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uwp.Xaml.Navigation.Navigation;

namespace Uwp.Xaml.Navigation
{
	sealed partial class App : Application
	{
		public App()
		{
			this.InitializeComponent();
			this.Suspending += OnSuspending;
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			var mainPage = Window.Current.Content as MainPage;
			if (mainPage == null)
			{
				mainPage = new MainPage();
				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}
				Window.Current.Content = mainPage;
				
				NestedNavigationServiceProvider.GetNavigationService().Navigated += OnNavigated;
				SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
				SetBackButtonVisibility();
			}
			Window.Current.Activate();
		}

		private void OnNavigated(object sender, NavigationEventArgs e)
		{
			SetBackButtonVisibility();
		}

		private void OnBackRequested(object sender, BackRequestedEventArgs e)
		{
			NestedNavigationServiceProvider.GetNavigationService().GoBack();
		}

		private void SetBackButtonVisibility()
		{
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = NestedNavigationServiceProvider.GetNavigationService().CanGoBack
				? AppViewBackButtonVisibility.Visible
				: AppViewBackButtonVisibility.Collapsed;
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}

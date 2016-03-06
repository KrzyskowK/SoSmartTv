using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
				mainPage.RootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				Window.Current.Content = mainPage;

				mainPage.RootFrame.Navigated += OnNavigated;
				SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
				SetBackButtonVisibility(mainPage.RootFrame);
			}
			
			Window.Current.Activate();
		}

		private void OnNavigated(object sender, NavigationEventArgs e)
		{
			var mainPage = Window.Current.Content as MainPage;
			SetBackButtonVisibility(mainPage.RootFrame);
		}

		private void OnBackRequested(object sender, BackRequestedEventArgs e)
		{
			var mainPage = Window.Current.Content as MainPage;
			mainPage.RootFrame.GoBack();
		}

		private void SetBackButtonVisibility(Frame rootFrame)
		{
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = rootFrame.CanGoBack
				? AppViewBackButtonVisibility.Visible
				: AppViewBackButtonVisibility.Collapsed;
		}

		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}

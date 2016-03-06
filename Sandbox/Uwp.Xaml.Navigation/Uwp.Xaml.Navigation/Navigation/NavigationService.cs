using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Xaml.Navigation.Navigation
{
	public class NavigationService : INavigationService
	{
		private readonly Frame _frame;

		public NavigationService(Frame rootFrame)
		{
			_frame = rootFrame;
			_frame.Navigated += OnFrameNavigated;
		}

		private void OnFrameNavigated(object sender, NavigationEventArgs e)
		{
			Navigated?.Invoke(sender, e);
		}

		public NavigatedEventHandler Navigated { get; set; }

		public void Navigate(Type sourcePageType, object context)
		{
			_frame.Navigate(sourcePageType, context);
		}

		public void Navigate(Type sourcePageType)
		{
			_frame.Navigate(sourcePageType);
		}
	}
}
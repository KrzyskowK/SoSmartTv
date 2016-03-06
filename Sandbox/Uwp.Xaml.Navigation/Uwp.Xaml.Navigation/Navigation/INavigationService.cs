using System;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Xaml.Navigation.Navigation
{
	public interface INavigationService
	{
		void Navigate(Type sourcePageType, object context);

		void Navigate(Type sourcePageType);

		NavigatedEventHandler Navigated { get; set; }
	}
}
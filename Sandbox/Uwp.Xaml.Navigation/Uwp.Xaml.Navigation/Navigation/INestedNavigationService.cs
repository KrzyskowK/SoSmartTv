using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Xaml.Navigation.Navigation
{
	public interface INestedNavigationService
	{
		void Navigate(string frameKey, Type sourcePageType, object context);

		void Navigate(string frameKey, Type sourcePageType);

		void GoBack();

		bool CanGoBack { get; }

		NavigatedEventHandler Navigated { get; set; }

		EventHandler<string> Disposing { get; set; }

		void RegisterFrame(string frameKey, Frame frame, string parentFrameKey = null);

		void UnRegisterFrame(string frameKey);

		bool IsFrameRegistered(string frameKey);
	}
}
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Xaml.Navigation.Navigation
{
	public interface INestedNavigationService
	{
		void Navigate(string frameTargetKey, Type sourcePageType, object context);

		void Navigate(string frameTargetKey, Type sourcePageType);

		void GoBack();

		bool CanGoBack { get; }

		NavigatedEventHandler Navigated { get; set; }

		EventHandler<string> Disposing { get; set; }

		void RegisterFrame(string frameTargetKey, Frame frame, string frameTargetKeyParent = null);

		void UnRegisterFrame(string frameTargetKey);

		bool IsFrameRegistered(string frameTargetKey);
	}
}
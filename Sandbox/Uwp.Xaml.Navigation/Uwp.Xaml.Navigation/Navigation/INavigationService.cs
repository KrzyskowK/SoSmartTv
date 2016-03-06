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

	public interface INavigationServiceParentMap 
	{
		string ParentFrameTargetKey { get; }

		bool HasParentFrameTargetKey { get; }

		INavigationService NagivationService { get; }
	}

	public class NavigationServiceParentMap : INavigationServiceParentMap
	{
		public NavigationServiceParentMap(string parentFrameTargetKey, INavigationService navigationService)
		{
			NagivationService = navigationService;
			ParentFrameTargetKey = parentFrameTargetKey;
		}

		public string ParentFrameTargetKey { get; }

		public bool HasParentFrameTargetKey => !string.IsNullOrEmpty(ParentFrameTargetKey);

		public INavigationService NagivationService { get; }
	}
}
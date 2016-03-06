using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Xaml.Navigation.Navigation
{
	public class NestedNavigationService : INestedNavigationService
	{
		private readonly Dictionary<string, Frame> _navigationServiceRegister = new Dictionary<string, Frame>();
		private readonly Dictionary<string, IList<string>> _framesMap = new Dictionary<string, IList<string>>();
		private readonly Stack<string> _navigationStack = new Stack<string>();

		public void Navigate(string frameTargetKey, Type sourcePageType, object context)
		{
			_navigationServiceRegister[frameTargetKey].Navigate(sourcePageType, context);
		}

		public void Navigate(string frameTargetKey, Type sourcePageType)
		{
			_navigationServiceRegister[frameTargetKey].Navigate(sourcePageType);
		}

		public void GoBack()
		{
			var last = _navigationStack.Pop();
			var frame = _navigationServiceRegister[last];
			if (frame.CanGoBack)
				frame.GoBack();
			else if (CanGoBack) GoBack();
		}

		public bool CanGoBack => _navigationStack.Count > 1;

		private void OnFrameNavigated(object sender, NavigationEventArgs e)
		{
			Navigated?.Invoke(sender, e);
		}

		private void OnFrameNavigating(object sender, NavigatingCancelEventArgs e)
		{
			if (e.NavigationMode == NavigationMode.New)
			{
				var frameKey = _navigationServiceRegister.First(x => x.Value == sender).Key;
				_navigationStack.Push(frameKey);
			}
		}

		public NavigatedEventHandler Navigated { get; set; }

		public EventHandler<string> Disposing { get; set; }

		public void RegisterFrame(string frameTargetKey, Frame frame, string frameTargetKeyParent = null)
		{
			if (IsFrameRegistered(frameTargetKey))
				UnRegisterFrame(frameTargetKey);

			RegisterFrameMap(frameTargetKey, frameTargetKeyParent);

			_navigationServiceRegister.Add(frameTargetKey, frame);
			_navigationServiceRegister[frameTargetKey].Navigated += OnFrameNavigated;
			_navigationServiceRegister[frameTargetKey].Navigating += OnFrameNavigating;
		}

		private void RegisterFrameMap(string frameTargetKey, string frameTargetKeyParent)
		{
			_framesMap.Add(frameTargetKey, new List<string>());
			if (frameTargetKeyParent != null)
				_framesMap[frameTargetKeyParent].Add(frameTargetKey);
		}

		public void UnRegisterFrame(string frameTargetKey)
		{
			foreach (var childFrameKey in _framesMap[frameTargetKey])
			{
				UnRegisterFrame(childFrameKey);
			}

			Disposing?.Invoke(this, frameTargetKey);
			_framesMap.Remove(frameTargetKey);
			_navigationServiceRegister[frameTargetKey].Navigated -= OnFrameNavigated;
			_navigationServiceRegister.Remove(frameTargetKey);
		}

		public bool IsFrameRegistered(string frameTargetKey)
		{
			return _navigationServiceRegister.ContainsKey(frameTargetKey);
		}
	}
}
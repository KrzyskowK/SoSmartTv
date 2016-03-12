using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uwp.Xaml.Navigation.ViewModels;

namespace Uwp.Xaml.Navigation.Navigation
{
	public class NestedNavigationService : INestedNavigationService
	{
		private readonly Dictionary<string, Frame> _navigationServiceRegister = new Dictionary<string, Frame>();
		private readonly Dictionary<string, IList<string>> _framesMap = new Dictionary<string, IList<string>>();
		private readonly Stack<string> _navigationStack = new Stack<string>();

		public void Navigate(string frameKey, Type sourcePageType, object context)
		{
			_navigationServiceRegister[frameKey].Navigate(sourcePageType, context);
		}

		public void Navigate(string frameKey, Type sourcePageType)
		{
			_navigationServiceRegister[frameKey].Navigate(sourcePageType);
		}

		public void GoBack()
		{
			var key = _navigationStack.Pop();
			var frame = _navigationServiceRegister[key];
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

		public void RegisterFrame(string frameKey, Frame frame, string parentFrameKey = null)
		{
			if (IsFrameRegistered(frameKey))
				UnRegisterFrame(frameKey);

			RegisterFrameMap(frameKey, parentFrameKey);

			_navigationServiceRegister.Add(frameKey, frame);
			_navigationServiceRegister[frameKey].Navigated += OnFrameNavigated;
			_navigationServiceRegister[frameKey].Navigating += OnFrameNavigating;
			_navigationServiceRegister[frameKey].Navigated += (s, e) => Debug.WriteLine("Frame Navigated");
			_navigationServiceRegister[frameKey].Navigating += (s, e) => Debug.WriteLine("Frame Navigating");
			_navigationServiceRegister[frameKey].NavigationFailed += (s, e) => Debug.WriteLine("Frame NavigationFailed");
			_navigationServiceRegister[frameKey].NavigationStopped += (s, e) => Debug.WriteLine("Frame NavigationStopped");
		}

		private void RegisterFrameMap(string frameKey, string parentFrameKey)
		{
			_framesMap.Add(frameKey, new List<string>());
			if (parentFrameKey != null)
				_framesMap[parentFrameKey].Add(frameKey);
		}

		public void UnRegisterFrame(string frameKey)
		{
			foreach (var childFrameKey in _framesMap[frameKey])
			{
				UnRegisterFrame(childFrameKey);
			}

			Disposing?.Invoke(this, frameKey);
			_framesMap.Remove(frameKey);
			_navigationServiceRegister[frameKey].Navigated -= OnFrameNavigated;
			_navigationServiceRegister.Remove(frameKey);
		}

		public bool IsFrameRegistered(string frameKey)
		{
			return _navigationServiceRegister.ContainsKey(frameKey);
		}
	}
}
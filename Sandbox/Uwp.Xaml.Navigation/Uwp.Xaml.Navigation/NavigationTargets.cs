using System;
using Uwp.Xaml.Navigation.Pages;
using Uwp.Xaml.Navigation.Pages.SubPages;

namespace Uwp.Xaml.Navigation
{
	public static class PageTargets
	{
		public static Type PageOne { get; } = typeof(PageOne);
		public static Type PageTwo { get; } = typeof(PageTwo);
		public static Type PageThree { get; } = typeof(PageThree);

		public static class SubPageTargets
		{
			public static Type SubPageA { get; } = typeof(SubPageA);
			public static Type SubPageB { get; } = typeof(SubPageB);
		}
	}

	public static class FrameTargets
	{
		public static string RootFrame = "RootFrame";
		public static string SubFrame = "SubFrame";
	}
}
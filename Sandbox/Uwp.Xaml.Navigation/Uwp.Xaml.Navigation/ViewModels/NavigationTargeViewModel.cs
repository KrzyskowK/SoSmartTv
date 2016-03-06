using System;

namespace Uwp.Xaml.Navigation.ViewModels
{
	public class NavigationTargeViewModel
	{
		public NavigationTargeViewModel(string name, Type targetType)
		{
			Name = name;
			TargetType = targetType;
		}

		public string Name { get; }

		public Type TargetType { get; }
	}
}
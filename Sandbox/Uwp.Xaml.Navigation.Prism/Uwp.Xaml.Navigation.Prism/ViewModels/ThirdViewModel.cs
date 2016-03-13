using Windows.UI.Xaml.Controls;
using Prism.Windows.Mvvm;

namespace Uwp.Xaml.Navigation.Prism.ViewModels
{
	public class ThirdViewModel : ViewModelBase
	{
		public ThirdViewModel()
		{
		
		}

		public string Title => "Third View Model";
		
		public void OnSubNavigationTargetClick(object sender, ItemClickEventArgs e)
		{
			//var navigationTarget = e.ClickedItem as NavigationTargeViewModel;
			//if (navigationTarget != null)
				//_navigationService.Navigate(FrameTargets.SubFrame, navigationTarget.TargetType, navigationTarget);
		}
	}
}
using System.Diagnostics;
using Windows.UI.Xaml.Navigation;
using Prism.Windows.Mvvm;
using Uwp.Xaml.Navigation.Prism.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Uwp.Xaml.Navigation.Prism.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ThirdView : SessionStateAwarePage
	{
		public ThirdView()
		{
			this.InitializeComponent();
			Debug.WriteLine(string.Format("Creating: {0}", GetType().Name));
			NavigationCacheMode = NavigationCacheMode.Enabled;
		}

		public ThirdViewModel ViewModel => DataContext as ThirdViewModel;
	}
}

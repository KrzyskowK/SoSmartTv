using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uwp.Xaml.Navigation.Prism.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Uwp.Xaml.Navigation.Prism.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SecondView : Page
	{
		public SecondView()
		{
			this.InitializeComponent();
			Debug.WriteLine(string.Format("Creating: {0}", GetType().Name));
			NavigationCacheMode = NavigationCacheMode.Enabled;
		}

		public SecondViewModel ViewModel => DataContext as SecondViewModel;
	}
}

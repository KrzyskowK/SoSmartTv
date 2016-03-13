using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uwp.Xaml.Navigation.Prism.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Uwp.Xaml.Navigation.Prism.Views
{
	public sealed partial class FirstView : Page
	{
		public FirstView()
		{
			this.InitializeComponent();
			Debug.WriteLine(string.Format("Creating: {0}", GetType().Name));
		}
		
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			Debug.WriteLine("OnNavigatedFrom");
			base.OnNavigatedFrom(e);
		}
		
		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			Debug.WriteLine("OnNavigatedFromCancel");
			base.OnNavigatingFrom(e);
		}
		
		public FirstViewModel ViewModel => DataContext as FirstViewModel;
	}
}

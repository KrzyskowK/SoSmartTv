using Windows.UI.Xaml.Controls;

namespace Uwp.Xaml.Navigation.Prism
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		public void SetFrame(Frame frame)
		{
			FrameHost.Content = frame;
		}
	}
}

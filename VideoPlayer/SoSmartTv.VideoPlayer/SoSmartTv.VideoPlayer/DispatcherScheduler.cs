using System.Reactive.Concurrency;

namespace SoSmartTv.VideoPlayer
{
	public static class DispatcherScheduler
	{
		public static IScheduler Instance { get; set; }
	}
}
using System;

namespace SoSmartTv.VideoFilesProvider
{
	public class VideoFileProperty
	{
		public VideoFileProperty(string path)
		{
			Path = path;
		}

		public bool IsMovie => Season == 0 && Episode == 0;
		public bool IsSerial => Season > 0 && Episode > 0;
		public int Season { get; set; }
		public int Episode { get; set; }
		public int Year { get; set; }
		public string Resolution { get; set; }
		public string Quality { get; set; }
		public string Codec { get; set; }
		public string Audio { get; set; }
		public bool Widescreen { get; set; }
		public string Language { get; set; }
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		public string Path { get; set; }
	}
}
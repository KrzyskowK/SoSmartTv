namespace SoSmartTv.VideoFilesProvider.TorrentFileNameParser
{
	public class TorrentVideoFileInfo
	{
		public int Season { get; set; }
		public int Episode { get; set; }
		public int Year { get; set; }
		public string Resolution { get; set; }
		public string Quality { get; set; }
		public string Codec { get; set; }
		public string Audio { get; set; }
		public string Group { get; set; }
		public string Region { get; set; }
		public bool Extended { get; set; }
		public bool Hardcoded { get; set; }
		public bool Proper { get; set; }
		public bool Repack { get; set; }
		public string Container { get; set; }
		public bool Widescreen { get; set; }
		public string Website { get; set; }
		public string Language { get; set; }
		public string Garbage { get; set; }
		public string Title { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoSmartTv.VideoFilesProvider.TorrentFileNameParser
{
	public static class TorrentVideoFileNamingPattern
	{
		public static Dictionary<Expression<Func<TorrentVideoFileInfo, object>>, string> Patterns =
			new Dictionary<Expression<Func<TorrentVideoFileInfo, object>>, string>
		{
			{a => a.Season , @"([Ss]?([0-9]{1,2}))[Eex]"},
			{x => x.Episode, @"([Eex]([0-9]{2})(?:[^0-9]|$))"},
			{x => x.Year, @"([\[\(]?((?:19[0-9]|20[01])[0-9])[\]\)]?)"},
			{x => x.Resolution, @"(([0-9]{3,4}p))[^M]"},
			{x => x.Audio, @"MP3|DD5\.?1|Dual[\- ] Audio|LiNE|DTS|AAC(?:\.?2\.0)?|AC3(?:\.5\.1)?"},
			{x => x.Quality, @"(?:PPV\.)?[HP]DTV|(?:HD)?CAM|B[rR] Rip|TS|" + @"(?:PPV )?WEB-?DL(?: DVDRip)?|H[dD]Ri[Pp]|" + @"DVDRip|DVDRiP|DVDRIP|CamRip|W[EB]B[rR]ip|[Bb]lu[Rr]ay|DvDScr|DVDSCR|hdtv"},
			{x => x.Codec, @"[Xx][Vv][Ii][Dd]|[Xx]264|h\.?264/i"},
			{x => x.Group, @"(- ?([^-]+(?:-={[^-]+-?$)?))$"},
			{x => x.Region, @"R[0 - 9]"},
			{x => x.Extended, @"EXTENDED"},
			{x => x.Hardcoded, @"HC"},
			{x => x.Proper, @"PROPER"},
			{x => x.Repack, @"REPACK"},
			{x => x.Container, @"MKV|AVI"},
			{x => x.Widescreen, @"WS"},
			{x => x.Website, @"^(\[ ?([^\]]+?) ?\])"},
			{x => x.Language, @"rus\.eng"},
			{x => x.Garbage, @"1400Mb|3rd Nov| ((Rip))"},
		};
	}
}
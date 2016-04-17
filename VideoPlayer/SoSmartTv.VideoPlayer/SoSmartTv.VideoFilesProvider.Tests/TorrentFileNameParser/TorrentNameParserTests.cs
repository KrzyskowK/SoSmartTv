using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SoSmartTv.VideoFilesProvider.TorrentFileNameParser;
using Xunit;
using Xunit.Extensions;
using Assert = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.Assert;

namespace SoSmartTv.VideoFilesProvider.Tests.TorrentFileNameParser
{
	public class TorrentNameParserTests
	{
		[Fact]
		public void AssignValue_should_correctly_set_string_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Audio, "audio_matched_value");
			Assert.AreEqual(dto.Audio, "audio_matched_value");
		}

		[Fact]
		public void AssignValue_should_correctly_set_bool_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Extended, "true");
			Assert.AreEqual(dto.Extended, true);
		}

		[Fact]
		public void AssignValue_should_correctly_set_int_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Year, "1988");
			Assert.AreEqual(dto.Year, 1988);
		}

		public static IEnumerable<object[]> SplitCountData()
		{
			yield return new object[]
			{
				"Hannibal.S03E03.720p.HDTV.X264-DIMENSION",
				new TorrentVideoFileInfo()
				{
					Season = 3,
					Episode = 3,
					Quality = "HDTV",
					Resolution = "720p",
					Title = "Hannibal",
					Codec = "X264",
					Group = "DIMENSION"
				},
			};

			yield return new object[]
			{
				"True.Detective.S02E01.PROPER.720p.HDTV.x264 - KILLERS",
				new TorrentVideoFileInfo()
				{
					Season = 2,
					Episode = 1,
					Quality = "HDTV",
					Resolution = "720p",
					Codec = "x264",
					Title = "True Detective",
					Group = "KILLERS",
					Proper = true
				}
			};

			yield return new object[]
			{
				"Black.Mass.2015.HC.HDRip.XViD.AC3-ETRG",
				new TorrentVideoFileInfo()
				{
					Title = "Black Mass",
					Year = 2015,
					Quality = "HDRip",
					Codec = "XViD",
					Audio = "AC3",
					Group = "ETRG",
					Hardcoded = true
				}
			};

			yield return new object[]
			{
				"The Lobster 2015 1080p BluRay x264 DTS-JYK",
				new TorrentVideoFileInfo()
				{
					Title = "The Lobster",
					Year = 2015,
					Resolution = "1080p",
					Quality = "BluRay",
					Codec = "x264",
					Audio = "DTS",
					Group = "JYK"
				}
			};

			yield return new object[]
			{
				"Straight.Outta.Compton.2015.1080p.HC.WEBRip.x264.AAC2.0-FGT",
				new TorrentVideoFileInfo()
				{
					Title = "Straight Outta Compton",
					Year = 2015,
					Resolution = "1080p",
					Hardcoded = true,
					Quality = "WEBRip",
					Codec = "x264",
					Audio = "AAC2.0",
					Group = "FGT"
				}
			};

			yield return new object[]
			{
				"The.Revenant.2015.DVDSCR.X264.AC3-EVO",
				new TorrentVideoFileInfo()
				{
					Title = "The Revenant",
					Year = 2015,
					Quality = "DVDSCR",
					Codec = "X264",
					Audio = "AC3",
					Group = "EVO"
				}
			};

			yield return new object[]
			{
				"Mission.Impossible.Rogue.Nation.2015.720p.HDRiP.x264.ShAaNiG",
				new TorrentVideoFileInfo()
				{
					Title = "Mission Impossible Rogue Nation",
					Year = 2015,
					Quality = "HDRiP",
					Resolution = "720p",
					Codec = "x264"
				}
			};
		}

		[Theory, MemberData("SplitCountData")]
		public void Parse_should_return_correct_dto(string fileName, TorrentVideoFileInfo expectedDto)
		{
			var dto = TorrenVideoFileParser.Parse(fileName);

			Assert.AreEqual(dto.Season, expectedDto.Season);
			Assert.AreEqual(dto.Episode, expectedDto.Episode);
			Assert.AreEqual(dto.Year, expectedDto.Year);
			Assert.AreEqual(dto.Resolution, expectedDto.Resolution);
			Assert.AreEqual(dto.Quality, expectedDto.Quality);
			Assert.AreEqual(dto.Codec, expectedDto.Codec);
			Assert.AreEqual(dto.Audio, expectedDto.Audio);
			Assert.AreEqual(dto.Group, expectedDto.Group);
			Assert.AreEqual(dto.Region, expectedDto.Region);
			Assert.AreEqual(dto.Extended, expectedDto.Extended);
			Assert.AreEqual(dto.Hardcoded, expectedDto.Hardcoded);
			Assert.AreEqual(dto.Proper, expectedDto.Proper);
			Assert.AreEqual(dto.Repack, expectedDto.Repack);
			Assert.AreEqual(dto.Container, expectedDto.Container);
			Assert.AreEqual(dto.Widescreen, expectedDto.Widescreen);
			Assert.AreEqual(dto.Website, expectedDto.Website);
			Assert.AreEqual(dto.Language, expectedDto.Language);
			Assert.AreEqual(dto.Garbage, expectedDto.Garbage);
			Assert.AreEqual(dto.Title, expectedDto.Title);
		}

		[Fact]
		public void Parse_should_return_correct_dto2()
		{
			var dto = TorrenVideoFileParser.Parse("True.Detective.S02E01.PROPER.720p.HDTV.x264 - KILLERS");
			Assert.AreEqual(dto.Season, 2);
			Assert.AreEqual(dto.Episode, 1);
			Assert.AreEqual(dto.Quality, "HDTV");
			Assert.AreEqual(dto.Resolution, "720p");
			Assert.AreEqual(dto.Codec, "x264");
			Assert.AreEqual(dto.Title, "True Detective");
			Assert.AreEqual(dto.Group, "KILLERS");
			Assert.AreEqual(dto.Proper, true);
		}
	}
}

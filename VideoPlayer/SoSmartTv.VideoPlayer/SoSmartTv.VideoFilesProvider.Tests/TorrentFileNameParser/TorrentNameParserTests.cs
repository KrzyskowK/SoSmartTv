using System.Collections.Generic;
using SoSmartTv.VideoFilesProvider.TorrentFileNameParser;
using Xunit;

namespace SoSmartTv.VideoFilesProvider.Tests.TorrentFileNameParser
{
	public class TorrentNameParserTests
	{
		[Fact]
		public void AssignValue_should_correctly_set_string_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Audio, "audio_matched_value");
			Assert.Equal(dto.Audio, "audio_matched_value");
		}

		[Fact]
		public void AssignValue_should_correctly_set_bool_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Extended, "true");
			Assert.Equal(dto.Extended, true);
		}

		[Fact]
		public void AssignValue_should_correctly_set_int_value()
		{
			var dto = new TorrentVideoFileInfo();
			TorrenVideoFileParser.TryAssignValue(dto, x => x.Year, "1988");
			Assert.Equal(dto.Year, 1988);
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

			Assert.Equal(dto.Season, expectedDto.Season);
			Assert.Equal(dto.Episode, expectedDto.Episode);
			Assert.Equal(dto.Year, expectedDto.Year);
			Assert.Equal(dto.Resolution, expectedDto.Resolution);
			Assert.Equal(dto.Quality, expectedDto.Quality);
			Assert.Equal(dto.Codec, expectedDto.Codec);
			Assert.Equal(dto.Audio, expectedDto.Audio);
			Assert.Equal(dto.Group, expectedDto.Group);
			Assert.Equal(dto.Region, expectedDto.Region);
			Assert.Equal(dto.Extended, expectedDto.Extended);
			Assert.Equal(dto.Hardcoded, expectedDto.Hardcoded);
			Assert.Equal(dto.Proper, expectedDto.Proper);
			Assert.Equal(dto.Repack, expectedDto.Repack);
			Assert.Equal(dto.Container, expectedDto.Container);
			Assert.Equal(dto.Widescreen, expectedDto.Widescreen);
			Assert.Equal(dto.Website, expectedDto.Website);
			Assert.Equal(dto.Language, expectedDto.Language);
			Assert.Equal(dto.Garbage, expectedDto.Garbage);
			Assert.Equal(dto.Title, expectedDto.Title);
		}

		[Fact]
		public void Parse_should_return_correct_dto2()
		{
			var dto = TorrenVideoFileParser.Parse("True.Detective.S02E01.PROPER.720p.HDTV.x264 - KILLERS");
			Assert.Equal(dto.Season, 2);
			Assert.Equal(dto.Episode, 1);
			Assert.Equal(dto.Quality, "HDTV");
			Assert.Equal(dto.Resolution, "720p");
			Assert.Equal(dto.Codec, "x264");
			Assert.Equal(dto.Title, "True Detective");
			Assert.Equal(dto.Group, "KILLERS");
			Assert.Equal(dto.Proper, true);
		}
	}
}

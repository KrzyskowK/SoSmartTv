using System.Collections.Generic;

namespace SoSmartTv.TheMovieDatabaseApi.Dtos
{
	public class VideoDetailsInfoWithCast : VideoDetailsInfo
	{
		public List<Cast> Cast { get; set; }
		public List<Crew> Crew { get; set; }
	}
}
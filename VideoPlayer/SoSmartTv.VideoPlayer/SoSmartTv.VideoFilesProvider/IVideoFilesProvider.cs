using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace SoSmartTv.VideoFilesProvider
{
	public interface IVideoFilesProvider
	{
		Task<IList<VideoProperties>> GetAllVideoFiles();

		Task IncludeDirectoryIntoVideoLibrary();

		Task ExcludeDirectoryIntoVideoLibrary(StorageFolder folder);
	}
}

using FakeItEasy;
using SoSmartTv.VideoService.Store;

namespace SoSmartTv.VideoService.Tests.Store
{
	public abstract class RedundantDataStoreTests
	{
		protected IRedundantDataStore _sut;
		protected IVideoItemsStoreReader _localStoreReader;
		protected IVideoItemsStoreReader _externalStoreReader;
		protected IVideoItemsStoreWriter _localStoreWriter;

		protected RedundantDataStoreTests()
		{
			_localStoreReader = A.Fake<IVideoItemsStoreReader>();
			_externalStoreReader = A.Fake<IVideoItemsStoreReader>();
			_localStoreWriter = A.Fake<IVideoItemsStoreWriter>();

			_sut = new RedundantDataStore(_localStoreReader, _localStoreWriter, _externalStoreReader);
		}
	}
}
namespace SoSmartTv.VideoService.Store
{
	public class RedundantEntity<T, TOuter>
	{
		public T Entity { get; }
		public TOuter JoinedEntity { get; }

		public bool IsJoined => JoinedEntity != null;

		public RedundantEntity(T entity, TOuter joinedEntity)
		{
			Entity = entity;
			JoinedEntity = joinedEntity;
		}

		public RedundantEntity(T entity)
		{
			Entity = entity;
		}
	}
}
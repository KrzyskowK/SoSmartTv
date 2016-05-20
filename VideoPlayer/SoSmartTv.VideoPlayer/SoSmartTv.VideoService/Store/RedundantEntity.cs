namespace SoSmartTv.VideoService.Store
{
	public class RedundantEntity<T, TLeft>
	{
		public T Entity { get; }
		public TLeft JoinedEntity { get; }

		public bool IsJoined => JoinedEntity != null;

		public RedundantEntity(T entity, TLeft joinedEntity)
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
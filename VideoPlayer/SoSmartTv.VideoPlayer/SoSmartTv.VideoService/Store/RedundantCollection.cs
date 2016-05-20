using System;
using System.Collections.Generic;
using System.Linq;

namespace SoSmartTv.VideoService.Store
{
	public class RedundantCollection<T, TLeft>
	{
		private readonly Func<T, TLeft, bool> _joinPredicate;

		public IEnumerable<RedundantEntity<T, TLeft>> Collection { get; private set; }

		public IEnumerable<TLeft> OnlyJoined => Collection.Where(c => c.IsJoined).Select(c => c.JoinedEntity);

		public IEnumerable<T> OnlyNotJoined => Collection.Where(c => !c.IsJoined).Select(c => c.Entity);

		public RedundantCollection(IEnumerable<T> baseCollection, IEnumerable<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate)
		{
			_joinPredicate = joinPredicate;
			Collection = baseCollection.Zip(joinedCollection, (e1, e2) => CreateEntity(e1, e2, joinPredicate));
		}

		public RedundantCollection(IList<T> baseCollection, IList<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate)
		{
			_joinPredicate = joinPredicate;
			Collection = baseCollection.Zip(joinedCollection, (e1, e2) => CreateEntity(e1, e2, joinPredicate));
		}

		public RedundantCollection<T, TLeft> JoinIfEmpty(IEnumerable<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate = null)
		{
			joinPredicate = joinPredicate ?? _joinPredicate;
			Collection = Collection.Zip(joinedCollection,
				(e1, e2) => CreateEntity(e1.Entity, e1.IsJoined ? e1.JoinedEntity : e2, joinPredicate));
			return this;
		}

		public RedundantCollection<T, TLeft> JoinIfEmpty(IList<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate = null)
		{
			joinPredicate = joinPredicate ?? _joinPredicate;
			Collection = Collection.Zip(joinedCollection,
				(e1, e2) => CreateEntity(e1.Entity, e1.IsJoined ? e1.JoinedEntity : e2, joinPredicate));
			return this;
		}

		private RedundantEntity<T, TLeft> CreateEntity(T entity, TLeft joinedEntity, Func<T, TLeft, bool> joinPredicate)
		{
			return joinPredicate(entity, joinedEntity)
				? new RedundantEntity<T, TLeft>(entity, joinedEntity)
				: new RedundantEntity<T, TLeft>(entity);
		}
	}
}
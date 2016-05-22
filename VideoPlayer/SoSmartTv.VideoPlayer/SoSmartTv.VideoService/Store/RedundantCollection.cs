using System;
using System.Collections.Generic;
using System.Linq;

namespace SoSmartTv.VideoService.Store
{
	public class RedundantCollection<T, TLeft>
	{
		private readonly Func<T, TLeft, bool> _joinPredicate;
		private readonly Func<TLeft, string> _outerKeySelector;
		private readonly Func<T, string> _innerKeySelector;

		public IEnumerable<RedundantEntity<T, TLeft>> Collection { get; private set; }

		public IEnumerable<TLeft> OnlyJoined => Collection.Where(c => c.IsJoined).Select(c => c.JoinedEntity);

		public IEnumerable<T> OnlyNotJoined => Collection.Where(c => !c.IsJoined).Select(c => c.Entity);

		public bool IsAnyNotJoined => Collection.Any(c => !c.IsJoined);

		public bool AllJoined => Collection.All(c => c.IsJoined);

		public RedundantCollection(IEnumerable<T> baseCollection, IEnumerable<TLeft> joinedCollection,
			Func<T, TLeft, bool> joinPredicate,
			Func<T,string> innerKeySelector,
			Func<TLeft, string> outerkeySelector
			)
		{
			_joinPredicate = joinPredicate;
			_innerKeySelector = innerKeySelector;
			_outerKeySelector = outerkeySelector;

			Collection = baseCollection.GroupJoin(
				joinedCollection,
				innerKeySelector,
				outerkeySelector,
				(e1, g) => g
					.Select((e2,id)=> CreateEntity(e1, e2, joinPredicate))
					.DefaultIfEmpty(new RedundantEntity<T, TLeft>(e1)))
			.SelectMany(g => g);
		}

		public RedundantCollection(IList<T> baseCollection, IList<TLeft> joinedCollection,
			Func<T, TLeft, bool> joinPredicate,
			Func<T, string> innerKeySelector,
			Func<TLeft, string> outerkeySelector
			)
		{
			_joinPredicate = joinPredicate;
			_innerKeySelector = innerKeySelector;
			_outerKeySelector = outerkeySelector;

			Collection = baseCollection.GroupJoin(
				joinedCollection,
				innerKeySelector,
				outerkeySelector,
				(e1, g) => g
					.Select((e2, id) => CreateEntity(e1, e2, joinPredicate))
					.DefaultIfEmpty(new RedundantEntity<T, TLeft>(e1)))
			.SelectMany(g => g);
		}

		public RedundantCollection<T, TLeft> JoinIfEmpty(IEnumerable<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate = null)
		{
			joinPredicate = joinPredicate ?? _joinPredicate;
			Collection = Collection.GroupJoin(
				joinedCollection,
				e => _innerKeySelector(e.Entity),
				_outerKeySelector,
				(e1, g) => g
					.Select((e2, id) => CreateEntity(e1.Entity, e1.IsJoined ? e1.JoinedEntity : e2, joinPredicate))
					.DefaultIfEmpty(e1))
			.SelectMany(g => g);
			
			return this;
		}

		public RedundantCollection<T, TLeft> JoinIfEmpty(IList<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate = null)
		{
			joinPredicate = joinPredicate ?? _joinPredicate;
			Collection = Collection.GroupJoin(
				joinedCollection,
				e => _innerKeySelector(e.Entity),
				_outerKeySelector,
				(e1, g) => g
					.Select((e2, id) => CreateEntity(e1.Entity, e1.IsJoined ? e1.JoinedEntity : e2, joinPredicate))
					.DefaultIfEmpty(e1))
			.SelectMany(g => g);

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
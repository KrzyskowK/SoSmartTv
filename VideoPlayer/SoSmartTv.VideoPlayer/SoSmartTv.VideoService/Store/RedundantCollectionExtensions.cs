using System;
using System.Collections.Generic;

namespace SoSmartTv.VideoService.Store
{
	public static class RedundantCollectionExtensions
	{
		public static RedundantCollection<T, TOuter> ToUnifiedCollection<T, TOuter>(this IEnumerable<T> baseCollection,
			IEnumerable<TOuter> joinedCollection, Func<T, TOuter, bool> joinPredicate, Func<T, string> innerKeySelector,
			Func<TOuter, string> outerKeySelector)
		{
			return new RedundantCollection<T, TOuter>(baseCollection, joinedCollection, joinPredicate, innerKeySelector, outerKeySelector);
		}

		public static RedundantCollection<T, TOuter> ToUnifiedCollection<T, TOuter>(this IList<T> baseCollection,
			IList<TOuter> joinedCollection, Func<T, TOuter, bool> joinPredicate, Func<T, string> innerKeySelector,
			Func<TOuter, string> outerKeySelector)
		{
			return new RedundantCollection<T, TOuter>(baseCollection, joinedCollection, joinPredicate, innerKeySelector, outerKeySelector);
		}

		public static RedundantCollection<T, TOuter> JoinIfEmpty<T, TOuter>(this RedundantCollection<T, TOuter> redundantCollection, IList<TOuter> joinedCollection,
			Func<T, TOuter, bool> joinPredicate = null)
		{
			redundantCollection.JoinIfEmpty(joinedCollection, joinPredicate);
			return redundantCollection;
		}

		public static RedundantCollection<T, TOuter> JoinIfEmpty<T, TOuter>(this RedundantCollection<T, TOuter> redundantCollection, IEnumerable<TOuter> joinedCollection,
			Func<T, TOuter, bool> joinPredicate = null)
		{
			redundantCollection.JoinIfEmpty(joinedCollection, joinPredicate);
			return redundantCollection;
		}
	}
}
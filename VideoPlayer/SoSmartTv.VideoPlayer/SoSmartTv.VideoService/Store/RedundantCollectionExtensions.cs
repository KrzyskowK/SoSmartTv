using System;
using System.Collections.Generic;

namespace SoSmartTv.VideoService.Store
{
	public static class RedundantCollectionExtensions
	{
		public static RedundantCollection<T, TLeft> ToUnifiedCollection<T, TLeft>(this IEnumerable<T> baseCollection,
			IEnumerable<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate)
		{
			return new RedundantCollection<T, TLeft>(baseCollection, joinedCollection, joinPredicate);
		}

		public static RedundantCollection<T, TLeft> ToUnifiedCollection<T, TLeft>(this IList<T> baseCollection,
			IList<TLeft> joinedCollection, Func<T, TLeft, bool> joinPredicate)
		{
			return new RedundantCollection<T, TLeft>(baseCollection, joinedCollection, joinPredicate);
		}

		public static RedundantCollection<T, TLeft> JoinIfEmpty<T, TLeft>(this RedundantCollection<T, TLeft> redundantCollection, IList<TLeft> joinedCollection,
			Func<T, TLeft, bool> joinPredicate = null)
		{
			redundantCollection.JoinIfEmpty(joinedCollection, joinPredicate);
			return redundantCollection;
		}

		public static RedundantCollection<T, TLeft> JoinIfEmpty<T, TLeft>(this RedundantCollection<T, TLeft> redundantCollection, IEnumerable<TLeft> joinedCollection,
			Func<T, TLeft, bool> joinPredicate = null)
		{
			redundantCollection.JoinIfEmpty(joinedCollection, joinPredicate);
			return redundantCollection;
		}
	}
}
using System;
using System.Collections.Generic;

namespace KoganeUnityLib
{
	/// <summary>
	/// List 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ListExt
	{
		private static Random m_random = new Random();

		/// <summary>
		/// 指定したコレクションの要素をリストの末尾に追加します
		/// </summary>
		public static void Add<T>( this List<T> self, IEnumerable<T> collection )
		{
			self.AddRange( collection );
		}

		/// <summary>
		/// 指定したコレクションの要素を末尾に追加します
		/// </summary>
		public static void AddRange<T>( this List<T> list, params T[] collection )
		{
			list.AddRange( collection );
		}

		/// <summary>
		/// 指定したコレクションの要素をの末尾に追加します
		/// </summary>
		public static void AddRange<T>( this List<T> list, params IList<T>[] collectionList )
		{
			for ( int i = 0; i < collectionList.Length; i++ )
			{
				list.AddRange( collectionList[ i ] );
			}
		}

		/// <summary>
		/// すべての要素を削除して、指定したコレクションの要素を追加します
		/// </summary>
		public static void Set<T>( this List<T> list, IEnumerable<T> collection )
		{
			list.Clear();
			list.AddRange( collection );
		}

		/// <summary>
		/// すべての要素を削除して、指定したコレクションの要素を追加します
		/// </summary>
		public static void Set<T>( this List<T> list, params T[] collection )
		{
			list.Clear();
			list.AddRange( collection );
		}

		/// <summary>
		/// 指定した Comparison<T> を使用して要素を並べ替えます
		/// </summary>
		public static void Sort<T>( this List<T> self, Comparison<T> comparison )
		{
			self.Sort( comparison );
		}

		/// <summary>
		/// 指定した Func<TSource, TResult> を使用して要素を並べ替えます
		/// </summary>
		public static void Sort<TSource, TResult>( this List<TSource> self, Func<TSource, TResult> selector ) where TResult : IComparable
		{
			self.Sort( ( x, y ) => selector( x ).CompareTo( selector( y ) ) );
		}

		/// <summary>
		/// 指定した Func<TSource, TResult> を使用して要素を逆順に並べ替えます
		/// </summary>
		public static void SortDescending<TSource, TResult>( this List<TSource> self, Func<TSource, TResult> selector ) where TResult : IComparable
		{
			self.Sort( ( x, y ) => selector( y ).CompareTo( selector( x ) ) );
		}

		/// <summary>
		/// 複数のキーを使用して要素を並べ替えます
		/// </summary>
		public static void Sort<TSource, TResult1, TResult2>( this List<TSource> self, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2 ) where TResult1 : IComparable where TResult2 : IComparable
		{
			self.Sort( ( x, y ) =>
			{
				var result = selector1( x ).CompareTo( selector1( y ) );
				return result != 0 ? result : selector2( x ).CompareTo( selector2( y ) );
			} );
		}

		/// <summary>
		/// 複数のキーを使用して要素を降順に並べ替えます
		/// </summary>
		public static void SortDescending<TSource, TResult1, TResult2>( this List<TSource> self, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2 ) where TResult1 : IComparable where TResult2 : IComparable
		{
			self.Sort( ( x, y ) =>
			{
				var result = selector1( y ).CompareTo( selector1( x ) );
				return result != 0 ? result : selector2( x ).CompareTo( selector2( y ) );
			} );
		}

		/// <summary>
		/// 要素をランダムに並び替えます
		/// </summary>
		public static List<T> Shuffle<T>( this List<T> self )
		{
			int n = self.Count;
			while ( 1 < n )
			{
				n--;
				int k = m_random.Next( n + 1 );
				var tmp = self[ k ];
				self[ k ] = self[ n ];
				self[ n ] = tmp;
			}
			return self;
		}

		/// <summary>
		/// match で一致した最初の要素をリストから削除します
		/// </summary>
		public static void Remove<T>( this List<T> self, Predicate<T> match )
		{
			var index = self.FindIndex( match );
			if ( index == -1 ) return;
			self.RemoveAt( index );
		}

		/// <summary>
		/// リスト内の先頭に要素を挿入します
		/// </summary>
		public static void InsertFirst<T>( this List<T> self, T item )
		{
			self.Insert( 0, item );
		}

		/// <summary>
		/// 指定された数になるまでリストの末尾の要素を削除します
		/// </summary>
		public static void RemoveSince<T>( this List<T> self, int count )
		{
			while ( count <= self.Count )
			{
				self.RemoveAt( self.Count - 1 );
			}
		}

		/// <summary>
		/// 指定された範囲を指定された値で埋めます
		/// </summary>
		public static void Fill<T>( this List<T> self, int startIndex, int endIndex, T value )
		{
			for ( int i = startIndex; i < endIndex; i++ )
			{
				self.Add( value );
			}
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize<T>( this List<T> self, int size )
		{
			if ( self.Count <= size ) return;
			self.RemoveRange( size, self.Count - size );
		}
	}
}
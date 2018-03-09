using System;
using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// IEnumerable 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class IEnumerableExt
	{
		/// <summary>
		/// オブジェクトの比較と選択を行うクラス
		/// </summary>
		private sealed class CompareSelector<T, TKey> : IEqualityComparer<T>
		{
			private readonly Func<T, TKey> m_selector;

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public CompareSelector( Func<T, TKey> selector )
			{
				m_selector = selector;
			}

			/// <summary>
			/// x と y を比較します
			/// </summary>
			public bool Equals( T x, T y )
			{
				return m_selector( x ).Equals( m_selector( y ) );
			}

			/// <summary>
			/// 指定オブジェクトのハッシュコードを返します
			/// </summary>
			public int GetHashCode( T obj )
			{
				return m_selector( obj ).GetHashCode();
			}
		}

		private static readonly Random m_random = new Random();

		/// <summary>
		/// 各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IEnumerable<T> self, Action<T> action )
		{
			foreach ( var n in self )
			{
				action( n );
			}
		}

		/// <summary>
		/// 各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IEnumerable<T> self, Action<T, int> action )
		{
			int index = 0;
			foreach ( var n in self )
			{
				action( n, index++ );
			}
		}

		/// <summary>
		/// シーケンスが null または Empty シーケンスであるかどうかを示します
		/// </summary>
		public static bool IsNullOrEmpty<T>( this IEnumerable<T> self )
		{
			return self == null || !self.Any();
		}

		/// <summary>
		/// シーケンスが null ではない、Empty シーケンスではないかどうかを示します
		/// </summary>
		public static bool IsNotNullOrEmpty<T>( this IEnumerable<T> self )
		{
			return !self.IsNullOrEmpty();
		}

		/// <summary>
		/// 指定されたページのシーケンスを返します
		/// </summary>
		public static IEnumerable<T> Pager<T>( this IEnumerable<T> self, int page, int count )
		{
			return self.Skip( page * count ).Take( count );
		}

		/// <summary>
		/// シーケンスを返します。シーケンスが null の場合は空のシーケンスを返します
		/// </summary>
		public static IEnumerable<T> DefaultIfNull<T>( this IEnumerable<T> self )
		{
			return self == null ? new T[ 0 ] : self;
		}

		/// <summary>
		/// null ではない値のシーケンスを返します
		/// </summary>
		public static IEnumerable<TSource> NotNull<TSource>( this IEnumerable<TSource> self )
		{
			return self.Where( c => c != null );
		}

		/// <summary>
		/// 等値比較子に従って 2 つのシーケンスが等しいかどうかを判断します
		/// </summary>
		public static bool SequenceEqual<T, TKey>( this IEnumerable<T> source, IEnumerable<T> second, Func<T, TKey> selector )
		{
			return source.SequenceEqual( second, new CompareSelector<T, TKey>( selector ) );
		}

		/// <summary>
		/// 既定の等値比較子を使用して値を比較することにより、シーケンスから一意の要素を返します
		/// </summary>
		public static IEnumerable<T> Distinct<T, TKey>( this IEnumerable<T> source, Func<T, TKey> selector )
		{
			return source.Distinct( new CompareSelector<T, TKey>( selector ) );
		}

		/// <summary>
		/// シーケンスから最大値を持つ要素を返します
		/// </summary>
		public static TSource MaxBy<TSource, TResult>
		(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector
		)
		{
			var value = source.Max( selector );
			return source.FirstOrDefault( c => selector( c ).Equals( value ) );
		}

		/// <summary>
		/// シーケンスから最大値を持つ要素を全て返します
		/// </summary>
		public static IEnumerable<TSource> MaxElementsBy<TSource, TResult>
		(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector
		)
		{
			var value = source.Max( selector );
			return source.Where( c => selector( c ).Equals( value ) );
		}

		/// <summary>
		/// シーケンスから最小値を持つ要素を返します
		/// </summary>
		public static TSource MinBy<TSource, TResult>
		(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector
		)
		{
			var value = source.Min( selector );
			return source.FirstOrDefault( c => selector( c ).Equals( value ) );
		}

		/// <summary>
		/// シーケンスから最小値を持つ要素を全て返します
		/// </summary>
		public static IEnumerable<TSource> MinElementsBy<TSource, TResult>
		(
			this IEnumerable<TSource> source,
			Func<TSource, TResult> selector
		)
		{
			var value = source.Min( selector );
			return source.Where( c => selector( c ).Equals( value ) );
		}

		/// <summary>
		/// シーケンスが空かどうかを返します
		/// </summary>
		public static bool IsEmpty<TSource>( this IEnumerable<TSource> source )
		{
			return !source.Any();
		}

		/// <summary>
		/// シーケンスの先頭に値を追加して返します
		/// </summary>
		public static IEnumerable<TSource> StartWith<TSource>
		(
			this IEnumerable<TSource> source,
			params TSource[] value
		)
		{
			foreach ( var n in value )
			{
				yield return n;
			}
			foreach ( var n in source )
			{
				yield return n;
			}
		}

		/// <summary>
		/// 指定された複数のシーケンスを連結して返します
		/// </summary>
		public static IEnumerable<TSource> Concat<TSource>
		(
			params IEnumerable<TSource>[] sources
		)
		{
			foreach ( var source in sources )
			{
				foreach ( var n in source )
				{
					yield return n;
				}
			}
		}

		/// <summary>
		/// 指定されたシーケンスから条件を満たさない要素を全て返します
		/// </summary>
		public static IEnumerable<TSource> WhereNot<TSource, TResult>
		(
			this IEnumerable<TSource> source,
			Func<TSource, bool> predicate
		)
		{
			return source.Where( c => !predicate( c ) );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します
		/// </summary>
		public static int Nearest
		(
			this IEnumerable<int> self,
			int target
		)
		{
			var min = self.Min( c => Math.Abs( c - target ) );
			return self.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します
		/// </summary>
		public static int Nearest<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( self.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します
		/// </summary>
		public static TSource FindNearest<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return self.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します
		/// </summary>
		public static int NearestMoreThan
		(
			this IEnumerable<int> self,
			int target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します
		/// </summary>
		public static int NearestMoreThan<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します
		/// </summary>
		public static TSource FindNearestMoreThan<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します
		/// </summary>
		public static int NearestOrLess
		(
			this IEnumerable<int> self,
			int target
		)
		{
			var list = self.Where( c => c <= target );
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します
		/// </summary>
		public static int NearestOrLess<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target );
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します
		/// </summary>
		public static TSource FindNearestOrLess<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target );
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します
		/// </summary>
		public static int NearestOrMore
		(
			this IEnumerable<int> self,
			int target
		)
		{
			var list = self.Where( c => target <= c );
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します
		/// </summary>
		public static int NearestOrMore<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) );
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します
		/// </summary>
		public static TSource FindNearestOrMore<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) );
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します
		/// </summary>
		public static int NearestMoreLess
		(
			this IEnumerable<int> self,
			int target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します
		/// </summary>
		public static int NearestMoreLess<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します
		/// </summary>
		public static TSource FindNearestMoreLess<TSource>
		(
			this IEnumerable<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 要素の中から確率抽選します
		/// </summary>
		public static T RandomAtWeight<T>( this IEnumerable<T> self, Func<T, int> selector )
		{
			var current = 0;
			var rate = m_random.Next( 0, self.Sum( selector ) );

			var result = self.FirstOrDefault( c =>
			{
				current += selector( c );
				return rate < current;
			} );

			return result;
		}

		/// <summary>
		/// 2 つのシーケンスを連結します
		/// </summary>
		public static IEnumerable<TSource> Concat<TSource>( this IEnumerable<TSource> first, TSource second )
		{
			return first.Concat( new[] { second } );
		}

		/// <summary>
		/// 指定されたシーケンスを分割します
		/// </summary>
		public static IEnumerable<IEnumerable<TSource>> Chunks<TSource>( this IEnumerable<TSource> self, int size )
		{
			while ( self.Any() )
			{
				yield return self.Take( size );
				self = self.Skip( size );
			}
		}
	}
}
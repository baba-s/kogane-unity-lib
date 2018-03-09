using System;
using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// IList 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class IListExt
	{
		/// <summary>
		/// 条件を満たす要素の数を表す数値を返します
		/// </summary>
		public static int Count<T>( this IList<T> self, Func<T, bool> predicate )
		{
			int count = 0;
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( predicate( self[ i ] ) )
				{
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// 要素をランダムに返します
		/// </summary>
		public static T ElementAtRandom<T>( this IList<T> self )
		{
			return self.IsEmpty() ? default( T ) : self[ UnityEngine.Random.Range( 0, self.Count ) ];
		}

		/// <summary>
		/// 先頭にあるオブジェクトを削除し、返します
		/// </summary>
		public static T Dequeue<T>( this IList<T> self )
		{
			var result = self[ 0 ];
			self.RemoveAt( 0 );
			return result;
		}

		/// <summary>
		/// IList 型のインスタンスの各要素に対して、指定された処理を逆順に実行します
		/// </summary>
		public static void ForEachReverse<T>( this IList<T> self, Action<T> act )
		{
			for ( int i = self.Count - 1; 0 <= i; i-- )
			{
				act( self[ i ] );
			}
		}

		/// <summary>
		/// IList 型のインスタンスの各要素に対して、指定された処理を逆順に実行します
		/// </summary>
		public static void ForEachReverse<T>( this IList<T> self, Action<T, int> act )
		{
			for ( int i = self.Count - 1; 0 <= i; i-- )
			{
				act( self[ i ], i );
			}
		}

		/// <summary>
		/// IList 型のインスタンスの各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IList<T> self, Action<T> act )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				act( self[ i ] );
			}
		}

		/// <summary>
		/// IList 型のインスタンスの各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IList<T> self, Action<T, int> act )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				act( self[ i ], i );
			}
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致するすべての要素を取得します
		/// </summary>
		public static IList<T> FindAll<T>( this IList<T> self, Predicate<T> match )
		{
			var result = new List<T>();
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					result.Add( self[ i ] );
				}
			}
			return result;
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を検索し、IList<T> 全体の中で最もインデックス番号の小さい要素を返します
		/// </summary>
		public static T Find<T>( this IList<T> self, Predicate<T> match )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return self[ i ];
				}
			}
			return default( T );
		}

		/// <summary>
		/// 指定した述語によって定義される条件に一致する要素を検索し、最もインデックス番号の小さい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindIndex<T>( this IList<T> self, Predicate<T> match )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、IList<T> 全体を対象に検索し、最もインデックス番号の大きい要素を返します
		/// </summary>
		public static T FindLast<T>( this IList<T> self, Predicate<T> match )
		{
			for ( int i = self.Count - 1; 0 <= i; i-- )
			{
				if ( match( self[ i ] ) )
				{
					return self[ i ];
				}
			}
			return default( T );
		}

		/// <summary>
		/// 指定した述語によって定義される条件に一致する要素を検索し、最もインデックス番号の大きい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindLastIndex<T>( this IList<T> self, Predicate<T> match )
		{
			for ( int i = self.Count - 1; 0 <= i; i-- )
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// 条件を満たしている要素があるかどうかを判断します
		/// </summary>
		public static bool Any<T>( this IList<T> self, Func<T, bool> predicate )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( predicate( self[ i ] ) )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// すべての要素が条件を満たしているかどうかを判断します
		/// </summary>
		public static bool All<T>( this IList<T> self, Func<T, bool> predicate )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( !predicate( self[ i ] ) )
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 既定の等値比較子を使用して、指定した要素がシーケンスに含まれているかどうかを判断します
		/// </summary>
		public static bool Contains<T>( this IList<T> self, T value )
		{
			for ( int i = 0; i < self.Count; i++ )
			{
				if ( self[ i ].Equals( value ) )
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、合計値を返します
		/// </summary>
		public static int Sum<T>( this IList<T> self, Func<T, int> selector )
		{
			int result = 0;

			for ( int i = 0; i < self.Count; i++ )
			{
				result += selector( self[ i ] );
			}
			return result;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、合計値を返します
		/// </summary>
		public static uint Sum<T>( this IList<T> self, Func<T, uint> selector )
		{
			uint result = 0;

			for ( int i = 0; i < self.Count; i++ )
			{
				result += selector( self[ i ] );
			}
			return result;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、Int32 の最大値を返します
		/// </summary>
		public static int Max<T>( this IList<T> self, Func<T, int> selector )
		{
			int result = int.MinValue;

			for ( int i = 0; i < self.Count; i++ )
			{
				var value = selector( self[ i ] );

				if ( result < value )
				{
					result = value;
				}
			}
			return result;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、Int64 の最大値を返します
		/// </summary>
		public static uint Max<T>( this IList<T> self, Func<T, uint> selector )
		{
			uint result = uint.MinValue;

			for ( int i = 0; i < self.Count; i++ )
			{
				var value = selector( self[ i ] );

				if ( result < value )
				{
					result = value;
				}
			}
			return result;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、Int32 の最小値を返します
		/// </summary>
		public static int Min<T>( this IList<T> self, Func<T, int> selector )
		{
			int result = int.MaxValue;

			for ( int i = 0; i < self.Count; i++ )
			{
				var value = selector( self[ i ] );

				if ( value < result )
				{
					result = value;
				}
			}
			return result;
		}

		/// <summary>
		/// シーケンスの各要素に対して変換関数を呼び出し、Int64 の最小値を返します
		/// </summary>
		public static uint Min<T>( this IList<T> self, Func<T, uint> selector )
		{
			uint result = uint.MaxValue;

			for ( int i = 0; i < self.Count; i++ )
			{
				var value = selector( self[ i ] );

				if ( value < result )
				{
					result = value;
				}
			}
			return result;
		}

		/// <summary>
		/// シーケンス内の指定されたインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します
		/// </summary>
		public static T ElementAtOrDefault<T>( this IList<T> self, int index )
		{
			return 0 <= index && index < self.Count ? self[ index ] : default( T );
		}

		/// <summary>
		/// シーケンス内の指定されたインデックス位置にある要素を返します。インデックスが範囲外の場合は既定値を返します
		/// </summary>
		public static T ElementAtOrDefault<T>( this IList<T> self, int index, T defaultValue )
		{
			return 0 <= index && index < self.Count ? self[ index ] : defaultValue;
		}

		/// <summary>
		/// int 値の最小値を持つ要素を返します
		/// </summary>
		public static T FindMin<T>( this IList<T> self, Func<T, int> selector )
		{
			return self.Find( c => selector( c ) == self.Min( selector ) );
		}

		/// <summary>
		/// uint 値の最小値を持つ要素を返します
		/// </summary>
		public static T FindMin<T>( this IList<T> self, Func<T, uint> selector )
		{
			return self.Find( c => selector( c ) == self.Min( selector ) );
		}

		/// <summary>
		/// int 値の最大値を持つ要素を返します
		/// </summary>
		public static T FindMax<T>( this IList<T> self, Func<T, int> selector )
		{
			return self.Find( c => selector( c ) == self.Max( selector ) );
		}

		/// <summary>
		/// uint 値の最大値を持つ要素を返します
		/// </summary>
		public static T FindMax<T>( this IList<T> self, Func<T, uint> selector )
		{
			return self.Find( c => selector( c ) == self.Max( selector ) );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int Nearest
		(
			this IList<int> self,
			int target
		)
		{
			var min = self.Min( c => Math.Abs( c - target ) );
			return self.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int Nearest<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( self.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearest<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return self.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrDefault(
			this IList<int> self,
			int target
		)
		{
			var min = self.Min( c => Math.Abs( c - target ) );
			return self.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( self.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return self.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreThan
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreThan<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestMoreThan<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreThanOrDefault
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreThanOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestMoreThanOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrLess
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrLess<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestOrLess<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrLessOrDefault
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrLessOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrLessOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrMore
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrMore<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestOrMore<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrMoreOrDefault
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrMoreOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrMoreOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreLess
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreLess<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestMoreLess<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreLessOrDefault
		(
			this IList<int> self,
			int target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreLessOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestMoreLessOrDefault<TSource>
		(
			this IList<TSource> self,
			int target,
			Func<TSource, int> selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		/// <summary>
		/// リストを指定した値で埋め尽くします
		/// </summary>
		public static void FillBy<T>( this IList<T> list, T value, int count )
		{
			int listcount = list.Count;
			for ( int i = 0; i < count; i++ )
			{
				if ( i < listcount )
				{
					list[ i ] = value;
				}
				else
				{
					list.Add( value );
				}
			}
		}

		/// <summary>
		/// リストを指定した値で埋め尽くします
		/// </summary>
		public static void FillBy<T>( this IList<T> list, Func<int, T> func, int count )
		{
			int listcount = list.Count;
			for ( int i = 0; i < count; i++ )
			{
				if ( i < listcount )
				{
					list[ i ] = func( i );
				}
				else
				{
					list.Add( func( i ) );
				}
			}
		}

		/// <summary>
		/// リストのすべての要素に対して指定された関数を適用します
		/// </summary>
		public static void Apply<T>( this IList<T> list, Func<T, int, T> func )
		{
			for ( int i = 0; i < list.Count; i++ )
			{
				list[ i ] = func( list[ i ], i );
			}
		}

		/// <summary>
		/// リストのすべての要素に対して指定された関数を適用します
		/// </summary>
		public static void Apply<T>( this IList<T> list, Func<T, T> func )
		{
			for ( int i = 0; i < list.Count; i++ )
			{
				list[ i ] = func( list[ i ] );
			}
		}

		/// <summary>
		/// 指定されたインデックスに要素が存在する場合に true を返します
		/// </summary>
		public static bool IsDefinedAt<T>( IList<T> self, int index )
		{
			return index < self.Count;
		}
	}
}
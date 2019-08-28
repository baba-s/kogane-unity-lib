using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// Enumerable クラスに関する汎用関数を管理するクラス
	/// </summary>
	public static class EnumerableUtils
	{
		/// <summary>
		/// 指定した範囲内の整数のシーケンスを生成します
		/// </summary>
		public static IEnumerable<int> Range( int count )
		{
			return Enumerable.Range( 0, count );
		}

		/// <summary>
		/// 指定した範囲内の整数のシーケンスを生成します
		/// </summary>
		public static IEnumerable<int> Range( uint count )
		{
			return Enumerable.Range( 0, ( int )count );
		}
	}
}
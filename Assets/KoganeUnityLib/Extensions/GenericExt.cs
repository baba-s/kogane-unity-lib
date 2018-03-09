using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// ジェネリックの拡張メソッドを管理するクラス
	/// </summary>
	public static class GenericExt
	{
		/// <summary>
		/// 指定したオブジェクトが 1 つでもこのコレクションに含まれるかどうかを返します
		/// </summary>
		public static bool ContainsAny<T>( this T self, IEnumerable<T> values )
		{
			return self.ContainsAny( values.ToArray() );
		}

		/// <summary>
		/// 指定したオブジェクトが 1 つでもこのコレクションに含まれるかどうかを返します
		/// </summary>
		public static bool ContainsAny<T>( this T self, params T[] values )
		{
			foreach ( var n in values )
			{
				if ( self.Equals( n ) )
				{
					return true;
				}
			}
			return false;
		}
	}
}
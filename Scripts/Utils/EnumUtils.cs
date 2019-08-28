using System;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// 列挙型に関する汎用関数を管理するクラス
	/// </summary>
	public static class EnumUtils
	{
		private static readonly Random m_random = new Random();  // 乱数

		/// <summary>
		/// 指定された列挙型の値をランダムに返します
		/// </summary>
		public static T RandomAt<T>( params T[] collection )
		{
			return collection
				.OrderBy( c => m_random.Next() )
				.FirstOrDefault()
			;
		}

		/// <summary>
		/// 指定された列挙型の値をランダムに返します
		/// </summary>
		public static T Random<T>()
		{
			return Enum.GetValues( typeof( T ) )
				.Cast<T>()
				.OrderBy( c => m_random.Next() )
				.FirstOrDefault()
			;
		}

		/// <summary>
		/// 指定された列挙型の値の数返します
		/// </summary>
		public static int GetLength<T>()
		{
			return Enum.GetValues( typeof( T ) ).Length;
		}

		/// <summary>
		/// 文字列形式での 1 つ以上の列挙定数の名前または数値を、等価の列挙オブジェクトに変換します
		/// </summary>
		public static T Parse<T>( string value )
		{
			return ( T )Enum.Parse( typeof( T ), value );
		}

		/// <summary>
		/// 文字列形式での 1 つ以上の列挙定数の名前または数値を、等価の列挙オブジェクトに変換します
		/// </summary>
		public static T Parse<T>( string value, bool ignoreCase )
		{
			return ( T )Enum.Parse( typeof( T ), value, ignoreCase );
		}

		/// <summary>
		/// 指定された文字列を列挙型に変換して成功したかどうかを返します
		/// </summary>
		public static bool TryParse<T>( string value, out T result )
		{
			return TryParse( value, true, out result );
		}

		/// <summary>
		/// 指定された文字列を列挙型に変換して成功したかどうかを返します
		/// </summary>
		public static bool TryParse<T>( string value, bool ignoreCase, out T result )
		{
			try
			{
				result = ( T )Enum.Parse( typeof( T ), value, ignoreCase );
				return true;
			}
			catch
			{
				result = default( T );
				return false;
			}
		}

		/// <summary>
		/// 指定された文字列が列挙型に変換できるかどうかを返します
		/// </summary>
		public static bool IsEnum<T>( string value )
		{
			T result;
			return TryParse<T>( value, out result );
		}

		/// <summary>
		/// 指定した列挙体に含まれている定数の値の配列を取得します
		/// </summary>
		public static T[] GetValues<T>()
		{
			return Enum.GetValues( typeof( T ) ) as T[];
		}

		/// <summary>
		/// 指定された整数値を列挙メンバーに変換して返します
		/// </summary>
		public static T ToObject<T>( int value )
		{
			return ( T )Enum.ToObject( typeof( T ), value );
		}
	}
}
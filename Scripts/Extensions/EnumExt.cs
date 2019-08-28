using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// Enum 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class EnumExt
	{
		/// <summary>
		/// 現在のインスタンスで 1 つ以上のビットフィールドが設定されているかどうかを判断します
		/// </summary>
		public static bool HasFlag( this Enum self, Enum flag )
		{
			if ( self.GetType() != flag.GetType() ) return false;

			var selfValue = Convert.ToUInt64( self );
			var flagValue = Convert.ToUInt64( flag );

			return ( selfValue & flagValue ) == flagValue;
		}

		/// <summary>
		/// 次の値に進みます。最大値を超える場合は初期値に戻ります
		/// </summary>
		public static T NextLoop<T>( this T self )
		{
			var intValue = Convert.ToInt32( self );
			var nextValue = ( intValue + 1 ) % EnumUtils.GetLength<T>();
			var enumValue = EnumUtils.ToObject<T>( nextValue );

			return enumValue;
		}
	}
}
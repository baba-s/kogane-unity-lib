using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// WWW 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class WWWExt
	{
		/// <summary>
		/// エラーが発生している場合 true を返します
		/// </summary>
		public static bool IsError( this WWW self )
		{
			return self == null || self.error.IsNotNullOrWhiteSpace();
		}

		/// <summary>
		/// エラーが発生していない場合 true を返します
		/// </summary>
		public static bool IsNotError( this WWW self )
		{
			return !self.IsError();
		}
	}
}
using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// IDisposable 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class IDisposableExt
	{
		/// <summary>
		/// 指定された IDisposable 型のインスタンスが null ではない場合にのみ Dispose を実行します
		/// </summary>
		public static void DisposeIfNotNull( this IDisposable self )
		{
			if ( self == null ) return;
			self.Dispose();
		}
	}
}
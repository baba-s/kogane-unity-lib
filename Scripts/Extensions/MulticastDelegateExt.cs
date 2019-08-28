using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// MulticastDelegate 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class MulticastDelegateExt
	{
		/// <summary>
		/// 登録されているデリゲートの数を返します
		/// </summary>
		public static int GetLengthIfNotNull( this MulticastDelegate self )
		{
			if ( self == null || self.GetInvocationList() == null ) return 0;
			return self.GetInvocationList().Length;
		}

		/// <summary>
		/// 登録されているデリゲートの数を返します
		/// </summary>
		public static int GetLength( this MulticastDelegate self )
		{
			return self.GetInvocationList().Length;
		}

		/// <summary>
		/// デリゲートが登録されていない場合 true を返します
		/// </summary>
		public static bool IsNullOrEmpty( this MulticastDelegate self )
		{
			return self == null || self.GetInvocationList() == null || self.GetInvocationList().Length <= 0;
		}

		/// <summary>
		/// デリゲートが登録されている場合 true を返します
		/// </summary>
		public static bool IsNotNullOrEmpty( this MulticastDelegate self )
		{
			return !self.IsNullOrEmpty();
		}
	}
}
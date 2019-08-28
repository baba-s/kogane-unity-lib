using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// uint 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class UintExt
	{
		/// <summary>
		/// 指定された回数分処理を繰り返します
		/// </summary>
		public static void Times( this uint self, Action act )
		{
			for ( uint i = 0; i < self; i++ )
			{
				act();
			}
		}

		/// <summary>
		/// 指定された回数分処理を繰り返します
		/// </summary>
		public static void Times( this uint self, Action<uint> act )
		{
			for ( uint i = 0; i < self; i++ )
			{
				act( i );
			}
		}

		/// <summary>
		/// <para>数値を指定された桁数で0埋めした文字列を返します</para>
		/// <para>123.ZeroFill( 4 ) → 01234</para>
		/// <para>123.ZeroFill( 8 ) → 000001234</para>
		/// </summary>
		public static string ZeroFill( this uint self, int numberOfDigits )
		{
			return self.ToString( "D" + numberOfDigits.ToString() );
		}
	}
}
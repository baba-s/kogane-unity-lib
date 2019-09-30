using System;
using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// int 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class IntExt
	{
		/// <summary>
		/// 指定された回数分処理を繰り返します
		/// </summary>
		public static void Times( this int self, Action act )
		{
			for ( int i = 0; i < self; i++ )
			{
				act();
			}
		}

		/// <summary>
		/// 指定された回数分処理を繰り返します
		/// </summary>
		public static void Times( this int self, Action<int> act )
		{
			for ( int i = 0; i < self; i++ )
			{
				act( i );
			}
		}

		/// <summary>
		/// 指定された回数分処理を逆順に繰り返します
		/// </summary>
		public static void TimesReverse( this int self, Action<int> act )
		{
			for ( int i = self - 1; 0 <= i; i-- )
			{
				act( i );
			}
		}

		/// <summary>
		/// <para>数値を指定された桁数で0埋めした文字列を返します</para>
		/// <para>123.ZeroFill( 4 ) → 01234</para>
		/// <para>123.ZeroFill( 8 ) → 000001234</para>
		/// </summary>
		public static string ZeroFill( this int self, int numberOfDigits )
		{
			return self.ToString( "D" + numberOfDigits.ToString() );
		}

		/// <summary>
		/// <para>数値に指定された桁数の固定小数点数を付加した文字列を返します</para>
		/// <para>123.FixedPoint(2) → 123.00</para>
		/// <para>123.FixedPoint(4) → 123.0000</para>
		/// </summary>
		public static string FixedPoint( this int self, int numberOfDigits )
		{
			return self.ToString( "F" + numberOfDigits.ToString() );
		}

		/// <summary>
		/// 数値を加算して、範囲を超えた分は 0 からの値として処理して返します
		/// </summary>
		public static int Repeat( this int self, int value, int max )
		{
			if ( max == 0 ) return self;
			return ( self + value + max ) % max;
		}

		/// <summary>
		/// 偶数かどうかを返します
		/// </summary>
		public static bool IsEven( this int self )
		{
			return self % 2 == 0;
		}

		/// <summary>
		/// 奇数かどうかを返します
		/// </summary>
		public static bool IsOdd( this int self )
		{
			return self % 2 == 1;
		}
		
		/// <summary>
		/// 値を範囲内に制限して返します
		/// </summary>
		public static float Clamp( this int value, int min, int max )
		{
			return Mathf.Clamp( value, min, max );
		}
	}
}
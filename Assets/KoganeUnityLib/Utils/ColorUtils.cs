using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Color クラスに関する汎用関数を管理するクラス
	/// </summary>
	public static class ColorUtils
	{
		/// <summary>
		/// <para>10 進数の数値を 16 進数の文字列に変換します</para>
		/// <para>1234.DecimalToHex() // 0004D2</para>
		/// </summary>
		public static string DecimalToHex( this int self )
		{
			self &= 0xFFFFFF;
			return self.ToString( "X6" );
		}

		/// <summary>
		/// <para>指定された 16 進数を色に変換します</para>
		/// <para>上位ビットから ARGB の順に変換します</para>
		/// <para>ColorUtils.ToARGB( 0xFFFF8000 ) // RGBA(1.000, 0.502, 0.000, 1.000)</para>
		/// </summary>
		public static Color ToARGB( uint val )
		{
			var inv = 1f / 255f;
			var c = Color.black;
			c.a = inv * ( ( val >> 24 ) & 0xFF );
			c.r = inv * ( ( val >> 16 ) & 0xFF );
			c.g = inv * ( ( val >> 8 ) & 0xFF );
			c.b = inv * ( val & 0xFF );
			return c;
		}

		/// <summary>
		/// <para>指定された 16 進数を色に変換します</para>
		/// <para>上位ビットから RGBA の順に変換します</para>
		/// <para>ColorUtils.ToARGB( 0xFF8000FF ) // RGBA(1.000, 0.502, 0.000, 1.000)</para>
		/// </summary>
		public static Color ToRGBA( uint val )
		{
			var inv = 1f / 255f;
			var c = Color.black;
			c.r = inv * ( ( val >> 24 ) & 0xFF );
			c.g = inv * ( ( val >> 16 ) & 0xFF );
			c.b = inv * ( ( val >> 8 ) & 0xFF );
			c.a = inv * ( val & 0xFF );
			return c;
		}

		/// <summary>
		/// <para>指定された 16 進数を色に変換します</para>
		/// <para>上位ビットから RGB の順に変換します</para>
		/// <para>ColorUtils.ToRGB( 0xFF8000 ) // RGBA(1.000, 0.502, 0.000, 1.000)</para>
		/// </summary>
		public static Color ToRGB( uint val )
		{
			var inv = 1f / 255f;
			var c = Color.black;
			c.r = inv * ( ( val >> 16 ) & 0xFF );
			c.g = inv * ( ( val >> 8 ) & 0xFF );
			c.b = inv * ( val & 0xFF );
			c.a = 1f;
			return c;
		}

		/// <summary>
		/// <para>指定された 16 進数を色に変換します</para>
		/// <para>上位ビットから RGB の順に変換します</para>
		/// <para>ColorUtils.ToRGB( 0xFF8000 ) // RGBA(1.000, 0.502, 0.000, 1.000)</para>
		/// </summary>
		public static Color ToRGB( int val )
		{
			return ToRGB( ( uint )val );
		}
	}
}
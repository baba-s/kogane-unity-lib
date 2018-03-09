using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Color 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ColorExt
	{
		/// <summary>
		/// <para>色を 16 進数の文字列に変換します</para>
		/// <para>Color.red.EncodeColor() // FF0000</para>
		/// </summary>
		public static string EncodeColor( this Color self )
		{
			int i = 0xFFFFFF & ( self.ToInt() >> 8 );
			return i.DecimalToHex();
		}

		/// <summary>
		/// 色を 16 進数の数値に変換します
		/// </summary>
		public static int ToInt( this Color self )
		{
			int result = 0;
			result |= Mathf.RoundToInt( self.r * 255f ) << 24;
			result |= Mathf.RoundToInt( self.g * 255f ) << 16;
			result |= Mathf.RoundToInt( self.b * 255f ) << 8;
			result |= Mathf.RoundToInt( self.a * 255f );
			return result;
		}
	}
}
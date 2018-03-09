namespace KoganeUnityLib
{
	/// <summary>
	/// byte 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ByteExt
	{
		/// <summary>
		/// bool 型に変換して返します
		/// </summary>
		public static bool ToBool( this byte self )
		{
			return self == 1;
		}

		/// <summary>
		/// <para>数値を指定された桁数で0埋めした文字列を返します</para>
		/// <para>123.ZeroFill( 4 ) → 01234</para>
		/// <para>123.ZeroFill( 8 ) → 000001234</para>
		/// </summary>
		public static string ZeroFill( this byte self, int numberOfDigits )
		{
			return self.ToString( "D" + numberOfDigits.ToString() );
		}
	}
}
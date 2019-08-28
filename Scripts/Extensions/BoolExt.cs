namespace KoganeUnityLib
{
	/// <summary>
	/// bool 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class BoolExt
	{
		/// <summary>
		/// byte 型に変換して返します
		/// </summary>
		public static byte ToByte( this bool self )
		{
			return ( byte )( self ? 1 : 0 );
		}
	}
}
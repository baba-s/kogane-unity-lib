namespace KoganeUnityLib
{
	/// <summary>
	/// object 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ObjectExt
	{
		/// <summary>
		/// 数値を 3 桁区切りの文字列に変換します
		/// </summary>
		public static string FormatWithComma( this object self )
		{
			return string.Format( "{0:#,##0}", self );
		}
	}
}
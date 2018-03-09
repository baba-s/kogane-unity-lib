using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// DateTime 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class DateTimeExt
	{
		/// <summary>
		/// UnixTime 基準時刻
		/// </summary>
		public static readonly DateTime UNIX_EPOCH = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );

		/// <summary>
		/// yyyy/MM/dd HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToPattern( this DateTime self )
		{
			return self.ToString( "yyyy/MM/dd HH:mm:ss" );
		}

		/// <summary>
		/// yyyy/MM/dd 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortDatePattern( this DateTime self )
		{
			return self.ToString( "yyyy/MM/dd" );
		}

		/// <summary>
		/// yyyy年M月d日 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongDatePattern( this DateTime self )
		{
			return self.ToString( "yyyy年M月d日" );
		}

		/// <summary>
		/// yyyy年M月d日 HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToFullDateTimePattern( this DateTime self )
		{
			return self.ToString( "yyyy年M月d日 HH:mm:ss" );
		}

		/// <summary>
		/// MM/dd HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToMiddleDateTimePattern( this DateTime self )
		{
			return self.ToString( "MM/dd HH:mm" );
		}

		/// <summary>
		/// HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortTimePattern( this DateTime self )
		{
			return self.ToString( "HH:mm" );
		}

		/// <summary>
		/// HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongTimePattern( this DateTime self )
		{
			return self.ToString( "HH:mm:ss" );
		}

		/// <summary>
		/// UnixTimeに変換して返します
		/// </summary>
		public static uint ToUnixTime( this DateTime self )
		{
			return ( uint )self.Subtract( UNIX_EPOCH ).TotalSeconds;
		}

		/// <summary>
		/// UnixTimeからDateTimeを生成します
		/// </summary>
		public static DateTime FromUnixTime( this DateTime self, long unixTime )
		{
			return UNIX_EPOCH.AddSeconds( unixTime ).ToLocalTime();
		}
	}
}
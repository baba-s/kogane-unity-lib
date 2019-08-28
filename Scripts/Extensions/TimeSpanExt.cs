using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// TimeSpan 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class TimeSpanExt
	{
		/// <summary>
		/// DateTime 型に変換します
		/// </summary>
		public static DateTime ToDateTime( this TimeSpan self )
		{
			return new DateTime( self.Ticks );
		}

		/// <summary>
		/// yyyy/MM/dd HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToPattern( this TimeSpan self )
		{
			return self.ToDateTime().ToPattern();
		}

		/// <summary>
		/// yyyy/MM/dd 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortDatePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToShortDatePattern();
		}

		/// <summary>
		/// yyyy年M月d日 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongDatePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToLongDatePattern();
		}

		/// <summary>
		/// yyyy年M月d日 HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToFullDateTimePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToFullDateTimePattern();
		}

		/// <summary>
		/// MM/dd HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToMiddleDateTimePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToMiddleDateTimePattern();
		}

		/// <summary>
		/// HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortTimePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToShortTimePattern();
		}

		/// <summary>
		/// HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongTimePattern( this TimeSpan self )
		{
			return self.ToDateTime().ToLongTimePattern();
		}
	}
}
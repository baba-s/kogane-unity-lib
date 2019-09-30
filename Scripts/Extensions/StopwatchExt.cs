using System;
using System.Diagnostics;

namespace KoganeUnityLib
{
	/// <summary>
	/// Stopwatch 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class StopwatchExt
	{
		/// <summary>
		/// yyyy/MM/dd HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToPattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "yyyy/MM/dd HH:mm:ss" );
		}

		/// <summary>
		/// yyyy/MM/dd 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortDatePattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "yyyy/MM/dd" );
		}

		/// <summary>
		/// yyyy年M月d日 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongDatePattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "yyyy年M月d日" );
		}

		/// <summary>
		/// yyyy年M月d日 HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToFullStopwatchPattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "yyyy年M月d日 HH:mm:ss" );
		}

		/// <summary>
		/// MM/dd HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToMiddleStopwatchPattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "MM/dd HH:mm" );
		}

		/// <summary>
		/// HH:mm 形式の文字列に変換して返します
		/// </summary>
		public static string ToShortTimePattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "HH:mm" );
		}

		/// <summary>
		/// HH:mm:ss 形式の文字列に変換して返します
		/// </summary>
		public static string ToLongTimePattern( this Stopwatch self )
		{
			return new DateTime( self.Elapsed.Ticks ).ToString( "HH:mm:ss" );
		}
	}
}
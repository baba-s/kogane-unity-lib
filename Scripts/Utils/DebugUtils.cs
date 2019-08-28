using System.Diagnostics;

namespace KoganeUnityLib
{
	/// <summary>
	/// Debug クラスに関する汎用関数を管理するクラス
	/// </summary>
	public static class DebugUtils
	{
		/// <summary>
		/// 一時停止します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Break()
		{
			UnityEngine.Debug.Break();
		}

		/// <summary>
		/// ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Log( object message )
		{
			UnityEngine.Debug.Log( message );
		}

		/// <summary>
		/// ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Log( object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.Log( message, context );
		}

		/// <summary>
		/// ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void LogFormat( string format, params object[] args )
		{
			UnityEngine.Debug.LogFormat( format, args );
		}

		/// <summary>
		/// ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void LogFormat( UnityEngine.Object context, string format, params object[] args )
		{
			UnityEngine.Debug.LogFormat( context, format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合はログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Log( bool condition, object message )
		{
			if ( condition ) return;
			UnityEngine.Debug.Log( message );
		}

		/// <summary>
		/// 指定された条件が false の場合はログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Log( bool condition, object message, UnityEngine.Object context )
		{
			if ( condition ) return;
			UnityEngine.Debug.Log( message, context );
		}

		/// <summary>
		/// 指定された条件が false の場合はログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void LogFormat( bool condition, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogFormat( format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合はログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void LogFormat( bool condition, UnityEngine.Object context, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogFormat( context, format, args );
		}

		/// <summary>
		/// 警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Warning( object message )
		{
			UnityEngine.Debug.LogWarning( message );
		}

		/// <summary>
		/// 警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Warning( object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.LogWarning( message, context );
		}

		/// <summary>
		/// 警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void WarningFormat( string format, params object[] args )
		{
			UnityEngine.Debug.LogWarningFormat( format, args );
		}

		/// <summary>
		/// 警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void WarningFormat( UnityEngine.Object context, string format, params object[] args )
		{
			UnityEngine.Debug.LogWarningFormat( context, format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合は警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Warning( bool condition, object message )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogWarning( message );
		}

		/// <summary>
		/// 指定された条件が false の場合は警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Warning( bool condition, object message, UnityEngine.Object context )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogWarning( message, context );
		}

		/// <summary>
		/// 指定された条件が false の場合は警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void WarningFormat( bool condition, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogWarningFormat( format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合は警告ログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void WarningFormat( bool condition, UnityEngine.Object context, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogWarningFormat( context, format, args );
		}

		/// <summary>
		/// エラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Error( object message )
		{
			UnityEngine.Debug.LogError( message );
		}

		/// <summary>
		/// エラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Error( object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.LogError( message, context );
		}

		/// <summary>
		/// エラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void ErrorFormat( string format, params object[] args )
		{
			UnityEngine.Debug.LogErrorFormat( format, args );
		}

		/// <summary>
		/// エラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void ErrorFormat( UnityEngine.Object context, string format, params object[] args )
		{
			UnityEngine.Debug.LogErrorFormat( context, format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合はエラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Error( bool condition, object message )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogError( message );
		}

		/// <summary>
		/// 指定された条件が false の場合はエラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void Error( bool condition, object message, UnityEngine.Object context )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogError( message, context );
		}

		/// <summary>
		/// 指定された条件が false の場合はエラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void ErrorFormat( bool condition, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogErrorFormat( format, args );
		}

		/// <summary>
		/// 指定された条件が false の場合はエラーログを出力します
		/// </summary>
		[Conditional( "DEBUG_LOG" )]
		public static void ErrorFormat( bool condition, UnityEngine.Object context, string format, params object[] args )
		{
			if ( condition ) return;
			UnityEngine.Debug.LogErrorFormat( context, format, args );
		}
	}
}
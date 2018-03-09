using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// Action 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ActionExt
	{
		/// <summary>
		/// パラメーターを受け取らない Action デリゲートを実行します
		/// </summary>
		public static void Call( this Action action )
		{
			if ( action != null )
			{
				action();
			}
		}

		/// <summary>
		/// 1 つのパラメーターを受け取る Action デリゲートを実行します
		/// </summary>
		public static void Call<T>( this Action<T> action, T arg )
		{
			if ( action != null )
			{
				action( arg );
			}
		}

		/// <summary>
		/// 2 つのパラメーターを受け取る Action デリゲートを実行します
		/// </summary>
		public static void Call<T1, T2>( this Action<T1, T2> action, T1 arg1, T2 arg2 )
		{
			if ( action != null )
			{
				action( arg1, arg2 );
			}
		}

		/// <summary>
		/// 3 つのパラメーターを受け取る Action デリゲートを実行します
		/// </summary>
		public static void Call<T1, T2, T3>( this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3 )
		{
			if ( action != null )
			{
				action( arg1, arg2, arg3 );
			}
		}

		/// <summary>
		/// 4 つのパラメーターを受け取る Action デリゲートを実行します
		/// </summary>
		public static void Call<T1, T2, T3, T4>( this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			if ( action != null )
			{
				action( arg1, arg2, arg3, arg4 );
			}
		}

		/// <summary>
		/// <para>パラメーターを受け取らない Action デリゲートを実行します</para>
		/// <para>デリゲートが null の場合は代わりに defaultValue を実行します</para>
		/// </summary>
		public static void CallOrDefault( this Action self, Action defaultValue )
		{
			if ( self == null )
			{
				defaultValue();
				return;
			}
			self();
		}

		/// <summary>
		/// <para>1 つのパラメーターを受け取る Action デリゲートを実行します</para>
		/// <para>デリゲートが null の場合は代わりに defaultValue を実行します</para>
		/// </summary>
		public static void CallOrDefault<T>( this Action<T> self, T arg, Action defaultValue )
		{
			if ( self == null )
			{
				defaultValue();
				return;
			}
			self( arg );
		}

		/// <summary>
		/// <para>1 つのパラメーターを受け取る Action デリゲートを実行します</para>
		/// <para>デリゲートが null の場合は代わりに defaultValue を実行します</para>
		/// </summary>
		public static void CallOrDefault<T1, T2>( this Action<T1, T2> self, T1 arg1, T2 arg2, Action defaultValue )
		{
			if ( self == null )
			{
				defaultValue();
				return;
			}
			self( arg1, arg2 );
		}
	}
}
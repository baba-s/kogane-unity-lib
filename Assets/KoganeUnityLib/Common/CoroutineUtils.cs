using System;
using System.Collections;
using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// コルーチンに関する汎用クラス
	/// </summary>
	public static class CoroutineUtils
	{
		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private static readonly MonoBehaviour m_behaviour;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// コルーチンを管理するゲームオブジェクトを生成するコンストラクタ
		/// </summary>
		static CoroutineUtils()
		{
			var gameObject = new GameObject( "CoroutineUtils" );
			gameObject.DontDestroyOnLoad();
			m_behaviour = gameObject.AddComponent<FooBehaviour>();
		}

		/// <summary>
		/// 条件を満たしたら Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForCondition( GameObject gameObject, Func<bool> condition, Action act )
		{
			if ( m_behaviour.HasBeenDestroyed() ) return;

			if ( condition() )
			{
				act();
				return;
			}

			m_behaviour.StartCoroutine( DoCallWaitForCondition( gameObject, condition, act ) );
		}

		/// <summary>
		/// 条件を満たしたら Action デリゲートを呼び出します
		/// </summary>
		public static IEnumerator DoCallWaitForCondition( GameObject gameObject, Func<bool> condition, Action act )
		{
			while ( !condition() ) yield return 0;
			if ( gameObject == null ) yield break;
			act.Call();
		}

		/// <summary>
		/// 条件を満たしたら Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForCondition( Func<bool> condition, Action act )
		{
			if ( m_behaviour.HasBeenDestroyed() ) return;

			if ( condition() )
			{
				act();
				return;
			}

			m_behaviour.StartCoroutine( DoCallWaitForCondition( condition, act ) );
		}

		/// <summary>
		/// 条件を満たしたら Action デリゲートを呼び出します
		/// </summary>
		public static IEnumerator DoCallWaitForCondition( Func<bool> condition, Action act )
		{
			while ( !condition() ) yield return 0;
			act.Call();
		}

		/// <summary>
		/// 1 フレーム待機してから Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForEndOfFrame( GameObject gameObject, Action act )
		{
			m_behaviour.StartCoroutine( DoCallWaitForEndOfFrame( gameObject, act ) );
		}

		/// <summary>
		/// 1 フレーム待機してから Action デリゲートを呼び出します
		/// </summary>
		private static IEnumerator DoCallWaitForEndOfFrame( GameObject gameObject, Action act )
		{
			yield return 0;
			if ( gameObject == null ) yield break;
			act.Call();
		}


		/// <summary>
		/// 1 フレーム待機してから Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForEndOfFrame( Action act )
		{
			m_behaviour.StartCoroutine( DoCallWaitForEndOfFrame( act ) );
		}

		/// <summary>
		/// 1 フレーム待機してから Action デリゲートを呼び出します
		/// </summary>
		private static IEnumerator DoCallWaitForEndOfFrame( Action act )
		{
			yield return 0;
			act.Call();
		}

		/// <summary>
		/// 指定された秒数待機してから Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForSeconds( GameObject gameObject, float seconds, Action act )
		{
			m_behaviour.StartCoroutine( DoCallWaitForSeconds( gameObject, seconds, act ) );
		}

		/// <summary>
		/// 指定された秒数待機してから Action デリゲートを呼び出します
		/// </summary>
		private static IEnumerator DoCallWaitForSeconds( GameObject gameObject, float seconds, Action act )
		{
			yield return new WaitForSeconds( seconds );
			if ( gameObject == null ) yield break;
			act.Call();
		}

		/// <summary>
		/// 指定された秒数待機してから Action デリゲートを呼び出します
		/// </summary>
		public static void CallWaitForSeconds( float seconds, Action act )
		{
			m_behaviour.StartCoroutine( DoCallWaitForSeconds( seconds, act ) );
		}

		/// <summary>
		/// 指定された秒数待機してから Action デリゲートを呼び出します
		/// </summary>
		private static IEnumerator DoCallWaitForSeconds( float seconds, Action act )
		{
			yield return new WaitForSeconds( seconds );
			act.Call();
		}

		/// <summary>
		/// 指定されたコルーチンを開始します
		/// </summary>
		public static void StartCoroutine( IEnumerator routice )
		{
			m_behaviour.StartCoroutine( routice );
		}
	}
}
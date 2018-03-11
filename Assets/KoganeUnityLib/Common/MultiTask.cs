using System;
using System.Collections;
using System.Collections.Generic;

namespace KoganeUnityLib
{
	/// <summary>
	/// 並列でタスクを管理するクラス
	/// </summary>
	public sealed class MultiTask : IEnumerable
	{
		private readonly List<Action<Action>> m_list = new List<Action<Action>>();

		private bool m_isPlaying;

		/// <summary>
		/// タスクを追加します
		/// </summary>
		public void Add( Action<Action> task )
		{
			if ( task == null || m_isPlaying ) return;

			m_list.Add( task );
		}

		/// <summary>
		/// タスクを実行します
		/// </summary>
		public void Play( Action onCompleted = null )
		{
			if ( onCompleted == null )
			{
				onCompleted = delegate { };
			}

			if ( m_list.Count <= 0 )
			{
				onCompleted();
				return;
			}

			m_isPlaying = true;

			var task = CallOfCountsFromDelegate( m_list.Count, () =>
			{
				m_isPlaying = false;
				m_list.Clear();
				onCompleted();
			} );

			for ( int i = 0; i < m_list.Count; i++ )
			{
				var n = m_list[ i ];
				Action nextTask = task;
				n( () =>
				{
					if ( nextTask == null ) return;
					nextTask();
					nextTask = null;
				} );
			}
		}

		/// <summary>
		/// この関数によって返されたIEnumeratorのMoveNext()を呼び出すことでカウントが減っていきます
		/// 呼び出すたびに指定した回数分まで <c>onUpdated</c> デリゲートを実行します
		/// 指定した回数分MoveNext()を呼び出すと<c>onCompleted</c> デリゲートを実行します。
		/// </summary>
		private static IEnumerator CallOfCounts( int count, Action onCompleted, Action onUpdated = null )
		{
			if ( onUpdated == null )
			{
				onUpdated = delegate { };
			}

			onUpdated();

			while ( 0 < --count )
			{
				yield return count;
				onUpdated();
			}
			onCompleted();

			onCompleted = null;
			onUpdated = null;
		}

		/// <summary>
		/// この関数によって返されたデリゲートを呼び出すことでカウントが減っていきます
		/// 呼び出すたびに指定した回数分まで <c>onUpdated</c> デリゲートを実行します
		/// 指定した回数分デリゲートを呼び出すと<c>onCompleted</c> デリゲートを実行します
		///
		/// CallOfCountsのデリゲートのみを返す版
		/// </summary>
		private static Action CallOfCountsFromDelegate( int count, Action onCompleted, Action onUpdated = null )
		{
			var coroutine = CallOfCounts( count, onCompleted, onUpdated );
			return () => coroutine.MoveNext();
		}

		/// <summary>
		/// コレクションを反復処理する列挙子を返します
		/// </summary>
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
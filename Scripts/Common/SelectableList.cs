using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// 変更を検知可能なリスト
	/// </summary>
	public class SelectableList<T> : IList<T>, IDisposable
	{
		private readonly List<T> m_list; // リスト

		/// <summary>
		/// 指定したインデックスにある要素を取得または設定します
		/// </summary>
		public T this[ int index ]
		{
			get { return m_list[ index ]; }
			set
			{
				m_list[ index ] = value;
				mChanged.Call();
			}
		}

		/// <summary>
		/// リストに格納されている要素の数を取得します
		/// </summary>
		public int Count { get { return m_list.Count; } }

		/// <summary>
		/// リストが読み取り専用かどうかを示す値を取得します
		/// </summary>
		public bool IsReadOnly { get { return false; } }

		/// <summary>
		/// 変更された時に呼び出されます
		/// </summary>
#pragma warning disable 0067
		public Action mChanged;
#pragma warning restore 0067

		/// <summary>
		/// 破棄します
		/// </summary>
		public void Dispose()
		{
			mChanged = null;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SelectableList()
		{
			m_list = new List<T>();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SelectableList( params T[] collection )
		{
			m_list = new List<T>( collection );
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SelectableList( IList<T> collection )
		{
			m_list = new List<T>( collection );
		}

		/// <summary>
		/// リストからすべての要素を削除して、指定したコレクションの要素を List に追加します
		/// </summary>
		public void Set( params T[] collection )
		{
			m_list.Set( collection );
			mChanged.Call();
		}

		/// <summary>
		/// リストからすべての要素を削除して、指定したコレクションの要素を List に追加します
		/// </summary>
		public void Set( IList<T> collection )
		{
			m_list.Set( collection );
			mChanged.Call();
		}

		/// <summary>
		/// <para>リストからすべての要素を削除して、指定したコレクションの要素を List に追加します</para>
		/// <para>値の設定後に mChanged イベントは呼び出されません</para>
		/// </summary>
		public void SetWithoutCallback( params T[] collection )
		{
			m_list.Set( collection );
		}

		/// <summary>
		/// <para>リストからすべての要素を削除して、指定したコレクションの要素を List に追加します</para>
		/// <para>値の設定後に mChanged イベントは呼び出されません</para>
		/// </summary>
		public void SetWithoutCallback( IList<T> collection )
		{
			m_list.Set( collection );
		}

		/// <summary>
		/// リストの要素を新しい配列にコピーします
		/// </summary>
		public T[] ToArray()
		{
			return m_list.ToArray();
		}

		/// <summary>
		/// リストの要素を新しいリストにコピーします
		/// </summary>
		public List<T> ToList()
		{
			return m_list.ToList();
		}

		/// <summary>
		/// <para>リスト内またはその一部にある値のうち、</para>
		///<para> 最初に出現する値の、0 から始まるインデックス番号を返します</para>
		/// </summary>
		public int IndexOf( T item )
		{
			return m_list.IndexOf( item );
		}

		/// <summary>
		/// リスト内の指定したインデックスの位置に要素を挿入します
		/// </summary>
		public void Insert( int index, T item )
		{
			m_list.Insert( index, item );
			mChanged.Call();
		}

		/// <summary>
		/// リストの指定したインデックスにある要素を削除します
		/// </summary>
		public void RemoveAt( int index )
		{
			m_list.RemoveAt( index );
			mChanged.Call();
		}

		/// <summary>
		/// リストの末尾にオブジェクトを追加します
		/// </summary>
		public void Add( T item )
		{
			m_list.Add( item );
			mChanged.Call();
		}

		/// <summary>
		/// <para>リストの末尾にオブジェクトを追加します</para>
		/// <para>値の設定後に mChanged イベントは呼び出されません</para>
		/// </summary>
		public void AddWithoutCallback( T item )
		{
			m_list.Add( item );
		}

		/// <summary>
		/// リストからすべての要素を削除します
		/// </summary>
		public void Clear()
		{
			m_list.Clear();
			mChanged.Call();
		}

		/// <summary>
		/// <para>リストからすべての要素を削除します</para>
		/// <para>値の設定後に mChanged イベントは呼び出されません</para>
		/// </summary>
		public void ClearWithoutCallback()
		{
			m_list.Clear();
		}

		/// <summary>
		/// 指定された要素が存在する場合 true を返します
		/// </summary>
		public bool Contains( T item )
		{
			return m_list.Contains( item );
		}

		/// <summary>
		/// リストまたはその一部を配列にコピーします
		/// </summary>
		public void CopyTo( T[] array, int arrayIndex )
		{
			m_list.CopyTo( array, arrayIndex );
		}

		/// <summary>
		/// リスト内で最初に見つかった特定のオブジェクトを削除します
		/// </summary>
		public bool Remove( T item )
		{
			var result = m_list.Remove( item );
			mChanged.Call();
			return result;
		}

		/// <summary>
		/// リスト内で最初に見つかった特定のオブジェクトを削除します
		/// </summary>
		public void Remove( Predicate<T> match )
		{
			RemoveWithoutCallback( match );
			mChanged.Call();
		}

		/// <summary>
		/// <para>リスト内で最初に見つかった特定のオブジェクトを削除します</para>
		/// <para>mChanged イベントは呼び出されません</para>
		/// </summary>
		public void RemoveWithoutCallback( Predicate<T> match )
		{
			m_list.Remove( match );
		}

		/// <summary>
		/// 指定した述語によって定義される条件に一致するすべての要素を削除します
		/// </summary>
		public int RemoveAll( Predicate<T> match )
		{
			var result = RemoveAllWithoutCallback( match );
			mChanged.Call();
			return result;
		}

		/// <summary>
		/// <para>指定した述語によって定義される条件に一致するすべての要素を削除します</para>
		/// <para>mChanged イベントは呼び出されません</para>
		/// </summary>
		public int RemoveAllWithoutCallback( Predicate<T> match )
		{
			return m_list.RemoveAll( match );
		}

		/// <summary>
		/// <para>リストの末尾にオブジェクトを追加します</para>
		/// <para>指定された要素が存在する場合削除します</para>
		/// </summary>
		public void AddOrRemove( T item )
		{
			if ( Contains( item ) )
			{
				Remove( item );
			}
			else
			{
				Add( item );
			}
		}

		/// <summary>
		/// リストを反復処理する列挙子を返します
		/// </summary>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return m_list.GetEnumerator();
		}

		/// <summary>
		/// リストを反復処理する列挙子を返します
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_list.GetEnumerator();
		}
	}
}
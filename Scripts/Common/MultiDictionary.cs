using System.Collections;
using System.Collections.Generic;

namespace KoganeUnityLib
{
	public class MultiDictionary<TKey, TValue> : IDictionary<TKey, List<TValue>>
	{
		private Dictionary<TKey, List<TValue>> m_dic;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MultiDictionary( IEqualityComparer<TKey> comparer )
		{
			m_dic = new Dictionary<TKey, List<TValue>>( comparer );
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MultiDictionary()
		{
			m_dic = new Dictionary<TKey, List<TValue>>();
		}

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( TKey key, TValue value )
		{
			if ( !m_dic.ContainsKey( key ) )
			{
				m_dic.Add( key, new List<TValue>() );
			}
			m_dic[ key ].Add( value );
		}

		/// <summary>
		/// IEnumerator を返します
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_dic.GetEnumerator();
		}

		/// <summary>
		/// IEnumerator を返します
		/// </summary>
		public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
		{
			return m_dic.GetEnumerator();
		}

		/// <summary>
		/// 要素の数を返します
		/// </summary>
		public int Count { get { return m_dic.Count; } }

		/// <summary>
		/// 読み取り専用の場合 true 返します
		/// </summary>
		public bool IsReadOnly { get { return false; } }

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( KeyValuePair<TKey, List<TValue>> pair )
		{
			foreach ( TValue value in pair.Value )
			{
				Add( pair.Key, value );
			}
		}

		/// <summary>
		/// 値を削除します
		/// </summary>
		public bool Remove( KeyValuePair<TKey, List<TValue>> pair )
		{
			return Remove( pair.Key );
		}

		/// <summary>
		/// 全ての要素を削除します
		/// </summary>
		public void Clear()
		{
			m_dic.Clear();
		}

		/// <summary>
		/// 指定されたキーに紐付く値を取得または設定します
		/// </summary>
		public List<TValue> this[ TKey key ]
		{
			get { return m_dic[ key ]; }
			set { m_dic[ key ] = value; }
		}

		/// <summary>
		/// キーの一覧を返します
		/// </summary>
		public ICollection<TKey> Keys { get { return m_dic.Keys; } }

		/// <summary>
		/// 値の一覧を返します
		/// </summary>
		public ICollection<List<TValue>> Values { get { return m_dic.Values; } }

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( TKey key, List<TValue> values )
		{
			foreach ( TValue value in values )
			{
				Add( key, value );
			}
		}

		/// <summary>
		/// 指定されたキーを削除します
		/// </summary>
		public bool Remove( TKey key )
		{
			return m_dic.Remove( key );
		}

		/// <summary>
		/// 指定されたキーが存在する場合 true を返します
		/// </summary>
		public bool ContainsKey( TKey key )
		{
			return m_dic.ContainsKey( key );
		}

		/// <summary>
		/// 指定されたキーに紐付く値を返します
		/// </summary>
		public bool TryGetValue( TKey key, out List<TValue> value )
		{
			return m_dic.TryGetValue( key, out value );
		}

		public bool Contains( KeyValuePair<TKey, List<TValue>> item )
		{
			throw new System.NotImplementedException();
		}

		public void CopyTo( KeyValuePair<TKey, List<TValue>>[] array, int arrayIndex )
		{
			throw new System.NotImplementedException();
		}
	}
}

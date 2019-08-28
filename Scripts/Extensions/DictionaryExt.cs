using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KoganeUnityLib
{
	/// <summary>
	/// Dictionary 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class DictionaryExt
	{
		/// <summary>
		/// 指定したキーに関連付けられている値を取得します。キーが存在しない場合は既定値を返します
		/// </summary>
		public static TValue GetOrDefault<TKey, TValue>( this Dictionary<TKey, TValue> self, TKey key, TValue defaultValue = default( TValue ) )
		{
			TValue value;
			return self.TryGetValue( key, out value ) ? value : defaultValue;
		}

		/// <summary>
		/// Hashtable に変換します
		/// </summary>
		public static Hashtable ToHashtable<TKey, TValue>( this Dictionary<TKey, TValue> self )
		{
			var result = new Hashtable();
			foreach ( var n in self )
			{
				result[ n.Key ] = n.Value;
			}
			return result;
		}

		/// <summary>
		/// ランダムに値を返します
		/// </summary>
		public static TValue ElementAtRandom<TKey, TValue>( this Dictionary<TKey, TValue> self )
		{
			return self.ElementAt( UnityEngine.Random.Range( 0, self.Count ) ).Value;
		}

		/// <summary>
		/// クリアします。null の場合は何も行いません
		/// </summary>
		public static void ClearIfNotNull<TKey, TValue>( this Dictionary<TKey, TValue> self )
		{
			if ( self == null ) return;
			self.Clear();
		}
	}
}
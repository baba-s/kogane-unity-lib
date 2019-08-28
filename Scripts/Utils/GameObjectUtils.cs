using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// GameObject クラスに関する汎用関数を管理するクラス
	/// </summary>
	public static class GameObjectUtils
	{
		/// <summary>
		/// 指定された名前のゲームオブジェクトが存在するかどうかを返します
		/// </summary>
		public static bool Exists( string name )
		{
			return GameObject.Find( name );
		}
	}
}
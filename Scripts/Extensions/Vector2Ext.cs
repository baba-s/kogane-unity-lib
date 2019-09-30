using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Vector2 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class Vector2Ext
	{
		/// <summary>
		/// 値を四捨五入して返します
		/// </summary>
		public static Vector2 Round( this Vector2 self )
		{
			return new Vector2
			(
				Mathf.Round( self.x ),
				Mathf.Round( self.y )
			);
		}
	}
}
using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Vector3 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class Vector3Ext
	{
		/// <summary>
		/// x,y,zの値が等しいかを返します
		/// </summary>
		public static bool IsUniform( this Vector3 self )
		{
			return Mathf.Approximately( self.x, self.y ) && Mathf.Approximately( self.x, self.z );
		}
	}
}
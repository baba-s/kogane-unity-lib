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
		
		/// <summary>
		/// 値を四捨五入して返します
		/// </summary>
		public static Vector3 Round( this Vector3 self )
		{
			return new Vector3
			(
				Mathf.Round( self.x ),
				Mathf.Round( self.y ),
				Mathf.Round( self.z )
			);
		}
	}
}
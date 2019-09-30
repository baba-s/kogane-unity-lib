using UnityEngine;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	/// <summary>
	/// Image 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ImageExt
	{
		/// <summary>
		/// sprite を設定します
		/// </summary>
		public static void SetSpriteAndSnap( this Image self, Sprite sprite )
		{
			self.sprite = sprite;
			self.SetNativeSize();
		}
	}
}
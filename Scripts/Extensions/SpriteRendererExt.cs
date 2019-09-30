using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// SpriteRenderer 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class SpriteRendererExt
	{
		/// <summary>
		/// 透明度を設定します
		/// </summary>
		public static void SetAlpha( this SpriteRenderer self, float alpha )
		{
			var color = self.color;
			color.a    = alpha;
			self.color = color;
		}
	}
}
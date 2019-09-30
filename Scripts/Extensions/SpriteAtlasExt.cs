using UnityEngine;
using UnityEngine.U2D;

namespace KoganeUnityLib
{
	/// <summary>
	/// SpriteAtlas 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class SpriteAtlasExt
	{
		/// <summary>
		/// スプライトの配列を返します
		/// </summary>
		public static Sprite[] GetSprites( this SpriteAtlas self )
		{
			var sprites = new Sprite[self.spriteCount];
			self.GetSprites( sprites );
			return sprites;
		}
	}
}
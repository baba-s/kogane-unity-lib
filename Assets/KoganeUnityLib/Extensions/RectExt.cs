using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Rect 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class RectExt
	{
		/// <summary>
		/// 位置をズラします
		/// </summary>
		public static Rect Shift( this Rect self, Vector2 offset )
		{
			self.x += offset.x;
			self.y += offset.y;
			return self;
		}

		/// <summary>
		/// 位置をズラします
		/// </summary>
		public static Rect Shift( this Rect self, float offsetX, float offsetY )
		{
			self.x += offsetX;
			self.y += offsetY;
			return self;
		}
	}
}
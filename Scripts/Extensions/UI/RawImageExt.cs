using UnityEngine;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	public static class RawImageExt
	{
		/// <summary>
		/// texture を設定します
		/// </summary>
		public static void SetTextureAndSnap( this RawImage self, Texture texture )
		{
			self.texture = texture;
			self.SetNativeSize();
		}

		public static float GetUvRectX( this RawImage self )
		{
			return self.uvRect.x;
		}

		public static float GetUvRectY( this RawImage self )
		{
			return self.uvRect.y;
		}

		public static float GetUvRectW( this RawImage self )
		{
			return self.uvRect.width;
		}

		public static float GetUvRectH( this RawImage self )
		{
			return self.uvRect.height;
		}

		public static void SetUvRectX( this RawImage self, float value )
		{
			var uvRect = self.uvRect;
			uvRect.x    = value;
			self.uvRect = uvRect;
		}

		public static void SetUvRectY( this RawImage self, float value )
		{
			var uvRect = self.uvRect;
			uvRect.y    = value;
			self.uvRect = uvRect;
		}

		public static void SetUvRectW( this RawImage self, float value )
		{
			var uvRect = self.uvRect;
			uvRect.width = value;
			self.uvRect  = uvRect;
		}

		public static void SetUvRectH( this RawImage self, float value )
		{
			var uvRect = self.uvRect;
			uvRect.height = value;
			self.uvRect   = uvRect;
		}
	}
}
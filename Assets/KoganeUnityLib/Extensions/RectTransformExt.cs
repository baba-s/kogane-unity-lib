using UnityEngine;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	/// <summary>
	/// RectTransform 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class RectTransformExt
	{
		/// <summary>
		/// 幅を返します
		/// </summary>
		public static float GetWidth( this Graphic self )
		{
			return self.rectTransform.GetWidth();
		}

		/// <summary>
		/// 高さを返します
		/// </summary>
		public static float GetHeight( this Graphic self )
		{
			return self.rectTransform.GetHeight();
		}

		/// <summary>
		/// 幅を設定します
		/// </summary>
		public static void SetWidth( this Graphic self, float width )
		{
			self.rectTransform.SetWidth( width );
		}

		/// <summary>
		/// 高さを設定します
		/// </summary>
		public static void SetHeight( this Graphic self, float height )
		{
			self.rectTransform.SetHeight( height );
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize( this Graphic self, float width, float height )
		{
			self.rectTransform.SetSize( width, height );
		}

		/// <summary>
		/// 幅を返します
		/// </summary>
		public static float GetWidth( this RectTransform self )
		{
			return self.sizeDelta.x;
		}

		/// <summary>
		/// 高さを返します
		/// </summary>
		public static float GetHeight( this RectTransform self )
		{
			return self.sizeDelta.y;
		}

		/// <summary>
		/// 幅を設定します
		/// </summary>
		public static void SetWidth( this RectTransform self, float width )
		{
			var size = self.sizeDelta;
			size.x = width;
			self.sizeDelta = size;
		}

		/// <summary>
		/// 高さを設定します
		/// </summary>
		public static void SetHeight( this RectTransform self, float height )
		{
			var size = self.sizeDelta;
			size.y = height;
			self.sizeDelta = size;
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSizeX( this RectTransform self, float width )
		{
			self.sizeDelta = new Vector2( width, self.sizeDelta.y );
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSizeY( this RectTransform self, float height )
		{
			self.sizeDelta = new Vector2( self.sizeDelta.x, height );
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize( this RectTransform self, float width, float height )
		{
			self.sizeDelta = new Vector2( width, height );
		}
		
		public static void SetAnchoredPosition
		( 
			this RectTransform self, 
			Vector2 value
		)
		{
			self.anchoredPosition = value;
		}
		
		public static void SetAnchoredPosition
		( 
			this RectTransform self, 
			float              x,
			float              y 
		)
		{
			self.anchoredPosition = new Vector2( x, y );
		}
		
		public static void SetAnchoredPositionX
		( 
			this RectTransform self, 
			float              x 
		)
		{
			var pos = self.anchoredPosition;
			pos.x                 = x;
			self.anchoredPosition = pos;
		}

		public static void SetAnchoredPositionY
		( 
			this RectTransform self, 
			float              y 
		)
		{
			var pos = self.anchoredPosition;
			pos.y                 = y;
			self.anchoredPosition = pos;
		}
	}
}
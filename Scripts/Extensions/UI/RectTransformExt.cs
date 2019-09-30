using UnityEngine;

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
			self.sizeDelta = new Vector2( width, self.sizeDelta.y );
		}

		/// <summary>
		/// 高さを設定します
		/// </summary>
		public static void SetHeight( this RectTransform self, float height )
		{
			self.sizeDelta = new Vector2( self.sizeDelta.x, height );
		}

		/// <summary>
		/// 幅を設定します
		/// </summary>
		public static void SetSizeX( this RectTransform self, float width )
		{
			self.sizeDelta = new Vector2( width, self.sizeDelta.y );
		}

		/// <summary>
		/// 高さを設定します
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

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize( this RectTransform self, Vector2 sizeDelta )
		{
			self.sizeDelta = sizeDelta;
		}

		/// <summary>
		/// anchoredPosition を設定します
		/// </summary>
		public static void SetAnchoredPosition( this RectTransform self, Vector2 value )
		{
			self.anchoredPosition = value;
		}
		
		/// <summary>
		/// anchoredPosition を設定します
		/// </summary>
		public static void SetAnchoredPosition( this RectTransform self, float x, float y )
		{
			self.anchoredPosition = new Vector2( x, y );
		}
		
		/// <summary>
		/// anchoredPosition.x を設定します
		/// </summary>
		public static void SetAnchoredPositionX( this RectTransform self, float x )
		{
			var pos = self.anchoredPosition;
			pos.x                 = x;
			self.anchoredPosition = pos;
		}

		/// <summary>
		/// anchoredPosition.y を設定します
		/// </summary>
		public static void SetAnchoredPositionY( this RectTransform self, float y )
		{
			var pos = self.anchoredPosition;
			pos.y                 = y;
			self.anchoredPosition = pos;
		}
		
		/// <summary>
		/// pivot.x を設定します
		/// </summary>
		public static void SetPivotX( this RectTransform self, float x )
		{
			var size = self.pivot;
			size.x     = x;
			self.pivot = size;
		}
    
		/// <summary>
		/// pivot.y を設定します
		/// </summary>
		public static void SetPivotY( this RectTransform self, float y )
		{
			var size = self.pivot;
			size.y     = y;
			self.pivot = size;
		}
    
		/// <summary>
		/// pivot を設定します
		/// </summary>
		public static void SetPivot( this RectTransform self, Vector2 pivot )
		{
			self.pivot = pivot;
		}

		/// <summary>
		/// pivot を設定します
		/// </summary>
		public static void SetPivot( this RectTransform self, float x, float y )
		{
			self.pivot = new Vector2( x, y );
		}

		/// <summary>
		/// offsetMin.x を設定します
		/// </summary>
		public static void SetOffsetMinX( this RectTransform self, float x )
		{
			var offsetMin = self.offsetMin;
			offsetMin.x     = x;
			self.offsetMin = offsetMin;
		}
    
		/// <summary>
		/// offsetMin.y を設定します
		/// </summary>
		public static void SetOffsetMinY( this RectTransform self, float y )
		{
			var offsetMin = self.offsetMin;
			offsetMin.y     = y;
			self.offsetMin = offsetMin;
		}
    
		/// <summary>
		/// offsetMin を設定します
		/// </summary>
		public static void SetOffsetMin( this RectTransform self, Vector2 offsetMin )
		{
			self.offsetMin = offsetMin;
		}

		/// <summary>
		/// offsetMin を設定します
		/// </summary>
		public static void SetOffsetMin( this RectTransform self, float x, float y )
		{
			self.offsetMin = new Vector2( x, y );
		}

		/// <summary>
		/// offsetMax.x を設定します
		/// </summary>
		public static void SetOffsetMaxX( this RectTransform self, float x )
		{
			var offsetMax = self.offsetMax;
			offsetMax.x    = x;
			self.offsetMax = offsetMax;
		}
    
		/// <summary>
		/// offsetMax.y を設定します
		/// </summary>
		public static void SetOffsetMaxY( this RectTransform self, float y )
		{
			var offsetMax = self.offsetMax;
			offsetMax.y    = y;
			self.offsetMax = offsetMax;
		}
    
		/// <summary>
		/// offsetMax を設定します
		/// </summary>
		public static void SetOffsetMax( this RectTransform self, Vector2 offsetMax )
		{
			self.offsetMax = offsetMax;
		}

		/// <summary>
		/// offsetMax を設定します
		/// </summary>
		public static void SetOffsetMax( this RectTransform self, float x, float y )
		{
			self.offsetMax = new Vector2( x, y );
		}
	}
}
using UnityEngine;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	/// <summary>
	/// Graphic 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class GraphicExt
	{
		//------------------------------------------------------------------------------
		// RectTransformExt
		//------------------------------------------------------------------------------
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
		/// 幅を設定します
		/// </summary>
		public static void SetSizeX( this Graphic self, float width )
		{
			self.rectTransform.SetSizeX( width );
		}

		/// <summary>
		/// 高さを設定します
		/// </summary>
		public static void SetSizeY( this Graphic self, float height )
		{
			self.rectTransform.SetSizeY( height );
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize( this Graphic self, float width, float height )
		{
			self.rectTransform.SetSize( width, height );
		}

		/// <summary>
		/// サイズを設定します
		/// </summary>
		public static void SetSize( this Graphic self, Vector2 sizeDelta )
		{
			self.rectTransform.SetSize( sizeDelta );
		}

		/// <summary>
		/// anchoredPosition を設定します
		/// </summary>
		public static void SetAnchoredPosition( this Graphic self, Vector2 value )
		{
			self.rectTransform.SetAnchoredPosition( value );
		}
		
		/// <summary>
		/// anchoredPosition を設定します
		/// </summary>
		public static void SetAnchoredPosition( this Graphic self, float x, float y )
		{
			self.rectTransform.SetAnchoredPosition( x, y );
		}
		
		/// <summary>
		/// anchoredPosition.x を設定します
		/// </summary>
		public static void SetAnchoredPositionX( this Graphic self, float x )
		{
			self.rectTransform.SetAnchoredPositionX( x );
		}

		/// <summary>
		/// anchoredPosition.y を設定します
		/// </summary>
		public static void SetAnchoredPositionY( this Graphic self, float y )
		{
			self.rectTransform.SetAnchoredPositionY( y );
		}
		
		/// <summary>
		/// pivot.x を設定します
		/// </summary>
		public static void SetPivotX( this Graphic self, float x )
		{
			self.rectTransform.SetPivotX( x );
		}
    
		/// <summary>
		/// pivot.y を設定します
		/// </summary>
		public static void SetPivotY( this Graphic self, float y )
		{
			self.rectTransform.SetPivotY( y );
		}
    
		/// <summary>
		/// pivot を設定します
		/// </summary>
		public static void SetPivot( this Graphic self, Vector2 pivot )
		{
			self.rectTransform.SetPivot( pivot );
		}
    
		/// <summary>
		/// pivot を設定します
		/// </summary>
		public static void SetPivot( this Graphic self, float x, float y )
		{
			self.rectTransform.SetPivot( x, y );
		}
		
		/// <summary>
		/// offsetMin.x を設定します
		/// </summary>
		public static void SetOffsetMinX( this Graphic self, float x )
		{
			self.rectTransform.SetOffsetMinX( x );
		}
    
		/// <summary>
		/// offsetMin.y を設定します
		/// </summary>
		public static void SetOffsetMinY( this Graphic self, float y )
		{
			self.rectTransform.SetOffsetMinY( y );
		}
    
		/// <summary>
		/// offsetMin を設定します
		/// </summary>
		public static void SetOffsetMin( this Graphic self, Vector2 offsetMin )
		{
			self.rectTransform.SetOffsetMin( offsetMin );
		}

		/// <summary>
		/// offsetMin を設定します
		/// </summary>
		public static void SetOffsetMin( this Graphic self, float x, float y )
		{
			self.rectTransform.SetOffsetMin( x, y );
		}

		/// <summary>
		/// offsetMax.x を設定します
		/// </summary>
		public static void SetOffsetMaxX( this Graphic self, float x )
		{
			self.rectTransform.SetOffsetMaxX( x );
		}
    
		/// <summary>
		/// offsetMax.y を設定します
		/// </summary>
		public static void SetOffsetMaxY( this Graphic self, float y )
		{
			self.rectTransform.SetOffsetMaxY( y );
		}
    
		/// <summary>
		/// offsetMax を設定します
		/// </summary>
		public static void SetOffsetMax( this Graphic self, Vector2 offsetMax )
		{
			self.rectTransform.SetOffsetMax( offsetMax );
		}

		/// <summary>
		/// offsetMax を設定します
		/// </summary>
		public static void SetOffsetMax( this Graphic self, float x, float y )
		{
			self.rectTransform.SetOffsetMax( x, y );
		}

		//------------------------------------------------------------------------------
		// RectTransform
		//------------------------------------------------------------------------------
		public static Vector2 GetOffsetMax( this Graphic self )
		{
			return self.rectTransform.offsetMax;
		}

		public static Vector2 GetOffsetMin( this Graphic self )
		{
			return self.rectTransform.offsetMin;
		}
		
		public static void ForceUpdateRectTransforms( this Graphic self )
		{
			self.rectTransform.ForceUpdateRectTransforms();
		}

		public static void GetLocalCorners( this Graphic self, Vector3[] fourCornersArray )
		{
			self.rectTransform.GetLocalCorners( fourCornersArray );
		}

		public static void GetWorldCorners( this Graphic self, Vector3[] fourCornersArray )
		{
			self.rectTransform.GetWorldCorners( fourCornersArray );
		}

		//------------------------------------------------------------------------------
		// Original
		//------------------------------------------------------------------------------
		/// <summary>
		/// 透明度を設定します
		/// </summary>
		public static void SetAlpha( this Graphic self, float alpha )
		{
			var color = self.color;
			color.a    = alpha;
			self.color = color;
		}

		//------------------------------------------------------------------------------
		// ContentSizeFitter
		//------------------------------------------------------------------------------
		public static ContentSizeFitter.FitMode GetHorizontalFit( this Graphic self )
		{
			return self.GetComponent<ContentSizeFitter>().horizontalFit;
		}

		public static void SetHorizontalFit( this Graphic self, ContentSizeFitter.FitMode value )
		{
			self.GetComponent<ContentSizeFitter>().horizontalFit = value;
		}

		public static ContentSizeFitter.FitMode GetVerticalFit( this Graphic self )
		{
			return self.GetComponent<ContentSizeFitter>().verticalFit;
		}

		public static void SetVerticalFit( this Graphic self, ContentSizeFitter.FitMode value )
		{
			self.GetComponent<ContentSizeFitter>().verticalFit = value;
		}

		public static void SetLayoutHorizontal( this Graphic self )
		{
			self.GetComponent<ContentSizeFitter>().SetLayoutHorizontal();
		}

		public static void SetLayoutVertical( this Graphic self )
		{
			self.GetComponent<ContentSizeFitter>().SetLayoutVertical();
		}
	}
}
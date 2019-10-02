using UnityEngine;

namespace KoganeUnityLib
{
	public static class CameraUtils
	{
		/// <summary>
		/// ワールド座標を Screen Space - Overlay の Canvas 内のワールド座標に変換します
		/// </summary>
		/// <param name="worldCamera">ワールド座標を描画するカメラ</param>
		/// <param name="worldPosition">変換前のワールド座標</param>
		/// <returns>変換後のワールド座標</returns>
		public static Vector3 WorldToScreenSpaceOverlay
		(
			Camera  worldCamera,
			Vector3 worldPosition
		)
		{
			return RectTransformUtility.WorldToScreenPoint
			(
				cam: worldCamera,
				worldPoint: worldPosition
			);
		}

		/// <summary>
		/// ワールド座標を Screen Space - Camera の Canvas 内のローカル座標に変換します
		/// </summary>
		/// <param name="worldCamera">ワールド座標を描画するカメラ</param>
		/// <param name="canvasCamera">Canvas を描画するカメラ</param>
		/// <param name="canvasRectTransform">Canvas の RectTransform</param>
		/// <param name="worldPosition">変換前のワールド座標</param>
		/// <returns>変換後のローカル座標</returns>
		public static Vector3 WorldToScreenSpaceCamera
		(
			Camera        worldCamera,
			Camera        canvasCamera,
			RectTransform canvasRectTransform,
			Vector3       worldPosition
		)
		{
			var screenPoint = RectTransformUtility.WorldToScreenPoint
			(
				cam: worldCamera,
				worldPoint: worldPosition
			);

			RectTransformUtility.ScreenPointToLocalPointInRectangle
			(
				rect: canvasRectTransform,
				screenPoint: screenPoint,
				cam: canvasCamera,
				localPoint: out var localPoint
			);

			return localPoint;
		}
	}
}
using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// float 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class FloatExt
	{
		/// <summary>
		/// しきい値を考慮して指定した値と等しいかどうかを判断します
		/// </summary>
		public static bool SafeEquals( this float self, float obj, float threshold = 0.001f )
		{
			return Mathf.Abs( self - obj ) <= threshold;
		}

		/// <summary>
		/// 値が正常かどうかを返します
		/// </summary>
		public static bool IsValidated( this float self )
		{
			return !float.IsInfinity( self ) && !float.IsNaN( self );
		}

		/// <summary>
		/// 値が不正かどうかを確認し、値を返します
		/// </summary>
		public static float GetValueOrDefault( this float self, float defaultValue = 0 )
		{
			if ( float.IsInfinity( self ) || float.IsNaN( self ) )
			{
				return defaultValue;
			}
			return self;
		}
		
		/// <summary>
		/// 値を範囲内に制限して返します
		/// </summary>
		public static float Clamp( this float value, float min, float max )
		{
			return Mathf.Clamp( value, min, max );
		}
	}
}
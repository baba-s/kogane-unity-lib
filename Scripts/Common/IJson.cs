using UnityEngine;

namespace KoganeUnityLib
{
	public interface IJson
	{
	}

	public static class IJsonExt
	{
		public static string ToReadableJson( this IJson self )
		{
			return JsonUtility.ToJson( self, true );
		}

		public static string ToJson( this IJson self )
		{
			return JsonUtility.ToJson( self );
		}
	}
}
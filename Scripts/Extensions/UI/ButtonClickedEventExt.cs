using UnityEngine.Events;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	public static class ButtonClickedEventExt
	{
		public static void Add( this Button.ButtonClickedEvent self, UnityAction call )
		{
			self.AddListener( call );
		}

		public static void Remove( this Button.ButtonClickedEvent self, UnityAction call )
		{
			self.RemoveListener( call );
		}

		public static void Set( this Button.ButtonClickedEvent self, UnityAction call )
		{
			self.RemoveAllListeners();
			self.AddListener( call );
		}
	}
}
using UnityEngine;

namespace KoganeUnityLib
{
	public abstract class CachableMonoBehaviour : MonoBehaviour
	{
		private Transform m_transform;

		public new Transform transform
		{
			get
			{
				if ( m_transform == null )
				{
					m_transform = GetComponent<Transform>();
				}
				return m_transform;
			}
		}
	}
}
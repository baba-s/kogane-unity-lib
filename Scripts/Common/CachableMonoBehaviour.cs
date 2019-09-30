using UnityEngine;

namespace KoganeUnityLib
{
	public abstract class CachableMonoBehaviour : MonoBehaviour
	{
		private Transform     m_transform;
		private RectTransform m_rectTransform;

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

		public RectTransform rectTransform
		{
			get
			{
				if ( m_rectTransform == null )
				{
					m_rectTransform = GetComponent<RectTransform>();
				}

				return m_rectTransform;
			}
		}
	}
}
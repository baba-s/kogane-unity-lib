using UnityEngine;

namespace KoganeUnityLib
{
	public abstract class CachableMonoBehaviour : MonoBehaviour
	{
		private Transform     m_transformCache;
		private RectTransform m_rectTransformCache;

		public new Transform transform
		{
			get
			{
				if ( m_transformCache == null )
				{
					m_transformCache = GetComponent<Transform>();
				}

				return m_transformCache;
			}
		}

		public RectTransform rectTransform
		{
			get
			{
				if ( m_rectTransformCache == null )
				{
					m_rectTransformCache = GetComponent<RectTransform>();
				}

				return m_rectTransformCache;
			}
		}
	}
}
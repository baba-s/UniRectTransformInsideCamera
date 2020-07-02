using UnityEngine;

namespace Kogane
{
	public static class RectTransformInsideCamera
	{
		private static Vector3[] m_fourCornersArray;

		public static bool IsInside( RectTransform rectTransform )
		{
			var canvas = rectTransform.GetComponentInParent<Canvas>();
			var camera = canvas.worldCamera;

			return IsInside( rectTransform, camera );
		}

		public static bool IsInside( RectTransform rectTransform, Camera camera )
		{
			if ( m_fourCornersArray == null )
			{
				m_fourCornersArray = new Vector3[4];
			}

			rectTransform.GetWorldCorners( m_fourCornersArray );

			var viewportPointLT = camera.WorldToViewportPoint( m_fourCornersArray[ 1 ] ); // 左上
			var viewportPointRB = camera.WorldToViewportPoint( m_fourCornersArray[ 3 ] ); // 右下

			viewportPointLT.z = 0;
			viewportPointRB.z = 0;

			var isInside = 0 <= viewportPointRB.x && viewportPointLT.x <= 1 &&
			               0 <= viewportPointLT.y && viewportPointRB.y <= 1;

			return isInside;
		}
	}
}
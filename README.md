# UniRectTransformInsideCamera

## 使用例

```cs
using Kogane;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    private RectTransform m_rectTransform;
    private Graphic       m_graphic;
    private Camera        m_camera;

    private void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_graphic       = GetComponent<Graphic>();
        m_camera        = m_graphic.canvas.worldCamera;
    }

    private void Update()
    {
        var isInside = RectTransformInsideCamera.IsInside( m_rectTransform, m_camera );

        m_graphic.enabled = isInside;
    }
}
```

![image (41)](https://user-images.githubusercontent.com/6134875/86303602-42f0d200-bc47-11ea-8bf1-dec630fb70f8.gif)

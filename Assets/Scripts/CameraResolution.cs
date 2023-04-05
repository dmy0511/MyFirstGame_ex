using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public static Vector3 m_ScreenWMin = new Vector3(-10.0f, -5.0f, 0.0f);
    public static Vector3 m_ScreenWMax = new Vector3(10.0f, 5.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        Camera a_Cam = GetComponent<Camera>();
        Rect rect = a_Cam.rect;
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        float scaleWidth = 1.0f / scaleHeight;

        if (scaleHeight < 1.0f)
        {
            rect.height = scaleHeight;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1.0f - scaleWidth) / 2.0f;
        }

        a_Cam.rect = rect;

        Vector3 a_ScMin = new Vector3(0.0f, 0.0f, 0.0f);
        m_ScreenWMin = a_Cam.ViewportToWorldPoint(a_ScMin);

        Vector3 a_ScMax = new Vector3(1.0f, 1.0f, 1.0f);
        m_ScreenWMax = a_Cam.ViewportToWorldPoint(a_ScMax);
    }
}

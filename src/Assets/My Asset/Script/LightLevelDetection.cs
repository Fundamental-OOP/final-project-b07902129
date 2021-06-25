using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLevelDetection : MonoBehaviour
{
    public Camera lightCamera;
    public float checkInterval = 0.1f;

    private float lightLevel = 0.0f;
    private const int textureSize = 1;
    private Texture2D lightTexture2D;
    private RenderTexture tmpRenderTexture;
    private Rect rect;
    private Color m_LightPixel;

    private void Start()
    {
        StartLightDetection();
    }

    private void StartLightDetection()
    {
        lightTexture2D = new Texture2D(textureSize, textureSize, TextureFormat.RGB24, false);
        tmpRenderTexture = new RenderTexture(textureSize, textureSize, 24);
        rect = new Rect(0.0f, 0.0f, textureSize, textureSize);

        StartCoroutine(LightDetectionUpdate(checkInterval));
    }

    private IEnumerator LightDetectionUpdate(float _fUpdateTime)
    {
        while (true)
        {
            lightCamera.targetTexture = tmpRenderTexture;
            lightCamera.Render();

            RenderTexture.active = tmpRenderTexture;
            lightTexture2D.ReadPixels(rect, 0, 0);

            RenderTexture.active = null;
            lightCamera.targetTexture = null;

            m_LightPixel = lightTexture2D.GetPixel(textureSize / 2, textureSize / 2);

            lightLevel = (0.2126f * m_LightPixel.r + 0.7152f * m_LightPixel.g + 0.0722f * m_LightPixel.b);

            Debug.Log("Light Value: " + lightLevel);

            yield return new WaitForSeconds(_fUpdateTime);
        }
    }
}
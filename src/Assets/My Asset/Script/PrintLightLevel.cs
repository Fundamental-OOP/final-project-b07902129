using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintLightLevel : MonoBehaviour
{
    public RenderTexture lgihtCheckTexture;
    public float LightLevel;

    // Update is called once per frame
    void Update()
    {
        RenderTexture tmpTexture = RenderTexture.GetTemporary(lgihtCheckTexture.width, lgihtCheckTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        Graphics.Blit(lgihtCheckTexture, tmpTexture);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = tmpTexture;

        Texture2D temp2DTexture = new Texture2D(lgihtCheckTexture.width, lgihtCheckTexture.height);
        temp2DTexture.ReadPixels(new Rect(0, 0, tmpTexture.width, tmpTexture.height), 0, 0);
        temp2DTexture.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(tmpTexture);

        Color32[] colors = temp2DTexture.GetPixels32();

        LightLevel = 0;
        for (int i = 0; i < colors.Length; i++) {
            LightLevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f * colors[i].b);
        }
        Debug.Log(LightLevel);
        Destroy(temp2DTexture);
    }
}

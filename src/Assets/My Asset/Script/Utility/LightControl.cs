using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightControl {

    public static void SetRadius(Light2D light, float innerRadius, float outerRadius) {
        light.pointLightInnerRadius = innerRadius;
        light.pointLightOuterRadius = outerRadius;
    }
    public static void SetIntensity(Light2D light, float intensity) {
        light.intensity = intensity;
    }
    public static void SetColor(Light2D light, Color color) {
        light.color = color;
    }
    public static GameObject CreateNewLight(float innerRadius, float outerRadius, float intensity, Color color) {
        GameObject light = new GameObject("New Light");
        Light2D lightComponent = light.AddComponent<Light2D>();
        lightComponent.lightType = Light2D.LightType.Point;
        lightComponent.pointLightInnerRadius = innerRadius;
        lightComponent.pointLightOuterRadius = outerRadius;
        lightComponent.intensity = intensity;
        lightComponent.color = color;
        return light;
    }
}
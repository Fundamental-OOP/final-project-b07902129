using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSaverMagic : AMagicDevice {
    private const float maxSave = 1;
    private const float saveSpeed = 0.1f;
    private const float maxRadius = 5f;
    private const float minRadius = 0.05f;
    private const float radiusSpeed = 2f;
    private Light2D light2D;
    public float save;
    public bool isActive;
    public bool isUsing;

    void Awake() {
        lid = transform.Find("LightIntensityDetector").gameObject.GetComponent<LightIntensityDetector>();
        light2D = gameObject.transform.Find("Light").GetComponent<Light2D>();
        requiredLightIntensity = 0.5f;
        isActive = false;
        isUsing = false;
        save = 0.0f;
        light2D.pointLightOuterRadius = minRadius;
    }

    public override void Passive() {
        bool meet = MeetLightIntensity();
        if (meet && !isUsing) {
            FadeSave(maxSave);
            FadeLight(minRadius);
        }
        else if (save > 0 && isActive) {
            isUsing = true;
            FadeSave(0);
            FadeLight(maxRadius);
        }
        else if (light2D.pointLightOuterRadius > minRadius + .05f){
            FadeLight(minRadius);
        }
        else {
            isActive = false;
            isUsing = false;
        }
    }

    private void FadeSave(float target) {
        save = Mathf.MoveTowards(save, target, saveSpeed * Time.deltaTime);
        save = Mathf.Clamp(save, 0, maxSave);
    }

    private void FadeLight(float radius) {
        light2D.pointLightOuterRadius = Mathf.MoveTowards(light2D.pointLightOuterRadius, radius, radiusSpeed * Time.deltaTime);
        light2D.pointLightOuterRadius = Mathf.Clamp(light2D.pointLightOuterRadius, minRadius, maxRadius);
    }

    public override void SingleUse() {
        isActive = !isActive;
    }

}
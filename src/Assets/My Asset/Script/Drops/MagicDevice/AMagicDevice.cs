using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

abstract public class AMagicDevice : Drops
{
    protected float coolDown;
    protected float coolDownTimer;
    protected float requiredLightIntensity;

    public float GetCoolDown() {
        return coolDown;
    }

    public void SetCoolDown(float coolDown) {
        this.coolDown = coolDown;
    }

    public float GetRequiredLightIntensity() {
        return requiredLightIntensity;
    }
}

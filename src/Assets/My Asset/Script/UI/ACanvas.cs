using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ACanvas : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    protected float desireAlpha = 0.0f;
    protected float alphaStepPerSec = 1.0f;

    void fade() {
        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, desireAlpha, Time.deltaTime * alphaStepPerSec);
    }
}

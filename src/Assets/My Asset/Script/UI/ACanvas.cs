using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ACanvas : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected float desireAlpha = 0.0f;
    protected float alphaStepPerSec = 1.0f;

    protected void fade() {
        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, desireAlpha, Time.deltaTime * alphaStepPerSec);
    }

    public void pauseCanvas() {
        setDesireAlpha(0.0f);
        setBlockRaycasts(false);
        setInteractable(false);
    }

    public void activateCanvas() {
        setDesireAlpha(1.0f);
        setBlockRaycasts(true);
        setInteractable(true);
    }

    public void setDesireAlpha(float alpha) {
        desireAlpha = alpha;
    }

    public void setBlockRaycasts(bool raycasts) {
        canvasGroup.blocksRaycasts = raycasts;
    }

    public void setInteractable(bool interactable) {
        canvasGroup.interactable = interactable;
    }
}

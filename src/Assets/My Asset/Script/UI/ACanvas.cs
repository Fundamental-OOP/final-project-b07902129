using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ACanvas : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected float desireAlpha = 0.0f;
    protected float alphaStepPerSec = 1.0f;

    protected void Fade() {
        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, desireAlpha, Time.fixedDeltaTime * alphaStepPerSec);
    }

    public void PauseCanvas() {
        SetDesireAlpha(0.0f);
        SetBlockRaycasts(false);
        SetInteractable(false);
    }

    public virtual void ActivateCanvas() {
        SetDesireAlpha(1.0f);
        SetBlockRaycasts(true);
        SetInteractable(true);
    }

    public void SetDesireAlpha(float alpha) {
        desireAlpha = alpha;
    }

    public void SetBlockRaycasts(bool raycasts) {
        canvasGroup.blocksRaycasts = raycasts;
    }

    public void SetInteractable(bool interactable) {
        canvasGroup.interactable = interactable;
    }
}

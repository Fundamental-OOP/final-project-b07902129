using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : ACanvas
{
    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0.0f;
    }

    void Update() {
        fade();
    }
}

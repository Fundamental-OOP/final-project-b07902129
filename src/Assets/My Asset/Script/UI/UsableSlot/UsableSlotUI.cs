using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableSlotUI : ACanvas
{
    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        PauseCanvas();
    }

    void Update() {
        Fade();
    }
}

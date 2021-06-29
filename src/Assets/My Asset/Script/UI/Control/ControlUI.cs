using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : ACanvas
{
    public AButton pauseButton;
    public AButton backpackButton;

    public ACanvas backpackUI;
    public ACanvas pauseUI;
    public ACanvas usableSlotUI;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        ActivateCanvas();
    }

    void Update() {
        CheckBackpack();
        CheckPause();
        Fade();
    }

    private void CheckPause() {
        if (pauseButton.IsPressed()) {
            PauseCanvas();
            usableSlotUI.PauseCanvas();
            pauseUI.ActivateCanvas();
        }
    }

    private void CheckBackpack() {
        if (backpackButton.IsPressed()) {
            PauseCanvas();
            backpackUI.ActivateCanvas();
        }
    }
}

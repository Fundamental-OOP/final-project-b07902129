using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : ACanvas
{
    public AButton pauseButton;
    public AButton backpackButton;

    public ACanvas controlUI;
    public ACanvas pauseUI;
    public ACanvas usableSlotUI;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        PauseCanvas();
    }

    void Update() {
        Fade();
        CheckPause();
        CheckBackpack();
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
            controlUI.ActivateCanvas();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : ACanvas
{
    private AButton pauseButton;
    private AButton backpackButton;

    public Canvas backpackUI;
    public Canvas pauseUI;

    private ACanvas backpackACanvas;
    private ACanvas pauseACanvas;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        setInteractable(true);
        setDesireAlpha(1.0f);
        pauseButton = gameObject.transform.Find("pause").gameObject.GetComponent<AButton>();
        backpackButton = gameObject.transform.Find("backpack").gameObject.GetComponent<AButton>();
        pauseACanvas = pauseUI.GetComponent<ACanvas>();
        backpackACanvas = backpackUI.GetComponent<ACanvas>();
    }

    void Update() {
        checkBackpack();
        checkPause();
        fade();
    }

    private void checkPause() {
        if (pauseButton.isPressed()) {
            pauseCanvas();
            pauseACanvas.activateCanvas();
        }
    }

    private void checkBackpack() {
        if (backpackButton.isPressed()) {
            pauseCanvas();
            backpackACanvas.activateCanvas();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : ACanvas
{
    public AButton restart;
    public List<ACanvas> canvases;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        PauseCanvas();
    }

    void Update() {
        Fade();
        if (restart.IsPressed()) {
            restartGame();
        }
    }
    public void OpenDeathMenu() {
        for (int i = 0; i < canvases.Count; i++) {
            canvases[i].PauseCanvas();
        }
        ActivateCanvas();
    }

    void restartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }
}

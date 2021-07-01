using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : ACanvas
{
    public AButton restart;
    public MainCharacter mainCharacter;
    public List<ACanvas> canvases;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        PauseCanvas();
    }

    void Update() {
        Fade();
        HandleDeath();
        if (restart.IsPressed()) {
            restartGame();
        }
    }
    void HandleDeath() {
        if (mainCharacter.health <= 0) {
            for (int i = 0; i < canvases.Count; i++) {
                canvases[i].PauseCanvas();
            }
            ActivateCanvas();
        }
    }

    void restartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }
}

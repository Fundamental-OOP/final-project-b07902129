using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : ACanvas
{
    public AButton resume;
    public ACanvas controlUI;
    public ACanvas usableSlotUI;

    void Awake()
    {
        PauseGame();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0.0f;
    }

    void Update()
    {
        Fade();
        if (resume.IsPressed())
        {
            controlUI.ActivateCanvas();
            usableSlotUI.ActivateCanvas();
            StartGame();
            PauseCanvas();
        }
    }
    public override void ActivateCanvas()
    {
        PauseGame();
        SetDesireAlpha(1.0f);
        SetBlockRaycasts(true);
        SetInteractable(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    private void StartGame()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Time.timeScale = 1.0f;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

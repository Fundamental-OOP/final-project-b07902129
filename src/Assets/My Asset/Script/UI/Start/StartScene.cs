using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : ACanvas
{
    public AButton start;
    public ACanvas controlUI;
    public ACanvas usableSlotUI;

    void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        ActivateCanvas();
    }

    void Update()
    {
        Fade();
        if (start.IsPressed())
        {
            controlUI.ActivateCanvas();
            usableSlotUI.ActivateCanvas();
            PauseCanvas();
        }
        else {
            Debug.Log("Not pressed");
        }
    }
}

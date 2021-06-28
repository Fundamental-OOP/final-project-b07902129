using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : ACanvas
{
    // Start is called before the first frame update
    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0.0f;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fade();
    }
}

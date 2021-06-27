using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : ACanvas
{
    void Awake() {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : ACanvas
{
    public GameObject character;
    private GameObject left;
    private GameObject right;

    void Awake() {
        left = gameObject.transform.Find("left").gameObject;
        right = gameObject.transform.Find("right").gameObject;
    }

    void Update() {
        UpdateCharacterMovement();
    }

    void UpdateCharacterMovement() {

    }
}

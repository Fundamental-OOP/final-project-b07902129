using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : AButton
{
    public override void OnPointerDown(PointerEventData data) {
        Debug.Log("down");
        pressed = true;
    }
    public override void OnPointerUp(PointerEventData data) {
        Debug.Log("up");
        pressed = false;
    }
    public override void onClick() {}
}

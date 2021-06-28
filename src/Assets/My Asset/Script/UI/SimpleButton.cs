using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleButton : AButton
{
    public override void OnPointerDown(PointerEventData data) {
        pressed = true;
    }
    public override void OnPointerUp(PointerEventData data) {
        pressed = false;
    }
    public override void onClick() {}
}

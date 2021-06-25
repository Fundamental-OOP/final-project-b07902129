using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

abstract public class AButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected bool pressed = false;
    public abstract void onClick();
    public abstract void OnPointerDown(PointerEventData data);
    public abstract void OnPointerUp(PointerEventData data);
    public bool isPressed() { return pressed; }
}

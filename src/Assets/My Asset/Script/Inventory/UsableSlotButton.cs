using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlotButton : AButton
{
    AButton button;
    Slot slot;

    void Awake() {
        button = gameObject.GetComponent<AButton>();
        slot = gameObject.GetComponent<Slot>();
    }

    void Update() {
        if (IsPressed()) {
            HoldUse();
        }
    }

    public override void onClick() {}
    public override void OnPointerDown(PointerEventData data) {
        SingleUse();
    }
    public override void OnPointerUp(PointerEventData data) {}

    void SingleUse()
    {
        if (!slot.IsEmpty()) {
            slot.GetDrops().SingleUse();
        }
        else if (slot.IsEmpty()) {
            Debug.Log("UseSlot empty");
        }
        else {
            Debug.Log("UseSlot item count wrong!");
        }
    }

    void HoldUse() {
        if (!slot.IsEmpty()) {
            slot.GetDrops().HoldUse();
        }
        else if (slot.IsEmpty()) {
            Debug.Log("UseSlot empty");
        }
        else {
            Debug.Log("UseSlot item count wrong!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlotButton : AButton
{
    public LightIntensityDetector lightIntensityDetector;
    AButton button;
    Slot slot;

    void Awake() {
        button = gameObject.GetComponent<AButton>();
        slot = gameObject.GetComponent<Slot>();
    }

    void Update() {
        if (slot.IsEmpty()) return;

        if (IsMagicDevice() && !passLightIntensity()) return;

        slot.GetDrops().Passive();
        if (IsPressed())
            HoldUse();
    }

    void FixedUpdate() {
        if (slot.IsEmpty()) return;
        if (IsMagicDevice())
            lightIntensityDetector.transform.position = slot.GetItem().transform.position;
    }

    public override void onClick() {}
    public override void OnPointerDown(PointerEventData data) {
        if (IsMagicDevice() && !passLightIntensity()) return;
        SingleUse();
    }

    protected bool IsMagicDevice() {
        return slot.GetItem().tag == "MagicDevice" ? true : false;
    }

    protected bool passLightIntensity() {
        float required = slot.GetItem().GetComponent<AMagicDevice>().GetRequiredLightIntensity();
        float detected = lightIntensityDetector.DetectLightIntensity();
        Debug.Log(string.Format("Required: {0}, Detected: {1}", required, detected));
        if (detected < required)
            return false;
        return true;
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

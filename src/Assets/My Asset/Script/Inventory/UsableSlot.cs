using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlot : AButton
{
    AButton button;

    void Awake() {
        button = gameObject.GetComponent<AButton>();
    }

    public override void onClick() {}
    public override void OnPointerDown(PointerEventData data) {
        Use();
    }
    public override void OnPointerUp(PointerEventData data) {}

    void Use()
    {
        if(gameObject.transform.childCount == 1)
        {
            GameObject item = gameObject.transform.GetChild(0).gameObject;
            item.GetComponent<Drops>().Use();
        }
        else if (gameObject.transform.childCount == 0)
        {
            Debug.Log("UseSlot empty");
        }
        else
        {
            Debug.Log("UseSlot item count wrong!");
        }
    }
}

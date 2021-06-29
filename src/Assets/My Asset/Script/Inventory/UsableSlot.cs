using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlot : Slot
{
    // drops onEquipped initialization
    protected override void OnDropCallBack() {
        Debug.Log("OnDropCallback");
        GetDrops().OnEquipped();
        GetItem().SetActive(true);
    }

    // passive ability
    void Update() {
        if (!IsEmpty())
            GetDrops().Passive();
    }
}

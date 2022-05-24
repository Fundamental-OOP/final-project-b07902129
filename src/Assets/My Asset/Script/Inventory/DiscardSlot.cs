using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardSlot : Slot
{
    // drops onEquipped initialization
    protected override void OnDropCallBack() {
        DestroyItem();
    }
}

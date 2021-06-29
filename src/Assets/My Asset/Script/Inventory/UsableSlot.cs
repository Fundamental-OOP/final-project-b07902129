using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlot : Slot
{
    public Vector3 objectOffsetFromCharacter;

    // drops onEquipped initialization
    protected override void OnDropCallBack() {
        drop.OnEquipped();
        item.SetActive(true);
        OverrideFollowerOffset();
    }

    public override void SetItem(GameObject item)
    {
        item.SetActive(true);
        draggable.enabled = true;
        this.item = item;
        drop = item.GetComponent<Drops>();
        SetSprite(drop.sprite);
        OverrideFollowerOffset();
    }

    private void OverrideFollowerOffset() {
        ObjectFollower of = item.GetComponent<ObjectFollower>();
        if (of != null && of.GetTarget().tag == "MainCharacter")
            of.SetOffset(objectOffsetFromCharacter);
    }
}

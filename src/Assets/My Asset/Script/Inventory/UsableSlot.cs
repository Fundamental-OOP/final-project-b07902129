using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlot : Slot
{
    public LightIntensityDetector lightIntensityDetector;
    public Vector3 objectOffsetFromCharacter;

    // drops onEquipped initialization
    protected override void OnDropCallBack() {
        drop.OnEquipped();
        if(item.GetComponent<ObjectFollower>() != null)
        {
            item.SetActive(true);
        }
        
        OverrideFollowerOffset();
    }

    public override void SetItem(GameObject item)
    {
        if(item == null)
        {
            return;
        }
        if (item.GetComponent<ObjectFollower>() != null)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
       
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

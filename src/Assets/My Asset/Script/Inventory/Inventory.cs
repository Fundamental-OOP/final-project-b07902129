using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> SlotList;
    public List<Slot> HandSlotList;
    void Start()
    {
        AddItem(GameObject.Find("LightSaver"));
        AddItem(GameObject.Find("BulletMagic"));
        AddItem(GameObject.Find("Defense_Circle"));
    }

    void Update()
    {

    }

    public bool AddItem(GameObject item)
    {
        for (int i = 0; i < HandSlotList.Count; i++)
        {
            if (HandSlotList[i].IsEmpty())
            {
                HandSlotList[i].SetItem(item);
                return true;
            }
        }

        for (int i = 0; i <  SlotList.Count;i++)
        {
            if(SlotList[i].IsEmpty())
            {
                SlotList[i].SetItem(item);
                
                return true;
            }
        }

        Debug.Log("inventory full");
        return false;
    }

    public bool InHand(string tag)
    {
        foreach(Slot s in  HandSlotList){
            if(s.GetItem() !=null && s.GetItem().tag.Equals(tag))
            {
                Debug.Log("Inhand" + s.GetItem().tag + tag);
                return true;
            }
        }
        return false;
    }

    void RemoveItem(int index)
    {
        SlotList[index].SetItemEmpty();
    }


    public List<Slot> GetItemList()
    {
        return SlotList;
    }
}

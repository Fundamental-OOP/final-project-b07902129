using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> SlotList;
    public List<Slot> HandSlotList;
    void Start()
    {
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
                item.SetActive(false);
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

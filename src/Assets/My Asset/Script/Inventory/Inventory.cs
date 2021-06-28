using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Slot> SlotList;

    //public int capacity = 15;
    void Start()
    {
        AddItem(GameObject.Find("BulletMagic"));
        AddItem(GameObject.Find("BulletMagic1"));
        AddItem(GameObject.Find("BulletMagic2"));
        AddItem(GameObject.Find("BulletMagic3"));
        /*ItemList = new List<Drops>();
        for(int i = 0; i < capacity; i++)
        {
            ItemList.Add(null);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool AddItem(GameObject item)
    {
        for(int i = 0; i < SlotList.Count; i++)
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

    void RemoveItem(int index)
    {
        SlotList[index].SetItemEmpty();
    }

    /*void RemoveItem(Drops Item)
    {
        ItemList.Remove(Item);
    }*/

    public List<Slot> GetItemList()
    {
        return SlotList;
    }
}

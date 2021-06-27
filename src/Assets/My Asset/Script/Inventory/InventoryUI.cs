using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory;
    public List<Slot> slots;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateInventory();
    }


    void UpdateInventory()
    {
        /*List<Slot> itemList = inventory.GetItemList();
        for(int i = 0; i < itemList.Count;i++)
        {
            if(itemList[i] != null)
            {
                slots[i].SetItem(itemList[i]);
            }
            else
            {
                slots[i].SetItemEmpty();
            }
            
        }*/
    }
}

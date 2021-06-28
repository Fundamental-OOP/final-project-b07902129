using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    Image image;
    GameObject item;
    GameObject slotObject; 
    void Awake()
    {
        item = null;
        gameObject.GetComponent<Draggable>().enabled = false;
    } 

    public void SetSprite(Sprite sprite)
    {
        gameObject.GetComponent<Image>().sprite = sprite;
    }
    public void SetItem(GameObject item)
    {
        item.transform.SetParent(gameObject.transform); 
        gameObject.GetComponent<Draggable>().enabled = true;
        this.item = item;
        SetSprite(item.GetComponent<Drops>().sprite);
    }
    public void SetItemEmpty()
    {
        item = null;
        SetSprite(null);
        gameObject.GetComponent<Draggable>().enabled = false;
        //slotObject.SetActive(false);
    }

    public bool IsEmpty()
    {
        return item == null ? true : false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop" + gameObject.name);
        if (eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag == gameObject)
            {
                Debug.Log("Drop to self");
                return;
            }
            if(eventData.pointerDrag.GetComponent<Slot>() == null)
            {
                Debug.Log("not correct source");
                return;
            }
            Debug.Log(eventData.pointerDrag.name);
            GameObject sourceSlot = eventData.pointerDrag;
            if (sourceSlot.transform.childCount == 1)
            {
                GameObject draggedItem = sourceSlot.transform.GetChild(0).gameObject;
                if (draggedItem != null)
                {
                    // swap two slots' content
                    
                    eventData.pointerDrag.GetComponent<Draggable>().SetCorrectDrop(this.item);
                    SetItem(draggedItem);
                }
            }
            else
            {
                Debug.Log("OnDrop dragged item count wrong");
            }
          
        }
    }
}

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
    Color transparent;
    Color nonTransparent;
    void Awake()
    {
        item = null;
        gameObject.GetComponent<Draggable>().enabled = false;
        image = gameObject.GetComponent<Image>();
        transparent = new Color(1f, 1f, 1f, 0f);
        nonTransparent = new Color(1f, 1f, 1f, 1f);
        SetImageColor();
    }

    private void SetImageColor() {
        if (image.sprite == null)
            image.color = transparent;
        else
            image.color = nonTransparent;
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
        SetImageColor();
    }
    public void SetItem(GameObject item)
    {
        item.transform.SetParent(gameObject.transform);
        gameObject.GetComponent<Draggable>().enabled = true;
        item.SetActive(false); // enter inventory disActives Object
        this.item = item;
        SetSprite(item.GetComponent<Drops>().sprite);
    }

    public GameObject GetItem()
    {
        return item;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    protected Image image;
    protected GameObject item;
    protected Drops drop;
    protected Color transparent;
    protected Color nonTransparent;
    protected Draggable draggable;
    void Awake()
    {
        item = null;
        draggable = GetComponent<Draggable>();
        draggable.enabled = false;
        image = gameObject.GetComponent<Image>();
        transparent = new Color(1f, 1f, 1f, 0f);
        nonTransparent = new Color(1f, 1f, 1f, 1f);
        SetImageColor();
    }

    protected void SetImageColor() {
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
        // item.transform.SetParent(gameObject.transform);
        draggable.enabled = true;
        this.item = item;
        drop = item.GetComponent<Drops>();
        SetSprite(drop.sprite);
    }
    public void SetItemEmpty()
    {
        item = null;
        SetSprite(null);
        draggable.enabled = false;
    }

    public void DestroyItem() {
        Destroy(item);
        SetItemEmpty();
    }

    public bool IsEmpty()
    {
        return item == null ? true : false;
    }

    public GameObject GetItem() {
        return item;
    }

    public Drops GetDrops() {
        return drop;
    }

    public Draggable GetDraggable() {
        return draggable;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("OnDrop" + gameObject.name);
        if (eventData.pointerDrag == null) return;


        if (eventData.pointerDrag == gameObject) {
            // Debug.Log("Drop to self");
            return;
        }

        Slot sourceSlot = eventData.pointerDrag.GetComponent<Slot>();
        if (sourceSlot == null) {
            // Debug.Log("not correct source");
            return;
        }

        // Debug.Log(eventData.pointerDrag.name);
        if (!sourceSlot.IsEmpty()) {
            // swap two slots' content
            sourceSlot.GetDraggable().SetCorrectDrop(this.item);
            SetItem(sourceSlot.GetItem());
            item.SetActive(false);
        }

        OnDropCallBack();
    }
    protected virtual void OnDropCallBack() {}
}

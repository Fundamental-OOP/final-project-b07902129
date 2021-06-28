using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;

    private RectTransform rectTransform;
    private Vector2 originAnchoredPosition;

    bool correctDrop = false;
    GameObject swapItem;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GameObject.Find("BackpackUI").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        originAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        originAnchoredPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = originAnchoredPosition;
        if (correctDrop == true)
        {
            if (swapItem != null)
            {
                this.gameObject.GetComponent<Slot>().SetItem(swapItem);
            }
            else
            {
                this.gameObject.GetComponent<Slot>().SetItemEmpty();
            }
        }
        
        correctDrop = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void SetCorrectDrop(GameObject item) {
        swapItem = item;
        correctDrop = true;
    }

    

}

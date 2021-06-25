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

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        originAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        if (correctDrop == false)
            rectTransform.anchoredPosition = originAnchoredPosition;
        else
            originAnchoredPosition = rectTransform.anchoredPosition;
        correctDrop = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void SetCorrectDrop(bool status) {
        correctDrop = status;
    }

}

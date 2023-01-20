using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {


    public static bool InSlot = false;
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject self;
    public static bool canCheck;

    public void Check()
    {
        if (!InSlot && canCheck)
        {
            self.GetComponent<Letters>().setPositon();
        }
    }
        

    private void Awake() { 
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        InSlot = false;

    }
    void SetPositoin()
    {
        self.GetComponent<Letters>().setPositon();
        
    }
    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
        //SetPositoin();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}

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
        List<GameObject> slots = GameManager.Slots;
        Debug.Log("--------->" + slots);
        foreach (GameObject slot in slots)
        {
            Debug.Log(slot);
            InSlot = true;  
            if (slot.GetComponent<ItemSlot>().isFilled)
            {
                if (eventData.pointerDrag.transform.position == slot.transform.position)
                {
                    //GameObject baseletter = slot.GetComponent<ItemSlot>().baseLetter;
                    Debug.Log("0");
                    //baseletter.GetComponent<Letters>().setPositon();
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
                    slot.GetComponent<ItemSlot>().isFilled = true;
                }
                else if (!slot.GetComponent<ItemSlot>().isFilled){
                    SetPositoin();
                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}

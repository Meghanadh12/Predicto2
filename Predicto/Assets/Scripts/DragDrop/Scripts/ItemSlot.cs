using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject self;
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public static bool isFilled = false;
    public GameObject baseLetter;
    public GameObject b;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            DragDrop.canCheck = false;
            eventData.pointerDrag.GetComponent<Letters>().FillObjectList();
            baseLetter = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = self.GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(self.GetComponent<RectTransform>().anchoredPosition);
            DragDrop.canCheck = true;
            isFilled = true;
            DragDrop.InSlot = true;
            Letters.a = false;
        }
    }

    public void ChangePosition()
    {
        baseLetter.GetComponent<Letters>().setPositon();
      
    }

} 


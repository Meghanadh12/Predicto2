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
    public bool isFilled = false;
    public GameObject baseLetter;
    public GameObject b;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            
            if (isFilled && baseLetter != null)
            {
                baseLetter.GetComponent<Letters>().setPositon();
                isFilled = false;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = self.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<Letters>().FillObjectList();
            baseLetter = eventData.pointerDrag;

            Debug.Log(self.GetComponent<RectTransform>().anchoredPosition);
        }
    }
}


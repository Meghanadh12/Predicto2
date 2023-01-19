using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    public string Letter1;
    public string Letter2;
    public string Letter3;
    public string Letter4;
    public static GameObject letterobject1;
    public static GameObject letterobject2;
    public static GameObject letterobject3;
    public static GameObject letterobject4;
    public static GameObject dummy1;
    public static GameObject dummy2;
    public static GameObject dummy3;
    public static GameObject dummy4;
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public static List<string> word = new List<string>();
    public static List<GameObject> wordObjects = new List<GameObject>();
    public GameObject self;
    public string letter;
    public Text letterTxt;
    static public bool a = true;
    Vector3 InitialPosition;
    public GameObject gamemanager2;
    public static bool needTofill = false; 


    void Awake()
    {
        InitialPosition = self.transform.position;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        letterTxt.text = letter;
        FillList();
        FillObjectList();   
    }

    public void FillObjectList()
    {
        wordObjects.Add(dummy1);
        wordObjects.Add(dummy2);
        wordObjects.Add(dummy3);
        wordObjects.Add(dummy4);
    }
    public void FillList()
    {
        Debug.Log("Filled");
        word.Add("");
        word.Add("");
        word.Add("");
        word.Add("");
    }
    // Update is called once per frame
    void Update()
    {

            if (self.transform.position == Slot1.transform.position)
            {
                letterobject1 = self;
                wordObjects[0] = (letterobject1);
                //Singleton.Instance.word[0] = Letter1;

            }
            else if (self.transform.position == Slot2.transform.position)
            {
                letterobject2 = self;
                wordObjects[1] = (letterobject2);
                //Singleton.Instance.word[1] = Letter2;

            }

            else if (self.transform.position == Slot3.transform.position)
            {
                letterobject3 = self;
                wordObjects[2] = (letterobject3);
                //Singleton.Instance.word[2] = Letter3;

            }

            else if (self.transform.position == Slot4.transform.position)
            {
                letterobject4 = self;
                wordObjects[3] = (letterobject4);
                //Singleton.Instance.word[3] = Letter4;

            }
            
            needTofill = false;
        foreach (GameObject slot in GameManager.Slots)
        {
            if (self.transform.position == slot.transform.position)
            {
                GameObject baseletter  = slot.GetComponent<ItemSlot>().baseLetter;
                if (baseletter != null)
                {
                    baseletter.GetComponent<Letters>().setPositon();
                    
                }
            }
        }
        
        
             
    }

    public void setPositon()
    {
        self.transform.position = InitialPosition;
        Debug.Log("SetPosition");
    }

    public void OnDisable()
    {
        foreach (string letter in word)
        {
            Debug.Log(letter);
        }
    }
}

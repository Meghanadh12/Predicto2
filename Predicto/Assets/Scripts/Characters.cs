using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public string character = "";
    public Text text;
    public static bool setActive = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = character;
        if (setActive)
        {
            gameObject.SetActive(true);
        }   
    }

    public void ChangeColor(int colornum)
    {
        if (colornum == 0)
        {
            gameObject.GetComponent<Image>().color = Color.grey;
        }
        else if (colornum == 1)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else if (colornum == 2)
        {
            gameObject.GetComponent<Image>().color = Color.yellow;
        }
    }
}

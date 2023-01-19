using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int index;
    public string Word;
    int indexyellow;
    public List<GameObject> shuflleList;
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    string chartoword;
    public List<string> wordList;
    public GameObject letter;
    GameObject yellowletter;    
    public List<GameObject> image1;
    public List<GameObject> image2;     
    public List<GameObject> image3;
    public List<GameObject> image4;
    public List<GameObject> image5;
    public List<GameObject> image6;
    public int listIndex;
    public List<string> guessedWord;
    public List<List<GameObject>> ListOfLists = new List<List<GameObject>>();
    public static List<GameObject> Slots = new List<GameObject>();

    private void Awake()
    {
        Slots.Add(Slot1);
        Slots.Add(Slot2);
        Slots.Add(Slot3);
        Slots.Add(Slot4);
    }

    void FillWithEmpty()
    {
        guessedWord.Add("");
        guessedWord.Add("");
        guessedWord.Add("");
        guessedWord.Add("");
    }
    void Start()
    {
        ListOfLists.Add(image1);
        ListOfLists.Add(image2);
        ListOfLists.Add(image3);
        ListOfLists.Add(image4);
        ListOfLists.Add(image5);
        ListOfLists.Add(image6);

        wordList.Clear();
        Debug.Log("Start");
        foreach (char letter in Word)
        {
            
            chartoword = letter.ToString();
            wordList.Add(chartoword);
            Debug.Log(letter);
           
        }

        
    }
    public void Clear()
    {
        foreach(GameObject letterInslot in Letters.wordObjects)
        {
            Letters.word.Clear();
            letter.GetComponent<Letters>().FillList();
            letterInslot.GetComponent<Letters>().setPositon();
        }

    }

    private void Guessingword()
    {
        guessedWord[0] = Letters.wordObjects[0].GetComponent<Letters>().letter;
        guessedWord[1] = Letters.wordObjects[1].GetComponent<Letters>().letter;
        guessedWord[2] = Letters.wordObjects[2].GetComponent<Letters>().letter;
        guessedWord[3] = Letters.wordObjects[3].GetComponent<Letters>().letter;
    }

    public void Shuflle()
    {
            
            int a = Random.Range(0, wordList.Count);
            int b = Random.Range(0, wordList.Count);
            while (b == a)
            {
                b = Random.Range(0, wordList.Count);
            }
            
            GameObject temp = Slots[0];
            int randomIndex = Random.Range(0, Slots.Count);
            Letters.wordObjects[a].transform.position = Slots[b].transform.position;
            Letters.wordObjects[b].transform.position = Slots[a].transform.position;
            
        Letters.needTofill = true;  
    }               
    public void Submit()            
    {
        Guessingword();
        if (Letters.wordObjects[0].GetComponent<Letters>().letter != "" && Letters.wordObjects[1].GetComponent<Letters>().letter != "" && Letters.wordObjects[2].GetComponent<Letters>().letter != "" && Letters.wordObjects[3].GetComponent<Letters>().letter != "")
        {
            List<GameObject> a = ListOfLists[listIndex];
            index = 0;
            if (Letters.wordObjects[0].GetComponent<Letters>().letter == wordList[0] && Letters.wordObjects[1].GetComponent<Letters>().letter == wordList[1] && Letters.wordObjects[2].GetComponent<Letters>().letter == wordList[2] && Letters.wordObjects[3].GetComponent<Letters>().letter == wordList[3])
            {
                index = 0;
                foreach (GameObject letterimage in ListOfLists[listIndex])
                {
                    letterimage.SetActive(true);
                    letterimage.GetComponent<Characters>().character = Letters.wordObjects[index].GetComponent<Letters>().letter;
                    letterimage.GetComponent<Characters>().ChangeColor(1);
                    index++;

                }
                Word = "EACH";
                listIndex++;
                Debug.Log("Correct");
            }
            else
            {
                index = 0;
                Debug.Log("Wrong");
                foreach (GameObject letterimage in ListOfLists[listIndex])
                {
                    letterimage.SetActive(true);
                    letterimage.GetComponent<Characters>().character = Letters.wordObjects[index].GetComponent<Letters>().letter;
                    index = index + 1;
                }
                listIndex++;
                foreach (string letters in guessedWord)
                {
                    int position = guessedWord.IndexOf(letters);
                    int indexColor = position;
                    if (letters != wordList[indexColor] && wordList.Contains(letters))
                    {

                        yellowletter = a[indexColor];
                        yellowletter.GetComponent<Characters>().ChangeColor(2);
                    }
                    if (letters == wordList[position])
                    {
                        GameObject greenletter = a[position];
                        greenletter.GetComponent<Characters>().ChangeColor(1);
                    }

                }

            }

            a.Clear();

            guessedWord.Clear();
            FillWithEmpty();
        }
    }
}

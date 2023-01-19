using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public List<string> word = new List<string>();

    public void Start()
    {
        word.Add("");
        word.Add("");
        word.Add("");
        word.Add("");
    }
}

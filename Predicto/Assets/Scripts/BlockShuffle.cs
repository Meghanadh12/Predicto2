using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShuffle : MonoBehaviour
{
    public List<GameObject> blocks; // the list of blocks to shuffle
    public Transform[] itemSlots; // the four item slots to move the blocks to

    void Start()
    {
        // shuffle the list of blocks
        Shuffle(blocks);

        // move the blocks to the item slots in the shuffled order
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].transform.position = itemSlots[i].position;
        }
    }

    // Fisher-Yates shuffle algorithm
    void Shuffle(List<GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
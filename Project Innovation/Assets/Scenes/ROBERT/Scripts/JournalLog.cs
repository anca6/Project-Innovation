using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class JournalLog : MonoBehaviour
{

    [SerializeField] private List<GameObject> items = new List<GameObject>(); //setup array list
    private int currentItem = 0; //bool to keep track of the current item

    private void Update()
    {
        ActivateLog();
        CheckCurrentLog();
    }

    private void ActivateLog()
    { //takes control of activating items
        for (int i = 0; i < items.Count; i++)
        {
            if (i == currentItem)
            {
                items[i].SetActive(true);
            }
            else
            {
                items[i].SetActive(false);
            }
        }
    }

    private void CheckCurrentLog()
    { //make sure current item doesn't exceed the list
        if (currentItem < 0)
        {
            currentItem = items.Count - 1;
        }
        if (currentItem > items.Count - 1)
        {
            currentItem = 0;
        }
    }

    public void SelectPreviousItem()
    {
        currentItem--;
    }

    // Public method to select the next item
    public void SelectNextItem()
    {
        currentItem++;
    }

}
using System.Collections.Generic;
using UnityEngine;

public class JournalLog : MonoBehaviour
{
    public static JournalLog Instance { get; private set; }

    [SerializeField] private List<GameObject> items = new List<GameObject>();
    private int currentItem = 0;
    private List<int> unlockedEntries = new List<int>();

    private void Update()
    {
        ActivateLog();
        CheckCurrentLog();
    }

    private void ActivateLog()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (unlockedEntries.Contains(i))
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
    {
        if (currentItem < 0)
        {
            currentItem = unlockedEntries.Count - 1;
        }
        if (currentItem >= unlockedEntries.Count)
        {
            currentItem = 0;
        }
    }

    public void SelectPreviousItem()
    {
        if (unlockedEntries.Count > 1)
        {
            currentItem--;
        }
    }

    public void SelectNextItem()
    {
        if (unlockedEntries.Count > 1)
        {
            currentItem++;
        }
    }

    public void UnlockEntry(int entryIndex)
    {
        if (!unlockedEntries.Contains(entryIndex))
        {
            unlockedEntries.Add(entryIndex);
            unlockedEntries.Sort(); // Ensure the list is sorted
        }
    }
}

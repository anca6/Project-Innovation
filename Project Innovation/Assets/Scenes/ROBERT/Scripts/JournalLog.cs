using System.Collections.Generic;
using UnityEngine;

public class JournalLog : MonoBehaviour
{
    public static JournalLog Instance { get; private set; }

    [SerializeField] private List<JournalEntry> journalEntries = new List<JournalEntry>();
    private int currentItemIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        ActivateLog();
        CheckCurrentLog();
    }

    private void ActivateLog()
    {
        int activeIndex = -1;
        for (int i = 0; i < journalEntries.Count; i++)
        {
            if (journalEntries[i].IsUnlocked)
            {
                if (currentItemIndex == i)
                {
                    activeIndex = i;
                    break;
                }
                else if (activeIndex == -1)
                {
                    activeIndex = i;
                }
            }
        }

        if (activeIndex != -1)
        {
            for (int i = 0; i < journalEntries.Count; i++)
            {
                journalEntries[i].GameObject.SetActive(i == activeIndex);
            }
        }
    }

 /*   private int FindNextUnlockedEntry(int startIndex)
    {
        int nextIndex = startIndex;
        do
        {
            nextIndex = (nextIndex + 1) % journalEntries.Count;
        } while (!journalEntries[nextIndex].IsUnlocked && nextIndex != startIndex);

        return nextIndex;
    }*/

    public void NavigateToNextUnlockedEntry()
    {
        int nextIndex = currentItemIndex + 1;
        while (nextIndex < journalEntries.Count && !journalEntries[nextIndex].IsUnlocked)
        {
            nextIndex++;
        }
        if (nextIndex < journalEntries.Count)
        {
            currentItemIndex = nextIndex;
            ActivateLog();
        }
    }

    public void NavigateToPreviousUnlockedEntry()
    {
        int prevIndex = currentItemIndex - 1;
        while (prevIndex >= 0 && !journalEntries[prevIndex].IsUnlocked)
        {
            prevIndex--;
        }
        if (prevIndex >= 0)
        {
            currentItemIndex = prevIndex;
            ActivateLog();
        }
    }

    private void CheckCurrentLog()
    {
        if (currentItemIndex < 0)
        {
            currentItemIndex = journalEntries.Count - 1;
        }
        if (currentItemIndex >= journalEntries.Count)
        {
            currentItemIndex = 0;
        }
    }

    public void SelectPreviousItem()
    {
        currentItemIndex--;
    }

    public void SelectNextItem()
    {
        currentItemIndex++;
    }
    public void UnlockEntry(int entryIndex)
    {
        if (entryIndex >= 0 && entryIndex < journalEntries.Count)
        {
            journalEntries[entryIndex].IsUnlocked = true;
            currentItemIndex = entryIndex;
        }
    }

}

[System.Serializable]
public class JournalEntry
{
    public GameObject GameObject;
    public bool IsUnlocked;

    public JournalEntry(GameObject gameObject)
    {
        GameObject = gameObject;
        IsUnlocked = false;
    }
}

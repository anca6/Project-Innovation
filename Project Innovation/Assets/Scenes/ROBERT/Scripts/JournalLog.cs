using System.Collections.Generic;
using UnityEngine;

public class JournalLog : MonoBehaviour
{
    public static JournalLog Instance; //singleton instance of the journal manager

    //list of gameobjects as journal entries
    [SerializeField] private List<JournalEntry> journalEntries = new List<JournalEntry>();
    private int currentItemIndex = 0;

    //method to be able to reference this object in any scene
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        ActivateLog();
        CheckCurrentLog();
    }

    //activate an entry if an action unlocked it
    private void ActivateLog()
    {
        int activeIndex = -1;
        for (int i = 0; i < journalEntries.Count; i++)
        {
            if (journalEntries[i].IsUnlocked) //if a journal entry has been unlocked
            {
                if (currentItemIndex == i)
                {
                    activeIndex = i; //activate the gameobject
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

    //checking if an object is the last unlocked entry and moving onto the next unlocked one
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

    //checking if an object is not the last entry and moving onto the previous unlocked one
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

    //checking for out of bounds entries
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

    //sets entry as unlocked
    public void UnlockEntry(int entryIndex)
    {
        if (entryIndex >= 0 && entryIndex < journalEntries.Count)
        {
            journalEntries[entryIndex].IsUnlocked = true;
            currentItemIndex = entryIndex;
            
        }
    }

}
    //journal entry class to assign entry gameobject and unlocked status
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

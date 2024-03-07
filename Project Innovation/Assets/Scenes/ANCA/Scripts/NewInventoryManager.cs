using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots;
    public Sprite[] itemSprites;

    public List<Seed> seedInventory = new List<Seed>();

    public JournalLog journalLog;

    void Start()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponent<Image>().sprite = null;
        }
    }

    public bool HasSeedType(string seedType)
    {
        foreach (Seed seed in seedInventory)
        {
            if (seed.Type == seedType)
            {
                return true;
            }
        }
        return false;
    }

    public void UnlockJournalEntry(int entryIndex)
    {
        if (journalLog != null)
        {
                journalLog.UnlockEntry(entryIndex);
            }
        else
        {
            Debug.LogWarning("journalLog instance not found");
        }
    }

    public void AddItemToInventory(Sprite itemSprite)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].GetComponent<Image>().sprite == null)
            {
                inventorySlots[i].GetComponent<Image>().sprite = itemSprite;
                break;
            }
        }
    }

    public void AddSeedToInventory(Seed seed)
    {
        seedInventory.Add(seed);

        Sprite seedSprite = GetSeedSprite(seed.Type);
        AddItemToInventory(seedSprite);
    }

    private Sprite GetSeedSprite(string type)
    {
        string path = $"Sprites/Seeds/{type}";
        Sprite sprite = Resources.Load<Sprite>(path);
        if (sprite == null)
        {
            Debug.LogError($"failed to load sprite for seed type: {type}");
        }
        return sprite;
    }
}

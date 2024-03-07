using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots; // Array of UI Image objects representing the inventory slots
    public Sprite[] itemSprites; // Array of Sprites for the items

    public List<Seed> seedInventory = new List<Seed>();

    public JournalLog journalLog;

    void Start()
    {
        // Initialize inventory slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponent<Image>().sprite = null; // Clear the slot
        }
    }

    public bool HasSeedType(string seedType)
    {
        foreach (Seed seed in seedInventory)
        {
            if (seed.Type == seedType)
            {
                return true; // Found the seed type in the inventory
            }
        }
        return false; // Seed type not found in the inventory
    }

    public void UnlockJournalEntry(int entryIndex)
    {
        // Find the JournalLog instance in the scene
        if (journalLog != null)
        {
                // Call the UnlockEntry method with the specified entry index
                journalLog.UnlockEntry(entryIndex);
            }
        else
        {
            Debug.LogWarning("JournalLog instance not found.");
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
            Debug.LogError($"Failed to load sprite for seed type: {type}");
        }
        return sprite;
    }
}

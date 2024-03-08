using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{ 
    public GameObject[] inventorySlots; //slots for the inventory grid
    public Sprite[] itemSprites;

    public List<Seed> seedInventory = new List<Seed>(); //list of seeds added to the inventory

    public JournalLog journalLog;

    //get the image component of each slot in the inventory
    void Start()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponent<Image>().sprite = null;
        }
    }

    //calls on the journal script to unlock an entry
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

    //goes through all objects in the list and replaces the sprite to the chosen sprite asset
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

    //adds the seed type in the inventory list
    public void AddSeedToInventory(Seed seed)
    {
        seedInventory.Add(seed);

        Sprite seedSprite = GetSeedSprite(seed.Type);
        AddItemToInventory(seedSprite);
    }

    //searches for the seed sprite linked to each seed type and loads it from the resource folder
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

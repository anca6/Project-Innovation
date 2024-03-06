using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots; // Array of UI Image objects representing the inventory slots
    public Sprite[] itemSprites; // Array of Sprites for the items

    public List<Seed> seedInventory = new List<Seed>();

    //public JournalLog journalLog;
    public static NewInventoryManager Instance { get; private set; }

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
    void Start()
    {
        // Initialize inventory slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponent<Image>().sprite = null; // Clear the slot
        }
    }

    public void AddItemToInventory(Sprite itemSprite)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //Image spriteImage = GetComponent<Image>();
            if (inventorySlots[i].GetComponent<Image>().sprite == null)
            {
                inventorySlots[i].GetComponent<Image>().sprite = itemSprite;
                break;
            }
        }
    }
    public void AddSeedToInventory(Seed seed)
    {
        // Add the seed to the list of seeds in the inventory
        seedInventory.Add(seed);
        Debug.Log("add seed 1");

        int entryIndexToUnlock = GetEntryIndexToUnlock(seed.Type);
        JournalLog.Instance.UnlockEntry(entryIndexToUnlock);


        // Find the corresponding sprite for the seed and add it to the inventory
        Sprite seedSprite = GetSeedSprite(seed.Type);
        AddItemToInventory(seedSprite);
    }

    private int GetEntryIndexToUnlock(string seedType)
    {
        // Example logic to determine which journal entry index to unlock
        // based on the seed type. Adjust this logic as needed.
        switch (seedType)
        {
            case "SeedType1":
                return 0; // Unlock the first journal entry
            case "SeedType2":
                return 1; // Unlock the second journal entry
            // Add more cases as needed
            default:
                return -1; // No entry to unlock
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots; // Array of UI Image objects representing the inventory slots
    public Sprite[] itemSprites; // Array of Sprites for the items

    public List<Seed> seedInventory = new List<Seed>();

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

        // Find the corresponding sprite for the seed and add it to the inventory
        Sprite seedSprite = GetSeedSprite(seed.Type);
        AddItemToInventory(seedSprite);
    }

    private Sprite GetSeedSprite(string type)
    {
        string path = $"Sprites/Seeds/{type}";
        Sprite sprite = Resources.Load<Sprite>(path);
        if (sprite == null)
        {
            Debug.LogError($"Failed to load sprite for seed type: {type}. Check the Resources folder structure and sprite names.");
        }
        return sprite;
    }

}

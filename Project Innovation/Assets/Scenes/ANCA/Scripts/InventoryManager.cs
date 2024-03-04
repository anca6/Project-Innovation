using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public delegate void InventoryHandler();
    public static event InventoryHandler onInventoryChanged;

    public List<Seed> inventory = new List<Seed>();
    private Dictionary<string, string> seedToFlower = new Dictionary<string, string>
    {
        { "SeedType1","FlowerType1" },
        { "SeedType2","FlowerType2" },
    };

    public Text seedCountText;
    //public GameObject inventorySeed;

    public void Update()
    {
        int seedCount = inventory.Sum(seed => seed.Quantity);
        
            seedCountText.text = seedCount.ToString();
    }

    public void AddSeed(string seedType)
    {
        Seed seed = inventory.Find(s => s.Type == seedType);
        if(seed != null)
        {
            seed.Quantity++;
            Debug.Log("seed added " + seedType + " " + seed.Quantity);
        }
        else
        {
            inventory.Add(new Seed(seedType, 1));
            Debug.Log("seed added " + seedType);
            onInventoryChanged?.Invoke();
        }

        if (seedToFlower.TryGetValue(seedType, out string flowerType))
        {
            //something
        }

    }
}

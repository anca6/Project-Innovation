using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Seed> inventory = new List<Seed>();
    private Dictionary<string, string> seedToFlower = new Dictionary<string, string>
    {
        { "SeedType1","FlowerType1" },
        { "SeedType2","FlowerType2" },
    };


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
        }

        if (seedToFlower.TryGetValue(seedType, out string flowerType))
        {
            //something
        }
    }
}

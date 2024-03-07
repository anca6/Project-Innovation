using UnityEngine;

public class Seed
{
    public string Type { get; set; }
    public string FlowerType { get; set; }
    public int Quantity { get; set; }
    public GameObject FlowerPrefab { get; set; }

    public Seed(string type, string flowerType, int quantity)
    {
        Type = type;
        FlowerType = flowerType;
        Quantity = quantity;
    }
}

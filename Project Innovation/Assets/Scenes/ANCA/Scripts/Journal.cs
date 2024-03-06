using UnityEngine;

[System.Serializable]
public class JournalEntry
{
    public string SeedType;
    public string FlowerType;

    public JournalEntry(string seedType, string flowerType)
    {
        SeedType = seedType;
        FlowerType = flowerType;
    }
}

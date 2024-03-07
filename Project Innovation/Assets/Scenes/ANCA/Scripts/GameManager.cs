using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool buttonClicked = false;

    public NewInventoryManager inventoryManager;

    [HideInInspector]
    public int flowerStage;
    [HideInInspector]
    public int elixirCount;
    [HideInInspector]
    public int journalStage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetButtonClicked(bool value)
    {
        buttonClicked = value;
        if (buttonClicked)
        {
            // Unlock a journal entry
            JournalLog.Instance.UnlockEntry(0); // Specify the index of the entry you want to unlock

            /*// Add a seed to the inventory
            Seed newSeed = new Seed("SeedType", "FlowerType", 1); // Replace "SeedType" and "FlowerType" with the actual types
            inventoryManager.AddSeedToInventory(newSeed);*/
        }
    }


}

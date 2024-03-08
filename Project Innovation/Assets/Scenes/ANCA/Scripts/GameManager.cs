using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //singleton instance of the game manager

    private bool buttonClicked = false; //for the seed object in the explore scene

    public NewInventoryManager inventoryManager;

    //keeping count of these variables
    [HideInInspector]
    public int flowerStage; 
    [HideInInspector]
    public int elixirCount;
    [HideInInspector]
    public int journalStage;

    //method to be able to reference this object in any scene
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //method for the seed collecting logic
    public void SetButtonClicked(bool value)
    {
        buttonClicked = value;
        if (buttonClicked)
        {
            JournalLog.Instance.UnlockEntry(0); //unlocking the first entry in the journal
        }
    }


}

using UnityEngine;

public class Resource : MonoBehaviour
{
    //class for the resource gameobjects
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    ResourceManager resourceManager;

    [SerializeField]
    NewInventoryManager inventoryManager;

    [SerializeField]
    LandmarkManager landmarkManager;
    public void OnClick()
    {
        //if collected, adds 1 elixir and deactivates the object
        resourceManager.AddElixir(1);
        gameObject.SetActive(false); 
    }
}
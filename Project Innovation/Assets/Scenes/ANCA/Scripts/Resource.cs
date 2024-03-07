using UnityEngine;

public class Resource : MonoBehaviour
{
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
        //if (landmarkManager != null && landmarkManager.canClick)
        //{
            resourceManager.AddElixir(1);
            gameObject.SetActive(false);
        //inventoryManager.AddSeed(new Flower());

        Debug.Log("RESOURCE ADDED");
        //}
    }
}
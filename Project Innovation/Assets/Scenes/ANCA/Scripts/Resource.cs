using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resource : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    ResourceManager resourceManager;

    [SerializeField]
    InventoryManager inventoryManager;

    [SerializeField]
    LandmarkManager landmarkManager;
    public void OnClick()
    {
        //if (landmarkManager != null && landmarkManager.canClick)
        //{
            resourceManager.AddElixir(1);
            //inventoryManager.AddSeed(new Flower());

            Debug.Log("RESOURCE ADDED");

            gameObject.SetActive(false);

        //}
    }
}
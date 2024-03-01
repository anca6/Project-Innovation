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
    LandmarkManager landmarkManager;
    public void OnClick()
    {
        if (landmarkManager != null && landmarkManager.canClick)
        {
                resourceManager.AddElixir(1);
                Debug.Log("RESOURCE ADDED");

                gameObject.SetActive(false);

        }
    }
}
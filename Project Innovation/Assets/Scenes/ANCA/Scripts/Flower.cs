using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public string type;
    public int currentStage;
    public int totalStages;

    [SerializeField]
    public GameObject[] stagePrefabs;

    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
    public void Grow()
    {
        if (resourceManager.elixir >= 1)
        {

            if (currentStage < totalStages)
            {
                currentStage++;
                resourceManager.UseElixir(1);
                UpdateVisualStage();
            }
            else
            {
                Debug.Log("flower reached last stage");
            }
        }
        else
        {
            Debug.Log("not enough elixir!");
        }
    }

    public GameObject GetStagePrefab()
    {
        if (currentStage < stagePrefabs.Length)
        {
            return stagePrefabs[currentStage];
        }
        else
        {
            Debug.Log("flower is at its last stage");
            return null;
        }
    }

    public void UpdateVisualStage()
    {
        // Loop through all child GameObjects (stages) and set them to inactive
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // Set the current stage to active
        if (currentStage < transform.childCount)
        {
            transform.GetChild(currentStage).gameObject.SetActive(true);
        }
        else
        {
            //Debug.LogError("current stage index is out of bounds");
            //show ui (this plant cant be grown anymore or sm like that)
        }
    }

}

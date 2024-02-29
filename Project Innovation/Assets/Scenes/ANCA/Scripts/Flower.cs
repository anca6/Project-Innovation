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
        currentStage = GameManager.instance.flowerStage;
        resourceManager.elixir = GameManager.instance.elixirCount;
    }
    public void Grow()
    {
        if (resourceManager.elixir >= 1)
        {

            if (currentStage < totalStages)
            {
                currentStage++;
                GameManager.instance.flowerStage++;

                resourceManager.UseElixir(1);
                GameManager.instance.elixirCount--;

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
        if (GameManager.instance.flowerStage < transform.childCount)
        {
            transform.GetChild(GameManager.instance.flowerStage).gameObject.SetActive(true);
        }
        else
        {
            //Debug.LogError("current stage index is out of bounds");
            //show ui (this plant cant be grown anymore or sm like that)
        }
    }

    private void OnEnable()
    {
        UpdateVisualStage ();
    }

}

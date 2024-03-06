using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    public string type;
    public int currentStage;
    public int totalStages;

    [SerializeField]
    public GameObject[] stagePrefabs;

    [SerializeField]
    public GameObject[] statusBar;

    /*[SerializeField]
    public GameObject[] roseStagePrefabs;*/

   /* [SerializeField]
    public GameObject[] lilyStagePrefabs;*/

    // Add more arrays as needed for different types


    private ResourceManager resourceManager;

    /*[SerializeField]
    private Dictionary<string, GameObject[]> flowerPrefabs = new Dictionary<string, GameObject[]>();*/

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        currentStage = GameManager.instance.flowerStage;
        resourceManager.elixir = GameManager.instance.elixirCount;

        /*flowerPrefabs.Add("Type1", new GameObject[] { *//* Prefabs for Type1 *//* });
        flowerPrefabs.Add("Type2", new GameObject[] { *//* Prefabs for Type2 *//* });*/
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

                // Update the visual stage to reflect the growth
                UpdateVisualStage();

                // Optionally, update the status bar colors here
                UpdateStatusBarColors();
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
        // Get the prefab array for the current flower type
        //GameObject[] stagePrefabs = flowerPrefabs[type];

        // Check if the current stage is within the bounds of the prefab array
        if (currentStage < stagePrefabs.Length)
        {
            // Return the prefab for the current stage
            return stagePrefabs[currentStage];
        }
        else
        {
            Debug.Log("flower is at its last stage");
            return null;
        }
    }

    /*public GameObject GetStagePrefab()
    {
        GameObject[] selectedPrefabs = null;

        // Use a switch statement to select the correct prefab array based on the type
        switch (type)
        {
            case "Rose":
                selectedPrefabs = roseStagePrefabs;
                break;
            case "Lily":
                selectedPrefabs = lilyStagePrefabs;
                break;
            // Add more cases as needed for different types
            default:
                Debug.LogError("Unknown flower type: " + type);
                break;
        }

        // Check if the current stage is within the bounds of the selected prefab array
        if (currentStage < selectedPrefabs.Length)
        {
            // Return the prefab for the current stage
            return selectedPrefabs[currentStage];
        }
        else
        {
            Debug.Log("Flower is at its last stage");
            return null;
        }
    }*/

    public void UpdateVisualStage()
    {
        // Loop through all child GameObjects (stages) and set them to inactive
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // Set the current stage to active
        // Assuming the child GameObjects are named or ordered to match the stages
        if (currentStage < transform.childCount)
        {
            transform.GetChild(currentStage).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("current stage index is out of bounds");
        }
    }



    public void UpdateStatusBarColors()
    {
        // Loop through all rectangles in the status bar
        for (int i = 0; i < statusBar.Length; i++)
        {
            // Check if the rectangle has an Image component
            Image imageComponent = statusBar[i].GetComponent<Image>();
            if (imageComponent != null)
            {
                // Change the color based on the rectangle's position
                if (i <= currentStage )
                {
                    // Change the color of rectangles up to the current stage to green
                    imageComponent.color = Color.green;
                }
                else
                {
                    // Change the color of rectangles beyond the current stage to red
                    imageComponent.color = Color.red;
                }
            }
            else
            {
                Debug.LogWarning($"Rectangle {i} does not have an Image component.");
            }
        }
    }



    private void OnEnable()
    {
        UpdateVisualStage ();
        UpdateStatusBarColors();
    }

}

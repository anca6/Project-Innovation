using TMPro;
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

    private ResourceManager resourceManager;

    public JournalLog journalLog;

    [SerializeField]
    private int entryIndex;

    [SerializeField] 
    TimerController timerController;

    [SerializeField]
    TimerController growthTimerController; // Reference to the growth timer controller

    private bool growthTimerStarted = false;
    private float growthStartTime;
    public float growthDuration = 30f; // Duration for each growth stage in seconds

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        currentStage = GameManager.instance.flowerStage;
        resourceManager.elixir = GameManager.instance.elixirCount;
    }

    public void StartGrowthTimer()
    {
        growthTimerStarted = true;
        growthStartTime = Time.time;
    }

    private void Update()
    {
        if (growthTimerStarted)
        {
            float elapsedTime = Time.time - growthStartTime;
            if (elapsedTime >= growthDuration)
            {
                Grow();
                StartGrowthTimer(); // Restart the growth timer for the next stage
            }
        }
    }

    public void Grow()
    {
        if (resourceManager.elixir >= 1)
        {
            if (currentStage < totalStages - 1) // Adjusted condition
            {
                currentStage++;
                GameManager.instance.flowerStage++;

                resourceManager.UseElixir(1);
                GameManager.instance.elixirCount--;

                timerController.ResetGrowthTimer();

                // Update the visual stage to reflect the growth
                UpdateVisualStage();

                // Optionally, update the status bar colors here
                UpdateStatusBarColors();
            }
            else if (currentStage == totalStages - 1) // Check if it's the last stage
            {
                journalLog.UnlockEntry(entryIndex);
                Debug.Log("3rd entry!");

                timerController.StopTimer();
                timerController.StopGrowthTimer();
                timerController.HideTimer();
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
                if (i < currentStage)
                {
                    // Change the color of rectangles up to the current stage to green
                    imageComponent.color = Color.green;
                }
                else if (i == currentStage)
                {
                    // Change the color of the current stage to green
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
        UpdateVisualStage();
        UpdateStatusBarColors();
    }

}

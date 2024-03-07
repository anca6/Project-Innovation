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

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        currentStage = GameManager.instance.flowerStage;
        resourceManager.elixir = GameManager.instance.elixirCount;
    }

    private void Update()
    {
        if (timerController.growthTimerStarted)
        {
            float elapsedTime = Time.time - timerController.growthStartTime;
            if (elapsedTime >= timerController.growthDuration)
            {
                Grow();
                timerController.ResetGrowthTimer();
            }
        }
    }

    public void Grow()
    {
        if (timerController.growthTimerElapsed || resourceManager.elixir >= 1)
        {
            if (currentStage < totalStages - 1) 
            {
                currentStage++;
                GameManager.instance.flowerStage++;

                resourceManager.UseElixir(1);
                GameManager.instance.elixirCount--;

                timerController.ResetGrowthTimer();

                
                UpdateVisualStage();

                
                UpdateStatusBarColors();
            }
            else if (currentStage == totalStages - 1)
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
        else /*if(timerController.grow)*/
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
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

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
        for (int i = 0; i < statusBar.Length; i++)
        {
            Image imageComponent = statusBar[i].GetComponent<Image>();
            if (imageComponent != null)
            {
                if (i < currentStage)
                {
                    imageComponent.color = Color.green;
                }
                else if (i == currentStage)
                {
                    imageComponent.color = Color.green;
                }
                else
                {
                    imageComponent.color = Color.red;
                }
            }
            else
            {
                Debug.LogWarning($"rectangle {i} does not have an image component");
            }
        }
    }


    private void OnEnable()
    {
        UpdateVisualStage();
        UpdateStatusBarColors();
    }

}

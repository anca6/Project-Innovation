using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour
{
    //variables to keep track of detailed object status
    public string type;
    public int currentStage;
    public int totalStages;

    //list of prefabs for different stage visualisation
    [SerializeField]
    public GameObject[] stagePrefabs;

    //list of gameobjects set up as a status bar
    [SerializeField]
    public GameObject[] statusBar;

    private ResourceManager resourceManager;

    public JournalLog journalLog;

    [SerializeField]
    private int entryIndex;

    //reference to timer controller for life-span and growth process
    [SerializeField] 
    TimerController timerController;

    private void Start()
    {
        //initializing managers
        resourceManager = FindObjectOfType<ResourceManager>();
        currentStage = GameManager.instance.flowerStage;
        resourceManager.elixir = GameManager.instance.elixirCount;
    }

    //checks if flower lived to the next stage before it dies
    private void Update()
    {
        if (timerController.growthTimerStarted)
        {
            float elapsedTime = Time.time - timerController.growthStartTime;
            if (elapsedTime >= timerController.growthDuration)
            {
                //flower goes to next stage and timer is reset for next growth check
                Grow();
                timerController.ResetGrowthTimer();
            }
        }
    }
    
    //entire logic of growing the flowers
    public void Grow()
    {
        if (timerController.growthTimerElapsed || resourceManager.elixir >= 1) //if the flower lived to the next stage or the player has elixir in its inventory
        {
            if (currentStage < totalStages - 1) //if flower didnt reach last growth stage
            {
                currentStage++;
                GameManager.instance.flowerStage++; //goes to next stage and updates universal growth status

                resourceManager.UseElixir(1);
                GameManager.instance.elixirCount--; //player uses elixir to grow flower to the next stage and updates inventory

                timerController.ResetGrowthTimer();


                UpdateVisualStage();
                UpdateStatusBarColors();

            }
            else if (currentStage == totalStages - 1)
            {
                currentStage++;
                GameManager.instance.flowerStage++; //next growth stage

                journalLog.UnlockEntry(entryIndex); //unlockes a new entry in the journal

                UpdateVisualStage();
                UpdateStatusBarColors(); //updates the prefab and status bar

                timerController.StopTimer();
                timerController.StopGrowthTimer();
                timerController.HideTimer(); //stops all timers
            }
        }
    }
    
    public GameObject GetStagePrefab()
    {
        if (currentStage < stagePrefabs.Length)
        {
            return stagePrefabs[currentStage];
        }
        else return null;
    }

    //updates the flower growth visually with prefabs
    public void UpdateVisualStage()
    {
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false); //setting all stages inactive initially
        }

        //if the flower is not at its last growth stage we activate it
        if (currentStage < transform.childCount)
        {
            transform.GetChild(currentStage).gameObject.SetActive(true); 
        }
    }

    //updates the flower growth visually with status bar
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
        }
    }

    private void OnEnable()
    {
        UpdateVisualStage();
        UpdateStatusBarColors();
    }

}

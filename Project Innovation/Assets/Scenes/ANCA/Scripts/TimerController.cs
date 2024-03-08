using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    //text to visualize the timer
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI growthTimerText;

    //variables to store life-span timer
    private float startTime;
    private bool timerStarted = false;
    public float duration = 30f;
   
    //variables to store time until next growth stage
    public float growthStartTime; 
    public bool growthTimerStarted = false;
    public float growthDuration = 30f;

    public bool growthTimerElapsed = false;

    private void Update()
    {
        if (timerStarted)
        {
            UpdateTimer();
        }

        if (growthTimerStarted)
        {
            UpdateGrowthTimer();
        }
    }

    public void StartTimer()
    {
        if (!timerStarted)
        {
            startTime = Time.time;
            timerStarted = true;
        }
    }

    public void StartGrowthTimer()
    {
        if (!growthTimerStarted)
        {
            growthStartTime = Time.time;
            growthTimerStarted = true;
        }
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }

    public void ResetGrowthTimer()
    {
        growthStartTime = Time.time;

    }
    public void StopTimer()
    {
        timerStarted = false;
    }

    public void StopGrowthTimer()
    {
        growthTimerStarted = false;
    }

    public void HideTimer()
    {
        timerText.gameObject.SetActive(false);
        growthTimerText.gameObject.SetActive(false);
    }

    //if life-span reaches 0, timer stops and flower dies
    private void UpdateTimer()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = Mathf.Max(0f, duration - elapsedTime);
        UpdateText(timerText, remainingTime);
        if (remainingTime <= 0f)
        {
            StopTimer();
            Destroy(gameObject);
        }
    }

    //flower grows to next stage
    private void UpdateGrowthTimer()
    {
        float elapsedTime = Time.time - growthStartTime;
        float remainingTime = Mathf.Max(0f, growthDuration - elapsedTime);
        UpdateText(growthTimerText, remainingTime);
        if (remainingTime <= 0.1f)
        {
            growthTimerElapsed = true;
            
            Flower flower = FindObjectOfType<Flower>();
            if (flower != null)
            {
                if(growthTimerElapsed == true)
                {
                flower.Grow();
                }
            }
        }
    }

    //updates text objects
    private void UpdateText(TextMeshProUGUI textComponent, float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        textComponent.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

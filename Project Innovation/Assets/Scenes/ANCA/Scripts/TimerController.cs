using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI growthTimerText;

    private float startTime;
    private bool timerStarted = false;
    public float duration = 30f;
   
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

    private void UpdateTimer()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = Mathf.Max(0f, duration - elapsedTime);
        UpdateText(timerText, remainingTime);
        if (remainingTime <= 0f)
        {
            StopTimer();
        }
    }

    private void UpdateGrowthTimer()
    {
        float elapsedTime = Time.time - growthStartTime;
        float remainingTime = Mathf.Max(0f, growthDuration - elapsedTime);
        UpdateText(growthTimerText, remainingTime);
        if (remainingTime <= 0f)
        {
            growthTimerElapsed = true;
            //StopGrowthTimer();
            
            Flower flower = FindObjectOfType<Flower>();
            if (flower != null)
            {
                if(growthTimerElapsed == true)
                {
                flower.Grow();

                }
            }
            else
            {
                Debug.LogWarning("flower component not found");
            }
        }
    }

    private void UpdateText(TextMeshProUGUI textComponent, float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        textComponent.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

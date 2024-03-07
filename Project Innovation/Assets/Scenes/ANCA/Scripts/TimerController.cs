using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI growthTimerText; // Text object for the growth timer
    private float startTime;
    private float growthStartTime; // Start time for the growth timer
    private bool timerStarted = false;
    private bool growthTimerStarted = false;
    public float duration = 30f;
    public float growthDuration = 30f; // Duration for each growth stage in seconds

    private Flower flower;

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
        growthTimerText.gameObject.SetActive(false); // Hide growth timer text
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
            StopGrowthTimer();
            // Call the Grow method to grow the flower
            Flower flower = FindObjectOfType<Flower>(); // Find the Flower component
            if (flower != null)
            {
                flower.Grow(); // Call the Grow method
            }
            else
            {
                Debug.LogWarning("Flower component not found.");
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

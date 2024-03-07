using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool timerStarted = false;
    public float duration = 30f;

    private void Update()
    {
        if (timerStarted)
        {
            float elapsedTime = Time.time - startTime;
            float remainingTime = Mathf.Max(0f, duration - elapsedTime);
            int hours = (int)(remainingTime / 3600f);
            int minutes = (int)((remainingTime % 3600f) / 60f);
            int seconds = (int)(remainingTime % 60f);
            timerText.text = string.Format("Timer: {0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            if (remainingTime <= 0f)
            {
                Destroy(gameObject);
            }
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
}

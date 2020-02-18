using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * Resources:
 * Simple Timer
 * https://answers.unity.com/questions/351420/simple-timer-1.html
 * https://answers.unity.com/questions/980339/count-down-timer-c-1.html
 */

public class Timer : MonoBehaviour
{
    public float timeLeft = 210.0f;
    public bool stop = true;

    private float minutes;
    private float seconds;
    public TextMeshProUGUI TimerText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        //TimerText.text = "Time Left:" + Mathf.Round(timeLeft);

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;

        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;
        }

        TimerText.text = string.Format("Time Left: {0:0}:{1:00}", minutes, seconds);

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

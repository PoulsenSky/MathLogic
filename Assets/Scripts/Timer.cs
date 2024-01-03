using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime = 600f;
    public bool isTimerRunning = true;
    public QuizManager quizManager;
    public float GetTimeLeft;

    private void Start()
    {
        isTimerRunning = true;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (isTimerRunning) {
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0f){
                countdownTime = 0f;
                Debug.Log("Timer Expired!");
                quizManager.GameOver();
                StopTimer();
            }
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        float minutes = Mathf.FloorToInt(countdownTime / 60);
        float seconds = Mathf.FloorToInt(countdownTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer() {
        isTimerRunning = false;
        Debug.Log("Timer Stopped");
    }

    public void TimeCorrectAnswer()
    {
        countdownTime += 10;
    }

    public void TimeIncorrectAnswer()
    {
        countdownTime -= 30;
    }
}

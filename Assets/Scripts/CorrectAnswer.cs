using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public bool isCorrect = false;
    public bool isDelay = true;
    public QuizManager quizManager;
    public GameObject NotifyFalsePanel;
    public GameObject NotifyTruePanel;
    public float delayTimer = 1f;

    public void Answer()
    {
        if(isCorrect) {
            Debug.Log("Correct Answer");
            quizManager.TrueAnswer();
        } else {
            Debug.Log("Sorry, it's a wrong Answer");
            quizManager.WrongAnswer();
        }
    }

    public void StepCorrectPanel() {
        NotifyTruePanel.SetActive(true);
        while(delayTimer > 0f) {
            delayTimer -= Time.deltaTime;
        }
        NotifyTruePanel.SetActive(false);
    }


    public void StepWrongPanel() {
        NotifyFalsePanel.SetActive(true);
        while(delayTimer > 0f) {
            delayTimer -= Time.deltaTime;

        }
        NotifyFalsePanel.SetActive(false);
    }
}

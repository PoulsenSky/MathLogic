using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager: MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject GameOverPanel;
    //================================= calling classes ===========================================
    public List<QuestionAnswers> Quests;
    public FuzzyLogicSugeno Fuzzy;
    public InputNameData inputTheName;
    public GameObject[] AnswersChoose;
    public CorrectAnswer AnswerNotify;
    public Timer theTime;

    //================================= calling variables ===========================================
    public int QuestionNumber;

    public Text QuestText;
    public Text TotalQuestText;
    public Text playerName;
    public string ProgressQuests;
    public Text TimeLeft;
    public Text ScoreText;
    public Text MyGrade;
    public int score;
    public string setNamePlayer;

    public int TotalQuests = 0;
    public int TimeGet;
    public string Grade;
    public double OutputResult;

    //Starting the script
    private void Start() {
        TotalQuests = Quests.Count;
        GameOverPanel.SetActive(false);
        QuestAppearRandom();
    }

    //Setting All Answers from QA class
    void AnswersSet() {
        for(int i = 0; i < AnswersChoose.Length; i++) {
            AnswersChoose[i].GetComponent<CorrectAnswer>().isCorrect = false;
            AnswersChoose[i].transform.GetChild(0).GetComponent<Text>().text = Quests[QuestionNumber].Answers[i];

            if(Quests[QuestionNumber].AnswerCorrect == i+1) {
                AnswersChoose[i].GetComponent<CorrectAnswer>().isCorrect = true;
            }
        }
    }

    //Questions related will be approaching randomly
   void QuestAppearRandom() {
        if(Quests.Count > 0) {
            QuestionNumber = Random.Range(0, Quests.Count);
            QuestText.text = Quests[QuestionNumber].Question;
            AnswersSet();
        } else {
            Debug.Log("All Questions have been answered");
            GameOver();
        }
    }

    //Counting how much questions have been answered
    public string UpdateQuestionTotal() {
        int questionsRemaining = Quests.Count;
        int questionsAnswered = TotalQuests - questionsRemaining;
        ProgressQuests = $"{questionsAnswered}";
        return ProgressQuests;
    }

    //If answer is true
    public void TrueAnswer() {
        score += 1;
        //AnswerNotify.StepCorrectPanel();
        Quests.RemoveAt(QuestionNumber);
        theTime.TimeCorrectAnswer();
        QuestAppearRandom();
    }

    //If answer is false
    public void WrongAnswer() {
        //AnswerNotify.StepWrongPanel();
        Quests.RemoveAt(QuestionNumber);
        theTime.TimeIncorrectAnswer();
        QuestAppearRandom();
    }

    //Game Over will be shown up by enabling GameOverPanel
    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        ScoreText.text = score.ToString();

        string ProgressGame = UpdateQuestionTotal();
        TotalQuestText.text = ProgressGame;

        theTime.StopTimer();
        TimeGet = Mathf.FloorToInt(theTime.countdownTime);
        TimeLeft.text = $"{TimeGet.ToString()} Seconds";

        inputTheName.NameUpdate();
        playerName.text = inputTheName.namePlayer.text;

        Fuzzy.Update();
        Grade = Fuzzy.ScoreGrade;
        MyGrade.text = Grade;
        Debug.Log("Your Grade is {MyGrade}");

    }

    //Game will retry and gets to Input Name Scene
    public void GameRetry(string Scenes) {
        SceneManager.LoadScene(Scenes);
    }
}

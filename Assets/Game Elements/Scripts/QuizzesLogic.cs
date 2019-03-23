using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class QuizzesLogic : MonoBehaviour {
    int score = 0, askedQuestions = 0;
    public static int NumOfQuestions;
    public Text QuestionBox, scoreBox;
    Question currentQuestion;
    public Question[] questions = new Question[NumOfQuestions];
    Option[] CurrentOptions = new Option[4];
    public Button[] Buttons = new Button[4];
    public GameObject NextButton;
    //public GameObject SkipButton;
    public Text[] OptionsText = new Text[4];
    public AudioSource correct, wrong;
    public GameObject StartScreen;
    public GameObject QuizScreen;
    public GameObject ResultScreen;

     public void StartQuiz()
    {
        StartScreen.SetActive(false);
        ResultScreen.SetActive(false);
        QuizScreen.SetActive(true);
        askedQuestions = 0;
        for(int i=0; i< NumOfQuestions;i++)
        {
            questions[i].GetComponent<Question>().asked = false;
        }
        scoreBox.text = "0";
        GetQuestion();
    }

    public void GetQuestion() {
        int QuizIndex;
        NextButton.SetActive(false);
        //SkipButton.SetActive(true);
        if (askedQuestions != NumOfQuestions)
        {
            QuizIndex = Random.Range(0, NumOfQuestions - 1);
            if (!questions[QuizIndex].GetComponent<Question>().asked)
            {
                currentQuestion = questions[QuizIndex];
                currentQuestion.GetComponent<Question>().asked = true;
                QuestionBox.text = ArabicFixer.Fix(currentQuestion.GetComponent<Question>().questionText);
                for (int i = 0; i < 4; i++)
                {
                    CurrentOptions[i] = currentQuestion.GetComponent<Question>().options[i];
                    OptionsText[i].text = ArabicFixer.Fix(CurrentOptions[i].GetComponent<Option>().optionText);
                }
                askedQuestions++;
            }
        }
        else
        {
            QuizScreen.SetActive(false);
            ResultScreen.SetActive(true);
        }
    }
    public void Answer(Option op)
    {
        int OptionIndex = 0;
        int CorrectOptionIndex=0;
        for (int i = 0; i < 4; i++) {
            if(CurrentOptions[i] == op)
            {
                OptionIndex = i;
            }
            if (CurrentOptions[i].GetComponent<Option>().correct)
            {
                CorrectOptionIndex = i;
            }
        }
        if (OptionIndex==CorrectOptionIndex)
        {
            Buttons[OptionIndex].GetComponent<Image>().color = Color.green;//specify shades
            correct.Play();
            score++;
            scoreBox.text = score.ToString();
        }
        else
        {
            Buttons[OptionIndex].GetComponent<Image>().color = Color.red;//specify shades
            Buttons[CorrectOptionIndex].GetComponent<Image>().color = Color.green;//specify shades
            wrong.Play();
        }
    }
    public void ExitQuiz()
    {
        StartScreen.SetActive(false);
        ResultScreen.SetActive(true);
        QuizScreen.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class QuizzesLogic : MonoBehaviour {
    public int score = 0, askedQuestions = 0;
    public static int NumOfQuestions;
    public Text QuestionBox, scoreBox;
    public Question currentQuestion;
    public Question[] questions = new Question[NumOfQuestions];
    public Option[] CurrentOptions = new Option[4];
    public Button[] Buttons = new Button[4];
    public GameObject NextButton;
    //public GameObject SkipButton;
    public Text[] OptionsText = new Text[4];
    public AudioSource correct, wrong, win;
    public GameObject StartScreen;
    public GameObject QuizScreen;
    public GameObject ResultScreen;
    bool answered = false;
    public Text PointsTotal;

    private void Start()
    {
        StartScreen.SetActive(true);
        QuizScreen.SetActive(false);
        ResultScreen.SetActive(false);
        NumOfQuestions = questions.Length;
        for (int i = 0; i < NumOfQuestions; i++)
        {
            questions[i].GetComponent<Question>().asked = false;
        }
    }

    public void StartQuiz()
    {
        StartScreen.SetActive(false);
        ResultScreen.SetActive(false);
        QuizScreen.SetActive(true);
        askedQuestions = 0;
        scoreBox.text = "0";
        GetQuestion();
    }

    public void GetQuestion() {
        int QuizIndex;
        NextButton.SetActive(false);
        answered = false;
        while (askedQuestions <10)
        {
            QuizIndex = Random.Range(0, NumOfQuestions - 1);
            if (!questions[QuizIndex].GetComponent<Question>().asked)
            {
                currentQuestion = questions[QuizIndex];
                currentQuestion.GetComponent<Question>().asked = true;
                QuestionBox.text = ArabicFixer.Fix(currentQuestion.GetComponent<Question>().questionText);
                for (int i = 0; i < 4; i++)
                {
                    Buttons[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    CurrentOptions[i] = currentQuestion.GetComponent<Question>().options[i];
                    OptionsText[i].text = ArabicFixer.Fix(CurrentOptions[i].GetComponent<Option>().optionText);
                }
                askedQuestions++;
                break;
            }
        }
        if (askedQuestions ==10)
        {
            ExitQuiz();
        }
    }

    public void Answer(Button op)
    {
        if (!answered)
        {
            NextButton.SetActive(true);
            Text pt = op.gameObject.GetComponentInChildren<Text>();
            Debug.Log("inside answer");
            //int OptionIndex = 0;
            int CorrectOptionIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                if (CurrentOptions[i].GetComponent<Option>().correct)
                {
                    CorrectOptionIndex = i;
                }
            }
            if (ArabicFixer.Fix(CurrentOptions[CorrectOptionIndex].optionText).Equals(pt.text))//correct
            {
                Debug.Log("inside correct");
                op.GetComponent<Image>().color = Color.green;//specify shades
                correct.Play();
                score++;
                scoreBox.text = score.ToString();
            }
            else
            {
                Debug.Log("inside else");
                op.GetComponent<Image>().color = Color.red;//specify shades
                Buttons[CorrectOptionIndex].GetComponent<Image>().color = Color.green;//specify shades
                wrong.Play();
            }
            answered = true;
        }
    }

    public void ExitQuiz()
    {
        PointsTotal.text = ArabicFixer.Fix(score.ToString());
        StartScreen.SetActive(false);
        ResultScreen.SetActive(true);
        QuizScreen.SetActive(false);
        win.Play();
    }
}

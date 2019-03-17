using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class QuizzesLogic : MonoBehaviour {
    public int score = 0, askedQuestions = 0;
    public static int NumOfQuestions;
    public Text QuestionBox, scoreBox, FinalScoreBox;
    public Question currentQuestion;
    public Question[] questions = new Question[NumOfQuestions];
    public Option[] CurrentOptions = new Option[4];
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
        /*StartScreen.SetActive(false);
        ResultScreen.SetActive(false);
        QuizScreen.SetActive(true);*/
        askedQuestions = 0;
        for(int i=0; i< questions.Length; i++)
        {
            questions[i].GetComponent<Question>().asked = false;
        }
        scoreBox.text = score.ToString();
        GetQuestion();
    }

    public void GetQuestion() {
        //Debug.Log("inside method");
        int QuizIndex;
        NextButton.SetActive(false);
        //SkipButton.SetActive(true);
        if (askedQuestions <= 10 && askedQuestions< questions.Length)
        {
            Debug.Log("inside if");
            
            //Debug.Log("Quiz index= " + QuizIndex);
            for (int i = 0; i < 100; i++)
            {
                QuizIndex = Random.Range(0, questions.Length);
                Debug.Log("generated number= "+ QuizIndex);
                if (questions[QuizIndex].GetComponent<Question>().asked == false)
                {
                    //Debug.Log("increaing");
                    askedQuestions++;
                   // Debug.Log("inside if2");
                    currentQuestion = questions[QuizIndex];
                    currentQuestion.GetComponent<Question>().asked = true;
                    QuestionBox.text = ArabicFixer.Fix(currentQuestion.GetComponent<Question>().questionText);
                    for (int j = 0; j < 4; j++)
                    {
                        //Debug.Log("inside for");
                        CurrentOptions[j] = currentQuestion.GetComponent<Question>().options[j];
                        OptionsText[j].text = ArabicFixer.Fix(CurrentOptions[j].GetComponent<Option>().optionText);
                        Buttons[j].GetComponent<Button>().enabled = true;
                        Buttons[j].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    }
                    Debug.Log("breaking");
                    break;
                }
            }
        }
        else
        {
            QuizScreen.SetActive(false);
            ResultScreen.SetActive(true);
            FinalScoreBox.text= score.ToString();
        }
    }
    public void Answer(Button op)
    {
        int OptionIndex = 0;
        int CorrectOptionIndex=0;
        for (int i = 0; i < 4; i++) {
            string OptionText = op.GetComponentInChildren<Text>().text;
            if (CurrentOptions[i].GetComponent<Option>().optionText.Equals(OptionText))
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
        for(int i = 0; i < 4; i++)
        {
            //Debug.Log("disabling");
            Buttons[i].GetComponent<Button>().enabled = false;
        }
        NextButton.SetActive(true);
    }
    public void ExitQuiz()
    {
        StartScreen.SetActive(false);
        ResultScreen.SetActive(true);
        QuizScreen.SetActive(false);
    }
}

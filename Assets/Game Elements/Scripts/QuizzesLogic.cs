using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzesLogic : MonoBehaviour {
    public Quiz MercuryQuiz;
    public Quiz VenusQuiz;
    public Quiz EarthQuiz;
    public Quiz MarsQuiz;
    public Quiz JupiterQuiz;
    public Quiz SaturnQuiz;
    public Quiz UranusQuiz;
    public Quiz NeptuneQuiz;
    int score;

    private void Start()
    {
        int score = 0;
    }

    public void PlanetQuiz(string planet) { }
    
}

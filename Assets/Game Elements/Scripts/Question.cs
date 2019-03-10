using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    bool asked = false;
    public string question;
    public Option[] options = new Option[4];
    Option correctAnswer;
}

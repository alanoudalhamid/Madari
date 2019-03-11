using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public bool asked = false;
    public string questionText;
    public Option[] options = new Option[4];
    Option correctAnswer;
}

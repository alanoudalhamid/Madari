using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomingAudio : MonoBehaviour {
    public AudioSource welcome;
    private static int timesPlayed = 0;
	// Use this for initialization
	void Start () {
        if (timesPlayed == 0)
        {
            welcome.Play();
            timesPlayed++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

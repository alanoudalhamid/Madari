using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour {

    public AudioSource introClip;
    AudioSource currentlyPlaying = null;

    void Start () {

        introClip.Play();
        currentlyPlaying = introClip;
	}
	
    public void playAudio(AudioSource clip)
    {
        if (currentlyPlaying != null)
        {
            currentlyPlaying.Stop();
        }
        currentlyPlaying = clip;
        currentlyPlaying.Play();
    }
}

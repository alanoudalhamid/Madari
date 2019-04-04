using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentComponentNavigator : MonoBehaviour {

    public GameObject[] components = new GameObject[4];
    public Animator[] animators = new Animator[4];
    public int contentIndex = 0;
    public GameObject nextButton, backButton;
    public bool animatingForward = false, animatingBackward= false;
    float pastFrame = -1, currentFrame;
    float animationTimer;
	// Use this for initialization
	void Start () {
        components[0].SetActive(true);
        components[1].SetActive(false);
        components[2].SetActive(false);
        components[3].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        /* if (animators[contentIndex - 1].GetCurrentAnimatorStateInfo(0).IsName("exit"))
         {
             components[contentIndex -1 ].SetActive(false);
         }*/
        /* if (animating)
         {
             if (animators[contentIndex - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animators[contentIndex - 1].IsInTransition(0))
             {
                 components[contentIndex - 1].SetActive(false);
                 animating = false;
             }
         }*/
        if (animatingForward)
        {
            if (animationTimer - Time.time < -1)
            {
                if (contentIndex == 0)
                {
                    components[3].SetActive(false);
                }
                else
                {
                    components[contentIndex - 1].SetActive(false);
                }
            }
        }
        if (animatingBackward)
        {
            if (animationTimer - Time.time < -1)
            {
                if(contentIndex == 3)
                {
                    components[0].SetActive(false);
                }
                else
                {
                    components[contentIndex + 1].SetActive(false);
                }
            }
        }
    }

    public void next()
    {

        //Debug.Log("inside next");
        animators[contentIndex].Play("exit");
        if (contentIndex == 3)
        {
            contentIndex = 0;
        }
        else
        {
            contentIndex += 1;
        }
        components[contentIndex].SetActive(true);
        animators[contentIndex].Play("enter");
        animatingForward = true;
        animationTimer = Time.time;

       /* while (!completedAnimation)
       // {
            if (animators[contentIndex-1].GetCurrentAnimatorStateInfo(0).IsName("exit"))
            {
                components[contentIndex].SetActive(false);
                completedAnimation = true;
            }
       */
          }
    

    public void back()
    {
        animators[contentIndex].Play("middle-right");
        animatingBackward = true;
        animationTimer = Time.time;
       
        if (contentIndex == 0)
        {
            contentIndex = 3;
        }
        else
        {
            contentIndex -= 1;
        }
        components[contentIndex].SetActive(true);
        animators[contentIndex].Play("left-middle");


    }
}

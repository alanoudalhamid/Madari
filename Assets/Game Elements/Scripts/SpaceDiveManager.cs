using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDiveManager : MonoBehaviour {

    string[] Planets = { "neptune","uranus","saturn","jupiter","mars","earth","venus","mercury",};
    public GameObject[] PlanetsNavigationPoints = new GameObject[8];
    public static int PlanetsIndex = 0;
    public GameObject NavigationUI_forward, NavigationUI__backward;
    public bool ActiveAnimation, VisibileNavigationUI=false;
    public GameObject GVREmulator;
    public Animator GVREmulatorAnimator;
    static string triggerName="";
    public static bool firstLoad = true;
    public bool needsTransition=false;

    private void Start()
    {
        if (!firstLoad)
        {
            Debug.Log("PlanetsIndex= " + PlanetsIndex);
            GVREmulatorAnimator.SetBool("intro-neptune", false);
            GVREmulatorAnimator.SetBool(triggerName, true);
        }
        else
        {
            GVREmulatorAnimator.SetBool("intro-neptune", true);
            firstLoad = false;
        }
        /* if (!firstLoad)
         {
             Debug.Log("PlanetsIndex= " + PlanetsIndex);
             GVREmulatorAnimator.SetBool("intro-neptune", false);
             Debug.Log("Position before: " + GVREmulator.transform.position);
             GVREmulator.transform.position = PlanetsNavigationPoints[PlanetsIndex].transform.position;
             GVREmulator.transform.rotation = PlanetsNavigationPoints[PlanetsIndex].transform.rotation;
             Debug.Log("Position after: " + GVREmulator.transform.position);
         }
         else
         {
             GVREmulatorAnimator.SetBool("intro-neptune", true);
             firstLoad = false;
         }*/


    }

    void Transition()
    {
        Debug.Log("in transition");
        Debug.Log("Position before: " + GVREmulator.transform.position);
        GVREmulator.transform.position = PlanetsNavigationPoints[PlanetsIndex].transform.position;
        GVREmulator.transform.rotation = PlanetsNavigationPoints[PlanetsIndex].transform.rotation;
        Debug.Log("Position after: " + GVREmulator.transform.position);
        needsTransition = false;
    }


    private void Update()
    {
        if (needsTransition)
        {
            Transition();
        }
        //Debug.Log("Position after: " + GVREmulator.transform.position);

        if (GVREmulator.transform.position == PlanetsNavigationPoints[PlanetsIndex].transform.position)
        {
            ActiveAnimation = false;
        }

        if (!ActiveAnimation && !VisibileNavigationUI)
        {
            if (PlanetsIndex == 0)
            {
                NavigationUI_forward.SetActive(true);
                NavigationUI__backward.SetActive(false);
                VisibileNavigationUI = true;
            }
            if(PlanetsIndex == 7)
            {
                NavigationUI__backward.SetActive(true);
                VisibileNavigationUI = true;
            }
            if(0<PlanetsIndex && PlanetsIndex < 7)
            {
                NavigationUI_forward.SetActive(true);
                NavigationUI__backward.SetActive(true);
                VisibileNavigationUI = true;
            }
        }

        if(ActiveAnimation && VisibileNavigationUI)
        {
            NavigationUI_forward.SetActive(false);
            NavigationUI__backward.SetActive(false);
            VisibileNavigationUI = false;
        }
    }
    /* void Awake()
     {
         //DontDestroyOnLoad(PlanetsIndex);
     }*/

 
     public void PlayAnimation(bool forward)
    {
        if (!ActiveAnimation)
        {
            int x;
            if (forward)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }
            triggerName = Planets[PlanetsIndex] + "-" + Planets[PlanetsIndex + x];
            GVREmulatorAnimator.SetBool(triggerName, true);
            PlanetsIndex += x;
            ActiveAnimation = true;
        }
}
}


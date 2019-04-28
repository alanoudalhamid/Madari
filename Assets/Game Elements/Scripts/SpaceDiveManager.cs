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
    public Animator GVREmulatorAnimator, SpaceMan;
    static string triggerName="";
    public static bool firstLoad = true;

    private void Start()
    {
        if (!firstLoad)
        {
          //  Debug.Log("PlanetsIndex= " + PlanetsIndex);
            GVREmulatorAnimator.SetBool("Default State", true);
            GVREmulatorAnimator.SetBool("intro-neptune", false);
            GVREmulatorAnimator.enabled = false;
           // Debug.Log("Before= " + GVREmulator.transform.position);
            GVREmulator.transform.position = PlanetsNavigationPoints[PlanetsIndex].transform.position;
            GVREmulator.transform.rotation = PlanetsNavigationPoints[PlanetsIndex].transform.rotation;
           // Debug.Log("after= " + GVREmulator.transform.position);
           // Debug.Log("after2= " + GVREmulator.transform.position);

        }
        else
        {
            GVREmulatorAnimator.SetBool("intro-neptune", true);
            firstLoad = false;
        }
 
    }

    private void Update()
    {

        if (GVREmulator.transform.position == PlanetsNavigationPoints[PlanetsIndex].transform.position)
        {
            ActiveAnimation = false;
            GVREmulatorAnimator.SetBool(triggerName, false);
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
 
     public void PlayAnimation(bool forward)
    {

        GVREmulatorAnimator.enabled = true;
       // Debug.Log(triggerName);
        if (!ActiveAnimation)
        {
            int x;
            if (forward)
            {
                x = 1;
                SpaceMan.SetBool("MoveForward", true);
            }
            else
            {
                x = -1;
                SpaceMan.SetBool("MoveBackward", true);
            }
            
            triggerName = Planets[PlanetsIndex] + "-" + Planets[PlanetsIndex + x];
            GVREmulatorAnimator.Play(triggerName);
         //   Debug.Log("playing animation");
            GVREmulatorAnimator.SetBool(triggerName, true);
            PlanetsIndex += x;
            ActiveAnimation = true;
        }
}
}


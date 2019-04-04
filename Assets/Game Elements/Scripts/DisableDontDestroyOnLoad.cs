using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDontDestroyOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("SolarSystem - VR camera").SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

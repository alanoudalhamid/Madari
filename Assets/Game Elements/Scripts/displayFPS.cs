using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayFPS : MonoBehaviour {
	public Text text;
	private float fps, deltaTime;

	// Use this for initialization
	void Start () {
		deltaTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fps = Mathf.FloorToInt (1.0f / deltaTime);
		text.text = fps.ToString ();

		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		
	}
}

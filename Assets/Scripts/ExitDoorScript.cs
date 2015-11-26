﻿using UnityEngine;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log(other.gameObject.name + " entered the exit door");
		Application.LoadLevel ("menu");
	}

	void OnTriggerExit(Collider other){
		Debug.Log(other.gameObject.name + " left the exit door");
	}
}

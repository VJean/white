using UnityEngine;
using System.Collections;

public class SixenseControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SixensePlugin.sixenseInit();

		for (int i = 0; i < SixenseInput.Controllers.Length; i++) {
			Debug.Log (SixenseInput.Controllers[i]);
		}

		// Debug.Log("Razer Controllers :" + SixenseInput.Controllers.Length);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

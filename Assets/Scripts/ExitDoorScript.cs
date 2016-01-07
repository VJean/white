using UnityEngine;
using System.Collections;

public class ExitDoorScript : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		// Player enters the door
		if(other.tag == "Player")
			Application.LoadLevel ("menu");
	}

	void OnTriggerExit(Collider other){
		// Player exits the door
	}
}

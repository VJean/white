using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Button playText;
	public Button quitText;
	// Use this for initialization
	void Start () {
		playText = playText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {;
	}

	public void StartLevel(){
		Application.LoadLevel("main");
	}

	public void ExitGame(){
		Application.Quit() ;
	}
}

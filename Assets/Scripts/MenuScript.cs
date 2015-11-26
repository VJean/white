using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OnGUI ();
	}

	void OnGUI()
	{
		const int buttonWidth = 160;
		const int buttonHeight = 30;
		
		// Affiche un bouton pour démarrer la partie
		if (
			GUI.Button(/* Centré en x, 2/3 en y*/ new Rect(Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),buttonWidth,buttonHeight),"Start!"	)
			)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("main");
		}

		if (
			GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
		    (2 * Screen.height / 3) + (buttonHeight),buttonWidth,buttonHeight),"Quit!"	)
			)
		{
			Application.Quit() ;
		}
	}
}

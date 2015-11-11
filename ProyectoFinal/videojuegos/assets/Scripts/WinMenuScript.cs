using UnityEngine;
using System.Collections;

public class WinMenuScript : MonoBehaviour
{

	//public GUISkin myskin;  //custom GUIskin reference
	public string gameLevel;
	public string optionsLevel;

	private void OnGUI ()
	{	
		if (Time.timeSinceLevelLoad >= 4.5) {
			GUI.Box (new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "LLEGASTE A TIEMPO!!!!!!!");
	
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "Jugar de nuevo")) {
				Application.LoadLevel (gameLevel);
			}
	
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "Creditos")) {
				Application.LoadLevel (optionsLevel);
			}
	
			if (GUI.Button (new Rect (Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "Salir")) {
				Application.Quit ();
			}	
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;

public class OptionsMenuScript : MonoBehaviour 
{
	//public GUISkin myskin;  //custom GUIskin reference
	public string mainMenuLevel;
	
	private void OnGUI()
	{
		//GUI.skin=myskin;   //use the custom GUISkin
		
		//GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "CREDITOS");
		
		GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Nombres");
		GUI.Box(new Rect(Screen.width/4, Screen.height/4 + 20, Screen.width/2, Screen.height/2), "dir contacto");
		
		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "VOLVER")){
			Application.LoadLevel(mainMenuLevel);
		}
	}
}

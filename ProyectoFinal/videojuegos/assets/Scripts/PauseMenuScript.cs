using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	//public GUISkin myskin;  //custom GUIskin reference
	public string levelToLoad;
	public bool paused = false;  //flag to check if the game is paused

	private void Update()
	{
		//if (Input.GetKey(KeyCode.Escape) ) //check if Escape key/Back key is pressed
		if (Input.GetKeyDown(KeyCode.Escape) ) //check if Escape key/Back key is pressed
		{
			paused = !paused;   //invert the current status. Pause if active, unpause if paused
		}
		
		if(paused)
			Time.timeScale = 0;  //set the timeScale to 0 so that all the procedings are halted
		else
			Time.timeScale = 1;  //set it back to 1 on unpausing the game
	}

	private void OnGUI()
	{
		//GUI.skin=myskin;   //use the custom GUISkin
		
		if (paused){     
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "PAUSA");
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESUMIR")){
				paused = false;
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "REINICIAR")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MENU PRINCIPAL")){
				Application.LoadLevel(levelToLoad);
			}
		}
	}

	private void Start()
	{
		Time.timeScale=1; //Set the timeScale back to 1 for Restart option to work  
	}
}

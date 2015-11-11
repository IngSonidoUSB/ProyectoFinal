using UnityEngine;
using System.Collections;

public class CountdownScript : MonoBehaviour {

	public GameObject character;
	public GameObject wall1;
	public GameObject wall2;
	public GameObject ground;
	public int countMax;  //max countdown number
	private int countDown;  //current countdown number
	//public GUIText guiTextCountdown;//GUIText reference
	public TextMesh guiTextCountdown;

	void Start () {
		MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   //get all the script components attached
		//loop through all the scripts and disable them
		foreach(MonoBehaviour script in scriptComponentsGameControl) {
			script.enabled = false;
		}
		
		//disable all the scripts attached to the walls, ground. Also disable the animation of character
		wall1.GetComponent<ControlTierra>().enabled = false;
		wall2.GetComponent<ControlTierra>().enabled = false;
		ground.GetComponent<ControlTierra>().enabled = false;
		character.GetComponent<Animation>().enabled = false;
		
		//Call the CountdownFunction
		StartCoroutine(CountdownFunction());
	}

	IEnumerator CountdownFunction() {
		//start the countdown
		for(countDown = countMax; countDown>-1;countDown--){
			if(countDown!=0){
				//display the number to the screen via the GUIText
				guiTextCountdown.text = countDown.ToString();
				//add a one second delay
				yield return new WaitForSeconds(1);    
			}
			else{
				guiTextCountdown.text = "A CORRER!!!!";
				yield return new WaitForSeconds(1);
			}
		}
		//enable all the scripts and animation once the count is down
		MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   
		foreach(MonoBehaviour script in scriptComponentsGameControl) {
			script.enabled = true;
		}
		
		wall1.GetComponent<ControlTierra>().enabled = true;
		wall2.GetComponent<ControlTierra>().enabled = true;
		ground.GetComponent<ControlTierra>().enabled = true;
		character.GetComponent<Animation>().enabled = true;
		//disable the GUIText once the countdown is done with
		guiTextCountdown.text = "";
		//guiTextCountdown.enabled = false;
	}
}

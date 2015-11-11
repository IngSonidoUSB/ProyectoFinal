using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	private float objectSpeed = -20f;
	
	void Update () {
		if(Time.timeScale==1){
			//transform.Translate(0, 0, objectSpeed);
			transform.Translate(new Vector3(0, 0, objectSpeed)*Time.deltaTime);
		}
	}
}
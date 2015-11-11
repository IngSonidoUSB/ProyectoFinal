using UnityEngine;
using System.Collections;

public class ControlTierra : MonoBehaviour {

	public float speed = .5f;
	
	void Update () {
		float offset = Time.time * speed;                             
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset); 
	}
}

using UnityEngine;
using System.Collections;

public class Rotar : MonoBehaviour {

	public float velocidad = 1;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Time.deltaTime * velocidad, 0, 0);
	}
}

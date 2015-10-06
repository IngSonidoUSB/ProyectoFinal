using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	private Animation Menu;

	// Use this for initialization
	void Start () {
		GetComponent<UnityEngine.Animation>().wrapMode = WrapMode.Loop;
		GetComponent<UnityEngine.Animation>().Play();


	
	}
}
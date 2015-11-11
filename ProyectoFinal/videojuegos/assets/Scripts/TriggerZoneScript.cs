using UnityEngine;
using System.Collections;

public class TriggerZoneScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Destroy(other.gameObject.transform.parent.gameObject);
		//Debug.Log("Trigger Enter!!!!!!!");
	}

	void OnCollisionEnter(Collision other){
		Destroy(other.gameObject.transform.parent.gameObject);
		Destroy(other.gameObject);
		//Debug.Log("Trigger Enter!!!!!!!");
	}
}

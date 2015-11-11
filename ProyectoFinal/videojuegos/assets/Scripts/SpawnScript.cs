using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public List<GameObject> obstacle;
	public GameObject powerup;

	float timeElapsed = 0;
	float spawnCycle = 0.5f;
	bool spawnPowerup = true;

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnPowerup)
			{
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y+Random.Range(0, 3), pos.z);
			}
			else
			{
				//int size = obstacle.Count;
				//Random.Range(0,obstacle.Count())
				int indexSelectedObstacle = Random.Range(0,obstacle.Count);
				//Debug.Log("Obstaculo seleccionado: " + indexSelectedObstacle);
				temp = (GameObject)Instantiate(obstacle[indexSelectedObstacle]);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			
			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
	}
}
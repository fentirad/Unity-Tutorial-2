using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValue;

	void Start () {
		SpawnWaves ();
	}

	void SpawnWaves() {
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (hazard, spawnPosition, spawnRotation);
	}
}

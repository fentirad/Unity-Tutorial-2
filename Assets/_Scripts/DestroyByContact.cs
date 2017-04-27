using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		string otherTag = other.tag;
		Transform thisTransform = gameObject.transform;
		Transform otherTransform = other.transform; 

		if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) {
			return;
		}

		if (explosion != null) {
			Instantiate (explosion, thisTransform.position, thisTransform.rotation);
		}

		if (other.CompareTag("Player")) {
			Instantiate (playerExplosion, otherTransform.position, otherTransform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		string otherTag = other.tag;
		Transform thisTransform = gameObject.transform;
		Transform otherTransform = other.transform; 

		if (otherTag == "Boundary") {
			return;
		}

		Instantiate (explosion, thisTransform.position, thisTransform.rotation);

		if (otherTag == "Player") {
			Instantiate (playerExplosion, otherTransform.position, otherTransform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}

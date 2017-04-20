using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;

	void Start() {
		Rigidbody moverRigidbody = gameObject.GetComponent<Rigidbody> ();

		moverRigidbody.velocity = transform.forward * speed;
	}
}

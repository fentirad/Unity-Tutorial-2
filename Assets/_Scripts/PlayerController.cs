using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRate;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	private float nextFire;

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate<GameObject>(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Rigidbody playerRigidbody = gameObject.GetComponent<Rigidbody> ();

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		playerRigidbody.velocity = movement * speed;

		playerRigidbody.position = new Vector3 (
			Mathf.Clamp(playerRigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(playerRigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		playerRigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, playerRigidbody.velocity.x * - tilt);
	}
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

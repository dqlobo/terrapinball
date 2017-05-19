using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellScript : MonoBehaviour {

	Vector3 startPosition;
	Rigidbody rb; 
	void Start () {
		rb = GetComponent<Rigidbody> ();
		startPosition = transform.position;
	}

	void Update () {
		if (Mathf.Abs (Mathf.Abs (transform.eulerAngles.x) - 90) > 5) {
			transform.localEulerAngles = new Vector3 (-90, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("DEAD")) {
			EventManager.TriggerEvent ("DEAD");
			transform.position = startPosition;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;  
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.CompareTag ("WALL")) {
			GetComponent<AudioSource> ().Play ();

		}
	}
}

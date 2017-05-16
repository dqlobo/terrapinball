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

	void OnTriggerEnter(Collider other) {
		if (other.tag == "DEAD") {
			EventManager.TriggerEvent ("DEAD");
			transform.position = startPosition;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;  
		}
	}
}

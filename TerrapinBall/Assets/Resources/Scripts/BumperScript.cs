using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour {
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		EventManager.TriggerEvent ("PointsSmall");
		Rigidbody otherRB = collision.rigidbody;
		if (otherRB != null
			&& collision.contacts.Length > 0) {
			ContactPoint c = collision.contacts [0];						
			otherRB.AddForce (Vector3.Reflect(otherRB.velocity.normalized * 15000, c.normal));
			GetComponent<AudioSource> ().Play ();
		}
	}
}

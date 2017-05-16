using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarpScript : MonoBehaviour {

	public Transform warpTo;

	void OnTriggerEnter(Collider other) {
		StartCoroutine (HoldRoutine (1.0F,other.gameObject));
	}

	IEnumerator HoldRoutine(float duration, GameObject gameObject) {
		yield return new WaitForSeconds(duration);
		gameObject.transform.position = warpTo.position;
		EventManager.TriggerEvent ("PointsSmall");
		yield return new WaitForSeconds(duration);
		yield return new WaitForFixedUpdate ();
		gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 50000 + Vector3.left * 20000);
	}
}

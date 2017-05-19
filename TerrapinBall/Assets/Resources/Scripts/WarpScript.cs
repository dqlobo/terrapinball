using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarpScript : MonoBehaviour {

	public Transform warpTo;
	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other) {
		StartCoroutine (HoldRoutine (1.0F,other.gameObject));
	}

	IEnumerator HoldRoutine(float duration, GameObject gameObject) {
		if (!audioSource.isPlaying) {
			audioSource.Play ();
		}
		yield return new WaitForSeconds(duration);
		gameObject.transform.position = warpTo.position;
		EventManager.TriggerEvent ("PointsBig");

		yield return new WaitForSeconds(duration);
		yield return new WaitForFixedUpdate ();
		gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 50000 + Vector3.left * 20000);
	}
}

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
		gameObject.transform.rotation = warpTo.rotation;
		yield return new WaitForFixedUpdate ();

		EventManager.TriggerEvent ("PointsBig");
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * -5000 + transform.right * -2000);
	}
}

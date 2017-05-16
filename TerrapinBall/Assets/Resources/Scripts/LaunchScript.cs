using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.
public class LaunchScript : MonoBehaviour {

	UnityAction launchAction;
	Rigidbody rb;

	void OnEnable () {
		launchAction = new UnityAction (DoLaunch);
		EventManager.StartListening ("LAUNCH", launchAction);
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void OnDisable () {
		EventManager.StopListening ("LAUNCH", launchAction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DoLaunch () {	
		GetComponent<AudioSource> ().Play ();
		StartCoroutine (LaunchMove ());
	}

	IEnumerator LaunchMove () {
		float upSpeed = 1F,
			downSpeed = .1F, 
			scale = 2.0F;
		for (int i = 0; i < (1/upSpeed); i++) {
			yield return new WaitForFixedUpdate ();
			rb.MovePosition(transform.position + transform.forward * upSpeed * scale);		
		}
		for (int i = 0; i < (1/downSpeed); i++) {
			yield return new WaitForFixedUpdate ();		
			rb.MovePosition(transform.position - transform.forward * downSpeed * scale);	
		}
	}


}

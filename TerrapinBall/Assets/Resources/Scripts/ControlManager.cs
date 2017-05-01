using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ControlManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				EventManager.TriggerEvent ("LAUNCH");
			}
		}
	}
}

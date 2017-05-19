using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ControlManager : MonoBehaviour {


	void Update () {
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				EventManager.TriggerEvent ("LAUNCH");
			}
		}
		// have not yet migrated controls for flippers to here yet
		// can handle platform-specific controls here
	}
}

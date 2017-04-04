using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {

	// if not left flipper, use negative sign before angle
	public bool isLeftFlipper;
	bool isEngaged;
	KeyCode key;
	Vector3 baseAngle;
	Rigidbody rb;
	void Start () {
		isEngaged = false;		
		key = isLeftFlipper ? KeyCode.LeftArrow : KeyCode.RightArrow;
		baseAngle = transform.eulerAngles;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckControls ();
	}

	void CheckControls () {
		if (Input.GetKeyUp (key)) {
			isEngaged = false;
			StopCoroutine ("ToggleFlipper");
			StartCoroutine (ToggleFlipper (0.005F));
		} else if (Input.GetKeyDown (key)) {			
			isEngaged = true;
			StopCoroutine ("ToggleFlipper");
			StartCoroutine (ToggleFlipper (0.07F));		
		} 	
	}

	float getTargetAngle(bool engagedFlag) {
		return engagedFlag ^ isLeftFlipper ? 90.0F : -90.0F;	
	}

	IEnumerator ToggleFlipper (float duration) {

		yield return new WaitForFixedUpdate();
		for (float t = 0; t < 1; t += Time.fixedDeltaTime / duration) {
			Vector3 rotateAmount = baseAngle + Vector3.forward * getTargetAngle (isEngaged) * t;			
			if (!isEngaged){
				rotateAmount = baseAngle;				
			}

			rb.MoveRotation(Quaternion.Euler (rotateAmount));

			yield return new WaitForFixedUpdate();
		}
	}

}

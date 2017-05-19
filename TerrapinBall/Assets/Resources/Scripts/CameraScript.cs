using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform follow;
	public Vector3 minPosition;
	public Vector3 maxPosition;

	void Start () {
		UpdatePosition ();
	}

	void Update () {
		UpdatePosition ();
	}

	void UpdatePosition() {
		Vector3 newPos = transform.position;
		if (InCamRange (follow.position.x, 'x')) {
			newPos.x = follow.position.x;
		}
		if (InCamRange (follow.position.y, 'y')) {
			newPos.y = follow.position.y + 30.0F;
		}
		if (InCamRange (follow.position.z, 'z')) {
			newPos.z = follow.position.z - 30.0F;
		}
		transform.position = newPos;
	}

	bool InCamRange(float val, char axis) {
		switch (axis) {
		case 'x':
			return InRange (val, minPosition.x, maxPosition.x);
		case 'y':
			return InRange (val, minPosition.y, maxPosition.y);
		case 'z':				
			return InRange (val, minPosition.z, maxPosition.z);
		default:
			return false;
		}
	}

	bool InRange(float val, float min, float max) {
		return val <= max && val >= min;
	}
}

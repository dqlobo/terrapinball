using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform follow;
	Vector3 oldFollowPosition;
	public Vector3 minPosition;
	public Vector3 maxPosition;

	void Start () {
		oldFollowPosition = new Vector3(follow.position.x, follow.position.y, follow.position.z);

	}

	void Update () {
		Vector3 followPosition = transform.position + follow.position - oldFollowPosition;
		float xPos = !InCamRange (follow.position.x, 'x') ? transform.position.x : followPosition.x,
		yPos = !InCamRange (follow.position.y, 'y') ? transform.position.y : followPosition.y,
		zPos = !InCamRange (follow.position.z, 'z') ? transform.position.z : followPosition.z;
		transform.position = new Vector3(xPos, yPos, zPos);
		oldFollowPosition = follow.position;
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

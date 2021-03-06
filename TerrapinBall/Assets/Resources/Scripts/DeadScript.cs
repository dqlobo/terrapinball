﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadScript : MonoBehaviour {
	public GameObject[] lifeIcons;
	int lifeCount;

	void Start () {
		lifeCount = lifeIcons.Length - 1;
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine (LoseLife ());
	}

	IEnumerator LoseLife() {
		if (lifeCount >= 0) {
			for (int i = 1; i < 100; i++) {
				GameObject curr = lifeIcons [lifeCount];
				Image img = curr.GetComponent<Image> ();
				img.color = new Color (0,0,0, 1.0F/i);
				yield return new WaitForFixedUpdate ();
			}
			lifeIcons [lifeCount--].SetActive (false);
			EventManager.TriggerEvent ("DEAD");
		} else {
			SceneManager.LoadScene ("EndScene");			
		}
		yield return null;
	}
}

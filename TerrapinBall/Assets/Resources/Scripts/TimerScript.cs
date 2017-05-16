using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {
	public float secondsRemaining;
	private Text timeLabel;

	void Start () {
		timeLabel = GetComponent<Text> ();
	}
	void Update () {
		DecrementTime (Time.deltaTime);
	}

	void DecrementTime (float seconds) {
		if (secondsRemaining <= 0)
			return;
		
		secondsRemaining -= seconds;		
		int mins = (int) secondsRemaining / 60;
		int secs = (int) secondsRemaining % 60;
		timeLabel.text = string.Format ("{0:D2}:{1:D2}", mins, secs);

		if (secondsRemaining <= 0) {
			EventManager.TriggerEvent ("TimeUp");
			SceneManager.LoadScene ("MenuScene");
		}
	}
}

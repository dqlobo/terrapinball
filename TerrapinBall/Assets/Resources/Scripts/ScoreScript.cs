using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class ScoreScript : MonoBehaviour {
	public AudioClip pointUpSound;
	Text textLabel;
	UnityAction smallBumpListener;
	UnityAction bigBumpListener;

	AudioSource audioSrc;

	void Start () {
		Score.score = 0;
		textLabel = GetComponent<Text> ();
		audioSrc = GetComponent<AudioSource> ();
	}

	void Awake () {
		smallBumpListener = new UnityAction (bumpScoreSmall);
		bigBumpListener = new UnityAction (bumpScoreBig);

	}

	void OnEnable () {
		EventManager.StartListening ("PointsSmall", smallBumpListener);
		EventManager.StartListening ("PointsBig", bigBumpListener);

	}

	void OnDisable () {
		EventManager.StopListening ("PointsSmall", smallBumpListener);
		EventManager.StopListening ("PointsBig", bigBumpListener);


	}

	private void bumpScoreSmall () {
		StartCoroutine(scoreBumpIterator(120));
	}
	private void bumpScoreBig () {
		StartCoroutine(scoreBumpIterator(1000));
	}

	public void bumpScore (int amount) {
		Score.score += amount;
		audioSrc.Play ();
		textLabel.text = Score.score + "";
		checkLetterLights ();
	}

	void checkLetterLights() {
		if (Score.score > 120*50)
			EventManager.TriggerEvent ("ActivateLetterS");
		else if (Score.score > 120*40)
			EventManager.TriggerEvent ("ActivateLetterP");
		else if (Score.score > 120*20)
			EventManager.TriggerEvent ("ActivateLetterR");
		else if (Score.score > 120*5)
			EventManager.TriggerEvent ("ActivateLetterE");
		else if (Score.score > 120)
			EventManager.TriggerEvent ("ActivateLetterT");
	}

	IEnumerator scoreBumpIterator(int amount) {
		int curr = amount,
			temp = 0,
			factor = 10;
		while (curr > 0) {
			temp = (int) Mathf.Max((int) amount / factor, (int)amount % factor);
			bumpScore (temp);
			curr -= temp;
			yield return new WaitForFixedUpdate ();
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class ScoreScript : MonoBehaviour {
	public AudioClip pointUpSound;
	int score;
	Text textLabel;
	UnityAction smallBumpListener;
	AudioSource audioSrc;

	void Start () {
		score = 0;
		textLabel = GetComponent<Text> ();
		audioSrc = GetComponent<AudioSource> ();
	}

	void Awake () {
		smallBumpListener = new UnityAction (bumpScoreSmall);
	}

	void OnEnable () {
		EventManager.StartListening ("PointsSmall", smallBumpListener);
	}

	void OnDisable () {
		EventManager.StopListening ("PointsSmall", smallBumpListener);

	}
	
	// Update is called once per frame
	void Update () {

	}

	private void bumpScoreSmall () {
//		bumpScore (120);
		StartCoroutine(scoreBumpIterator(120));
		
	}

	public void bumpScore (int amount) {
		score += amount;
		audioSrc.Play ();
		textLabel.text = score + "";
		checkLetterLights ();
	}

	void checkLetterLights() {
		if (score > 120*20)
			EventManager.TriggerEvent ("ActivateLetterS");
		else if (score > 120*15)
			EventManager.TriggerEvent ("ActivateLetterP");
		else if (score > 120*10)
			EventManager.TriggerEvent ("ActivateLetterR");
		else if (score > 120*5)
			EventManager.TriggerEvent ("ActivateLetterE");
		else if (score > 120)
			EventManager.TriggerEvent ("ActivateLetterT");
	}

	IEnumerator scoreBumpIterator(int amount) {
		int curr = amount,
			temp = 0,
			factor = 10;
		while (curr > 0) {
			temp = (int) Mathf.Max((int) amount / factor, (int)amount % factor);
			print (temp);
			print (amount);
			bumpScore (temp);
			curr -= temp;
			yield return new WaitForFixedUpdate ();
		}
	}

}

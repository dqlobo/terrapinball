using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreScript : MonoBehaviour {
	int score;
	Text textLabel;
	UnityAction smallBumpListener;

	void Start () {
		score = 0;
		textLabel = GetComponent<Text> ();
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
		bumpScore (120);
	}

	public void bumpScore (int amount) {
		score += amount;
		textLabel.text = score + "";
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


}

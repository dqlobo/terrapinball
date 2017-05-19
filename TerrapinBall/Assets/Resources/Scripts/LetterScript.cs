using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterScript : MonoBehaviour {

	UnityAction activateListener;
	UnityAction deactivateListener;
	Light light;
	SpriteRenderer letterSprite;

	public char letter;

	void OnEnable () {
		activateListener = new UnityAction (LightOn);
		deactivateListener = new UnityAction (LightOn);
		light = GetComponent<Light> ();
		letterSprite = GetComponent<SpriteRenderer> ();
		SetLightOn (false);
		EventManager.StartListening ("ActivateLetter" + letter, activateListener);
		EventManager.StartListening ("DeactivateLetter" + letter, deactivateListener);
	}

	void OnDisable () {
		EventManager.StopListening ("ActivateLetter" + letter, activateListener);
		EventManager.StopListening ("DeactivateLetter" + letter, deactivateListener);
	}
		
	void LightOn () {
		SetLightOn (true);
	}

	void LightOff () {
		SetLightOn (false);
	}

	void SetLightOn(bool lightOn) {		
//		print ("set light: " +letter+' '+ lightOn);
		light.intensity = lightOn ? 1F : 0F;
		letterSprite.sortingOrder = lightOn ? 2 : 0;
		light.range = lightOn ? 15F : 0F;
	}
}
